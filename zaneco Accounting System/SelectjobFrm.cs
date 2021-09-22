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
    public partial class SelectjobFrm : Form
    {
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        //private MySqlDataReader dr;
        private MySqlDataAdapter da;

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();

        private jvdetailsFrm frm_jvdetails = new jvdetailsFrm();
        private apvdetailsFrm frm_apvdetails = new apvdetailsFrm();
        private checkvoucherFrm frm_checkvoucher = new checkvoucherFrm();

        public SelectjobFrm()
        {
            InitializeComponent();
        }

        public void checkvoucherInitl(checkvoucherFrm frm_checkvoucher1)
        {
            this.frm_checkvoucher = frm_checkvoucher1;
        }
        public void jvdetailsFrmInitl(jvdetailsFrm frm_jvdetails1)
        {
            this.frm_jvdetails = frm_jvdetails1;
        }

        public void apvdetailsFrmInitl(apvdetailsFrm frm_apvdetails1)
        {
            this.frm_apvdetails = frm_apvdetails1;
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            int selectedIndex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = dataGridView2.Rows[selectedIndex];

            if (lblTag.Text == "apvdetails")
            {
                int selectedrowindex = frm_apvdetails.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRowapv = frm_apvdetails.tb_dbGrid.Rows[selectedrowindex];


                sRowapv.Cells[18].Value = sRow.Cells[1].Value.ToString();
                sRowapv.Cells[19].Value = sRow.Cells[2].Value.ToString();
                sRowapv.Cells[17].Value = "X";
                Close();
            }
            else if (lblTag.Text == "checkvoucher")
            {
                int selectedrowindex = frm_checkvoucher.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRowjv = frm_checkvoucher.tb_dbGrid.Rows[selectedrowindex];


                sRowjv.Cells[15].Value = sRow.Cells[1].Value.ToString();
                sRowjv.Cells[16].Value = sRow.Cells[2].Value.ToString();
                sRowjv.Cells[14].Value = "X";

                Close();
            }
            else
            {
                int selectedrowindex = frm_jvdetails.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRowjv = frm_jvdetails.tb_dbGrid.Rows[selectedrowindex];


                sRowjv.Cells[10].Value = sRow.Cells[1].Value.ToString();
                sRowjv.Cells[11].Value = sRow.Cells[2].Value.ToString();

                Close();
            }

        }
                

        public void loadjob()
        {
            String qry = "Select * from journaljob where active = 1 and (code like @code or name like @code)";

            ds = new DataSet();

            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);

                da.SelectCommand.Parameters.AddWithValue("@code", "%" + search_tf.Text + "%");

                da.Fill(ds, "job");
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = ds.Tables["job"];

                da.Dispose();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

        private void SelectjobFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            loadjob();

            this.ActiveControl = search_tf;
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            loadjob();
        }

        private void search_tf_TextChanged(object sender, EventArgs e)
        {
            loadjob();
        }

        private void search_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = dataGridView2;
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            int selectedIndex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = dataGridView2.Rows[selectedIndex];

            if ((e.KeyCode == Keys.Enter) && (lblTag.Text == "apvdetails"))
            {
                int selectedrowindex = frm_apvdetails.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRowapv = frm_apvdetails.tb_dbGrid.Rows[selectedrowindex];


                sRowapv.Cells[18].Value = sRow.Cells[1].Value.ToString();
                sRowapv.Cells[19].Value = sRow.Cells[2].Value.ToString();
                sRowapv.Cells[17].Value = "X";

                Close();
            }            
            else if ((e.KeyCode == Keys.Enter) && (lblTag.Text == "checkvoucher"))
            {
                int selectedrowindex = frm_checkvoucher.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRowjv = frm_checkvoucher.tb_dbGrid.Rows[selectedrowindex];


                sRowjv.Cells[15].Value = sRow.Cells[1].Value.ToString();
                sRowjv.Cells[16].Value = sRow.Cells[2].Value.ToString();
                sRowjv.Cells[14].Value = "X";

                Close();
            }
            else if ((e.KeyCode == Keys.Enter) && (lblTag.Text != "checkvoucher") && (lblTag.Text != "apvdetails"))
            {
                int selectedrowindex = frm_jvdetails.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRowjv = frm_jvdetails.tb_dbGrid.Rows[selectedrowindex];


                sRowjv.Cells[10].Value = sRow.Cells[1].Value.ToString();
                sRowjv.Cells[11].Value = sRow.Cells[2].Value.ToString();
                
                Close();
            }
        }
    }
}
