<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Helloworld.aspx.cs" Inherits="Lab_25_ASP_First_Website.Helloworld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Hello World</h1>

    <ul>
        <li>One</li>
                <li>Two</li>
                <li>Three2</li>

    </ul>
    <asp:Label ID="Label1" runat="server" Text="Label">This is a label</asp:Label>
    <br />
    <asp:TextBox ID="TextBox1" runat="server">This is a text box </asp:TextBox>
        <br />
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" />


<%--    <form method=" get" action =" processdat,cs " >

        FirstName <input type="text" placeholder="type here" name="firstname" />
                  <button--%>



<%--    </form>--%>
</asp:Content>
