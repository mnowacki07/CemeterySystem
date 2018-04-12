<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="DashboardZarzadca.aspx.cs" Inherits="CemeterySystem.Pages.DashboardZarzadca" %>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

<!-- ZAWARTOŚĆ STRONY START -->
   <div class="w3-container" style="margin-top:80px" id="pogrzeby">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Pogrzeby.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>
  
  <!-- Icon grid -->
  <div class="w3-container">
    <div class="w3-container">
      <img src="/photos/8.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
     </div>  
  </div>

  <!-- Osoby zmarłe -->
  <div class="w3-container" id="osoby_zmarle" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-red w3-text-dark-grey"><b>Osoby zmarłe.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>
    
  <!-- Icon grid -->
  <div class="w3-container">
    <div class="w3-container">
      <img src="/photos/1.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
     </div>  
  </div>
  
  <!-- Miejsca pochówku -->
  <div class="w3-container" id="miejsca_pochowku" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Miejsca pochówku.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>
       <!-- Icon grid -->
 
  <div class="w3-container">
    <div class="w3-container">
      <img src="/photos/5.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
     </div>  
  </div>


  <!-- Rezerwacje -->
  <div class="w3-container" id="rezerwacje" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Rezerwacje.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>

  <div class="w3-container">
    <div class="w3-container">
      <img src="/photos/10.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
     </div>  
  </div>

  <!-- Zaklady pogrzebowe -->
  <div class="w3-container" id="zaklady_pogrzebowe" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Zakłady pogrzebowe.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>

  <div class="w3-container">
    <div class="w3-container">
      <img src="/photos/4.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
     </div>  
  </div>

  <!-- Opłaty -->
  <div class="w3-container" id="oplaty" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Ustawienia opłat.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>

  <div class="w3-container">
    <div class="w3-container">
      <img src="/photos/11.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
     </div>  
  </div>

  <!-- Opiekunowie -->
  <div class="w3-container" id="opiekunowie" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Opiekunowie miejsc pogrzebania.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>

  <div class="w3-container">
    <div class="w3-container">
      <img src="/photos/7.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
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