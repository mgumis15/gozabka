<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Sklep.Users" %>

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
            right:20%;
            top:15%;
            height:300px;
        }
       

        #delDiv{
           display:none;
           width:300px;
           height:auto;
           border:1px solid white;
           border-radius:10px;
           background-color:black;
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
                              <td class="menu">
                   
                                  <asp:Button ID="Button1" CssClass="menubtn" runat="server" Text="Produkty" OnClick="Button1_Click" />
                   
                   </td>

                                <td class="menu" >
                    <h1 >
                        <asp:Button cssClass="menubtn" ID="btWyloguj" runat="server" Text="Wyloguj" OnClick="btWyloguj_Click" />
                                    </h1>
                </td>


            </tr>

        </table>
        <div id="dMain" runat="server">

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Adding"/>
             <asp:Table ID="tUsers" runat="server">
                 <asp:TableRow >
                     <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Id
                     </asp:TableCell>
                     <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Nazwa
                     </asp:TableCell>
                     <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Ilość odwiedzin
                     </asp:TableCell>
                      <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Usuń
                     </asp:TableCell>
                      <asp:TableCell cssClass="aspLabel" Font-Bold="True">
                         Zbanowany
                     </asp:TableCell>

                 </asp:TableRow>

                 

        </asp:Table>
           
            <asp:HiddenField ID="hField" runat="server" />
           
        </div>
        <div id="rightDiv" runat="server">
            
                <div class="delDiv" id="delDiv" runat="server">
                    <asp:Label ID="lDelName" cssClass="aspLabel" runat="server" Text="Czy na pewno chcesz usunąć?"></asp:Label>
                    <br />
                    <asp:Label ID="lDelID" cssClass="aspLabel" runat="server" Text=""></asp:Label>
                       <br />
                    <asp:Button ID="btDelete" cssClass="aspButton" runat="server" Text="USUŃ" OnClick="btDelete_Click" CausesValidation="False" />
                </div>
            </div>
        
       
       
        
    </form>
    
    
    
</body>
</html>
