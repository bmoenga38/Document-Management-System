using System;
using System.IO;

namespace FINNETT.data
{
    public class FileManager
    {
        public static string GetFolderLocations(string name, int type)
        {
            string folderlocation = string.Empty;

            if (name == "usr_pst")
            {
                if (type == 0)
                {
                    folderlocation = System.Web.HttpContext.Current.Server.MapPath("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr/pst").ToString();
                }
                else
                {
                    folderlocation = "~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr/pst".ToString();
                }
            }

            if (name == "usr_sig")
            {
                if (type == 0)
                {
                    folderlocation = System.Web.HttpContext.Current.Server.MapPath("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr/sig").ToString();
                }
                else
                {
                    folderlocation = "~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr/sig".ToString();
                }
            }

            return folderlocation;
        }

        public static void CheckDMSFolders(string type, int code)
        {
            if (type == "basic")
            {
                try
                {
                    if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms"))))
                    {
                        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms")));
                    }
                }
                catch (Exception) { }

                try
                {
                    if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls"))))
                    {
                        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls")));
                    }
                }
                catch (Exception) { }

                try
                {
                    if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID()))))
                    {
                        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID())));
                    }
                }
                catch (Exception) { }
            }

            try
            {
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr"))))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr")));
                }
            }
            catch (Exception) { }

            try
            {
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr"))))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr")));
                }
            }
            catch (Exception) { }

            if (type == "usr")
            {
                try
                {
                    if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr/pst"))))
                    {
                        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr/pst")));
                    }
                }
                catch (Exception) { }

                try
                {
                    if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr/sig"))))
                    {
                        Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(("~/ibsui/dms/fls/" + SuiteDreamLiner.GetCompanyID() + "/usr/sig")));
                    }
                }
                catch (Exception) { }
            }
        }
    }
}