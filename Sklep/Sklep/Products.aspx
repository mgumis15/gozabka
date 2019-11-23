<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Sklep.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #tProducts{
            border:1px solid black;
            padding:5px;
        }
        #tProducts td{
            border:1px solid black;
        }
        .imgTable{
            width:50px;
            height:50px;
        }
        .auto-style1 {
            margin-top: 9px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="dMain" runat="server">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
             <asp:Table ID="tProducts" runat="server">
                 <asp:TableRow >
                     <asp:TableCell Font-Bold="True">
                         Id
                     </asp:TableCell>
                     <asp:TableCell Font-Bold="True">
                         Nazwa
                     </asp:TableCell>
                     <asp:TableCell Font-Bold="True">
                         Cena
                     </asp:TableCell>
                     <asp:TableCell Font-Bold="True">
                         Opis
                     </asp:TableCell>
                      <asp:TableCell Font-Bold="True">
                         Zdjęcie
                     </asp:TableCell>
                 </asp:TableRow>

                 <asp:TableRow runat="server">
                     <asp:TableCell runat="server">DODAJ</asp:TableCell>
                     <asp:TableCell runat="server">

                          <asp:TextBox ID="tbName" runat="server" CssClass="auto-style1"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="tbName"></asp:RequiredFieldValidator>

                     </asp:TableCell>
                     <asp:TableCell runat="server">

                         <asp:TextBox ID="tbPrice" runat="server" ControlToValidate="tbPrice"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="tbPrice"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="revPrice" runat="server" ErrorMessage="Podaj poprawną cenę" Text="*" ControlToValidate="tbPrice" ValidationExpression="^\d+(?:[\.\,]\d+)?$"></asp:RegularExpressionValidator>

                     </asp:TableCell>
                     <asp:TableCell runat="server">

                         <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Text="*" ControlToValidate="tbDescription"></asp:RequiredFieldValidator>

                     </asp:TableCell>
                     <asp:TableCell runat="server">

                         <asp:FileUpload ID="fUpload" runat="server" />
                         <asp:RequiredFieldValidator ID="rfvFile" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="fUpload"></asp:RequiredFieldValidator>
                         <asp:CustomValidator ID="cvFile" runat="server" ErrorMessage="Zły format pliku" Text="*" ControlToValidate="fUpload" OnServerValidate="cvFile_ServerValidate" ></asp:CustomValidator>

                     </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Button ID="bAdd" runat="server" Text="Dodaj produkt" OnClick="bAdd_Click" />
                     </asp:TableCell>
                 </asp:TableRow>

        </asp:Table>
            
        </div>
       
        
       
       
        
    </form>
    
    
    
</body>
</html>
