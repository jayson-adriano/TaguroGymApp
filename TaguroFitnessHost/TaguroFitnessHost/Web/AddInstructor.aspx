<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web/Administrator.master" Inherits="TaguroFitnessHost.Web.AddInstructor" CodeBehind="AddInstructor.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="siteBody" runat="server">


    <div class="body">
        <h1>Add Instructor</h1>
        <br />
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="User Name: "></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword2" runat="server" Text="Confirm Password: "></asp:Label>
        <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name: "></asp:Label>
        <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblBday" runat="server" Text="Birthday: "></asp:Label>
        <br />
        Year:
        <asp:DropDownList ID="ddlYear" runat="server"   OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" EnableViewState="True" AppendDataBoundItems="False" AutoPostBack="True"/>
        Month:
        <asp:DropDownList ID="ddlMonth" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" EnableViewState="True" AppendDataBoundItems="True" AutoPostBack="True"/>
        Day:
        <asp:DropDownList ID="ddlDay" runat="server" AppendDataBoundItems="True" AutoPostBack="True"/>
           <br />
        <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
        <asp:DropDownList ID="ddGender" runat="server">
            <asp:ListItem Text="Male" Value="Male" Selected="True" />
            <asp:ListItem Text="Female" Value="Female" />
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email Address: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <%-- <asp:Button ID="btnAdd" runat="server" Text="ADD" />--%>
        <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="OnButtonClick" CssClass="button" />
    </div>

</asp:Content>
