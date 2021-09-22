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
    public partial class selectChartFrm : Form
    {
        private MySqlConnection conn = new MySqlConnection();
        private connDBtmp db = new connDBtmp();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;

        private unitClass uc = new unitClass();
        private checkvoucherFrm frm_checkVoucher = new checkvoucherFrm();
        private jvdetailsFrm frm_journalv = new jvdetailsFrm();
        private apvdetailsFrm frm_apvdetails = new apvdetailsFrm();
        private mctdetailsFrm frm_mctdetail = new mctdetailsFrm();
        private bankReconFrm frm_bankrecon = new bankReconFrm();
        private String glcode;
        private String glname;
        private String sf_aname;
        private String doctype = "";
        private String accountcodeFilter = "";

        //==Global Event Variables===========================
        public delegate void DoEvent(String accountcode);
        public event DoEvent loadBankReconDgv;
        private String accountcode = "";

        public delegate void DoEventMemo(String code);
        public event DoEventMemo memoTotal;
        //==================================================

        public void setAccountcode(String code_)
        {
            this.accountcodeFilter = code_;
        }
        public selectChartFrm()
        {
            InitializeComponent();
            
        }
        public void setDoctype(String doc)
        {
            this.doctype = doc;
        }
        public void mctdetailsFrmInitl(mctdetailsFrm frm_mctdetail1)
        {
            this.frm_mctdetail = frm_mctdetail1;
        }

        public void frmBankreconInitl(bankReconFrm frm_bankrecon_)
        {
            this.frm_bankrecon = frm_bankrecon_;
        }

        public void frmcheckVoucherInitl(checkvoucherFrm frm_checkVoucher1)
        {
            frm_checkVoucher = frm_checkVoucher1;
        }
        public void apvdetailsFrmInitl(apvdetailsFrm frm_apvdetails1)
        {
            frm_apvdetails = frm_apvdetails1;
        }
        public void frmjournalvInitl(jvdetailsFrm frm_journalv1)
        {
            frm_journalv = frm_journalv1;
        }
        private void loadaccount()
        {
            String qry = "Select chart.*,ifnull(chart.bankCode,'') bank from chart where isSF in ('0')  and accountcode like '%" + search_tf.Text + "%' OR isSF in ('0') and accountname like'%" + search_tf.Text + "%'";

            if ((doctype == "cv_GF") || (this.Text.Equals("bankrecon")))
            {                
                qry = "Select chart.*,ifnull(chart.bankCode,'') bank from chart where isSF in ('1') and accountcode like '%" + search_tf.Text + "%' OR isSF in ('1')  and accountname like'%" + search_tf.Text + "%'";
            }else if(doctype.Equals("journalv"))
            {
                qry = "Select chart.*,ifnull(chart.bankCode,'') bank from chart where accountcode like '%" + search_tf.Text + "%' OR accountname like'%" + search_tf.Text + "%'";
            }else if(doctype.Equals("CV"))
            {
                qry = "Select chart.*,ifnull(chart.bankCode,'') bank from chart where accountcode like '%" + search_tf.Text + "%' OR accountname like'%" + search_tf.Text + "%'";
            }

            try
            {
                
                conn.Open();
                cmd = new MySqlCommand(qry, conn);
                dr = cmd.ExecuteReader();

                chart_lv.Items.Clear();
                while (dr.Read())
                {
                     ListViewItem lv = chart_lv.Items.Add(dr["accountcode"].ToString());
                     lv.SubItems.Add(dr["accountname"].ToString());
                     lv.SubItems.Add(dr["category"].ToString());
                     lv.SubItems.Add(dr["bank"].ToString());

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

        private void select_btn_Click(object sender, EventArgs e)
        {
            loadaccount();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void search_tf_TextChanged(object sender, EventArgs e)
        {
            loadaccount();
        }

        private void selectChartFrm_Load(object sender, EventArgs e)
        {
            this.glcode = "";
            this.glname = "";
            conn = db.getConn();

            //search_tf.Text = accountcodeFilter;
            loadaccount();
            this.ActiveControl = search_tf;


            SeachFunction(accountcodeFilter);
          //  chart_lv.TopItem.SubItems[0].ResetStyle();


            /*
             listView1.Items.AddRange(Items.Where(i=>string.IsNullOrEmpty(textBox1.Text)||i.Name.StartsWith(textBox1.Text))
            .Select(c => new ListViewItem(c.Name)).ToArray());

             */

        }

        private void SeachFunction(string Search)
        {
            //Boolean flag = false;
            int indexSelected = 0;
            
            string iSearch = Search.ToLower();
            foreach (ListViewItem item in chart_lv.Items)
            {
                if (item.Text.ToLower().Contains(iSearch))
                {
                    item.Selected = true;
                }
                if (item.SubItems[0].Text.ToLower().Contains(iSearch))
                {
                    chart_lv.Focus();
                    item.Selected = true;
                    indexSelected = item.Index;
                }
                
            }

            
            chart_lv.EnsureVisible(indexSelected);
           
        }
        private void search_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = chart_lv;
        }

        private void chart_lv_KeyDown(object sender, KeyEventArgs e)
        {
            this.glcode = "";

            try
            {
                if ((e.KeyCode == Keys.Enter) && (this.Text == "check vouvher"))
                    getChartCV();
                else if ((e.KeyCode == Keys.Enter) && (this.Text == "journal vouvher"))
                    getChartJV();
                else if ((e.KeyCode == Keys.Enter) && (this.Text == "Accounts Payable"))
                    getAPV();
                else if ((e.KeyCode == Keys.Enter) && (this.Text == "Material Charge Ticket"))
                    getmct();
                else if ((e.KeyCode == Keys.Enter) && (this.Text == "bankrecon"))
                {
                    ListViewItem lvitem = chart_lv.SelectedItems[0];
                    frm_bankrecon.txtaccountcode.Text = lvitem.Text;
                    accountcode = lvitem.Text;
                    Close();
                }
            }
            catch { }


        }


        private void getmct()
        {
            if (chart_lv.SelectedIndices.Count > 0)
            {
               
                int selectedrowindex = frm_mctdetail.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = frm_mctdetail.tb_dbGrid.Rows[selectedrowindex];

                ListViewItem lvitem = chart_lv.SelectedItems[0];
                String CF = getisCF(lvitem.Text);
               
                sRow.Cells[0].Value = lvitem.Text;
                sRow.Cells[2].Value = lvitem.SubItems[1].Text;
                sRow.Cells[14].Value = glcode;//--
                sRow.Cells[15].Value = glname;
                                
                //sRow.Cells[6].Value = "1";//--
                sRow.Cells[7].Value = "";//--
                sRow.Cells[8].Value = "0.00";  //--                      
                sRow.Cells[17].Value = "0";//--
                sRow.Cells[18].Value = "";//--                

                Close();
            }
        }
        private void getChartCV()
        {
           
            if (chart_lv.SelectedIndices.Count > 0)
            {
                int selectedrowindex = frm_checkVoucher.tb_dbGrid.SelectedCells[0].RowIndex;                
                DataGridViewRow sRow = frm_checkVoucher.tb_dbGrid.Rows[selectedrowindex];

                ListViewItem lvitem = chart_lv.SelectedItems[0];

                sRow.Cells[0].Value = lvitem.Text;
                sRow.Cells[2].Value = lvitem.SubItems[1].Text;
                sRow.Cells[5].Value = frm_checkVoucher.cvNo_lbtmp.Text;
                sRow.Cells[7].Value = getisCF(lvitem.Text);
                sRow.Cells[8].Value = glcode;
                sRow.Cells[9].Value = glname;
              
                if (doctype == "cv_GF")
                {
                    sRow.Cells[11].Value = sf_aname;
                    sRow.Cells[12].Value = "Source Of Fund";
                    frm_checkVoucher.bank_cb.SelectedIndex = frm_checkVoucher.bank_cb.FindStringExact(lvitem.SubItems[3].Text);
                }
                else if (doctype == "CV")
                {
                    sRow.Cells[11].Value = "";
                    sRow.Cells[12].Value = "CV";
                }

                Close();
            }
            
        }

        private void getAPV()
        {
            String particulars = "";

            if (chart_lv.SelectedIndices.Count > 0)
            {
                
                int selectedrowindex = frm_apvdetails.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = frm_apvdetails.tb_dbGrid.Rows[selectedrowindex];

                ListViewItem lvitem = chart_lv.SelectedItems[0];
                String CF = getisCF(lvitem.Text);

                sRow.Cells[1].Value = lvitem.Text;
                sRow.Cells[3].Value = lvitem.SubItems[1].Text;                
                sRow.Cells[6].Value = glcode;
                sRow.Cells[7].Value = glname;

                try
                {
                    particulars = sRow.Cells[0].Value.ToString();
                }
                catch
                { }

                if(particulars == "")
                    sRow.Cells[0].Value = frm_apvdetails.desc_tf.Text;

                Close();
            }
        }
        private void getChartJV()
        {

            if (chart_lv.SelectedIndices.Count > 0)
            {
                int selectedrowindex = frm_journalv.tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = frm_journalv.tb_dbGrid.Rows[selectedrowindex];

                ListViewItem lvitem = chart_lv.SelectedItems[0];

                sRow.Cells[0].Value = lvitem.Text;
                sRow.Cells[2].Value = lvitem.SubItems[1].Text;
                sRow.Cells[6].Value = frm_journalv.jvnumber_lbtmp.Text;
                sRow.Cells[8].Value = getisCF(lvitem.Text);
                sRow.Cells[12].Value = glcode;
                                
                Close();
            }

        }

        private String getisCF(String code)
        {
            String isCF = "0";
            String qry = "Select isCF,glAccountcode,glaccountname from chart where accountcode = '"+code+"'";
            cmd = new MySqlCommand(qry, conn);

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    isCF = dr.GetString("isCF");
                    this.glcode = dr.GetString("glAccountcode");
                    this.glname = dr.GetString("glaccountname");
                    this.sf_aname = dr.GetString("glaccountname");
                }

                dr.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                dr.Close();
                conn.Close();
            }

            return isCF;
        }
        private void chart_lv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void selectChartFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.Text == "bankrecon")
            {
                loadBankReconDgv(accountcode);
                memoTotal(accountcode);
            }
        }
    }
}
