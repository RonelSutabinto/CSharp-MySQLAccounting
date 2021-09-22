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
    public partial class selectitemindexFrm : Form
    {
        private MySqlConnection conn = new MySqlConnection();
        private connectionDB_inv db = new connectionDB_inv();

        private MySqlConnection connS = new MySqlConnection();
        private connDBtmp dbS = new connDBtmp();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;

        private unitClass uc = new unitClass();
        private mctdetailsFrm frm_mctdetail = new mctdetailsFrm();

        private String idmctDetail = "0";
        private String debitcredit = "0.00";
        private DataGridViewRow sRowMct;
        private int selectedrowindexMct; 

        public selectitemindexFrm()
        {
            InitializeComponent();
        }
        public void mctdetailsFrmInitl(mctdetailsFrm frm_mctdetail1)
        {
            this.frm_mctdetail = frm_mctdetail1;
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            loaditemindex(search_tf.Text);
        }

        public void setIdmctd(String idd)
        {
            this.idmctDetail = idd;
        }

        public void setDebitcredit(String dc)
        {
            this.debitcredit = dc;
        }

        private void loaditemindex(String searchStr)
        {
            String qry = "Select * from zanecoinvphp.tbl_itemindex where itemcode like '%" + searchStr + "%' or itemname like '%" + searchStr + "%' limit 1000";
                            
            try
            {

                conn.Open();
                cmd = new MySqlCommand(qry, conn);
                dr = cmd.ExecuteReader();

                itemindex_lv.Items.Clear();
                while (dr.Read())
                {
                    ListViewItem lv = itemindex_lv.Items.Add(dr["itemcode"].ToString());
                    lv.SubItems.Add(dr["itemname"].ToString());
                    //lv.SubItems.Add(dr["category"].ToString());
                    //lv.SubItems.Add(dr["bank"].ToString());
                    //  lv.SubItems.Add(dr["BalAsOf"].ToString());                        
                }
                dr.Close();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
            }
            finally
            {
                conn.Close();
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void search_tf_TextChanged(object sender, EventArgs e)
        {
            loaditemindex(search_tf.Text);
        }

        private void getItemindex(String tb)
        {
            if (itemindex_lv.SelectedIndices.Count > 0)
            {

                selectedrowindexMct = frm_mctdetail.tb_dbGrid.SelectedCells[0].RowIndex;
                frm_mctdetail.tb_dbGrid.Rows.Add();

                sRowMct = frm_mctdetail.tb_dbGrid.Rows[selectedrowindexMct];                

                ListViewItem lvitem = itemindex_lv.SelectedItems[0];

                sRowMct.Cells[3].Value = lvitem.Text;
                sRowMct.Cells[5].Value = lvitem.SubItems[1].Text;
                
                //===========================
                string sql = "SELECT i.*,cd.accountname as anameDebit, cc.accountname as anameCredit FROM zanecoinvphp.tbl_itemindex i " +
                             " left join zanecoaccounting.chart cd on cd.accountcode = i.acamacodein " +
                             " left join zanecoaccounting.chart cc on cc.accountcode = i.acamacodeout " +
                             " where i.itemcode like '" + lvitem.Text + "'";
                cmd = new MySqlCommand(sql, connS);

                //OPEN CON
                try
                {
                    connS.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        sRowMct.Cells[6].Value = "1";
                        sRowMct.Cells[7].Value = dr.GetString("unit");
                        sRowMct.Cells[8].Value = "0.00";
                        sRowMct.Cells[11].Value = idmctDetail;//Strictly removed this statement
                        sRowMct.Cells[12].Value = "";
                        sRowMct.Cells[14].Value = "";
                        sRowMct.Cells[15].Value = "";
                        sRowMct.Cells[16].Value = DateTime.Now;
                        sRowMct.Cells[17].Value = dr.GetString("iditemindex");
                        sRowMct.Cells[18].Value = dr.GetString("iditemindex");
                        sRowMct.Cells[19].Value = selectedrowindexMct;
                        sRowMct.Cells[20].Value = "0";

                        //id = dr.GetString("idmaterialct");                        
                        //if (tb.ToString().Equals("debitStr"))
                        //{
                            sRowMct.Cells[0].Value = dr.GetString("acamacodein");
                            sRowMct.Cells[2].Value = dr.GetString("anameDebit");
                            

                            //==================================
                            sRowMct.Cells[9].Value = debitcredit;
                            sRowMct.Cells[10].Value = "0.00";
                            //==================================

                            

                            sRowMct.Cells[9].ReadOnly = false;
                            sRowMct.Cells[10].ReadOnly = true;                            
                        // }
                        /*else if(tb.ToString().Equals("creditStr"))
                        {
                            sRow.Cells[0].Value = dr.GetString("acamacodeout");
                            sRow.Cells[2].Value = dr.GetString("anameCredit");
                            sRow.Cells[21].Value = "0";

                            //==========================================
                            sRow.Cells[9].Value = "0.00";
                            sRow.Cells[10].Value = debitcredit;                            
                            //==========================================
                            
                            sRow.Cells[9].Style.ForeColor = Color.Black;
                            sRow.Cells[10].Style.ForeColor = Color.Red;

                            sRow.Cells[9].ReadOnly = true;
                            sRow.Cells[10].ReadOnly = false;

                        }    */
                        
                    }

                    dr.Close();
                    connS.Close();

                }
                catch 
                {                    
                    dr.Close();
                    connS.Close();
                }
                //===========================
                sRowMct.Cells[21].Value = "1";
                sRowMct.Cells[0].Style.BackColor = Color.Green;
                sRowMct.Cells[2].Style.BackColor = Color.Green;

                getItemCredit();
            }
        }

        private void getItemCredit()
        {
            if (itemindex_lv.SelectedIndices.Count > 0)
            {                                                
                sRowMct = frm_mctdetail.tb_dbGrid.Rows[selectedrowindexMct + 1];
                
                ListViewItem lvitem = itemindex_lv.SelectedItems[0];

                sRowMct.Cells[3].Value = lvitem.Text;
                sRowMct.Cells[5].Value = lvitem.SubItems[1].Text;

                //===========================
                string sql = "SELECT i.*,cd.accountname as anameDebit, cc.accountname as anameCredit FROM zanecoinvphp.tbl_itemindex i " +
                             " left join zanecoaccounting.chart cd on cd.accountcode = i.acamacodein " +
                             " left join zanecoaccounting.chart cc on cc.accountcode = i.acamacodeout " +
                             " where i.itemcode like '" + lvitem.Text + "'";
                cmd = new MySqlCommand(sql, connS);

                //OPEN CON
                try
                {
                    connS.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        sRowMct.Cells[6].Value = "1";
                        sRowMct.Cells[7].Value = dr.GetString("unit");
                        sRowMct.Cells[8].Value = "0.00";
                        sRowMct.Cells[11].Value = idmctDetail;//Strictly removed this statement
                        sRowMct.Cells[12].Value = "";
                        sRowMct.Cells[14].Value = "";
                        sRowMct.Cells[15].Value = "";
                        sRowMct.Cells[16].Value = DateTime.Now;
                        sRowMct.Cells[17].Value = dr.GetString("iditemindex");
                        sRowMct.Cells[18].Value = dr.GetString("iditemindex");
                        sRowMct.Cells[19].Value = selectedrowindexMct+1;
                        sRowMct.Cells[20].Value = "0";

                        
                        sRowMct.Cells[0].Value = dr.GetString("acamacodeout");
                        sRowMct.Cells[2].Value = dr.GetString("anameCredit");

                        //==========================================
                        sRowMct.Cells[9].Value = "0.00";
                        sRowMct.Cells[10].Value = debitcredit;
                        //==========================================

                        sRowMct.Cells[9].Style.ForeColor = Color.Black;
                        sRowMct.Cells[10].Style.ForeColor = Color.Red;

                        sRowMct.Cells[9].ReadOnly = true;
                        sRowMct.Cells[10].ReadOnly = false;
                                               
                        
                        // }    */

                    }

                    dr.Close();
                    connS.Close();
                                        
                }
                catch
                {
                    dr.Close();
                    connS.Close();
                }
                //===========================
                sRowMct.Cells[21].Value = "0";
                sRowMct.Cells[0].Style.BackColor = Color.Red;
                sRowMct.Cells[2].Style.BackColor = Color.Red;

                Close();
            }
        }

        private void itemindex_lv_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                try
                {
                                        
                }
                catch
                { }
            }*/
               
            
        }

        private void search_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = itemindex_lv;
        }

        private void selectitemindexFrm_Load(object sender, EventArgs e)
        {
            conn = db.getConn();
            connS = dbS.getConn();

            loaditemindex(search_tf.Text);
            this.ActiveControl = search_tf;
        }

        private void itemindex_lv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getItemindex("creditStr");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getItemindex("debitStr");
        }
    }
}
