<%@ Page Language="C#" MasterPageFile="~/Web/Administrator.master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="TaguroFitnessHost.Web.Inventory" %>

<asp:Content ID="content" ContentPlaceHolderID="siteBody" runat="server">


    <div class="body">
        <h1>View Inventory</h1>

        <asp:GridView ID="gridviewSales" runat="server" AutoGenerateColumns="true" CssClass="gridview"></asp:GridView>

    </div>

</asp:Content>
