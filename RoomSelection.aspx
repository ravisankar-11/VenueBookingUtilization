<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoomSelection.aspx.cs" Inherits="bitshack.RoomSelection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <link href="CSS/RoomSelection.css" rel="stylesheet" />
     <asp:Table ID="Table6" runat="server" Height="40px" Width="1200px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" >
              <asp:Button ID="Button2" runat="server" OnClick="onViewPreviousRequest" Text="View Previous Request" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table5" runat="server" Height="40px" Width="1200px">
        <asp:TableRow runat="server" >
            <asp:TableCell runat="server">
            <center><asp:Label ID="lable6" runat="server" Text="Room booking"></asp:Label></center>
                </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Table ID="Table1" runat="server" Height="200px" Width="1200px">
        <asp:TableRow runat="server" BorderStyle="Ridge">
            <asp:TableCell runat="server">
                <asp:Label ID="lblselectdate" runat="server" Text="Select From Date"></asp:Label>
                <asp:TextBox ID="txtFromDate" runat="server" Height="30px" Width="200px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" Format="MM/dd/yyyy hh:mm tt"></cc1:CalendarExtender>
               
                <asp:TableCell runat="server">
                <asp:Label ID="Label5" runat="server" Text="Select To Date"></asp:Label>
                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate" Format="MM/dd/yyyy hh:mm tt" ></cc1:CalendarExtender>
                </asp:TableCell>
                 <asp:TableCell runat="server">
                  <asp:Label ID="lblhours" runat="server" Text="Total Hours"></asp:Label>
                  <asp:DropDownList ID="DropDownList3" runat="server" Height="35px" Width="200px">
                    <asp:ListItem Value="0">Select the hours</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:DropDownList><br />
                 </asp:TableCell>
                <asp:TableRow runat="server" style="background-color:white">
                    <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server" style="background-color:White">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" OnClick="onSubmitRequest" Text="Check avaliablity" CssClass="smallbutton" Height="45px" Width="150px"/>
                </asp:TableCell>
                    </asp:TableRow>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table3" runat="server" Height="100px" Width="1200px" Visible="false">
        <asp:TableRow runat="server" BorderStyle="Ridge">
            <asp:TableCell runat="server">
                <asp:Label ID="Label1" runat="server" Text="Select Type"></asp:Label><br></br>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="OnRadio_Changed" AutoPostBack="true">
                    <asp:ListItem>Class Room</asp:ListItem>
                    <asp:ListItem>Seminar Hall</asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table><br />
    <asp:Table ID="Table2" runat="server" Height="350px" Width="1200px" Visible="false">
        <asp:TableRow runat="server" BorderStyle="Ridge">
            <asp:TableCell runat="server">
                <asp:Label ID="SelectDepartment" runat="server" Text="Select Department"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
                <asp:DropDownList ID="ddLoadDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddr_OnchageDepartment" Height="35px" Width="200px"></asp:DropDownList><br />
                <br />
               
                <asp:Label ID="lbleventtype" runat="server" Text="EventType"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" Height="35px" Width="200px">
                    <asp:ListItem Value="0">Select EventType</asp:ListItem>
                    <asp:ListItem>Academics</asp:ListItem>
                    <asp:ListItem>Club events</asp:ListItem>
                    <asp:ListItem>Rewards events</asp:ListItem>
                    <asp:ListItem>Meetings</asp:ListItem>
                    <asp:ListItem>others</asp:ListItem>
                </asp:DropDownList><br />
                <br />
                <asp:Label ID="lblreason" runat="server" Text="Reason"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Height="40px" Width="260px"></asp:TextBox><br /><br />
                 <asp:Label ID="lblfacultyincharge" runat="server" Text="Faculty incharge"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Height="40px" Width="260px"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell ID="floorid" runat="server" Visible="true">
                <asp:Label ID="lblselectfloor" runat="server" Text="Select floor"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
                <asp:DropDownList ID="selectfloor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddr_OnChangeSelectFloor" Height="35px" Width="150px"></asp:DropDownList>
                <br /><br />
                <asp:Label ID="lblSpeakerAvail" runat="server" Text="lblSpeakerAvail"></asp:Label><br><br />
                <asp:Label ID="lblProjectorAvail" runat="server" Text="lblProjectorAvail"></asp:Label><br />
                <br />
                 <asp:Label ID="lblcomputeravail" runat="server" Text="lblcomputeravail"></asp:Label><br></br>
               
            </asp:TableCell>
            <asp:TableCell ID="classroomid" runat="server" Visible="true">
                <asp:Label ID="lblclassroom" runat="server" Text="Select Class Room"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
                <asp:DropDownList ID="ddlClassRoom" runat="server" Height="35px" Width="200px" ></asp:DropDownList>
                <br /><br />
                <asp:Label ID="lblStudentDesk" runat="server" Text="lblStudentDesk"></asp:Label><br><br />
                <asp:Label ID="lblCapacity" runat="server" Text="lblCapacity"></asp:Label><br><br />
                <asp:TableRow runat="server" style="background-color:White">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">
                 <asp:Button ID="btnSubmittoCreate" runat="server" Text="Submit" OnClick="btnSubmitCreateRecord" Height="45px" Width="150px" CssClass="smallbutton" />
                </asp:TableCell>
                        </asp:TableRow>
               </asp:TableCell>
        </asp:TableRow>
         </asp:Table><br />

   <%--SEMINAR HALL--%>

   
    <asp:Table ID="Table4" runat="server" Height="200px" Width="1200px" Visible="false">
        <asp:TableRow runat="server" BorderStyle="Ridge">
            <asp:TableCell runat="server">
                <asp:Label ID="Label2" runat="server" Text="Select Block Name"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
                <asp:DropDownList ID="ddLoadBlockname" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddr_OnChangeSelectBlockname" Height="35px" Width="200px"></asp:DropDownList><br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Select floor"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
                <asp:DropDownList ID="selectfloorvalue" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddr_OnChangeSelectSeminarHall" Height="35px" Width="200px"></asp:DropDownList><br />
                <br />
                <asp:Label ID="lbleventtype2" runat="server" Text="EventType"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="200px">
                    <asp:ListItem Value="0">Select EventType</asp:ListItem>
                    <asp:ListItem>Academics</asp:ListItem>
                    <asp:ListItem>Club events</asp:ListItem>
                    <asp:ListItem>Rewards events</asp:ListItem>
                    <asp:ListItem>Meetings</asp:ListItem>
                    <asp:ListItem>others</asp:ListItem>
                </asp:DropDownList><br /><br />
                <asp:Label ID="lblreason1" runat="server" Text="Reason"></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox5" runat="server" Height="40px" Width="260px"></asp:TextBox><br /><br />

                <asp:TableCell runat="server" ID="tblcellSelectNameCapacity">
                    <asp:Label ID="Label4" runat="server" Text="Select Name"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
                <asp:DropDownList ID="ddlselectName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_OnChangeSelectName"  Height="30px" Width="600px"></asp:DropDownList><br>
                    <br>
                    <asp:Label ID="lblSeatingCapacity" runat="server" Text="Seating Capacity"></asp:Label>
                    <br /><br />
                    <asp:Label ID="lblfacultyincharge3" runat="server" Text="Faculty incharge"></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox4" runat="server" Height="40px" Width="260px"></asp:TextBox><br /><br />
                <asp:TableRow runat="server" style="background-color:White">
                    <asp:TableCell runat="server" style="background-color:White"></asp:TableCell>
                    <asp:TableCell runat="server" style="background-color:White">
                    <br /><asp:Button ID="Button3" runat="server" Text="Submit" OnClick="btnSubmitCreateRecordSeminar" Height="45px" Width="150px" CssClass="smallbutton" />
                </asp:TableCell>
                        </asp:TableRow>
                    </asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>