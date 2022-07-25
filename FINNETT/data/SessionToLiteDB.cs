namespace FINNETT.data
{
    //public class SessionData
    //{
    //    public string DataKey { get; set; }
    //    public string DataValue { gest; set; }
    //}

    //public class SessionToLiteDB
    //{
    //    public static string session = GetUserSession();
    //    public static LiteDatabase db = CreateDatabase(session);

    //    private static LiteDatabase CreateDatabase(string dbName)
    //    {
    //        string filePath = "Filename=" + System.Web.HttpContext.Current.Server.MapPath("~/data/" + dbName + ".db;connection=shared");
    //        return new LiteDatabase(filePath);
    //    }

    //    public static string GetUserSession()
    //    {
    //        string _udata = string.Empty;
    //        try
    //        {
    //            try
    //            {
    //                _udata = data.StringUtil.DecryptData(System.Web.HttpContext.Current.Request.Cookies["SES360"].Value);
    //            }
    //            catch (Exception)
    //            {
    //                _udata = string.Empty;
    //            }
    //        }
    //        catch (Exception)
    //        {
    //        }
    //        return _udata;
    //    }

    //    public static void SaveSessionData(string key, string value)
    //    {
    //        try
    //        {
    //            using (db)
    //            {
    //                ILiteCollection<SessionData> collection = db.GetCollection<SessionData>("SessD");
    //                SessionData _sess = collection.Find(x => x.DataKey == key).FirstOrDefault();
    //                if (_sess != null)
    //                {
    //                    DeleteSessionData(key);
    //                    //UpdateSessionData(key, value);
    //                }
    //                {
    //                    DataKey = key,
    //                    DataValue = value,
    //                };
    //                collection.Insert(_session);

    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.ToString());
    //        }
    //    }

    //    public static void UpdateSessionData(string key, string value)
    //    {
    //        using (db)
    //        {
    //            ILiteCollection<SessionData> collection = db.GetCollection<SessionData>("SessD");
    //            collection.EnsureIndex(x => x.DataKey);
    //            SessionData _sess = collection.Find(x => x.DataKey == key).FirstOrDefault();
    //            _sess.DataValue = value;
    //            collection.Update(_sess);
    //        }
    //    }

    //    public static string GetSessionData(string key)
    //    {
    //        string _session = string.Empty;
    //        using (db)
    //        {
    //            ILiteCollection<SessionData> collection = db.GetCollection<SessionData>("SessD");
    //            collection.EnsureIndex(x => x.DataKey);
    //            SessionData _sess = collection.Find(x => x.DataKey == key).FirstOrDefault();
    //            if (_sess != null)
    //            {
    //                _session = _sess.DataValue.ToString();
    //            }
    //        }

    //        return _session;
    //    }

    //    public static void DeleteSessionData(string key)
    //    {
    //        string _session = string.Empty;
    //        using (db)
    //        {
    //            ILiteCollection<SessionData> collection = db.GetCollection<SessionData>("SessD");
    //            collection.EnsureIndex(x => x.DataKey);
    //            SessionData _sess = collection.Find(x => x.DataKey == key).FirstOrDefault();
    //            if (_sess != null)
    //            {
    //                BsonValue p = new BsonValue(_sess.DataKey);
    //                collection.Delete(p);
    //            }
    //        }
    //    }
    //}
}