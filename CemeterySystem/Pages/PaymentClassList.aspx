<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="PaymentClassList.aspx.cs" Inherits="CemeterySystem.Pages.PaymentClassList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="w3-container" style="margin-top:80px" id="top">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Opłaty.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>




    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-payment-class').DataTable({
                language: jQueryDataTableTranslations
            });
            generateFooterFilters(jQuery('#table-payment-class'));
        });
    </script>

    <div class="table-wrapper">
        <table id="table-payment-class" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th style="max-width: 300px;">Nazwa</th>
                    <th style="max-width: 200px;">Cena</th>
                    <th>Opis</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>nazwa</th>
                    <th>cena</th>
                    <th>opis</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repPaymentClass">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/PaymentClassDetails?PaymentClassID=<%# Eval("PaymentClassID") %>">Pokaż</a>                                
                            </td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("PriceFormatted") %></td>
                            <td><%# Eval("Description") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 20px;">
                <a href="/Pages/PaymentClassDetails?IsCreateMode=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>        
    </div>
</asp:Content>
