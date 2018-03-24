<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="FuneralCompanyList.aspx.cs" Inherits="CemeterySystem.Pages.FuneralCompanyList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="w3-container" style="margin-top:80px" id="top">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Zakłady pogrzebowe</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>

    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-funeral-company').DataTable({
                language: jQueryDataTableTranslations
            });
            generateFooterFilters(jQuery('#table-funeral-company'));
        });
    </script>

    <div class="table-wrapper">
        <table id="table-funeral-company" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th style="max-width: 300px;">Nazwa</th>
                    <th style="max-width: 200px;">Numer licencji</th>                    
                    <th>Adres</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>nazwa</th>
                    <th>numer licencji</th>
                    <th>adres</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repFuneralCompany">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/FuneralCompanyDetails?FuneralCompanyID=<%# Eval("FuneralCompanyID") %>">Pokaż</a>                                
                            </td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("LicenseNumber") %></td>
                            <td><%# Eval("Address.AddressHtmlFormatted") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 20px;">
                <a href="/Pages/FuneralCompanyDetails.aspx?IsCreateMode=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>        
    </div>
</asp:Content>
