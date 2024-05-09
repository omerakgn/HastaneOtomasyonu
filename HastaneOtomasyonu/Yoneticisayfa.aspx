<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Yoneticisayfa.aspx.cs" Inherits="Yoneticisayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Design.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 41%;
            height: 120px;
            margin-left: 0px;
            margin-top: 20px;
        }
        .auto-style3 {
            height: 66px;
            width: 100%;
        }
        .auto-style4 {
            width: 202px;
            text-align: right;
            font-weight: bold;
            height: 40px;
        }
        .auto-style8 {
            height: 40px;
            width: 155px;
        }
        .auto-style9 {
            width: 155px;
        }
        input[type=number]::-webkit-inner-spin-button {
            -webkit-appearance: none;
            display: none;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: lightblue; font-size:50px;" class="auto-style3"> 
    <asp:Label Text="Yönetici Paneli" runat="server" style="margin-left:550px;"></asp:Label>
</div>
        <div style="margin-left: 40%;"> 
            <asp:Button ID="Button1" runat="server" Text="Memnuniyet Anketi" Width="160px"  CssClass="button" style="margin-top:20px; margin-right:10px;" OnClick="Button1_Click" />
            
            <asp:Button ID="Button2" runat="server" Text="Teknik Sorunları Görüntüle" Width="160px"  CssClass="button" style="margin-top:20px; " OnClick="Button2_Click" />

        </div>
        <div  style="margin-left: 46%; margin-top:3%; margin-bottom:20px;">
            <asp:Label ID="lbl1" runat="server" Text="BÖLÜM EKLE-SİL" Font-Bold="True" Font-Overline="False" Font-Underline="True"></asp:Label>
           
        </div>
       
        <div style="margin-left: 40%;">
            <asp:DropDownList ID="DropDownList1" runat="server" Width="329px" Height="25px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
        </div>

        <div style ="margin-left:35%; margin-top:20px;">                                              

            <table class="auto-style1">
                               
                <tr >
                    <td class="auto-style4" >
                        Bölüm Adı :&nbsp;</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtbolum" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"> </td>
                    <td class="auto-style9"> <b><u>Doktor Bilgileri </u></b></td>

                </tr>
                 <tr>
                     <td class="auto-style4">Unvanı :</td>
                     <td class="auto-style8" >
                        <asp:TextBox ID="txtunvan" runat="server" Width="145px" AutoCompleteType="Disabled"></asp:TextBox>
                     </td>

                 </tr>

                <tr>
                    <td class="auto-style4">
                        
                        İsim :</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtIsim" runat="server" Width="145px" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        TC Kimlik Numarası :</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtTCNO" runat="server" Width="145px" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style4">

                        Şifre :</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtboxsifre" runat="server" Width="145px" AutoCompleteType="Disabled"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td class="auto-style4">

                        Mail adresi :</td>

                    <td  class="auto-style8">

                        <asp:TextBox ID="txtMAIL" runat="server" Width="145px" AutoCompleteType="Disabled" TextMode="Email"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td> 
                        <asp:Button ID="btnekle" Text="Ekle" runat="server" CssClass="button" Width="75px" OnClick="btnekle_Click"></asp:Button>
                        <asp:Button ID="btnsil" Text="Sil" runat="server" CssClass="button" Width="75px" OnClick="btnsil_Click"></asp:Button>
                    </td>
                </tr>
               
                
               
            </table>

        </div>
         <div style="margin-left: 38%; margin-top:5px;">
      <asp:Label ID="lbl2" runat="server" Text="(NOT:Silmek istediğiniz doktorun tcno ve isim bilgilerini girmeniz yeterlidir.)" Font-Bold="True" Font-Size="Small"></asp:Label>
 </div>
        <div style="margin-left:500px;">
            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTCNO" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numaranız 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
       

    </form>
</body>
</html>
