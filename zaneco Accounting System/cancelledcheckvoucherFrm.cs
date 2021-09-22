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

namespace zaneco_Accounting_System
{
    public partial class cancelledcheckvoucherFrm : Form
    {
        
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private MySqlDataAdapter da;        

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();
             
        public cancelledcheckvoucherFrm()
        {
            InitializeComponent();
        }

        private void to_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fr_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void select_btn_Click(object sender, EventArgs e)
        {

        }

        private void cancelledcheckvoucherFrm_Load(object sender, EventArgs e)
        {
            fr_date.Value = uc.StartOfMonth;
            to_date.Value = uc.EndOfMonth;

            conn_tmp = db_tmp.getConn();
            loadCancelled();
        }

        private void loadCancelled()
        {
            String qry = "Select * from zanecoaccounting.trailcheckv where checknumber like @checkno and cvdate between @datefrom and @dateto order by cvdate,checknumber";                    

            ds = new DataSet();

            try
            {

                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);

                da.SelectCommand.Parameters.AddWithValue("@datefrom", fr_date.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto", to_date.Value);
                da.SelectCommand.Parameters.AddWithValue("@checkno","%"+ CodeName_tf.Text+"%");

                da.Fill(ds, "cancelled");
                dt_gridview.AutoGenerateColumns = false;
                dt_gridview.DataSource = ds.Tables["cancelled"];

                da.Dispose();
                conn_tmp.Close();                               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Clone();
            }

        }

        private void select_btn_Click_1(object sender, EventArgs e)
        {
            loadCancelled();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
