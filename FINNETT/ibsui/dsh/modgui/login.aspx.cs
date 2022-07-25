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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void businessOnClick(object sender, EventArgs e)
        {


            string URL = "https://cloud.unistrat.co.ke/";
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest("finnettapidemo/user/login", Method.POST);
            request.AddHeader("Accept", "application/json");
            var body = new
            {
                Password = txt_password.Text,
                UserName = txt_Username.Text,
                BusinessKey = Request.Cookies["FINNETT0000"].Value,
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
            string responseDescription = finalDeser["ResponseDescription"].ToString();

            if (responsecode == "000")
            {
                string userName = finalDeser["UserName"].ToString();
                string accessKey = finalDeser["AccessKey"].ToString(); 
                string branchID = finalDeser["BranchID"].ToString();
                string BusinessKey = finalDeser["AccessKey"].ToString();
                string AccessKey = finalDeser["AccessKey"].ToString();

                Response.Cookies["FINNETT0001"].Value = accessKey;
                Response.Cookies["UserName"].Value = userName;
                Response.Cookies["BranchID"].Value = branchID;

                Response.Cookies["BusinessKey"].Value = BusinessKey;
                Response.Cookies["AccessKey"].Value = AccessKey;


                if (Request.Cookies["FINNETT0001"].Value != null)
                {
                    Response.Redirect("dmsconnect.aspx", true);
                }
                else
                {
                    labale.Text = "Access Key is Missing";
                }
                

            }
            else
            {
                labale.Text = responseDescription;
                bsverification.Visible = true;


            }






        }


        protected void verification(object sender, EventArgs e)
        {
            Response.Redirect("businessverification.aspx", true);
        }





    }




    
}