<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="CompanyInfo.aspx.cs" Inherits="CemeterySystem.Pages.CompanyInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        jQuery(document).ready(function () {
            jQuery("#form1").validate({
                rules: {
                    "<%= txtName.UniqueID %>": {
                        required: true
                    },
                    "<%= txtLicenseNumber.UniqueID %>": {
                        required: true
                    },
                    "<%= txtStreet.UniqueID %>": {
                        required: true
                    },
                    "<%= txtHouseNumber.UniqueID %>": {
                        required: true
                    },
                    "<%= txtTown.UniqueID %>": {
                        required: true
                    },
                    "<%= txtPostCode.UniqueID %>": {
                        required: true
                    },
                    "<%= txtPhoneNumber.UniqueID %>": {
                        required: true
                    }
                },
                messages: {
                    "<%= txtName.UniqueID %>": { required: "Proszę wpisać nazwę zakładu" },
                    "<%= txtLicenseNumber.UniqueID %>": { required: "Proszę wpisać numer licencji" },
                    "<%= txtStreet.UniqueID %>": { required: "Proszę wpisać nazwę ulicy" },
                    "<%= txtHouseNumber.UniqueID %>": { required: "Proszę wpisać numer domu" },
                    "<%= txtTown.UniqueID %>": { required: "Proszę wpisać nazwę miejscowości" },
                    "<%= txtPostCode.UniqueID %>": { required: "Proszę wpisać kod pocztowy" },
                    "<%= txtPhoneNumber.UniqueID %>": { required: "Proszę wpisać numer telefonu" },
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
        });

        function validateForm() {
            jQuery("#form1").validate();
            return jQuery("#form1").valid()
        }
    </script>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblName" Text="Nazwa:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtName" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblLicenseNumber" Text="Numer licencji:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtLicenseNumber" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPhoneNumber" Text="Numer telefonu:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblStreet" Text="Ulica:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtStreet" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblHouseNumber" Text="Numer domu:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtHouseNumber" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFlatNumber" Text="Numer mieszkania:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtFlatNumber" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblTown" Text="Miejscowość:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtTown" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPostCode" Text="Kod pocztowy:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPostCode" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 10px;">            
            <button type="submit" runat="server" id="btnSave" onclick="if(!validateForm()) return;" onserverclick="btnSave_ServerClick" class="w3-button w3-green w3-round-large" style="float: right;">
                <i class="fas fa-check"></i>&nbsp;Zapisz
            </button>
        </div>
    </div>
</asp:Content>