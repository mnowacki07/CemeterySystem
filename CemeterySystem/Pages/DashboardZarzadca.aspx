<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ZadrzadcaMaster.Master" AutoEventWireup="true" CodeBehind="DashboardZarzadca.aspx.cs" Inherits="CemeterySystem.Pages.DashboardZarzadca" %>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

<!-- ZAWARTOŚĆ STRONY START -->
   <div class="w3-container" style="margin-top:80px" id="pogrzeby">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Pogrzeby.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
  </div>
  
  <!-- Icon grid -->
  <div class="w3-row-padding">
    <div class="w3-half">
      <img src="https://i.imgur.com/nzgTknT.png" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks"> 
      <img src="https://i.imgur.com/zD7PEHB.jpg" style="width:100%" onclick="onClick(this)" alt="Light, white and tight scandinavian design">
 
    </div>

    <div class="w3-half">
      <img src="https://i.imgur.com/OD3KOXq.jpg" style="width:100%" onclick="onClick(this)" alt="Windows for the atrium">
      <img src="https://i.imgur.com/u1AEkOJ.jpg" style="width:100%" onclick="onClick(this)" alt="Bedroom and office in one space">

    </div>
  </div>

  <!-- Osoby zmarłe -->
  <div class="w3-container   " id="osoby_zmarle" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-red w3-text-dark-grey"><b>Osoby zmarłe.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>
     <!-- Icon grid -->
  <div class="w3-row-padding">
    <div class="w3-half">
      <img src="https://i.imgur.com/aD6lEtw.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks">
      <img src="https://i.imgur.com/zD7PEHB.jpg" style="width:100%" onclick="onClick(this)" alt="Light, white and tight scandinavian design">
  
    </div>

    <div class="w3-half">
      <img src="https://i.imgur.com/OD3KOXq.jpg" style="width:100%" onclick="onClick(this)" alt="Windows for the atrium">
      <img src="https://i.imgur.com/u1AEkOJ.jpg" style="width:100%" onclick="onClick(this)" alt="Bedroom and office in one space">
  
    </div>
  </div>
  
  <!-- Miejsca pochówku -->
  <div class="w3-container" id="miejsca_pochowku" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Miejsca pochówku.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
     </div>
       <!-- Icon grid -->
  <div class="w3-row-padding">
    <div class="w3-half">
      <img src="https://i.imgur.com/aD6lEtw.jpg" style="width:100%" OnClick="Button1_Click" alt="Concrete meets bricks">
      <img src="https://i.imgur.com/zD7PEHB.jpg" style="width:100%" onclick="onClick(this)" alt="Light, white and tight scandinavian design">

    </div>

    <div class="w3-half">
      <img src="https://i.imgur.com/OD3KOXq.jpg" style="width:100%" onclick="onClick(this)" alt="Windows for the atrium">
      <img src="https://i.imgur.com/u1AEkOJ.jpg" style="width:100%" onclick="onClick(this)" alt="Bedroom and office in one space">
    
    </div>
  </div>


  <!-- Rezerwacje -->
  <div class="w3-container" id="rezerwacje" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Rezerwacje.</b></h1>
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
                                <a href="/Pages/PaymentClassDetails?ID=<%# Eval("PaymentClassID") %>">Pokaż</a>                                
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
                <a href="/Pages/PaymentClassDetails?Create=True" class="w3-button w3-blue w3-round-large" style="float: right;"><i class="fa fa-plus"></i>&nbsp;Nowy</a>
            </div>
        </div>        
    </div>
  
  <!-- Dodatkowe informacje -->
  <div class="w3-container" id="Dodatkowe informacje" style="margin-top:75px">
    <h1 class="w3-xxxlarge w3-text-dark-grey"><b>Dodatkowe informacje.</b></h1>
    <hr style="width:300px;border:5px solid grey" class="w3-round">
    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi aut ipsam itaque quia voluptates laborum provident sed molestiae illum. Maiores?</p>
      
      <div class="w3-section">
        <label>Imię</label>
        <input class="w3-input w3-border" type="text" name="Name" required>
      </div>
      <div class="w3-section">
        <label>Email</label>
        <input class="w3-input w3-border" type="text" name="Email" required>
      </div>
      <div class="w3-section">
        <label>Widomość</label>
        <input class="w3-input w3-border" type="text" name="Message" required>
      </div>
      
          <asp:Button ID="Button1" runat="server" Text="Button" type="submit" class="w3-button w3-block w3-padding-large w3-red w3-margin-bottom" Height="54px" />
     
      
  </div>

    </asp:Content>  