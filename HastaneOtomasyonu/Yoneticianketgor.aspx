<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Yoneticianketgor.aspx.cs" Inherits="Yoneticianketgor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style ="margin-left:400px; margin-top:70px;">
   <asp:Gridview ID="Gwanket2" runat="server" AutoGenerateColumns="False" DataKeyNames="M_anketID" CssClass="auto-style1" Height="204px" Width="528px" >
       <Columns>
           <asp:TemplateField HeaderText="Randevu tarihi">
               <ItemTemplate>
                   <asp:Label Text='<%#  Eval("Randevutarih" , "{0:dd.MM.yyyy }") %>'  runat="server"> </asp:Label>

               </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Hasta isim">
               <ItemTemplate>
                   <asp:Label Text='<%#  Eval("Hasta") %>' runat="server"> </asp:Label>

               </ItemTemplate>
           </asp:TemplateField>

                      <asp:TemplateField HeaderText="Doktor">
                          <ItemTemplate>
                              <asp:Label Text='<%#  Eval("Doktor") %>' runat="server"> </asp:Label>

                          </ItemTemplate>

                      </asp:TemplateField>

          
           <asp:TemplateField HeaderText="Anket metni">
               <ItemTemplate>
                   <asp:Label Text='<%#  Eval("M_Anket") %>' runat="server"> </asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
           
           
           
           
       </Columns>

   </asp:Gridview>

</div>
    </form>
</body>
</html>
