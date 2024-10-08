using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUG_ADO_NET_DEMO
{
    public partial class Demos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP(10) * FROM SALES.CUSTOMERS", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@first_name", "Partha");
                cmd.Parameters.AddWithValue("@last_name", "Bora");
                cmd.Parameters.AddWithValue("@phone", "111111");
                cmd.Parameters.AddWithValue("@email", "Partha@gmail.com");
                cmd.Parameters.AddWithValue("@street", "street");
                cmd.Parameters.AddWithValue("@city", "city");
                cmd.Parameters.AddWithValue("@state", "state");
                cmd.Parameters.AddWithValue("@zip_code", "123");
                

                SqlParameter outParam = new SqlParameter();
                outParam.ParameterName = "@customer_id";
                outParam.SqlDbType = System.Data.SqlDbType.Int;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                con.Open();
                int i = cmd.ExecuteNonQuery();

                string customer_id = outParam.Value.ToString();

                Label1.Text = customer_id + "  " + i;
            }
        }
    }
}