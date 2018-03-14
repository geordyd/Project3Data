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

using System.Windows.Forms.DataVisualization.Charting;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboBoxSettings();


            //FillChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void FillChart()
        {

            //string connstring = "Server=127.0.0.1; port=5432; User Id=postgres; Password=hallo; Database=test;";
            //NpgsqlConnection con = new NpgsqlConnection(connstring);
            //DataSet ds = new DataSet();
            //con.Open();
            //NpgsqlDataAdapter adapt = new NpgsqlDataAdapter("Select * from a", con);
            //adapt.Fill(ds);
            //this.chart1.DataSource = ds;
            ////set the member of the chart data source used to data bind to the X-values of the series  
            //this.chart1.Series["Series1"].XValueMember = "pos";
            ////set the member columns of the chart data source used to data bind to the X-values of the series  
            //this.chart1.Series["Series1"].YValueMembers = "pos";
            //this.chart1.Titles.Add("Salary Chart");
            ////close connection
            //con.Close();

        }

        public void ComboBoxSettings()
        {
            this.comboBox1.DropDownWidth = 300;
            this.comboBox1.Items.AddRange(new Object[] {"Item 1",
                        "Item 2",
                        "Item 3",
                        "Item 4",
                        "Item 5"});
            this.comboBox2.DropDownWidth = 300;
            this.comboBox2.Items.AddRange(new object[] {"Item 1",
                        "Item 2",
                        "Item 3",
                        "Item 4",
                        "Item 5"});
        }

        public void ChartExample()
        {
            this.chart1.Titles.Clear();
            this.chart1.Series.Clear();

            // Data arrays
            string[] seriesArray = { "Cat", "Dog", "Bird", "Monkey" };
            int[] pointsArray = { 2, 1, 7, 5 };

            // Set palette
            this.chart1.Palette = ChartColorPalette.EarthTones;

            // Set title
            this.chart1.Titles.Add("Animals");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        public void ChartExample2()
        {
            this.chart1.Titles.Clear();
            this.chart1.Series.Clear();

            // Data arrays
            string[] seriesArray = { "Paling", "Makreel", "Snoek", "Goudvis" };
            int[] pointsArray = { 10, 3, 6, 1 };

            // Set palette
            this.chart1.Palette = ChartColorPalette.Grayscale;

            // Set title
            this.chart1.Titles.Add("Animals");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == this.comboBox1.FindStringExact("Item 1"))
            {
                this.comboBox1.BackColor = System.Drawing.Color.Blue;
                ChartExample();
            }
            if (this.comboBox1.SelectedIndex == this.comboBox1.FindStringExact("Item 2"))
            {
                this.comboBox1.BackColor = System.Drawing.Color.Red;
                ChartExample2();
            }

        }
    }
}

