<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web/Administrator.master" Inherits="TaguroFitnessHost.Web.AddCourse" CodeBehind="AddCourse.aspx.cs" %>


<asp:Content ID="content" ContentPlaceHolderID="siteBody" runat="server">

    <div class="body">
        <h1>Add Course</h1>
        
        <br />
        <br />
        Example:Boxing - Monday - 9-12AM
        <br />
        BOXM1 
        <br />
        <br />
        <asp:Label ID="lblCourseID" runat="server" Text="Course ID: "></asp:Label>
        <asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDay" runat="server" Text="Day: "></asp:Label>
        <asp:TextBox ID="txtDay" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblTime" runat="server" Text="Time: "></asp:Label>
        <asp:TextBox ID="txtTime" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <br />
           <%-- <asp:Button ID="btnAdd" runat="server" Text="ADD"/>--%>
           <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="OnButtonClick" CssClass="button"/>
       </div>

</asp:Content>