<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="BurialPlacesDetails.aspx.cs" Inherits="CemeterySystem.Pages.BurialPlacesDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        jQuery(document).ready(function () {
            jQuery("#form1").validate({
                rules: {
                    "<%= txtFieldNumber.UniqueID %>": {
                        required: true
                    }                    
                },
                messages: {
                    "<%= txtFieldNumber.UniqueID %>": { required: "Proszę wpisać numer pola" }                    
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
            
            jQuery("#<%= txtPaymentDate.ClientID %>").datepicker({
                dateFormat: 'dd.mm.yy'
            });           
        });

        function validateForm() {
            jQuery("#form1").validate();
            return jQuery("#form1").valid()
        }
    </script>

    <div class="w3-container" style="margin-top: 80px; padding-bottom: 20px;" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Miejsca pogrzebania</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
        <% if (("" + ViewState["Existing"]).Equals("True")) { %> 
            <span style="color: #cb2121; font-size: 20px;">
                Miejsce pogrzebania z podanym numerem pola i miejsca już istnieje
            </span>
         <%} %>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFieldNumber" Text="Numer pola:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtFieldNumber" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblGraveNumber" Text="Numer miejsca:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtGraveNumber" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblType" Text="Typ:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:DropDownList runat="server" ID="ddlType" CssClass="w3-select w3-border"></asp:DropDownList>
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblStatus" Text="Status:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:DropDownList runat="server" ID="ddlStatus" CssClass="w3-select w3-border"></asp:DropDownList>
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPaymentClass" Text="Klasa opłaty:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:DropDownList runat="server" ID="ddlPaymentClass" CssClass="w3-select w3-border"></asp:DropDownList>
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPaymentDate" Text="Termin opłaty:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPaymentDate" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblDescription" Text="Opis:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtDescription" CssClass="w3-input w3-round-large" TextMode="MultiLine" Rows="5" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 10px;">
           <a runat="server" id="lbtnGoBack" onserverclick="lbtnGoBack_ServerClick" class="w3-button w3-blue w3-round-large" style="float: left; margin-right: 10px;">
                <i class="fa fa-arrow-left"></i>&nbsp;Powrót
            </a>
        
            <a runat="server" id="btnDelete" onserverclick="btnDelete_ServerClick" class="w3-button w3-red w3-round-large" style="float: left;">
                <i class="fa fa-times"></i>&nbsp;Usuń
            </a>
            <button type="submit" runat="server" id="btnSave" onclick="if(!validateForm()) return;" onserverclick="btnSave_ServerClick" class="w3-button w3-green w3-round-large" style="float: right;">
                <i class="fas fa-check"></i>&nbsp;Zapisz
            </button>
        </div>
    </div>
</asp:Content>