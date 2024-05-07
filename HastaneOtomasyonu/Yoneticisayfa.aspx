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
        }
        .auto-style2 {
            width: 202px;
            text-align: center;
        }
        .auto-style3 {
            height: 66px;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: lightblue; font-size:50px;" class="auto-style3"> 
    <asp:Label Text="Yönetici Paneli" runat="server" style="margin-left:520px;"></asp:Label>
</div>
        <div style ="margin-left:40%; margin-top:5%;">
            <table class="auto-style1">
                <tr >
                    <td class="auto-style2" >
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Bölüm ekle-sil"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style2" style="height:100px;">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td style="height:100px;">
                        <asp:Button ID="Silbtn" runat="server" Text="Sil" Width="77px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="height:50px;">
                        <asp:TextBox ID="TextBox1" runat="server" Width="145px"></asp:TextBox>
                    </td>
                    <td style="height:50px;">
                        <asp:Button ID="Eklebtn" runat="server" Text="Ekle" Width="77px" />
                    </td>
                </tr>

                <tr>
    <td class="auto-style2" style="height:100px;">
        <asp:Button ID="Button1" runat="server" Text="Memnuniyet Anketi" Width="160px"  CssClass="button" style="margin-top:20px;" OnClick="Button1_Click" />
    </td>
    <td>
       <asp:Button ID="Button2" runat="server" Text="Teknik Sorunları Görüntüle" Width="160px"  CssClass="button" style="margin-top:20px;" OnClick="Button2_Click" />
    </td>
</tr>
               
            </table>
        </div>
      
    </form>
</body>
</html>
