<%@  Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="bitshack.Admin" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <link href="SideBar.css" rel="stylesheet" />
    <div id="sidebar" style="position: fixed; height: 100%;">
    <ul>
        <li><a href="#">Link 1</a></li>
        <br />
        <br />
        <br />
        <li><a href="venuemanagement.aspx"><i class="fa fa-qrcode">Venue Management</i></a></li>
        <br />
        <br />
        <br />
      <li><a href="Utilization.aspx"><i class="fa fa-qrcode">Venue Utilization</i></a></li>

    </ul>
</div><right>
  <div id="main">
      <br />
      <br />
      <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1Value" 
        AllowCustomPaging="True" AllowPaging="True" OnRowCommand="GridView1_SelectedIndexChanged" ForeColor="Black" DataKeyNames="Id" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="4">
        <Columns>

            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" ItemStyle-Width="50px">
<ItemStyle Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FromDateAndTime" HeaderText="FromDate_Time" SortExpression="FromDateAndTime" />
            <asp:BoundField DataField="ToDateAndTime" HeaderText="ToDate_Time" SortExpression="ToDateAndTime" />
            <asp:BoundField DataField="TypeOfBooking" HeaderText="TypeOfBooking" SortExpression="TypeOfBooking" />
            <asp:BoundField DataField="BookedUser" HeaderText="BookedUser" SortExpression="BookedUser" />
            <asp:BoundField DataField="BookedFloor" HeaderText="Floor" SortExpression="BookedFloor" />
            <asp:BoundField DataField="BookedRoom" HeaderText="Room" SortExpression="BookedRoom" />
            <asp:BoundField DataField="BookedBlock" HeaderText="BookedBlock" SortExpression="BookedBlock" />
            <asp:BoundField DataField="EventType" HeaderText="EventType" SortExpression="EventType" />
            <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
            <asp:BoundField DataField="FacultyIncharge" HeaderText="FacultyIncharge" SortExpression="FacultyIncharge" />
            <asp:BoundField DataField="TypeOfBooking" HeaderText="TypeOfBooking" SortExpression="TypeOfBooking" />
            <asp:TemplateField HeaderText="Operations">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" CommandName="Approve" runat="server" CommandArgument="<%# Container.DataItemIndex %>">Approve</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Operations">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" CommandName="Reject" runat="server" CommandArgument="<%# Container.DataItemIndex %>">Reject</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            

        </Columns>
        <HeaderStyle Width="325px" BackColor="Black" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource runat="server" ID="SqlDataSource1Value" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [BookingDetails] WHERE ([StatusValue] = @StatusValue)">
        <SelectParameters>
            <asp:Parameter DefaultValue="In-Progress" Name="StatusValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div></right>
</asp:Content>
