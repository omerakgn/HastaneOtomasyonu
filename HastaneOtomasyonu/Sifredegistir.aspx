<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sifredegistir.aspx.cs" Inherits="Sifredegistir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

      <style type="text/css">
  
     .tablestyle {
         width: 400px;
         height:100px;
         margin-left:300px;
     }
     .tdstyle{
         height:23px;
     }
          .auto-style1 {
              margin-left: 412px;
              margin-top: 25px;
          }
 </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="background-color: lightblue; font-size:50px; height:66px;width: 900px; margin-left:200px;" > &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>ŞİFREMİ UNUTTUM</b></div>
        <div style="margin-top:50px; margin-left:200px;" >
            
            <table class="tablestyle">
                <tr>
                    <td class="tdstyle;"> 
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="T.C :"></asp:Label>
                    </td>
                    <td class="tdstyle;"> 
                        <asp:TextBox ID="tcno" runat="server" Width="160px"></asp:TextBox>
                         
                    </td>
                </tr>

                <tr>
                    <td class="tdstyle;"> 
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Mail Adresiniz :"></asp:Label>
                    </td>
                    <td class="tdstyle;"> 
                        <asp:TextBox ID="mail" runat="server" Width="160px"  TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
            </table>
            
            <div>
                <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Font-Bold="True" OnClick="Button1_Click" Text="Kod gönder" Width="115px" />
            
            </div>
            <div style ="margin-left: 350px;"><asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="tcno" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numaranız 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator></div>
        </div>
        
        
        </div>
    </form>
</body>
</html>
