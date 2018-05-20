<%@ Page Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="CemeterySystem.Pages.UsersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Użytkownicy</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>
   
    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-users').DataTable({
                language: jQueryDataTableTranslations                
            });
            generateFooterFilters(jQuery('#table-users'));
        });
    </script>
        <div class="table-wrapper">
        <table id="table-users" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th>Nazwa użytkownika</th>
                    <th>Email</th>                    
                    <th>Imię</th>
                    <th>Nazwisko</th>
                    <th>Rola</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>Nazwa użytkownika</th>
                    <th>Email</th>                    
                    <th>Imię</th>
                    <th>Nazwisko</th>
                    <th>Rola</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repUsers">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/UserDetails?UserID=<%# Eval("Id") %>">Pokaż</a>                                
                            </td>
                            <td><%# Eval("UserName") %></td>
                            <td><%# Eval("Email") %></td>                            
                            <td><%# Eval("FamilyMember.FirstName") %></td>
                            <td><%# Eval("FamilyMember.LastName") %></td>
                            <td><%# Eval("RoleNameFormatted") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 20px;">
                <a href="/Pages/UserDetails.aspx?IsCreateMode=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>        
    </div>
</asp:Content>