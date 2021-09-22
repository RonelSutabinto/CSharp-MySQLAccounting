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
using System.Drawing.Drawing2D;
using zaneco_Accounting_System.module;
using DevExpress.XtraGrid.Views.Grid;

namespace zaneco_Accounting_System
{
    public partial class journalFrm : Form
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

        private DateTime StartOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        private DateTime EndOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        //private MySqlDataAdapter da;

        private DataSet ds = new DataSet();        
        private MySqlDataAdapter da;

        private unitClass uc = new unitClass();
        private Boolean _isJV_;

        public journalFrm()
        {
            InitializeComponent();

            this._isJV_ = false;
        }

        public void setisJV(Boolean isjv_)
        {
            this._isJV_ = isjv_;
        }

        private void close_bnt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void journalFrm_Load(object sender, EventArgs e)
        {
            //MakeLabelRounded();

            conn_tmp = db_tmp.getConn();
           // this.journalv_dtTableAdapter.Connection.ConnectionString = db_tmp.getConnString();

            fr_date.Value = StartOfMonth;
            to_date.Value = EndOfMonth;
            loadjv();

            countForliquidation();

            if (_isJV_ == false)
            {
                addAccntCode_btn.Enabled = false;
                update_btn.Enabled = false;
                deleteAccntCode_btn.Enabled = false;
            }
        }

        private void countForliquidation()
        {
            String qry = " select    " +
                         "     sum(ifnull(f.cntr,0)) cntr    " +
                         "     from    " +
                         "    (Select    " +
                         "       c.cvdate,    " +                         
                         "       ifnull(c.cvamount,0) cvamount,    " +
                         "       c.refnumber,    " +                         
                         "       sum(ifnull(j.jvamount,0))  jvamount, " +
                         "       1 cntr   " +
                         "     from checkvoucher c   " +
                         "       left join journalv j on j.cvnumber = c.cvnumber " +
                         "       where c.forliquidation = 1  and " +
                         "           CURDATE() >= c.cvdate and " +
                         "           c.cvdate >= DATE_SUB( CURDATE(), INTERVAL 2 YEAR) " +
                         "        group by c.cvnumber  " +
                         "     ) f    " +                         
                         "     where f.cvamount > f.jvamount ";

            //===Count Out of due APV=====================
            //============================================
            String cntr_ = "0";
            try
            {
                conn_tmp.Open();
                cmd = new MySqlCommand(qry, conn_tmp);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cntr_ = dr.GetString("cntr");
                }
                dr.Close();
                conn_tmp.Close();
            }
            catch
            {
                conn_tmp.Close();
            }

            cntr_lb.Text = cntr_;
        }
        private void loadjv()
        {
            String qry = " SELECT  "+
                         "     idjournal,    " +
                         "     jvnumber,  " +
                         "     jvdate,  " +
                         "     transCategory,  " +
                         "     docdate,  " +
                         "     description,  " +
                         "     jvamount,  " +
                         "     isposted,  " +                         
                         "     'JV' as doctype," +
                         "     rvnumber," +
                         "     cvnumber," +
                         "     userid  " +
                         "   FROM journalv  " +
                         "   WHERE (jvnumber like @jvno OR rvnumber like @jvno or cvnumber like @jvno) AND  " +
                         "               jvdate between @datefrom and @dateto order by docdate asc";

            ds = new DataSet();

            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);

                da.SelectCommand.Parameters.AddWithValue("@jvno", "%" + docno_tf.Text + "%");                
                da.SelectCommand.Parameters.AddWithValue("@datefrom", fr_date.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto", to_date.Value);

                da.Fill(ds, "journalv");
                //journalv_dgv.AutoGenerateColumns = false;
                gridControl1.DataSource = ds.Tables["journalv"];


                da.Dispose();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }

            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

            //if (gridControl.GetRowCellValue(RowCount, "cvnumber").ToString() == "CANCELLED")

            /*============================================================================
             * int rowcnt = journalv_dgv.Rows.Count;
            for (int i = 0; i < rowcnt - 1; i++)
            {

                if (journalv_dgv.Rows[i].Cells[8].Value.ToString().Equals(globalmainFrm.userlog))
                {
                    journalv_dgv.Rows[i].Cells[1].Style.BackColor = Color.MistyRose;
                    journalv_dgv.Rows[i].Cells[2].Style.BackColor = Color.MistyRose;
                    journalv_dgv.Rows[i].Cells[3].Style.BackColor = Color.MistyRose;
                    journalv_dgv.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
                    journalv_dgv.Rows[i].Cells[5].Style.BackColor = Color.MistyRose;
                    journalv_dgv.Rows[i].Cells[6].Style.BackColor = Color.MistyRose;
                    journalv_dgv.Rows[i].Cells[7].Style.BackColor = Color.MistyRose;
                }
                else
                {
                    journalv_dgv.Rows[i].Cells[1].Style.BackColor = Color.White;
                    journalv_dgv.Rows[i].Cells[2].Style.BackColor = Color.White;
                    journalv_dgv.Rows[i].Cells[3].Style.BackColor = Color.White;
                    journalv_dgv.Rows[i].Cells[4].Style.BackColor = Color.White;
                    journalv_dgv.Rows[i].Cells[5].Style.BackColor = Color.White;
                    journalv_dgv.Rows[i].Cells[6].Style.BackColor = Color.White;
                    journalv_dgv.Rows[i].Cells[7].Style.BackColor = Color.White;
                }
===================================================================
            }*/
            //journalv_dgv.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.MistyRose;
            /*try
            {
                // Remember the vertical scroll position of the DataGridView
                int saveVScroll = 0;
                if (journalv_dgv.Rows.Count > 0)
                    saveVScroll = journalv_dgv.FirstDisplayedCell.RowIndex;

                //========================================================
               // this.journalv_dtTableAdapter.Fill(this.journalv.journalv_dt, "%", "%" + docno_tf.Text + "%", fr_date.Value, to_date.Value);

                // Go back to the saved vertical scroll position if available
                if (saveVScroll != 0 && saveVScroll < journalv_dgv.Rows.Count)
                    journalv_dgv.FirstDisplayedScrollingRowIndex = saveVScroll;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
            }*/
        }

        private void searchCode_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {            
            jvdetailsFrm frm = new jvdetailsFrm();
            frm.frmjournalInitl(this);
            frm.Text = "Add Journal Voucher Entry";
            frm.ShowDialog();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {        

            String jvid = "";
            String jvno = "";

            
            try
            {
                jvdetailsFrm frm = new jvdetailsFrm();
                frm.Text = "Update Journal Voucher Entry";



                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                if (gridControl.GetRowCellValue(RowCount, "cvnumber").ToString() == "CANCELLED")
                    return;

                if (!(gridControl.GetRowCellValue(RowCount, "userid").ToString().Equals(globalmainFrm.userlog)))
                {
                    MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userid").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                jvid = gridControl.GetRowCellValue(RowCount, "idjournal").ToString();
                jvno = gridControl.GetRowCellValue(RowCount, "jvnumber").ToString();

                if (!(getjvPosted(jvno)))
                {
                    frm.setjvno(jvno);
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("JV Number: " + jvno + "\n Journal Voucher number was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*try
            {
                jvdetailsFrm frm = new jvdetailsFrm();
                frm.Text = "Update Journal Voucher Entry";
                               
                
                if (journalv_dgv.SelectedCells.Count > 0)
                {
                    int selectedIndex = journalv_dgv.SelectedCells[0].RowIndex;

                    DataGridViewRow sRow = journalv_dgv.Rows[selectedIndex];

                    if (sRow.Cells[3].Value.ToString() == "CANCELLED")
                        return;

                    if (!(sRow.Cells[8].Value.ToString().Equals(globalmainFrm.userlog)))
                    {
                        MessageBox.Show("Authorize user ID: " + sRow.Cells[8].Value.ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    jvid = sRow.Cells[0].Value.ToString();
                    jvno = sRow.Cells[1].Value.ToString();

                    if (!(getjvPosted(jvno)))
                    {
                        frm.setjvno(jvno);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("JV Number: " + jvno + "\n Journal Voucher number was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
            }*/

        }

        
        private Boolean getjvPosted(String jvno_)
        {
            Boolean posted = false;
            String qry = "Select isposted from journalv where jvnumber = '"+ jvno_ + "'";
            cmd = new MySqlCommand(qry, conn_tmp);

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    posted = dr.GetBoolean("isposted");

                dr.Close();
                conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                dr.Close();
                conn_tmp.Close();
            }

            return posted;
        }

        private void preview_btn_Click(object sender, EventArgs e)
        {
            String jvid = "";
            String jvno = "";
                        
            try
            {
                jvdetailsFrm frm = new jvdetailsFrm();
                frm.Text = "Preview Journal Voucher Entry";


                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                if (gridControl.GetRowCellValue(RowCount, "cvnumber").ToString() == "CANCELLED")
                    return;

                jvid = gridControl.GetRowCellValue(RowCount, "idjournal").ToString();
                jvno = gridControl.GetRowCellValue(RowCount, "jvnumber").ToString();

                frm.setjvno(jvno);
                frm.ShowDialog();                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*try
            {
                jvdetailsFrm frm = new jvdetailsFrm();
                frm.Text = "Preview Journal Voucher Entry";
                               
                if (journalv_dgv.SelectedCells.Count > 0)
                {
                    int selectedIndex = journalv_dgv.SelectedCells[0].RowIndex;
                    DataGridViewRow sRow = journalv_dgv.Rows[selectedIndex];

                    if (sRow.Cells[3].Value.ToString() == "CANCELLED")
                        return;

                    jvid = sRow.Cells[0].Value.ToString();
                    jvno = sRow.Cells[1].Value.ToString();

                    frm.setjvno(jvno);
                    frm.ShowDialog();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void deleteAccntCode_btn_Click(object sender, EventArgs e)
        {
            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

            
            try
            {

                String jv_no = gridControl.GetRowCellValue(RowCount, "jvnumber").ToString();

                if (gridControl.GetRowCellValue(RowCount, "cvnumber").ToString() == "CANCELLED")
                    return;

                if (!(gridControl.GetRowCellValue(RowCount, "userid").ToString().Equals(globalmainFrm.userlog)))
                {
                    MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userid").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(getjvPosted(jv_no)))
                {
                    DialogResult d = MessageBox.Show("JV No.:" + gridControl.GetRowCellValue(RowCount, "jvnumber").ToString() + "\n Are you sure, you want to cancel this JV number?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (d == DialogResult.Yes)
                    {
                        canceljv(jv_no, globalmainFrm.userlog);
                        //========================================================
                        // this.journalv_dtTableAdapter.Fill(this.journalv.journalv_dt, "%", "%" + docno_tf.Text + "%", fr_date.Value, to_date.Value);

                    }
                }
                else
                    MessageBox.Show("CV Number: " + jv_no + "\n Journal Voucher number was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            { }

            /*
            int selectedIndex = journalv_dgv.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = journalv_dgv.Rows[selectedIndex];

            try
            {

                String jv_no = sRow.Cells[1].Value.ToString();

                if (sRow.Cells[3].Value.ToString() == "CANCELLED")
                    return;

                if (!(sRow.Cells[8].Value.ToString().Equals(globalmainFrm.userlog)))
                {
                    MessageBox.Show("Authorize user ID: " + sRow.Cells[8].Value.ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(getjvPosted(jv_no)))
                {
                    DialogResult d = MessageBox.Show("JV No.:" + sRow.Cells[1].Value.ToString() + "\n Are you sure, you want to cancel this JV number?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (d == DialogResult.Yes)
                    {
                        canceljv(jv_no,globalmainFrm.userlog);                                               
                        //========================================================
                       // this.journalv_dtTableAdapter.Fill(this.journalv.journalv_dt, "%", "%" + docno_tf.Text + "%", fr_date.Value, to_date.Value);
                                                
                    }
                }
                else
                    MessageBox.Show("CV Number: " + jv_no + "\n Journal Voucher number was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            { }*/
        }

        private void canceljv(String jv_no,String user)
        {
            String qry = " insert into trailjv    "+
                         "   (Select j.*, @executedby, current_date() from journalv j where j.jvnumber = @jvnumber );    " +
                         " insert into trailjvdetails    " +
                         "   (Select jd.*, @executedby, current_date() from jvdetails jd where jd.jvnumber = @jvnumber );    " +
                         " Delete from jvdetails where jvnumber = @jvnumber;    " +
                         " update journalv set jvnumber = concat('CANCELLED : ', now(), ' - ', @executedby), jvamount = 0 where jvnumber = @jvnumber; ";


            try
            {
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@jvnumber", jv_no);
                cmd.Parameters.AddWithValue("@executedby", user);

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch
            {
                conn_tmp.Close();
            }


        }

        private void journalv_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex >= 0)
            {
                if(!(journalv_dgv.Rows[e.RowIndex].Cells[8].Value.ToString().Equals(globalmainFrm.userlog)))
                {
                    journalv_dgv.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.MistyRose;
                }
                else
                {
                    journalv_dgv.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                }
                /* ((descSF == "APV Debit") || (descSF == "RV Debit"))
                {
                    tb_dbGrid.Rows[e.RowIndex].Cells[4].Value = "0.00";
                    sumDC();
                    return;
                }

                if ((descSF == "Surce Of Fund"))
                {
                    tb_dbGrid.Rows[e.RowIndex].Cells[3].Value = "0.00";
                    sumDC();
                    return;
                }
            }*/
        }

        private void cntr_lb_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(cntr_lb.Text)>0)
            {
                jvdetailsFrm frm = new jvdetailsFrm();
                frm.frmjournalInitl(this);
                frm.Text = "Add Journal Voucher Entry";
                frm.setIsnotify(true);
                frm.ShowDialog();
            }
            
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            loadjv();
            countForliquidation();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void docno_tf_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void export_bnt_Click(object sender, EventArgs e)
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

        private void journalFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
