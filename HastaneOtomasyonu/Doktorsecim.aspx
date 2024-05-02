<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doktorsecim.aspx.cs" Inherits="Doktorsecim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .style{
        margin-left:450px;
        height:30px;
    }
    .style2{
        height:30px;
        
    }
        .auto-style1 {
            margin-left: 132px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
       <div style="height:100px;" >

           
           <asp:Button CssClass="style" ID="Button2" runat="server" Text="Reçete Oluştur" OnClick="Button2_Click" />
           <asp:Button CssClass="style2" ID="Button3" runat="server" Text="Ameliyat Kayıt" OnClick="Button3_Click" />
           <asp:Button CssClass="style2" ID="Button4" runat="server" Text="Memnuniyet Anketi" OnClick="Button4_Click" />
           <asp:Button CssClass="style2" ID="Button5" runat="server" Text="Teknik Sorun Bildir" OnClick="Button5_Click" />

       </div>
        
        <div>

            <div style ="margin-left:300px; margin-top:30px;">
    <asp:Gridview ID="GwDoktor" runat="server" AutoGenerateColumns="False" DataKeyNames="RandevuID" CssClass="auto-style1" Height="204px" Width="528px" >
        <Columns>
            <asp:TemplateField HeaderText="Randevu tarihi">
                <ItemTemplate>
                    <asp:Label Text='<%#  Eval("Randevutarih") %>'  runat="server"> </asp:Label>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hasta isim">
                <ItemTemplate>
                    <asp:Label Text='<%#  Eval("Hasta") %>' runat="server"> </asp:Label>

                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Hasta TC">
                <ItemTemplate>
                    <asp:Label Text='<%#  Eval("HastaTC") %>' runat="server"> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="">
                 <ItemTemplate>
                     <asp:Button  Text="Randevuyu ertele " runat="server" CommandName="Delete" ToolTip="iptal" > </asp:Button>

                 </ItemTemplate>
             </asp:TemplateField>
            
        </Columns>

    </asp:Gridview>

 </div>
    </div>
        
    </form>
</body>
</html>
