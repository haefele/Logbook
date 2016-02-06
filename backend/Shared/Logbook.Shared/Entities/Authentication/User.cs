﻿using System.Collections.Generic;
using Logbook.Shared.Entities.Summoners;

namespace Logbook.Shared.Entities.Authentication
{
    public class User : AggregateRoot
    {
        public User()
        {
            this.Authentications = new List<AuthenticationKindBase>();
            this.WatchSummoners = new List<Summoner>();
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the preferred language.
        /// (For example: en-US, de-DE)
        /// The <see cref="PreferredLanguage"/> is optional and not required.
        /// </summary>
        public string PreferredLanguage { get; set; }
        /// <summary>
        /// Gets or sets the authentications this user can use to login.
        /// </summary>
        public IList<AuthenticationKindBase> Authentications { get; set; }
        /// <summary>
        /// Gets or sets the summoners that this user is watching.
        /// </summary>
        public IList<Summoner> WatchSummoners { get; set; } 
    }
}