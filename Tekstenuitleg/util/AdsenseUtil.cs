using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursusIndex.util
{
    public class AdsenseUtil
    {
        public static string InsertAdsense(string text, string insertAfterFirst)
        {
            int endOfFirtsParagraph = text.IndexOf(insertAfterFirst);

            if (endOfFirtsParagraph == -1)
            {
                return text;
            }

            return text.Substring(0, endOfFirtsParagraph + 4) + AddAdsense() + text.Substring(endOfFirtsParagraph + 4);
        }



        private static string AddAdsense()
        {
            string adsenseMiddle = "<div class=\"adsenseMiddle\"><script type=\"text/javascript\"><!--\n" +
                                   "google_ad_client = \"ca-pub-4003168380759642\";" +
                                   " /* tekst midden */ " +
                                   "google_ad_slot = \"2663832624\";" +
                                   "google_ad_width = 336;" +
                                   "google_ad_height = 280;" +
                                   "//-->" +
                                   "</script>" +
                                   "<script type=\"text/javascript\"" +
                                   "src=\"http://pagead2.googlesyndication.com/pagead/show_ads.js\">" +
                                   "</script></div>";
            return adsenseMiddle;
        }
    }
}