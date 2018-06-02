<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="DeadPersonsList.aspx.cs" Inherits="CemeterySystem.Pages.DeadPersonsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Osoby zmarłe</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>


   <!-- Tutaj kod tabelki -->
        <script>        
        jQuery(document).ready(function () {
            jQuery('#table-deadperson').DataTable({
                language: jQueryDataTableTranslations,
                columnDefs: [
                    { "type": "de_date", targets: 5 }
                ]
            });
            generateFooterFilters(jQuery('#table-deadperson'));
        });
    </script>
        <div class="table-wrapper">
        <table id="table-deadperson" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th style="max-width: 300px;">Zmarły</th>
                    <th>Płeć</th>
                    <th>Pesel</th>
                    <th>Numer pola</th>
                    <th>Data pogrzebu</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>Zmarły</th>
                    <th>Płeć</th>
                    <th>Pesel</th>
                    <th>Numer pola</th>
                    <th>Data pogrzebu</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repDeadPerson">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/DeadPersonsDetails?DeadPersonID=<%# Eval("DeadPerson.DeadPersonID") %>">Pokaż</a>                                
                            </td>
                            <td><%# Eval("DeadPerson.NameFormatted") %></td>
                            <td><%# Eval("DeadPerson.GenderFormatted") %></td>
                            <td><%# Eval("DeadPerson.Pesel") %></td>
                            <td><%# Eval("DeadPerson.BurialPlace.FieldNumber") %></td>
                            <td><%# Eval("DeadPerson.Funeral.FuneralShortDateFormatted") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 20px;">
                <a href="/Pages/DeadPersonsDetails.aspx?IsCreateMode=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>        
    </div>

</asp:Content>
