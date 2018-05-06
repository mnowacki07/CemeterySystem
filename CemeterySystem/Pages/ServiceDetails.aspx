<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" CodeBehind="ServiceDetails.aspx.cs" Inherits="CemeterySystem.Pages.ServiceDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="w3-container" style="margin-top: 80px" id="top">
        <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Usługa</b></h1> 
        <hr style="width: 300px; border: 5px solid grey" class="w3-round">  <br />                
 </div>


    <script>
        jQuery(document).ready(function () {
            jQuery("#form1").validate({
                rules: {
                    "<%= txtName.UniqueID %>": {
                        required: true
                    },
                    "<%= txtPriceGross.UniqueID %>": {
                        required: true,
                        priceRegex: true
                    }                    
                },
                messages: {
                    "<%= txtName.UniqueID %>": { required: "Proszę wpisać nazwę" },
                    "<%= txtPriceGross.UniqueID %>": { required: "Proszę wpisać cenę" }                    
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
            <asp:Label runat="server" ID="lblDescription" Text="Opis:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtDescription" CssClass="w3-input w3-round-large" TextMode="MultiLine" Rows="5" style="resize: none;" />        
        </div>
    </div>

    <div class="w3-row">
        <div class="w3-col m12">
            <asp:Label runat="server" ID="lblPriceGross" Text="Cena:" />
        </div>
    </div>
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 5px;">
            <asp:TextBox runat="server" ID="txtPriceGross" CssClass="w3-input w3-round-large" />        
        </div>
    </div>
    
    <div class="w3-row">
        <div class="w3-col m12" style="padding-top: 10px;">
            <a runat="server" id="lbtnGoBack" onserverclick="lbtnGoBack_ServerClick" class="w3-button w3-blue w3-round-large" style="float: left; margin-right: 10px;">
                <i class="fa fa-arrow-left"></i>&nbsp;Powrót
            </a>
            <a runat="server" id="btnDelete" onserverclick="btnDelete_ServerClick" class="w3-button w3-red w3-round-large" style="float: left;">
                <i class="fa fa-times"></i>&nbsp;Usuń
            </a>
            <button type="submit" runat="server" id="btnSave" onclick="if(!validateForm()) return;" onserverclick="btnSave_ServerClick" class="w3-button w3-green w3-round-large" style="float: right;">
                <i class="fa fa-check"></i>&nbsp;Zapisz
            </button>
        </div>
    </div>
</asp:Content>
