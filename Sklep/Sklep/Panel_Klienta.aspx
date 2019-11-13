<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel_Klienta.aspx.cs" Inherits="Sklep.Panel_Klienta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        td{
            width:33.3%;
            text-align:center;
            heigth:auto;
        }
        .auto-style3 {
            height: 30px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">

    <table class="auto-style1">
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2">Panel Klienta</td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btZmiana" runat="server" OnClick="btZmiana_Click" Text="Zmień Hasło" />
            </td>
            <td>
                <asp:Button ID="btHaslo" runat="server" Text="Zmień dane konta" OnClick="btHaslo_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lName" runat="server" Text="Nazwa" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbName" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lMail" runat="server" Text="Adres e-mail" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbMail" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lInfo" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Button ID="btConfirm" runat="server" OnClick="btConfirm_Click" Text="Zatwierdź" Visible="False" />
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lOld" runat="server" Text="Stare hasło" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbOld" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lNew" runat="server" Text="Nowe hasło" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbNew" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lNewRep" runat="server" Text="Powtórz nowe hasło" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbNewRep" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btPass" runat="server" Text="Zatwierdź" Visible="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

    </form>

</body>
</html>
