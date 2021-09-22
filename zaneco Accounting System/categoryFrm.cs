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
    public partial class categoryFrm : Form
    {
        private connectionDB db = new connectionDB();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private MySqlDataReader dr;
        private DataSet ds = new DataSet();
        private unitClass uc = new unitClass();
        private addChartAccountFrm frm_addChartAccount = new addChartAccountFrm();

        public categoryFrm()
        {
            InitializeComponent();
        }

        public void addChartAccountInitl(addChartAccountFrm frm_addChartAccount1)
        {
            this.frm_addChartAccount = frm_addChartAccount1;
        }

        private void categoryFrm_Load(object sender, EventArgs e)
        {
            this.categoryTableAdapter1.Fill(this.categoryDS1.category, "%" + search_tf.Text + "%");
            //conn = db.getConn();            
            this.ActiveControl = search_tf;
            //loadCategory();
            search_tf.Focus();
        }

       /* private void loadCategory()
        {
            String qry = "Select * from acctcategory where category like '%" + search_tf .Text + "%'";

            try
            {
                conn = db.getConn();
                if (db.OpenConnection())
                {
                    cmd = new MySqlCommand(qry, conn);
                    dr = cmd.ExecuteReader();

                    category_lv.Items.Clear();
                    while (dr.Read())
                        {
                           category_lv.Items.Add(dr["categorytype"].ToString());
                        }
                    dr.Close();
                    
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString(),uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

           
        }*/
        

        private void cmd_showInvent_Click(object sender, EventArgs e)
        {
            //loadCategory();            
            this.categoryTableAdapter1.Fill(this.categoryDS1.category,"%"+ search_tf.Text+ "%");
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void search_tf_TextChanged(object sender, EventArgs e)
        {
           // loadCategory();
        }

        private void category_lv_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)             
            {                
                ListViewItem lvitem = category_lv.SelectedItems[0];

                frm_addChartAccount.category_tf.Text = lvitem.Text;      
                Close();               
            }

        }

        private void search_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = category_dgrid;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Enter)
            {
                int selectedrowindex = category_dgrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = category_dgrid.Rows[selectedrowindex];
                frm_addChartAccount.category_tf.Text = sRow.Cells[1].Value.ToString();
                frm_addChartAccount.idcategory.Text = sRow.Cells[0].Value.ToString();

                Close();
            }
        }
    }
}
