using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Additional imports:
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace FormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Console.WriteLine("Lets get ourselfs some data!...");
            Console.WriteLine();

            DataTable data = GrabData("select * from a");
            int counter = 0;

            foreach (DataRow row in data.Rows)
            {
                counter++;
                Console.WriteLine(counter + ". " + row[0]);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Grabs data from a, specified, remote SQL source.
        /// </summary>
        /// <param name="statement">A String which represents the SQL statement.</param>
        /// <returns>DataTable</returns>
        static public DataTable GrabData(string statement)
        {

            //Setup:
            ///Creeër een plaats om de data van ons request op te slaan.
            string connstring = "Server=127.0.0.1; port=5432; User Id=postgres; Password=hallo; Database=test;";
            DataTable dataStore = new DataTable();
            ///Creeër de connectie die gebruikt zal worden om met de database te communiceren. 
            NpgsqlConnection connection = new NpgsqlConnection(connstring);


            //Creeër de SQL statement.
            NpgsqlCommand sqlStatement = new NpgsqlCommand(statement, connection);
            ///Creeër de adapter die de data van de database ophaalt.
            NpgsqlDataAdapter dataGrabber = new NpgsqlDataAdapter(sqlStatement);

            //Work:
            ///Open de connectie naar de database.
            connection.Open();
            ///Vul met de adapter de "dataStore".
            dataGrabber.Fill(dataStore);
            //if (connection.State == System.Data.ConnectionState.Open)
            //{
            //    Console.WriteLine("blkabalabal");
            //}
            ///Sluit de connectie naar de database.
            connection.Close();

            //Shutdown:
            ///Return de "dataStore".
            return dataStore;
        }
    }
}
