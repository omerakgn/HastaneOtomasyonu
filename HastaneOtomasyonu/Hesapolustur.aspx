,<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hesapolustur.aspx.cs" Inherits="Hesapolustur" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
 
    .auto-style10 {
        width: 300px;
        height:400px;
        margin-left:300px;
    }
    .auto-style11 {
        height: 23px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    
        
            <div style="background-color: lightblue; font-size:50px; height:66px;width: 900px; margin-left:200px;" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HESAP OLUŞTUR</b></div>
    
        
            <div style="height: 500px; margin-left: 200px; width: 900px; margin-top: 20px;">


            <table class="auto-style10">

                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label1" runat="server" Text="İsim :" Font-Bold="True" Width="50px"></asp:Label></td>
                    <td class="auto-style11">
                        <asp:TextBox ID="isimtxt" runat="server" Width="190px"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label2" runat="server" Text="Soyisim :" Font-Bold="True"></asp:Label></td>
                    <td class="auto-style11">
                        <asp:TextBox ID="soyisimtxt" runat="server" Width="190px"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label3" runat="server" Text="TC :" Font-Bold="True"></asp:Label></td>
                    <td class="auto-style11">
                        <asp:TextBox ID="tcnotxt" runat="server" Width="190px" TextMode="Number"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label4" runat="server" Text="Mail :" Font-Bold="True"></asp:Label></td>
                    <td class="auto-style11">
                        <asp:TextBox ID="mailtxt" runat="server" Width="190px" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label5" runat="server" Text="Şifre :" Font-Bold="True"></asp:Label></td>
                    <td class="auto-style11">
                        <asp:TextBox ID="sifretxt" runat="server" Width="190px"></asp:TextBox></td>
                </tr>

                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label6" runat="server" Text="Telefon numarası :" Font-Bold="True"></asp:Label></td>
                    <td class="auto-style11">
                        <asp:TextBox ID="telnotxt" runat="server" Width="190px" placeholder="ÖRN: 5071898075" ></asp:TextBox>
                       
                    </td>
                </tr>


            </table>

            <div style="margin-top: 30px;">
                <asp:Button ID="Button1" runat="server" Text="Hesap Oluştur" Width="140px" Style="margin-left: 400px; background-color: lightblue;" OnClick="Button1_Click" />
            </div>
                <div style="margin-left:320px;"><asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="tcnotxt" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numaranız 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator></div>
                
                <div style="margin-left:330px;"><asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="sifretxt" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{7,25}$" runat="server" ErrorMessage="Şifreniz en az 7 karakter içermelidir !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator></div>
   
                <div  style="margin-left:340px;"> <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="telnotxt" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{10,10}$" runat="server" ErrorMessage="Telefon numaranızı kontrol ediniz !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator></div>
   

                
           
    </div>
</form>
</body>
</html>
