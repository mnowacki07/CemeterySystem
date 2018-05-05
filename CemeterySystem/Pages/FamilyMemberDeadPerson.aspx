<%@ Page Language="C#" MasterPageFile="~/Pages/FamilyMemberMaster.Master" AutoEventWireup="true" CodeBehind="FamilyMemberDeadPerson.aspx.cs" Inherits="CemeterySystem.Pages.FamilyMemberDeadPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Podlegająca osoba zmarła</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <h3>Dane podstawowe</h3>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFirstName" Text="Imię:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtFirstName" CssClass="w3-input w3-round-large" Enabled="false" />
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblLastName" Text="Nazwisko:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtLastName" CssClass="w3-input w3-round-large" Enabled="false" />
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPESEL" Text="PESEL:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPESEL" CssClass="w3-input w3-round-large" Enabled="false" />
        </div>
    </div>

    <h3>Miejsce pochówku</h3>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblBurialPlaceFieldNumber" Text="Numer pola:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtBurialPlaceFieldNumber" CssClass="w3-input w3-round-large" Enabled="false" />
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblBurialPlaceGraveNumber" Text="Numer grobu:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtBurialPlaceGraveNumber" CssClass="w3-input w3-round-large" Enabled="false" />
        </div>
    </div>

    <h3>Pogrzeb</h3>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFuneralDate" Text="Data pogrzebu:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:TextBox runat="server" ID="txtFuneralDate" CssClass="w3-input w3-round-large" Enabled="false" />
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFuneralCompany" Text="Firma pogrzebowa:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:TextBox runat="server" ID="txtFuneralCompany" CssClass="w3-input w3-round-large" Enabled="false" />
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblFuneralStaffPerson" Text="Osoba nadzorująca:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12">
            <asp:TextBox runat="server" ID="txtFuneralStaffPerson" CssClass="w3-input w3-round-large" Enabled="false" />
        </div>
    </div>

</asp:Content>
