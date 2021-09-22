using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace zaneco_Accounting_System
{
    class connectionDB_inv
    {
        private MySqlConnection connection;
        private String server;
        private String database;
        private String uid;
        private String password;
        private String connStr;

        public connectionDB_inv()
        {
            Initialize();
        }



        private void Initialize()
        {
            //server = "server";
            //database = "zanecoinvphp";
            //uid = "19zan72";
            //password = "pascalzan";
            server = "182.168.3.1";
            database = "zanecoinvphp";
            uid = "19zan72";
            password = "pascalzan";
            string connectionStr;

            connectionStr = connectionStr = "SERVER=" + server + ";" + "Port = 3306; DATABASE=" + database + ";" + "UID=" + uid + ";" + ";Allow User Variables=True;" +//"Persist Security Info=True;"+
                            "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionStr);

            this.connStr = connectionStr;

        }

        public String getConnString()
        {
            return this.connStr;
        }
        public MySqlConnection getConn()
        {
            return connection;
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }



        //close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
