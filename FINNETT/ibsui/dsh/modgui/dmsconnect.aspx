<%@ Page Language="C#" ViewStateEncryptionMode="Auto" EnableViewState="false" AutoEventWireup="true" CodeBehind="dmsconnect.aspx.cs" Inherits="FINNETT.ibsui.dsh.modgui.dmsconnect" %>

<%@ Register Src="~/ibsui/dsh/modgui/shortcutmenu.ascx" TagPrefix="uc1" TagName="shortcutmenu" %>
<%@ Register Src="~/ibsui/dsh/modgui/usermenu.ascx" TagPrefix="uc1" TagName="usermenu" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>PENGER PAY</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="assets/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="libs/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/fonts/line-awesome/css/line-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/fonts/montserrat/styles.css" />
    <link rel="stylesheet" type="text/css" href="libs/tether/css/tether.min.css" />
    <link rel="stylesheet" type="text/css" href="libs/jscrollpane/jquery.jscrollpane.css" />
    <link rel="stylesheet" type="text/css" href="assets/styles/common.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/styles/themes/primary.min.css" />
    <link class="ks-sidebar-dark-style" rel="stylesheet" type="text/css" href="assets/styles/themes/sidebar-black.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/fonts/kosmo/styles.css" />

    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.5)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.5)" />
</head>
<body class="ks-navbar-fixed ks-sidebar-default ks-sidebar-position-fixed ks-page-header-fixed ks-theme-primary ks-page-loading">
    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <nav class="navbar ks-navbar">
            <div class="navbar-brand">
                <a id="toggleMENU" class="ks-sidebar-toggle"><i class="ks-icon la la-bars" aria-hidden="true"></i></a>
                <a class="ks-sidebar-mobile-toggle"><i class="ks-icon la la-bars" aria-hidden="true"></i></a>
                <div class="ks-navbar-logo">
                    <a href="pengerpay" class="ks-logo">
                        <img src="../../images/abc.png" style="height: 30px; width: 30px; background-color: black; border-radius: 20px;"></a>
                    <a href="pengerpay" class="ks-logo" style="text-transform: none;">PENGERPAY</a>

                    <uc1:shortcutmenu runat="server" ID="shortcutmenu" />
                </div>
            </div>
            <div class="ks-wrapper">
                <nav class="nav navbar-nav">
                    <div class="ks-navbar-menu">
                        <div class="ks-wrapper">
                        </div>

                        <div runat="server" id="ussd" visible="false" class="nav-item dropdown" >
                            <a class="nav-link dropdown-toggle" id="PPUSSSD" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                                <i style="font-size: small;" class="la la-code"></i>&nbsp;USSD
                            </a>
                            <div class="dropdown-menu ks-info" aria-labelledby="Preview" runat="server" id="ussdsessions">
                                <a class="dropdown-item" runat="server" id="ussd_payment_menu" href="../../abc/abcxussdpaymentmenu" target="UNILoaderV" visible="true">Payment Menu</a>
                                <a class="dropdown-item" runat="server" id="ussd_sessions" href="../../abc/abcxussdsession" target="UNILoaderV" visible="true">All Sessions</a>
                            </div>
                        </div>

                        <div runat="server" id="banking_360" visible="false" class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="PPMBanking" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                                <i style="font-size: small;" class="la la-code"></i>&nbsp;Banking360
                            </a>
                            <div class="dropdown-menu ks-info" aria-labelledby="Preview" runat="server" id="Div2">
                                <a class="dropdown-item" runat="server" id="b360_playstore" href="../../abc/abcxplaystore" target="UNILoaderV" visible="true">Play Store</a>
                                <a class="dropdown-item" runat="server" id="b360_activations" href="../../abc/reports/mbactivations" target="UNILoaderV" visible="true">Activations</a>
                                <a class="dropdown-item" runat="server" id="b360_loan_applications" href="../../abc/reports/mbloanapplications" target="UNILoaderV" visible="true">Loan Applications</a>
                                <a class="dropdown-item" runat="server" id="b360_loans_byproduct" href="../../abc/reports/mbloanapplicationsbyproduct" target="UNILoaderV" visible="true">Applications by Product</a>
                                <a class="dropdown-item" runat="server" id="b360_guarantorship_requests" href="../../abc/reports/mbguarantorshiprequests" target="UNILoaderV" visible="true">Guarantorship Request</a>
                                <a class="dropdown-item" runat="server" id="b360_mpesa_payments" href="~/ibsui/abc/abcxc2btransactionhistory" visible="true" target="UNILoaderV">M-PESA Payments</a>
                                <a class="dropdown-item" runat="server" id="b360_features" href="../../abc/reports/mbappfeatures" target="UNILoaderV" visible="true">M-Banking Features</a>
                                <a class="dropdown-item" runat="server" id="b360_client_features" href="../../abc/reports/mbclientappfeatures" target="UNILoaderV" visible="true">Client B360 Settings</a>
                                <a class="dropdown-item" id="b360_registration_requests" runat="server" visible="true" href="~/ibsui/abc/abcxregistrationview" target="UNILoaderV">Registration Requests</a>
                                <a class="dropdown-item" id="b360_mobileloan_applicatioins" runat="server" visible="true" href="~/ibsui/abc/abcxmobiloanrequestsview" target="UNILoaderV">Mobile Loan Applications</a>
                            </div>
                        </div>

                        <div runat="server" id="field_capture" visible="false" class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="PPFieldCapture" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                                <i style="font-size: small;" class="la la-street-view"></i>&nbsp;FCapture
                            </a>
                            <div class="dropdown-menu ks-info" aria-labelledby="Preview">
                                <a class="dropdown-item" runat="server" id="fcapture_features" href="../../abc/reports/fcappfeatures" target="UNILoaderV">FCapture Features</a>
                                <a class="dropdown-item" id="fcapture_terminals" runat="server" visible="true" href="~/ibsui/abc/abcxfcaptureterminals" target="UNILoaderV">Terminals</a>
                                <a class="dropdown-item" id="fcapture_user_rights" runat="server" visible="true" href="~/ibsui/abc/abcxfcuseraccessrights" target="UNILoaderV">User Rights</a>
                                <a class="dropdown-item" id="fcapture_posting_accounts" runat="server" visible="true" href="~/ibsui/abc/abcxfcuserpostingaccounts" target="UNILoaderV">Posting Accounts</a>
                                <a class="dropdown-item" id="fcapture_transactions_overview" runat="server" visible="true" href="~/ibsui/abc/abcxfctrxoverview.aspx" target="UNILoaderV">Transactions Overview</a>
                                <a class="dropdown-item" id="fcapture_collections_report" runat="server" visible="true" href="~/ibsui/abc/reports/fieldcapturereports" target="UNILoaderV">Collection Report</a>
                                <a class="dropdown-item" id="fcapture_summary_collection" runat="server" visible="true" href="~/ibsui/abc/reports/fieldcapturesummaryreports" target="UNILoaderV">Collection Summary Report</a>
                                <a class="dropdown-item" id="fcapture_client_summary" runat="server" visible="true" href="~/ibsui/abc/reports/clientsummaryreports" target="UNILoaderV">Client Summary Report</a>
                            </div>
                        </div>

                        <div runat="server" id="mpesa" visible="false" class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="PPMPESA" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                                <i style="font-size: small;" class="la la-mobile-phone"></i>&nbsp;M-PESA
                            </a>
                            <div class="dropdown-menu ks-info" aria-labelledby="Preview">
                                <a class="dropdown-item" href="~/ibsui/abc/abcxsendmoneyview" id="send_money" runat="server" visible="true" target="UNILoaderV">Send Money</a>
                                <a class="dropdown-item" href="~/ibsui/abc/abcxshortcodebalance" id="mpesa_balance" runat="server" visible="true" target="UNILoaderV">Balance</a>
                                <a class="dropdown-item" href="~/ibsui/abc/abcxb2btransfers" id="b2b_transfers" runat="server" visible="true" target="UNILoaderV">B2B Transfers</a>
                                <a class="dropdown-item" href="~/ibsui/abc/abcxc2btransactionhistory" id="c2b_payments" runat="server" visible="true" target="UNILoaderV">Money IN</a>
                                <a class="dropdown-item" href="~/ibsui/abc/abcxb2ctransactionhistory" id="b2c_payments" runat="server" visible="true" target="UNILoaderV">Money OUT</a>
                                <a class="dropdown-item" href="~/ibsui/abc/reversetransaction" target="UNILoaderV" runat="server" id="reverse_transaction" visible="true">Reverse Transanction</a>
                            </div>
                        </div>
                        <div runat="server" id="Div1" visible="false" class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="PPMPESA" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                                <i style="font-size: small;" class="la la-bank"></i>&nbsp;CO~OP
                            </a>
                            <div class="dropdown-menu ks-info" aria-labelledby="Preview">
                                <a class="dropdown-item" href="~/ibsui/cop/accountbalance" id="A2" runat="server" visible="true" target="UNILoaderV">Account Balance</a>
                                <a class="dropdown-item" href="~/ibsui/cop/accounttransaction" id="A3" runat="server" visible="true" target="UNILoaderV">Account Transactions</a>
                                <a class="dropdown-item" href="~/ibsui/cop/fullstatement" id="A4" runat="server" visible="true" target="UNILoaderV">Fullstatement</a>
                                <a class="dropdown-item" href="~/ibsui/cop/minstatement" id="A8" runat="server" visible="true" target="UNILoaderV">Minstatement</a>
                                <a class="dropdown-item" href="~/ibsui/cop/iftaccount" id="A5" runat="server" visible="true" target="UNILoaderV">IFT </a>
                                <a class="dropdown-item" href="~/ibsui/cop/pesalink2phone" id="A6" runat="server" visible="true" target="UNILoaderV">Pesa~link To Phone</a>
                                 <a class="dropdown-item" href="~/ibsui/cop/pesalink2account" id="A7" runat="server" visible="true" target="UNILoaderV">Pesa~link To Account</a>
                            </div>
                        </div>

                        <div runat="server" id="crb" visible="true" class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="CRB" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">
                                <i style="font-size: small;" class="la la-street-view"></i>&nbsp;DMS
                            </a>
                            <div class="dropdown-menu ks-info" aria-labelledby="Preview">
                                <a class="dropdown-item" runat="server" id="crb_access_settings" onclick="ChangeUrl('../../crb/crbsettings')" visible="true">Access Settings </a>
                                <a class="dropdown-item" runat="server" id="identity_verification" onclick="ChangeUrl('../../crb/identityverification')" visible="true">Identity Verification </a>
                                <a class="dropdown-item" runat="server" id="deliquency_status" onclick="ChangeUrl('../../crb/delinquencystatus')" visible="true">Delinquency Status </a>
                                <a class="dropdown-item" runat="server" id="metro_score" onclick="ChangeUrl('../../crb/metroscore')" visible="true">Metro Score</a>
                                <a class="dropdown-item" runat="server" id="identity_scrub" onclick="ChangeUrl('../../crb/identityscrub')" visible="true">Identity Scrub</a>
                                <a class="dropdown-item" runat="server" id="credit_information" onclick="ChangeUrl('../../crb/creditinfo')" visible="true">Credit Information</a>
                                <a class="dropdown-item" runat="server" id="enhanced_information" onclick="ChangeUrl('../../crb/enhancedcreditinfo')" visible="true">Enh. Credit Info.</a>
                                <a class="dropdown-item" runat="server" id="enhanced_info_mobile" onclick="ChangeUrl('../../crb/enhancedcreditinfomobile')" visible="true">Enh. Credit Info. Mobile</a>
                                <a class="dropdown-item" runat="server" id="full_credit_info" onclick="ChangeUrl('../../crb/fullenhancedcreditinfo')" visible="true">Full Enh. Credit Info.</a>
                                <a class="dropdown-item" runat="server" id="minified_credit_info" onclick="ChangeUrl('../../crb/minifiedcredit')" visible="true">Mainfied Credit Info.</a>
                                <a class="dropdown-item" runat="server" id="full_json_report" onclick="ChangeUrl('../../crb/fulljsonreport')" visible="true">Full JSON Report</a>
                            </div>
                        </div>
                    </div>

                    <div class="ks-navbar-actions">
                    </div>
                    <div class="ks-navbar-actions">

                        <div class="nav-item nav-link btn-action-block">
                        </div>
                        <div class="nav-item dropdown ks-languages">
                        </div>
                        <uc1:usermenu runat="server" ID="usermenu" />
                    </div>
                </nav>
                <nav class="nav navbar-nav ks-navbar-actions-toggle">
                    <a class="nav-item nav-link">
                        <span class="la la-ellipsis-h ks-icon ks-open"></span>
                        <span class="la la-close ks-icon ks-close"></span>
                    </a>
                </nav>
                <nav class="nav navbar-nav ks-navbar-menu-toggle">
                    <a class="nav-item nav-link">
                        <span class="la la-th ks-icon ks-open"></span>
                        <span class="la la-close ks-icon ks-close"></span>
                    </a>
                </nav>
            </div>
        </nav>

        <div class="ks-page-container ks-dashboard-tabbed-sidebar-fixed-tabs">
            <div class="ks-column ks-sidebar ks-info">
                <div class="ks-wrapper ks-sidebar-wrapper">

                    <ul class="nav nav-pills nav-stacked">

                        <li runat="server" id="mpesa_settings" class="nav-item dropdown" visible="true">
                            <a class="nav-link dropdown-toggle" role="button" aria-haspopup="true" aria-expanded="false">
                                <span class="ks-icon la la-mobile-phone"></span>
                                <span>Documents</span>
                            </a>
                            <div class="dropdown-menu">                               
                                <a class="dropdown-item" href="~/ibsui/dms/filetype" target="UNILoaderV" runat="server" id="identity_types" visible="true"><i class="fa-solid fa-file-circle-plus"></i>&nbsp;File Types</a>

                                 <a class="dropdown-item" href="~/ibsui/dms/filesubcategory" target="UNILoaderV" runat="server" id="A1" visible="true"><i class="fa-solid fa-file-circle-plus"></i></i>&nbsp;File SubCategories</a>
                                
                                 <a class="dropdown-item" href="~/ibsui/dms/folders" target="UNILoaderV" runat="server" id="A9" visible="true"><i class="fa-solid fa-file-circle-plus"></i></i>&nbsp;Folders</a>
                                
                                 <a class="dropdown-item" href="~/ibsui/dms/files" target="UNILoaderV" runat="server" id="A10" visible="true"><i class="fa fa-file"></i>&nbsp;Files</a>
                                
                                
                            </div>
                        </li>

                        <li class="nav-item dropdown" runat="server" id="fcapture_settings" visible="true">
                            <a class="nav-link dropdown-toggle" role="button" aria-haspopup="true" aria-expanded="false">
                                <span class="ks-icon la la-street-view"></span>
                                <span>Field Capture</span>
                            </a>
                            <div class="dropdown-menu">
                                <a class="dropdown-item" href="~/ibsui/abc/abcxfunctions" target="UNILoaderV" runat="server" id="functions" visible="true"><i class="fa fa-sitemap"></i>&nbsp;Functions</a>
                                <a class="dropdown-item" href="~/ibsui/abc/abcxfunctioncategories" target="UNILoaderV" runat="server" id="function_categories" visible="true"><i class="fa fa-sitemap"></i>&nbsp;Function Categories</a>
                            </div>
                        </li>

                        <li class="nav-item dropdown" runat="server" id="reports" visible="true">
                            <a class="nav-link dropdown-toggle" href="#pengerpayreports" role="button" aria-haspopup="true" aria-expanded="false">
                                <span class="ks-icon la la-bar-chart"></span>
                                <span>Reports</span>
                            </a>
                            <div class="dropdown-menu">
                                <a class="dropdown-item" href="~/ibsui/abc/reports/fieldcapturereports" target="UNILoaderV" runat="server" id="full_collections_report" visible="true"><i class="fa fa-truck"></i>&nbsp;FCapture Reports</a>
                                <a class="dropdown-item" href="~/ibsui/abc/reports/fieldcapturesummaryreports" target="UNILoaderV" runat="server" id="summary_collections_report" visible="true"><i class="fa fa-truck"></i>&nbsp;FCapture Summary Report</a>
                                <a class="dropdown-item" href="~/ibsui/abc/abcxfctrxoverview" target="UNILoaderV" runat="server" id="full_transaction_overview" visible="true"><i class="fa fa-truck"></i>&nbsp;Transactions Overview</a>
                                <a class="dropdown-item" href="~/ibsui/abc/abcxb2ctransactionhistory" target="UNILoaderV" runat="server" id="mpesa_out_report" visible="true"><i class="fa fa-truck"></i>&nbsp;M-Pesa OUT Report</a>
                                <a class="dropdown-item" href="~/ibsui/abc/abcxc2btransactionhistory" target="UNILoaderV" runat="server" id="mpesa_in_report" visible="true"><i class="fa fa-truck"></i>&nbsp;M-Pesa IN Report</a>
                                <a class="dropdown-item" onserverclick="pencustomreports_ServerClick" runat="server" id="custom_report" visible="true"><i class="fa fa-align-center"></i>&nbsp;Custom Reports</a>
                            </div>
                        </li>

                        <li class="nav-item dropdown" runat="server" id="data_uploads" visible="true">
                            <a class="nav-link" runat="server" target="UNILoaderV" href="../../utl/fileuploadoverview" role="button" aria-haspopup="true" aria-expanded="false">
                                <span class="ks-icon la la-upload"></span>
                                <span>File Uploads</span>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="ks-column ks-page">
                <div class="ks-page-container">
                    <div class="ks-page-content">
                        <iframe id="UNILoaderV" class="ks-page-content-body" style="height: 100vh; overflow: scroll;"
                            name="UNILoaderV" runat="server" src="~/ibsui/dsh/dboard/abcdashboard"></iframe>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="libs/responsejs/response.min.js"></script>
    <script src="libs/loading-overlay/loadingoverlay.min.js"></script>
    <script src="libs/jscrollpane/jquery.jscrollpane.min.js"></script>
    <script src="libs/tether/js/tether.min.js"></script>
    <script src="libs/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/scripts/common.min.js"></script>
    <script src="libs/velocity/velocity.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var elems = $('a');
            elems.on('click', function (e) {
                $(this).addClass('nav-link bg-primary');
                elems.not(this).removeClass('nav-link bg-primary');
                elems.not(this).addClass('nav-link');
            });
        });
    </script>
    <link href="../../cssjs/popupcss.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () { $("#btnClose0").click(function (e) { HideDialog0(); }); });
        function ShowDialog(modal) { $("#overlay").show(); $("#dialog").fadeIn(300); if (modal) { $("#overlay").unbind("click"); } else { $("#overlay").click(function (e) { HideDialog(); }); } } function popME() { ShowDialog(true); } function popME0() { ShowDialog0(true); } function HideDialog() { $("#overlay").hide(); $("#dialog").fadeOut(300); } function HideDialog0() { $("#overlay0").hide(); $("#dialog0").fadeOut(300); } function ShowDialog0(modal) { $("#overlay0").show(); $("#dialog0").fadeIn(300); if (modal) { $("#overlay0").unbind("click"); } else { $("#overlay0").click(function (e) { HideDialog0(); }); } } function scrollPageX() { window.scrollTo(100, 100); } function ScrollSmooth() { $("a[href='#top']").click(function () { $("html, body").animate({ scrollTop: 0 }, "slow"); return false; }); }
    </script>
    <%--<script type="text/javascript">document.addEventListener('contextmenu', event => event.preventDefault());</script>--%>
    <script>this.history.forward();</script>

    <script type="text/javascript">
        function ChangeUrl(loc) {
            document.getElementById("UNILoaderV").src = loc;

        }
    </script>

    <style type="text/css">
        .selectedbg {
            background-color: #25628f;
        }
    </style>
    <div class="ks-mobile-overlay"></div>
    <div class="ks-mobile-overlay"></div>
</body>
</html>