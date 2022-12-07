using KioskBox_Display.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace KioskBox_Display.Helpers
{
    public static class Extentions
    {
        public static string Localize(this string resourceKey, string resw = null)
        {
            try
            {
                string s;
                if (resw == null)
                {
                    s = new ResourceLoader().GetString(resourceKey);
                }
                else
                {
                    s = new Windows.ApplicationModel.Resources.ResourceLoader(resw).GetString(resourceKey);
                }
                return string.IsNullOrEmpty(s) ? resourceKey : s;
            }
            catch
            {
                return resourceKey.ToString();
            }
        }
        public static string Localize(this Localized resourceKey, string resw = null)
        {
            try
            {
                string s;
                if (resw == null)
                {
                    s = new ResourceLoader().GetString(resourceKey.ToString());
                }
                else
                {
                    s = new ResourceLoader(resw).GetString(resourceKey.ToString());
                }
                return string.IsNullOrEmpty(s) ? resourceKey.ToString() : s;
            }
            catch
            {
                return resourceKey.ToString();
            }
        }
    }
}
