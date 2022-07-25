


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FINNETT.ibsui.dsh.modgui.login" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Finnett 360 : Core Banking</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="libs/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/fonts/line-awesome/css/line-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/fonts/montserrat/styles.css" />
    <link rel="stylesheet" type="text/css" href="libs/flag-icon-css/css/flag-icon.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/styles/common.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/styles/themes/primary.min.css" />
    <link class="ks-sidebar-dark-style" rel="stylesheet" type="text/css" href="assets/styles/themes/sidebar-black.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/fonts/kosmo/styles.css" />
    <link rel="stylesheet" type="text/css" href="libs/c3js/c3.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/styles/dsh/tabbed-sidebar.min.css" />
    <script src="../../../app-assets/jquery.min.js"></script>
    <script>jQuery(window).load(function () { jQuery('#overlay').fadeOut(); });</script>
    <style>
        #overlay {
            background: #ffffff;
            color: #666666;
            position: fixed;
            height: 100%;
            width: 100%;
            z-index: 5000;
            top: 0;
            left: 0;
            float: left;
            text-align: center;
            padding-top: 25%;
        }
    </style>
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

    <script type="text/javascript">
        var idleTime = 0;
        $(document).ready(function () {
            var idleInterval = setInterval(timerIncrement, 60000);
            $(this).mousemove(function (e) {
                idleTime = 0;
            });
            $(this).keypress(function (e) {
                idleTime = 0;
            });
        });

        function timerIncrement() {
            idleTime = idleTime + 1;
            if (idleTime > 30) {
                window.location.replace("../../../connect/ibis.aspx");
            }
        }
    </script>
</head>
<body onload="if(history.length>0)history.go(+1)" class="ks-navbar-fixed ks-sidebar-default ks-sidebar-position-fixed ks-page-header-fixed ks-theme-primary ks-page-loading">

    <div id="overlay">
        <img src="../../processing.gif" width="50" height="50" alt="processing..." /><br />
    </div>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid container-fullw bg-white" style="position: relative; margin-top: 0px; border-top: 4px solid #404e67; border-bottom: 4px solid #404e67; border-radius: 0px;" >
            <div class="row" >
                <div class="col-4"></div>
                <div class="col-4">
                      
                    <div class="row">
                        <div class="col-7">
                            <img src="../../images/finnetttransparent.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                           User Name
                        </div>
                        <div class="col-7">
                            <asp:TextBox AutoCompleteType="Disabled" runat="server" placeholder="User Name" ID="txt_Username"  class="form-control" />
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-4">
                           Password
                        </div>
                        <div class="col-7">
                            <asp:TextBox AutoCompleteType="Disabled" runat="server" placeholder="password" ID="txt_password"  class="form-control" type="password"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-7">
                             <asp:button text="LogIn" runat="server" Onclick="businessOnClick"/>
                             <asp:button text="Verify Business" runat="server" Onclick="verification" Visible="false" ID="bsverification"/>
                        </div>
                        <div class="col-4">
                            <asp:Label Text="" runat="server" ID="labale" />
                        </div>
                    </div>
                </div>
                <div class="col-4"></div>
            </div>
        </div>
       
    </form>
</body> 