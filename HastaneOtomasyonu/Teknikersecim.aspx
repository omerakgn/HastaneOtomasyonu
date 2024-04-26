<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teknikersecim.aspx.cs" Inherits="Teknikersecim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Design.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 400px;
            margin-top: 150px;
            margin-left:250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1" >
            <div style="height:100px;width:120px; margin-left:300px;" class="hakkimizda">
              <div> <asp:Label ID="Label1" runat="server" Text="GÖREVLER" Font-Bold="True" style="margin-left:20px;"></asp:Label></div> 
               <div><asp:Button ID="Button1" runat="server" Text="GÖRÜNTÜLE" Width="100%" style="margin-top:10px;" OnClick="Button1_Click" /></div> 
            </div>
            <div class="duyuru" style=" height:100px ;margin-left:10px; width:120px;">
                <div> <asp:Label ID="Label2" runat="server" Text="TALEPLER" Font-Bold="True" style="margin-left:20px;"></asp:Label></div>
                <div><asp:Button ID="Button2" runat="server" Text="GÖRÜNTÜLE" Width="100%" style="margin-top:10px;" OnClick="Button2_Click" /></div> 
            </div>
        </div>
    </form>
</body>
</html>
