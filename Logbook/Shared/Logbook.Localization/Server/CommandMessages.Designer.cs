﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logbook.Localization.Server {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class CommandMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommandMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Logbook.Localization.Server.CommandMessages", typeof(CommandMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot login with a password for the email address &quot;{0}&quot;..
        /// </summary>
        public static string CannotLoginWithPassword {
            get {
                return ResourceManager.GetString("CannotLoginWithPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This email address is already in use..
        /// </summary>
        public static string EmailIsNotAvailable {
            get {
                return ResourceManager.GetString("EmailIsNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect password..
        /// </summary>
        public static string IncorrectPassword {
            get {
                return ResourceManager.GetString("IncorrectPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No session information were given..
        /// </summary>
        public static string NoAuthenticationTokenGiven {
            get {
                return ResourceManager.GetString("NoAuthenticationTokenGiven", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No user exists with the email address &quot;{0}&quot;..
        /// </summary>
        public static string NoUserFound {
            get {
                return ResourceManager.GetString("NoUserFound", resourceCulture);
            }
        }
    }
}
