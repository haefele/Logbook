﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Logbook.Server.Contracts;
using Logbook.Server.Contracts.Emails;
using Logbook.Server.Infrastructure;
using Logbook.Shared;

namespace Logbook.Worker.EmailSender
{
    public class EmailSenderWorker : IWorker
    {
        private readonly IEmailQueue _emailQueue;
        private readonly IEmailSender _emailSender;

        public EmailSenderWorker(IEmailQueue emailQueue, IEmailSender emailSender)
        {
            Guard.NotNull(emailQueue, nameof(emailQueue));
            Guard.NotNull(emailSender, nameof(emailSender));

            this._emailQueue = emailQueue;
            this._emailSender = emailSender;
        }

        public Task StartAsync()
        {
            return Task.CompletedTask;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                var email = await this._emailQueue.TryDequeueMailAsync();
                if (email != null)
                {
                    try
                    {
                        AppInsights.GenerateAsyncAwareOperationId();

                        AppInsights.Client.TrackEvent("Sending Email");

                        await this._emailSender.SendMailAsync(email);
                        await this._emailQueue.RemoveAsync(email);
                    }
                    catch (Exception exception)
                    {
                        await this._emailQueue.TryAgainLaterAsync(email);
                        
                        AppInsights.Client.TrackException(exception);
                    }
                }
            }
        }
    }
}
