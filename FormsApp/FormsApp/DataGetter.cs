using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Npgsql;

namespace FormsApp
{
    //string connstring = "Server=127.0.0.1; port=5432; User Id=postgres; Password=hallo; Database=Database Project;";
    class DataGetter
    {
        private NpgsqlConnection connection;

        public DataGetter(string serverIP, string serverPort, string userName, string password)
        {
            // = new NpgsqlConnection("Data Source=" + serverIP + "," + serverPort + "; Database=Database Project;Persist Security Info=True; User ID=" + userName + "; Password=" + password);
            connection = new NpgsqlConnection("Server=" + serverIP + "; port=" + serverPort + "; User Id=" + userName + "; Password=" + password + "; Database=Database Project;");
        }


        public DataTable GetData(string statement)
        {
            DataTable dataStore = new DataTable();
            NpgsqlCommand sqlStatement = new NpgsqlCommand(statement, connection);
            NpgsqlDataAdapter dataGrabber = new NpgsqlDataAdapter(sqlStatement);

            connection.Open();
            dataGrabber.Fill(dataStore);
            connection.Close();

            return dataStore;
        }
    }
}


