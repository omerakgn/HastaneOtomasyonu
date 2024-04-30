<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teknikertalepler.aspx.cs" Inherits="Teknikertalepler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        function confirmDelete(button) {
    if (confirm("Bu kaydı silmek istediğinize emin misiniz?")) {
        __doPostBack(button.id, ""); 
        return true;
    } else {
        return false;
    }
}</script>
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
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataKeyNames="TeknikSorunID" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" Height="221px" Width="465px">
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
                          <asp:Label ID="LabelTeknikSorun" Text='<%#  Eval("Tekniksorun") %>' runat="server"> </asp:Label>

                      </ItemTemplate>

                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Onayla">
                      <ItemTemplate>
                          <asp:Button  Text="Onayla" runat="server" CommandName="Onaylabuton" ToolTip="Onayla" > </asp:Button>

                      </ItemTemplate>

                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Reddet">
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
    