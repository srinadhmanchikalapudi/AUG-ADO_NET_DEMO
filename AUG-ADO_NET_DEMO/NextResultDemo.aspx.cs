using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUG_ADO_NET_DEMO
{
    public partial class NextResultDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Student;select * from Products;", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader()) { 
                    ProductsGridView.DataSource = rdr;  
                    ProductsGridView.DataBind();
                    while (rdr.NextResult()) {
                        StudentGridView.DataSource = rdr;
                        StudentGridView.DataBind();
                    }
                }
            }
        }
    }
}