<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receteolustur.aspx.cs" Inherits="Receteolustur" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Design.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 466px;
        }
        .auto-style2 {
            width: 300px;
            height: 267px;
            margin-left: 78px;
            margin-top: 68px;
            align-content:center;
            float:left;
        }
        .txtboxstyle{

            width:200px;
            height:25px;
        }
        .auto-style3 {
            width: 82px;
        }
        .trstyle{
            height:50px;

        }
        
        .auto-style5 {
            background-color: lightblue;
            border-radius: 2%;
            border: solid black 2px;
            margin-top: 13px;
        }
        
        .auto-style6 {
            float: left;
            height: 300px;
            margin-left: 100px;
            
        }
        .auto-style7 {
            margin-left: 0px;
            margin-top: 11px;
            }
        input[type=number]::-webkit-inner-spin-button {
   
            -webkit-appearance: none;
            display: none;

        }
        
       
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table class="auto-style2" >
                <tr class="trstyle">
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Hasta adı :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtHasta" runat="server" CssClass="txtboxstyle" AutoCompleteType="Disabled" ></asp:TextBox>
                    </td>
                </tr>
                <tr class="trstyle">
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Hasta TC:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtHastatc" runat="server" CssClass="txtboxstyle" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr class="trstyle">
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Text="Hasta mail :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtHastamail" runat="server" CssClass="txtboxstyle" AutoCompleteType="Disabled" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr class="trstyle">
                    <td class="auto-style3">
                        <asp:Label ID="Label4" runat="server" Text="İlaç adı :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txtilac" runat="server" CssClass="txtboxstyle" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr class="trstyle">
                    <td class="auto-style3">
                        <asp:Label ID="Label5" runat="server" Text="Adet :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txtadet" runat="server" CssClass="txtboxstyle" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr class="trstyle">
                    <td class="auto-style3">
                        <asp:Label ID="Label6" runat="server" Text="Kullanım talimatları :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtTalimat" runat="server" CssClass="txtboxstyle" TextMode="MultiLine" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td> <asp:Button ID="Kaydetbtn" Text="Kaydet" runat="server" CssClass="auto-style5"  Height="31px" OnClick="Kaydetbtn_Click" Width="86px" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                         <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TxtHastatc" ID="MyPassordMinMaxLengthValidator" ValidationExpression="^[\s\S]{11,11}$" runat="server" ErrorMessage="Tc kimlik numaranız 11 haneli olmalıdır !" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>

                </tr>
            </table>

             <div style="margin-top:70px;" class="auto-style6">
     <asp:GridView ID="GwRecete" runat="server" AutoGenerateColumns="False" DataKeyNames="ReceteID" CssClass="auto-style7" Height="243px" Width="529px">
         <Columns>
             
             <asp:TemplateField HeaderText="Hasta" >
                 <ItemTemplate>
                     <asp:Label Text='<%#  Eval("Hasta") %>' runat="server" > </asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Hasta TC ">
                 <ItemTemplate>
                     <asp:Label Text='<%#  Eval("HastaTC") %>' runat="server" > </asp:Label>

                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="İlaç">
                 <ItemTemplate>
                     <asp:Label Text='<%#  Eval("Ilac") %>' runat="server"> </asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="İlaç adeti" >
                 <ItemTemplate>
                     <asp:Label Text='<%#  Eval("Ilacadet") %>' runat="server"> </asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Kullanım talimatları">
                 <ItemTemplate>
                     <asp:Label Text='<%#  Eval("Kullanimtalimat") %>' runat="server" > </asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>

         </Columns>


     </asp:GridView>
                      
 </div>

            
        </div>

       

    </form>
</body>
</html>
