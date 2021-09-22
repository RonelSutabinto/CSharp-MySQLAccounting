using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace zaneco_Accounting_System
{
    public partial class apv_cvdetails : Form
    {
        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        //private DataTable dt = new DataTable();
        private MySqlDataAdapter da;

        public apv_cvdetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void apv_cvdetails_Load(object sender, EventArgs e)
        {
            
        }

        private void load()
        {
            /*refdetailDatagrid.Rows.Clear();

            String qry = "Select apvdetails.*," +
                         "       ifnull(jobid,'') job," +
                         "       ifnull(jobname,'') jobname_ " +
                         " from checkvoucher where idapv = '" + id + "'";
            cmd = new MySqlCommand(qry, conn_tmp);

            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");

            refdetailDatagrid.Rows.Clear();
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.GetString("job").Length > 1)
                        btnJob = "X";
                    else
                        btnJob = "...";

                    tb_dbGrid.Rows.Add(dr.GetString("particulars"),
                                       dr.GetString("accountcode"),
                                       "...",
                                       dr.GetString("accountname"),
                                       dr.GetDouble("debit").ToString("N02", ci),
                                       dr.GetDouble("credit").ToString("N02", ci),
                                       dr.GetString("glaccountcode"),
                                       dr.GetString("glaccountname"),
                                       dr.GetString("qty"),
                                       dr.GetString("unit"),
                                       dr.GetString("cost"),
                                       dr.GetString("idapvdetails"),
                                       "", "", "", "", "0.00",
                                       btnJob,
                                       dr.GetString("job"),
                                       dr.GetString("jobname_"));


                    if (dr.GetDouble("debit") > 0)
                    {
                        refdetailDatagrid.Rows.Add(dr.GetString("qty"),
                                                   dr.GetString("particulars"),
                                                   dr.GetString("unit"),
                                                   dr.GetDouble("cost").ToString("N02", ci),
                                                   dr.GetDouble("debit").ToString("N02", ci));
                    }

                }

                this.ActiveControl = tb_dbGrid;
                dr.Close();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                conn_tmp.Close();
            }*/
        }
    }
}
