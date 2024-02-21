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
    public partial class Login : System.Web.UI.Page
    {
        System.Data.SqlClient.SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\WORKING SOLUTION\\App_Data\\Bitshacksql.mdf;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    // Use parameterized query to prevent SQL injection
                    SqlCommand cmd = new SqlCommand("SELECT * FROM LoginDetails WHERE EmployeeEmail = @Email AND Password = @Password", con);
                    cmd.Parameters.AddWithValue("@Email", txtemailaddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtpassword.Text.Trim());

                    int result = (int)cmd.ExecuteScalar();

                    if (result == 1)
                    {
                        // Retrieve the user's details from the database
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds.Tables[0].Rows[0]["TypeOfUser"].ToString() == "Lecturer")
                        {
                            // Use URL encoding to pass parameters in the query string
                            string email = HttpUtility.UrlEncode(txtemailaddress.Text.Trim());
                            string name = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["FullName"].ToString());
                            Session["Email"] = email;
                            Session["Name"] = name;
                            Response.Redirect($"~/RoomSelection.aspx");
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