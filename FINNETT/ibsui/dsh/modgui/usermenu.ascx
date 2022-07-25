<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usermenu.ascx.cs" Inherits="FINNETT.ibsui.dsh.modgui.usermenu" %>

<html>
<head runat="server">
</head>
<body>

    <table>
        <tr>
            <td align="right" runat="server" id="client_lookup" visible="false" style="text-align: right">
                <table>
                    <tr>
                        <td runat="server" visible="false" id="find_client">
                            <div class="nav-item dropdown" style="border: none" runat="server" id="thesearcharea">
                                <div class="input-icon icon-right icon">
                                    <asp:TextBox autocomplete="off" AutoPostBack="true" ID="searchclient" OnTextChanged="findclient_TextChanged" Style="text-align: center; width: auto;" placeholder="Find client..." runat="server" />
                                    <asp:RequiredFieldValidator ErrorMessage="" SetFocusOnError="true" InitialValue="" ControlToValidate="searchclient" runat="server" />
                                </div>
                            </div>
                        </td>
                        <td runat="server" visible="false" id="aio_search">
                            <a runat="server" id="clickadvsearch" class="nav-item nav-link" tooltip="Advanced Client Search" target="UNILoaderV" href="~/ibsui/cnt/clientxoverview"><i style="font-size: large;" class="la la-binoculars"></i></a>
                        </td>
                    </tr>
                </table>
            </td>

            <td runat="server" id="system_docs" visible="false">
                <a runat="server" id="user_manual" tooltip="User Manual" target="_blank" class="nav-item nav-link" href="~/ibsui/doc/help" role="button" aria-haspopup="true" aria-expanded="false">
                    <i class="la la-folder" style="font-size: large;"></i>
                </a>
            </td>
            <td runat="server" visible="false" id="system_notifications">
                <div class="nav-item dropdown ks-user" style="border: none; background-color: transparent; cursor: default;">
                    <a runat="server" id="normalbell" class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                        <i class="la la-bell-slash" style="font-size: large;"></i>
                    </a>
                    <a runat="server" id="shakingbell" visible="false" class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                        <i class="la la-bell" style="font-size: large;"></i>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="Preview" style="width: 100%;">
                        <a visible="false" runat="server" id="queued_tasks" class="dropdown-item" href="~/ibsui/utl/utilinitiatedawaitingtasks" target="UNILoaderV">
                            <span class="la la-check-circle ks-icon"></span>
                            <span>Queued Tasks &nbsp;
                            <asp:Label Text="0" ID="queuedtasks" Style="font-size: small; font-weight: bold;" runat="server" />
                                &nbsp;</span>
                        </a>

                        <a visible="false" runat="server" id="checker_tasks" class="dropdown-item" href="~/ibsui/utl/utilinitiatedpendingtasks" target="UNILoaderV">
                            <span class="la la-list-alt ks-icon"></span>
                            <span>Checker Task &nbsp;
                            <asp:Label Text="0" ID="initiatedtasks" Style="font-size: small; font-weight: bold;" runat="server" />
                                &nbsp;</span>
                        </a>
                    </div>
                </div>
            </td>

            <td runat="server" visible="false" id="user_profile">
                <div class="nav-item dropdown ks-user" style="border: none; background-color: transparent;">
                    <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                        <i class="la la-user" style="font-size: large;"></i>
                        <asp:Label Text="" ID="username" runat="server" />
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="Preview" style="width: 100%;">

                        <a class="dropdown-item" href="#" runat="server" id="business_information" visible="false"><span>
                            <asp:Label Text="" ID="mybusiness" runat="server" Style="width: 100%; font-size: xx-small;" />
                        </span></a>
                        <a visible="false" runat="server" id="manage_business" class="dropdown-item" href="~/connect/company/businessesoverview" target="UNILoaderV">
                            <span class="la la-user-secret ks-icon"></span>
                            <span>Manage Businesses</span>
                        </a>
                        <a visible="false" runat="server" id="business_overview" class="dropdown-item" href="~/connect/company/businessinformation" target="UNILoaderV">
                            <span class="la la-briefcase ks-icon"></span>
                            <span>Business Overview</span>
                        </a>

                        <a visible="false" runat="server" id="edit_business" class="dropdown-item" href="~/connect/company/businessinfo" target="UNILoaderV">
                            <span class="la la-edit ks-icon"></span>
                            <span>Edit Business</span>
                        </a>

                        <a visible="false" runat="server" id="sms_balance" class="dropdown-item" href="../../utl/utilxsmsbalance" target="UNILoaderV">
                            <span class="la la-comments ks-icon"></span>
                            <span>SMS Balance</span>
                        </a>

                        <a visible="false" runat="server" id="license_information" class="dropdown-item" href="~/connect/company/businesslicenseinformation" target="UNILoaderV">
                            <span class="la la-certificate ks-icon"></span>
                            <span>License Information</span>
                        </a>

                        <a visible="false" runat="server" id="pay_unistrat" class="dropdown-item" href="~/ibsui/fin/faxhowtopayunistrat" target="UNILoaderV">
                            <span class="la la-paypal ks-icon"></span>
                            <span>Pay UNISTRAT &nbsp;</span>
                        </a>
                        <hr style="margin-top: 0px; margin-bottom: 0px; padding-top: 1px; padding-bottom: 1px;" />

                        <a runat="server" id="my_profile" visible="false" class="dropdown-item" href="../../sec/myprofile" target="UNILoaderV">
                            <span class="la la-black-tie ks-icon"></span>
                            <span>My Profile</span>
                        </a>
                        <a runat="server" id="audit_trail" visible="false" class="dropdown-item" href="../../sec/myprofile" target="UNILoaderV">
                            <span class="la la-user-secret ks-icon"></span>
                            <span>Operation Trail</span>
                        </a>
                        <a runat="server" id="change_password" visible="false" class="dropdown-item" href="../../sec/changepassword" target="UNILoaderV">
                            <span class="la la-lock ks-icon"></span>
                            <span>Change Password</span>
                        </a>
                        <a runat="server" id="log_out" class="dropdown-item" href="../../../connect/am_out">
                            <span class="la la-sign-out ks-icon" aria-hidden="true"></span>
                            <span>Logout</span>
                        </a>
                    </div>
                </div>
            </td>
        </tr>
    </table>

    <asp:Button ID="Button1" runat="server" Style="background-color: transparent; border: none;" />

    <asp:ModalPopupExtender BackgroundCssClass="modal-backdrop" ID="searchPop" runat="server" PopupControlID="Panel2" TargetControlID="Button1" PopupDragHandleControlID="Div1">
    </asp:ModalPopupExtender>
    <asp:Panel Style="display: none;" ID="Panel2" runat="server" align="center">
        <div style="overflow-y: scroll; position: fixed; z-index: 500; left: 15%; bottom: 5%; margin-bottom: 5%; background-color: whitesmoke; right: 15%; top: 5%; margin-top: 5%; border: 3px solid #2196f3; border-bottom-left-radius: 10px; border-bottom-right-radius: 10px; border-top-left-radius: 5px; border-top-right-radius: 5px;">
            <table runat="server" width="100%">
                <tr>
                    <td>

                        <div style="background-color: #2196f3; color: white; width: 100%; z-index: 1; text-align: right; position: relative; top: 5%; display: block;" runat="server" id="Div1">
                            <table runat="server" width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:Label Text="SELECT CLIENT" ID="findclienttitle" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text="" ID="foundresults" runat="server" />
                                    </td>
                                    <td align="right" style="width: 50px;">
                                        <asp:LinkButton Text="" ID="closeSearchPop" OnClick="closeSearchPop_Click" CausesValidation="false" runat="server" Style="border-radius: 0px;"><span class="btn btn-danger btn-sm"> <i class="la la-close"></i></span></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView OnRowDataBound="OnRowDataBound" CssClass="table table-sm table-bordered" Style="width: 100%; position: absolute; cursor: pointer;" OnSelectedIndexChanged="OnSelectedIndexChanged" EmptyDataText="Clients not Found..." ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ClientID" GridLines="None" AllowSorting="false">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %>.</ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClientNumber" HeaderText="Client #" SortExpression="ClientNumber" />
                                <asp:BoundField DataField="NationalID" HeaderText="National ID" SortExpression="NationalID" />
                                <asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="FullName" />
                                <asp:BoundField DataField="CellPhone" HeaderText="Phone" SortExpression="CellPhone" />
                                <asp:BoundField DataField="ClientGroup" HeaderText="Group" SortExpression="ClientGroup" />
                                <asp:CommandField HeaderText="Ö" ShowSelectButton="True" SelectText="select"></asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</body>
</html>