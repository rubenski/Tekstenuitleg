using System;
using System.Web;
using System.Web.SessionState;
using umbraco.interfaces;

namespace Tekstenuitleg.settings
{
    public class Settings
    {
        public static INode CurrentHomepage()
        {
            return GetSettings().CurrentHomepage();
        }

        public static INode CurrentCategory()
        {
            return GetSettings().CurrentCategory();
        }

        private static SettingsData GetSettings()
        {
            HttpSessionState session = HttpContext.Current.Session;
            Object data = session["siteSettings"];
            return (SettingsData) data;
        }

        public static string CurrentLanguage()
        {
            return GetSettings().CurrentLanguage();
        }
    }
}