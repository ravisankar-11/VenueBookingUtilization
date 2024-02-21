using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace bitshack
{
    public partial class Adminlogin : System.Web.UI.Page
    {
        System.Data.SqlClient.SqlConnection con;
        protected void Page_Loadd(object sender, EventArgs e)
        {

        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\bitshack_final\\WorkingSOlutionBackup\\App_Data\\Bitshacksql.mdf;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    // Use parameterized query to prevent SQL injection
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Adminlogin WHERE AdminEmail = @AdminEmail AND Password = @Password", con);
                    cmd.Parameters.AddWithValue("@AdminEmail", txtemailaddress1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtpassword1.Text.Trim());

                    int result = (int)cmd.ExecuteScalar();


                    if (result == 1)
                    {
                        // Retrieve the user's details from the database
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds.Tables[0].Rows[0]["Typeofuser"].ToString() == "Admin")
                        {
                            // Use URL encoding to pass parameters in the query string
                            string email = HttpUtility.UrlEncode(txtemailaddress1.Text.Trim());
                            string name = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["Fullname"].ToString());
                            Session["Email"] = email;
                            Session["Name"] = name;
                            Response.Redirect($"~/Admin.aspx");
                        }

                    }
                    else
                    {
                        // Display an error message if login fails
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid email address or password')", true);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or display an error message
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('{ex.Message}')", true);
                }
            }
        }

    }
}