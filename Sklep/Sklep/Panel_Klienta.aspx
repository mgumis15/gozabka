<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel_Klienta.aspx.cs" Inherits="Sklep.Panel_Klienta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" type="image/x-icon" href="~/Images/indeks.jpg" />
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
            height:auto;
        }
        #tKoszyk{
            border:1px solid black;
            padding:5px;
        }
        #tKoszyk td{
            border:1px solid black;
        }
        .imgTable{
            width:50px;
            height:50px;
        }
        .auto-style3 {
            height: 30px;
        }
        .auto-style4 {
            height: 26px;
        }
        td{
            width:20%;
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
        body{
            background-color:black;

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
        .aspButton{
            color:white;
            background-color:black;
            border:2px solid black;
            border-radius:5px;
            padding:10px;
            width:160px;
            text-align:center;
            font-size:15px;
            font-weight:bold;
        }
        .aspLabel{
            color:white;
        }
        .menu{
            width:25%;
        }
        td{
    height:auto;
}
        .auto-style6 {
            height: 81px;
            width: 382px;
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
        .aspSelect{
            background-color:grey;
            border:1px solid white;
            width:50px;
            height:30px;
            color:white;
            margin:20px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
                 <table class="menuTab">
            <tr>
                <td class="menu">

                    <img alt="logo" class="auto-style6" src="/Images/logo.png" /></td>

                <td class="menu">
                   <asp:Button CssClass="menubtn" ID="btRefresh" runat="server" Text="Strona główna" OnClick="btRefresh_Click" />
                   </td>
                <td class="menu" >
                    <h1 > <a style="border:none;display:flex;flex-direction:row;align-items:center;justify-content:space-around;" ><asp:Button CssClass="menubtn" ID="btKoszyk" runat="server" Text="Panel Klienta " OnClick="btKoszyk_Click" /><img alt="koszyk" style="border:none;width:40px;" src="/Images/koszyk.png" /></a></h1>
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
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>

            <td class="minimenu" colspan="3">
                 <asp:Button CssClass="aspButton" style="margin-right:100px;" ID="btHaslo" runat="server" Text="Zmień dane konta" OnClick="btHaslo_Click" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                <asp:Button CssClass="aspButton" style="margin-left:100px;" ID="btZmiana" runat="server" OnClick="btZmiana_Click" Text="Zmień Hasło" BorderColor="White"  BorderStyle="Solid" BorderWidth="1px" />
               
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label CssClass="aspLabel" ID="lName" runat="server" Text="Nazwa" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox cssClass="aspTextBox" ID="tbName" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="aspLabel" ID="lMail" runat="server" Text="Adres e-mail" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox cssClass="aspTextBox" ID="tbMail" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label CssClass="aspLabel" ID="lInfo" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Button CssClass="aspButton" ID="btConfirm" runat="server" OnClick="btConfirm_Click" Text="Zatwierdź" Visible="False" BorderColor="White"  BorderStyle="Solid" BorderWidth="1px"/>
            </td>
            <td class="auto-style3"></td>
        </tr>

        <tr>
            <td class="auto-style4">
                <asp:Label CssClass="aspLabel" ID="lOld" runat="server" Text="Stare hasło" Visible="False"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="tbOld" cssClass="aspTextBox" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvOld" runat="server" ControlToValidate="tbOld" Enabled="False" ErrorMessage="Pole wymagane" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="aspLabel" ID="lNew" runat="server" Text="Nowe hasło" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbNew" cssClass="aspTextBox" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNew" runat="server" ControlToValidate="tbNew" Enabled="False" ErrorMessage="Pole wymagane" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNew" runat="server" ControlToValidate="tbNew" Enabled="False" ErrorMessage="Hasło nie może zawierać białych znaków i musi być złożone" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])\S{8,15}$">*</asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="aspLabel" ID="lNewRep" runat="server" Text="Powtórz nowe hasło" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbNewRep" cssClass="aspTextBox" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRepNew" runat="server" ControlToValidate="tbNewRep" Enabled="False" ErrorMessage="Pole wymagane" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbNew" ControlToValidate="tbNewRep" Enabled="False" ErrorMessage="Hasła nie są identyczne" ForeColor="Red">*</asp:CompareValidator>
            </td>
            <td>
                <asp:HiddenField ID="hfKoszyk" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button CssClass="aspButton" ID="btPass" runat="server" Text="Zatwierdź" Visible="False" OnClick="btPass_Click" BorderColor="White"  BorderStyle="Solid" BorderWidth="1px"/>
            </td>
            <td>
                <asp:ValidationSummary ID="vsPass" runat="server" BackColor="Black" ForeColor="White" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label CssClass="aspLabel" ID="lKoszyk" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Table ID="tKoszyk" runat="server">
                    <asp:TableRow runat="server" Font-Bold="True">
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Nr.</asp:TableCell>
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Nazwa</asp:TableCell>
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Cena</asp:TableCell>
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Opis</asp:TableCell>
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Miniaturka</asp:TableCell>
                        <asp:TableCell CssClass="aspLabel" runat="server" Font-Bold="True">Ilość</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                
            </td>
            <td style="text-align: left">
                <asp:Label ID="lPrice" runat="server" Visible="False" ForeColor="White"></asp:Label>
                <asp:Button CssClass="aspButton" ID="bBuy" runat="server" CausesValidation="False" OnClick="bBuy_Click" Text="KUPUJĘ!" BorderColor="White"  BorderStyle="Solid" BorderWidth="1px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    </form>

</body>
</html>
