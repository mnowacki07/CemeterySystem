<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="DashboardZarzadca.aspx.cs" Inherits="CemeterySystem.Pages.DashboardZarzadca" %>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

<!-- ZAWARTOŚĆ STRONY START -->

  <!-- Pogrzeby -->
   <div class="w3-container" style="margin-top:80px" id="pogrzeby">
    <h1 class="w3-xxxlarge w3-text-dark-grey"> <a href="/Pages/FuneralsList" style="text-decoration:none;"><b>Pogrzeby.</b> </a></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>
  
  <!-- zdjecie pogrzeby-->
  <div class="w3-container">
    <div class="w3-container">
    <a href="/Pages/FuneralsList">  <img src="/photos/8.jpg" style="width:100%" OnClick="Button1_Click" alt="Pogrzeby"> </a>
     </div>  
  </div>

  <!-- Osoby zmarłe -->
  <div class="w3-container" id="osoby_zmarle" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-red w3-text-dark-grey"><a href="/Pages/DeadPersonsList" style="text-decoration:none;"><b>Osoby zmarłe.</b></a></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>
    
    <!-- zdjecie osoby zmarle -->
  <div class="w3-container">
    <div class="w3-container">
   <a href="/Pages/DeadPersonsList">   <img src="/photos/1.jpg" style="width:100%" OnClick="Button1_Click" alt="Osoby zmarłe"> </a>
     </div>  
  </div>
  
  <!-- Miejsca pochówku -->
  <div class="w3-container" id="miejsca_pochowku" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey">
        <a href="/Pages/BurialPlacesList" style="text-decoration:none;"><b>Miejsca pochówku.</b></a>
    </h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>
     
   <!-- zdjęcie miejsce pochowku -->
  <div class="w3-container">
    <div class="w3-container">
    <a href="/Pages/BurialPlacesList">   
        <img src="/photos/5.jpg" style="width:100%" OnClick="Button1_Click" alt="Miejsca pochówku"> 
    </a>
    </div>  
  </div>


  <!-- Rezerwacje -->
  <div class="w3-container" id="rezerwacje" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey">
        <a href="/Pages/DashboardZarzadca" style="text-decoration:none;">
            <b>Rezerwacje.</b>
        </a>
    </h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
   </div>

  <div class="w3-container">
    <div class="w3-container">
          <a href="/Pages/DashboardZarzadca">  
              <img src="/photos/10.jpg" style="width:100%" OnClick="Button1_Click" alt="Rezerwacje"> 
          </a>
     </div>  
  </div>

  <!-- Zaklady pogrzebowe -->
  <div class="w3-container" id="zaklady_pogrzebowe" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey">
       <a href="/Pages/FuneralCompanyList" style="text-decoration:none;">
        <b>Zakłady pogrzebowe.</b>
        </a>
    </h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
   </div>

  <div class="w3-container">
    <div class="w3-container">
         <a href="/Pages/FuneralCompanyList" style="text-decoration:none;">
            <img src="/photos/4.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
         </a>
     </div>  
  </div>

  <!-- Opłaty -->
  <div class="w3-container" id="oplaty" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey">
     <a href="/Pages/PaymentClassList" style="text-decoration:none;">
        <b>Ustawienia opłat.</b>
    </a>
    </h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
    </div>

  <div class="w3-container">
    <div class="w3-container">
      <a href="/Pages/PaymentClassList" style="text-decoration:none;">
      <img src="/photos/11.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
      </a>
     </div>  
  </div>

  <!-- Opiekunowie -->
  <div class="w3-container" id="opiekunowie" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey">
       <a href="/Pages/DashboardZarzadca" style="text-decoration:none;">
        <b>Opiekunowie miejsc pogrzebania.</b>
       </a>
    </h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>

  <div class="w3-container">
    <div class="w3-container">
        <a href="/Pages/DashboardZarzadca" style="text-decoration:none;">
         <img src="/photos/7.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
         </a>
     </div>  
  </div>
  
  
  <!-- Dodatkowe informacje -->
  <div class="w3-container" id="Dodatkowe informacje" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Dodatkowe informacje.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi aut ipsam itaque quia voluptates laborum provident sed molestiae illum. Maiores?</p>
      
      <div class="w3-section">
        <label>Imię</label>
        <input class="w3-input w3-border" type="text" name="Name" required>
      </div>
      <div class="w3-section">
        <label>Email</label>
        <input class="w3-input w3-border" type="text" name="Email" required>
      </div>
      <div class="w3-section">
        <label>Widomość</label>
        <input class="w3-input w3-border" type="text" name="Message" required>
      </div>
      
          <asp:Button ID="Button1" runat="server" Text="Button" type="submit" class="w3-button w3-block w3-padding-large w3-red w3-margin-bottom" Height="54px" />
     
      
  </div>

    </asp:Content>  