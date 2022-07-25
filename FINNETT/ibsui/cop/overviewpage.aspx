<%@ Page Language="C#" ViewStateEncryptionMode="Auto" AutoEventWireup="true" Title="Account Overview" CodeBehind="overviewpage.aspx.cs" Inherits="FINNETT.ibsui.cop.overviewpage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>FA GENERAL LEDGER</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/css/vendors.min.css" />
    <script src="../dsh/modgui/assets/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/css/app.min.css" />

    <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/fonts/line-awesome/css/line-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/fonts/montserrat/styles.css" />

    <script type="text/javascript"> if (top == self) { window.location.replace("../dsh/modgui/coopconnect"); } else { } </script>
    <!-- POP CODE-->
    <script src="../cssjs/jquery-1.4.3.min.js"></script>
    <link href="../cssjs/popupcss.css" rel="stylesheet" />
    <script type="text/javascript">  $(document).ready(function () { $("#btnClose0").click(function (e) { HideDialog0(); }); }); function ShowDialog(modal) { $("#overlay").show(); $("#dialog").fadeIn(300); if (modal) { $("#overlay").unbind("click"); } else { $("#overlay").click(function (e) { HideDialog(); }); } } function popME() { ShowDialog(true); } function popME0() { ShowDialog0(true); } function HideDialog() { $("#overlay").hide(); $("#dialog").fadeOut(300); } function HideDialog0() { $("#overlay0").hide(); $("#dialog0").fadeOut(300); } function ShowDialog0(modal) { $("#overlay0").show(); $("#dialog0").fadeIn(300); if (modal) { $("#overlay0").unbind("click"); } else { $("#overlay0").click(function (e) { HideDialog0(); }); } } function scrollPageX() { window.scrollTo(100, 100); } function ScrollSmooth() { $("a[href='#top']").click(function () { $("html, body").animate({ scrollTop: 0 }, "slow"); return false; }); } </script>

    <style>
        /* width */
        ::-webkit-scrollbar {
            width: 0px;
        }

        /* Track */
        ::-webkit-scrollbar-track {
            background: #f1f1f1;
        }

        /* Handle */
        ::-webkit-scrollbar-thumb {
            background: #888;
        }

            /* Handle on hover */
            ::-webkit-scrollbar-thumb:hover {
                background: #555;
            }
    </style>
    <script type="text/javascript">
        function refreshIframe() {
            var ifr = document.getElementsByName('reportLauch')[0];
            ifr.src = ifr.src;
        }
    </script>
    <%--<script type="text/javascript">document.addEventListener('contextmenu', event => event.preventDefault());</script>--%>

    <script type="text/javascript">
        function excelPrint() {
            var header = "<html xmlns:o='urn:schemas-microsoft-com:office:office' " +
                "xmlns:w='urn:schemas-microsoft-com:office:excel' " +
                "xmlns='http://www.w3.org/TR/REC-html40'>";
            var footer = "";
            var sourceHTML = header + document.getElementById("realData").innerHTML + footer;

            var source = 'data:application/vnd.ms-excel;charset=utf-8,' + encodeURIComponent(sourceHTML);
            var fileDownload = document.createElement("a");
            document.body.appendChild(fileDownload);
            fileDownload.href = source;
            fileDownload.download = 'LEDGER ACCOUNTS.xls';
            fileDownload.click();
            document.body.removeChild(fileDownload);
        }
    </script>

    <style>
        @page {
            margin-top: 0px;
            margin-bottom: 0px;
            margin-left: auto;
            margin-right: 0px;
            padding-right: 2px;
            padding-left: 2px;
        }
    </style>

    <script>this.history.forward();</script>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <%--<div class="container-fluid container-fullw bg-white" style="position: relative; margin-top: 0px; border-top: 4px solid #404e67; border-bottom: 4px solid #404e67; border-radius: 0px;">--%>

        <div runat="server" id="mainPageContents">
            <asp:Label Text="" Visible="false" ID="clNumber" runat="server" />

            <asp:UpdateProgress DynamicLayout="true" ID="UpdateShow" runat="server" AssociatedUpdatePanelID="AA">
                <ProgressTemplate>
                    <div style="background-color: Gray; filter: alpha(opacity=60); opacity: 0.60; width: 100%; top: 0px; left: 0px; position: fixed; height: 100%; z-index: 1000;"></div>
                    <div style="margin: auto; font-family: Trebuchet MS; filter: alpha(opacity=100); border: 0px; opacity: 1; font-size: small; vertical-align: middle; z-index: 2000; top: 10%; position: fixed; left: 48%; color: #275721; text-align: center; height: 70px; width: 70px; border-radius: 4px; box-shadow: 3px;">
                        <table style="background-color: transparent; font-family: 'Century Gothic'; border: 0px; text-align: center; border-color: transparent; width: inherit; height: inherit; padding: 15px; position: absolute; top: 45%;">
                            <tr>
                                <td style="text-align: center;">
                                    <img id="Img1" style="border-color: transparent; border-radius: 2px; position: fixed; top: 45%; width: 50px; height: 50px; border: 0px; background-color: transparent" runat="server" src="~/ibsui/processing.gif" alt="Loading" />
                                </td>
                                <td style="text-align: inherit;"></td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="AA">
                <ContentTemplate>

                    <asp:Label Text="" ID="checkerX" Visible="false" runat="server" />

                    <div class="col-md-12">
                        <div class="content-header row" style="background-color: #efefef;">
                            <table runat="server" class="form-section" width="100%">
                                <tr>
                                    <td align="left">
                                        <h4 style="width: 100%;"><i class="la la-sitemap"></i>Ledger </h4>
                                    </td>

                                    <td align="right" style="font-size: x-small;">
                                        <div class="col-md-12">
                                            <asp:LinkButton Text="" ID="interbank_transfers" OnClick="interbank_Click" CssClass="btn btn-blue btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-bank" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;">InterBank Transfer </span></i></span></asp:LinkButton>
                                            <asp:LinkButton Text="" ID="close_financialperiod" OnClick="closefperiod_Click" CssClass="btn btn-blue btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-dollar" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;"> Close Financial Period </span></i></span></asp:LinkButton>
                                            <asp:LinkButton Text="" ID="bank_reconcilliation" OnClick="reconcilliation_Click" CssClass="btn btn-blue btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-compress" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;"> Reconcilliations </span></i></span></asp:LinkButton>
                                            <asp:LinkButton Text="" ID="ledger_transactions" OnClick="ledgertransactions_Click" CssClass="btn btn-dropbox btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-list" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;"> Ledger Transactions </span></i></span></asp:LinkButton>
                                            <asp:LinkButton Text="" ID="journal_entries" OnClick="journalentries_Click" CssClass="btn btn-bitbucket btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-diamond" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;"> Journal Entries</span></i></span></asp:LinkButton>
                                            <asp:LinkButton Text="" ID="record_incomes" OnClick="incomes_Click" CssClass="btn btn-success btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-dollar" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;"> Incomes </span></i></span></asp:LinkButton>
                                            <asp:LinkButton Text="" ID="record_expenses" OnClick="expenses_Click" CssClass="btn btn-danger btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-money" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;"> Expenses </span></i></span></asp:LinkButton>
                                            <asp:LinkButton Text="" ID="ledger_account" OnClick="newledgeraccount_Click" CssClass="btn btn-dropbox btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-plus-circle" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;"> New Account </span></i></span></asp:LinkButton>
                                            <asp:LinkButton Text="" ID="refereshledgeraccounts" OnClick="refereshledgeraccounts_Click" CssClass="btn btn-dropbox btn-sm" Style="padding: 3px; font-size: small;" runat="server"><span> <i class="la la-refresh" style="font-size:small;"> <span  style="font-family:montserrat;font-size:x-small;"> Refresh </span></i></span></asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div class="row" style="padding: 3px 0px 3px 0px; margin-top: 3px; background-color: #2196f3; color: white;">
                            <div class="col-md-4 text-left">
                                <h6><i class="fa fa-briefcase">: </i>
                                    <asp:Label Text=" Ledger Account(s) Information" ID="selectledger" runat="server" /></h6>
                            </div>
                            <div class="col-md-8 text-right" runat="server" id="moreoptions" visible="false">
                                <asp:LinkButton Text="" ID="grouped_statement" OnClick="groupedledgerstatement_Click" CssClass="btn btn-dark btn-sm" Style="padding: 3px; font-size: smaller;" runat="server"><span> <i class="fa fa-sitemap"> <span  style="font-family:montserrat"> Grouped Statement </span></i></span></asp:LinkButton>
                                <asp:LinkButton Text="" ID="ledger_statement" OnClick="ledgerstatement_Click" CssClass="btn btn-dark btn-sm" Style="padding: 3px; font-size: smaller;" runat="server"><span> <i class="fa fa-newspaper-o"> <span  style="font-family:montserrat"> Statement </span></i></span></asp:LinkButton>
                                <asp:LinkButton Text="" ID="edit_ledger" OnClick="editledger_Click" CssClass="btn btn-dark btn-sm" Style="padding: 3px; font-size: smaller;" runat="server"><span> <i class="fa fa-edit"> <span  style="font-family:montserrat"> Edit </span></i></span></asp:LinkButton>
                                <asp:LinkButton Text="" ID="transfer_funds" OnClick="transferfunds_Click" CssClass="btn btn-dark btn-sm" Style="padding: 3px; font-size: smaller;" runat="server"><span> <i class="fa fa-exchange"> <span  style="font-family:montserrat"> Internal Transfers </span></i></span></asp:LinkButton>
                                <asp:LinkButton Text="" ID="reconcile_account" OnClick="reconcile_Click" CssClass="btn btn-dark btn-sm" Style="padding: 3px; font-size: smaller;" runat="server"><span> <i class="fa fa-compress"> <span  style="font-family:montserrat"> Reconcile </span></i></span></asp:LinkButton>
                            </div>
                        </div>
                        <div class="row" runat="server" style="padding: 3px 0px 3px 0px; border-top: 1px solid #d8d8d8;">

                            <table runat="server" width="100%" visible="false" id="accountinfo">
                                <tr>
                                    <td>Account No.</td>
                                    <td style="font-weight: bold; text-align: left;">
                                        <asp:Label Text="" ID="accountno" CssClass="bold" runat="server" />
                                    </td>
                                    <td>Account Name.</td>
                                    <td style="font-weight: bold; text-align: left;">
                                        <asp:Label Text="" ID="accountname" CssClass="bold" runat="server" />
                                    </td>
                                    <td>Date Opened.</td>
                                    <td style="font-weight: bold; text-align: left;">
                                        <asp:Label Text="" ID="openingdate" CssClass="bold" runat="server" />
                                    </td>
                                    <td>Last Saving Date.</td>
                                    <td style="font-weight: bold; text-align: left;">
                                        <asp:Label Text="NA" ID="lastsavingdate" CssClass="bold" runat="server" />
                                    </td>
                                    <td>Balance.</td>
                                    <td style="font-weight: bold; text-align: left;">
                                        <asp:Label Text="0.00" ID="balance" CssClass="bold" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="row" style="background-color: #2196f3">
                            <div class="col-md-8">
                                <table runat="server" width="100%" style="color: white;">
                                    <tr>
                                        <td>Find</td>
                                        <td>
                                            <asp:TextBox runat="server" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="true" ID="findledgeraccount" OnTextChanged="findledgeraccount_TextChanged" Style="height: 25px;" /></td>
                                        <td>
                                            <asp:Label Text="[0]" ID="accountcount" runat="server" /></td>
                                        <td>Classification
                                        </td>
                                        <td>
                                            <asp:DropDownList Style="height: 25px;" Width="100%" AppendDataBoundItems="true" runat="server" ID="ledgerclass" AutoPostBack="true" OnSelectedIndexChanged="ledgerclass_SelectedIndexChanged" class="form-control">
                                                <asp:ListItem Value="0">Select Class</asp:ListItem>
                                                <asp:ListItem Value="INCOME">Income</asp:ListItem>
                                                <asp:ListItem Value="EXPENSE">Expenditure</asp:ListItem>
                                                <asp:ListItem Value="CURRENTASSET">Current Asset</asp:ListItem>
                                                <asp:ListItem Value="FIXEDASSET">Fixed Asset</asp:ListItem>
                                                <asp:ListItem Value="EQUITY">Equity/Capital</asp:ListItem>
                                                <asp:ListItem Value="CURRENTLIABILITY">Current Liability</asp:ListItem>
                                                <asp:ListItem Value="LONGTERMLIABILITY">Long Term Liability</asp:ListItem>
                                            </asp:DropDownList>
                                            <script type="text/javascript">$(document).ready(function () { $("#<%=ledgerclass.ClientID%>").select2(); });</script>
                                        </td>
                                        <td>Regulator Class
                                        </td>
                                        <td>
                                            <asp:DropDownList Style="height: 25px;" Width="100%" AppendDataBoundItems="true" runat="server" ID="regulatorclass" AutoPostBack="true" OnSelectedIndexChanged="regulatorclass_SelectedIndexChanged" class="form-control">
                                                <asp:ListItem Value="0">Select Class</asp:ListItem>
                                            </asp:DropDownList>
                                            <script type="text/javascript">$(document).ready(function () { $("#<%=regulatorclass.ClientID%>").select2(); });</script>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-4 text-right">
                                <asp:Label Text="" ID="status" Style="font-weight: 400;" runat="server" />
                                <asp:CheckBox Text="" ID="closed" Visible="false" runat="server" />
                                <asp:LinkButton Text="" ID="viewactiveledgeraccounts" Visible="true" OnClick="viewactiveledgeraccounts_Click" CssClass="btn btn-blue" Style="padding: 5px; font-size: smaller; border-radius: 0px" runat="server"><span> <i class="fa fa-unlock-alt"> <span  style="font-family:montserrat"> Active</span></i></span></asp:LinkButton>
                                <asp:LinkButton Text="" ID="viewinactiveledgeraccounts" Visible="true" OnClick="viewinactiveledgeraccounts_Click" CssClass="btn btn-blue" Style="padding: 5px; font-size: smaller; border-radius: 0px" runat="server"><span> <i class="fa fa-lock"> <span  style="font-family:montserrat"> Inactive</span></i></span></asp:LinkButton>
                                <asp:LinkButton Text="" ID="exporttoexcel" Visible="false" OnClientClick="excelPrint()" CssClass="btn btn-success" Style="font-size: smaller; border-radius: 3px" runat="server"><span> <i class="fa fa-file-excel-o"> <span  style="font-family:montserrat"> xls </span></i></span></asp:LinkButton>
                            </div>
                        </div>
                        <div class="row" style="font-size: smaller; left: 0px; right: 0px; cursor: pointer; overflow: auto; padding-bottom: 15px;" runat="server" id="realData">
                            <asp:Label Text="" ID="datakey" Visible="false" runat="server" />
                            <asp:GridView OnRowDataBound="OnRowDataBound" ShowFooter="true" FooterStyle-Font-Bold="true" CssClass="table table-striped table-responsive-sm" Style="width: 100%; position: absolute;" OnSelectedIndexChanged="OnSelectedIndexChanged" EmptyDataText="No customers to Display..." ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="LedgerId" GridLines="None" AllowSorting="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %>.</ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AccountNo" HeaderText="Acc No." SortExpression="AccountNo" />
                                    <asp:BoundField DataField="LedgerName" HeaderText="Account Name" SortExpression="LedgerName" />
                                    <asp:BoundField DataField="MasterCode" HeaderText="Master Code" SortExpression="MasterCode" />
                                    <asp:BoundField DataField="GroupName" HeaderText="Group Name" SortExpression="GroupName" />
                                    <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
                                    <asp:BoundField DataField="BroadClass" HeaderText="Class" SortExpression="BroadClass" />
                                    <asp:CheckBoxField DataField="IsBankAccount" HeaderText="IsBank" SortExpression="IsBankAccount" />
                                    <asp:CheckBoxField DataField="IsCashAccount" HeaderText="IsCash" SortExpression="IsCashAccount" />
                                    <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" DataFormatString="{0:n}" />
                                    <asp:CommandField HeaderText="Action" ShowSelectButton="True" ItemStyle-Width="0px" SelectText="&lt;i class=&quot;fa fa-arrow-circle-right &quot;&gt;&lt;/i&gt;">
                                        <ItemStyle Width="0px" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <asp:Button ID="btnShow" runat="server" Text="" Style="background-color: transparent; border: none;" />
                    <!-- ModalPopupExtender -->
                    <asp:ModalPopupExtender BackgroundCssClass="modalBackground" ID="mp1" CancelControlID="btnClose" runat="server" PopupControlID="Panel1" TargetControlID="btnShow" PopupDragHandleControlID="popheader">
                    </asp:ModalPopupExtender>

                    <asp:Panel Style="display: none;" ID="Panel1" runat="server" align="center">
                        <div style="position: fixed; z-index: 1; left: 3%; bottom: 10%; background-color: whitesmoke; right: 3%; top: 1%; border: 3px solid #2196f3; border-bottom-left-radius: 10px; border-bottom-right-radius: 10px; border-top-left-radius: 5px; border-top-right-radius: 5px;">
                            <table runat="server" width="100%">
                                <tr>
                                    <td>

                                        <div style="background-color: #2196f3; color: white; width: 100%; z-index: 1; text-align: right; position: relative; top: 1%; display: block;" runat="server" id="popheader">
                                            <table runat="server" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label Text="" ID="accountIN" runat="server" />
                                                    </td>
                                                    <td align="right">
                                                        <a onclick="refreshIframe();"><span class="btn btn-microsoft"><i class="fa fa-spinner"></i></span></a>
                                                        <asp:LinkButton Text="" ID="btnClose" CausesValidation="false" runat="server" Style="border-radius: 0px;"><span class="btn btn-danger"> <i class="fa fa-close"></i></span></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <div style="text-align: center; top: 20px;">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <iframe onloadstart='resizeIframe(this)' runat="server" name="reportLauch" id="optionLaunch" src="" class="embed-responsive-item" style="min-height: 90vh; height: 100vh; width: 100%; border: 0px; bottom: 10%; padding-bottom: 10%; margin-bottom: 10%;"></iframe>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>