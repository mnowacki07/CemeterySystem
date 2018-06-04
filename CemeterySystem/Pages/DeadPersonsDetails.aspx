<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="DeadPersonsDetails.aspx.cs" Inherits="CemeterySystem.Pages.DeadPersonsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Osoby zmarłe</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>


   <!-- Tutaj kod tabelki -->

    <script>
        jQuery(document).ready(function () {
            jQuery("#form1").validate({
                rules: {
                                
                },
                messages: {
                                     
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
            
            jQuery("#<%= txtFuneralDate.ClientID %>").datepicker({
                dateFormat: 'dd.mm.yy'
            });           
        });

        function validateForm() {
            jQuery("#form1").validate();
            return jQuery("#form1").valid()
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
            <asp:Label runat="server" ID="lblPesel" Text="Pesel:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPesel" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    
    

             <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblGender" Text="Płeć:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:DropDownList runat="server" ID="ddlGender" CssClass="w3-select w3-border"></asp:DropDownList>
        </div>
    </div>

    
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFieldNumber" Text="Numer pola:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:DropDownList runat="server" ID="ddlFieldNumber" CssClass="w3-select w3-border"></asp:DropDownList>
        </div>
    </div>
    
        <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblGraveNumber" Text="Numer alejki:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:DropDownList runat="server" ID="ddlGraveNumber" CssClass="w3-select w3-border"></asp:DropDownList>
        </div>
    </div>
    

    
     <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFuneralDate" Text="Data pogrzebu:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtFuneralDate" CssClass="w3-input w3-round-large" />
        </div>
    </div>


     <!-- buttony -->
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
