﻿using System;
using System.Collections.Generic;
using Logbook.Shared.Configuration;

namespace Logbook.Server.Infrastructure
{
    public static class Config
    {
        static Config()
        {
            EnableDefaultMetrics = new BoolSetting("Logbook/EnableDefaultMetrics", false);
            CompressResponses = new BoolSetting("Logbook/CompressResponses", true);
            EnableDebugRequestResponseLogging = new BoolSetting("Logbook/EnableDebugRequestResponseLogging", false);
            FormatResponses = new BoolSetting("Logbook/FormatResponses", false);
            SqlServerConnectionString = new StringSetting("Logbook/SqlServerConnectionString", string.Empty);
            RecreateDatabase = new BoolSetting("Logbook/RecreateDatabase", false);
            UpdateDatabase = new BoolSetting("Logbook/UpdateDatabase", true);
            IterationCountForPasswordHashing = new IntSetting("Logbook/IterationCountForPasswordHashing", 10000);
            Addresses = new UriListSetting("Logbook/Addresses", new List<Uri> { new Uri("http://localhost") }, "|");
            AuthenticationKeyPhrase = new StringSetting("Logbook/AuthenticationKeyPhrase", string.Empty);
            LoginIsValidForDuration = new TimeSpanSetting("Logbook/LoginIsValidForDuration", TimeSpan.FromHours(8));
            MicrosoftClientId = new StringSetting("Logbook/MicrosoftClientId", string.Empty);
            MicrosoftClientSecret = new StringSetting("Logbook/MicrosoftClientSecret", string.Empty);
            FacebookAppId = new StringSetting("Logbook/FacebookAppId", string.Empty);
            FacebookAppSecret = new StringSetting("Logbook/FacebookAppSecret", string.Empty);
            GoogleClientId = new StringSetting("Logbook/GoogleClientId", string.Empty);
            GoogleClientSecret = new StringSetting("Logbook/GoogleClientSecret", string.Empty);
            SmtpHost = new StringSetting("Logbook/Smtp/Host", "localhost");
            SmtpPort = new IntSetting("Logbook/Smtp/Port", 25);
            SmtpUseDefaultCredentials = new BoolSetting("Logbook/Smtp/UseDefaultCredentials", true);
            SmtpUsername = new StringSetting("Logbook/Smtp/Username", string.Empty);
            SmtpPassword = new StringSetting("Logbook/Smtp/Password", string.Empty);
            SmtpUseSsl = new BoolSetting("Logbook/Smtp/UseSsl", false);
            ConfirmEmailIsValidForDuration = new TimeSpanSetting("Logbook/ConfirmEmailIsValidForDuration", TimeSpan.FromHours(2));
            ConfirmEmailKeyPhrase = new StringSetting("Logbook/ConfirmEmailKeyPhrase", string.Empty);
            ConfirmEmailSender = new StringSetting("Logbook/ConfirmEmailSender", "no-reply@logbook.xyz");
            PasswordResetKeyPhrase = new StringSetting("Logbook/PasswordResetKeyPhrase", string.Empty);
            PasswordResetIsValidForDuration = new TimeSpanSetting("Logbook/PasswordResetIsValidForDuration", TimeSpan.FromHours(2));
            PasswordResetEmailSender = new StringSetting("Logbook/PasswordResetEmailSender", string.Empty);
            PasswordResetNewPasswordLength = new IntSetting("Logbook/PasswordResetNewPasswordLength", 16);
            TwitterConsumerKey = new StringSetting("Logbook/TwitterConsumerKey", string.Empty);
            TwitterConsumerSecret = new StringSetting("Logbook/TwitterConsumerSecret", string.Empty);
            TwitterLoginKeyPhrase = new StringSetting("Logbook/TwitterLoginKeyPhrase", string.Empty);
            InDebugHoldOnException = new BoolSetting("Logbook/InDebugHoldOnException", true);
            RiotApiKey = new StringSetting("Logbook/RiotApiKey", string.Empty);
            RiotApiRateLimitPer10Seconds = new IntSetting("Logbook/RiotApiRateLimitPer10Seconds", 10);
            RiotApiRateLimitPer10Minutes = new IntSetting("Logbook/RiotApiRateLimitPer10Minutes", 500);
        }

        public static BoolSetting EnableDefaultMetrics { get; }
        public static BoolSetting CompressResponses { get; }
        public static BoolSetting EnableDebugRequestResponseLogging { get; }
        public static BoolSetting FormatResponses { get; }
        public static StringSetting SqlServerConnectionString { get; }
        public static BoolSetting RecreateDatabase { get; }
        public static BoolSetting UpdateDatabase { get; }
        public static IntSetting IterationCountForPasswordHashing { get; }
        public static UriListSetting Addresses { get; }
        public static StringSetting AuthenticationKeyPhrase { get; }
        public static TimeSpanSetting LoginIsValidForDuration { get; }
        public static StringSetting MicrosoftClientId { get; }
        public static StringSetting MicrosoftClientSecret { get; }
        public static StringSetting FacebookAppId { get; }
        public static StringSetting FacebookAppSecret { get; }
        public static StringSetting GoogleClientId { get; }
        public static StringSetting GoogleClientSecret { get; }
        public static StringSetting SmtpHost { get; }
        public static IntSetting SmtpPort { get; }
        public static BoolSetting SmtpUseDefaultCredentials { get; }
        public static StringSetting SmtpUsername { get; }
        public static StringSetting SmtpPassword { get; }
        public static BoolSetting SmtpUseSsl { get; }
        public static TimeSpanSetting ConfirmEmailIsValidForDuration { get; }
        public static StringSetting ConfirmEmailKeyPhrase { get; }
        public static StringSetting ConfirmEmailSender { get; }
        public static StringSetting PasswordResetKeyPhrase { get; }
        public static TimeSpanSetting PasswordResetIsValidForDuration { get; }
        public static StringSetting PasswordResetEmailSender { get; }
        public static IntSetting PasswordResetNewPasswordLength { get; }
        public static StringSetting TwitterConsumerKey { get; }
        public static StringSetting TwitterConsumerSecret { get; }
        public static StringSetting TwitterLoginKeyPhrase { get; }
        public static BoolSetting InDebugHoldOnException { get; }
        public static StringSetting RiotApiKey { get; }
        public static IntSetting RiotApiRateLimitPer10Seconds { get; }
        public static IntSetting RiotApiRateLimitPer10Minutes { get; }
    }
}