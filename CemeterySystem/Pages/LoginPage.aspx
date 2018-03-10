<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CemeterySystem.Pages.LoginPage" MasterPageFile="~/Pages/LoginMasterPage.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <div style="width: 100%; padding: 13px;">
        <div class="row" style="padding-bottom: 8px;">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblUsername" Text="Nazwa użytkownika:" style="font-size: 18px;" />
            </div>
        </div>
        <div class="row" style="padding-bottom: 8px;">
            <div class="col-md-12">
                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" />
            </div>
        </div>
        <div class="row" style="padding-bottom: 8px;">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblPassword" Text="Hasło:" style="font-size: 18px;" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                 <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="padding-top: 10px;">
                <button runat="server" id="btnSignIn" class="btn btn-primary btn-md" onserverclick="btnSignIn_ServerClick" style="width: 100%;">
                    <i class="fa fa-sign-in-alt"></i>&nbsp;Zaloguj
                </button>
            </div>
        </div>
    </div>    
</asp:Content>  