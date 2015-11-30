﻿using JetBrains.Annotations;
using LiteGuard;

namespace Logbook.Server.Contracts.Commands.Authentication
{
    public class LiveLoginCommand : ICommand<string>
    {
        public LiveLoginCommand([NotNull]string code, [NotNull]string redirectUrl)
        {
            Guard.AgainstNullArgument(nameof(code), code);
            Guard.AgainstNullArgument(nameof(redirectUrl), redirectUrl);

            this.Code = code;
            this.RedirectUrl = redirectUrl;
        }

        public string Code { get; }
        public string RedirectUrl { get; }   
    }
}