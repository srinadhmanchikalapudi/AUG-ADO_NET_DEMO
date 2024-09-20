using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUG_ADO_NET_DEMO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP(10) * FROM SALES.CUSTOMERS", con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    DataTable dt = new DataTable("SALES.CUSTOMERS");
                    dt.Columns.Add("customer_id");
                    dt.Columns.Add("first_name");
                    dt.Columns.Add("last_name");
                    dt.Columns.Add("phone");
                    dt.Columns.Add("email");
                    dt.Columns.Add("street");
                    dt.Columns.Add("city");
                    dt.Columns.Add("state");
                    dt.Columns.Add("zip_code");

                    while (reader.Read()) {
                        DataRow row = dt.NewRow();
                        
                        row["customer_id"] = reader["customer_id"];
                        row["first_name"] = reader["first_name"];
                        row["last_name"] = reader["last_name"];
                        row["phone"] = reader["phone"];
                        row["email"] = reader["email"];
                        row["street"] = reader["street"];
                        row["city"] = reader["city"];
                        row["state"] = reader["state"];
                        row["zip_code"] = reader["zip_code"];

                        dt.Rows.Add(row);
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                };



                #region
                //Reads the top 7 rows 
                //for (int i = 0; i < 7; i++)
                //{
                //    Label1.Text += reader.Read().ToString() + " ";
                //}

                ////while (reader.Read()) {
                ////    Label1.Text += "Read";
                ////}
                //Reads 3 remaining rows 
                //GridView1.DataSource = reader;
                //GridView1.DataBind();
                #endregion
            }
        }
    }
}