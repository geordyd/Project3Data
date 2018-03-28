﻿using System;
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
        public void FillChart()
        {
            chart1.Titles.Clear();
            chart1.Series[0].Points.Clear();
            
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;



            /*if (checkBox4.Checked)
                {
                    ChartAxis secYAxis = new ChartAxis();
                    chartControl1.Axes.Add(secYAxis);
                    chartControl1.Series[0].YAxis = secYAxis;
                    chartControl1.Series[1].YAxis = secYAxis;
                    chartControl1.secYAxis.OpposedPosition = true;
                }
        */


            //if (comboBox1.GetItemText(comboBox1.SelectedItem) == comboBox2.GetItemText(comboBox2.SelectedItem))
            //{
            //    chart1.Series[0].Name = comboBox1.GetItemText(comboBox1.SelectedItem) + " Kopie";
            //}
            //else
            //{
            //    chart1.Series[0].Name = comboBox1.GetItemText(comboBox1.SelectedItem);
            //}

            int jaar = trackBar1.Value;
            string selected = comboBox1.GetItemText(comboBox1.SelectedItem);

            string statement = "SELECT DISTINCT leeftijd.wijk, leeftijd.gem_leeftijd, leeftijd.jaar, inkomen.gemiddeld_inkomen FROM leeftijd, inkomen WHERE leeftijd.jaar = inkomen.jaar AND leeftijd.wijk = inkomen.wijk AND leeftijd.wijk ='" + selected + "' and inkomen.jaar =" + jaar ;

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
                chart1.Series[0].Points.AddXY(row[0],row[3]);
                chart1.Series[1].Points.AddXY(row[0], row[1]);
                //chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
                //chart1.Series[0].YAxisType = AxisType.Secondary;
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

            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //if (comboBox1.GetItemText(comboBox1.SelectedItem) == comboBox2.GetItemText(comboBox2.SelectedItem))
            //{
            //    chart1.Series[1].Name = comboBox1.GetItemText(comboBox1.SelectedItem) + " Kopie2";
            //}
            //else
            //{
            //    chart1.Series[1].Name = comboBox2.GetItemText(comboBox2.SelectedItem);
            //}


            int jaar = trackBar1.Value;
            string selected = comboBox2.GetItemText(comboBox2.SelectedItem);
            //string statement = "SELECT * FROM migratie WHERE wijk = " + "'selected'";
            string statement = "SELECT DISTINCT leeftijd.wijk, leeftijd.gem_leeftijd, leeftijd.jaar, inkomen.gemiddeld_inkomen FROM leeftijd, inkomen WHERE leeftijd.jaar = inkomen.jaar AND leeftijd.wijk = inkomen.wijk AND leeftijd.wijk ='" + selected + "' and inkomen.jaar =" + jaar;
            //string statement = "SELECT * FROM migratie WHERE wijk = 'Rozenburg' AND jaar = 2010";
            string connstring = "Server=127.0.0.1; port=5432; User Id=postgres; Password=hallo; Database=Database Project";
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
                chart1.Series[0].Points.AddXY(row[0], row[3]);
                chart1.Series[1].Points.AddXY(row[0], row[1]);
                //chart1.Series[1].Points.AddXYchart1.Series[1].Points.AddXY(row[0], row[1]);row[0], row[1]);
                //chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
                //chart1.Series[1].YAxisType = AxisType.Secondary;
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
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //keuze dropdown menu 1
        {


            //if(checkBox4.Checked){
                //FillChart3();
            //}
            

           
        }

        //combobox2 code
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //keuze dropdown menu 2
        {


            //if(checkBox4.Checked){
                //FillChart4();
            //}


        }



        //combobox en checkbox combinatie
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Afrikaanderwijk") && !checkBox1.Checked)
            {
                //this.comboBox2.BackColor = System.Drawing.Color.Red;
                //ChartExample3();

            }
            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Afrikaanderwijk") && checkBox1.Checked)
            {
                //this.comboBox2.BackColor = System.Drawing.Color.Blue;
                //ChartExample4();

            }
            if (this.comboBox2.SelectedIndex == this.comboBox2.FindStringExact("Agniesebuurt"))
            {
                //this.comboBox2.BackColor = System.Drawing.Color.Red;
                //ChartExample4();
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
            // for debugging only
            //textBox1.Text = trackBar1.Value.ToString();
            
            SwitchSettings();
            FillChart();
            FillChart2();
        }

        //Switchen van de map
        public void SwitchSettings()
        {
            int caseSwitch = 0;

            caseSwitch = this.trackBar1.Value;

            switch (caseSwitch)
            {
                case 2013: //2
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
                //case 4:+9
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                //chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                //chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                //chart1.Series.Add("Series1");
                chart1.ChartAreas[0].AxisX.Title = "Jaar";
                chart1.ChartAreas[0].AxisY.Title = "Aantal Misdrijven";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                //chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                //chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                chart1.Series[0].Name = "gem inkomen";
                chart1.Series[1].Name = "gem leeftijd";
                chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                chart1.Series[1].XAxisType = AxisType.Primary;
                chart1.Series[1].YAxisType = AxisType.Secondary;



            }
        }
    }
}

