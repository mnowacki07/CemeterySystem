<%@ Page Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="CemeterySystem.Pages.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Użytkownik</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <script>
        jQuery(document).ready(function () {
            ddlRoleOnChange();
            jQuery('#<%= ddlRole.ClientID %>').on('change', ddlRoleOnChange);
        });

        function ddlRoleOnChange() {
            let value = jQuery('#<%= ddlRole.ClientID %>').val();
            if (value == '<%= CemeterySystem.Repositories.UserRoleRepository.MANAGER_ROLE_ID %>') {
                jQuery('#familyMemberData').hide();
            }
            else {
                jQuery('#familyMemberData').show();
            }
        }
    </script>

    <div class="w3-row" style="padding-bottom: 5px;">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblUsername" Text="Nazwa użytkownika:" />
        </div>
    </div>
    <div class="w3-row" style="padding-bottom: 10px;">
        <div class="w3-col m12">
            <asp:TextBox runat="server" ID="txtUsername" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    <div class="w3-row" style="padding-bottom: 5px;">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblEmail" Text="E-mail:" />
        </div>
    </div>
    <div class="w3-row" style="padding-bottom: 10px;">
        <div class="w3-col m12">
            <asp:TextBox runat="server" ID="txtEmail" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    <div class="w3-row" style="padding-bottom: 5px;">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPassword" Text="Hasło:" />
        </div>
    </div>
    <div class="w3-row" style="padding-bottom: 10px;">
        <div class="w3-col m12">
            <asp:TextBox runat="server" ID="txtPassword" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    <div class="w3-row" style="padding-bottom: 5px;">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPasswordRepeated" Text="Powtórz hasło:" />
        </div>
    </div>
    <div class="w3-row" style="padding-bottom: 10px;">
        <div class="w3-col m12">
            <asp:TextBox runat="server" ID="txtPasswordRepeated" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    <div class="w3-row" style="padding-bottom: 5px;">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblRole" Text="Rola:" />
        </div>
    </div>
    <div class="w3-row" style="padding-bottom: 10px;">
        <div class="w3-col m12">
            <asp:DropDownList runat="server" ID="ddlRole" CssClass="w3-select"></asp:DropDownList>
        </div>
    </div>

    <div id="familyMemberData">
        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblFirstName" Text="Imię:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="w3-input w3-round-large" />
            </div>
        </div>

        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblLastName" Text="Nazwisko:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="w3-input w3-round-large" />
            </div>
        </div>

        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblRelationship" Text="Pokrewieństwo:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtRelationship" CssClass="w3-input w3-round-large" />
            </div>
        </div>

        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblPhoneNumber" Text="Numer telefonu:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="w3-input w3-round-large" />
            </div>
        </div>

        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblStreet" Text="Ulica:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtStreet" CssClass="w3-input w3-round-large" />
            </div>
        </div>

        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblHouseNumber" Text="Numer domu:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtHouseNumber" CssClass="w3-input w3-round-large" />
            </div>
        </div>

        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblFlatNumber" Text="Numer mieszkania:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtFlatNumber" CssClass="w3-input w3-round-large" />
            </div>
        </div>

        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblTown" Text="Miejscowość:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtTown" CssClass="w3-input w3-round-large" />
            </div>
        </div>

        <div class="w3-row" style="padding-bottom: 5px;">
            <div class="w3-col m12">
                <asp:Label runat="server" ID="lblPostCode" Text="Kod pocztowy:" />
            </div>
        </div>
        <div class="w3-row" style="padding-bottom: 10px;">
            <div class="w3-col m12">
                <asp:TextBox runat="server" ID="txtPostCode" CssClass="w3-input w3-round-large" />
            </div>
        </div>
    </div>


    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 20px;">
        </div>
    </div>

</asp:Content>
