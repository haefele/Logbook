﻿using System;
using System.Collections.Generic;
using JWT;
using Logbook.Server.Contracts.Encryption;
using Logbook.Server.Infrastructure.Exceptions;
using Logbook.Server.Infrastructure.Extensions;
using Logbook.Shared;
using Logbook.Shared.Models;
using Metrics.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonWebToken = Logbook.Shared.Models.JsonWebToken;

namespace Logbook.Server.Infrastructure.Encryption
{
    public class JsonWebTokenService : IJsonWebTokenService
    {
        public JsonWebToken Generate<T>(T payload, TimeSpan validDuration)
        {
            var expiresAt = DateTime.UtcNow.Add(validDuration).StripEverythingAfterSeconds();

            var actualPayload = this.ToDictionary(payload);
            actualPayload["iss"] = Constants.Authentication.JWTIssuer;
            actualPayload["exp"] = expiresAt.ToUnixTime();

            var token = JWT.JsonWebToken.Encode(actualPayload, Config.AuthenticationKeyPhrase, JwtHashAlgorithm.HS256);

            return new JsonWebToken
            {
                ExpiresAt = expiresAt,
                Token = token
            };
        }

        public T ValidateAndDecode<T>(string jsonWebToken)
        {
            try
            {
                var decodedTokenAsJsonString = JWT.JsonWebToken.Decode(jsonWebToken, Config.AuthenticationKeyPhrase, verify: true);
                return JsonConvert.DeserializeObject<T>(decodedTokenAsJsonString);
            }
            catch (SignatureVerificationException)
            {
                throw new JsonWebTokenTimedOutException();
            }
            catch (Exception)
            {
                throw new InvalidJsonWebTokenException();
            }
        }

        private Dictionary<string, object> ToDictionary(object payload)
        {
            string json = JsonConvert.SerializeObject(payload);
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }
    }
}