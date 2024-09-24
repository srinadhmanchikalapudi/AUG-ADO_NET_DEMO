using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Caching;

namespace AUG_ADO_NET_DEMO
{
    public partial class CachingDemo : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Student", con);
                    ds = new DataSet();
                    da.Fill(ds);
                    Cache["Data"] = ds;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                Label1.Text = "Data Loaded from Database";
            }
            else {
                GridView1.DataSource = (DataSet)Cache["Data"];
                GridView1.DataBind();
                Label1.Text = "Data Loaded from Cache";
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null) { 
                Cache.Remove("Data");
            }
        }
    }
}