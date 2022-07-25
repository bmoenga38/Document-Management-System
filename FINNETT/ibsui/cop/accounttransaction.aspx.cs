﻿

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using FINNETT.data;
using Newtonsoft.Json;
using RestSharp;

namespace FINNETT.ibsui.cop
{
    public partial class accounttransaction : System.Web.UI.Page
    {
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkerX.Text == "update")
                {
                    update_Click(sender, e);
                }
                else if (checkerX.Text == "add")
                {
                    add_Click(sender, e);
                }
                else if (checkerX.Text == "refresh")
                {
                    refreshdata_Click(sender, e);
                }
                else if (checkerX.Text == "clear")
                {
                    clearformdata_Click(sender, e);
                }
                else
                { }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnClose0_Click(object sender, EventArgs e)
        {
            checkerX.Text = string.Empty;
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "Script", "HideDialog0();", true);
        }

        protected void closeStatus_Click(object sender, EventArgs e)
        {
            checkerX.Text = string.Empty;
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "ScriptHideDLOG", "HideDialog();", true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                   
                   
                    LoadAccounts();
                    accountnumber.Text = AccountName.SelectedValue;
                    LoadData(2, accountnumber.Text);
                   

                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to Edit or Preview Data.";
            }
        }

        protected void clearformdata_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkerX.Text != "clear")
                {
                    checkerX.Text = "clear";
                    updateData.Text = "Reload "+string.Empty+" Page?";                    
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "Script", "popME0();", true);
                }
                else
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                showAlert(false, ex.Message);
            }
        }

        protected void refreshdata_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData(0,"");
            }
            catch (Exception ex)
            {
                showAlert(false, ex.Message);
            }
        }

        protected void showAlert(bool success, string message)
        {
            if (success == true)
            {
                popMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                popMessage.ForeColor = System.Drawing.Color.Red;
            }
            popMessage.Text = message;
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "Script", "popME();", true);
        }

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkerX.Text != "update")
                {
                    checkerX.Text = "update";
                    updateData.Text = "Update "+string.Empty+" Information?";
                    
                    
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "Script", "popME0();", true);
                }
                else
                {
                    

                }
            }
            catch (Exception ex)
            {
                showAlert(false, ex.Message);
            }
        }

        protected void LoadData(int Code, string SearchParameter)
        {

            RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
            RestRequest request = new RestRequest("get/cop/transactions", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", Secure360.GetAuthorization());
            request.AddHeader("Signature", Secure360.GetSignature());
            var bodyParameters = new
            {

                Code = Code,
                SearchParameter = SearchParameter
            };
            string finalData = JsonConvert.SerializeObject(bodyParameters).ToString();
            var body = new
            {
                Data = finalData
            };
            request.AddJsonBody(body);
            var responseOUT = client.Execute(request).Content;
            var serializer = new JavaScriptSerializer();
            var receivedData = serializer.Deserialize<dynamic>(responseOUT);
            var receivedData2 = serializer.Deserialize<dynamic>(receivedData);
            DataTable dt = new DataTable();
            try
            {
                var response = receivedData2[0];
                var _response = response["Response"];
                var response2 = serializer.Deserialize<dynamic>(_response);
                var trans = response2["Transactions"];
                var AccountNumber = response2["AccountNumber"];
                var AccountName = response2["AccountName"];
                _AccountNumber.Text = AccountNumber;
                _AccountName.Text = AccountName;

                var jsonTransaction = JsonConvert.SerializeObject(trans);
                dt = (DataTable)JsonConvert.DeserializeObject(jsonTransaction, (typeof(DataTable)));
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }

        }



        protected void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkerX.Text != "add")
                {
                    checkerX.Text = "add";
                    updateData.Text = "Add "+string.Empty+" Information?";
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "Script", "popME0();", true);
                }
                else
                {
                    string imgurl = string.Empty;
                    string responseDescription = string.Empty;
                    string responsecode = string.Empty;
                    string hasError = string.Empty;
                    RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
                    RestRequest request = new RestRequest("cop/account/transactions", Method.POST);
                    request.AddHeader("Accept", "application/json");
                    request.AddHeader("Authorization", Secure360.GetAuthorization());
                    request.AddHeader("Signature", Secure360.GetSignature());
                    var bodyParameters = new
                    {
                        AccountName = AccountName.SelectedItem,
                        AccountNumber = accountnumber.Text,
                        NoOfTransactions = transactionNo.Text
                    };
                    string finalData = JsonConvert.SerializeObject(bodyParameters).ToString();
                    var body = new
                    {
                        Data = finalData
                    };
                    request.AddJsonBody(body);
                    var responseout = client.Execute(request).Content;
                    var serializer = new JavaScriptSerializer();
                    var receivedData = serializer.Deserialize<dynamic>(responseout);
                    var finalDeser = serializer.Deserialize<dynamic>(receivedData);
                    try { responsecode = finalDeser["ResponseCode"].ToString(); } catch (Exception ex) { }
                    try { responseDescription = finalDeser["ResponseDescription"].ToString(); } catch(Exception ex) { }
                    try { responseDescription = finalDeser["errorMessage"].ToString(); } catch (Exception ex) { }
                    try { hasError = finalDeser["has_error"].ToString(); } catch (Exception) { hasError = ""; }
                    if (responsecode == "000")
                    {
                        LoadData(2, accountnumber.Text);
                        showAlert(true, responseDescription);
                    }
                   
                    else
                    {
                        showAlert(false, responseDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                showAlert(false, ex.Message);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                datakey.Text = GridView1.SelectedValue.ToString();
                PreviewData(datakey.Text);
                ChangeSelectedColor(GridView1.SelectedRow.RowIndex);
            }
            catch (Exception ex)
            {
                showAlert(false, ex.Message);
            }
        }

        protected void PreviewData(string pk)
        {
           
        }

        protected void ClearData()
        {
           // update.Visible =  false;
           // add.Visible =  true;
        }

        protected void ChangeSelectedColor(int rowindex)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                GridView1.Rows[row.RowIndex].BackColor = System.Drawing.Color.Transparent; GridView1.Rows[row.RowIndex].ForeColor = System.Drawing.Color.FromArgb(64, 78, 103);
            }
            GridView1.Rows[rowindex].BackColor = System.Drawing.Color.FromArgb(33, 150, 243); GridView1.Rows[rowindex].ForeColor = System.Drawing.Color.White;
        }

        protected void viewdata_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                GridViewRow row = btn.NamingContainer as GridViewRow;
                string pk = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                datakey.Text = pk;
                ChangeSelectedColor(row.RowIndex);
                GridView1.SelectRow(row.RowIndex);
                PreviewData(datakey.Text);
            }
            catch (Exception ex)
            {
                showAlert(false, ex.Message);
            }
        }

        protected void SourceAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            accountnumber.Text = AccountName.SelectedValue;
            LoadData(2, accountnumber.Text);
        }

        protected void LoadAccounts()
        {

            RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
            RestRequest request = new RestRequest("get/all/account", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", Secure360.GetAuthorization());
            request.AddHeader("Signature", Secure360.GetSignature());
            var bodyParameters = new
            {

                Code = 0,
                SearchParameter = 1
            };
            string finalData = JsonConvert.SerializeObject(bodyParameters).ToString();
            var body = new
            {
                Data = finalData
            };
            request.AddJsonBody(body);
            var responseOUT = client.Execute(request).Content;
            var serializer = new JavaScriptSerializer();
            var receivedData = serializer.Deserialize<dynamic>(responseOUT);
            //var receivedData2 = serializer.Deserialize<dynamic>(receivedData);
            DataTable dt = new DataTable();
            try
            {
                dt = (DataTable)JsonConvert.DeserializeObject(receivedData, (typeof(DataTable)));
            }
            catch (Exception ex)
            {
                dt = null;
            }

            AccountName.DataSource = dt;
            AccountName.DataValueField = "AccountNumber";
            AccountName.DataTextField = "AccountName";
            AccountName.DataBind();

        }

       
    }
}