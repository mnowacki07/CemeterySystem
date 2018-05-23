<%@ Page Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="CemeterySystem.Pages.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Użytkownik</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <script>
        jQuery(document).ready(function () {
            jQuery('#<%= txtPassword.ClientID %>').val('');
            jQuery('#<%= txtPasswordRepeated.ClientID %>').val('');
            ddlRoleOnChange();
            <% if (this.IsCreateMode) { %> 
            jQuery('#<%= ddlRole.ClientID %>').on('change', ddlRoleOnChange);
            <% } else { %>
            jQuery('#<%= txtPasswordRepeated.ClientID %>').on('keyup', function () {
                jQuery('#<%= txtPassword.ClientID %>').valid();
            });
            <% } %>

            jQuery.validator.addMethod("familyMemberRequired", function (value, element) {
                let isFamilyMemberSelected = jQuery('#<%= ddlRole.ClientID %>').val() === '<%= CemeterySystem.Repositories.UserRoleRepository.FAMILY_MEMBER_ROLE_ID %>';
                return isFamilyMemberSelected ? value.trim() !== '' : true;
            });

            jQuery.validator.addMethod("passwordValidatorRequired", function (value, element) {
                let password = jQuery("#<%= txtPassword.ClientID %>").val().trim();
                let passwordRepeated = jQuery("#<%= txtPasswordRepeated.ClientID %>").val().trim();
                return (password === "" && passwordRepeated === "") || (password !== "" && passwordRepeated !== "");
            });

            jQuery.validator.addMethod("passwordValidatorMinLength", function (value, element) {
                let password = jQuery("#<%= txtPassword.ClientID %>").val().trim();
                let passwordRepeated = jQuery("#<%= txtPasswordRepeated.ClientID %>").val().trim();

                if (password === "" && passwordRepeated === "") {
                    return true;
                }
                else {
                    return value.trim().length >= 6;
                }
            });

            jQuery.validator.addMethod("passwordValidatorEqualsTo", function (value, element) {
                let password = jQuery("#<%= txtPassword.ClientID %>").val().trim();
                let passwordRepeated = jQuery("#<%= txtPasswordRepeated.ClientID %>").val().trim();

                if (password === "" && passwordRepeated === "") {
                    return true;
                }
                else {                    
                    return password === passwordRepeated;
                }
            });

            jQuery("#form1").validate({
                rules: {
                    "<%= txtUsername.UniqueID %>": {
                        required: true
                    },
                    "<%= txtEmail.UniqueID %>": {
                        required: true,
                        email: true
                    },
                    <% if(this.IsCreateMode) { %> 
                    "<%= txtPassword.UniqueID %>": {
                        required: true,
                        minlength: 6
                    },
                    "<%= txtPasswordRepeated.UniqueID %>": {
                        required: true,
                        equalTo: "#<%= txtPassword.ClientID %>"
                    },
                    <% } else { %>
                    "<%= txtPassword.UniqueID %>": {
                        passwordValidatorRequired: true,
                        passwordValidatorMinLength: 6
                    },
                    "<%= txtPasswordRepeated.UniqueID %>": {                        
                        passwordValidatorEqualsTo: true
                    },
                    <% } %>   
                    "<%= txtFirstName.UniqueID %>": {
                        familyMemberRequired: true
                    },
                    "<%= txtLastName.UniqueID %>": {
                        familyMemberRequired: true
                    },
                    "<%= txtRelationship.UniqueID %>": {
                        familyMemberRequired: true
                    },
                    "<%= txtStreet.UniqueID %>": {
                        familyMemberRequired: true
                    },
                    "<%= txtHouseNumber.UniqueID %>": {
                        familyMemberRequired: true
                    },
                    "<%= txtTown.UniqueID %>": {
                        familyMemberRequired: true
                    },
                    "<%= txtPostCode.UniqueID %>": {
                        familyMemberRequired: true
                    }
                },
                messages: {
                    "<%= txtUsername.UniqueID %>": { required: "Proszę wpisać nazwę użytkownika" },
                    "<%= txtEmail.UniqueID %>": {
                        required: "Proszę wpisać adres e-mail",
                        email: "Adres e-mail jest nieprawidłowy"
                    },
                    <% if(this.IsCreateMode) { %> 
                    "<%= txtPassword.UniqueID %>": {
                        required: "Proszę wpisać hasło",
                        minlength: "Hasło musi zawierać conajmniej 6 znaków"
                    },
                    "<%= txtPasswordRepeated.UniqueID %>": {
                        required: "Proszę powtórzyć hasło",
                        equalTo: "Hasła muszą być takie same"
                    },
                    <% } else { %>
                    "<%= txtPassword.UniqueID %>": {
                        passwordValidatorRequired: "Proszę podać hasło i je potwierdzić lub zostawić oba pola puste",
                        passwordValidatorMinLength: "Hasło musi zawierać conajmniej 6 znaków"
                    },
                    "<%= txtPasswordRepeated.UniqueID %>": {                        
                        passwordValidatorEqualsTo: "Hasła muszą być takie same"
                    },
                    <% } %>        
                    "<%= txtFirstName.UniqueID %>": {
                        familyMemberRequired: "Proszę wpisać imię"
                    },
                    "<%= txtLastName.UniqueID %>": {
                        familyMemberRequired: "Proszę wpisać nazwisko"
                    },
                    "<%= txtRelationship.UniqueID %>": {
                        familyMemberRequired: "Proszę wpisać stopień pokrewieństwa"
                    },
                    "<%= txtStreet.UniqueID %>": {
                        familyMemberRequired: "Proszę wpisać ulicę"
                    },
                    "<%= txtHouseNumber.UniqueID %>": {
                        familyMemberRequired: "Proszę wpisać numer domu"
                    },
                    "<%= txtTown.UniqueID %>": {
                        familyMemberRequired: "Proszę wpisać miejscowość"
                    },
                    "<%= txtPostCode.UniqueID %>": {
                        familyMemberRequired: "Proszę wpisać kod pocztowy"
                    }
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
        });

        function ddlRoleOnChange() {
            let value = jQuery('#<%= ddlRole.ClientID %>').val();
            if (value !== '<%= CemeterySystem.Repositories.UserRoleRepository.FAMILY_MEMBER_ROLE_ID %>') {
                jQuery('#familyMemberData').hide();
            }
            else {
                jQuery('#familyMemberData').show();
            }
        }

        function validateForm() {
            jQuery("#form1").validate();
            return jQuery("#form1").valid()
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
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="w3-input w3-round-large" />
        </div>
    </div>

    <div class="w3-row" style="padding-bottom: 5px;">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPasswordRepeated" Text="Powtórz hasło:" />
        </div>
    </div>
    <div class="w3-row" style="padding-bottom: 10px;">
        <div class="w3-col m12">
            <asp:TextBox runat="server" ID="txtPasswordRepeated" TextMode="Password" CssClass="w3-input w3-round-large" />
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