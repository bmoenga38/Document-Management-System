using System;
using System.IO;
using System.Web;

namespace FINNETT.data
{
    public class GlobalParameters
    {
        public static string mainPath = @"C:\\Finnett";
        public static string LogPath = mainPath + "\\systemlogs.txt";

        public static void SystemFileLogs(string datatowrite)
        {
            try
            {
                if (!File.Exists(LogPath))
                {
                    File.Create(LogPath);
                }

                File.AppendAllText(LogPath, "\n\n" + datatowrite + " \n\n");
            }
            catch (Exception) { }
        }

        public static string GetTimeStamp()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            return timestamp;
        }

        public static string GetSiteUrl()
        {
            string baseUrl = string.Empty;
            try
            {
                baseUrl = HttpContext.Current.Request.Url.AbsolutePath;
            }
            catch (Exception)
            {
                baseUrl = string.Empty;
            }
            return baseUrl;
        }

        public static string GetHostadress()
        {
            string ip = string.Empty;
            try
            {
                ip = HttpContext.Current.Request.UserHostAddress;
            }
            catch (Exception)
            {
                ip = string.Empty;
            }
            return ip;
        }

        public static string GetWebBrowserName()
        {
            string WebBrowserName = string.Empty;
            try
            {
                WebBrowserName = HttpContext.Current.Request.Browser.Browser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return WebBrowserName;
        }
    }
}