<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_anketgor.aspx.cs" Inherits="M_anketgor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                   <div style ="margin-left:300px; margin-top:30px;">
   <asp:Gridview ID="Gwanket1" runat="server" AutoGenerateColumns="False" DataKeyNames="M_anketID" CssClass="auto-style1" Height="204px" Width="528px" >
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
