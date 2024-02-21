<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSubmittedRequests.aspx.cs" Inherits="bitshack.ViewSubmittedRequests" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>
            <asp:BoundField DataField="FromDateAndTime" HeaderText="FromDateAndTime" SortExpression="FromDateAndTime"></asp:BoundField>
            <asp:BoundField DataField="ToDateAndTime" HeaderText="ToDateAndTime" SortExpression="ToDateAndTime"></asp:BoundField>
            <asp:BoundField DataField="BookedFloor" HeaderText="BookedFloor" SortExpression="BookedFloor"></asp:BoundField>
            <asp:BoundField DataField="BookedUser" HeaderText="BookedUser" SortExpression="BookedUser"></asp:BoundField>
            <asp:BoundField DataField="BookedRoom" HeaderText="BookedRoom" SortExpression="BookedRoom"></asp:BoundField>
            <asp:BoundField DataField="BookedBlock" HeaderText="BookedBlock" SortExpression="BookedBlock"></asp:BoundField>
            <asp:BoundField DataField="StatusValue" HeaderText="StatusValue" SortExpression="StatusValue"></asp:BoundField>
            <asp:BoundField DataField="EventType" HeaderText="EventType" SortExpression="EventType"></asp:BoundField>
            <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason"></asp:BoundField>
            <asp:BoundField DataField="FacultyIncharge" HeaderText="FacultyIncharge" SortExpression="FacultyIncharge" />
            <asp:BoundField DataField="TypeOfBooking" HeaderText="TypeOfBooking" SortExpression="TypeOfBooking" />
            <asp:BoundField DataField="TotalHours" HeaderText="TotalHours" SortExpression="TotalHours" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [Id], [FromDateAndTime], [ToDateAndTime], [BookedFloor], [BookedUser], [BookedRoom], [BookedBlock], [StatusValue], [EventType], [Reason],[FacultyIncharge],[TypeOfBooking],[TotalHours] FROM [BookingDetails] WHERE ([BookedUserEmail] = @BookedUserEmail) ORDER BY [FromDateAndTime] DESC">
        <SelectParameters>
            <%--<asp:Parameter DefaultValue="demo@gmail.com" Name="BookedUserEmail" Type="String"></asp:Parameter>--%>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
