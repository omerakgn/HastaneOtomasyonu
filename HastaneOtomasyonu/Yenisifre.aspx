<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Yenisifre.aspx.cs" Inherits="Yenisifre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Design.css" rel="stylesheet" />
    <style type="text/css">
 
    .auto-style1 {           
        margin-left: 412px;           
        margin-top: 25px;
         }
     
    input[type=number]::-webkit-inner-spin-button {
        -webkit-appearance: none;
         display: none;
         }
   
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div style="background-color: lightblue; font-size:50px; height:66px;width: 100%; " > 
        <asp:Label Text="Şifre Yenileme" runat="server" style="margin-left:530px;"></asp:Label>
    </div>
            <div style="margin-top:50px; margin-left:200px;" >
    
    <table class="tablestyle">
        
        <tr>
            <td class="tdstyle;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="TC kimlik numaranız :"></asp:Label>

            </td>
                    
            <td class="tdstyle;"> 
                <asp:TextBox ID="txtTC" runat="server" Width="160px" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>

            </td>

                </tr>

        <tr>
            <td class="tdstyle;"> 
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Yeni Şifre :"></asp:Label>
            </td>
            <td class="tdstyle;"> 
                <asp:TextBox ID="txtyenisifre" runat="server" Width="160px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdstyle;">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Yeni Şifre Tekrar :"></asp:Label>

            </td>
            <td class="tdstyle;"> 
                <asp:TextBox ID="txtsifretekrar" runat="server" Width="160px" AutoCompleteType="Disabled"></asp:TextBox>

            </td>
</tr>

    </table>
    
    <div>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Font-Bold="True"  Text="ONAYLA" Width="115px" OnClick="Button1_Click" />
    </div>
                <div style="margin-left:320px; margin-top:30px;"> 
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTC" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numaranız 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                
</div>


</div>
    </form>
</body>
</html>
