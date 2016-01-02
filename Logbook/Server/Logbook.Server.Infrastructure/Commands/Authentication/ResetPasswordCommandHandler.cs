﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Logbook.Server.Contracts.Commands;
using Logbook.Server.Contracts.Commands.Authentication;
using Logbook.Server.Contracts.Emails;
using Logbook.Server.Contracts.Encryption;
using Logbook.Server.Infrastructure.Emails.Templates;
using Logbook.Server.Infrastructure.Exceptions;
using Logbook.Server.Infrastructure.Extensions;
using Logbook.Server.Infrastructure.Raven.Indexes;
using Logbook.Shared.Entities.Authentication;
using Logbook.Shared.Extensions;
using Raven.Client;
using Raven.Client.Linq;

namespace Logbook.Server.Infrastructure.Commands.Authentication
{
    public class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand, object>
    {
        private readonly IAsyncDocumentSession _documentSession;
        private readonly IJsonWebTokenService _jsonWebTokenService;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IEmailSender _emailSender;

        public ResetPasswordCommandHandler(IAsyncDocumentSession documentSession, IJsonWebTokenService jsonWebTokenService, IEmailTemplateService emailTemplateService, IEmailSender emailSender)
        {
            this._documentSession = documentSession;
            this._jsonWebTokenService = jsonWebTokenService;
            this._emailTemplateService = emailTemplateService;
            this._emailSender = emailSender;
        }

        public async Task<object> Execute(ResetPasswordCommand command, ICommandScope scope)
        {
            var user = await this._documentSession
                .Query<User, Users_ByEmailAddress>()
                .Where(f => f.EmailAddress == command.EmailAddress)
                .FirstOrDefaultAsync()
                .WithCurrentCulture();

            var authenticationData = await this._documentSession
                .LoadAsync<AuthenticationData>(AuthenticationData.CreateId(user.Id))
                .WithCurrentCulture();

            if (authenticationData.Authentications.Any(f => f.Kind == AuthenticationKind.Logbook) == false)
                throw new NoLogbookLoginToResetPasswordException();

            var token = this._jsonWebTokenService.GenerateForPasswordReset(command.EmailAddress);

            var emailTemplate = new ResetPasswordEmailTemplate
            {
                Url = $"{command.OwinContext.Request.Scheme}://{command.OwinContext.Request.Host}/Authentication/PasswordReset/Finish?token={token.Token}",
                ValidDuration = token.ValidDuration
            };

            var email = this._emailTemplateService.GetTemplate(emailTemplate);
            email.Receiver = user.EmailAddress;

            await this._emailSender
                .SendMailAsync(email)
                .WithCurrentCulture();

            return new object();
        }
    }
}