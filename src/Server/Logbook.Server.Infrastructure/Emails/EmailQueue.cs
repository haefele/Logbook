﻿using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Logbook.Server.Contracts.Emails;
using Logbook.Server.Infrastructure.Configuration;
using Logbook.Shared;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace Logbook.Server.Infrastructure.Emails
{
    public class EmailQueue : IEmailQueue
    {
        #region Fields
        private readonly CloudQueueClient _queueClient;
        private readonly ConcurrentDictionary<Email, CloudQueueMessage> _dequeuedMessages;
        private CloudQueue _queue;
        #endregion

        #region Constructors
        public EmailQueue(CloudQueueClient queueClient)
        {
            Guard.NotNull(queueClient, nameof(queueClient));

            this._queueClient = queueClient;

            this._dequeuedMessages = new ConcurrentDictionary<Email, CloudQueueMessage>();
        }
        #endregion

        #region Implementation of IEmailQueue
        public async Task EnqueueMailAsync(Email email)
        {
            Guard.NotNull(email, nameof(email));

            var queue = await this.GetQueueAsync();
            var message = new CloudQueueMessage(JsonConvert.SerializeObject(email));

            await queue.AddMessageAsync(message, null, TimeSpan.FromSeconds(20), null, null);
        }

        public async Task<Email> TryDequeueMailAsync()
        {
            var queue = await this.GetQueueAsync();
            var message = await queue.GetMessageAsync();

            if (message == null)
                return null;

            var email = JsonConvert.DeserializeObject<Email>(message.AsString);
            this._dequeuedMessages.TryAdd(email, message);

            return email;
        }

        public async Task RemoveAsync(Email email)
        {
            Guard.NotNull(email, nameof(email));
            
            CloudQueueMessage message;
            if (this._dequeuedMessages.TryRemove(email, out message))
            {
                var queue = await this.GetQueueAsync();
                await queue.DeleteMessageAsync(message);
            }
        }

        public async Task TryAgainLaterAsync(Email email)
        {
            Guard.NotNull(email, nameof(email));

            CloudQueueMessage message;
            if (this._dequeuedMessages.TryRemove(email, out message))
            {
                var queue = await this.GetQueueAsync();
                await queue.UpdateMessageAsync(message, TimeSpan.FromSeconds(Config.Email.OnErrorTryToSendEmailAgainAfterMinutes), MessageUpdateFields.Visibility);
            }
        }
        #endregion

        #region Private Methods
        private async Task<CloudQueue> GetQueueAsync()
        {
            if (this._queue != null)
                return this._queue;

            this._queue = this._queueClient.GetQueueReference(Config.Azure.EmailQueueName);
            await this._queue.CreateIfNotExistsAsync();

            return this._queue;
        }
        #endregion
    }
}