<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="FuneralCompanyDetails.aspx.cs" Inherits="CemeterySystem.Pages.FuneralCompanyDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Zakłady pogrzebowe</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

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
            <button runat="server" id="btnDelete" onserverclick="btnDelete_ServerClick" class="w3-button w3-red w3-round-large" style="float: left;">
                <i class="fa fa-times"></i>&nbsp;Usuń
            </button>
            <button type="submit" runat="server" id="btnSave" onclick="if(!validateForm()) return;" onserverclick="btnSave_ServerClick" class="w3-button w3-green w3-round-large" style="float: right;">
                <i class="fas fa-check"></i>&nbsp;Zapisz
            </button>
        </div>
    </div>
</asp:Content>
