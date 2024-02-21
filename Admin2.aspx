<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin2.aspx.cs" Inherits="bitshack.WebForm1" %>
<a href="Admin.aspx">Admin.aspx</a>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
         <center> 
             <h1>WELCOME ADMIN</h1>
             <p>BOOKING DETAILS</p>
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                 DataKeyNames="Id" DataSourceID="SqlDataSource1" GridLines="None" ForeColor="#333333">
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                     <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                     <asp:BoundField DataField="FromDateAndTime" HeaderText="FromDateAndTime" SortExpression="FromDateAndTime" />
                     <asp:BoundField DataField="ToDateAndTime" HeaderText="ToDateAndTime" SortExpression="ToDateAndTime" />
                     <asp:BoundField DataField="BookedUser" HeaderText="BookedUser" SortExpression="BookedUser" />
                     <asp:BoundField DataField="BookedFloor" HeaderText="BookedFloor" SortExpression="BookedFloor" />
                     <asp:BoundField DataField="BookedRoom" HeaderText="BookedRoom" SortExpression="BookedRoom" />
                     <asp:BoundField DataField="BookedBlock" HeaderText="BookedBlock" SortExpression="BookedBlock" />
                     <asp:BoundField DataField="BookedUserEmail" HeaderText="BookedUserEmail" SortExpression="BookedUserEmail" />
                     <asp:BoundField DataField="StatusValue" HeaderText="StatusValue" SortExpression="StatusValue" />
                     <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
                 </Columns>
                 <%--<FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />--%>
                 <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

                 <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>

                 <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

                 <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>

                 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

                 <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

                 <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

                 <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

                 <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
             </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [BookingDetails]"></asp:SqlDataSource></center>  
            
        </div>
    </form>
</body>
</html>
