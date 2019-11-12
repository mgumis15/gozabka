<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strona.aspx.cs" Inherits="Sklep.FormularzLogowania" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1" style="table-layout: fixed">
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
                <td class="auto-style5">
                    <asp:Button ID="bLogin" runat="server" Text="Logowanie" OnClick="bLogin_Click" CausesValidation="False" UseSubmitBehavior="False" />
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style3">
                    <asp:Button ID="bRegister" runat="server" Text="Rejestracja" OnClick="bRegister_Click" CausesValidation="False" UseSubmitBehavior="False" />
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="lAuth" runat="server" Text="Podaj kod autoryzacyjny" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="tbAuth" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>

                </td>
                <td>
                    <br />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="lName" runat="server" Text="Nazwa" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="tbName" runat="server" Visible="False">wee se drwesr</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbName" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style7">
                    <asp:Label ID="lPassword" runat="server" Text="Hasło" Visible="False"></asp:Label>
                </td>
                <td class="auto-style10">
                     <asp:TextBox ID="tbPassword" runat="server" CausesValidation="True" Visible="False" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPass" runat="server" ControlToValidate="tbPassword" Display="None" ErrorMessage="Hasło nie może zawierać białych znaków" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])\S{8,15}$">*</asp:RegularExpressionValidator>
                </td>
                <td class="auto-style4"></td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style4">
                   
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="lRepPass" runat="server" Text="Powtórz hasło" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9"> <asp:TextBox ID="tbRepPass" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRepPass" runat="server" ControlToValidate="tbRepPass" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvPassMatch" runat="server" ControlToValidate="tbRepPass" ErrorMessage="Hasła nie są identyczne" ForeColor="Red" OnServerValidate="cvPassMatch_ServerValidate">*</asp:CustomValidator></td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="lMail" runat="server" Text="E-Mail" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="tbMail" runat="server" Visible="False" >w@w.pl</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMail" runat="server" ControlToValidate="tbMail" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbMail" ErrorMessage="To nie jest prawidłowy adres email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:HiddenField ID="hdLogRes" runat="server" Value="1" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="lInfo" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="bDoLogOrReg" runat="server" Text="Zarejestruj się" OnClick="bDoLogOrReg_Click" Visible="False" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
</body>
</html>
