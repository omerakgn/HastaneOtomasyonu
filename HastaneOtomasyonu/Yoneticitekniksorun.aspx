<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Yoneticitekniksorun.aspx.cs" Inherits="Yoneticitekniksorun" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .style {
        margin-left: 396px;
        margin-top:100px;
    }
</style>
</head>
<body>
        <form id="form1" runat="server">
            <div class="style">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"  DataKeyNames="TeknikergorevID"  Height="221px" Width="465px"  >
                    <Columns>
        <asp:TemplateField HeaderText="Doktor">
            <ItemTemplate>
                <asp:Label ID="labeldoktor" Text='<%#  Eval("Doktor") %>' runat="server"> </asp:Label>
            </ItemTemplate>


        </asp:TemplateField>
        <asp:TemplateField HeaderText="Poliklinik">
            <ItemTemplate>
                <asp:Label Text='<%#  Eval("Polisim") %>' runat="server"> </asp:Label>

            </ItemTemplate>

        </asp:TemplateField>
    
    
        <asp:TemplateField HeaderText="Teknik Sorun">
            <ItemTemplate>
                <asp:Label  ID="Labeltekniksorun" Text='<%#  Eval("Tekniksorun") %>' runat="server"> </asp:Label>

            </ItemTemplate>

        </asp:TemplateField>
                        
        <asp:TemplateField HeaderText="Teknik Durum">
            <ItemTemplate>
                <asp:Label ID="lblTeknikdurum" Text='<%#  Eval("Teknikdurum") %>' runat="server" ></asp:Label>

            </ItemTemplate>

        </asp:TemplateField>
    
</Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
