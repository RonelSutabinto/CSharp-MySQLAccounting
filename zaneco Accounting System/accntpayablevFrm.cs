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
using zaneco_Accounting_System.module;
using DevExpress.XtraGrid.Views.Grid;

using System.Drawing.Drawing2D;

namespace zaneco_Accounting_System
{
    public partial class accntpayablevFrm : Form
    {
        //=============================================
        //=============================================
        private void MakeLabelRounded()
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, cntr_lb.Width, cntr_lb.Height);
            cntr_lb.Region = new Region(gp);
            cntr_lb.Invalidate();
        }
        //=============================================
        //=============================================

        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private MySqlDataAdapter da;
        private Boolean isdueCheck;

        //private connDBtmp db_tmp = new connDBtmp();
        //private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();
        private Boolean isAPV_;

        private int cntTmr = 0;

        // private accntpayablevFrm frm_accountpayable = new accntpayablevFrm();

        public accntpayablevFrm()
        {
            InitializeComponent();

            this.isAPV_ = false;
        }

        public void setisAPV(Boolean isapv)
        {
            this.isAPV_ = isapv;
        }

        private void close_bnt_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void setisdue(Boolean due_)
        {
            this.isdueCheck = due_;
        }

        /* public void frmcvJournalInitl(accntpayablevFrm frm_accountpayable1)
         {
             frm_accountpayable = frm_accountpayable1;
         }*/

        
        
         
        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {
            apvdetailsFrm frm = new apvdetailsFrm();
            frm.Text = "Add Accounts Payable Voucher";
            frm.accntpayablevInitl(this);
            frm.ShowDialog();
        }

        private void searchCode_btn_Click(object sender, EventArgs e)
        {
            
        }

        public void loadapv(String searchapv_,DateTime from_d,DateTime to_d, Boolean isdue)
        {
            String qry = " SELECT " +
                         "      a.*, " +
                         "      if (a.posted = 1,'YES','NO') postedF, " +
                         "      sum(IFNULL(c.cvamount,0)) as amountpaidF, "+
                         "      if(sum(IFNULL(c.total,0))>0 and sum(IFNULL(c.total,0))<a.amount,'Partial',if(sum(IFNULL(c.total,0))>=a.amount AND a.amount <> 0,'Paid','Unpaid')) statusP" +
                         "    FROM apvoucher a " +
                         "    left join checkvoucher c on c.refnumber = a.apvnumber and c.cvpcode <>'CANCELED' " +                        
                         "    where a.apvnumber like @apvno and " +
                         "        a.apvdate between @datefrom and @dateto or " +
                         "        a.pcode like @pcode and " +
                         "        a.apvdate between @datefrom and @dateto group by a.apvnumber";

            //==Counter for dues APV============================
            String qry_cnt = "   Select sum(f.noapv) cntr " +
                             "   from(SELECT " +
                             "          1 as noapv, " +
                             "          sum(IFNULL(c.total, 0)) amountpaidF, a.* " +
                             "    FROM apvoucher a " +
                             "    left join checkvoucher c on c.refnumber = a.apvnumber and c.cvpcode <> 'CANCELED' " +
                             "    where  a.amount > 0 and " +
                             "          CURDATE() >= a.apvduedate and " +
                             "           a.apvduedate >= DATE_SUB( CURDATE(), INTERVAL 2 YEAR) " +
                             "         group by a.apvnumber " +
                             "         ) f where f.amountpaidF < f.amount ";
            //====================================================

            if (isdue)
            {                
                qry =    "Select f.* from ( SELECT " +
                         "      a.*, " +
                         "      if (a.posted = 1,'YES','NO') postedF, " +
                         "      sum(IFNULL(c.total,0)) as amountpaidF, " +
                         "      if(sum(IFNULL(c.total,0))>0 and sum(IFNULL(c.total,0))<a.amount,'Partial',if(sum(IFNULL(c.total,0))>=a.amount AND a.amount <> 0,'Paid','Unpaid')) statusP" +
                         "    FROM apvoucher a " +
                         "    left join checkvoucher c on c.refnumber = a.apvnumber and c.cvpcode <>'CANCELED' " +                         
                         "    where a.apvnumber like @apvno and " +
                         "        CURDATE() >= a.apvduedate and " +
                         "        a.apvdate between @datefrom and @dateto or " +
                         "        a.pcode like @pcode and " +
                         "        CURDATE() >= a.apvduedate and " +                         
                         "        a.apvdate between @datefrom and @dateto group by a.apvnumber " +
                         ") f where f.amountpaidF< f.amount and f.amount>0 ";
            }

            ds = new DataSet();
            
            try
            {
                //conn_tmp.Open();
                da = new MySqlDataAdapter(qry, globalmainFrm.getConn_accnt());

                da.SelectCommand.Parameters.AddWithValue("@apvno","%"+ searchapv_ + "%");
                da.SelectCommand.Parameters.AddWithValue("@pcode", "%" + searchapv_ + "%");
                da.SelectCommand.Parameters.AddWithValue("@datefrom",from_d);
                da.SelectCommand.Parameters.AddWithValue("@dateto",to_d);

                da.Fill(ds, "apv");
                //apvdatagridview.AutoGenerateColumns = false;
                //apvdatagridview.DataSource = ds.Tables["apv"];
                gridControl1.DataSource = ds.Tables["apv"];

                da.Dispose();
                //conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
            }


            //===Count Out of due APV=====================
            //============================================
            String cntr_= "0";
            try
            {
                //conn_tmp.Open();
                cmd = new MySqlCommand(qry_cnt, globalmainFrm.getConn_accnt());                 
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cntr_ = dr.GetString("cntr");                    
                }
                dr.Close();
                //conn_tmp.Close();
            }
            catch
            {
                //conn_tmp.Close();
            }

            cntr_lb.Text = cntr_;
            //=====================================================
        }

        private void accntpayablevFrm_Load(object sender, EventArgs e)
        {
            Boolean isDue_ = false;

            //MakeLabelRounded();

            //conn_tmp = db_tmp.getConn();
            fr_date.Value = uc.StartOfMonth;
            to_date.Value = uc.EndOfMonth;

            //==============================
            if (isdueCheck)
                dues_cb.Checked = true;
            else
                dues_cb.Checked = false;

            if (dues_cb.Checked)
            {
                isDue_ = true;
                fr_date.Value = fr_date.Value.AddMonths(-12);
            }
            //===============================
            

            loadapv(apvsearch_tf.Text,fr_date.Value,to_date.Value, isDue_);

            
            if (isAPV_ == false)
            {
                addAccntCode_btn.Enabled = false;
                update_btn.Enabled = false;
                deleteAccntCode_btn.Enabled = false;
            }
        }
                
        private void update_btn_Click(object sender, EventArgs e)
        {
            apvdetailsFrm frm = new apvdetailsFrm();
            frm.Text = "Update Accounts Payable Voucher";
            frm.accntpayablevInitl(this);

            //int selectedIndex = 0;

            // try
            // {
            //     selectedIndex = apvdatagridview.SelectedCells[0].RowIndex;
            //}
            //catch
            //{ }                    


            // DataGridViewRow sRow = apvdatagridview.Rows[selectedIndex];
            try
            {
                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                if (gridControl.GetRowCellValue(RowCount, "pName").ToString().Substring(0, 9) == "CANCELLED")
                {
                    MessageBox.Show("Unable to continue this process, APV was already cancelled..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (!(gridControl.GetRowCellValue(RowCount, "userID").ToString().Equals(globalmainFrm.userlog)))
                {
                    MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userID").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (!(Boolean.Parse(gridControl.GetRowCellValue(RowCount, "posted").ToString())))
                {
                    frm.setidapv(gridControl.GetRowCellValue(RowCount, "idAPVoucher").ToString()); 
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("APV Number: " + gridControl.GetRowCellValue(RowCount, "apvNumber").ToString() + "\n Accounts payable voucher was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch
            { }

            /*if (Double.Parse(sRow.Cells[5].Value.ToString().Replace(",","")) > 0)
            {
                MessageBox.Show("Unable to continue this process, APV has already issued Check..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }  */             
                                          
        }

        private void preview_btn_Click(object sender, EventArgs e)
        {
            apvdetailsFrm frm = new apvdetailsFrm();
            frm.Text = "Preview Accounts Payable Voucher";
            frm.accntpayablevInitl(this);
                       
           // try
            //{
                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                if (gridControl.GetRowCellValue(RowCount, "pName").ToString().Substring(0,9) == "CANCELLED")
                    return;

                frm.setidapv(gridControl.GetRowCellValue(RowCount, "idAPVoucher").ToString());
                frm.ShowDialog();

            //}
            //catch
            //{ }
                        
        }
        private void deleteAccntCode_btn_Click(object sender, EventArgs e)
        {
            Boolean isDue_ = false;

            if (dues_cb.Checked)
                isDue_ = true;

            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

            if (Double.Parse(gridControl.GetRowCellValue(RowCount, "amountpaidF").ToString()) > 0.00 )
            {
                MessageBox.Show("Unable to continue this process, APV has already initial/full CV payment..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (gridControl.GetRowCellValue(RowCount, "pName").ToString().Substring(0,9) == "CANCELLED")
            {
                MessageBox.Show("Unable to continue this process, APV was already cancelled..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(gridControl.GetRowCellValue(RowCount, "userID").ToString().Equals(globalmainFrm.userlog)))
            {
                MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userID").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(Boolean.Parse(gridControl.GetRowCellValue(RowCount, "posted").ToString())))
            {
                DialogResult d = MessageBox.Show("APV No.:" + gridControl.GetRowCellValue(RowCount, "apvNumber").ToString()+ "\n Are you sure, you want to cancel this APV number?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    apvcancel(gridControl.GetRowCellValue(RowCount, "apvNumber").ToString(), globalmainFrm.userlog);
                    loadapv(apvsearch_tf.Text, fr_date.Value, to_date.Value, isDue_);
                }
            }
            else
                MessageBox.Show("APV Number: " + gridControl.GetRowCellValue(RowCount, "apvNumber").ToString() + "\n Accounts payable voucher was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void apvcancel(String apv_no,String user)
        {
            

            String qry = " insert into trailapv  " +
                         "   (Select a.*, @executedby, current_date() from apvoucher a where a.apvNumber = @apvno );  " +
                         " insert into trailapvdetails  " +
                         "   (Select ad.*, @executedby, current_date() from apvdetails ad where ad.apvNumber = @apvno );  " +
                         " Delete from apvdetails where apvnumber = @apvno;  " +
                         " update apvoucher set pDescription =concat('CANCELLED : ', now(), ' - ', @executedby),pName = concat('CANCELLED : ', now(), ' - ', @executedby), amount = 0 where apvnumber = @apvno; ";
            //" update apvoucher set apvnumber = concat('CANCELLED : ', now(), ' - ', @executedby), amount = 0 where apvnumber = @apvno; ";

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@apvno", apv_no);
                cmd.Parameters.AddWithValue("@executedby", user);

                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
            }
            
        }

        private void apvdatagridview_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void poupTmr_Tick(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dues_cb_Click(object sender, EventArgs e)
        {
            Boolean isDue_ = false;

            if (dues_cb.Checked)
                isDue_ = true;
            
            loadapv(apvsearch_tf.Text, fr_date.Value, to_date.Value, isDue_);
        }

        private void dues_cb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            Boolean isDue_ = false;

            if (dues_cb.Checked)
                isDue_ = true;

            loadapv(apvsearch_tf.Text, fr_date.Value, to_date.Value, isDue_);
        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
            saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialogExcel.FileName;
                //gridControl1.DataSource = selectgridvalues();
                gridControl1.ExportToXlsx(exportFilePath);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
