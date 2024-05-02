<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sorunbildir.aspx.cs" Inherits="Sorunbildir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 482px;
            
        }
        .auto-style2 {
            margin-left: 700px;
            margin-top: 12px;
        }
        .auto-style3 {
            height: 21px;
            margin-top: 83px;
        }
        
        .style4{
             margin-left: 482px;
             margin-top:150px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
        
            <div class="auto-style3"> 
                <asp:Label ID="Label1" runat="server" Text="Teknik Sorun Bildirin : " CssClass ="style4" Font-Bold="True" ></asp:Label>
            </div>
            <div> <asp:TextBox ID="Tekniksoruntxt" runat="server" CssClass="auto-style1" Height="152px" TextMode="MultiLine" Width="341px"></asp:TextBox></div>
            <div><asp:Button ID="Button1" runat="server" CssClass="auto-style2" OnClick="Button1_Click" Text="Button" Width="93px" /></div>

        </div>    
    </form>
</body>
</html>
