using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bitshack
{
    public partial class ViewSubmittedRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //https://localhost:44376/ViewSubmittedRequests?Parameter=demo@gmail.com
                
                SqlDataSource1.SelectParameters.Add("BookedUser", (string)Session["Email"].ToString().Replace("%40", "@"));
                SqlDataSource1.SelectParameters.Add("BookedUserEmail", (string)Session["Email"].ToString().Replace("%40", "@"));
                GridView1.DataBind();
            }
        }
    }
}