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
    <a href="/Pages/FuneralsList">  <img src="/Content/img/8.jpg" style="width:100%" OnClick="Button1_Click" alt="Pogrzeby"> </a>
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
   <a href="/Pages/DeadPersonsList">   <img src="/Content/img/1.jpg" style="width:100%" OnClick="Button1_Click" alt="Osoby zmarłe"> </a>
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
        <img src="/Content/img/5.jpg" style="width:100%" OnClick="Button1_Click" alt="Miejsca pochówku"> 
    </a>
    </div>  
  </div>


  <!-- Personel cmentarza -->
  <div class="w3-container" id="personel" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey">
        <a href="/Pages/CemeteryStaffPersonList" style="text-decoration:none;">
            <b>Personel cmentarza.</b>
        </a>
    </h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
   </div>

  <div class="w3-container">
    <div class="w3-container">
          <a href="/Pages/CemeteryStaffPersonList">  
              <img src="/Content/img/12.jpg" style="width:100%" OnClick="Button1_Click" alt="Rezerwacje"> 
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
            <img src="/Content/img/4.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
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
      <img src="/Content/img/11.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
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
         <img src="/Content/img/7.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
         </a>
     </div>  
  </div>
  
  
  <!-- Dodatkowe informacje -->
  <div class="w3-container" id="Dodatkowe informacje" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Dodatkowe informacje.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
    <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, 
        eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. 
        Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni 
        dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor 
        sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam 
        quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid
        ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur,
        vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?

    </p>
      
    
      
  </div>

    </asp:Content>  