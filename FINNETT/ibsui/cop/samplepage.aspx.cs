using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FINNETT.ibsui.cop
{
    public partial class samplepage : System.Web.UI.Page
    {
        protected void postData()
        {
        }

        protected void viewdata_Click(object sender, EventArgs e)
        {
            /*try
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
            }*/
        }

        protected void BindUsersData()
        {
            /*data.FinnettData db = new data.FinnettData
            {
                CommandTimeout = 999999999
            }; System.Collections.Generic.List<data.GlobalGetUserInformationResult> data2 = db.GlobalGetUserInformation(1, 0, string.Empty, int.Parse(data.SuiteDreamLiner.GetCompanyID()), true).ToList();
            locktouser.DataSource = data2;
            locktouser.DataTextField = "FullName";
            locktouser.DataValueField = "UserName";
            locktouser.DataBind();*/
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadTerminalTypeData();
                    BindUsersData();
                    TerminalsData();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void LoadTerminalTypeData()
        {
            /*data.FinnettData db = new data.FinnettData();
            System.Collections.Generic.List<data.GlobalGetAccessTerminalTypesResult> savedData = db.GlobalGetAccessTerminalTypes(1, 0, data.SuiteDreamLiner.GetCompanyID(), data.SuiteDreamLiner.GetBranch(), string.Empty, data.SuiteDreamLiner.GetUserName()).ToList();
            terminaltype.Items.Clear();
            terminaltype.DataBind();
            terminaltype.DataSource = savedData;
            terminaltype.DataTextField = "TerminalType";
            terminaltype.DataValueField = "TerminalTypeId";
            terminaltype.DataBind();*/
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

        protected void ClearPage()
        {
            terminalname.Text = terminalserial.Text = terminalip.Text = string.Empty;
        }

        protected void PreviewData(string pk)
        {
           /* data.FinnettData db = new data.FinnettData
            {
                CommandTimeout = 999999999
            };
            int x = int.Parse(data.SuiteDreamLiner.GetCompanyID());

            System.Collections.Generic.List<data.GlobalAccessTerminalsResult> savedData = db.GlobalAccessTerminals(1, 1, pk, data.SuiteDreamLiner.GetBranch(), pk, data.SuiteDreamLiner.GetUserName()).ToList();
            foreach (data.GlobalAccessTerminalsResult item in savedData)
            {
                terminalip.Text = item.TerminalIP;
                terminalname.Text = item.TerminalName;
                terminalserial.Text = item.SerialNumber;
                bool allowed = item.Allowed.Value;
                bool suspended = item.Suspended.Value;
                valid.Checked = item.Valid.Value;
                terminaltype.SelectedValue = item.TerminalType.ToString();
                locktouser.SelectedValue = item.LockToUser.ToString();

                if (allowed == true)
                {
                    allowdeny.SelectedIndex = 0;
                }
                else
                {
                    allowdeny.SelectedIndex = 1;
                }
            }
            update.Visible = true;
            add.Visible = false;*/
        }

        protected void ChangeSelectedColor(int rowindex)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                GridView1.Rows[row.RowIndex].BackColor = System.Drawing.Color.Transparent; GridView1.Rows[row.RowIndex].ForeColor = System.Drawing.Color.FromArgb(64, 78, 103);
            }
            GridView1.Rows[rowindex].BackColor = System.Drawing.Color.FromArgb(33, 150, 243); GridView1.Rows[rowindex].ForeColor = System.Drawing.Color.White;
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to Edit or Preview Data.";
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (checkerX.Text != "add")
                {
                    checkerX.Text = "add";
                    string pgTitle = string.Empty.ToString();
                    updateData.Text = "Add " + string.Empty + " Information?";
                    Page.ClientScript.RegisterStartupScript(GetType(), "criptMe", "popME0()", true);
                }
                else
                {
                    data.FinnettData db = new data.FinnettData
                    {
                        CommandTimeout = 999999999
                    }; string response = string.Empty;
                    bool allowed = false;
                    bool suspended = false;
                    if (allowdeny.SelectedIndex == 0)
                    {
                        allowed = true;
                        suspended = false;
                    }
                    else
                    {
                        allowed = false;
                        suspended = true;
                    }
                    db.AccessTerminals(string.Empty, data.SuiteDreamLiner.GetCompanyID(), data.SuiteDreamLiner.GetBranch(), terminalname.Text, terminalserial.Text, terminalip.Text, terminaltype.SelectedValue, locktouser.SelectedValue,
                        allowed, suspended, DateTime.Now, data.SuiteDreamLiner.GetUserName(), System.IO.Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Request.Url.AbsolutePath, data.SuiteDreamLiner.GetIPAddress(),
                        valid.Checked, false, data.SuiteDreamLiner.GetTransactionCode(), ref response);
                    TerminalsData();

                    if (response.StartsWith("000"))
                    {
                        showAlert(true, data.SuiteDreamLiner.SystemResponse(response));
                    }
                    else
                    {
                        showAlert(false, data.SuiteDreamLiner.SystemResponse(response));
                    }
                }
            }
            catch (Exception ex)
            {
                checkerX.Text = string.Empty;
                showAlert(true, ex.Message);
            }*/
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkerX.Text == "update")
                {
                    update_Click(sender, e);
                }
                if (checkerX.Text == "add")
                {
                    add_Click(sender, e);
                }
                else
                { }
            }
            catch (Exception)
            {
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
            Page.ClientScript.RegisterStartupScript(GetType(), "criptMe2", "popME()", true);
        }

        protected void btnClose0_Click(object sender, EventArgs e)
        {
            checkerX.Text = string.Empty;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "HideDialog0();", true);
        }

        protected void closeStatus_Click(object sender, EventArgs e)
        {
            checkerX.Text = string.Empty;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ScriptHideDLOG", "HideDialog();", true);
        }

        protected void update_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (checkerX.Text != "update")
                {
                    checkerX.Text = "update";
                    string pgTitle = string.Empty.ToString();
                    updateData.Text = "Update " + string.Empty + " Information?";
                    Page.ClientScript.RegisterStartupScript(GetType(), "criptMe", "popME0()", true);
                }
                else
                {
                    checkerX.Text = string.Empty;

                    data.FinnettData db = new data.FinnettData
                    {
                        CommandTimeout = 999999999
                    }; string response = string.Empty;
                    bool allowed = false;
                    bool suspended = false;
                    if (allowdeny.SelectedIndex == 0)
                    {
                        allowed = true;
                        suspended = false;
                    }
                    else
                    {
                        allowed = false;
                        suspended = true;
                    }
                    db.AccessTerminals(datakey.Text, data.SuiteDreamLiner.GetCompanyID(), data.SuiteDreamLiner.GetBranch(), terminalname.Text, terminalserial.Text, terminalip.Text, terminaltype.SelectedValue, locktouser.SelectedValue,
                        allowed, suspended, DateTime.Now, data.SuiteDreamLiner.GetUserName(), System.IO.Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Request.Url.AbsolutePath, data.SuiteDreamLiner.GetIPAddress(),
                        valid.Checked, true, data.SuiteDreamLiner.GetTransactionCode(), ref response);
                    TerminalsData();

                    if (response == "000")
                    {
                        showAlert(true, data.SuiteDreamLiner.SystemResponse(response));
                    }
                    else
                    {
                        showAlert(false, data.SuiteDreamLiner.SystemResponse(response));
                    }
                }
            }
            catch (Exception ex)
            {
                checkerX.Text = string.Empty;
                showAlert(false, ex.Message);
            }*/
        }

        protected void TerminalsData()
        {
           /* data.FinnettData db = new data.FinnettData();
            System.Collections.Generic.List<data.GlobalAccessTerminalsResult> savedData = db.GlobalAccessTerminals(1, 4, data.SuiteDreamLiner.GetCompanyID(), data.SuiteDreamLiner.GetBranch(), terminaltype.SelectedValue, data.SuiteDreamLiner.GetUserName()).ToList();
            GridView1.DataSource = savedData;
            GridView1.DataBind();*/
        }

        protected void terminaltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            TerminalsData();
        }
    }
}