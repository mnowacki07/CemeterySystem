<%@ Page Language="C#" MasterPageFile="~/Pages/FamilyMemberMaster.Master" AutoEventWireup="true" CodeBehind="FamilyMemberDeadPersonsList.aspx.cs" Inherits="CemeterySystem.Pages.FamilyMemberDeadPersonsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Podlegające osoby zmarłe</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-dead-perosons').DataTable({
                language: jQueryDataTableTranslations,
                columnDefs: [
                    { "type": "de_date", targets: 5 }
                ]
            });
            generateFooterFilters(jQuery('#table-dead-perosons'));
        });
    </script>

    <div class="table-wrapper">
        <table id="table-dead-perosons" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th>Imię</th>
                    <th>Nazwisko</th>
                    <th>PESEL</th>
                    <th>Miejsce pochówku</th>
                    <th>Data pogrzebu</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>Imię</th>
                    <th>Nazwisko</th>
                    <th>PESEL</th>
                    <th>Miejsce pochówku</th>
                    <th>Data pogrzebu</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repDeadPersons">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/FamilyMemberDeadPerson.aspx?FamilyMemberDeadPersonID=<%# Eval("DeadPersonID") %>">Pokaż</a>
                            </td>
                            <td><%# Eval("FirstName") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><%# Eval("PESEL") %></td>
                            <td><%# Eval("BurialPlace.FieldNumber") + " / " + Eval("BurialPlace.GraveNumber") %></td>
                            <td><%# Eval("Funeral.FuneralDate", "{0:dd.MM.yyyy}") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>        
    </div>
</asp:Content>
