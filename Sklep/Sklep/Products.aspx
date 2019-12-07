<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Sklep.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" type="image/x-icon" href="~/Images/indeks.jpg" />
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
         #dMain{
            display:inline-block;
            
        }
        #rightDiv{
            display:inline-block;
            position:fixed;
            left:60%;
            top:5%;

        }
       
        #modDiv{
            display:none;
           width:300px;
           height:200px;
           border:1px solid black;
           background-color:#00bcd4;
           text-align:center;

        }
        #delDiv{
            display:none;
           width:300px;
           height:100px;
           border:1px solid black;
           background-color:#ff5252;
           text-align:center;
        }
                body{
            background-color:black;
        }
        .aspButton{
            color:white;
            background-color:black;
            border:2px solid black;
            border-radius:5px;
            padding:10px;
            width:120px;
            text-align:center;
            font-size:15px;
            font-weight:bold;
        }
        .aspLabel{
            color:white;
        }
        
        .menuTab{
            width:100%;
            background-color:black;
        }
        h1{
            text-align:center;
        }
        a{
            text-decoration:none;
            text-align:center;
            color:white;
            background-color:black;
            display:block;
            border:2px solid white;
            border-radius:100px;
            width:60%;
            margin:0 auto;
            padding:10px;

        }
        .aspTextBox{
            width:100%;
            background-color:#191717;
            border:1px solid white;
            border-radius:10px;
            text-align:center;
            color:white;
            height:50px;
            margin-top:10px;
            margin-bottom:10px;
        }
        .auto-style1 {
            width: 100%;
        }
        td{
           align-items:flex-end;
        }
        .auto-style3 {
            height: 30px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            height: 30px;
            width: 232px;
        }
        .auto-style6 {
            width: 232px;
        }
        .auto-style7 {
            height: 26px;
            width: 232px;
        }
        .auto-style8 {
            height: 30px;
            width: 333px;
        }
        .auto-style9 {
            width: 333px;
        }
        .auto-style10 {
            height: 26px;
            width: 333px;
        }
        .menu{
            width:25%;
        }

        .auto-style13 {
            height: 79px;
            width: 359px;
        }
                .menubtn{
            text-decoration:none;
            text-align:center;
            color:white;
            background-color:black;
            display:block;
            border:2px solid white;
            border-radius:100px;
            width:200px;
            margin:0 auto;
            padding:10px;
            font-size:25px;
            font-weight:bold;
        }
                
   
        }
         .desc{
            font-size:18px;
            color:white;
            text-align:center;
           
        }
       .Title{
           font-size:18px;
            color:white;
            text-align:center;
       }
       .price{
            font-size:18px;
            color:white;
            text-align:center;
       }
       .ajdi{
            font-size:18px;
            color:white;
            text-align:center;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="menuTab">
            <tr>
                <td class="menu">

                    <img alt="logo" class="auto-style13" src="/Images/logo.png" /></td>

                <td class="menu">
                   <asp:Button CssClass="menubtn" ID="btRefresh" runat="server" Text="Strona główna" OnClick="btRefresh_Click" />
                   </td>

                                <td class="menu" >
                    <h1 >
                        <asp:Button cssClass="menubtn" ID="btWyloguj" runat="server" Text="Wyloguj" OnClick="btWyloguj_Click" />
                                    </h1>
                </td>


            </tr>

        </table>
        <div id="dMain" runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Adding" ForeColor="White"/>
             <asp:Table ID="tProducts" runat="server">
                 <asp:TableRow >
                     <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Id
                     </asp:TableCell>
                     <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Nazwa
                     </asp:TableCell>
                     <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Cena
                     </asp:TableCell>
                     <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Opis
                     </asp:TableCell>
                      <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Zdjęcie
                     </asp:TableCell>
                 </asp:TableRow>

                 <asp:TableRow runat="server">
                     <asp:TableCell cssClass="aspLabel" runat="server">DODAJ</asp:TableCell>
                     <asp:TableCell runat="server">

                          <asp:TextBox cssClass="aspTextBox" ID="tbName" runat="server" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="tbName" ValidationGroup="Adding"></asp:RequiredFieldValidator>

                     </asp:TableCell>
                     <asp:TableCell runat="server">

                         <asp:TextBox cssClass="aspTextBox" ID="tbPrice" runat="server" ControlToValidate="tbPrice"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="tbPrice" ValidationGroup="Adding"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="revPrice" runat="server" ErrorMessage="Podaj poprawną cenę" Text="*" ControlToValidate="tbPrice" ValidationExpression="^\d+(?:[\.\,]\d+)?$" ValidationGroup="Adding"></asp:RegularExpressionValidator>

                     </asp:TableCell>
                     <asp:TableCell runat="server">

                         <asp:TextBox cssClass="aspTextBox" ID="tbDescription" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Text="*"  ErrorMessage="To pole jest wymagane" ControlToValidate="tbDescription" ValidationGroup="Adding"></asp:RequiredFieldValidator>

                     </asp:TableCell>
                     <asp:TableCell runat="server">

                         <asp:FileUpload ID="fUpload" runat="server" />
                         <asp:RequiredFieldValidator ID="rfvFile" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="fUpload" ValidationGroup="Adding"></asp:RequiredFieldValidator>
                         <asp:CustomValidator ID="cvFile" runat="server" ErrorMessage="Zły format pliku" Text="*" ControlToValidate="fUpload" OnServerValidate="cvFile_ServerValidate" ValidationGroup="Adding"></asp:CustomValidator>

                     </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Button cssClass="aspButton" ID="bAdd" runat="server" Text="Dodaj produkt" OnClick="bAdd_Click" ValidationGroup="Adding" UseSubmitBehavior="True" />
                     </asp:TableCell>
                 </asp:TableRow>

        </asp:Table>
           
            <asp:HiddenField ID="hField" runat="server" />
           
        </div>
        <div id="rightDiv" runat="server">
            <div id="modDiv" runat="server"> 
                  <asp:Label ID="lModID" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lModName" runat="server" Text="Nazwa"></asp:Label>
                &nbsp;<asp:TextBox ID="tbModName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvModName" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="tbModName" ValidationGroup="Modifying"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lModPrice" runat="server" Text="Cena"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbModPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvModPrice" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="tbModPrice" ValidationGroup="Modifying"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="Podaj poprawną cenę" Text="*" ControlToValidate="tbModPrice" ValidationExpression="^\d+(?:[\.\,]\d+)?$" ValidationGroup="Modifying"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="lModDescription" runat="server" Text="Opis"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbModDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvModDescription" runat="server" ErrorMessage="To pole jest wymagane" Text="*" ControlToValidate="tbModDescription" ValidationGroup="Modifying"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lModPhoto" runat="server" Text="Zdjęcie"></asp:Label>
                &nbsp;<asp:FileUpload ID="fModUpload" runat="server" />
                
                 <asp:CustomValidator ID="cvModFile" runat="server" ErrorMessage="Zły format pliku" Text="*" ControlToValidate="fModUpload"  ValidationGroup="Modifying" OnServerValidate="cvModFile_ServerValidate"></asp:CustomValidator>
                <br />
                <asp:Button ID="btMod" runat="server" Text="MODYFIKUJ" ValidationGroup="Modifying" OnClick="btMod_Click"/>   

                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Modifying" ForeColor="White"/>
            </div>
                <div id="delDiv" runat="server">
                    <asp:Label ID="lDelName" runat="server" Text="USUŃ"></asp:Label>
                    <br />
                    <asp:Label ID="lDelID" runat="server" Text=""></asp:Label>
                       <br />
                    <asp:Button ID="btDelete" runat="server" Text="USUŃ" OnClick="btDelete_Click" CausesValidation="False" />
                </div>
            </div>
        
       
       
        
    </form>
    
    
    
</body>
</html>
