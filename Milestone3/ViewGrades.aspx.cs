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
    public partial class ViewGrades : System.Web.UI.Page
    {
        int sid; 
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = (Int32)Session["user"];

        }

        protected void ViewGrade(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand viewAssignGradesproc = new SqlCommand("viewAssignGrades", conn);
                viewAssignGradesproc.CommandType = CommandType.StoredProcedure;
                sid = (Int32)Session["user"];
                viewAssignGradesproc.Parameters.Add(new SqlParameter("@assignnumber", Int32.Parse(AssignmentNumber.Text)));
                viewAssignGradesproc.Parameters.Add(new SqlParameter("@assignType", AssignmentType.Text));
                viewAssignGradesproc.Parameters.Add(new SqlParameter("@cid", Int32.Parse(CourseId.Text)));
                viewAssignGradesproc.Parameters.Add(new SqlParameter("@sid", sid));
                SqlParameter Grade = viewAssignGradesproc.Parameters.Add(new SqlParameter("@assignGrade", SqlDbType.Decimal));
                Grade.Direction = ParameterDirection.Output;
                conn.Open();
                viewAssignGradesproc.ExecuteNonQuery();
                conn.Close();
                Label grade = new Label();
                grade.Text = Grade.Value.ToString();
                form1.Controls.Add(new Literal { Text = "<p style='color:red'>" + "Your Grade is : " + grade.Text + "</p>" });
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data' ) </script>");
            }
        }
    }
}