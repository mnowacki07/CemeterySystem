<%@ Page Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="ServiceList.aspx.cs" Inherits="CemeterySystem.Pages.ServiceList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Usługi</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-services').DataTable({
                language: jQueryDataTableTranslations
            });
            generateFooterFilters(jQuery('#table-services'));
        });
    </script>

    <div class="table-wrapper">
        <table id="table-services" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th>Nazwa</th>
                    <th>Opis</th>
                    <th>Cena</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>nazwa</th>
                    <th>opis</th>
                    <th>cena</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repServices">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/ServiceDetails.aspx?ServiceID=<%# Eval("ServiceID") %>">Pokaż</a>
                            </td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Description") %></td>
                            <td><%# Eval("PriceGrossFormatted") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 20px;">
                <a href="/Pages/ServiceDetails.aspx?IsCreateMode=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>
    </div>
</asp:Content>