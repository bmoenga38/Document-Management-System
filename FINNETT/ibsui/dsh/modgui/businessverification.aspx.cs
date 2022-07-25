using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using System;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Data;
using Newtonsoft.Json;
using FINNETT.data;
using HttpCookie = System.Web.HttpCookie;


namespace FINNETT.ibsui.dsh.modgui
{
    public partial class businessverification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void businessOnClick(object sender, EventArgs e)
        {

            string URL = "https://cloud.unistrat.co.ke/";
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest("finnettapidemo/business/verification", Method.POST);
            request.AddHeader("Accept", "application/json");
            var body = new
            {
                BusinessKey= businessname.Text,
                TerminalType = "WEB",
                TerminalID = SuiteDreamLiner.GetIPAddress(),
                TimeStamp = SuiteDreamLiner.GetTimeStamp()

            };

            request.AddJsonBody(body);

            var responseOUT = client.Execute(request).Content;
            var serializer = new JavaScriptSerializer();
            var receivedData = serializer.Deserialize<dynamic>(responseOUT);
           
            var finalDeser = serializer.Deserialize<dynamic>(receivedData);
            string responsecode = finalDeser["ResponseCode"].ToString();

            if (responsecode == "000")
            {
                string BusinessKey = finalDeser["BusinessKey"].ToString();
                string CompanyID = finalDeser["CompanyID"].ToString();

                Response.Cookies["FINNETT0000"].Value = BusinessKey;
                Response.Cookies["CompanyID"].Value = CompanyID;

                if (Request.Cookies["FINNETT0000"].Value != null)
                {
                    Response.Redirect("login.aspx", true);
                }
                else
                {
                    labale.Text = "Missing Business Key";
                }

            }
            else
            {
                labale.Text = "wrong business code";
            }
        }
    }




    
}