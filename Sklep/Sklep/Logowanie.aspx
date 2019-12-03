<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strona.aspx.cs" Inherits="Sklep.FormularzLogowania" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="shortcut icon" type="image/x-icon" href="~/Images/indeks.jpg" />
    <title></title>

    <style type="text/css">
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
                    <h1 > &nbsp;</h1>
                </td>
                                <td class="menu" >
                    <h1 >
                        &nbsp;</h1>
                </td>


            </tr>

        </table>
        <table class="auto-style1" style="table-layout: fixed">
            
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
                <td style="text-align:center;" class="auto-style5">
                    <asp:Button ID="bLogin" CssClass="aspButton" runat="server" Text="Logowanie" OnClick="bLogin_Click" CausesValidation="False" UseSubmitBehavior="False" BackColor="Black" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" />
                </td>
                <td class="auto-style8"></td>
                <td style="text-align:center;" class="auto-style3">
                    <asp:Button  ID="bRegister" CssClass="aspButton" runat="server" Text="Rejestracja" OnClick="bRegister_Click" CausesValidation="False" UseSubmitBehavior="False" BackColor="Black" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" />
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
                    <asp:Label CssClass="aspLabel" ID="lAuth" runat="server" Text="Podaj kod autoryzacyjny" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="tbAuth" CssClass="aspTextBox" runat="server" Visible="False"></asp:TextBox>
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
                    <asp:Label CssClass="aspLabel" ID="lName" runat="server" Text="Nazwa" Visible="True"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="tbName" runat="server" CssClass="aspTextBox" Visible="True"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbName" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style7">
                    <asp:Label ID="lPassword" CssClass="aspLabel" runat="server" Text="Hasło" Visible="True"></asp:Label>
                </td>
                <td class="auto-style10">
                     <asp:TextBox ID="tbPassword" runat="server" CssClass="aspTextBox" CausesValidation="True" Visible="True" TextMode="Password"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPass" runat="server" ControlToValidate="tbPassword" Display="None" ErrorMessage="Hasło nie może zawierać białych znaków i musi być złożone" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])\S{8,15}$" Enabled="False">*</asp:RegularExpressionValidator>
                </td>
                <td class="auto-style4">
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style4">
                   
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="lRepPass" CssClass="aspLabel" runat="server" Text="Powtórz hasło" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9"> <asp:TextBox ID="tbRepPass" CssClass="aspTextBox" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
                    </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvRepPass" runat="server" ControlToValidate="tbRepPass" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True" Enabled="False">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvPassMatch" runat="server" ControlToValidate="tbRepPass" ErrorMessage="Hasła nie są identyczne" ForeColor="Red" OnServerValidate="cvPassMatch_ServerValidate" Enabled="False">*</asp:CustomValidator></td>
                <td>
                    &nbsp;</td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="lMail" CssClass="aspLabel" runat="server" Text="E-Mail" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="tbMail" CssClass="aspTextBox" runat="server" Visible="False" ></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvMail" runat="server" ControlToValidate="tbMail" ErrorMessage="To pole jest wymagane" ForeColor="Red" SetFocusOnError="True" Enabled="False">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbMail" ErrorMessage="To nie jest prawidłowy adres email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Enabled="False">*</asp:RegularExpressionValidator>
                    <asp:HiddenField ID="hdLogRes" runat="server" Value="0"  />
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
                    <asp:Label ID="lInfo" CssClass="aspLabel" runat="server"></asp:Label>
                </td>
                <td style="text-align:center;" class="auto-style9">
                    <asp:Button ID="bDoLogOrReg" CssClass="aspButton" runat="server" Text="Zaloguj się" OnClick="bDoLogOrReg_Click" Visible="True" BackColor="Black" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" />
                </td>
                <td>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="White" />
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
