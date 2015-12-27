﻿using System.Threading.Tasks;

namespace Logbook.Server.Contracts.Social
{
    public interface IGoogleService : IService
    {
        Task<string> ExchangeCodeForTokenAsync(string redirectUrl, string code);

        Task<GoogleUser> GetMeAsync(string token);
    }
}