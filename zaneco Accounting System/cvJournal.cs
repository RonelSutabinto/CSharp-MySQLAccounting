using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using zaneco_Accounting_System.module;
using DevExpress.XtraGrid.Views.Grid;

namespace zaneco_Accounting_System
{
    public partial class cvJournal : Form
    {

        //private connDBtmp db = new connDBtmp();
        //private MySqlConnection conn = new MySqlConnection();
        //private connDBtmp db_tmp = new connDBtmp();        
        //private MySqlConnection conn_tmp= new MySqlConnection();        
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlCommand cmdQ = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private MySqlDataReader dr;
        private DataSet ds = new DataSet();
        private unitClass uc = new unitClass();

        private DateTime StartOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        private DateTime EndOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));


        private Boolean _isCV_;
        //==Public ===========================
        // public connectionDB db_tmpB = new connectionDB();
        //public MySqlConnection conn_tmpB = new MySqlConnection();

        public cvJournal()
        {
            InitializeComponent();

            this._isCV_ = false;
        }

        public void setisCV(Boolean iscv_)
        {
            this._isCV_ = iscv_;
        }
        

        private void close_bnt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editAccntCode_btn_Click(object sender, EventArgs e)
        {
            String cvno = "";
            try
            {
                checkvoucherFrm frm = new checkvoucherFrm();
                frm.Text = "Preview Check Voucher (Payment)";
                                
                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                cvno = gridControl.GetRowCellValue(RowCount, "idcheckvoucher").ToString();

                if (gridControl.GetRowCellValue(RowCount, "cvpcode").ToString() == "CANCELLED")
                    return;

                frm.setcvNum(cvno);
                frm.setdateF(fr_date.Value);
                frm.setdateT(to_date.Value);
                frm.setfilter(CodeName_tf.Text);

                frm.RefreshDgv += new checkvoucherFrm.DoEvent(fm_RefreshDgv);

                //=================================
                frm.printCheck_btn.Enabled = false;
                frm.isvoid_cb.Enabled = false;
                //=================================

                frm.setUserid(gridControl.GetRowCellValue(RowCount, "userID").ToString());

                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {
            checkvoucherFrm frm = new checkvoucherFrm();
            frm.Text = "Add Check Voucher (Payment)";
            frm.frmcvJournalInitl(this);
            frm.ShowDialog();
        }

        private void cvJournal_Load(object sender, EventArgs e)
        {
            //conn = db.getConn();
            //conn_tmp = db_tmp.getConn();
            //conn_tmpB = db_tmpB.getConn();
            this.checkvoucherTableAdapter.Connection.ConnectionString = globalmainFrm.getConnString();

            fr_date.Value = StartOfMonth;
            to_date.Value = EndOfMonth;
            loadCV();

            if (_isCV_ == false)
            {
                addAccntCode_btn.Enabled = false;
                update_btn.Enabled = false;
                deleteAccntCode_btn.Enabled = false;
            }
           
        }

        void fm_RefreshDgv(string dateFR, string dateTo, string filterTF)
        {
            String qry = "  Select * from checkvoucher " +
                        "  where cvdate between @datefrom and @dateto and " +
                        "        cvnumber like @cvno OR " +
                        "        cvdate between @datefrom and @dateto and " +
                        "        cvpname like @cvno order by idcheckvoucher desc ";

            //cmd = new MySqlCommand(qry, conn_tmp);

            ds = new DataSet();
            
            try
            {
                //conn_tmp.Open();
                da = new MySqlDataAdapter(qry, globalmainFrm.getConn_accnt());

                da.SelectCommand.Parameters.AddWithValue("@cvno", "%" + filterTF + "%");
                da.SelectCommand.Parameters.AddWithValue("@datefrom", dateFR);
                da.SelectCommand.Parameters.AddWithValue("@dateto", dateTo);
                da.Fill(ds, "checkv");
                //checkv_dg.AutoGenerateColumns = false;
                gridControl1.DataSource = ds.Tables["checkv"];

                da.Dispose();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
            }
             /*
            foreach (DataGridViewRow row in checkv_dg.Rows)
            {
                //Tried to set rows directly
                // row.Cells["TrackingId"].Value = "";
                try
                {
                    if (Boolean.Parse(row.Cells["isvoid"].Value.ToString()))
                    {
                        row.Cells[1].Style.ForeColor = Color.Red;
                        row.Cells[2].Style.ForeColor = Color.Red;
                        row.Cells[3].Style.ForeColor = Color.Red;
                        row.Cells[4].Style.ForeColor = Color.Red;
                        row.Cells[5].Style.ForeColor = Color.Red;
                        row.Cells[6].Style.ForeColor = Color.Red;
                        row.Cells[7].Style.ForeColor = Color.Red;
                        row.Cells[8].Style.ForeColor = Color.Red;

                    }
                    else
                    {
                        row.Cells[1].Style.ForeColor = Color.Black;
                        row.Cells[2].Style.ForeColor = Color.Black;
                        row.Cells[3].Style.ForeColor = Color.Black;
                        row.Cells[4].Style.ForeColor = Color.Black;
                        row.Cells[5].Style.ForeColor = Color.Black;
                        row.Cells[6].Style.ForeColor = Color.Black;
                        row.Cells[7].Style.ForeColor = Color.Black;
                        row.Cells[8].Style.ForeColor = Color.Black;
                    }
                }
                catch
                { }

            }*/
        }


        public void loadCV()
        {

            String qry = "  Select * from checkvoucher "+
                         "  where cvdate between @datefrom and @dateto and "+
                         "        cvnumber like @cvno OR "+
                         "        cvdate between @datefrom and @dateto and "+
                         "        cvpname like @cvno order by cvdate desc,cvnumber desc ";
                        
            //cmd = new MySqlCommand(qry, conn_tmp);

            ds = new DataSet();

            try
            {
                //conn_tmp.Open();
                da = new MySqlDataAdapter(qry, globalmainFrm.getConn_accnt());

                da.SelectCommand.Parameters.AddWithValue("@cvno", "%" + CodeName_tf.Text + "%");
                da.SelectCommand.Parameters.AddWithValue("@datefrom", fr_date.Value.ToString("yyyy-MM-dd"));
                da.SelectCommand.Parameters.AddWithValue("@dateto", to_date.Value.ToString("yyyy-MM-dd"));
                da.Fill(ds, "checkv");
                //checkv_dg.AutoGenerateColumns = false;
                //checkv_dg.DataSource = ds.Tables["checkv"];
                gridControl1.DataSource = ds.Tables["checkv"];

                da.Dispose();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
            }

           

        }

        private void searchCode_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void CodeName_tf_TextChanged(object sender, EventArgs e)
        {
           
        }
        private Boolean getcvPosted(String cvno)
        {
            Boolean posted = false;
            String qry = "Select posted from checkvoucher where cvnumber = '"+cvno+"'";
            cmd = new MySqlCommand(qry,globalmainFrm.getConn_accnt());

            try
            {
                //conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    posted = dr.GetBoolean("posted");

                dr.Close();
                //conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                dr.Close();
                //conn.Close();
            }

            return posted;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String cvno = "";
            String code = "";
                        
            try
            {
                checkvoucherFrm frm = new checkvoucherFrm();
                frm.Text = "Update Check Voucher (Payment)";

                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);
                                
                cvno = gridControl.GetRowCellValue(RowCount, "idcheckvoucher").ToString();
                code = gridControl.GetRowCellValue(RowCount, "cvnumber").ToString();

                if (gridControl.GetRowCellValue(RowCount, "cvpcode").ToString() == "CANCELLED")
                {
                    MessageBox.Show("Unable to update the cancelled CV entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(gridControl.GetRowCellValue(RowCount, "userID").ToString().Equals(globalmainFrm.userlog)))
                {
                    MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userID").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(getcvPosted(code)))
                {
                    frm.setcvNum(cvno);

                    //===set to global form event============================
                    frm.RefreshDgv += new checkvoucherFrm.DoEvent(fm_RefreshDgv);

                    frm.setdateF(fr_date.Value);
                    frm.setdateT(to_date.Value);
                    frm.setfilter(CodeName_tf.Text);
                    frm.setUserid(gridControl.GetRowCellValue(RowCount, "userID").ToString());

                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("CV Number: " + code + "\n Check Voucher number was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);                            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                    
            
        }

        private void CodeName_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loadCV();

        }

        private void chartacamDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteAccntCode_btn_Click(object sender, EventArgs e)
        {
            //int selectedIndex = checkv_dg.SelectedCells[0].RowIndex;
            //DataGridViewRow sRow = checkv_dg.Rows[selectedIndex];

            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);
                       
            if (!(gridControl.GetRowCellValue(RowCount, "userID").ToString().Equals(globalmainFrm.userlog)))
            {
                MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userID").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (gridControl.GetRowCellValue(RowCount, "cvpcode").ToString() == "CANCELLED")
                return;

            cancelPanel.Location = new Point(480, 147);
            cancelPanel.Visible = true;
            panel4.Enabled = false;
            gridControl1.Enabled = false;
            panel1.Enabled = false;

            cvlbl.Text = gridControl.GetRowCellValue(RowCount, "cvnumber").ToString();
                                   

        }
        private void cancelledcv(String cv_no,String user)
        {

            String qry = " insert into zanecoaccounting.trailcheckv(idcheckvoucher, cvnumber, cvdate, cvpcode, cvpname, cvpaddress, cvamount, total, refnumber, checknumber, voidcheck, voiddate, bankaccount, bank, paymentDesc, transCategory, cvStatus, userID, doctype, posted, postedby, posteddate, voidRemarks, forliquidation, mpcode, entrydate, executedby, datecancelled,remarks)" +
                        " (Select c.*, @executedby, now(),@remarks from zanecoaccounting.checkvoucher c where cvnumber = @cvno);" +
                        " insert into trailcheckvj(idcvJournal, idcheckvoucher, glaccountcode, glaccountname, accountcode, cvparticulars, date, debit, credit, cvnumber, isSF, userID, posted, postedby, posteddate, descSF, jobid, jobname, iscleared, mpcode, entrydate, executedby, datecancelled)" +
                        " (Select cj.*, @executedby, now() from cvjournal cj where cvnumber = @cvno);" +
                        " Update checkvoucher set cvpcode = 'CANCELLED', cvamount = 0.00,total=0.00,checknumber=concat('CANCELLED : ',now(),' - ',@executedby),refnumber=concat('CANCELLED : ',now(),' - ',@executedby) where cvnumber = @cvno; ";
                        //" Update checkvoucher set cvpcode = 'CANCELLED', cvamount = 0.00,total=0.00,cvnumber=concat('CANCELLED : ',now(),' - ',@executedby),checknumber=concat('CANCELLED : ',now(),' - ',@executedby),refnumber=concat('CANCELLED : ',now(),' - ',@executedby) where cvnumber = @cvno; ";

            String qry2 = "Delete  From cvjournal where cvnumber = @cvno";                         

           String qryQ = "Select posted from trailcheckvj where cvnumber = '" + cv_no + "' and DATE_FORMAT(datecancelled,'%Y-%m-%e') = DATE_FORMAT(current_date(),'%Y-%m-%e') ";
           

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@cvno", cv_no);
                cmd.Parameters.AddWithValue("@executedby",user);
                cmd.Parameters.AddWithValue("@remarks", remarkCancel_tf.Text);

                //MessageBox.Show(globalmainFrm.userlog + "\n Ronel", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();

                 
             }
             catch
             {
                 //conn_tmp.Close();                
             }      
                                   

            try
            {
                cmdQ = new MySqlCommand(qryQ, globalmainFrm.getConn_accnt());
                //conn.Open();
                dr = cmdQ.ExecuteReader();

                if (dr.Read())
                {
                    //posted = dr.GetBoolean("posted");
                    cmd = new MySqlCommand(qry2, globalmainFrm.getConn_accnt());
                    cmd.Parameters.AddWithValue("@cvno", cv_no);
                    //cmd.Parameters.AddWithValue("@executedby", user);
                    
                    //conn_tmp.Open();
                    cmd.ExecuteNonQuery();
                    //conn_tmp.Close();
                }                  

                dr.Close();
                //conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                //conn.Close();
            }

        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            loadCV();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            cancelPanel.Visible = false;
            panel4.Enabled = true;
            gridControl1.Enabled = true;
            panel1.Enabled = true;
        }

        private void okcancel_btn_Click(object sender, EventArgs e)
        {
            try
            { 
                if(remarkCancel_tf.Text.Length<4)
                {
                    MessageBox.Show("Unable to continue this process, invalid remarks entry...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(getcvPosted(cvlbl.Text)))
                {
                    cancelledcv(cvlbl.Text, globalmainFrm.userlog);
                }
                else
                    MessageBox.Show("CV Number: " + cvlbl.Text + "\n Check Voucher number was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            { }
        }

        private void cancelledd_btn_Click(object sender, EventArgs e)
        {
            cancelledcheckvoucherFrm frm = new cancelledcheckvoucherFrm();
            frm.ShowDialog();
        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void export_btn_Click(object sender, EventArgs e)
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
