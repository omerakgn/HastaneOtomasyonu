<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Randevularim.aspx.cs" Inherits="Randevularim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 496px;
        }
        .auto-style2 {
            height: 300px;
            margin-top:50px;
        }
        .style1{
            margin-left:2px;
        }
    </style>
</head>
<body style="height: 700px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div style="background-color: lightblue; font-size:50px; height:66px;width: 900px; margin-left:200px" > <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RANDEVULARIM</b></div>
       <div style="margin-top:50px; margin-left:600px">
           <asp:Button ID="Button2" runat="server" Text="Yeni Randevu Al " style="width:100px; height:35px;" Font-Bold="True" Font-Italic="False" Font-Names="Calibri" Font-Size="Small" BackColor="LightBlue" OnClick="Button2_Click" />
            </div>
            <div >
                <div style="margin-left:400px; " ><asp:Literal ID="litHtmlTable" runat="server" ></asp:Literal></div>
                
                <div style="margin-left:200px; " ><asp:Literal ID="Literal1" runat="server" ></asp:Literal></div>

            </div>
                    
        </div>
         
    </form>
</body>
</html>
