<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="bitshack.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center;">
        <h2>Login</h2>
        <table style="margin:0 auto;">
            <tr>
                <td>
                    <asp:Label ID="lblemailadd" runat="server" AssociatedControlID="txtemailaddress" Text="Email Address"></asp:Label>
                </td>
                <td style="padding-bottom:10px;">
                    <asp:TextBox ID="txtemailaddress" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtpassword" Text="Password"></asp:Label>
                </td>
                <td style="padding-bottom:10px;">
                    <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>