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
    public partial class SqlAdapterDemo : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;
        DataSet ds;
        static bool flag = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(!Page.IsPostBack);
            if (!Page.IsPostBack)
            {
                getData();
                GridView1.DataSource = ds.Tables["Student"];
                GridView1.DataBind();
            } 
        }
        public void getData() {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("spGetStudent", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@stdid", TextBox1.Text);

                SqlDataAdapter da1 = new SqlDataAdapter("Select * from Products", con);
                //da.SelectCommand = new SqlCommand("Select * from Student"); 
                ds = new DataSet();

                ds.Tables.Add(new DataTable("Student"));
                ds.Tables.Add(new DataTable("Products"));

                da.Fill(ds.Tables["Student"]);
                da1.Fill(ds.Tables["Products"]);
                
                //Response.Write(ds.Tables.Count);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getData();

            if (flag)
            {
                GridView1.DataSource = ds.Tables["Products"];
                GridView1.DataBind();
                flag = false;
            }
            else {
                GridView1.DataSource = ds.Tables["Student"];
                GridView1.DataBind();
                flag = true;
            }
        }
    }
}