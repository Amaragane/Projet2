using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Collections;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture
        /// </summary>
        public string SetCulture(string language)
        {
            string culture = null;
            if (string.IsNullOrEmpty(culture)) {
                switch (language)
                {
                    case "English": culture = "en"; return culture;
                    case "French": culture = "fr"; return culture;
                    case "Espagnol":culture = "es"; return culture;
                }
            }
            // TODO complete the code 
            // Default language is "en", french is "fr" and spanish is "es".
            
            return "en";
        }

        /// <summary>
        /// Update the culture cookie
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
