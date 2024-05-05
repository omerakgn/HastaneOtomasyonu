<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ameliyatkayit.aspx.cs" Inherits="Ameliyatkayit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

    .auto-style1 {
     margin-left: 132px;
 }

 </style>
</head>
<body>
    <form id="form1" runat="server">
                  <div style ="margin-left:200px; margin-top:90px;">
   <asp:Gridview ID="GwAmeliyat" runat="server" AutoGenerateColumns="False" DataKeyNames="AmeliyatID" OnRowCommand="GwAmeliyat_RowCommand" ShowFooter="true"  Height="204px" Width="528px" >
       <Columns>
           <asp:TemplateField HeaderText="Ameliyat tarihi">
               <ItemTemplate>
                   <asp:Label ID="AmeliyatTarih1" Text='<%#  Eval("AmeliyatTarih" , "{0:dd.MM.yyyy }") %>'  runat="server" > </asp:Label>
                   
               </ItemTemplate>
               <FooterTemplate>
                   <asp:TextBox ID="AmeliyatTarihtxt" Text='<%# Eval("AmeliyatTarih") %>' runat="server"> </asp:TextBox>

               </FooterTemplate>
           </asp:TemplateField>

           <asp:TemplateField HeaderText="Açıklama">
               <ItemTemplate>
                   <asp:Label Text='<%#  Eval("Ameliyataciklama") %>' runat="server"> </asp:Label>

               </ItemTemplate>
               <FooterTemplate>
                   <asp:TextBox ID="Ameliyataciklamatxt" Text='<%#  Eval("Ameliyataciklama") %>' runat="server"> </asp:TextBox>
               </FooterTemplate>

           </asp:TemplateField>
          
           <asp:TemplateField HeaderText="Hasta TC">
               <ItemTemplate>
                   <asp:Label Text='<%#  Eval("HastaTC") %>' runat="server"> </asp:Label>
               </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="HastaTCtxt" Text='<%#  Eval("HastaTC") %>' runat="server"> </asp:TextBox>

                </FooterTemplate>
           </asp:TemplateField>

           <asp:TemplateField HeaderText="Hasta">
               <ItemTemplate>
                   <asp:Label Text='<%#  Eval("Hasta") %>' runat="server"> </asp:Label>

               </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="Hastatxt" Text='<%#  Eval("Hasta") %>' runat="server"> </asp:TextBox>

                </FooterTemplate>
           </asp:TemplateField>
           
           <asp:TemplateField HeaderText="Ameliyathane">
               <ItemTemplate>
                   <asp:Label Text='<%#  Eval("Ameliyathaneno") %>' runat="server"> </asp:Label>

               </ItemTemplate>
               <FooterTemplate>
                   <asp:TextBox ID="Ameliyathaneno" Text='<%#  Eval("Ameliyathaneno") %>' runat="server"> </asp:TextBox>

               </FooterTemplate>

           </asp:TemplateField>


            <asp:TemplateField HeaderText="">
                <FooterTemplate>
                    <asp:Button  Text="Kayıt oluştur " runat="server" CommandName="AddNew" ToolTip="Add new" > </asp:Button>

                </FooterTemplate>
            </asp:TemplateField>
           
           
       </Columns>

   </asp:Gridview>

</div>
    </form>
</body>
</html>
