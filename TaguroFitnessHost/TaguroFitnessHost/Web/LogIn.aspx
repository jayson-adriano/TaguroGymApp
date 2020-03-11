<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TaguroFitnessHost.Web.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TAGURO FITNESS - ADMIN</title>
</head>
<body>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <form id="form1" runat="server" align="center" >
        <div>
            <h1 class="header1" style="background-color:lightslategrey">TAGURO FITNESS - ADMIN</h1>
            <div class="body-text" style="background-color:lightsteelblue">
                <br />
                Username <asp:TextBox ID="txtBoxLoginUserName" runat="server"></asp:TextBox><br />
                Password <asp:TextBox ID="txtBoxLoginPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <br /><br />
            </div>
        </div>
    </form>
</body>
</html>
