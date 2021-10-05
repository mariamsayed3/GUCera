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
    public partial class ViewCertificates : System.Web.UI.Page
    {
        int sid; 
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = (Int32)Session["user"];

        }

        protected void ViewCertificate(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Gucera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewCertificateproc = new SqlCommand("viewCertificate", conn);
            viewCertificateproc.CommandType = CommandType.StoredProcedure;
            conn.Open();
             sid = (Int32)Session["user"];
            string cid = CourseId.Text;
            if (cid == "")
            {
                Response.Redirect("ViewCertificates.aspx");

            }
            else
            {
                try
                {
                    viewCertificateproc.Parameters.Add(new SqlParameter("@cid", cid));
                    viewCertificateproc.Parameters.Add(new SqlParameter("@sid", sid));
                    SqlDataReader rdr = viewCertificateproc.ExecuteReader(CommandBehavior.CloseConnection);
                    //  Response.Redirect("Assignments.aspx");
                    int k = 0;

                    while (rdr.Read())
                    {
                        if (k == 0)
                        {
                            table.Append("<table border = '1'>");
                            table.Append("<tr> <th> Student ID </th> <th> Course ID  </th> <th> Issue Date </th> </tr>");
                        }
                        int studentid = (Int32)rdr[0];
                        int courseid = (Int32)rdr[1];
                        DateTime time = (DateTime)rdr[2];
                        table.Append("<tr>");
                        table.Append("<td>" + studentid + "</td>");
                        table.Append("<td>" + courseid + "</td>");
                        table.Append("<td>" + time + "</td>");
                        table.Append("</tr>");
                        k++;

                    }
                    if (k == 0)
                    {
                        table.Append("You have no certifications in this course ");
                    }
                    form1.Controls.Add(new Literal { Text = table.ToString() });
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('Please Enter Valid Data' ) </script>");

                }


            }
        }
    }
}