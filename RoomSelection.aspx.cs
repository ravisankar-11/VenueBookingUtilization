using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace bitshack
{
    public partial class RoomSelection : System.Web.UI.Page
    {
        System.Data.SqlClient.SqlConnection con;
        string Email = string.Empty;
        string Name = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Email = (string)Session["Email"];
            Name = (string)Session["Name"];
            if (!this.IsPostBack)
            {
                btnSelectedDate_Click(sender, e);
                con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
                con.Open();
                DataTable departments = new DataTable();
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("select distinct(Block) from Classrooms", con);
                    adapter.Fill(departments);
                    ddLoadDepartment.DataSource = departments;
                    ddLoadDepartment.DataTextField = "Block";
                    ddLoadDepartment.DataBind();
                }
                catch (Exception ex)
                {
                }
                con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
                con.Open();
                DataTable blockname = new DataTable();
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("select distinct([Block Name]) from SeminarHallDetails", con);
                    adapter.Fill(blockname);
                    ddLoadBlockname.DataSource = blockname;
                    ddLoadBlockname.DataTextField = "Block Name";
                    ddLoadBlockname.DataBind();
                }
                catch (Exception ex)
                {
                }
                con.Close();
            }

        }

        protected void OnRadio_Changed(object sender, EventArgs e)
        {
            string getRaidoButtonSelection = RadioButtonList1.SelectedItem.Value;
            if (getRaidoButtonSelection == "Class Room")
            {
                Table2.Visible = true;
                ddr_OnchageDepartment(sender, e);
                Table4.Visible = false;
            }
            else
            {
                Table2.Visible = false;
                Table4.Visible = true;
                ddr_OnChangeSelectBlockname(sender, e);
            }
        }

        protected void ddr_OnChangeSelectSeminarHall(object sender, EventArgs e)
        {
            //if (todateLabel.Text != "Select To Date" && displayLabelDate.Text != "Select From Date")
            //{
            if (con == null)
            {
                con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
                con.Open();
            }
            DataTable loadClassValue = new DataTable();
            SqlDataAdapter loadClass = new SqlDataAdapter("select Name from SeminarHallDetails where [Block Name]='" + ddLoadBlockname.SelectedValue + "' and Floor ='" + selectfloorvalue.SelectedValue + "'", con);
            loadClass.Fill(loadClassValue);
            ddlselectName.DataSource = loadClassValue;
            ddlselectName.DataTextField = "Name";
            ddlselectName.DataBind();
            con.Close();
            ddl_OnChangeSelectName(sender, e);
            //}
        }
        protected void ddl_OnChangeSelectName(object sender, EventArgs e)
        {
            if (con == null)
            {
                con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
                con.Open();
            }
            SqlCommand getValuestoFillLabel = new SqlCommand("select * from SeminarHallDetails where [Block Name]='" + ddLoadBlockname.SelectedValue + "' and Floor ='" + selectfloorvalue.SelectedValue + "' and Name='" + ddlselectName.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(getValuestoFillLabel);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lblSeatingCapacity.Text = "Seating Capacity : " + ds.Tables[0].Rows[0]["Seating Capacity"].ToString() + " </b>";
            con.Close();
        }
        //ddr_OnchageDepartment
        protected void ddr_OnChangeSelectFloor(object sender, EventArgs e)
        {
            if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
            {
                classroomid.Visible = true;
                con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
                con.Open();
                DataTable loadClassValue = new DataTable();
                SqlDataAdapter loadClass = new SqlDataAdapter("select [Classroom No] from Classrooms where Block = '" + ddLoadDepartment.SelectedValue + "' and Floor = '" + selectfloor.SelectedValue + "'", con);
                loadClass.Fill(loadClassValue);
                ddlClassRoom.DataSource = loadClassValue;
                ddlClassRoom.DataTextField = "Classroom No";
                ddlClassRoom.DataBind();
                SqlCommand reloadClass = new SqlCommand("select * from BookingDetails where FromDateAndTime >= '" + (txtFromDate.Text.Replace("From Date : ", "")) + "' and ToDateAndTime<='" + (txtToDate.Text.Replace("To Date : ", "")) + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(reloadClass);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                    {
                        ddlClassRoom.Items.Remove(ddlClassRoom.Items.FindByValue(ds.Tables[i].Rows[i]["BookedRoom"].ToString()));
                    }
                }
                loadLabelValues(sender, e);

                con.Close();
            }

        }

        protected void loadLabelValues(object sender, EventArgs e)
        {
            if (selectfloor.SelectedValue != "")
            {
                con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
                con.Open();
                SqlCommand getValuestoFillLabel = new SqlCommand("select * from Classrooms where Block = '" + ddLoadDepartment.SelectedValue + "' and Floor = '" + selectfloor.SelectedValue + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(getValuestoFillLabel);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows[0]["Computer Availability"].ToString() == "True")
                {
                    lblcomputeravail.Text = "Computer Availability : Yes </b>";
                }
                else
                {
                    lblcomputeravail.Text = "Computer Availability : No";
                }

                if (ds.Tables[0].Rows[0]["Speaker Availability"].ToString() == "True")
                {
                    lblSpeakerAvail.Text = "Speaker Availability : Yes </b>";
                }
                else
                {
                    lblSpeakerAvail.Text = "Speaker Availability : No </b>";
                }

                if (ds.Tables[0].Rows[0]["Speaker Availability"].ToString() == "True")
                {

                    lblProjectorAvail.Text = "Projector Availability : Yes</b>";
                }
                else
                {
                    lblProjectorAvail.Text = "Projector Availability : No </b>";
                }

                lblStudentDesk.Text = "Student Desk : " + ds.Tables[0].Rows[0]["Student Desk"].ToString() + "</b>";
                lblCapacity.Text = "Capacity : " + ds.Tables[0].Rows[0]["Capacity"].ToString() + "</b>";
                con.Close();
            }
        }

        //ddr_OnchageDepartment
        protected void ddr_OnchageDepartment(object sender, EventArgs e)
        {
            floorid.Visible = true;
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            con.Open();
            DataTable loadFloorValue = new DataTable();
            SqlDataAdapter loadFloor = new SqlDataAdapter("select distinct(floor) from Classrooms where Block='" + ddLoadDepartment.SelectedValue + "'", con);
            loadFloor.Fill(loadFloorValue);
            selectfloor.DataSource = loadFloorValue;
            selectfloor.DataTextField = "Floor";
            selectfloor.DataBind();
            con.Close();
            ddr_OnChangeSelectFloor(sender, e);
        }
        protected void ddr_OnChangeSelectBlockname(object sender, EventArgs e)
        {
            floorid.Visible = true;
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            con.Open();
            DataTable loadFloorValue = new DataTable();
            SqlDataAdapter loadFloor = new SqlDataAdapter("select distinct(floor) from SeminarHallDetails where [Block Name]='" + ddLoadBlockname.SelectedValue + "'", con);
            loadFloor.Fill(loadFloorValue);
            selectfloorvalue.DataSource = loadFloorValue;
            selectfloorvalue.DataTextField = "Floor";
            selectfloorvalue.DataBind();
            ddr_OnChangeSelectSeminarHall(sender, e);
            con.Close();
        }

        protected void btnSelectedDate_Click(object sender, EventArgs e)
        {
            //datePicker.Visible = !datePicker.Visible;
        }

        protected void btnToSelectedDate_Click(object sender, EventArgs e)
        {
            //toDatePicker.Visible = !datePicker.Visible;
        }

        protected void datepicker_SelectionChanged(object sender, EventArgs e)
        {
            //string concatDate = datePicker.SelectedDate.Month + "/" + datePicker.SelectedDate.Day + "/" + datePicker.SelectedDate.Year +
            //  " " + ddrhour.SelectedValue + ":" + ddrmin.SelectedValue + ":00 " + ddrampm.SelectedValue;
            ////DateTime tempDate = Convert.ToDateTime(concatDate);
            //DateTime dt;
            //if (DateTime.TryParseExact(concatDate, "MM/dd/yyyy hh:mm:ss tt",
            //               CultureInfo.InvariantCulture, DateTimeStyles.None,
            //               out dt))
            //{

            //    displayLabelDate.Text = "From Date : " + dt.ToString();
            //    datePicker.Visible = false;
            //    Table3.Visible = true;
            //    ddr_OnChangeSelectFloor(sender, e);
            //}
        }

        protected void todatepicker_SelectionChanged(object sender, EventArgs e)
        {
            //string concatDate = toDatePicker.SelectedDate.Month + "/" + toDatePicker.SelectedDate.Day + "/" + toDatePicker.SelectedDate.Year +
            //    " " + toddrhour.SelectedValue + ":" + toddrmin.SelectedValue + ":00 " + toddrampm.SelectedValue;
            ////DateTime tempDate = Convert.ToDateTime(concatDate);
            //DateTime dt;
            //if (DateTime.TryParseExact(concatDate, "MM/dd/yyyy hh:mm:ss tt",
            //               CultureInfo.InvariantCulture, DateTimeStyles.None,
            //               out dt))
            //{
            //    todateLabel.Text = "To Date : " + dt.ToString();
            //    toDatePicker.Visible = false;
            //    Table3.Visible = true;
            //    ddr_OnChangeSelectFloor(sender, e);
            //}
        }

        protected void onSubmitRequest(object sender, EventArgs e)
        {
            Table3.Visible = true;
            ddr_OnChangeSelectFloor(sender, e);
        }

        protected void onViewPreviousRequest(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewSubmittedRequests.aspx");
        }

        protected void btnSubmitCreateRecord(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            con.Open();

            string query = "INSERT INTO BookingDetails (FromDateAndTime, ToDateAndTime, BookedUser, BookedFloor, BookedRoom,  BookedBlock,BookedUserEmail,StatusValue,FullName,EventType,Reason,FacultyIncharge,TypeOfBooking, TotalHours)";
            query += " VALUES (@FromDateAndTime, @ToDateAndTime, @BookedUser, @BookedFloor, @BookedRoom, @BookedBlock,@BookedUserEmail,@StatusValue,@FullName,@EventType,@Reason,@FacultyIncharge,@TypeOfBooking, @TotalHours)";

            SqlCommand myCommand = new SqlCommand(query, con);

            myCommand.Parameters.AddWithValue("@FromDateAndTime", DateTime.Parse(txtFromDate.Text.Replace("From Date : ", "")));
            myCommand.Parameters.AddWithValue("@ToDateAndTime", DateTime.Parse(txtToDate.Text.Replace("To Date : ", "")));
            myCommand.Parameters.AddWithValue("@BookedUser", Email.Replace("%40", "@"));
            myCommand.Parameters.AddWithValue("@BookedFloor", selectfloor.SelectedValue);
            myCommand.Parameters.AddWithValue("@BookedRoom", ddlClassRoom.SelectedValue);
            myCommand.Parameters.AddWithValue("@BookedBlock", ddLoadDepartment.SelectedValue);
            myCommand.Parameters.AddWithValue("@BookedUserEmail", Email.Replace("%40", "@"));
            myCommand.Parameters.AddWithValue("@StatusValue", "In-Progress");
            myCommand.Parameters.AddWithValue("@FullName", Name);
            myCommand.Parameters.AddWithValue("@EventType", DropDownList2.Text);
            myCommand.Parameters.AddWithValue("@Reason", TextBox1.Text);
            myCommand.Parameters.AddWithValue("@FacultyIncharge", TextBox2.Text);
            myCommand.Parameters.AddWithValue("@TypeOfBooking", RadioButtonList1.SelectedValue);
            myCommand.Parameters.AddWithValue("@TotalHours", DropDownList3.SelectedValue);
            myCommand.ExecuteNonQuery();



            Response.Redirect("~/SubmittedSuccessForm.aspx");

        }

        protected void btnSubmitCreateRecordSeminar(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            con.Open();

            string query = "INSERT INTO BookingDetails (FromDateAndTime, ToDateAndTime, BookedUser, BookedFloor, BookedRoom,  BookedBlock,BookedUserEmail,StatusValue,FullName,EventType,Reason,FacultyIncharge,SeatingCapacity,TypeOfBooking,TotalHours)";
            query += " VALUES (@FromDateAndTime, @ToDateAndTime, @BookedUser, @BookedFloor, @BookedRoom, @BookedBlock,@BookedUserEmail,@StatusValue,@FullName,@EventType,@Reason,@FacultyIncharge,@SeatingCapacity,@TypeOfBooking, @TotalHours)";

            SqlCommand myCommand = new SqlCommand(query, con);

            myCommand.Parameters.AddWithValue("@FromDateAndTime", DateTime.Parse(txtFromDate.Text.Replace("From Date : ", "")));
            myCommand.Parameters.AddWithValue("@ToDateAndTime", DateTime.Parse(txtToDate.Text.Replace("To Date : ", "")));
            myCommand.Parameters.AddWithValue("@BookedUser", Email.Replace("%40", "@"));
            myCommand.Parameters.AddWithValue("@BookedFloor", selectfloorvalue.SelectedValue);
            myCommand.Parameters.AddWithValue("@BookedRoom", ddlselectName.SelectedValue);
            myCommand.Parameters.AddWithValue("@BookedBlock", ddLoadBlockname.SelectedValue);
            myCommand.Parameters.AddWithValue("@BookedUserEmail", Email.Replace("%40", "@"));
            myCommand.Parameters.AddWithValue("@StatusValue", "In-Progress");
            myCommand.Parameters.AddWithValue("@FullName", Name);
            myCommand.Parameters.AddWithValue("@SeatingCapacity", lblSeatingCapacity.Text);
            myCommand.Parameters.AddWithValue("@EventType", DropDownList1.SelectedValue);
            myCommand.Parameters.AddWithValue("@Reason", TextBox5.Text);
            myCommand.Parameters.AddWithValue("@FacultyIncharge", TextBox4.Text);
            myCommand.Parameters.AddWithValue("@TypeOfBooking", RadioButtonList1.SelectedValue);
            myCommand.Parameters.AddWithValue("@TotalHours", DropDownList3.SelectedValue);
            myCommand.ExecuteNonQuery();



            Response.Redirect("~/SubmittedSuccessForm.aspx");

        }
    }
}
