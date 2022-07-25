using FINNETT.data;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FINNETT.ibsui.cop
{
    public partial class overviewpage: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                mainPageContents.Visible = true;

                //if (!IsPostBack)
                //{
                //    mp1.Hide();
                //    Panel1.Style["display"] = "none";
                //    LoadRegulatorClassification();
                //    LoadLedgerAccountsList(0, string.Empty);
                //}
            }
            catch (Exception)
            {
                mainPageContents.Visible = false;
            }
        }

        protected void LoadLedgerAccountsList(int code, string reference)
        {
            /* try
             {
                 data.FinnettData db = new data.FinnettData
                 {
                     CommandTimeout = 999999999
                 }; System.Collections.Generic.List<data.GlobalGetLedgerAccountsResult> dataV = db.GlobalGetLedgerAccounts(1, code, reference, int.Parse(data.SuiteDreamLiner.GetCompanyID()), int.Parse(data.SuiteDreamLiner.GetBranch()), true).ToList();
                 GridView1.DataSource = null;
                 GridView1.DataBind();
                 GridView1.DataSource = dataV;
                 GridView1.DataBind();

                 accountcount.Text = "[" + GridView1.Rows.Count + "]";

                 if (GridView1.Rows.Count > 0)
                 {
                     exporttoexcel.Visible = true;

                     float total = 0;
                     foreach (GridViewRow row in GridView1.Rows)
                     {
                         string amount = row.Cells[9].Text;
                         float _amount = 0;
                         try { _amount = float.Parse(amount); } catch (Exception) { _amount = 0; }
                         total += _amount;
                     }
                     GridView1.FooterRow.Cells[0].Text = "TOTAL";
                     GridView1.FooterRow.Cells[9].Text = total.ToString("###,###.##");
                 }
                 else
                 {
                     exporttoexcel.Visible = false;
                 }
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
                e.Row.ToolTip = "Click to Preview Information.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                datakey.Text = GridView1.SelectedValue.ToString();
                if (closed.Checked == true)
                {
                    PreviewData(datakey.Text, false);
                }
                else
                {
                    PreviewData(datakey.Text, true);
                }
                ChangeSelectedColor(GridView1.SelectedRow.RowIndex);
            }
            catch (Exception)
            {
            }
        }

        protected void PreviewData(string pk, bool activex)
        {
            /*try
            {
                selectledger.Text = string.Empty;
                HideallOptions();
                status.Text = string.Empty;
                data.FinnettData db = new data.FinnettData
                {
                    CommandTimeout = 999999999
                }; string encstring = data.SuiteDreamLiner.EncryptData(pk);
                data.SessionDataStore.SaveSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_LEDGER_ID", encstring);
                //try { System.Web.HttpContext.Current.Response.Cookies["FINNETT_LEDGERID"].Value = encstring; } catch (Exception) { }
                //try { System.Web.HttpContext.Current.Response.Cookies["FINNETT0005"].Value = encstring; } catch (Exception) { }

                try
                {
                    System.Collections.Generic.List<data.GlobalGetLedgerAccountsResult> data0 = db.GlobalGetLedgerAccounts(1, 1, pk, int.Parse(data.SuiteDreamLiner.GetCompanyID()), int.Parse(data.SuiteDreamLiner.GetBranch()), activex).ToList();
                    foreach (data.GlobalGetLedgerAccountsResult item in data0)
                    {
                        selectledger.Text = item.AccountNo + " : " + item.LedgerName.ToString();
                        string mydata = item.LedgerId.ToString() + "," + item.AccountNo + "," + item.LedgerName + "," + item.MasterId + "," + "," + item.CategoryID + "," + item.GroupID;
                        data.SessionDataStore.SaveSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_LEDGER_DATA", mydata);

                        //System.Web.HttpContext.Current.Response.Cookies["FINNETT_LEDGERDATA"].Value = data.SuiteDreamLiner.EncryptData(mydata);

                        string broadclass = item.BroadClass;
                        if (broadclass == "BANK")
                        {
                            transfer_funds.Visible = true;
                        }
                        else
                        {
                            transfer_funds.Visible = false;
                        }

                        //if (broadclass == "FIXEDASSET")
                        //{
                        //    transferfunds.Visible = true;
                        //}
                        //else
                        //{
                        //    transferfunds.Visible = false;
                        //}
                    }
                }
                catch (Exception) { }
                if (selectledger.Text != string.Empty)
                {
                    moreoptions.Visible = true;
                }
                else
                {
                    moreoptions.Visible = false;
                }
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

        protected void viewdata_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                GridViewRow row = btn.NamingContainer as GridViewRow;
                string pk = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                datakey.Text = pk;
                ChangeSelectedColor(row.RowIndex);
                if (closed.Checked == true)
                {
                    PreviewData(datakey.Text, false);
                }
                else
                {
                    PreviewData(datakey.Text, true);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void HideallOptions()
        {
        }

        protected void newcustomer_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "Finnett  - CREATE NEW CUSTOMER -[";
                optionLaunch.Src = "~/ibsui/fin/faxcustomers";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void sendemail_Click(object sender, EventArgs e)
        {
            try
            {
                string[] maildata = data.DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT_CUSVENDATA"].Value).Split(',');
                System.Web.HttpContext.Current.Response.Cookies["mailTO"].Value = data.SuiteDreamLiner.EncryptData(maildata[3].ToString());
                System.Web.HttpContext.Current.Response.Cookies["mailCC"].Value = data.SuiteDreamLiner.EncryptData(maildata[5].ToString());
                accountIN.Text = "Finnett  - EMAIL CUSTOMER -[" + selectledger.Text + "]-";
                optionLaunch.Src = "~/ibsui/com/sendemailcusven";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void payment_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "Finnett  - RECEIVE PAYMENTS -[" + selectledger.Text + "]-";
                optionLaunch.Src = "~/ibsui/fin/faxreceivecustomerpayment";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            mp1.Hide();
        }

        protected void statement_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "CUSTOMER STATEMENT -[" + selectledger.Text + "]-";
                optionLaunch.Src = "~/ibsui/fin/faxstatement";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void incomes_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "Finnett  - RECORD INCOMES ";
                optionLaunch.Src = "~/ibsui/fin/faxrecordincomes";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void newledgeraccount_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "Finnett  - NEW LEDGER ACCOUNT ";
                optionLaunch.Src = "~/ibsui/fin/faxledgeraccounts";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void uploadledgeraccounts_Click(object sender, EventArgs e)
        {
        }

        protected void ledgerlist_Click(object sender, EventArgs e)
        {
        }

        protected void refereshledgeraccounts_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Response.Redirect(Request.RawUrl);
        }

        protected void expenses_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "Finnett  - RECORD EXPENSES ";
                optionLaunch.Src = "~/ibsui/fin/faxrecordexpenses";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void editledger_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "EDIT LEDGER ACCOUNT -[" + selectledger.Text + "]-";
                optionLaunch.Src = "~/ibsui/fin/faxledgeraccountedit";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void viewactiveledgeraccounts_Click(object sender, EventArgs e)
        {
            try
            {
                LoadLedgerAccountsList(0, string.Empty);
            }
            catch (Exception)
            {
            }
        }

        protected void viewinactiveledgeraccounts_Click(object sender, EventArgs e)
        {
           /* try
            {
                data.FinnettData db = new data.FinnettData
                {
                    CommandTimeout = 999999999
                }; System.Collections.Generic.List<data.GlobalGetLedgerAccountsResult> dataV = db.GlobalGetLedgerAccounts(1, 0, string.Empty, int.Parse(data.SuiteDreamLiner.GetCompanyID()), int.Parse(data.SuiteDreamLiner.GetBranch()), false).ToList();
                GridView1.DataSource = null;
                GridView1.DataBind();
                GridView1.DataSource = dataV;
                GridView1.DataBind();
            }
            catch (Exception)
            {
            }*/
        }

        protected void transferfunds_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "INTERBANK TRANSFERS :  FROM  : " + selectledger.Text;
                optionLaunch.Src = "~/ibsui/fin/faxinterbanktransfers";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void rundepreciation_Click(object sender, EventArgs e)
        {
        }

        protected void reconcilliation_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ibsui/fin/faxreconcilliationoverview");
            }
            catch (System.Exception)
            {
            }
        }

        protected void statement_Click1(object sender, EventArgs e)
        {
            try
            {
                data.SessionDataStore.SaveSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_LEDGER_ID", GridView1.SelectedValue.ToString());//System.Web.HttpContext.Current.Response.Cookies["FINNETT0005"].Value = data.SuiteDreamLiner.EncryptData(GridView1.SelectedValue.ToString());
                accountIN.Text = "RECONCILLIATION -[" + selectledger.Text + "]-";
                optionLaunch.Src = "~/ibsui/fin/faxledgerstatement";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void ledgerstatement_Click(object sender, EventArgs e)
        {
            try
            {
                data.SessionDataStore.SaveSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_LEDGER_ID", GridView1.SelectedValue.ToString());//System.Web.HttpContext.Current.Response.Cookies["FINNETT0005"].Value = data.SuiteDreamLiner.EncryptData(GridView1.SelectedValue.ToString());
                accountIN.Text = "LEDGER TRANSACTION STATEMENT -[" + selectledger.Text + "]-";
                optionLaunch.Src = "~/ibsui/fin/faxledgerstatement";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void journalentries_Click(object sender, EventArgs e)
        {
            try
            {
                accountIN.Text = "JOURNAL ENTRIES";
                optionLaunch.Src = "~/ibsui/fin/faxledgerentries";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void ledgertransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ibsui/fin/faxledgertransactions");
        }

        protected void findledgeraccount_TextChanged(object sender, EventArgs e)
        {
            LoadLedgerAccountsList(15, findledgeraccount.Text);
        }

        protected void reconcile_Click(object sender, EventArgs e)
        {
            try
            {
                data.SessionDataStore.SaveSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_LEDGER_ID", GridView1.SelectedValue.ToString());//System.Web.HttpContext.Current.Response.Cookies["FINNETT0005"].Value = data.SuiteDreamLiner.EncryptData(GridView1.SelectedValue.ToString());
                Response.Redirect("~/ibsui/fin/faxbankreconcilliation");
            }
            catch (System.Exception)
            {
            }
        }

        protected void closefperiod_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ibsui/fin/faxclosefperiod");
            }
            catch (System.Exception)
            {
            }
        }

        protected void interbank_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    data.SessionDataStore.DeleteSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_LEDGER_ID");
                    //data.SuiteDreamLiner.KillCookieX("FINNETT_LEDGERID");
                }
                catch (Exception) { }
                accountIN.Text = "INTERBANK TRANSFERS";
                optionLaunch.Src = "~/ibsui/fin/faxinterbanktransfers";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void groupedledgerstatement_Click(object sender, EventArgs e)
        {
            try
            {
                data.SessionDataStore.SaveSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_LEDGER_ID", GridView1.SelectedValue.ToString());//System.Web.HttpContext.Current.Response.Cookies["FINNETT0005"].Value = data.SuiteDreamLiner.EncryptData(GridView1.SelectedValue.ToString());
                accountIN.Text = "GROUPED LEDGER ACCOUNT STATEMENT -[" + selectledger.Text + "]-";
                optionLaunch.Src = "~/ibsui/fin/faxledgerstatementgrouped";
                mp1.Show();
            }
            catch (System.Exception)
            {
            }
        }

        protected void ledgerclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ledgerclass.SelectedIndex > 0)
            {
                LoadLedgerAccountsList(25, ledgerclass.SelectedValue);
            }
            else
            {
                LoadLedgerAccountsList(0, string.Empty);
            }
        }

        protected void regulatorclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (regulatorclass.SelectedIndex > 0)
            {
                LoadLedgerAccountsList(26, regulatorclass.SelectedValue);
            }
            else
            {
                LoadLedgerAccountsList(0, string.Empty);
            }
        }

        protected void LoadRegulatorClassification()
        {
            /*data.FinnettData db = new data.FinnettData
            {
                CommandTimeout = 999999999
            }; System.Collections.Generic.List<GlobalGetRegulatorAccountsResult> savedData = db.GlobalGetRegulatorAccounts(1, 3, SuiteDreamLiner.GetCompanyID(), data.SuiteDreamLiner.GetCompanyID(), data.SuiteDreamLiner.GetBranch(), true, SuiteDreamLiner.GetUserName(), SuiteDreamLiner.GetIPAddress()).ToList();
            regulatorclass.DataSource = null;
            regulatorclass.DataBind();
            regulatorclass.DataSource = savedData;
            regulatorclass.DataTextField = "AccountName";
            regulatorclass.DataValueField = "RegulatorAccID";
            regulatorclass.DataBind();*/
        }
    }
}