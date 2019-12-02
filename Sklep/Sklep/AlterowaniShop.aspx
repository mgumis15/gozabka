<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterowaniShop.aspx.cs" Inherits="Sklep.AlterowaniShop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 432px;
        }
        .auto-style2 {
            height: 23px;
        }
        td{
            width:33.3%;
            text-align:center;
            heigth:auto;
        }
        #tShop{
            border:1px solid black;
            padding:5px;
        }
        #tShop td{
            border:1px solid black;
        }
        .imgTable{
            width:50px;
            height:50px;
        }
        td{
            width:20%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btRefresh" runat="server" Text="Strona główna" OnClick="btRefresh_Click" /></td>
            <td class="auto-style2">
                <asp:Button ID="btKoszyk" runat="server" Text="Koszyk" OnClick="btKoszyk_Click" /></td>
            <td class="auto-style2">
                <asp:Button ID="btKlient" runat="server" Text="Panel Klienta"  /></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td id="cont" class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        </table>
        <asp:Table ID="tShop" runat="server">
        </asp:Table>
    </form>
</body>
</html>
