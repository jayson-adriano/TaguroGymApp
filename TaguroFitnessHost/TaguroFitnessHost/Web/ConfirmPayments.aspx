<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web/Administrator.master" Inherits="TaguroFitnessHost.Web.ConfirmPayments" CodeBehind="ConfirmPayments.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="siteBody" runat="server">


    <div class="body">
        <h1>Confirm Payments</h1>
        
        <asp:GridView ID="gridviewConfirmPayments" runat="server" AutoGenerateColumns="true" CssClass="gridview"></asp:GridView>
        <br />
        <br />
        <asp:Label ID="lblCustID" runat="server" Text="Sales_ID: "></asp:Label>
        <asp:TextBox ID="txtCustID" runat="server"></asp:TextBox>
        <br />
            <%--<asp:Button ID="btnConfirm" runat="server" Text="CONFIRM"/>--%>
            <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClick="OnButtonClick" CssClass="button"/>
        
       </div>

</asp:Content>