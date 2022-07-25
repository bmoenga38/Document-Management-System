using System;
using System.Linq;

namespace FINNETT.data
{
    public class DatabaseSessionData
    {
        public static string GetUserSession()
        {
            string _udata = string.Empty;
            try
            {
                try
                {
                    _udata = data.StringUtil.DecryptData(System.Web.HttpContext.Current.Request.Cookies["SES360"].Value);
                }
                catch (Exception)
                {
                    _udata = string.Empty;
                }
            }
            catch (Exception)
            {
            }
            return _udata;
        }

        public static void SaveSessionData(string key, string value)
        {
            try
            {
                //string _ResponseCode = string.Empty;
                //FinnettData db = new FinnettData();
                //System.Collections.Generic.List<SaveAccessSessionResult> _Response = db.SaveAccessSession(GetUserSession(), key, value).ToList();
                //foreach (SaveAccessSessionResult item in _Response)
                //{
                //    _ResponseCode = item.ResponseCode;
                //}
                //if (_ResponseCode == "005")
                //{
                //    System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
                //}
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteSessionData()
        {
            try
            {
                //FinnettData db = new FinnettData();
                //db.DeleteAccessSession(GetUserSession());
            }
            catch (Exception)
            {
            }
        }

        public static string GetSessionData(string key)
        {
            string _session = string.Empty;
            try
            {
                //string _ResponseCode = string.Empty;
                //FinnettData db = new FinnettData();
                //System.Collections.Generic.List<GetAccessSessionResult> _Response = db.GetAccessSession(GetUserSession(), key).ToList();
                //foreach (GetAccessSessionResult item in _Response)
                //{
                //    _ResponseCode = item.ResponseCode;
                //    _session = item.SessionData;
                //}
                //if (_ResponseCode == "005")
                //{
                //    System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
                //}
            }
            catch (Exception)
            {
            }
            return _session;
        }
    }
}