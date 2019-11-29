<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="platnosc.aspx.cs" Inherits="Sklep.platnosc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        td{
            width:33.3%;
           
        }
        .RadioButtonList{
            text-align:center;
        }
        .auto-style2 {
            height: 23px;
        }
        .ceny{
            right:0;
            position:absolute;
        }
        .radio{
            position:relative;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lTitle" runat="server" Text="Potwierdzenie zamówienia"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Label ID="lKoszyk" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>&nbsp;

                </td>
                <td>&nbsp;
                                    <asp:Table ID="tKoszyk" runat="server">
                </asp:Table>
                </td>
                <td>
                    <asp:HiddenField ID="hfPobierz" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="radio">
                    <asp:RadioButtonList ID="rbDostawa" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="20">Kurier (płatność z góry)<div class="ceny">20zł</div></asp:ListItem>
                        <asp:ListItem Value="25">Kurier (płatność pobraniowa)<div class="ceny">25zł</div></asp:ListItem>
                        <asp:ListItem Value="13">Poczta Polska<div class="ceny">13zł</div></asp:ListItem>
                        <asp:ListItem Value="10">Paczkomaty InPost <div class="ceny">10zł</div></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
