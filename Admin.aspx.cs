using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bitshack
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            string getCommandValues = "Reject";
            if (e.CommandName == "Approve")
            {
                getCommandValues = "Approved";
            }


            int getID = Convert.ToInt32(e.CommandArgument.ToString());
            GridViewRow getValuesFromGrid = GridView1.Rows[getID];
            string getIdtoUpdate = getValuesFromGrid.Cells[0].Text;

            String mycon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True";
            String updatedata = "Update bookingdetails set StatusValue='" + getCommandValues + "'where [id]='" + getIdtoUpdate + "'";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatedata;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            GridView1.DataSource = null;

            GridView1.DataBind();
        }
        protected void RejectOnClick(object sender, EventArgs e)
        {
        }
    }
}