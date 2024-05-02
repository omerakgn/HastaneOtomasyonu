<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bitengorevler.aspx.cs" Inherits="Bitengorevler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 381px;
            margin-top: 104px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="Gridview3" runat="server" AutoGenerateColumns="false" DataKeyNames="BitengorevID" CssClass="auto-style1" Height="160px" Width="483px">
                <Columns>
                    <asp:TemplateField HeaderText="Doktor">
                        <ItemTemplate>
                            <asp:Label ID="labeldoktor" Text='<%#  Eval("Doktor") %>' runat="server"> </asp:Label>
                        </ItemTemplate >

                    </asp:TemplateField >

                    

                    <asp:TemplateField HeaderText="Poliklinik" >
                        <ItemTemplate>
                           <asp:Label Text='<%#  Eval("Polisim") %>' runat="server"> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teknik Sorun">
                        <ItemTemplate>
                             <asp:Label  ID="Labeltekniksorun" Text='<%#  Eval("Tekniksorun") %>' runat="server"> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField  HeaderText="Teknik Durum">
                        <ItemTemplate>
                            <asp:Label  ID="Labelteknikdurum" Text='<%#  Eval("Teknikdurum") %>' runat="server"> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
