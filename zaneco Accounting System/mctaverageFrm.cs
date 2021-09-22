using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excels = Microsoft.Office.Interop.Excel;
using zaneco_Accounting_System.moduledatasource;
using zaneco_Accounting_System.module;
using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;

namespace zaneco_Accounting_System
{
    public partial class mctaverageFrm : Form
    {
        private unitClass uc = new unitClass();
        private DataSet ds = new DataSet();
        
        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        private DataTable dt = new DataTable();
        private MySqlDataAdapter da;

        public mctaverageFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void loadExcel(String pathStr)
        {
            Excels.Application xlApp;
            Excels.Workbook xlWorkBook;
            Excels.Worksheet xlWorkSheet;
            Excels.Range range;

            //string str;
            int rCnt;
            //int cCnt;
            int rw = 0;
            int cl = 0;
            
            Boolean isErr = false;
            try
            {
                xlApp = new Excels.Application();
                //xlWorkBook = xlApp.Workbooks.Open(@"e:\average.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkBook = xlApp.Workbooks.Open(pathStr, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excels.Worksheet)xlWorkBook.Worksheets.get_Item(2);
                //object misValue = System.Reflection.Missing.Value;

                range = xlWorkSheet.UsedRange;
                rw = range.Rows.Count;
                cl = range.Columns.Count;

                progressPanel1.Location = new Point(393, 218);
                progressPanel1.Visible = true;

                postporgress.Location = new Point(393, 275);
                postporgress.Maximum = rw;
                postporgress.Value = 2;
                postporgress.Visible = true;

                for (rCnt = 2; rCnt <= rw; rCnt++)
                {

                    mctaverage mctaverage = new mctaverage();

                    try
                    { mctaverage.itemcode = (string)(range.Cells[rCnt, 2] as Excels.Range).Value.ToString(); }
                    catch
                    {
                        isErr = true;
                        mctaverage.itemcode = "";
                    }

                    try
                    {
                        mctaverage.itemname = (string)(range.Cells[rCnt, 3] as Excels.Range).Value.ToString();
                        //mctaverage.itemname = mctaverage.itemname.Replace("\"", "");
                    }
                    catch
                    { mctaverage.itemname = ""; }

                    try
                    { mctaverage.closingdate = (string)(range.Cells[rCnt, 4] as Excels.Range).Value.ToString("yyyy-MM-dd"); }
                    catch
                    {
                        isErr = true;
                        mctaverage.closingdate = "";
                    }

                    try
                    { mctaverage.qty = Double.Parse((string)(range.Cells[rCnt, 5] as Excels.Range).Value.ToString()); }
                    catch
                    { isErr = true; }

                    try
                    { mctaverage.average = Double.Parse((string)(range.Cells[rCnt, 6] as Excels.Range).Value.ToString()); }
                    catch
                    { isErr = true; }

                    mctaverage.userid = globalmainFrm.userlog;

                    if ((mctaverage.itemcode.ToString().Equals("")) && (mctaverage.itemname.ToString().Equals("")) && (mctaverage.closingdate.Equals("")))
                        rCnt = rw;

                    if (!(isErr))
                    {
                        if (mctaverage_datasource.Exist_average(mctaverage.itemcode, mctaverage.closingdate))
                            mctaverage_datasource.update_average(mctaverage);
                        else
                            mctaverage_datasource.insert_average(mctaverage);
                    }

                    isErr = false;
                    postporgress.Value = rCnt;
                }


                MessageBox.Show("MCT Item Index average cost successfully updated...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                postporgress.Visible = false;
                progressPanel1.Visible = false;
                xlWorkBook.Close(false, null, null);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
            catch
            {
                MessageBox.Show("Invalid MCT cost file format...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {
            //loadExcel();
            /*
            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadExcel(xtraOpenFileDialog1.FileName);
                //MessageBox.Show(xtraOpenFileDialog1.FileName);
            }*/

            from__date.Value = fr_date.Value;
            to__date.Value = to_date.Value;

            panelControl2.Enabled = false;
            panel3.Location = new Point(393, 218);
            panel3.Visible = true;
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xtraFolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void select_btn_Click(object sender, EventArgs e)
        {            
            gridControl1.DataSource = mctaverage_datasource.mctunion_filter(fr_date.Value.ToString("yyyy-MM-dd"), to_date.Value.ToString("yyyy-MM-dd")).Tables["mctaverage"];
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {            
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            switch (e.KeyCode)
            {                
                case Keys.Up:
                    RowCount--;
                    break;
                case Keys.Down:
                    RowCount++;
                    break;                    
            }
            
            try
            {
                GridView gridControl = new GridView();
                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);//.GetRowCellValue(RowCount, "description").ToString();
                description_tf.Text = gridControl.GetRowCellValue(RowCount, "description").ToString();
                mct_tf.Text = gridControl.GetRowCellValue(RowCount, "mctno").ToString();
            }   
            catch
            { }

            
                       
        }
                
        private void gridControl1_Click(object sender, EventArgs e)
        {
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            try
            {
                description_tf.Text = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(RowCount, "description").ToString();
                mct_tf.Text = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(RowCount, "mctno").ToString();
            }
            catch { }
        }

       
        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aveDate_cb.Items.Clear();
            foreach (DataRow dr in mctaverage_datasource.average_date().Tables["averagedate"].Rows)
            {
                aveDate_cb.Items.Add(dr["closingdate"].ToString());
            }

            cancelPanel.Visible = true;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            cancelPanel.Visible = false;
        }

        private void okcancel_btn_Click(object sender, EventArgs e)
        {
            mctaverage_datasource.updateCostAll(aveDate_cb.GetItemText(aveDate_cb.SelectedItem).ToString(), fr_date.Value.ToString("yyyy-MM-dd"),to_date.Value.ToString("yyyy-MM-dd"));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mctItemIndexFrm frm = new mctItemIndexFrm();
            frm.dateFrom = fr_date.Value.ToString("yyyy-MM-dd");
            frm.dateTo = to_date.Value.ToString("yyyy-MM-dd");
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure, you want to clear the selected date mct item index cost?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                mctaverage_datasource.clearCost(fr_date.Value.ToString("yyyy-MM-dd"), to_date.Value.ToString("yyyy-MM-dd"));
                gridControl1.DataSource = mctaverage_datasource.mctunion_filter(fr_date.Value.ToString("yyyy-MM-dd"), to_date.Value.ToString("yyyy-MM-dd")).Tables["mctaverage"];
            }
        }

        private void execute_btn_Click(object sender, EventArgs e)
        {
            mctaverage_datasource.import_mctcost(fr_date.Value.ToString("yyyy-MM-dd"), to_date.Value.ToString("yyyy-MM-dd"),from__date.Value.ToString("yyyy-MM-dd"), to__date.Value.ToString("yyyy-MM-dd"));
            gridControl1.DataSource = mctaverage_datasource.mctunion_filter(fr_date.Value.ToString("yyyy-MM-dd"), to_date.Value.ToString("yyyy-MM-dd")).Tables["mctaverage"];
            panel3.Visible = false;
            panelControl2.Enabled = true;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panelControl2.Enabled = true;
        }

        private void mctaverageFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();

            if (globalmainFrm.usertype.Equals("Admin"))
            {
                addAccntCode_btn.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }else
            {
                addAccntCode_btn.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }

            gridControl1.DataSource = mctaverage_datasource.mctunion_filter(fr_date.Value.ToString("yyyy-MM-dd"), to_date.Value.ToString("yyyy-MM-dd")).Tables["mctaverage"];
        }

        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            accountLedgerFrm frm = new accountLedgerFrm();

            try
            {
                GridView gridControl = new GridView();
                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);
                

                frm.accountcode_tf.Text = gridControl.GetRowCellValue(RowCount, "accountcode").ToString();
                frm.accountname_tf.Text = gridControl.GetRowCellValue(RowCount, "accountname").ToString();
                frm.date__fr = gridControl.GetRowCellValue(RowCount, "mctdate").ToString();//fr_date.Value.ToString("yyyy-MM-dd");
                frm.date__to = gridControl.GetRowCellValue(RowCount, "mctdate").ToString();//to_date.Value.ToString("yyyy-MM-dd");
                frm.descSource = "mct";


                //================================================
                //================================================
                String qry = "Select * from zanecoaccounting.chart where accountcode = @accountcode";
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@accountcode", gridControl.GetRowCellValue(RowCount, "accountcode").ToString());

                try
                {
                    conn_tmp.Open();

                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        
                        frm.dateasof_dp.Value = dr.GetDateTime("dateAsOf");
                        frm.balance_tf.Text = dr.GetDouble("BalAsOf").ToString("N02", uc.ci);
                        //frm.atype_tf.Text = dr.GetString("BalAsOf");
                        frm.category_tf.Text = dr.GetString("category");
                    }

                    dr.Close();
                    conn_tmp.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn_tmp.Close();
                }
            }
            catch
            { }

            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void updateMCTCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void menuAccount_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure, you want to reset the selected date mct item cost? \nThis process could override item cost permanently.", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                mctaverage_datasource.import_mctcostExist(fr_date.Value.ToString("yyyy-MM-dd"), to_date.Value.ToString("yyyy-MM-dd"));
                gridControl1.DataSource = mctaverage_datasource.mctunion_filter(fr_date.Value.ToString("yyyy-MM-dd"), to_date.Value.ToString("yyyy-MM-dd")).Tables["mctaverage"];
            }
        }
    }
}

