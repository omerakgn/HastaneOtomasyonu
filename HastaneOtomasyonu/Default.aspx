<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Design.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height:110px;
        }
        .auto-style2 {
            width: 132px;
        }
        .auto-style3 {
            width: 532px;
            height: 50px;
            margin-left:130px;
            margin-top:20px;
        }
        .auto-style4 {
            width: 175px;
        }
        .auto-style5 {
            width: 175px;
        }
        .auto-style6 {
            display: flex;
            margin-left: 90px;
            width: 1200px;
            height: 500px;
            
        }
        .auto-style7 {
            height: 51px;
            margin-top: 0px;
            float:left
        }
        .style123{
            float:left
        }
    </style>
</head>
<body style="height:100% ; width:100%; background-color:lightblue;">
    <form id="form1" runat="server">
                   
                <div style ="height:120px; width:320px;" class="style123">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">
                                <asp:Image ID="Image1" runat="server" Height="100px" Width="140px" ImageUrl="~/Images/MHRS_Logo_1.png" />
                            </td>
                            <td><p style="font-size:18px"><b>HASTA-DOKTOR <br/>
                                RANDEVU TAKİP <br />
                                SİSTEMİ</b> </p></td>
                        </tr>
                    </table>
                
                    </div>
        <div class="auto-style7">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="Button3" runat="server" Text="Hasta Giriş" Width="150px" CssClass="button" OnClick="Button3_Click" />
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="Button4" runat="server" Text="Doktor Giriş" Width="150px" CssClass="button" OnClick="Button4_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button5" runat="server" Text="Yönetici Giriş" Width="150px" CssClass="button" OnClick="Button5_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button6" runat="server" Text="Tekniker Giriş" Width="150px" CssClass="button" OnClick="Button6_Click" />
                    </td>
                </tr>
            </table>
                </div>
        
        <div class="auto-style6">
            <div  class="hakkimizda" style="border:solid black 2px ; border-radius:2%;"> <b>HAKKIMIZDA  </b>
                <br />
                Burada yazacağımız yazı kısaca bilgilendirme olacaktır.<br />
                <br />
                <b>Sıkça Sorulan Sorular<br />
                </b></div> 
            <div  class="duyuru" style="border:solid black 2px ; border-radius:2%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<b>DUYURULAR VE REKLAMLAR</b>
            </div>
            <div  class="kirmizi" >
                <div  >
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Hastaneimage.png" CssClass="circleclass" />
                    <br />  Size yakın hasteneleri kolaylıkla seçebilirsiniz
                </div>
                <div > 
                    <asp:Image  ID ="Image3" runat="server"  ImageUrl="~/Images/steteskopimage.jpg" CssClass="circleclass" style="margin-top:25px;"/>
                    <br /> İstediğiniz doktora randevu almak artık çok kolay
                </div>
                <div > 
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/soruisaretimage.jpg" CssClass="circleclass" style="margin-top:25px;" />
                    <br /> Şikayetinizi randevu alırken girebilme imkanınız var
                </div>
            </div>
                
            
                </div>
         <div style="margin-left:600px"><p>Soru ve sorunlarınız için hastadoktor@saglik.com.tr </p></div>

    </form>
</body>
</html>
