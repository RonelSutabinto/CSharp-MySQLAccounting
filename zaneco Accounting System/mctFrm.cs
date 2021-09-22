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
using zaneco_Accounting_System.module;
using DevExpress.XtraGrid.Views.Grid;

namespace zaneco_Accounting_System
{
    public partial class mctFrm : Form
    {
        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        //private DataTable dt = new DataTable();
        private MySqlDataAdapter da;
        private unitClass uc = new unitClass();
        private Boolean _isMCT_;

        private DataSet ds;

        public mctFrm()
        {
            InitializeComponent();

            this._isMCT_ = false;
        }

        public void setisMCT(Boolean ismct_)
        {
            this._isMCT_ = ismct_;
        }

        private void close_bnt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {
            mctdetailsFrm frm = new mctdetailsFrm();
            frm.Text = "Add MCT Details Entry";

            //===set to global form event============================
            frm.RefreshDgv += new mctdetailsFrm.DoEvent(loadmct);

            frm.ShowDialog();
        }
                
        public void loadmct()
        {
            String qry = " Select " +
                         "     m.*," +
                         "     if(posted=0,'NO','YES') postedf," +
                         "     DATE_FORMAT(m.date,'%Y-%m-%d')  dateF," +
                         "     concat(m.forwardedFrom,' - ',m.forwardedTo) forwardarea " +
                         " from materialct m " +
                         " where m.mctno like @mctno and " +                        
                         "       DATE_FORMAT(m.mctdate,'%Y-%m-%d') between @datefrom and @dateto";

            // String qry = "Select m.*,if(posted=0,'NO','YES') postedf from materialct m where m.mctno like @mctno and m.date between @datefrom and @dateto";
            cmd = new MySqlCommand(qry, conn_tmp);
           
            ds = new DataSet();

            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);               

                da.SelectCommand.Parameters.AddWithValue("@mctno", "%"+search_tf.Text+"%");
                da.SelectCommand.Parameters.AddWithValue("@datefrom", fr_date.Value.ToString("yyyy-MM-dd"));
                da.SelectCommand.Parameters.AddWithValue("@dateto", to_date.Value.ToString("yyyy-MM-dd"));
                da.Fill(ds, "mct");
                //mct_dgv.AutoGenerateColumns = false;
                //mct_dgv.DataSource = ds.Tables["mct"];
                gridControl1.DataSource = ds.Tables["mct"]; 

                da.Dispose();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

        private void mctFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            loadmct();

            if (_isMCT_ == false)
            {
                addAccntCode_btn.Enabled = false;
                update_btn.Enabled = false;
                deleteAccntCode_btn.Enabled = false;                
            }
        }

        private void searchCode_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            mctdetailsFrm frm = new mctdetailsFrm();
            frm.Text = "Update MCT Details";
            frm.mctFrmInitl(this);

            //===set to global form event============================
            frm.RefreshDgv += new mctdetailsFrm.DoEvent(loadmct);


            try
            {                

                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

            
                if (gridControl.GetRowCellValue(RowCount, "mctno").ToString().Substring(0,9) == "CANCELLED")
                {
                    return;

                }

                if (!(gridControl.GetRowCellValue(RowCount, "userID").ToString().Equals(globalmainFrm.userlog)))
                {
                    MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userID").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (gridControl.GetRowCellValue(RowCount, "posted").ToString() == "0")
                {
                    frm.setmctno(gridControl.GetRowCellValue(RowCount, "mctno").ToString());
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("MCT Number: " + gridControl.GetRowCellValue(RowCount, "mctno").ToString() + "\n MCT was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                
            }
           catch
           { };
           

        }

        private void preview_btn_Click(object sender, EventArgs e)
        {
            mctdetailsFrm frm = new mctdetailsFrm();
            frm.Text = "Preview MCT Details";
            frm.mctFrmInitl(this);

            //===set to global form event============================
            frm.RefreshDgv += new mctdetailsFrm.DoEvent(loadmct);


            try
            {

                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                if (gridControl.GetRowCellValue(RowCount, "mctno").ToString().Substring(0, 9) == "CANCELLED")
                {
                    return;
                }

                frm.setmctno(gridControl.GetRowCellValue(RowCount, "mctno").ToString());
                frm.ShowDialog();
            }
            catch
            { };
            
        }

        private void deleteAccntCode_btn_Click(object sender, EventArgs e)
        {
            try
            {
               
                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                mctlbl.Text = gridControl.GetRowCellValue(RowCount, "mctno").ToString();

                if (!(gridControl.GetRowCellValue(RowCount, "userID").ToString().Equals(globalmainFrm.userlog)))
                {
                    MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userID").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

              
                if (gridControl.GetRowCellValue(RowCount, "posted").ToString() == "0")
                {
                    DialogResult d = MessageBox.Show("MCT No.:" + gridControl.GetRowCellValue(RowCount, "mctno").ToString() + "\n Are you sure, you want to cancel this MCT number?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (d == DialogResult.Yes)
                    {
                        cancelmct(gridControl.GetRowCellValue(RowCount, "mctno").ToString(), globalmainFrm.userlog);
                        loadmct();
                    }
                }
                else
                    MessageBox.Show("MCT Number: " + gridControl.GetRowCellValue(RowCount, "mctno").ToString() + "\n MCT was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);

               
            }
            catch
            { }

            cancelPanel.Location = new Point(480, 147);
            cancelPanel.Visible = true;
            
        }
        private void cancelmct(String mct_no,String user)
        {
            

            String qry = " insert into trailmct  " +
                         "   (Select a.*, @executedby, current_date(),@remarks from materialct a where a.mctno = @mctno );  " +
                         " insert into trailmctdetails  " +
                         "   (Select ad.*, @executedby, current_date() from mctdetails ad where ad.mctno = @mctno );  " +
                         " Delete from mctdetails where mctno = @mctno;  " +
                         " update materialct set mctno = concat('CANCELLED : ', now(), ' - ', @executedby) where mctno = @mctno; ";

            try
            {
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@mctno", mct_no);
                cmd.Parameters.AddWithValue("@remarks", remarkCancel_tf.Text);
                cmd.Parameters.AddWithValue("@executedby", user);

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();

                cancelPanel.Visible = false;
                panel4.Enabled = true;               
                panel1.Enabled = true;
                gridControl1.Enabled = true;
                //MessageBox.Show("Ronel");
                loadmct();
            }
            catch
            {
                conn_tmp.Close();
            }

        }

        private void mct_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            loadmct();
        }

        private void okcancel_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (remarkCancel_tf.Text.Length < 4)
                {
                    MessageBox.Show("Unable to continue this process, invalid remarks entry...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!(getcvPosted(mctlbl.Text)))
                {
                    cancelmct(mctlbl.Text, globalmainFrm.userlog);
                }
                else
                    MessageBox.Show("MCT Number: " + mctlbl.Text + "\n MCT number was already posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            { }
        }

        private Boolean getcvPosted(String mctno)
        {
            Boolean posted = false;
            String qry = "Select posted from materialct where mctno = '" + mctno + "'";
            cmd = new MySqlCommand(qry, conn_tmp);

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    posted = dr.GetBoolean("posted");

                dr.Close();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                conn_tmp.Close();
            }

            return posted;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {            
            cancelPanel.Visible = false;
            panel4.Enabled = true;
            mct_dgv.Enabled = true;
            panel1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mctaverageFrm frm = new mctaverageFrm();
            frm.Text = "MCT Item Index Average Detail";
            frm.fr_date.Value = fr_date.Value;
            frm.to_date.Value = to_date.Value;
            frm.ShowDialog();
            
        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
