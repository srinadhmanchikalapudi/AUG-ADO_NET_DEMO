using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUG_ADO_WIN_DEMO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string CS = "Data Source=MLBSRL1-106854;Database=test;Integrated Security=True;Connect Timeout=30;";
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP(10) * FROM SALES.CUSTOMERS", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = rdr;
                dataGridView1.DataSource = source;  
            }
        }
    }
}
