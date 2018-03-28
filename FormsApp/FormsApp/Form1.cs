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
        Bitmap img1 = Properties.Resources.Versie1;
        Bitmap img2 = Properties.Resources.Versie2;
        Bitmap img3 = Properties.Resources.Versie3;
        Bitmap img4 = Properties.Resources.Versie4;
        Bitmap img5 = Properties.Resources.Versie5;

        public Form1()
        {
            InitializeComponent();
            ComboBoxSettings();
            TrackBarSettings();
            SwitchSettings();
            
            //FillChart();
        }
        //connection with database
        public string statement;
        public void FillChart()
        {
            chart1.Titles.Clear();
            chart1.Series[0].Points.Clear();

            

            if (comboBox1.GetItemText(comboBox1.SelectedItem) == comboBox2.GetItemText(comboBox2.SelectedItem))
            {
                chart1.Series[0].Name = comboBox1.GetItemText(comboBox1.SelectedItem) + " Kopie";
            }
            else
            {
                chart1.Series[0].Name = comboBox1.GetItemText(comboBox1.SelectedItem);
            }

            int jaar = trackBar1.Value;
            string selected = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (checkBox1.Checked)
            {
                statement = "SELECT * FROM criminaliteit WHERE wijk = '" + selected + "'  ";
            }
            else if (checkBox2.Checked)
            {
                statement = "SELECT * FROM criminaliteit WHERE wijk = '" + selected + "'  ";
            }
            else if (checkBox3.Checked)
            {
                statement = "SELECT * FROM criminaliteit WHERE wijk = '" + selected + "'  ";
            }
            else if (checkBox3.Checked)
            {
                statement = "SELECT * FROM criminaliteit WHERE wijk = '" + selected + "'  ";
            }
           

            string connstring = "Server=127.0.0.1; port=5432; User Id=postgres; Password=hallo; Database=Database Project;";
            NpgsqlConnection con = new NpgsqlConnection(connstring);
            DataTable ds = new DataTable();
            con.Open();
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(statement, con);
            adapt.Fill(ds);
            chart1.DataSource = ds;

            //close connection
            con.Close();
            foreach (DataRow row in ds.Rows)
            {
                if (checkBox1.Checked)
                {
                    chart1.Series[0].Points.AddXY(row[2], row[1]);
                }
                else if (checkBox2.Checked)
                {
                    chart1.Series[0].Points.AddXY(row[2], row[1]);
                }
                else if (checkBox3.Checked)
                {
                    chart1.Series[0].Points.AddXY(row[2], row[1]);
                }
                else if (checkBox3.Checked)
                {
                    chart1.Series[0].Points.AddXY(row[2], row[1]);
                }
            }

            //set the member of the chart data source used to data bind to the X-values of the series  

            //chart1.Series["Series1"].Points.Add(jaar);
            //    //set the member columns of the chart data source used to data bind to the X-values of the series  
            //    chart1.Series["Series1"].YValueMembers = "emigratietotaal";
            //    chart1.Titles.Add("Salary Chart");



            //textBox1.Text = selected;
            
        }
        
        public void FillChart2()
        {

            chart1.Titles.Clear();
            chart1.Series[1].Points.Clear();
            if (comboBox1.GetItemText(comboBox1.SelectedItem) == comboBox2.GetItemText(comboBox2.SelectedItem))
            {
                chart1.Series[1].Name = comboBox1.GetItemText(comboBox1.SelectedItem) + " Kopie2";
            }
            else
            {
                chart1.Series[1].Name = comboBox2.GetItemText(comboBox2.SelectedItem);
            }
            

            int jaar = trackBar1.Value;
            string selected = comboBox2.GetItemText(comboBox2.SelectedItem);
            //string statement = "SELECT * FROM migratie WHERE wijk = " + "'selected'";
            
            //Statements per checkbox(subgroep)
            if (checkBox1.Checked)
            {
                statement = "SELECT * FROM criminaliteit WHERE wijk = '" + selected + "'  ";
            }
            else if (checkBox2.Checked)
            {
                statement = "SELECT * FROM criminaliteit WHERE wijk = '" + selected + "'  ";
            }
            else if (checkBox3.Checked)
            {
                statement = "SELECT * FROM criminaliteit WHERE wijk = '" + selected + "'  ";
            }
            else if (checkBox3.Checked)
            {
                statement = "SELECT * FROM criminaliteit WHERE wijk = '" + selected + "'  ";
            }

            //string statement = "SELECT * FROM migratie WHERE wijk = 'Rozenburg' AND jaar = 2010";
            string connstring = "Server=127.0.0.1; port=5432; User Id=postgres; Password=hallo; Database=Database Project;";
            NpgsqlConnection con = new NpgsqlConnection(connstring);
            DataTable ds = new DataTable();
            con.Open();
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(statement, con);
            adapt.Fill(ds);
            chart1.DataSource = ds;
            //close connection
            con.Close();
            //set the member of the chart data source used to data bind to the X-values of the series  
            foreach (DataRow row in ds.Rows)
            {
                if (checkBox1.Checked)
                {
                    chart1.Series[1].Points.AddXY(row[2], row[1]);
                }
                else if (checkBox2.Checked)
                {
                    chart1.Series[1].Points.AddXY(row[2], row[1]);
                }
                else if (checkBox3.Checked)
                {
                    chart1.Series[1].Points.AddXY(row[2], row[1]);
                }
                else if (checkBox3.Checked)
                {
                    chart1.Series[1].Points.AddXY(row[2], row[1]);
                }
            }
            //chart1.Series["Series2"].Points.Add(jaar);
            ////set the member columns of the chart data source used to data bind to the X-values of the series  
            //chart1.Series["Series2"].Points.AddY("emigratietotaal");
            //chart1.Titles.Add("Salary Chart");

            textBox1.Text = selected;
            
        }

        //public void AddSeries()
        //{
        //    chart1.Titles.Clear();
        //    chart1.Series.Clear();
        //    if (chart1.Series.IsUniqueName("Series1"))
        //    {
        //        chart1.Series.Add("Series1");
        //    }
        //}

        //public void AddSeries2()
        //{
        //    chart1.Titles.Clear();
        //    chart1.Series.Clear();
        //    if (chart1.Series.IsUniqueName("Series2"))
        //    {
        //        chart1.Series.Add("Series2");
        //    }
        //}

        public void ComboBoxSettings()
        {
            this.comboBox1.DropDownWidth = 100;
            this.comboBox1.Items.AddRange(new Object[] {
                    "Rozenburg",
                    "IJsselmonde",
                    "Hoogvliet",
                    "Noord",
                    "Feijenoord",
                    "Kralingen-Crooswijk",
                    "Pernis",
                    "Hillegersberg-Schiebroek",
                    "Rotterdam Centrum",
                    "Charlois",
                    "Overschie",
                    "Delfshaven",
                    "Prins Alexander",
                    "Hoek van Holland"});
            

            this.comboBox2.DropDownWidth = 100;
            this.comboBox2.Items.AddRange(new object[] {
                    "Rozenburg",
                    "IJsselmonde",
                    "Hoogvliet",
                    "Noord",
                    "Feijenoord",
                    "Kralingen-Crooswijk",
                    "Pernis",
                    "Hillegersberg-Schiebroek",
                    "Rotterdam Centrum",
                    "Charlois",
                    "Overschie",
                    "Delfshaven",
                    "Prins Alexander",
                    "Hoek van Holland"});

        }

        ////ComboBox1 code, show chart
        //public void ChartExample()
        //{
        //    this.chart1.Titles.Clear();
        //    this.chart1.Series.Clear();

        //    // Data arrays
        //    string[] seriesArray = { "Cat", "Dog", "Bird", "Monkey" };
        //    int[] pointsArray = { 2, 1, 7, 5 };

        //    // Set palette
        //    this.chart1.Palette = ChartColorPalette.EarthTones;

        //    // Set title
        //    this.chart1.Titles.Add("ComboBox1");

        //    // Add series.
        //    for (int i = 0; i < seriesArray.Length; i++)
        //    {
        //        Series series = this.chart1.Series.Add(seriesArray[i]);
        //        series.Points.Add(pointsArray[i]);
        //    }
        //}

        ////ComboBox1 code, show chart
        //public void ChartExample2()
        //{
        //    this.chart1.Titles.Clear();
        //    this.chart1.Series.Clear();

        //    // Data arrays
        //    string[] seriesArray = { "Paling", "Makreel", "Snoek", "Goudvis" };
        //    int[] pointsArray = { 10, 3, 6, 1 };

        //    // Set palette
        //    this.chart1.Palette = ChartColorPalette.Grayscale;

        //    // Set title
        //    this.chart1.Titles.Add("Combobox1");

        //    // Add series.
        //    for (int i = 0; i < seriesArray.Length; i++)
        //    {
        //        Series series = this.chart1.Series.Add(seriesArray[i]);
        //        series.Points.Add(pointsArray[i]);
        //    }
        //}

        ////ComboBox2 code, show chart 
        //public void ChartExample3()
        //{
        //    this.chart1.Titles.Clear();
        //    this.chart1.Series.Clear();

        //    // Data arrays
        //    string[] seriesArray = { "Cat", "Dog", "Bird", "Monkey" };
        //    int[] pointsArray = { 2, 1, 7, 5 };

        //    // Set palette
        //    this.chart1.Palette = ChartColorPalette.EarthTones;

        //    // Set title
        //    this.chart1.Titles.Add("ComboBox2");

        //    // Add series.
        //    for (int i = 0; i < seriesArray.Length; i++)
        //    {
        //        Series series = this.chart1.Series.Add(seriesArray[i]);
        //        series.Points.Add(pointsArray[i]);
        //    }
        //    var series2 = new Series("Finance");

        //    series2.ChartType = SeriesChartType.Line;
        //    series2.Points.DataBindXY(new[] { 7, 5, 2, 1 }, new[] { 3, 5, 2, 1 });
        //    chart1.Series.Add(series2);
        //}

        ////ComboBox2 code, show chart
        //public void ChartExample4()
        //{
        //    this.chart1.Titles.Clear();
        //    this.chart1.Series.Clear();

        //    // Data arrays
        //    //string[] seriesArray = { "Paling", "Makreel", "Snoek", "Goudvis" };
        //    //int[] pointsArray = { 10, 3, 6, 1 };

        //    //// Set palette
        //    //this.chart1.Palette = ChartColorPalette.Grayscale;

        //    //// Set title
        //    //this.chart1.Titles.Add("ComboBox2");

        //    //// Add series.

        //    //for (int i = 0; i < seriesArray.Length; i++)
        //    //{

        //    //    Series series = this.chart1.Series.Add(seriesArray[i]);
        //    //    var series = new Series("Finance");

        //    //    series.ChartType = SeriesChartType.Line;
        //    //    series.Points.DataBindXY(new[] { 2001, 2002, 2003, 2004 }, new[] { 100, 200, 90, 150 });
        //    //    series.Points.Add(series);
        //    //}
        //    var series = new Series("Finance");

        //    series.ChartType = SeriesChartType.Line;
        //    series.Points.DataBindXY(new[] { 7, 5, 2, 1 }, new[] { 3, 5, 2, 1 });
        //    chart1.Series.Add(series);
        //}


        //combobox1
        //Combobox1 code
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
            {
                FillChart();
            }
        }

        //combobox2 code
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
            {
                FillChart2();
            }


        }




        //show trackbar at start app
        public void TrackBarSettings()
        {
            trackBar1.Minimum = 2010;

            trackBar1.Maximum = 2016;
        }

        //show value trackbar in textbox when scrolling
        public void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SwitchSettings();
            }

            if (checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
            {
                FillChart();
                FillChart2();
            }
        }

        //Switchen van de map
        public void SwitchSettings()
        {
            int caseSwitch = 0;

            caseSwitch = this.trackBar1.Value;

            switch (caseSwitch)
            {
                case 2013:
                    textBox1.Text = "Map2";
                    pictureBox1.Image = img2;
                    break;
                case 2014:
                    textBox1.Text = "Map3";
                    pictureBox1.Image = img3;
                    break;
                case 2015:
                    textBox1.Text = "Map4";
                    pictureBox1.Image = img4;
                    break;
                //case 4:
                //    textBox1.Text = "Map4";
                //    pictureBox1.Image = img5;
                //    break;
                default:
                    textBox1.Text = "Map1";
                    pictureBox1.Image = img1;
                    break;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.AutoCheck = false;
                checkBox3.AutoCheck = false;
                checkBox4.AutoCheck = false;
            }
            else
            {
                checkBox2.AutoCheck = true;
                checkBox3.AutoCheck = true;
                checkBox4.AutoCheck = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                //chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                //chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                //chart1.Series.Add("Series1");
                trackBar1.Visible = false;
                chart1.ChartAreas[0].AxisX.Title = "Jaar";
                chart1.ChartAreas[0].AxisY.Title = "Aantal Misdrijven";
                FillChart();
                FillChart2();
                checkBox1.AutoCheck = false;
                checkBox3.AutoCheck = false;
                checkBox4.AutoCheck = false;
            }
            else
            {
                trackBar1.Visible = true;
                checkBox1.AutoCheck = true;
                checkBox3.AutoCheck = true;
                checkBox4.AutoCheck = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                chart1.ChartAreas[0].AxisX.Title = "Jaar";
                chart1.ChartAreas[0].AxisY.Title = "Aantal Misdrijven";
                FillChart();
                FillChart2();
                checkBox2.AutoCheck = false;
                checkBox1.AutoCheck = false;
                checkBox4.AutoCheck = false;
            }
            else
            {
                checkBox2.AutoCheck = true;
                checkBox1.AutoCheck = true;
                checkBox4.AutoCheck = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                chart1.ChartAreas[0].AxisX.Title = "Wijk";
                chart1.ChartAreas[0].AxisY.Title = "Aantal Misdrijven";
                FillChart();
                FillChart2();
                checkBox1.AutoCheck = false;
                checkBox2.AutoCheck = false;
                checkBox3.AutoCheck = false;
            }
            else
            {
                checkBox1.AutoCheck = true;
                checkBox2.AutoCheck = true;
                checkBox3.AutoCheck = true;

            }
        }
    }
}

