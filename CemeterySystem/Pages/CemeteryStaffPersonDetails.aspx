<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="CemeteryStaffPersonDetails.aspx.cs" Inherits="CemeterySystem.Pages.CemeteryStaffPersonDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Personel cmentarza</b></h1> 
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">  <br />  
        <button onclick="window.history.back()"  class="w3-button w3-green w3-round-large" style="float: left;">Wróć  </button>
     <br />   
     <br />    
     <br />    
 </div>


    <script>
        jQuery(document).ready(function () {
            jQuery("#form1").validate({
                rules: {
                    "<%= txtFirstName.UniqueID %>": {
                        required: true
                    },
                    "<%= txtLastName.UniqueID %>": {
                        required: true
                    },
                    "<%= txtPosition.UniqueID %>": {
                        required: true
                    },
                    "<%= txtPESEL.UniqueID %>": {
                        required: true
                    }            
                },
                messages: {
                    "<%= txtFirstName.UniqueID %>": { required: "Proszę wpisać imię" },
                    "<%= txtLastName.UniqueID %>": { required: "Proszę wpisać nazwisko" },
                    "<%= txtPosition.UniqueID %>": { required: "Proszę wpisać pozycję" },
                    "<%= txtPESEL.UniqueID %>": { required: "Proszę wpisać PESEL" }
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
        });

        function validateForm() {
            jQuery("#form1").validate();            
            return jQuery("#form1").valid();
        }
    </script>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFirstName" Text="Imię:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtFirstName" CssClass="w3-input w3-round-large" />        
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblLastName" Text="Nazwisko:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtLastName" CssClass="w3-input w3-round-large" />        
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPosition" Text="Pozycja" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPosition" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPESEL" Text="PESEL:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPESEL" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 10px;">
            <a runat="server" id="btnDelete" onserverclick="btnDelete_ServerClick" class="w3-button w3-red w3-round-large" style="float: left;">
                <i class="fa fa-times"></i>&nbsp;Usuń
            </a>
            <button type="submit" runat="server" id="btnSave" onclick="if(!validateForm()) return;" onserverclick="btnSave_Click" class="w3-button w3-green w3-round-large" style="float: right;">
                <i class="fas fa-check"></i>&nbsp;Zapisz
            </button>
        </div>
    </div>
</asp:Content>
