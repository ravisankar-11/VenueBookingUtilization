using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace bitshack
{
    public partial class venuemanagement : System.Web.UI.Page
    {
        public object Label16 { get; private set; }
        public int Classroom { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
                GridView1.Columns[1].HeaderStyle.Width = 10;
                GridView1.Columns[2].HeaderStyle.Width = 10;
                GridView1.Columns[3].HeaderStyle.Width = 10;
                GridView1.Columns[4].HeaderStyle.Width = 10;
                //OnRowCreated = "GridView1_RowCreated"
                // GridView1.
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            Label8.Text = "";
            GridView1.EditRowStyle.BackColor = System.Drawing.Color.Orange;

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            Label8.Text = "";
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool computerAvail = false;
            bool speakerAvail = false;
            bool projectorAvail = false;
            Label Id = GridView1.Rows[e.RowIndex].FindControl("Label18") as Label;
            TextBox Block = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox Floor = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            TextBox ClassroomNo = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
            TextBox ComputerAvailability = GridView1.Rows[e.RowIndex].FindControl("TextBox10") as TextBox;
            if (ComputerAvailability.Text == "True")
            {
                computerAvail = true;
            }

            TextBox SpeakerAvailability = GridView1.Rows[e.RowIndex].FindControl("TextBox12") as TextBox;
            if (SpeakerAvailability.Text == "True")
            {
                speakerAvail = true;
            }
            TextBox ProjectorAvailability = GridView1.Rows[e.RowIndex].FindControl("TextBox14") as TextBox;
            if (ProjectorAvailability.Text == "True")
            {
                projectorAvail = true;
            }
            TextBox StudentDesk = GridView1.Rows[e.RowIndex].FindControl("TextBox5") as TextBox;
            TextBox Capacity = GridView1.Rows[e.RowIndex].FindControl("TextBox16") as TextBox;
            String mycon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            String updatedata = "Update Classrooms set Block='" + Block.Text + "',Floor='" + Floor.Text + "',[Classroom No]='" + ClassroomNo.Text + "',[Computer Availability]='" + computerAvail + "',[Speaker Availability]='" + speakerAvail + "',[Projector Availability]='" + projectorAvail + "',[Student Desk]='" + StudentDesk.Text + "',[Capacity]='" + Capacity.Text + "'where [id]='" + Id.Text + "'";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatedata;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label8.Text = "Row Data Has Been Updated Successfully";
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Label Id = GridView1.FooterRow.FindControl("Label18") as Label;
            TextBox Block = GridView1.FooterRow.FindControl("TextBox6") as TextBox;
            TextBox Floor = GridView1.FooterRow.FindControl("TextBox7") as TextBox;
            TextBox ClassroomNo = GridView1.FooterRow.FindControl("TextBox8") as TextBox;
            TextBox ComputerAvailability = GridView1.FooterRow.FindControl("TextBox11") as TextBox;
            TextBox SpeakerAvailability = GridView1.FooterRow.FindControl("TextBox13") as TextBox;
            TextBox ProjectorAvailability = GridView1.FooterRow.FindControl("TextBox15") as TextBox;
            TextBox StudentDesk = GridView1.FooterRow.FindControl("TextBox9") as TextBox;
            TextBox Capacity = GridView1.FooterRow.FindControl("TextBox1") as TextBox;
            String query = "insert into Classrooms('Block','Floor','[Classroom No]','[Computer Availability]','[Speaker Availability]','[Projector Availability]','[Student Desk]','[Capacity]') values ('" + Block.Text + "'," + Floor.Text + "'," + ClassroomNo.Text + "'," + ComputerAvailability.Text + "'," + SpeakerAvailability.Text + "'," + ProjectorAvailability.Text + "'," + StudentDesk.Text + "'," + Capacity.Text + "')";
            String mycon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label8.Text = "Row Data Has Been Inserted Successfully";
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label Id = GridView1.Rows[e.RowIndex].FindControl("Label17") as Label;
            String mycon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            String updatedata = "delete from classrooms where Id=" + Id.Text;
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatedata;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label8.Text = "Row Data Has Been Deleted Successfully";
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();

        }

        protected void GridView1_RowCreated(object sender, EventArgs e)
        {
            int computerAvail = 0;
            int speakerAvail = 0;
            int projectorAvail = 0;
            //Label Id = GridView1.FooterRow.FindControl("Label18") as Label;
            TextBox Block = GridView1.FooterRow.FindControl("TextBox6") as TextBox;
            TextBox Floor = GridView1.FooterRow.FindControl("TextBox7") as TextBox;
            TextBox ClassroomNo = GridView1.FooterRow.FindControl("TextBox8") as TextBox;
            TextBox ComputerAvailability = GridView1.FooterRow.FindControl("TextBox11") as TextBox;
            if (ComputerAvailability.Text == "True")
            {
                computerAvail = 1;
            }
            TextBox SpeakerAvailability = GridView1.FooterRow.FindControl("TextBox13") as TextBox;
            if (SpeakerAvailability.Text == "True")
            {
                speakerAvail = 1;
            }
            TextBox ProjectorAvailability = GridView1.FooterRow.FindControl("TextBox15") as TextBox;
            if (ProjectorAvailability.Text == "True")
            {
                projectorAvail = 1;
            }
            TextBox StudentDesk = GridView1.FooterRow.FindControl("TextBox9") as TextBox;
            TextBox Capacity = GridView1.FooterRow.FindControl("TextBox16") as TextBox;
            string query = "Insert into Classrooms values('" + Block.Text + "','" + Floor.Text + "','" + ClassroomNo.Text + "'," + computerAvail +
                "," + speakerAvail + "," + projectorAvail + "," + StudentDesk.Text + ",20)";
            //String query = "insert into Classrooms('Block','Floor','[Classroom No]','[Computer Availability]','[Speaker Availability]','[Projector Availability]','[Student Desk]','Capacity') " +
            //    "values " +
            //    "('" + Block.Text + "','" +
            //    Floor.Text + "','" + 
            //    ClassroomNo.Text + "','" + 
            //    computerAvail + "','" + 
            //    speakerAvail + "','" + 
            //    projectorAvail + "','" + 
            //    StudentDesk.Text + "','" + 
            //    20 + "')";
            String mycon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Label8.Text = "Row Data Has Been Inserted Successfully";
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }
    }
}