<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/FamilyMemberMaster.Master" CodeBehind="BookedServiceList.aspx.cs" Inherits="CemeterySystem.Pages.BookedServiceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Usługi</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <style>
        #table-services .dt-row-selected, #table-services .dt-row-selected td,
        #table-booked-services .dt-row-selected, #table-booked-services .dt-row-selected td{
            background-color: #4ca3bf !important;
        }
    </style>

    <script>        
        jQuery(document).ready(function () {
            var tableBookedServices = jQuery('#table-booked-services').DataTable({
                language: jQueryDataTableTranslations
            });
            generateFooterFilters(jQuery('#table-booked-services'));

            var tableServices = jQuery('#table-services').DataTable({
                language: jQueryDataTableTranslations
            });
            generateFooterFilters(jQuery('#table-services'));

            jQuery('#table-services tbody').on('click', 'tr', function () {
                if (jQuery(this).hasClass('dt-row-selected')) {
                    jQuery(this).removeClass('dt-row-selected');
                }
                else {
                    tableServices.$('tr.dt-row-selected').removeClass('dt-row-selected');
                    jQuery(this).addClass('dt-row-selected');
                }

                jQuery('#<%= btnBookService.ClientID %>').prop('disabled', false);
                jQuery('#<%= hfServiceID.ClientID %>').val(jQuery(this).attr('data-s-id'));
            });

            jQuery('#table-booked-services tbody').on('click', 'tr', function () {
                if (jQuery(this).hasClass('dt-row-selected')) {
                    jQuery(this).removeClass('dt-row-selected');
                }
                else {
                    tableBookedServices.$('tr.dt-row-selected').removeClass('dt-row-selected');
                    jQuery(this).addClass('dt-row-selected');
                }

                var isPaid = jQuery(this).attr('data-is-paid').toLowerCase() == 'true';
                var isFinished = jQuery(this).attr('data-is-finished').toLowerCase() == 'true';

                jQuery('#<%= btnCancelBookedService.ClientID %>').prop('disabled', isPaid || isFinished);
                jQuery('#<%= btnPayForService.ClientID %>').prop('disabled', isPaid || isFinished);
                jQuery('#<%= hfBookedServiceID.ClientID %>').val(jQuery(this).attr('data-b-s-id'));
            });
        });

        function showServiceList() {
            jQuery('#btnShowServiceList').hide();
            jQuery('#<%= btnBookService.ClientID %>').show();
            jQuery('#table-services-wrapper').show();
        }
    </script>

    <div class="table-wrapper">
        <h2>Wykupione usługi</h2>
        <table id="table-booked-services" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th>Nazwa</th>
                    <th>Opis</th>
                    <th>Cena</th>
                    <th>Zmarły</th>
                    <th>Zapłacono</th>
                    <th>Wykonano</th>
                    <th>Data zlecenia</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Nazwa</th>
                    <th>Opis</th>
                    <th>Cena</th>
                    <th>Zmarły</th>
                    <th>Zapłacono</th>
                    <th>Wykonano</th>
                    <th>Data zlecenia</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repBookedServices">
                    <ItemTemplate>
                        <tr data-b-s-id="<%# Eval("BookedService.BookedServiceID") %>" data-is-paid="<%# Eval("BookedService.IsPaid") %>" data-is-finished="<%# Eval("BookedService.IsFinished") %>">
                            <td><%# Eval("BookedService.Name") %></td>
                            <td><%# Eval("BookedService.Description") %></td>
                            <td><%# Eval("BookedService.PriceGrossFormatted") %></td>
                            <td><%# Eval("DeadPersonNameFormatted") %></td>
                            <td><%# Eval("IsPaidFormatted") %></td>
                            <td><%# Eval("IsFinishedFormatted") %></td>
                            <td><%# Eval("BookedService.CreationDateTimeFormatted") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

    <div id="table-services-wrapper" class="table-wrapper" style="display: none;">
        <h2>Wybierz usługę</h2>
        <table id="table-services" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th>Nazwa</th>
                    <th>Opis</th>
                    <th>Cena</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Nazwa</th>
                    <th>Opis</th>
                    <th>Cena</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repServices">
                    <ItemTemplate>
                        <tr data-s-id="<%# Eval("ServiceID") %>">
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Description") %></td>
                            <td><%# Eval("PriceGrossFormatted") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <div class="w3-row" style="background-color: #FFFFFF;">
            <div class="w3-col m12" style="padding-top: 15px; padding-bottom: 15px;">
                <asp:Label runat="server" ID="lblDeadPerson" Text="Osoba zmarła:" />
            </div>
        </div>

        <div class="w3-row" style="background-color: #FFFFFF;">
            <div class="w3-col m12" style="padding-top: 0; padding-bottom: 0;">
                <asp:DropDownList runat="server" ID="ddlDeadPerson" CssClass="w3-select" />
            </div>
        </div>
    </div>

    <div class="w3-row" style="background-color: #FFFFFF;">
        <div class="w3-col m12" style="padding: 15px;">
            <button type="button" id="btnShowServiceList" class="w3-button w3-green w3-round-large" style="float: right;" onclick="showServiceList()">
                <i class="fa fa-check"></i>&nbsp;Zamów usługę
            </button>
            <asp:HiddenField runat="server" ID="hfServiceID" Value="" />
            <asp:HiddenField runat="server" ID="hfBookedServiceID" Value="" />

            <button type="submit" runat="server" id="btnCancelBookedService" onserverclick="btnCancelBookedService_ServerClick" class="w3-button w3-red w3-round-large" style="float: left; margin-right: 10px;" disabled="disabled">
                <i class="fas fa-times"></i>&nbsp;Anuluj wykonanie usługi
            </button>

            <button type="submit" runat="server" id="btnPayForService" onserverclick="btnPayForService_ServerClick" class="w3-button w3-blue w3-round-large" style="float: left;" disabled="disabled">
                <i class="fa fa-dollar-sign"></i>&nbsp;Zapłać za usługę
            </button>

            <button type="submit" runat="server" id="btnBookService" onserverclick="btnBookService_ServerClick" class="w3-button w3-green w3-round-large" style="float: right; display: none;" disabled="disabled">
                <i class="fa fa-check"></i>&nbsp;Zamów usługę
            </button>
        </div>
    </div>

</asp:Content>
