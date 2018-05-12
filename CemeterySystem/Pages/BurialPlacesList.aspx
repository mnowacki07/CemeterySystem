<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="BurialPlacesList.aspx.cs" Inherits="CemeterySystem.Pages.BurialPlacesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Miejsca pogrzebania</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-burial-places').DataTable({
                language: jQueryDataTableTranslations,
                columnDefs: [
                    { "type": "de_date", targets: 6 }
                ]
            });
            generateFooterFilters(jQuery('#table-burial-places'));
        });
    </script>

    <div class="table-wrapper">
        <table id="table-burial-places" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th>Numer pola</th>
                    <th>Numer miejsca</th>
                    <th>Klasa opłaty</th>
                    <th>Osoba zmarła</th>
                    <th>Opiekun grobu</th>
                    <th>Termin płatności</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>Numer pola</th>
                    <th>Numer miejsca</th>
                    <th>Klasa opłaty</th>
                    <th>Osoba zmarła</th>
                    <th>Opiekun grobu</th>
                    <th>Termin płatności</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repBurialPlace">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/BurialPlacesDetails.aspx?BurialPlaceID=<%# Eval("BurialPlace.BurialPlaceID") %>">Pokaż</a>
                            </td>
                            <td><%# Eval("BurialPlace.FieldNumber") %></td>
                            <td><%# Eval("BurialPlace.GraveNumber") %></td>
                            <td><%# Eval("BurialPlace.PaymentClassNameFormatted") %></td>
                            <td><%# Eval("DeadPersonAnchor") %></td>
                            <td><%# Eval("FamilyMemberAnchor") %></td>
                            <td><%# Eval("BurialPlace.PaymentDateFormatted") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 20px;">
                <a href="/Pages/BurialPlacesDetails.aspx?IsCreateMode=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>
    </div>

</asp:Content>
