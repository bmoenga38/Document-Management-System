using FINNETT.data;
using RestSharp;
using System;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace FINNETT.ibsui.dsh.modgui
{
    public partial class usermenu : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Page.EnableEventValidation = false;
        }

        protected void findclient_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchclient.Text))
            {
                searchclient.Focus();
            }
            else
            {
                try
                {
                    searchclient.ForeColor = System.Drawing.Color.Black;
                    RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
                    RestRequest request = new RestRequest("client/search", Method.POST);
                    request.AddHeader("Accept", "application/json");
                    var body = new
                    {
                        BusinessKey = data.SuiteDreamLiner.GetBusinessKeyNoEncryption(),
                        AccessKey = data.SuiteDreamLiner.GetAccessKeyNoEncryptionPOST(),
                        TerminalType = "WEB",
                        TerminalID = data.SuiteDreamLiner.GetIPAddress(),
                        TimeStamp = data.SuiteDreamLiner.GetTimeStamp(),
                        SearchParameter = searchclient.Text,
                        SearchCode = "ANY"
                    };

                    request.AddJsonBody(body); client.Timeout = 999999999;
                    string response = client.Execute(request).Content;

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic receivedData = serializer.Deserialize<dynamic>(response);
                    dynamic finalDeser = serializer.Deserialize<dynamic>(receivedData);
                    string _response = finalDeser["ResponseCode"].ToString();
                    if (_response == "000")
                    {
                        SuiteDreamLiner.SaveReceivedClientData(response);
                        System.Web.HttpContext.Current.Response.Redirect("~/ibsui/dsh/modgui/backoffice", false);
                        searchclient.Text = data.SuiteDreamLiner.GetClientNumber();
                    }
                    else
                    {
                        SearchMultiple();
                    }
                }
                catch (Exception)
                {
                    SearchMultiple();
                }
            }
        }

        protected void SearchMultiple()
        {
            try
            {
                findclienttitle.Text = "Search Client Database for ->>    " + searchclient.Text.ToString() + "    <<--";

                GetClients(15, searchclient.Text);
                try { searchPop.Show(); } catch (Exception) { }
            }
            catch (Exception) { }
        }

        protected void GetClients(int code, string reference)
        {
            /*try
            {
                data.FinnettData db = new data.FinnettData
                {
                    CommandTimeout = 999999999
                }; System.Collections.Generic.List<ReportClientDataResult> cdata = db.ReportClientData(1, code, reference, data.SuiteDreamLiner.GetCompanyID(), data.SuiteDreamLiner.GetBranch(), DateTime.Now, DateTime.Now, DateTime.Now, true).ToList();
                GridView1.DataSource = null;
                GridView1.DataBind();
                GridView1.DataSource = cdata;
                GridView1.DataBind();

                foundresults.Text = GridView1.Rows.Count.ToString() + " Results Found.";
            }
            catch (Exception)
            {
            }*/
        }

        protected void ChangeSelectedColor(int rowindex)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                GridView1.Rows[row.RowIndex].BackColor = System.Drawing.Color.Transparent; GridView1.Rows[row.RowIndex].ForeColor = System.Drawing.Color.FromArgb(64, 78, 103);
            }
            GridView1.Rows[rowindex].BackColor = System.Drawing.Color.FromArgb(33, 150, 243); GridView1.Rows[rowindex].ForeColor = System.Drawing.Color.White;
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
           /* try
            {
                ChangeSelectedColor(GridView1.SelectedRow.RowIndex);
                data.FinnettData db = new data.FinnettData
                {
                    CommandTimeout = 999999999
                }; System.Collections.Generic.List<ReportClientDataResult> cdata = db.ReportClientData(1, 1, GridView1.SelectedValue.ToString(), data.SuiteDreamLiner.GetCompanyID(), SuiteDreamLiner.GetBranch(), DateTime.Now, DateTime.Now, DateTime.Now, true).ToList();
                foreach (ReportClientDataResult item in cdata)
                {
                    searchclient.Text = item.ClientNumber.ToString();
                }

                searchPop.Hide();
                findclient_TextChanged(sender, e);
            }
            catch (Exception)
            {
            }*/
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to View Client";
            }
        }

        //GET NOTIFICATIONS
        protected void GetNotifications()
        {
            try
            {
                RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
                RestRequest request = new RestRequest("user/notifications", Method.POST);
                request.AddHeader("Accept", "application/json");
                var body = new
                {
                    AccessKey = data.SuiteDreamLiner.GetAccessKeyNoEncryptionPOST(),
                    BusinessKey = data.SuiteDreamLiner.GetBusinessKeyNoEncryption(),
                    TerminalType = "WEB",
                    TerminalID = data.SuiteDreamLiner.GetIPAddress(),
                    TimeStamp = data.SuiteDreamLiner.GetTimeStamp()
                };
                request.AddJsonBody(body); client.Timeout = 999999999;
                string response = client.Execute(request).Content;

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic receivedData = serializer.Deserialize<dynamic>(response);
                dynamic finalDeser = serializer.Deserialize<dynamic>(receivedData);
                string _responseCode = finalDeser["ResponseCode"].ToString();
                try
                {
                    if (_responseCode == "000")
                    {
                        queuedtasks.Text = finalDeser["QueuedTasks"].ToString();
                        initiatedtasks.Text = finalDeser["InitiatedTask"].ToString();
                    }
                    if (int.Parse(queuedtasks.Text) > 0 || int.Parse(initiatedtasks.Text) > 0)
                    {
                        normalbell.Visible = false;
                        shakingbell.Visible = true;
                    }
                    else
                    {
                        normalbell.Visible = true;
                        shakingbell.Visible = false;
                    }
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    GetLicensedModules();
            //    username.Text = data.SuiteDreamLiner.GetFullUserName(); mybusiness.Text = data.SuiteDreamLiner.GetBusinessName();
            //    mybusiness.Text = SuiteDreamLiner.GetBusinessName();
            //    GetNotifications();
            //    if (!IsPostBack)
            //    {
            //        try
            //        {
            //            if (searchclient.Text == string.Empty)
            //            {
            //                searchclient.Text = SuiteDreamLiner.GetClientNumber();
            //            }
            //        }
            //        catch (Exception)
            //        {
            //            //searchclient.Text = string.Empty;
            //        }
            //    }

            //    try
            //    {
            //        if (searchclient.Text == string.Empty)
            //        {
            //            searchclient.Text = SuiteDreamLiner.GetClientNumber();
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        //searchclient.Text = string.Empty;
            //    }
            //}
            //catch (System.Exception)
            //{
            //}
        }

        protected void GetLicensedModules()
        {
            try
            {
                try
                {
                    string resourcename = "home_processesVIEW"; string rights = data.RightsAndAccess.GetRights(resourcename);
                    if (rights != string.Empty) { foreach (string item in rights.Split(':')) { try { System.Web.UI.Control modulename = FindControl(item); if (modulename != null) { modulename.Visible = true; } } catch (Exception) { } } }
                    else
                    { Response.Redirect("~/connect/am_out"); }
                }
                catch (Exception) { }

                if (SuiteDreamLiner.GetIsGrandMaster() == false) { manage_business.Visible = false; }
            }
            catch (Exception)
            {
            }
        }

        protected void findbyany_TextChanged(object sender, EventArgs e)
        {
        }

        protected void closeSearchPop_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
            searchPop.Hide();
        }
    }
}