<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Yoneticigiris.aspx.cs" Inherits="Yoneticigiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
     .auto-style1 {
         height: 66px;
         width: 100%;
     }
     .auto-style2 {
         height: 325px;
     }
     .auto-style3 {
         margin-left: 610px;
     }
     input[type=number]::-webkit-inner-spin-button {
    -webkit-appearance: none;
     display: none;
     }
 </style>
</head>
<body style="height:700px;">
    <form id="form1" runat="server">
        <div>
                    <div style="background-color: lightblue; font-size:50px;" class="auto-style1">
                        <asp:Label Text="Yönetici Girişi" runat="server" style="margin-left:530px;"></asp:Label>
                    </div>
        <div class="auto-style2">
            <div style="margin-top:50px; height:20px;"><asp:Label ID="Label1" runat="server" Text="TC Kimlik numarası:" CssClass="left" style="margin-left:560px" Font-Size="Large"></asp:Label> </div>
            
            <div style="height:50px;"> <asp:TextBox ID="Yoneticitc" runat="server" Height="37px" Width="230px" CssClass="right" style="margin-left: 560px ;" TextMode="Number" AutoCompleteType="Disabled"  ></asp:TextBox >
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="Yoneticitc" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numaranız 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            
            
       
     <div><asp:Label ID="Label2" runat="server" Text="Şifre:" CssClass="left" style="margin-left: 560px" Font-Size="Large"></asp:Label> </div>
     
     <div style="height:50px;"> <asp:TextBox ID="Sifre" runat="server" Height="37px" Width="230px" CssClass="right" style="margin-left: 560px" AutoCompleteType="Disabled" TextMode="Password" ></asp:TextBox ></div>
 
            <div style ="margin-top:20px; height:70px" > 
                <asp:Button ID="Button" runat="server" Text="Giriş Yap" CssClass="auto-style3" Width="140px" Height="40px" OnClick="Button_Click"  />
            </div>
                        <div style=" margin-top:10px;">
                            <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black"  style="margin-left: 635px;"  OnClick="LinkButton2_Click"  >Şifremi unuttum</asp:LinkButton>

                        </div>
        

</div>
            

        </div>
    </form>
</body>
</html>
