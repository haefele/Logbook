﻿using System.Threading.Tasks;

namespace Logbook.Server.Contracts.Social
{
    public interface IMicrosoftService : IService
    {
        Task<string> GetLoginUrlAsync(string redirectUrl);

        Task<string> ExchangeCodeForTokenAsync(string redirectUrl, string code);

        Task<MicrosoftUser> GetMeAsync(string token);
    }
}