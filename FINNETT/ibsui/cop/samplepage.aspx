<%@ Page Language="C#" ViewStateEncryptionMode="Auto" Title="User" AutoEventWireup="true" CodeBehind="samplepage.aspx.cs" Inherits="FINNETT.ibsui.cop.samplepage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <title>Access Terminals</title>
    <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/css/vendors.min.css"/>   <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/css/app.min.css"/>    <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/css/style.css"/>    <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/fonts/line-awesome/css/line-awesome.min.css"/>   <link rel="stylesheet" type="text/css" href="../dsh/modgui/assets/fonts/montserrat/styles.css" />
    
    <script type="text/javascript"> if (top == self) { window.location.replace("../../ibsui/dsh/modgui/coopconnect"); } else { } </script>
    <script src="../../ibsui/cssjs/jquery-1.4.3.min.js"></script>
    <link href="../../ibsui/cssjs/popupcss.css" rel="stylesheet" />
    <script type="text/javascript">  $(document).ready(function () { $("#btnClose0").click(function (e) { HideDialog0(); }); }); function ShowDialog(modal) { $("#overlay").show(); $("#dialog").fadeIn(300); if (modal) { $("#overlay").unbind("click"); } else { $("#overlay").click(function (e) { HideDialog(); }); } } function popME() { ShowDialog(true); } function popME0() { ShowDialog0(true); } function HideDialog() { $("#overlay").hide(); $("#dialog").fadeOut(300); } function HideDialog0() { $("#overlay0").hide(); $("#dialog0").fadeOut(300); } function ShowDialog0(modal) { $("#overlay0").show(); $("#dialog0").fadeIn(300); if (modal) { $("#overlay0").unbind("click"); } else { $("#overlay0").click(function (e) { HideDialog0(); }); } } function scrollPageX() { window.scrollTo(100, 100); } function ScrollSmooth() { $("a[href='#top']").click(function () { $("html, body").animate({ scrollTop: 0 }, "slow"); return false; }); } </script>
    <%--<script type="text/javascript">document.addEventListener('contextmenu', event => event.preventDefault());</script>--%>
<script>this.history.forward();</script> </head>
<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col-md-12">
                    <div class="content-header row" style="background-color: #efefef;">
                        <h5 class="form-section" style="width: 100%;"><i class="fa fa-desktop"></i>ACCESS TERMINALS</h5>
                    </div>
                    <%-- Operation Status Alert --%>
                    <div id="output"></div>
                    <div id="overlay" class="web_dialog_overlay"></div>
                    <div id="dialog" class="web_dialog">
                        <div class="web_dialog_title">Finnett 360 :: Transaction Status ::</div>
                        <br />
                        <div style="text-align: center">
                            <asp:Label runat="server" ID="popMessage" Text="" Style="width: 100%; font-family: 'Century Gothic'; text-align: center"> </asp:Label>
                        </div>
                        <div style="position: absolute; text-align: right; bottom: 0px; width: 100%;">
                            <asp:LinkButton Text="OK" CausesValidation="false" class="btn btn-success" ID="closeStatus" OnClick="closeStatus_Click" runat="server" Style="position: relative; border-bottom-left-radius: 10px; border-bottom-right-radius: 10px; bottom: 0px; width: 100%; height: 25px; font-size: smaller; padding-top: 1%" />
                        </div>
                    </div>
                    <asp:Label Text="" ID="checkerX" Visible="false" runat="server" />
                    <%-- Transaction Confirmation --%>
                    <div id="output0"></div>
                    <div id="overlay0" class="web_dialog_overlay"></div>
                    <div id="dialog0" class="web_dialog">
                        <div class="web_dialog_title">Finnett 360 :: Confirmation :: </div>
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <img src="../../ibsui/images/question.png" width="30" height="30" alt="?" />
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="updateData" Text="Are you sure you want to proceed?" Style="width: 100%; font-family: 'Century Gothic'"> </asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div style="position: absolute; bottom: 0px; width: 100%;">
                            <table runat="server" width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:LinkButton CausesValidation="false" OnClick="btnClose0_Click" ID="btnCloseV" Style="border-bottom-left-radius: 10px;" Text="No" runat="server" class="btn btn-danger" /></td>
                                    <td align="right">
                                        <asp:LinkButton CausesValidation="false" ID="yesButton" OnClick="Unnamed_Click" Style="border-bottom-right-radius: 10px;" Text="Yes" runat="server" class="btn btn-success" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2 text-right">
                            Terminal Type
                        </div>

                        <div class="col-md-4  text-left">
                            <asp:DropDownList runat="server" CssClass="form-control" Style="height: 25px;" ID="terminaltype" AutoPostBack="true" OnSelectedIndexChanged="terminaltype_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="terminaltype" runat="server" />
                        </div>
                        <div class="col-md-2 text-right">
                            Terminal Name
                        </div>

                        <div class="col-md-4  text-left">
                            <asp:TextBox AutoCompleteType="Disabled" runat="server" CssClass="form-control" ID="terminalname" />
                            <asp:RequiredFieldValidator ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="terminalname" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2 text-right">
                            Terminal Serial
                        </div>

                        <div class="col-md-4  text-left">
                            <asp:TextBox AutoCompleteType="Disabled" runat="server" CssClass="form-control" ID="terminalserial" />
                        </div>
                        <div class="col-md-2 text-right">
                            Terminal IP
                        </div>

                        <div class="col-md-4  text-left">
                            <asp:TextBox AutoCompleteType="Disabled" runat="server" CssClass="form-control" ID="terminalip" />
                            <asp:RequiredFieldValidator ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="terminalip" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2 text-right">
                            Access
                        </div>

                        <div class="col-md-4  text-left">
                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="allowdeny">
                                <asp:ListItem Text="Allowed" Selected="True" />
                                <asp:ListItem Text="Denied" />
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-md-2 text-right">
                            Link to User
                        </div>

                        <div class="col-md-4  text-left">
                            <asp:DropDownList runat="server" CssClass="form-control" Style="height: 25px;" ID="locktouser" AppendDataBoundItems="true">
                                <asp:ListItem Text="NONE" Value="NONE" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row" style="padding-bottom: 5px; background-color: #2196f3;">
                        <div class="col-md-2 text-left">

                            <asp:CheckBox Text="Is Active" ID="valid" Checked="true" runat="server" />
                        </div>
                        <div class="col-md-10  text-right">
                            <asp:LinkButton ID="add" Visible="true" runat="server" OnClick="add_Click" CssClass="btn btn-black">
                                                        <span class="fa fa-plus-circle"></span> Add TERMINAL </asp:LinkButton>

                            <asp:LinkButton ID="update" Visible="false" runat="server" OnClick="update_Click" CssClass="btn btn-success">
                                                        <span class="fa fa-database"></span> Update TERMINAL </asp:LinkButton>
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label Text="" ID="datakey" Visible="false" runat="server" />
                        <asp:GridView Style="width: 100%; position: absolute; right: 0px; cursor: pointer;" CssClass="table table-striped table-responsive-md" OnSelectedIndexChanged="OnSelectedIndexChanged" EmptyDataText="No Terminals Defined" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TerminalID" GridLines="None" AllowSorting="false">
                            <Columns>
                                <asp:BoundField DataField="TerminalName" HeaderText="Terminal Name" SortExpression="TerminalName" />
                                <asp:BoundField DataField="SerialNumber" HeaderText="Serial No." SortExpression="SerialNumber" />
                                <asp:BoundField DataField="TerminalIP" HeaderText="Terminal IP" SortExpression="TerminalIP" />
                                <asp:BoundField DataField="TerminalType" HeaderText="Terminal Type" SortExpression="TerminalType" />
                                <asp:BoundField DataField="LockToUser" HeaderText="Lock To User" SortExpression="LockToUser" />
                                <asp:CheckBoxField DataField="Allowed" HeaderText="Allowed" SortExpression="Allowed" />
                                <asp:CheckBoxField DataField="Suspended" HeaderText="Suspended" SortExpression="Suspended" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton CausesValidation="false" Text="" ID="viewdata" OnClick="viewdata_Click" class="text-azure" runat="server"><span> <i class="fa fa-edit"></i></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" ItemStyle-Width="0px" SelectText=""></asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="add" />
                <asp:PostBackTrigger ControlID="update" />
                <asp:PostBackTrigger ControlID="btnCloseV" />
                <asp:PostBackTrigger ControlID="yesButton" />
                <asp:PostBackTrigger ControlID="closeStatus" />
            </Triggers>
        </asp:UpdatePanel>
    </form>

   

   
    
   
   
    

    
</body>
</html>