<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Randevual.aspx.cs" Inherits="Randevual" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="DropdownScript.js"></script>
    <title></title>
    <style type="text/css">
     
        .auto-style10 {
            width: 400px;
            height:500px;
            margin-left:300px;
        }
        .auto-style11 {
            height:40px;
        
        .dropdownlistdesign{
            height: 60%;
            width: 190px;

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <div style="background-color: lightblue; font-size:50px; height:66px;width: 900px; margin-left:200px" > <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RANDEVU AL</b></div>
        
            <div style="height:800px; margin-left:200px;width: 900px; margin-top:20px;">
           
               

                <table class="auto-style10">
                   
                    <tr>
                        <td class="auto-style11"><asp:Label ID="Label1" runat="server" Text="İl :" Font-Bold="True" Width="50px"></asp:Label></td>
                        <td class="auto-style11">
                            <asp:DropDownList ID="il" runat="server" CssClass="dropdownlistdesign" OnSelectedIndexChanged="il_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                   
                    <tr>
                        <td class="auto-style11"><asp:Label ID="Label2" runat="server" Text="İlçe :" Font-Bold="True"></asp:Label></td>
                        <td class="auto-style11">
                            <asp:DropDownList ID="ilce" runat="server"  CssClass="dropdownlistdesign" AutoPostBack="True" OnSelectedIndexChanged="ilce_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style11"><asp:Label ID="Label3" runat="server" Text="Hastane :" Font-Bold="True"></asp:Label></td>
                        <td class="auto-style11">
                            <asp:DropDownList ID="hastane" runat="server" CssClass="dropdownlistdesign" AutoPostBack="True" OnSelectedIndexChanged="hastane_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style11"><asp:Label ID="Label4" runat="server" Text="Poliklinik" Font-Bold="True"></asp:Label></td>
                        <td class="auto-style11">
                            <asp:DropDownList ID="poliklinik" runat="server" CssClass="dropdownlistdesign" AutoPostBack="True" OnSelectedIndexChanged="poliklinik_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style11"><asp:Label ID="Label5" runat="server" Text="Doktor :" Font-Bold="True"></asp:Label></td>
                        <td class="auto-style11">
                            <asp:DropDownList ID="doktor" runat="server" CssClass="dropdownlistdesign" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style11"><asp:Label ID="Label6" runat="server" Text="Tarih :" Font-Bold="True"></asp:Label></td>
                        <td class="auto-style11">
                            <asp:Calendar ID="tarih" runat="server" Height="55px"></asp:Calendar>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="auto-style11"><asp:Label ID="Label7" runat="server" Text="Şikayet :" Font-Bold="True"></asp:Label></td>
                        <td class="auto-style11" ><asp:TextBox ID="sikayet" runat="server" Width="190px" EnableTheming="True" Height=100% TextMode="MultiLine" style="resize:none"></asp:TextBox></td>
                    
                    </tr>
             
                </table>

                <div style="margin-top:30px;">
                    <asp:Button ID="Button1" runat="server" Text="Randevu Al" Width="140px" style="margin-left:400px; background-color:lightblue; " OnClick="Button1_Click" />
                </div>
                                                                 
        </div>
    </form>
</body>
</html>
