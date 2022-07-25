<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mpesaurl.aspx.cs" Inherits="FINNETT.ibsui.cop.mpesaurl" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Identity Verification</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <link rel="stylesheet" type="text/css" href="../../app-assets/css/vendors.min.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/vendors/css/charts/jquery-jvectormap-2.0.3.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/vendors/css/charts/morris.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/vendors/css/extensions/unslider.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/vendors/css/weather-icons/climacons.min.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/css/app.min.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/css/core/menu/menu-types/vertical-menu.min.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/css/style.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/fonts/line-awesome/css/line-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/fonts/montserrat/styles.css">

    <script type="text/javascript"> if (top == self) { window.location.replace("../dsh/modgui/mpesa"); } else { } </script>
    <!-- POP CODE-->
    <script src="../cssjs/jquery.min.js"></script>
    <link href="../cssjs/gFormat.css" rel="stylesheet" />
    <script src="../cssjs/notie.js"></script>
    <link rel="stylesheet" type="text/css" href="../cssjs/notie.scss" />
    <link href="../cssjs/notie.min.css" rel="stylesheet" />
    <script src="../cssjs/notie.min.js"></script>
    <script src="../cssjs/jquery-1.4.3.min.js"></script>
    <link href="../cssjs/popupcss.css" rel="stylesheet" />
    <script type="text/javascript">  $(document).ready(function () { $("#btnClose0").click(function (e) { HideDialog0(); }); }); function ShowDialog(modal) { $("#overlay").show(); $("#dialog").fadeIn(300); if (modal) { $("#overlay").unbind("click"); } else { $("#overlay").click(function (e) { HideDialog(); }); } } function popME() { ShowDialog(true); } function popME0() { ShowDialog0(true); } function HideDialog() { $("#overlay").hide(); $("#dialog").fadeOut(300); } function HideDialog0() { $("#overlay0").hide(); $("#dialog0").fadeOut(300); } function ShowDialog0(modal) { $("#overlay0").show(); $("#dialog0").fadeIn(300); if (modal) { $("#overlay0").unbind("click"); } else { $("#overlay0").click(function (e) { HideDialog0(); }); } } function scrollPageX() { window.scrollTo(100, 100); } function ScrollSmooth() { $("a[href='#top']").click(function () { $("html, body").animate({ scrollTop: 0 }, "slow"); return false; }); } </script>
</head>
<body onload="if(history.length>0)history.go(+1)">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress DynamicLayout="true" ID="UpdateShow" runat="server" AssociatedUpdatePanelID="AA">
            <ProgressTemplate>
                <div style="background-color: Gray; filter: alpha(opacity=60); opacity: 0.60; width: 100%; top: 0px; left: 0px; position: fixed; height: 100%; z-index: 1000;"></div>
                <div style="margin: auto; font-family: Trebuchet MS; filter: alpha(opacity=100); border: 0px; opacity: 1; font-size: small; vertical-align: middle; z-index: 2000; top: 10%; position: fixed; left: 48%; color: #275721; text-align: center; height: 70px; width: 70px; border-radius: 4px; box-shadow: 3px;">
                    <table style="background-color: transparent; font-family: 'Century Gothic'; border: 0px; text-align: center; border-color: transparent; width: inherit; height: inherit; padding: 15px; position: absolute; top: 45%;">
                        <tr>
                            <td style="text-align: center;">
                                <img id="Img1" style="border-color: transparent; border-radius: 2px; position: absolute; top: 15%; width: 50px; height: 50px; border: 0px; background-color: transparent" runat="server" src="~/ibsui/processing.gif" alt="Loading" />
                            </td>
                            <td style="text-align: inherit;"></td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="AA">
            <ContentTemplate>
                <%-- Operation Status Alert --%>
                <div id="output"></div>
                <div id="overlay" class="web_dialog_overlay"></div>
                <div id="dialog" class="web_dialog">
                    <div class="web_dialog_title">Transaction Status</div>
                    <br />
                    <div style="text-align: center">
                        <asp:Label runat="server" ID="popMessage" Text="" Style="width: 100%; font-family: 'Century Gothic'; text-align: center"> </asp:Label>
                    </div>
                    <div style="position: absolute; text-align: right; bottom: 0px; width: 100%;">
                        <asp:LinkButton Text="OK" CausesValidation="false" class="btn btn-success" ID="closeStatus" OnClick="closeStatus_Click" runat="server" Style="position: relative; border-radius: 0px; bottom: 0px; width: 100%; height: 25px; font-size: smaller; padding-top: 1%" />
                    </div>
                </div>
                <asp:Label Text="" ID="checkerX" Visible="false" runat="server" />
                <%-- Transaction Confirmation --%>
                <div id="output0"></div>
                <div id="overlay0" class="web_dialog_overlay"></div>
                <div id="dialog0" class="web_dialog">
                    <div class="web_dialog_title">Confirmation</div>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <img src="../images/question.png" width="30" height="30" alt="?" />
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
                                    <asp:LinkButton CausesValidation="false" OnClick="btnClose0_Click" ID="btnCloseV" Style="border-radius: 0px;" Text="No" runat="server" class="btn btn-danger" /></td>
                                <td align="right">
                                    <asp:LinkButton CausesValidation="false" OnClick="Unnamed_Click" Style="border-radius: 0px;" Text="Yes" runat="server" class="btn btn-success" /></td>
                            </tr>
                        </table>
                    </div>
                </div>

                <%-- <div class="container-fluid">--%>
                <div class="container-fluid container-fullw bg-white" style="position: relative; margin-top: 0px; border-top: 4px solid #404e67; border-bottom: 4px solid #404e67; border-radius: 0px;">

                    <div class="content-header row" style="background-color: #efefef;">
                        <h5 class="form-section" style="width: 100%;"><i class="fa fa-file"></i>M~PESA URL</h5>
                    </div>
                 
                    <div class="row">
                       
                         <div class="col-md-2 text-right">
                            URL CODE:
                        </div>

                        <div class="col-md-4 text-left">
                            <asp:TextBox AutoCompleteType="Disabled" runat="server" placeholder="MPESA URL" ID="ApiUrlCode" class="form-control"/>
                            <asp:RequiredFieldValidator ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ApiUrlCode" runat="server" />
                        </div>
                        <div class="col-md-2 text-right">
                             URL:
                        </div>
                        <div class="col-md-4 text-left">
                            <asp:TextBox AutoCompleteType="Disabled" runat="server" placeholder="URL" ID="ApiUrlString" class="form-control" />
                            <asp:RequiredFieldValidator ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="ApiUrlString" runat="server" />
                        </div>
                         
                    </div>
                   
                   
                    <div class="row" style="background-color: #2196f3; text-align: right; padding-bottom: 5px; padding-top: 5px;">
                        <div class="col-md-2 text-right">
                            <asp:CheckBox Text="Is Active?" class="checkbox clip-check check-primary checkbox-inline" Checked="true" ID="valid" runat="server" />
                        </div>
                        <div class="col-md-10 text-right">
                                <asp:LinkButton Text="" ID="clearformdata" OnClick="clearformdata_Click" CausesValidation="false" runat="server"><span class="btn btn-info"> Clear Form<i class="fa fa-spinner"></i></span></asp:LinkButton>
                            &nbsp;
                                <asp:LinkButton Text="" ID="add" OnClick="add_Click" runat="server"><span class="btn btn-black"> Register URL <i class="fa fa-id-card"></i></span></asp:LinkButton>
                            &nbsp;
                                <asp:LinkButton Visible="false" Text="" ID="update" OnClick="update_Click" runat="server"><span class="btn btn-success"> Update URL <i class="fa fa-magic"></i></span></asp:LinkButton>
                            &nbsp;
                                <asp:LinkButton Text="" ID="refreshdata" OnClick="refreshdata_Click" Visible="false" CausesValidation="false" runat="server"><span class="btn btn-black"> Refresh Data <i class="fa fa-spinner"></i></span></asp:LinkButton>
                            &nbsp;
                                                   
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label Text="" ID="datakey" Visible="false" runat="server" />
                        <asp:GridView Style="width: 100%; position: absolute; left: 0px; right: 0px;" OnRowDataBound="OnRowDataBound" CssClass="table table-striped table-responsive-md" OnSelectedIndexChanged="OnSelectedIndexChanged" EmptyDataText="URL not Configured" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ApiUrlId" GridLines="None" AllowSorting="false">
                            <Columns>
                                <asp:BoundField DataField="ApiUrlCode" HeaderText="Api Url Code" SortExpression="ApiUrlCode" />
                                <asp:BoundField DataField="ApiUrlString" HeaderText="Api Url String" SortExpression="ApiUrlString" />                           
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton Text="" ID="viewdata" CausesValidation="false" OnClick="viewdata_Click" class="text-azure" runat="server"><span> Edit <i class="fa fa-edit"></i></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowSelectButton="True" ItemStyle-Width="0px" SelectText=""></asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="clearformdata" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="add" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="update" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="refreshdata" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>

    <script src="../../app-assets/vendors/js/extensions/jquery.knob.min.js" type="text/javascript"></script>
    <script src="../../app-assets/js/scripts/extensions/knob.min.js" type="text/javascript"></script>
    <script src="../../app-assets/vendors/js/charts/raphael-min.js" type="text/javascript"></script>
    <script src="../../app-assets/vendors/js/charts/morris.min.js" type="text/javascript"></script>
    <script src="../../app-assets/vendors/js/charts/jvector/jquery-jvectormap-2.0.3.min.js" type="text/javascript"></script>
    <script src="../../app-assets/vendors/js/charts/jvector/jquery-jvectormap-world-mill.js" type="text/javascript"></script>
    <script src="../../app-assets/data/jvector/visitor-data.js" type="text/javascript"></script>
    <script src="../../app-assets/vendors/js/charts/chart.min.js" type="text/javascript"></script>
    <script src="../../app-assets/vendors/js/charts/jquery.sparkline.min.js" type="text/javascript"></script>
    <script src="../../app-assets/vendors/js/extensions/unslider-min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../app-assets/css/core/colors/palette-climacon.css">
    <link rel="stylesheet" type="text/css" href="../../app-assets/fonts/simple-line-icons/style.min.css">
    <script src="../../app-assets/js/core/app-menu.min.js" type="text/javascript"></script>
    <script src="../../app-assets/js/core/app.min.js" type="text/javascript"></script>
    <script src="../../app-assets/js/scripts/customizer.min.js" type="text/javascript"></script>
    <script src="../../app-assets/js/scripts/pages/dsh-analytics.min.js" type="text/javascript"></script>
    <script>
        jQuery(document).ready(function () {
            Main.init();
            FormWizard.init();
        });
    </script>
</body>
</html>