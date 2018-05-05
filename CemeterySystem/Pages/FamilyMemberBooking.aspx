<%@ Page Language="C#" MasterPageFile="~/Pages/FamilyMemberMaster.Master" AutoEventWireup="true" CodeBehind="FamilyMemberBooking.aspx.cs" Inherits="CemeterySystem.Pages.FamilyMemberBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Rezerwacja miejsca pochówku</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <div runat="server" id="divBurialPlace">
        <h3>Twoja rezerwacja</h3>
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

        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 10px;">
                <asp:Button runat="server" ID="btnCancelBooking" CssClass="w3-button w3-red w3-round-large" Style="float: right;" Text="Anuluj rezerwacje" OnClick="btnCancelBooking_Click" />
            </div>
        </div>
    </div>

    <div runat="server" id="divBurialPlaceList">
        <style>
            #table-burial-places .dt-row-selected, #table-burial-places .dt-row-selected td {
                background-color: #4ca3bf !important;
            }
        </style>

        <script>        
            jQuery(document).ready(function () {
                var burialPlacesTable = jQuery('#table-burial-places').DataTable({
                    language: jQueryDataTableTranslations
                });
                generateFooterFilters(jQuery('#table-burial-places'));

                jQuery('#table-burial-places tbody').on('click', 'tr', function () {
                    if (jQuery(this).hasClass('dt-row-selected')) {
                        jQuery(this).removeClass('dt-row-selected');
                    }
                    else {
                        burialPlacesTable.$('tr.dt-row-selected').removeClass('dt-row-selected');
                        jQuery(this).addClass('dt-row-selected');
                    }

                    jQuery('#<%= btnCreateBooking.ClientID %>').prop('disabled', false);
                    jQuery('#<%= hfBurialPlaceID.ClientID %>').val(jQuery(this).attr('data-bp-id'));
                });
            });
        </script>

        <div class="table-wrapper">
            <h3>Proszę wybrać miejsce pochówku</h3>
            <table id="table-burial-places" class="display" style="width: 100%">
                <thead>
                    <tr>
                        <th>Numer pola</th>
                        <th>Numer miejsca</th>
                        <th>Klasa opłaty</th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <th>Numer pola</th>
                        <th>Numer miejsca</th>
                        <th>Klasa opłaty</th>
                    </tr>
                </tfoot>
                <tbody>
                    <asp:Repeater runat="server" ID="repBurialPlace">
                        <ItemTemplate>
                            <tr data-bp-id="<%# Eval("BurialPlaceID") %>">
                                <td><%# Eval("FieldNumber") %></td>
                                <td><%# Eval("GraveNumber") %></td>
                                <td><%# Eval("PaymentClassNameFormatted") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="w3-row">
                <div class="w3-col m12">
                    <asp:HiddenField runat="server" ID="hfBurialPlaceID" Value="" />
                    <asp:Button runat="server" ID="btnCreateBooking" CssClass="w3-button w3-green w3-round-large" Style="float: right;" OnClick="btnCreateBooking_Click" Text="Rezerwuj" Enabled="false" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
