<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="CemeteryStaffPersonList.aspx.cs" Inherits="CemeterySystem.Pages.CemeteryStaffPersonList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Personel cmentarza</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-cemetery-staff-person').DataTable({
                language: jQueryDataTableTranslations
            });
            generateFooterFilters(jQuery('#table-cemetery-staff-person'));
        });
    </script>

    <div class="table-wrapper">
        <table id="table-cemetery-staff-person" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th>Imię</th>
                    <th>Nazwisko</th>
                    <th>Pozycja</th>
                    <th>PESEL</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>imię</th>
                    <th>nazwisko</th>
                    <th>pozycja</th>
                    <th>PESEL</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repCemetereyStaffPerson">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/CemeteryStaffPersonDetails.aspx?CemeteryStaffPersonID=<%# Eval("CemeteryStaffPersonID") %>">Pokaż</a>
                            </td>
                            <td><%# Eval("FirstName") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><%# Eval("Position") %></td>
                            <td><%# Eval("PESEL") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 20px;">
                <a href="/Pages/CemeteryStaffPersonDetails.aspx?IsCreateMode=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>
    </div>
</asp:Content>