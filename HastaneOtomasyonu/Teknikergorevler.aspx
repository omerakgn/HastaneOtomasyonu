<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teknikergorevler.aspx.cs" Inherits="Teknikergorevler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .auto-style1 {
        margin-left: 396px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
               
        <div style="margin-top:100px;" class="auto-style1">
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  DataKeyNames="TeknikergorevID"  Height="221px" Width="465px">
              <Columns>
                  <asp:TemplateField HeaderText="Doktor">
                      <ItemTemplate>
                          <asp:Label Text='<%#  Eval("Doktor") %>' runat="server"> </asp:Label>
                      </ItemTemplate>


                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Poliklinik">
                      <ItemTemplate>
                          <asp:Label Text='<%#  Eval("Polisim") %>' runat="server"> </asp:Label>

                      </ItemTemplate>

                  </asp:TemplateField>
                  
                  
                  <asp:TemplateField HeaderText="Teknik Sorun">
                      <ItemTemplate>
                          <asp:Label  Text='<%#  Eval("Tekniksorun") %>' runat="server"> </asp:Label>

                      </ItemTemplate>

                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Onayla">
                      <ItemTemplate>
                         

                      </ItemTemplate>

                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Teslim edildi ">
                      <ItemTemplate>
                          <asp:Button Text="Reddet"  runat="server" CommandName="Delete" ToolTip="delete"> </asp:Button>

                      </ItemTemplate>

                  </asp:TemplateField>
              </Columns>


          </asp:GridView>
            </div>
    </form>
</body>
</html>
