<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web/Administrator.master" Inherits="TaguroFitnessHost.Web.RemoveCourse" CodeBehind="RemoveCourse.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="siteBody" runat="server">
    
    <div class="body">
        <h1>Remove Course</h1>
        
        <asp:GridView ID="gridviewRemoveCourse" runat="server" AutoGenerateColumns="true" CssClass="gridview"></asp:GridView>
        <br />
        <br />
        <asp:Label ID="lblCourseID" runat="server" Text="Course_ID: "></asp:Label>
        <asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>
        <br />
            <asp:Button ID="btnRemove" runat="server" Text="REMOVE" OnClick="OnButtonClick" CssClass="button"/>
        
       
    </div>

</asp:Content>