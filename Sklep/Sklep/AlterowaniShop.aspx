<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterowaniShop.aspx.cs" Inherits="Sklep.AlterowaniShop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .menuTab{
            width:100%;
            background-color:black;
        }
        h1{
            text-align:center;
        }
        body{
            background-color:black;
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
        .menu{
            width:25%;
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
        .pozycjonowanie{
            display:flex;
            width:40%;
            height:90%;
            flex-direction:column;
            justify-content:space-between;
            align-items:center;
            float:right;
        }
        #tShop{
            width:100%;
            
        }
        #tShop td{
            
            border:1px solid white;
            border-radius:10px;
            margin:10px;
            width:80%;
            height:400px;
            display:flex;
            flex-direction:row;
            justify-content:space-between;
            align-items:center;
            background-color:black;
            color:white;
            margin:0 auto;
            margin-bottom:10px;
        }

        #tShop td img{
            height:80%;
            width:auto;
            margin:30px;
            

        }
        #tShop td select{
            background-color:grey;
            border:1px solid white;
            width:50px;
            height:30px;
            color:white;
            margin:20px;

        }
        #tShop td input{
            width:150px;
            background-color:#191717;
            border:1px solid white;
            border-radius:10px;
            text-align:center;
            color:white;
            height:40px;
            margin:20px;



        }
        .imgTable{
            width:50px;
            height:50px;
        }
        td{
            width:20%;
        }
        .Title{
            font-size:25px;
            color:white;
            text-align:center;
            text-decoration:underline;

        }
        .desc{
            font-size:18px;
            color:white;
            text-align:center;
           
        }
        .price{
            margin-top:100px;
            color:white;
            font-size:25px;
            text-align:center;
        }
        .auto-style3 {
            width: 357px;
            height: 80px;
        }
        .auto-style4 {
            width: 100%;
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
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <table class="menuTab">
            <tr>
                <td class="menu">

                    <img alt="logo" class="auto-style3" src="/Images/logo.png" /></td>

                <td class="menu">
                   <asp:Button CssClass="menubtn" ID="btRefresh" runat="server" Text="Strona główna" OnClick="btRefresh_Click" />
                   </td>
                <td class="menu" >
                    <h1 > <a style="border:none;display:flex;flex-direction:row;align-items:center;justify-content:space-around;"><asp:Button CssClass="menubtn" ID="btKoszyk" runat="server" Text="Panel Klienta " OnClick="btKoszyk_Click" /><img alt="koszyk" style="border:none;width:40px;" src="/Images/koszyk.png" /></a></h1>
                </td>
                                <td class="menu" >

                    <h1 >
                        <asp:Button cssClass="menubtn" ID="btWyloguj" runat="server" Text="Wyloguj" />
                                    </h1>

                </td>


            </tr>

        </table>
       
        <asp:Table ID="tShop" runat="server">
        </asp:Table>
    </form>

</body>
</html>
