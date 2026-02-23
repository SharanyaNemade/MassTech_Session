using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auth
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string username = TextBox2.Text;
            string password = TextBox3.Text;
            string role = DropDownList1.SelectedValue;



            string q = $@"exec sp_SaveUsers
                '{email}','{username}','{password}','{role}'";
                
                SqlCommand cmd = new SqlCommand(q,conn);
                cmd.ExecuteNonQuery();

            Response.Write("<script>alert('TIcket Raised Successfully')</script>");
        }
    }
}