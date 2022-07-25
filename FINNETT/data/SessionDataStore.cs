using System;
using System.Collections.Generic;

namespace FINNETT.data
{
    public class SessionDataStore
    {
        public static Dictionary<string, string> DataStore = new Dictionary<string, string>(StringComparer.Ordinal);

        public static void SaveSessionData(string key, string value)
        {
            try
            {
                //DeleteSessionData(key);
                //DataStore.Add(key, value);
                //SuiteDreamLiner.WriteDicData(key, value);
                //SuiteDreamLiner.WriteDicCount(DataStore.Count.ToString());

                //System.Web.HttpContext.Current.Response.Cookies[key].Value = data.SuiteDreamLiner.EncryptData(value);
                //DatabaseSessionData.SaveSessionData(key, value);
                //SessionToLiteDB.SaveSessionData(key, value);
                try { DeleteSessionData(key); } catch (Exception) { }
                try { SessionInMemory.SaveSessionData(key, value); } catch (Exception) { }
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteSessionData(string key)
        {
            try
            {
                //DataStore.Remove(key);
                //data.SuiteDreamLiner.KillCookieX(key);
                //DatabaseSessionData.DeleteSessionData();
                //SessionToLiteDB.DeleteSessionData(key);
                SessionInMemory.DeleteSessionData(key);
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
                //_session = DataStore[key].ToString();
                //_session = data.SuiteDreamLiner.DecryptData(System.Web.HttpContext.Current.Request.Cookies[key].Value);
                //_session = DatabaseSessionData.GetSessionData(key);
                //_session = SessionToLiteDB.GetSessionData(key);
                _session = SessionInMemory.GetSessionData(key);
            }
            catch (Exception)
            {
                _session = string.Empty;
            }
            return _session;
        }
    }
}