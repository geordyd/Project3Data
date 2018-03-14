using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Additional imports:
using System.Data.SqlClient;
using Npgsql;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void FillChart()
        {
            string connstring = "Server=127.0.0.1; port=5432; User Id=postgres; Password=hallo; Database=test;";
            NpgsqlConnection con = new NpgsqlConnection(connstring);
            DataSet ds = new DataSet();
            con.Open();
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter("Select * from a", con);
            adapt.Fill(ds);
            this.chart1.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series  
            this.chart1.Series["Series1"].XValueMember = "pos";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            this.chart1.Series["Series1"].YValueMembers = "pos";
            this.chart1.Titles.Add("Salary Chart");
            //close connection
            con.Close();

        }
    }
}
