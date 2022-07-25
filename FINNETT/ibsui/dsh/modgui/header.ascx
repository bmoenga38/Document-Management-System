<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="FINNETT.ibsui.dsh.modgui.header" %>
<%@ Register Src="~/ibsui/dsh/modgui/usermenu.ascx" TagPrefix="uc1" TagName="usermenu" %>

<div class="ks-wrapper">
    <nav class="nav navbar-nav">
        <div class="ks-navbar-menu">
            <div class="ks-wrapper">
            </div>
            <a runat="server" id="home_processes" visible="false" class="nav-item nav-link bg-primary" href="ubs"><i style="font-size: small;" class="la la-home"></i>&nbsp;</a>
            <a runat="server" id="client_data_processes" visible="false" class="nav-item nav-link" title="Client Information" href="clients"><i style="font-size: small;" class="la la-users"></i>&nbsp;Clients </a>
            <a runat="server" id="crm_processes" visible="false" class="nav-item nav-link" title="Customer Relationship Management" href="crm"><i style="font-size: small;" class="la la-gg"></i>&nbsp;CRM</a>
            <a runat="server" id="finance_processes" visible="false" class="nav-item nav-link" title="Finance, Accounting" href="finance"><i style="font-size: small;" class="la la-cubes"></i>&nbsp;Finance</a>
            <a runat="server" id="pos_processes" visible="false" class="nav-item nav-link" title="Inventory and POS" href="pos"><i style="font-size: small;" class="la la-shopping-cart"></i>&nbsp;POS</a>
            <a runat="server" id="penger_pay_processes" visible="false" class="nav-item nav-link" title="ABC,FCapture,Revenue" href="pengerpay"><i style="font-size: small;" class="la la-paypal"></i>&nbsp;pengerPay</a>
            <a runat="server" id="eservo_processes" visible="false" class="nav-item nav-link" title="Petrol Station Management" href="eservo"><i style="font-size: small;" class="la la-fire"></i>&nbsp;eServo</a>
            <a runat="server" id="parcel_processes" visible="false" class="nav-item nav-link" title="Parcel Services" href="parcel"><i style="font-size: small;" class="la la-truck"></i>&nbsp;Parcel</a>
            <a runat="server" id="auto_processes" visible="false" class="nav-item nav-link" title="Auto Care Services" href="autocare"><i style="font-size: small;" class="la la-automobile"></i>&nbsp;MotoX</a>
            <a runat="server" id="sms_processes" visible="false" class="nav-item nav-link" title="SMS Communication" href="sms"><i style="font-size: small;" class="la la-comments"></i>&nbsp;Sms</a>
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