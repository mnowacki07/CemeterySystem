<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="FuneralsList.aspx.cs" Inherits="CemeterySystem.Pages.FuneralsList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="w3-container" style="margin-top:80px" id="top">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Pogrzeby</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>

    <script>        
        jQuery(document).ready(function () {
            jQuery('#table-funeral').DataTable({
                language: jQueryDataTableTranslations
            });
            generateFooterFilters(jQuery('#table-funeral'));
        });
    </script>

    <div class="table-wrapper">
        <table id="table-funeral" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th style="max-width: 100px;">Pokaż</th>
                    <th style="max-width: 300px;">Data</th>
                    <th>Osoba zmarła</th>
                    <th>Zakład pogrzebowy</th> 
                    <th>Osoba prowadząca ceremonię</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th></th>
                    <th>data</th>
                    <th>osoba zmarła</th>
                    <th>zakład pogrzebowy</th>
                    <th>osoba prowadząca ceremonię</th>
                </tr>
            </tfoot>
            <tbody>
                <asp:Repeater runat="server" ID="repFuneral">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <a href="/Pages/FuneralsDetails?FuneralID=<%# Eval("Funeral.FuneralID") %>">Pokaż</a>                                
                            </td>
                            <td><%# Eval("Funeral.FuneralShortDateFormatted") %></td>
                            <td><%# Eval("DeadPerson.NameFormatted") %></td>
                            <td><%# Eval("Funeral.FuneralCompany.Name") %></td>
                            <td><%# Eval("Funeral.CemeteryStaffPerson.LastName") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div class="w3-row">
            <div class="w3-col m12" style="padding-top: 20px;">
                <a href="/Pages/FuneralsDetails.aspx?IsCreateMode=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>        
    </div>
</asp:Content>