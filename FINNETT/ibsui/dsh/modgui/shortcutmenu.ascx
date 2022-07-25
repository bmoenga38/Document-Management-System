<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="shortcutmenu.ascx.cs" Inherits="FINNETT.ibsui.dsh.modgui.shortcutmenu" %>
<span class="nav-item dropdown ks-dropdown-grid-images" runat="server" visible="true" id="shortcut_menu">
    <a class="nav-link dropdown-toggle" data-toggle="dropdown" style="background-color: transparent;" role="button" aria-haspopup="true" aria-expanded="false"></a>
    <div class="dropdown-menu ks-info ks-scrollable" aria-labelledby="Preview" data-height="260">
        <div class="ks-scroll-wrapper">
            <a runat="server" id="master_processes" href="~/ibsui/dsh/gmaster/grandview" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-user-secret ks-color-red" style="font-size: x-large;"></i>
                <span class="ks-text">Grand Master</span>
            </a>

            <a runat="server" id="home_processes" href="ubs" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-home ks-color-red" style="font-size: x-large;"></i>
                <span class="ks-text">Home</span>
            </a>
            <a runat="server" id="client_data_processes" href="clients" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-users ks-color-warning" style="font-size: x-large;"></i>
                <span class="ks-text">Clients</span>
            </a>
            <a runat="server" id="finance_processes" href="finance" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-cubes  ks-color-info" style="font-size: x-large;"></i>
                <span class="ks-text">Finance</span>
            </a>

            <a runat="server" id="penger_pay_processes" href="pengerpay" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-paypal ks-color-success" style="font-size: x-large;"></i>
                <span class="ks-text">PengerPay</span>
            </a>

            <a runat="server" id="crm" href="crm" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-gg ks-color-primary" style="font-size: x-large;"></i>
                <span class="ks-text">CRM</span>
            </a>
            <a runat="server" id="eservo_processes" href="#" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-fire ks-color-danger" style="font-size: x-large;"></i>
                <span class="ks-text">eServo</span>
            </a>
            <a runat="server" id="auto_processes" href="#" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-automobile ks-color-dark" style="font-size: x-large;"></i>
                <span class="ks-text">Garage</span>
            </a>

            <a runat="server" id="parcel_processes" href="parcel" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-truck ks-color-info" style="font-size: x-large;"></i>
                <span class="ks-text">Parcel</span>
            </a>

            <a runat="server" id="security_processes" href="secure" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-key ks-color-red" style="font-size: x-large;"></i>
                <span class="ks-text">Security</span>
            </a>
            <a runat="server" id="sms_processes" href="sms" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-comments ks-color-warning" style="font-size: x-large;"></i>
                <span class="ks-text">SMS</span>
            </a>

            <a runat="server" id="asset_processes" href="assets" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-building-o ks-color-warning" style="font-size: x-large;"></i>
                <span class="ks-text">Assets</span>
            </a>

            <a runat="server" id="report_processes" href="reports" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-bar-chart ks-color-primary" style="font-size: x-large;"></i>
                <span class="ks-text">Reports</span>
            </a>

            <a runat="server" id="pos_processes" href="pos" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-shopping-cart ks-color-red" style="font-size: x-large;"></i>
                <span class="ks-text">POS</span>
            </a>
            <a runat="server" id="back_office_processes" href="backoffice" visible="false" class="ks-grid-item" style="text-align: center; padding: 5px; padding-top: 20px; padding-bottom: 20px;">
                <i class="la la-briefcase ks-color-warning" style="font-size: x-large;"></i>
                <span class="ks-text">BOSA</span>
            </a>
        </div>
    </div>
</span>