<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/FamilyMemberMaster.Master" CodeBehind="FamilyMemberPaymentList.aspx.cs" Inherits="CemeterySystem.Pages.FamilyMemberPaymentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container" style="margin-top: 80px">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Opłaty</b></h1>
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">
    </div>

    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-payments').DataTable({
                language: jQueryDataTableTranslations
            });
            generateFooterFilters(jQuery('#table-payments'));
        });

        function processPayment(button) {
            jQuery('#<%= hfDeadPersonID.ClientID %>').val(jQuery(button).attr('data-d-p-id'));
            return true;
        }
    </script>

    <asp:HiddenField runat="server" ID="hfDeadPersonID" />

    <div class="table-wrapper">
        <table id="table-payments" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th>Osoba zmarła</th>
                    <th>Miejsce pochówku</th>
                    <th>Kwota opłaty</th>
                    <th>Termin płatności</th>
                    <th>Przedłużenie do</th>
                    <th>Przedłuż</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Osoba zmarła</th>
                    <th>Miejsce pochówku</th>
                    <th>Kwota opłaty</th>
                    <th>Termin płatności</th>
                    <th>Przedłużenie</th>
                    <th></th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repPayments">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("NameFormatted") %></td>
                            <td><%# Eval("BurialPlace.FieldNumber") + " / " + Eval("BurialPlace.GraveNumber") %></td>
                            <td><%# Eval("BurialPlace.PaymentClass.PriceFormatted") %></td>
                            <td><%# Eval("BurialPlace.PaymentDateFormatted") %></td>
                            <td><%# Eval("BurialPlace.FuturePaymentDateFormatted") %></td>
                            <td>
                                <asp:LinkButton runat="server" ID="lbtnProcessPayment" CssClass="w3-button w3-blue w3-round-small" Text="Zapłać" OnClientClick="return processPayment(this);" OnClick="lbtnProcessPayment_Click" data-d-p-id='<%# Eval("DeadPersonID") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 10px;">
                <a runat="server" id="lbtnGoBack" onserverclick="lbtnGoBack_ServerClick" class="w3-button w3-blue w3-round-large" style="float: left; margin-right: 10px;">
                    <i class="fa fa-arrow-left"></i>&nbsp;Powrót
                </a>
            </div>
        </div>
    </div>
</asp:Content>