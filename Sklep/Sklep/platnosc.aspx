<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="platnosc.aspx.cs" Inherits="Sklep.platnosc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" type="image/x-icon" href="~/Images/indeks.jpg" />
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
            text-align:center;
        }
              
        }
        .aspButton{
            color:white;
            background-color:black;
            border:2px solid black;
            border-radius:5px;
            padding:10px;
            width:180px;
            text-align:center;
            font-size:15px;
            font-weight:bold;
        }
        .aspLabel{
            color:white;
            margin:20px;
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
                body{
                    background-color:black;
                }
                #rbPlatnosc{
                    margin:0 auto;
                }
                img{
                     width:50px;
                    height:50px;
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
                    <h1 > <a style="border:none;display:flex;flex-direction:row;align-items:center;justify-content:space-around;"><asp:Button CssClass="menubtn" ID="btKoszyk" runat="server" Text="Panel Klienta " OnClick="btKoszyk_Click" /><img alt="koszyk" style="border:none;width:40px;" src="/Images/koszyk.png" /></a></h1>
                </td>
                                <td class="menu" >
                    <h1 >
                        <asp:Button cssClass="menubtn" ID="btWyloguj" runat="server" Text="Wyloguj" OnClick="btWyloguj_Click" />
                                    </h1>
                </td>


            </tr>

        </table>
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label CssClass="aspLabel" ID="lInfo" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Label ID="lKoszyk" CssClass="aspLabel" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>&nbsp;

                </td>
                <td>&nbsp;
                <asp:Table ID="tKoszyk" runat="server">
                    <asp:TableRow runat="server" Font-Bold="True">
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Nr.</asp:TableCell>
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Nazwa</asp:TableCell>
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Ilość</asp:TableCell>
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Cena</asp:TableCell>
                       
                    </asp:TableRow>
                </asp:Table>
                </td>
                <td>
                    <asp:HiddenField ID="hfPobierz" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="aspLabel" ID="lImie" runat="server" Text="Imię:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  CssClass="aspTextBox" ID="tbImie" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvImie" runat="server" ControlToValidate="tbImie" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="aspLabel" ID="lNazwisko" runat="server" Text="Nazwisko:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbNazwisko" CssClass="aspTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNazwisko" runat="server" ControlToValidate="tbNazwisko" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="aspLabel" ID="lAdres" runat="server" Text="Adres (ulica, numer domu):"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbAdres" CssClass="aspTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAdres" runat="server" ControlToValidate="tbAdres" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="aspLabel" ID="lmiejscowosc" runat="server" Text="Miejsowość:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="aspTextBox" ID="tbMiejscowosc" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMiejscowosc" runat="server" ControlToValidate="tbMiejscowosc" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label CssClass="aspLabel" ID="lKod" runat="server" Text="Kod Pocztowy:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="aspTextBox" ID="tbKod" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvKod" runat="server" ControlToValidate="tbKod" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label CssClass="aspLabel" ID="lDostawa" runat="server" Text="Wybierz rodzaj dostawy"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="radio">
                    <asp:RadioButtonList ID="rbDostawa" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbDostawa_SelectedIndexChanged" BackColor="Black" CssClass="aspLabel">
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
                    <asp:Label ID="lPlatnosc" CssClass="aspLabel" runat="server" Text="Wybierz metodę płatności"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="radio">
                    <asp:RadioButtonList ID="rbPlatnosc" runat="server" AutoPostBack="True" BackColor="Black" CssClass="aspLabel" OnSelectedIndexChanged="rbPlatnosc_SelectedIndexChanged">
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
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Black" ForeColor="White" />
                </td>
                <td>
                    <asp:Button CssClass="aspButton" ID="btKup" runat="server" Text="Złóż zamówienie" OnClick="btKup_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
