﻿using System;
using System.Linq;
using Logbook.Server.Infrastructure;
using Microsoft.Owin.Hosting;
using Raven.Abstractions.Extensions;

namespace Logbook.Server.Hosts.Service
{
    public class LogbookService
    {
        private IDisposable _webApp;

        public void Start()
        {
            var options = new StartOptions();
            options.Urls.AddRange(Config.Addresses.GetValue().Select(f => f.ToString()));

            this._webApp = WebApp.Start<Startup>(options);
        }

        public void Stop()
        {
            this._webApp?.Dispose();
        }
    }
}