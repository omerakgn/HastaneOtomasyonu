<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Güvenlikkodu.aspx.cs" Inherits="Güvenlikkodu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left:37%;margin-top:200px;">
            <table>
                <tr>
                    <td style="height:20px;"> 
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="ŞİFRE YENİLEME KODU :" Font-Size="Large" Height="100%"></asp:Label>

                    </td>
                    <td style="height:20px;"> 
                        <asp:TextBox ID="Kod" runat="server" Width="160px" Height="100%"></asp:TextBox>

                    </td>

                </tr>
                
                </table>
            <div style="margin-top:20px;">
                <asp:Button ID="Button1" runat="server" Text="DOĞRULA" style="margin-left:130px;" Font-Bold="True" Font-Size="Medium" Height="35px" Width="100px" OnClick="Button1_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
