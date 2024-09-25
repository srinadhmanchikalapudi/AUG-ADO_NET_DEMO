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
    public partial class WebForm2 : System.Web.UI.Page
    {
        static string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                BindData();
            }

        }
        protected void BindData() {
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
    }
}