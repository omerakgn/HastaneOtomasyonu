﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teknikergorevler.aspx.cs" Inherits="Teknikergorevler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .auto-style1 {
        margin-left: 396px;
    }
    .ddlstyle{
        width:100%;
        height:70%;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
               
        <div style="margin-top:100px;" class="auto-style1">
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  DataKeyNames="TeknikergorevID"  Height="221px" Width="465px"  OnRowCommand="GridView2_RowCommand">
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
                  <asp:TemplateField HeaderText="Teknik Durum" >
                      <ItemTemplate>
                          <asp:DropDownList CssClass="ddlstyle" ID="DDLTeknikdurum"  runat="server"  AutoPostBack="True" OnSelectedIndexChanged="DDLTeknikdurum_SelectedIndexChanged"> 
                              <asp:ListItem Value="">Seçiniz </asp:ListItem>
                              <asp:ListItem>Teknik ekip yönlendirildi </asp:ListItem>
                              <asp:ListItem>Arıza tespit yapıldı</asp:ListItem>
                              <asp:ListItem>Parça bekleniyor</asp:ListItem>
                              <asp:ListItem>Parça temin edildi</asp:ListItem>
                              <asp:ListItem>Cihazın birime gelmesi bekleniyor</asp:ListItem>
                              <asp:ListItem>Tamir edildi</asp:ListItem>
                              <asp:ListItem>Teslim edildi</asp:ListItem>
                          </asp:DropDownList>

                      </ItemTemplate>

                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="">
                      <ItemTemplate>
                          <asp:Button CssClass="ddlstyle" Text="Tamamlandı"  runat="server" CommandName="Buton" ToolTip="delete"> </asp:Button>

                      </ItemTemplate>

                  </asp:TemplateField>
              </Columns>
               

          </asp:GridView>
            </div>
        <div> 
            <asp:Button  ID="button2" runat="server" Text="Biten görevler" Width="140px" style="margin-left:550px; margin-top:40px; background-color:lightblue; " OnClick="button2_Click" />
        </div>
    </form>
</body>
</html>
