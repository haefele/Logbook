﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Logbook.Server.Contracts.Social;
using Logbook.Server.Infrastructure.Configuration;
using Logbook.Shared;
using Newtonsoft.Json.Linq;

namespace Logbook.Server.Infrastructure.Social
{
    public class FacebookService : IFacebookService
    {
        public Task<string> GetLoginUrlAsync(string redirectUrl)
        {
            Guard.NotNullOrWhiteSpace(redirectUrl, nameof(redirectUrl));

            string scope = string.Join(",", Constants.Authentication.FacebookRequiredScopes);

            var url = $"https://www.facebook.com/dialog/oauth" +
                      $"?client_id={Config.Security.FacebookAppId}" +
                      $"&redirect_uri={redirectUrl}" +
                      $"&scope={scope}" +
                      $"&response_type=code";

            return Task.FromResult(url);
        }

        public async Task<string> ExchangeCodeForTokenAsync(string redirectUrl, string code)
        {
            Guard.NotNullOrWhiteSpace(redirectUrl, nameof(redirectUrl));
            Guard.NotNullOrWhiteSpace(code, nameof(code));

            var client = new HttpClient();
            var response = await client.GetAsync($"https://graph.facebook.com/oauth/access_token" +
                                                 $"?client_id={Config.Security.FacebookAppId}" +
                                                 $"&redirect_uri={redirectUrl}" +
                                                 $"&client_secret={Config.Security.FacebookAppSecret}" +
                                                 $"&code={code}");

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var responseFormData = await response.Content.ReadAsStringAsync();
            var token = HttpUtility.ParseQueryString(responseFormData)["access_token"];

            if (await this.HasRequiredScopes(token) == false)
                return null;

            return token;
        }

        private async Task<bool> HasRequiredScopes(string token)
        {
            Guard.NotNullOrWhiteSpace(token, nameof(token));

            var client = new HttpClient();
            var response = await client.GetAsync($"https://graph.facebook.com/debug_token" +
                                                 $"?input_token={token}" +
                                                 $"&access_token={Config.Security.FacebookAppId}|{Config.Security.FacebookAppSecret}");

            if (response.StatusCode != HttpStatusCode.OK)
                return false;

            var responseJsonString = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(responseJsonString);

            var actualScopes = json
                .Value<JObject>("data")
                .Value<JArray>("scopes")
                .Select(f => f.Value<string>())
                .ToList();

            return Constants.Authentication.FacebookRequiredScopes
                .All(f => actualScopes.Contains(f));
        }

        public async Task<FacebookUser> GetMeAsync(string token)
        {
            Guard.NotNullOrWhiteSpace(token, nameof(token));

            var client = new HttpClient();
            var response = await client.GetAsync($"https://graph.facebook.com/me?fields=id,email,locale&access_token={token}");

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var responseJsonString = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(responseJsonString);

            var user = new FacebookUser
            {
                Id = json.Value<string>("id"),
                Email = json.Value<string>("email"),
                Locale = json.Value<string>("locale")?.Replace("_", "-")
            };

            if (string.IsNullOrWhiteSpace(user.Email) || 
                string.IsNullOrWhiteSpace(user.Locale))
                return null;

            return user;
        }
    }
}