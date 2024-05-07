<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teknikergiris.aspx.cs" Inherits="Teknikergiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 590px;
        }
        .auto-style2 {
            height: 66px;
            width: 100%;

        }
        input[type=number]::-webkit-inner-spin-button {
            -webkit-appearance: none;
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: lightblue; font-size:50px; " class="auto-style2"> 
            <asp:Label Text="Tekniker Girişi" runat="server" style="margin-left:510px;"></asp:Label>
        </div>

        <div>
            <div style="margin-top:50px; height:20px;"><asp:Label ID="Label1" runat="server" Text="TC Kimlik numarası:" CssClass="lbl1" style="margin-left:540px" Font-Size="Large"></asp:Label> </div>
       
            <div style="height:50px;"> <asp:TextBox ID="Tcno" runat="server" Height="37px" Width="230px" CssClass="textbox1" style="margin-left: 540px" TextMode="Number" AutoCompleteType="Disabled" ></asp:TextBox >
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="Tcno" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numaranız 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
       
  
            <div><asp:Label ID="Label2" runat="server" Text="Şifre:" CssClass="lbl1" style="margin-left: 540px" Font-Size="Large"></asp:Label> </div>
            <div style="height:50px;"> <asp:TextBox ID="Sifre" runat="server" Height="37px" Width="230px" CssClass="textbox1" style="margin-left: 540px" AutoCompleteType="Disabled" TextMode="Password" ></asp:TextBox ></div>
            
            <div style ="margin-top:20px; height:70px" > 
                <asp:Button ID="Button1" runat="server" Text="Giriş Yap" Width="140px" Height="40px" CssClass="auto-style1" OnClick="Button1_Click"   />

            </div>
            <div >
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black"  style="margin-left: 615px;" OnClick="LinkButton2_Click"  >Şifremi unuttum</asp:LinkButton>

            </div>
   
            

        </div>

    </form>
</body>
</html>
