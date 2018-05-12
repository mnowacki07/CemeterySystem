<%@ Page Language="C#" MasterPageFile="~/Pages/FamilyMemberMaster.Master" AutoEventWireup="true" CodeBehind="DashboardFamilyMember.aspx.cs" Inherits="CemeterySystem.Pages.DashboardFamilyMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 100%; text-align: center; padding-top: 100px; padding-bottom: 100px;">
        <h1 style="font-size: 40px;">Witamy w systemie wspomagającym pracę cmentarza.</h1>
        <h3>Co chciałbyś zrobić?</h3>
    </div>    


     <!-- Rezerwacje -->
   <div class="w3-container" style="margin-top:80px" id="rezerwacje">
    <h1 class="w3-xxxlarge w3-text-dark-grey"> <a href="/Pages/FamilyMemberBooking" style="text-decoration:none;"><b>Rezerwacje</b> </a></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>
  
  <!-- zdjecie dla rezerwacje-->
  <div class="w3-container">
    <div class="w3-container">
    <a href="/Pages/FamilyMemberBooking">  <img src="/Content/img/10.jpg" style="width:100%" OnClick="Button1_Click" alt="Rezerwacje"> </a>
     </div>  
  </div>

  <!-- Podlegające Osoby zmarłe -->
  <div class="w3-container" id="podlegajace_osoby_zmarle" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-red w3-text-dark-grey"><a href="/Pages/FamilyMemberDeadPersonsList" style="text-decoration:none;"><b>Podlegające osoby zmarłe</b></a></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>
    
    <!-- zdjecie dla podlegające osoby zmarle -->
  <div class="w3-container">
    <div class="w3-container">
   <a href="/Pages/FamilyMemberDeadPersonsList">   <img src="/Content/img/9.jpg" style="width:100%" OnClick="Button1_Click" alt="Podlegające osoby zmarłe"> </a>
     </div>  
  </div>
  
  <!-- Opłaty -->
  <div class="w3-container" id="oplaty" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey">
        <a href="/Pages/FamilyMemberPayments" style="text-decoration:none;"><b>Opłaty</b></a>
    </h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>

       <!-- zdjęcie opłaty -->
  <div class="w3-container">
    <div class="w3-container">
    <a href="/Pages/FamilyMemberPayments">   
        <img src="/Content/img/11.jpg" style="width:100%" OnClick="Button1_Click" alt="Opłaty"> 
    </a>
    </div>  
  </div>

  <!-- Usługi -->
  <div class="w3-container" id="uslugi" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey">
        <a href="/Pages/BookedServiceList" style="text-decoration:none;"><b>Usługi</b></a>
    </h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>

       <!-- zdjęcie miejsce pochowku -->
  <div class="w3-container">
    <div class="w3-container">
    <a href="/Pages/BookedServiceList">   
        <img src="/Content/img/1.jpg" style="width:100%" OnClick="Button1_Click" alt="Usługi"> 
    </a>
    </div>  
  </div>



</asp:Content>