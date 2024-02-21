<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminScreen.aspx.cs" Inherits="bitshack.AdminScreen" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="Table1" runat="server" Height="132px" Width="1412px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="displayfromdate" runat="server" Text="From Date"></asp:Label>
                <br />
                <asp:Label ID="displaytodate" runat="server" Text="To Date"></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Label ID="todateLabel" runat="server" Text="Blocked Room"></asp:Label>
            </asp:TableCell>
             <asp:TableCell runat="server" Width="100px">
                 <asp:Button ID="Button1" runat="server" Text="Approve" />
            </asp:TableCell>
            <asp:TableCell runat="server">
                 <asp:Button ID="Button2" runat="server" Text="Reject" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
        </asp:TableRow>
    </asp:Table>
</asp:Content>


