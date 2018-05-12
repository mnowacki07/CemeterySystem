<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="DeadPersonsDetails.aspx.cs" Inherits="CemeterySystem.Pages.DeadPersonsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Osoby zmarłe</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>


   <!-- Tutaj kod tabelki -->


     <!-- buttony -->
     <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 10px;">
            <a runat="server" id="lbtnGoBack" onserverclick="lbtnGoBack_ServerClick" class="w3-button w3-blue w3-round-large" style="float: left; margin-right: 10px;">
                <i class="fa fa-arrow-left"></i>&nbsp;Powrót
            </a>

        </div>
    </div>
</asp:Content>
