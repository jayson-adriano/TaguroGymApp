<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web/Administrator.master" Inherits="TaguroFitnessHost.Web.AssignCourse" CodeBehind="AssignCourse.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="siteBody" runat="server">

    <div class="body">
        <h1>Assign Course</h1>

        <asp:GridView ID="gridviewAvailableCourses" runat="server" AutoGenerateColumns="true" CssClass="gridview"></asp:GridView>
        <br />
        <br />
        <asp:Label ID="lblCourseID" runat="server" Text="Course_ID: "></asp:Label>
        <asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSelect" runat="server" Text="SELECT" OnClick="OnButtonClick" CssClass="button" />
        <br />

        <h2>Choose Instructor</h2>
        <asp:GridView ID="gridviewAvailableInstructor" runat="server" AutoGenerateColumns="true" CssClass="gridview"></asp:GridView>
        <br />
        <br />
        <asp:Label ID="lblAvailableInstructor" runat="server" Text="Instructor_ID: "></asp:Label>
        <asp:TextBox ID="txtAvailableInstructor" runat="server"></asp:TextBox>
        <br />
          <asp:Button ID="btnAssign" runat="server" Text="ASSIGN" OnClick="OnButtonClick2" CssClass="button"/>
        <br />
    </div>
</asp:Content>
