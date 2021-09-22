using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace zaneco_Accounting_System
{
     
    class connectionDB
    {
       //private MySqlConnection connection;
           
        
        /*public connectionDB() 
        {
            Initialize();
        }*/        

        public static MySqlConnection ConnDBopen()
        {
            String server = "182.168.3.1";
            String database = "zanecoaccounting";
            String uid = "19zan72";
            String password = "pascalzan";
                                    
            MySqlConnection Connector = new MySqlConnection("SERVER=" + server + ";" + "Port = 3306; DATABASE=" + database + ";" + "UID=" + uid + ";" + ";Allow User Variables=True;" +//"Persist Security Info=True;"+
                            "PASSWORD=" + password + ";");

            Connector.Open();
            return Connector;
            
        }

        

        //close connection
        /*public bool CloseConnection()
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
        }*/
    }

   
}


/*
    // Remember the vertical scroll position of the DataGridView
int saveVScroll = 0;
if (DataGridView1.Rows.Count > 0)
  saveVScroll = DataGridView1.FirstDisplayedCell.RowIndex;

// Remember the horizontal scroll position of the DataGridView
int saveHScroll = 0;
if (DataGridView1.HorizontalScrollingOffset > 0)
  saveHScroll = DataGridView1.HorizontalScrollingOffset;

// Refresh the DataGridView
DataGridView1.DataSource = ds.Tables(0);

// Go back to the saved vertical scroll position if available
if (saveVScroll != 0 && saveVScroll < DataGridView1.Rows.Count)
  DataGridView1.FirstDisplayedScrollingRowIndex = saveVScroll;

// Go back to the saved horizontal scroll position if available
if (saveHScroll != 0)
  DataGridView1.HorizontalScrollingOffset = saveHScroll;
    */