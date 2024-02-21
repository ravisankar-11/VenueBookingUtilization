<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SideBar.aspx.cs" Inherits="bitshack.SideBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <link href="CSS/Sidebar.css" rel="stylesheet" />
    <div id="sidebar" style="position: fixed; height: 100%;">
    <ul>
        <li><a href="#">Link 1</a></li>
        <li><a href="#">Link 2</a></li>
        <li><a href="#">Link 3</a></li>
    </ul>
</div>
</asp:Content>
