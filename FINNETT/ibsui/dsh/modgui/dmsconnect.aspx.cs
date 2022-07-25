using System;

namespace FINNETT.ibsui.dsh.modgui
{
    public partial class dmsconnect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!IsPostBack) { data.SuiteDreamLiner.KillClientSession(); }
                //if (data.SuiteDreamLiner.VerifyUserSession() == false)
                //{
                //    Response.Redirect("~/connect/index");
                //}
                //else
                //{
                //    try
                //    {
                //        string resourcename = "penger_pay_processesVIEW"; string rights = data.RightsAndAccess.GetRights(resourcename);
                //        if (rights != string.Empty) { foreach (string item in rights.Split(':')) { try { System.Web.UI.Control modulename = FindControl(item); if (modulename != null) { modulename.Visible = true; } } catch (Exception) { } } } else { System.Web.HttpContext.Current.Response.Cookies["RESOURCE"].Value = resourcename.Replace("VIEW", string.Empty); Response.Redirect("~/ibsui/dsh/modgui/access"); }
                //    }
                //    catch (Exception) { }
                //}
            }
            catch (Exception) { }
        }

        protected void pencustomreports_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Response.Cookies["FINNETTRPTSRC"].Value = data.SuiteDreamLiner.EncryptData("PENGER_PAY_PROCESSES");
                UNILoaderV.Src = "~/ibsui/utl/adhocreportview";
            }
            catch (Exception) { }
        }
    }
}