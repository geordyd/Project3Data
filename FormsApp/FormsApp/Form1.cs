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
        //loading in images
        Bitmap img1 = Properties.Resources.johnwilliams_258x210;
        Bitmap img2 = Properties.Resources.paling;
        Bitmap img3 = Properties.Resources.makreel;
        Bitmap img4 = Properties.Resources.snoek;
        Bitmap img5 = Properties.Resources.blobvis;
        

        public Form1()
        {
            InitializeComponent();
            ComboBoxSettings();
            TrackBarSettings();
            SwitchSettings();
            
            //FillChart();
        }

        //connection with database
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
            this.comboBox1.DropDownWidth = 100;
            this.comboBox1.Items.AddRange(new Object[] {
                    "Afrikaanderwijk",
                    "Agniesebuurt"});

            this.comboBox2.DropDownWidth = 100;
            this.comboBox2.Items.AddRange(new object[] {
                    "Afrikaanderwijk",
                    "Agniesebuurt"});

        }

        //ComboBox1 code, show chart
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
            this.chart1.Titles.Add("ComboBox1");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        //ComboBox1 code, show chart
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
            this.chart1.Titles.Add("Combobox1");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        //ComboBox2 code, show chart 
        public void ChartExample3()
        {
            this.chart1.Titles.Clear();
            this.chart1.Series.Clear();

            // Data arrays
            string[] seriesArray = { "Cat", "Dog", "Bird", "Monkey" };
            int[] pointsArray = { 2, 1, 7, 5 };

            // Set palette
            this.chart1.Palette = ChartColorPalette.EarthTones;

            // Set title
            this.chart1.Titles.Add("ComboBox2");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
            var series2 = new Series("Finance");

            series2.ChartType = SeriesChartType.Line;
            series2.Points.DataBindXY(new[] { 5, 7, 2, 1 }, new[] { 3, 5, 2, 1 });
            chart1.Series.Add(series2);
        }

        //ComboBox2 code, show chart
        public void ChartExample4()
        {
            this.chart1.Titles.Clear();
            this.chart1.Series.Clear();

            // Data arrays
            //string[] seriesArray = { "Paling", "Makreel", "Snoek", "Goudvis" };
            //int[] pointsArray = { 10, 3, 6, 1 };

            //// Set palette
            //this.chart1.Palette = ChartColorPalette.Grayscale;

            //// Set title
            //this.chart1.Titles.Add("ComboBox2");

            //// Add series.

            //for (int i = 0; i < seriesArray.Length; i++)
            //{

            //    Series series = this.chart1.Series.Add(seriesArray[i]);
            //    var series = new Series("Finance");

            //    series.ChartType = SeriesChartType.Line;
            //    series.Points.DataBindXY(new[] { 2001, 2002, 2003, 2004 }, new[] { 100, 200, 90, 150 });
            //    series.Points.Add(series);
            //}
            var series = new Series("Finance");

            series.ChartType = SeriesChartType.Line;
            series.Points.DataBindXY(new[] { 2001, 2002, 2003, 2004 }, new[] { 100, 200, 90, 150 });
            chart1.Series.Add(series);
        }


        //combobox1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.comboBox1.SelectedIndex == this.comboBox1.FindStringExact("Afrikaanderwijk"))
            {
                this.comboBox1.BackColor = System.Drawing.Color.Blue;
                ChartExample();
            }
            if (this.comboBox1.SelectedIndex == this.comboBox1.FindStringExact("Agniesebuurt"))
            {
                this.comboBox1.BackColor = System.Drawing.Color.Red;
                ChartExample2();
            }

        }

        //combobox en checkbox combinatie
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Afrikaanderwijk") && !checkBox1.Checked)
            {
                this.comboBox2.BackColor = System.Drawing.Color.Red;
                ChartExample3();

            }
            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Afrikaanderwijk") && checkBox1.Checked)
            {
                this.comboBox2.BackColor = System.Drawing.Color.Blue;
                ChartExample4();

            }
            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Agniesebuurt"))
            {
                this.comboBox2.BackColor = System.Drawing.Color.Red;
                ChartExample4();
            }

        }

        //combobox en checkbox combinatie
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Afrikaanderwijk") && !checkBox1.Checked)
            {
                this.comboBox2.BackColor = System.Drawing.Color.Red;
                ChartExample3();

            }
            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Afrikaanderwijk") && checkBox1.Checked)
            {
                this.comboBox2.BackColor = System.Drawing.Color.Blue;
                ChartExample4();

            }
            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Agniesebuurt"))
            {
                this.comboBox2.BackColor = System.Drawing.Color.Red;
                ChartExample4();
            }
        }

        //show trackbar at start app
        public void TrackBarSettings()
        {
            trackBar1.Minimum = 0;

            trackBar1.Maximum = 4;
        }

        //show value trackbar in textbox when scrolling
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // for debugging only
            //textBox1.Text = trackBar1.Value.ToString();

            SwitchSettings();
        }
        //Switchen van de map

        public void SwitchSettings()
        {
            int caseSwitch = 0;

            caseSwitch = this.trackBar1.Value;

            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    textBox1.Text = "Paling";
                    pictureBox1.Image = img2;
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    textBox1.Text = "Makreel";
                    pictureBox1.Image = img3;
                    break;
                case 3:
                    Console.WriteLine("Case 3");
                    textBox1.Text = "Snoek";
                    pictureBox1.Image = img4;
                    break;
                case 4:
                    Console.WriteLine("Case 4");
                    textBox1.Text = "Blobvis (A.K.A. Raoul)";
                    pictureBox1.Image = img5;
                    break;
                default:
                    Console.WriteLine("Default case");
                    textBox1.Text = "John";
                    pictureBox1.Image = img1;
                    break;
            }
        }
    }
}

