<%@ Page Title="Adminlogin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adminlogin.aspx.cs" Inherits="bitshack.Adminlogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/Login.css" rel="stylesheet" />
    <div style="text-align:center;">
        <br /><br /><br /><br /><br />
          <br /><br /><br /><br /><br />
         <br /><br />
       
        <h2>AdminLogin</h2>
       <center> <table style="margin:0 auto;">
            <tr>
                <td>
                    <asp:Label ID="lblemailadd1" runat="server" AssociatedControlID="txtemailaddress1" Text="Email Address"></asp:Label>
                </td>
                <td style="padding-bottom:10px;">
                    <asp:TextBox ID="txtemailaddress1" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword1" runat="server" AssociatedControlID="txtpassword1" Text="Password"></asp:Label>
                </td>
                <td style="padding-bottom:10px;">
                    <asp:TextBox ID="txtpassword1" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table></center>
        <asp:Button ID="btnSubmit1" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="btnSubmit1_Click" />
    </div>
    <br /> <br /><br /><br /><br /><br />
          <br /><br /><br /><br /><br />
         <br /><br />

</asp:Content>
