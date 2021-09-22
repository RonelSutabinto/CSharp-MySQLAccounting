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
    public partial class selectPayeeFrm : Form
    {
        
        private MySqlConnection conn = new MySqlConnection();
        private connDBtmp db = new connDBtmp();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;

        private unitClass uc = new unitClass();
        private checkvoucherFrm frm_checkVoucher;
        private jvdetailsFrm frm_journalv;
        private apvdetailsFrm frm_apvdetails;
         
        public selectPayeeFrm()
        {
            InitializeComponent();
        }

        
        public void frmcheckVoucherInitl(checkvoucherFrm frm_checkVoucher1)
        {
            frm_checkVoucher = frm_checkVoucher1;
        }
        public void frmapvdetailsInitl(apvdetailsFrm frm_apvdetails1)
        {
            frm_apvdetails = frm_apvdetails1;
        }
        public void frmjournalvInitl(jvdetailsFrm frm_journalv1)
        {
            frm_journalv = frm_journalv1;
        }
        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void loadpayee()
        {
            
             String qry = "Select * from payee where active = 1 and (pcode like '%" + search_tf.Text + "%' OR name like '%"+search_tf.Text+"%')";

            try
            {
                conn = db.getConn();
                if (db.OpenConnection())
                {
                    cmd = new MySqlCommand(qry, conn);
                    dr = cmd.ExecuteReader();

                    chart_lv.Items.Clear();
                    while (dr.Read())
                    {
                        ListViewItem lv = chart_lv.Items.Add(dr["pcode"].ToString());
                        lv.SubItems.Add(dr["name"].ToString());
                        lv.SubItems.Add(dr["address"].ToString());                        
                    }
                    dr.Close();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
             
        }

        private void search_tf_TextChanged(object sender, EventArgs e)
        {
            loadpayee();
        }

        private void selectPayeeFrm_Load(object sender, EventArgs e)
        {
            loadpayee();
            this.ActiveControl = search_tf;
        }

        private void search_tf_KeyDown(object sender, KeyEventArgs e)
        {
            
             if (e.KeyCode == Keys.Enter)
                this.ActiveControl = chart_lv;
             
        }

        private void getpayeeCV()
        {
            
              if (chart_lv.SelectedIndices.Count > 0)
            {
                //int selectedrowindex = frm_checkVoucher.tb_dbGrid.SelectedCells[0].RowIndex;                
                //DataGridViewRow sRow = frm_checkVoucher.tb_dbGrid.Rows[selectedrowindex];

                ListViewItem lvitem = chart_lv.SelectedItems[0];

                frm_checkVoucher.pcode_tf.Text = lvitem.Text;
                frm_checkVoucher.pname_tf.Text = lvitem.SubItems[1].Text;        
                frm_checkVoucher.paddress_tf.Text =  lvitem.SubItems[2].Text;                
                 
                Close();
            }
             
        }


        private void getpayeeJV()
        {

            if (chart_lv.SelectedIndices.Count > 0)
            {                               
                int selectedrowindex = frm_journalv.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = frm_journalv.tb_dbGrid.Rows[selectedrowindex];

                ListViewItem lvitem = chart_lv.SelectedItems[0];

                sRow.Cells[10].Value = lvitem.Text;
                sRow.Cells[11].Value = lvitem.SubItems[1].Text;          
                                
                Close();
            }

        }

        private void getpayeeAPV()
        {

            if (chart_lv.SelectedIndices.Count > 0)
            {

                ListViewItem lvitem = chart_lv.SelectedItems[0];
                               
                frm_apvdetails.pcode_tf.Text = lvitem.Text;
                frm_apvdetails.pname_tf.Text = lvitem.SubItems[1].Text;
                frm_apvdetails.paddress_tf.Text = lvitem.SubItems[2].Text;

                Close();
            }

        }
        private void select_btn_Click(object sender, EventArgs e)
        {
            loadpayee();
        }

        private void chart_lv_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) &&(this.Text=="check voucher"))
                getpayeeCV();
            else if ((e.KeyCode == Keys.Enter) && (this.Text == "journal voucher"))
            {
                getpayeeJV();
            }
            else if ((e.KeyCode == Keys.Enter) && (this.Text == "apv voucher"))
            {
                getpayeeAPV();
            }
            //frmapvdetailsInitl
        }
    }
}
