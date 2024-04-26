<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doktorsecim.aspx.cs" Inherits="Doktorsecim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .style{
        margin-left:350px;
        height:30px;
    }
    .style2{
        height:30px;
        
    }
        </style>
</head>
<body>
    <form id="form1" runat="server">
       <div style="height:100px;" >

           <asp:Button CssClass="style"  ID="Button1" runat="server" Text="Randevu Ertele" />
           <asp:Button CssClass="style2" ID="Button2" runat="server" Text="Reçete Oluştur" />
           <asp:Button CssClass="style2" ID="Button3" runat="server" Text="Ameliyat Kayıt" />
           <asp:Button CssClass="style2" ID="Button4" runat="server" Text="Memnuniyet Anketi" />
           <asp:Button CssClass="style2" ID="Button5" runat="server" Text="Teknik Sorun Bildir" />

       </div>
        
        <div>

            <div style="margin-top:100px; margin-left:400px;"> <asp:Literal ID="litHtmlTable2" runat="server" ></asp:Literal></div>
            <div style="margin-left:400px; " ><asp:Literal ID="Literal2" runat="server" ></asp:Literal></div>
    </div>
        
    </form>
</body>
</html>
