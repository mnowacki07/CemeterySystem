﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="FuneralsDetails.aspx.cs" Inherits="CemeterySystem.Pages.FuneralsDetails" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

    <div class="w3-container" style="margin-top: 80px; padding-bottom: 20px;" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Pogrzeby</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
     
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

    

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFuneralCompany" Text="Zakład Pogrzebowy:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:DropDownList runat="server" ID="ddlFuneralCompany" CssClass="w3-select w3-border"></asp:DropDownList>
        </div>
    </div>  
         <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblStaffPerson" Text="Osoba prowadząca ceremonię:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:DropDownList runat="server" ID="ddlStaffPerson" CssClass="w3-select w3-border"></asp:DropDownList>
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