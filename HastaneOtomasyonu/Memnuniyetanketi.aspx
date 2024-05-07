<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Memnuniyetanketi.aspx.cs" Inherits="Memnuniyetanketi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Design.css" rel="stylesheet" />
    <style type="text/css">

        .auto-style1 {
            width: 410px;
            height: 170px;
            margin-left: 146px;
        }
        .auto-style2 {
            height: 33px;
        }
        .auto-style3 {
            background-color: lightblue;
            border-radius: 2%;
            border: 1px solid black;
            height: 30px;
            margin-left: 70px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div >
            <div style="background-color: lightblue; font-size:50px;  width: 100%; height: 66px;" >  
                <asp:Label Text="Memnuniyet Anketi" runat="server" style="margin-left:430px;"></asp:Label>
            </div>
        <div style="margin-top:100px; margin-left:300px;">
            <table class="auto-style1">
            <tr>
                <td class="auto-style2"> <asp:Label ID="lbl1" runat="server" Text="Randevu numarası :"> </asp:Label> </td>
                <td class="auto-style2"> <asp:TextBox ID="txtRandevuNo" runat="server" AutoCompleteType="Disabled" Width="170px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td> <asp:Label ID="lbl2" runat="server" Text="Randevu tarihi :"> </asp:Label></td>
                <td> <asp:TextBox ID="TxtRandevutarih" runat="server" AutoCompleteType="Disabled" TextMode="Date" Width="170px" ></asp:TextBox> </td>
            </tr>
                <tr>
                    <td> <asp:Label ID="lbl3" runat="server" Text="Görüş ve Şikayetleriniz :"> </asp:Label></td>
                    <td> <asp:TextBox ID="txtMetin" runat="server" AutoCompleteType="Disabled" Height="70px" TextMode="MultiLine" Width="170px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btngonder" runat="server" Text="Gönder" OnClick="btngonder_Click" CssClass="button" Width="100px" style="margin-left:77px;" /> </td>               
                </tr>
        </table>
        </div>
        
        
        </div>
    </form>
</body>
</html>

