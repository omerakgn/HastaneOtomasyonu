<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Randevularim.aspx.cs" Inherits="Randevularim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 496px;
        }
        .style1{
            margin-left:2px;
        }
    </style>
</head>
<body style="height: 700px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div style="background-color: lightblue; font-size:50px; height:66px;width: 100%; " > 
                <asp:Label Text="Randevularım" runat="server" style="margin-left:530px;"></asp:Label>
            </div>
       <div style="margin-top:50px; margin-left:600px">
           <asp:Button ID="btnrandevual" runat="server" Text="Yeni Randevu Al " style="width:130px; height:35px;" Font-Bold="True" Font-Italic="False" Font-Names="Calibri" Font-Size="Small" BackColor="LightBlue" OnClick="Button2_Click" />
            </div>
            <div style="margin-top:20px; margin-left:600px" >
                <asp:Button ID="btnanket" runat="server" Text="Memnuniyet Anketi  " style="width:130px; height:35px;" Font-Bold="True" Font-Italic="False" Font-Names="Calibri" Font-Size="Small" BackColor="LightBlue" OnClick="btnanket_Click" />
            </div>
            <div style ="margin-left:100px; margin-top:30px;">
               <asp:Gridview ID="GwRandevu" runat="server" AutoGenerateColumns="False" DataKeyNames="RandevuID" OnRowDeleting="GwRandevu_RowDeleting">
                   <Columns>
                       <asp:TemplateField HeaderText="Randevu Numarası">
                           <ItemTemplate>
                               <asp:Label Text='<%#  Eval("RandevuID") %>'  runat="server"> </asp:Label>

                           </ItemTemplate>

                       </asp:TemplateField>

                       <asp:TemplateField HeaderText="Randevu Tarihi">
                           <ItemTemplate>
                               <asp:Label Text='<%#  Eval("Randevutarih" , "{0:dd.MM.yyyy }") %>'  runat="server"> </asp:Label>

                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Hastane">
                           <ItemTemplate>
                               <asp:Label Text='<%#  Eval("Hastaneisim") %>' runat="server"> </asp:Label>

                           </ItemTemplate>
                       </asp:TemplateField>
                      
                       <asp:TemplateField HeaderText="Poliklinik">
                           <ItemTemplate>
                               <asp:Label Text='<%#  Eval("Polisim") %>' runat="server"> </asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>

                       <asp:TemplateField HeaderText="Doktor">
                           <ItemTemplate>
                               <asp:Label Text='<%#  Eval("Doktor") %>' runat="server"> </asp:Label>

                           </ItemTemplate>
                       </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button  Text="Randevuyu iptal et" runat="server" CommandName="Delete" ToolTip="iptal" > </asp:Button>

                            </ItemTemplate>
                        </asp:TemplateField>
                       
                   </Columns>

               </asp:Gridview>
               <div style="margin-left:110px;">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
            </div>
                    
        </div>
         
    </form>
</body>
</html>
