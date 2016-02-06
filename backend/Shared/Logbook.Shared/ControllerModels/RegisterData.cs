﻿namespace Logbook.Shared.ControllerModels
{
    public class RegisterData
    {
        public string EmailAddress { get; set; }
        public string PasswordSHA256Hash { get; set; }
        public string PreferredLanguage { get; set; }
    }
}