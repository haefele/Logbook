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
    public class EmailTemplateMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EmailTemplateMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Logbook.Localization.Server.EmailTemplateMessages", typeof(EmailTemplateMessages).Assembly);
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
        ///   Looks up a localized string similar to Body @@Url@@.
        /// </summary>
        public static string ConfirmEmail_Body {
            get {
                return ResourceManager.GetString("ConfirmEmail_Body", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Subject.
        /// </summary>
        public static string ConfirmEmail_Subject {
            get {
                return ResourceManager.GetString("ConfirmEmail_Subject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your new password is &quot;@@NewPassword@@&quot;..
        /// </summary>
        public static string PasswordResetted_Body {
            get {
                return ResourceManager.GetString("PasswordResetted_Body", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New Logbook password.
        /// </summary>
        public static string PasswordResetted_Subject {
            get {
                return ResourceManager.GetString("PasswordResetted_Subject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Click on the following link to reset your logbook password:
        ///@@Url@@.
        /// </summary>
        public static string ResetPassword_Body {
            get {
                return ResourceManager.GetString("ResetPassword_Body", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Logbook password reset.
        /// </summary>
        public static string ResetPassword_Subject {
            get {
                return ResourceManager.GetString("ResetPassword_Subject", resourceCulture);
            }
        }
    }
}
