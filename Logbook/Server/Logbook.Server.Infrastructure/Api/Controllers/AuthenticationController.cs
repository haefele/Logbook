﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LiteGuard;
using Logbook.Localization.Server;
using Logbook.Server.Contracts.Commands;
using Logbook.Server.Contracts.Commands.Authentication;
using Logbook.Server.Contracts.Social;
using Logbook.Server.Infrastructure.Exceptions;
using Logbook.Server.Infrastructure.Extensions;
using Logbook.Shared.Extensions;
using Logbook.Shared.Models;

namespace Logbook.Server.Infrastructure.Api.Controllers
{
    [RoutePrefix("Authentication")]
    public class AuthenticationController : BaseController
    {
        private readonly IMicrosoftService _microsoftService;
        private readonly IFacebookService _facebookService;
        private readonly IGoogleService _googleService;

        public AuthenticationController(ICommandExecutor commandExecutor, IMicrosoftService microsoftService, IFacebookService facebookService, IGoogleService googleService)
            : base(commandExecutor)
        {
            Guard.AgainstNullArgument(nameof(microsoftService), microsoftService);
            Guard.AgainstNullArgument(nameof(facebookService), facebookService);
            Guard.AgainstNullArgument(nameof(facebookService), googleService);

            this._microsoftService = microsoftService;
            this._facebookService = facebookService;
            this._googleService = googleService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<HttpResponseMessage> RegisterAsync(RegisterData data)
        {
            if (data?.EmailAddress == null || data?.PasswordSHA256Hash == null)
                throw new DataMissingException();

             await this.CommandExecutor
                .Execute(new RegisterCommand(data.EmailAddress, Convert.FromBase64String(data.PasswordSHA256Hash), data.PreferredLanguage, this.OwinContext))
                .WithCurrentCulture();

            return this.Request.GetMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("Register/Finish")]
        public async Task<HttpResponseMessage> FinishRegistrationAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new DataMissingException();

            var user = await this.CommandExecutor
                .Execute(new FinishRegistrationCommand(token))
                .WithCurrentCulture();

            return this.Request.GetMessageWithObject(HttpStatusCode.Created, user);
        }

        [HttpPost]
        [Route("Login/Logbook")]
        public async Task<HttpResponseMessage> LoginAsync(LoginData data)
        {
            if (data?.EmailAddress == null || data?.PasswordSHA256Hash == null)
                throw new DataMissingException();

            var token = await this.CommandExecutor
                .Execute(new LoginCommand(data.EmailAddress, Convert.FromBase64String(data.PasswordSHA256Hash)))
                .WithCurrentCulture();

            return this.Request.GetMessageWithObject(HttpStatusCode.OK, token);
        }

        [HttpGet]
        [Route("Login/Microsoft/Url")]
        public async Task<HttpResponseMessage> GetLoginLiveUrlAsync(string redirectUrl)
        {
            if (string.IsNullOrWhiteSpace(redirectUrl))
                throw new DataMissingException();

            var url = await this._microsoftService.GetLoginUrlAsync(redirectUrl).WithCurrentCulture();
            return this.Request.GetMessageWithObject(HttpStatusCode.OK, new {Url = url});
        }

        [HttpPost]
        [Route("Login/Microsoft")]
        public async Task<HttpResponseMessage> LoginLiveAsync(MicrosoftLoginData data)
        {
            if (data?.Code == null || data?.RedirectUrl == null)
                throw new DataMissingException();

            var token = await this.CommandExecutor
                .Execute(new MicrosoftLoginCommand(data.Code, data.RedirectUrl))
                .WithCurrentCulture();

            return this.Request.GetMessageWithObject(HttpStatusCode.OK, token);
        }

        [HttpGet]
        [Route("Login/Facebook/Url")]
        public async Task<HttpResponseMessage> GetLoginFacebookUrlAsync(string redirectUrl)
        {
            if (string.IsNullOrWhiteSpace(redirectUrl))
                throw new DataMissingException();

            var url = await this._facebookService.GetLoginUrlAsync(redirectUrl).WithCurrentCulture();
            return this.Request.GetMessageWithObject(HttpStatusCode.OK, new {Url = url});
        }

        [HttpPost]
        [Route("Login/Facebook")]
        public async Task<HttpResponseMessage> LoginFacebookAsync(FacebookLoginData data)
        {
            if (data?.Code == null || data?.RedirectUrl == null)
                throw new DataMissingException();

            var token = await this.CommandExecutor
                .Execute(new FacebookLoginCommand(data.Code, data.RedirectUrl))
                .WithCurrentCulture();

            return this.Request.GetMessageWithObject(HttpStatusCode.OK, token);
        }

        [HttpGet]
        [Route("Login/Google/Url")]
        public async Task<HttpResponseMessage> GetLoginGoogleUrlAsync(string redirectUrl)
        {
            if (string.IsNullOrWhiteSpace(redirectUrl))
                throw new DataMissingException();

            var url = await this._googleService.GetLoginUrlAsync(redirectUrl).WithCurrentCulture();
            return this.Request.GetMessageWithObject(HttpStatusCode.OK, new {Url = url});
        }

        [HttpPost]
        [Route("Login/Google")]
        public async Task<HttpResponseMessage> LoginGoogleAsync(GoogleLoginData data)
        {
            if (data?.Code == null || data?.RedirectUrl == null)
                throw new DataMissingException();

            var token = await this.CommandExecutor
                .Execute(new GoogleLoginCommand(data.Code, data.RedirectUrl))
                .WithCurrentCulture();

            return this.Request.GetMessageWithObject(HttpStatusCode.OK, token);
        }
    }
}