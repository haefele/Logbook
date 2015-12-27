﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Logbook.Server.Contracts.Commands.Authentication;
using Logbook.Server.Contracts.Encryption;
using Logbook.Server.Contracts.Social;
using Logbook.Server.Infrastructure.Raven.Indexes;
using Logbook.Shared.Entities.Authentication;
using Logbook.Shared.Extensions;
using Raven.Client;

namespace Logbook.Server.Infrastructure.Commands.Authentication
{
    public class GoogleLoginCommandHandler : SocialLoginCommandHandler<GoogleLoginCommand>
    {
        private readonly IGoogleService _googleService;

        public GoogleLoginCommandHandler(IAsyncDocumentSession documentSession, IJsonWebTokenService jsonWebTokenService, IGoogleService googleService)
            : base(documentSession, jsonWebTokenService)
        {
            this._googleService = googleService;
        }

        protected override Task<string> ExchangeCodeForTokenAsync(GoogleLoginCommand command)
        {
            return this._googleService.ExchangeCodeForTokenAsync(command.RedirectUrl, command.Code);
        }

        protected override async Task<SocialLoginUser> GetMeAsync(string token)
        {
            var user = await this._googleService.GetMeAsync(token).WithCurrentCulture();

            if (user == null)
                return null;

            return new SocialLoginUser
            {
                EmailAddress = user.EmailAddress,
                Locale = user.Locale,
                Id = user.Id
            };
        }

        protected override Expression<Func<AuthenticationData_ByAllFields.Result, bool>> GetExpressionForSocialUserId(SocialLoginUser user)
        {
            return f => f.GoogleUserId == user.Id;
        }

        protected override AuthenticationKindBase CreateAuthentication(SocialLoginUser user)
        {
            return new GoogleAuthenticationKind
            {
                GoogleUserId = user.Id
            };
        }
    }
}