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
            text-align:center;
           
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
                <td>
                    <asp:Label ID="lImie" runat="server" Text="Imię:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbImie" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvImie" runat="server" ControlToValidate="tbImie" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lNazwisko" runat="server" Text="Nazwisko:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbNazwisko" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNazwisko" runat="server" ControlToValidate="tbNazwisko" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lAdres" runat="server" Text="Adres (ulica, numer domu):"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbAdres" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAdres" runat="server" ControlToValidate="tbAdres" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lmiejscowosc" runat="server" Text="Miejsowość:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbMiejscowosc" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMiejscowosc" runat="server" ControlToValidate="tbMiejscowosc" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lKod" runat="server" Text="Kod Pocztowy:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbKod" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvKod" runat="server" ControlToValidate="tbKod" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lDostawa" runat="server" Text="Wybierz rodzaj dostawy"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="radio">
                    <asp:RadioButtonList ID="rbDostawa" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbDostawa_SelectedIndexChanged">
                        <asp:ListItem Value="20">Kurier (płatność z góry)<div class="ceny">20zł</div></asp:ListItem>
                        <asp:ListItem Value="25">Kurier (płatność pobraniowa)<div class="ceny">25zł</div></asp:ListItem>
                        <asp:ListItem Value="13">Poczta Polska<div class="ceny">13zł</div></asp:ListItem>
                        <asp:ListItem Value="10">Paczkomaty InPost <div class="ceny">10zł</div></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvrbDostawa" runat="server" ControlToValidate="rbDostawa" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lPlatnosc" runat="server" Text="Wybierz metodę płatności"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="radio">
                    <asp:RadioButtonList ID="rbPlatnosc" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="SPrzelew">Szybki Przelew</asp:ListItem>
                        <asp:ListItem Value="PTradycyjny">Przelew Tradycyjny</asp:ListItem>
                        <asp:ListItem Value="PBLIK">Przelew BLIK</asp:ListItem>
                        <asp:ListItem Value="POdbior">Płatność przy odbiorze</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvrbPlatnosc" runat="server" ControlToValidate="rbPlatnosc" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btKup" runat="server" Text="Złóż zamówienie" OnClick="btKup_Click" />
                </td>
                <td>
                    <asp:Label ID="lInfo" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
