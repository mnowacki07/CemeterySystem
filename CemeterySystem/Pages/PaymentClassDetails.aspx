<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="PaymentClassDetails.aspx.cs" Inherits="CemeterySystem.Pages.PaymentClassDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        jQuery(document).ready(function () {
            jQuery("#form1").validate({
                rules: {
                    "<%= txtName.UniqueID %>": {
                        required: true
                    },
                    "<%= txtPrice.UniqueID %>": {
                        required: true,
                        priceRegex: true
                    }            
                },
                messages: {
                    "<%= txtName.UniqueID %>": { required: "Proszę wpisać nazwę" },
                    "<%= txtPrice.UniqueID %>": { required: "Proszę wpisać cenę" }
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
        });

        function validateForm() {
            jQuery("#form1").validate();            
            return jQuery("#form1").valid();
        }
    </script>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblName" Text="Nazwa:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtName" CssClass="w3-input w3-round-large" />        
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPrice" Text="Cena:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPrice" CssClass="w3-input w3-round-large" />        
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblDescription" Text="Opis:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtDescription" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 10px;">
            <button runat="server" id="btnDelete" onserverclick="btnDelete_ServerClick" class="w3-button w3-red w3-round-large" style="float: left;">
                <i class="fa fa-times"></i>&nbsp;Usuń
            </button>
            <button type="submit" runat="server" id="btnSave" onclick="if(!validateForm()) return;" onserverclick="btnSave_Click" class="w3-button w3-green w3-round-large" style="float: right;">
                <i class="fas fa-check"></i>&nbsp;Zapisz
            </button>
        </div>
    </div>
</asp:Content>
