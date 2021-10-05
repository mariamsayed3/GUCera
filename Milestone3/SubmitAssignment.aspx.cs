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
    public partial class SubmitAssignment : System.Web.UI.Page
    {
        int sid; 
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = (Int32)Session["user"];

        }

        protected void SubmitAssign(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand submitAssignproc = new SqlCommand("submitAssign", conn);
                submitAssignproc.CommandType = CommandType.StoredProcedure;
                conn.Open();
                sid = (Int32)Session["user"];
                string cid = CourseId.Text;
                string asstype = AssignmentType.Text;
                int assnum = Int32.Parse(AssignmentNumber.Text);
                submitAssignproc.Parameters.Add(new SqlParameter("@assignType", asstype));
                submitAssignproc.Parameters.Add(new SqlParameter("@assignnumber", assnum));
                submitAssignproc.Parameters.Add(new SqlParameter("@sid", sid));
                submitAssignproc.Parameters.Add(new SqlParameter("@cid", cid));
                try
                {
                    submitAssignproc.ExecuteNonQuery();
                    Response.Write("<script> alert('Submitted successfully ' ) </script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('This assignment is already submitted or not defined yet ' ) </script>");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data' ) </script>");

            }
        }

       
    }
}