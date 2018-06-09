<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CemeterySystem.Pages.LoginPage" MasterPageFile="~/Pages/LoginMasterPage.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  

      <div style="width: 100%; height: 100%; text-align: center; padding-top: 100px; padding-bottom: 100px;">
        <h1 class="w3-xxlarge w3-text-dark-grey ">Witamy w systemie wspomagającym pracę cmentarza.</h1>
          <br />
          <br />

        <h1 class="w3-xxlarge w3-text-magenda">Zaloguj się:</h1>
 

     <!-- Logowanie-->
   <div class="w3-container" style="margin-top:5px" id="login">
   <div style="width: 100%; padding: 13px;">
        <div class="row" style="padding-bottom: 8px;">
            <div class="w3-xlarge w3-text-dark-grey ">
                <asp:Label runat="server" ID="lblUsername" Text="Nazwa użytkownika:"  />
            </div>
        </div>
        <div class="row" style="padding-bottom: 8px;">
            <div class="w3-xlarge">
                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" style="text-align: center" />
            </div>
        </div>
        <div class="row" style="padding-bottom: 8px;">
            <div class="w3-xlarge w3-text-dark-grey">
                <asp:Label runat="server" ID="lblPassword" Text="Hasło:"  />
            </div>
        </div>
        <div class="row">
            <div class="w3-xlarge">
                 <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" style="text-align: center"/>
            </div>
        </div>
       <br />
        <div class="row">
            <div class="col-md-12" style="padding-top: 10px;">
                <button runat="server" id="btnSignIn" class="w3-button w3-grey w3-xxlarge  w3-round-xlarge" onserverclick="btnSignIn_ServerClick" >
                    <i class="fa fa-sign-in-alt"></i>&nbsp;zaloguj
                </button>
            </div>
        </div>
    </div>  
  </div>

 <br />
           <!-- zdjecie logowania-->
  <div class="w3-container">
    <div class="w3-container">
    <img src="/Content/img/10.jpg" style="width:100%" OnClick="Button1_Click" alt="photo"> 
     </div>  
  </div>


             </div>    
  



     
</asp:Content>  