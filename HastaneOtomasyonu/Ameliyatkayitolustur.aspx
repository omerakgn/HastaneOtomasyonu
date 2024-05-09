<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ameliyatkayitolustur.aspx.cs" Inherits="Ameliyatkayitolustur" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Design.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 400px;
            margin-left:500px;
            height: 256px;
        }
        .auto-style2 {
            width: 168px;
            text-align: right;
             height: 43px;
        }
        input[type=number]::-webkit-inner-spin-button {
            -webkit-appearance: none;
            display: none;
        }   
        .auto-style4 {
            height: 43px;
        }
        .auto-style5 {
            background-color: lightblue;
            border-radius: 2%;
            border: 1px solid black;
            margin-left: 85px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top:150px;">
            <table class="auto-style1">
                <tr >
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Hasta TC :" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txthastaTC" runat="server" Width="166px" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Hasta İsim-Soyisim :" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtHastaisim" runat="server" Width="166px" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Ameliyathane numarası :" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAhaneno" runat="server" Width="166px" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Ameliyat Tarihi :" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAmeliyatTarih" runat="server" Width="166px" AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Açıklama :" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAciklama" runat="server" Width="166px" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Oluştur" CssClass="auto-style5" Height="25px" OnClick="Button1_Click" Width="89px" />
                    </td>
                </tr>
            </table>
            <div style ="margin-left:600px;">
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txthastaTC" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numarası 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red" ></asp:RegularExpressionValidator>
            </div>
            
        </div>

    </form>
</body>
</html>
