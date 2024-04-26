<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doktorgiris.aspx.cs" Inherits="Doktorgiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
     .auto-style1 {
         height: 66px;
         width: 900px;
     }
     .auto-style2 {
         height: 325px;
     }
     .auto-style3 {
         margin-left: 610px;
     }
     </style>
</head>
<body style="height:700px;">
    <form id="form1" runat="server">
        <div>
                    <div style="background-color: lightblue; font-size:50px; margin-left:200px" class="auto-style1"> <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DOKTOR GİRİŞİ</b></div>
        <div class="auto-style2">
            <div style="margin-top:50px; height:20px;"><asp:Label ID="Label1" runat="server" Text="TC Kimlik numarası:" CssClass="left" style="margin-left:560px" Font-Size="Large"></asp:Label> </div>
            
            <div style="height:50px;"> <asp:TextBox ID="Tcno1" runat="server" Height="37px" Width="230px" CssClass="right" style="margin-left: 560px ;" TextMode="Number"  ></asp:TextBox >
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="Tcno1" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numaranız 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            
            
       
     <div><asp:Label ID="Label2" runat="server" Text="Şifre:" CssClass="left" style="margin-left: 560px" Font-Size="Large"></asp:Label> </div>
     
     <div style="height:50px;"> <asp:TextBox ID="Sifre1" runat="server" Height="37px" Width="230px" CssClass="right" style="margin-left: 560px" ></asp:TextBox ></div>
 
            <div style ="margin-top:20px; height:70px" > 
                <asp:Button ID="Button1" runat="server" Text="Giriş Yap" CssClass="auto-style3" Width="140px" Height="40px" OnClick="Button1_Click" />
            </div>
            <div style=" margin-top:10px;">
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black"  style="margin-left: 635px;" OnClick="LinkButton2_Click"  >Şifremi unuttum</asp:LinkButton>
            </div>
        
        

</div>

        </div>
    </form>
</body>
</html>
