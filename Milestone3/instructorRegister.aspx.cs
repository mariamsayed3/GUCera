using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class instructorRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand instReg = new SqlCommand("InstructorRegister",conn);
            instReg.CommandType = CommandType.StoredProcedure;
            instReg.Parameters.Add(new SqlParameter("@first_name",firstName.Text));
            instReg.Parameters.Add(new SqlParameter("@last_name",lastName.Text));
            instReg.Parameters.Add(new SqlParameter("@password",password.Text));
            instReg.Parameters.Add(new SqlParameter("@email",email.Text));
            instReg.Parameters.Add(new SqlParameter("@gender",gender.SelectedValue));
            instReg.Parameters.Add(new SqlParameter("@address",address.Text));


            conn.Open();
            try
            {
                instReg.ExecuteNonQuery();
                Response.Redirect("Login.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Please Enter Valid Data')</script>");

            }
            conn.Close();

        }
    }
}