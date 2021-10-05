using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class AddFeedback : System.Web.UI.Page
    {
        int sid; 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                sid = (Int32)Session["user"];
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('You should not be accessing this page')</script>");

            }

        }

        protected void Add_Feedback(object sender, EventArgs e)
        {
            try {
                string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand addFeedbackproc = new SqlCommand("addFeedback", conn);
                addFeedbackproc.CommandType = CommandType.StoredProcedure;
                string comment = Feedback.Text;
                int cid = Int32.Parse(CourseId.Text);
                addFeedbackproc.Parameters.Add(new SqlParameter("@comment", comment));
                addFeedbackproc.Parameters.Add(new SqlParameter("@cid", cid));
                addFeedbackproc.Parameters.Add(new SqlParameter("@sid", sid));
                conn.Open();
                addFeedbackproc.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script> alert('Feedback Added Successfully')</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data')</script>");
            }
        }
        
    }
}