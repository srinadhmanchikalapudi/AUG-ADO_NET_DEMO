using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUG_ADO_NET_DEMO
{
    public partial class CommandBuilderDemo : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string fecthStream = "select distinct [stream] from student";
                SqlDataAdapter da1 = new SqlDataAdapter(fecthStream, con);
                DataTable dt = new DataTable("Streams");
                da1.Fill(dt);   

                string query = "Select * from Student where studentid=" + TextBox1.Text;
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                ds = new DataSet();
                da.Fill(ds, "Student");

                ViewState["SQL_QUERY"] = query;
                ViewState["DATASET"] = ds;

                if (ds.Tables["Student"].Rows.Count > 0) {
                    DataRow row = ds.Tables["Student"].Rows[0];
                    TextBox2.Text = row["studentName"].ToString();
                    DropDownList1.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        DataRow dr = dt.Rows[i];
                        DropDownList1.Items.Add(dr[0].ToString());
                    }

                    
                    DropDownList1.DataBind();
                    TextBox3.Text = row["marks"].ToString();
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;    
                    Label1.Text = "No Record Found With The ID = " + TextBox1.Text;
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    DropDownList1.Items.Clear();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                DataSet ds = (DataSet)ViewState["DATASET"];

                if (ds.Tables["Student"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["Student"].Rows[0];
                    dr["studentName"] = TextBox2.Text;
                    dr["marks"] = TextBox3.Text;
                    dr["stream"] = DropDownList1.SelectedValue.ToString();
                }

                int rowsUpdated = da.Update(ds, "Student");
                if (rowsUpdated > 0)
                {
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "No Record Updated = " + rowsUpdated;
                }
                else {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "No Record Updated";
                }
                Label2.Text = builder.GetUpdateCommand().CommandText;
                Label3.Text = builder.GetInsertCommand().CommandText;
                Label4.Text = builder.GetDeleteCommand().CommandText;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Student", con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "Student");

                foreach (DataRow row in ds.Tables["Student"].Rows)
                {
                    if (row["studentId"].ToString() == TextBox1.Text)
                    {
                        ds.Tables["Student"].Rows.Remove(row);
                        break;
                    }
                }

                //DataRow[] rows = ds.Tables["Student"].Select("[studentId] <= " + TextBox1.Text);
                //foreach (DataRow row in rows)
                //{
                //    ds.Tables["Student"].Rows.Remove(row);
                //    break;
                //}

                ds.Tables["Student"].AcceptChanges();
                
                Label1.Text = ds.Tables["Student"].Rows.Count.ToString();
                GridView1.DataSource = ds.Tables["Student"];
                GridView1.DataBind();

                int rowsUpdated = da.Update(ds, "Student");

                if (rowsUpdated > 0)
                {
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "No Record Updated = " + rowsUpdated;
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "No Record Updated";
                }
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Student", con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "Student");

                
                DataRow dr = ds.Tables["Student"].NewRow(); 
                dr["studentName"] = TextBox2.Text;
                dr["marks"] = TextBox3.Text;
                dr["stream"] = DropDownList1.SelectedValue.ToString();
                ds.Tables["Student"].Rows.Add(dr);

                Label1.Text = ds.Tables["Student"].Rows.Count.ToString();

                int rowsUpdated = da.Update(ds, "Student");
                if (rowsUpdated > 0)
                {
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "No Record Updated = " + rowsUpdated;
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "No Record Updated";
                }
            }
        }
    }
}