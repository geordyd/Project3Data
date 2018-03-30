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
        Bitmap img1 = Properties.Resources.jaar2010;
        Bitmap img2 = Properties.Resources.jaar2011;
        Bitmap img3 = Properties.Resources.jaar2012;
        Bitmap img4 = Properties.Resources.jaar2013;
        Bitmap img5 = Properties.Resources.jaar2014;
        Bitmap img6 = Properties.Resources.jaar2015;
        Bitmap img7 = Properties.Resources.jaar2016;


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
            else if (checkBox4.Checked)
            {
                statement = "SELECT DISTINCT leeftijd.wijk, leeftijd.gem_leeftijd, leeftijd.jaar, inkomen.gemiddeld_inkomen FROM leeftijd, inkomen WHERE leeftijd.jaar = inkomen.jaar AND leeftijd.wijk = inkomen.wijk AND leeftijd.wijk ='" + selected + "' and inkomen.jaar =" + jaar;
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
                else if (checkBox4.Checked)
                {
                    chart1.Series[1].Points.Clear();
                    chart1.Series[0].Points.Clear();
                    chart1.Series[0].Points.AddXY(row[0], row[3]);
                    chart1.Series[1].Points.AddXY(row[0], row[1]);
                }
            }
        }
        
        public void FillChart2()
        {

            chart1.Titles.Clear();
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
            else if (checkBox4.Checked)
            {
                statement = "SELECT DISTINCT leeftijd.wijk, leeftijd.gem_leeftijd, leeftijd.jaar, inkomen.gemiddeld_inkomen FROM leeftijd, inkomen WHERE leeftijd.jaar = inkomen.jaar AND leeftijd.wijk = inkomen.wijk AND leeftijd.wijk ='" + selected + "' and inkomen.jaar =" + jaar;
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
                else if (checkBox4.Checked)
                {
                    chart1.Series[0].Points.AddXY(row[0], row[3]);
                    chart1.Series[1].Points.AddXY(row[0], row[1]);
                }
            }
        }

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

        //combobox1
        //Combobox1 code
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                chart1.Series[1].Points.Clear();
                chart1.Series[0].Points.Clear();
                FillChart();
                FillChart2();
            }
            if(checkBox3.Checked || checkBox4.Checked)
            {
                chart1.Series[1].Points.Clear();
                chart1.Series[0].Points.Clear();
                //FillChart();
            }
        }

        //combobox2 code
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                chart1.Series[1].Points.Clear();
                chart1.Series[0].Points.Clear();
                FillChart();
                FillChart2();
            }
            if (checkBox3.Checked || checkBox4.Checked)
            {
                chart1.Series[1].Points.Clear();
                chart1.Series[0].Points.Clear();
                //FillChart2();
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
            textBox1.Text = trackBar1.Value.ToString();
            if (checkBox1.Checked)
            {
                SwitchSettings();
            }

            if (checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
            {
                //textBox1.Text = trackBar1.Value.ToString();
                FillChart();
                FillChart2();
            }
            //clears chart when there is no data for that year
            if (checkBox4.Checked && (trackBar1.Value == 2010 || trackBar1.Value == 2016))
            {
                //clears all series
                chart1.Series.Clear();
                //adds series again
                chart1.Series.Add("Series1");
                chart1.Series.Add("Series2");
                //set charttype
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                //gives series names
                chart1.Series[0].Name = "gem inkomen";
                chart1.Series[1].Name = "gem leeftijd";
                //gives axis names
                chart1.ChartAreas[0].AxisX.Title = "Wijk";
                chart1.ChartAreas[0].AxisY.Title = "Aantal Misdrijven";
                //enables second Y-Axis
                chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                //gives series axis type
                chart1.Series[1].YAxisType = AxisType.Secondary;
            }

        }

        //Switchen van de map
        public void SwitchSettings()
        {
            int caseSwitch = 0;

            caseSwitch = this.trackBar1.Value;

            switch (caseSwitch)
            {
                case 2011:
                    textBox1.Text = "2011";
                    pictureBox1.Image = img2;
                    break;
                case 2012:
                    textBox1.Text = "2012";
                    pictureBox1.Image = img3;
                    break;
                case 2013:
                    textBox1.Text = "2013";
                    pictureBox1.Image = img4;
                    break;
                case 2014:
                    textBox1.Text = "2014";
                    pictureBox1.Image = img5;
                    break;
                case 2015:
                    textBox1.Text = "2015";
                    pictureBox1.Image = img6;
                    break;
                case 2016:
                    textBox1.Text = "2016";
                    pictureBox1.Image = img7;
                    break;
                default:
                    textBox1.Text = "2010";
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
                //clears all series
                chart1.Series.Clear();
                //adds series again
                chart1.Series.Add("Series1");
                chart1.Series.Add("Series2");
                //set charttype
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //gives series names
                //chart1.Series[0].Name = "gem inkomen";
                //chart1.Series[1].Name = "gem leeftijd";
                //gives axis names
                chart1.ChartAreas[0].AxisX.Title = "Wijk";
                chart1.ChartAreas[0].AxisY.Title = "Aantal Misdrijven";
                ////enables second Y-Axis
                chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;
                ////gives series axis type
                chart1.Series[1].YAxisType = AxisType.Primary;
                //execute fillchart functions 
                trackBar1.Visible = false;
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

                //clears all series
                chart1.Series.Clear();
                //adds series again
                chart1.Series.Add("Series1");
                chart1.Series.Add("Series2");
                //set charttype
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                //gives series names
                chart1.Series[0].Name = "gem inkomen";
                chart1.Series[1].Name = "gem leeftijd";
                //gives axis names
                chart1.ChartAreas[0].AxisX.Title = "Wijk";
                chart1.ChartAreas[0].AxisY.Title = "Aantal Misdrijven";
                //enables second Y-Axis
                chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                //gives series axis type
                chart1.Series[1].YAxisType = AxisType.Secondary;
                //execute fillchart functions 
                FillChart();
                FillChart2();
                //can't click on other checkboxes
                checkBox1.AutoCheck = false;
                checkBox2.AutoCheck = false;
                checkBox3.AutoCheck = false;
            }
            else
            {
                //other checkboxes are clickable 
                checkBox1.AutoCheck = true;
                checkBox2.AutoCheck = true;
                checkBox3.AutoCheck = true;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

