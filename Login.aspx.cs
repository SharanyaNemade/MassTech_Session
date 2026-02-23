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
    public partial class Login : System.Web.UI.Page
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
            string user = TextBox1.Text;
            string pass = TextBox2.Text;


            string q = $@"exec sp_Login '{user}','{pass}'";
            SqlCommand cmd = new SqlCommand(q,conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if(rdr.HasRows)
            {
                while (rdr.Read())
                {

                    Session["ActivateUser"] = rdr["username"];

                    if ((rdr["email"].Equals(user) || rdr["username"].Equals(user)) && rdr["password"].Equals(pass) && rdr["role"].Equals("Admin"))
                    {
                        Response.Redirect("AdminPage.aspx");
                    }

                    else
                    {
                        Response.Write("<script>alert(Invalid Crediantials)</script>");
                    }
                }
            }
        }
    }
}