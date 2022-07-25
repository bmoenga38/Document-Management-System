using System;
using System.Web.UI;

namespace FINNETT.ibsui.dsh.modgui
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //GetLicensedModules();
                //if (!IsPostBack)
                //{
                //}
            }
            catch (System.Exception)
            {
            }
        }

        protected void GetLicensedModules()
        {
            try
            {
                string businessInformation = data.SuiteDreamLiner.UserAccessModules();
                if (businessInformation != string.Empty && businessInformation != null && businessInformation != "")
                {
                    string[] module = businessInformation.Split(':');
                    foreach (string item in module)
                    {
                        try
                        {
                            Control modulename = FindControl(item);
                            if (modulename != null)
                            {
                                modulename.Visible = true;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}