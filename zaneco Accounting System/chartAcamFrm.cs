using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using zaneco_Accounting_System.Reports;
using zaneco_Accounting_System.module;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;



namespace zaneco_Accounting_System
{
    public partial class chartAcamFrm : Form
    {
        
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        //private MySqlDataReader dr;
        private unitClass uc = new unitClass();
        private DataTable dt = new DataTable();

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private Boolean _ischart_;
        private String _usertype_ = "";
                              
        public chartAcamFrm()
        {
            InitializeComponent();

            this._ischart_ = false;
        }
           
        public void setischart(Boolean ischart_)
        {
            this._ischart_ = ischart_;
        }

        public void setuserType(String usert)
        {
            this._usertype_ = usert;
        }

        /*private void loadChart(String codeStr,String nameStr)
        {
            String qry = "Select c.cstatus," +
                         "   c.accountcode," +
                         "   c.accountname," +
                         "   c.accounttype," +
                         "   c.accountledgertype ledgertype, " +
                         "   c.category " +
                         " from chart c  " +
                         "   where c.accountcode like @code  or c.accountname like @name " +
                         "   order by c.accountcode  ";

            try
            {
                ds = new DataSet();
                da = new MySqlDataAdapter(qry,conn);
                da.SelectCommand.Parameters.AddWithValue("@code", codeStr);
                da.SelectCommand.Parameters.AddWithValue("@name", "%" + nameStr + "%");
                da.Fill(ds, "chartAcam");
                dataGridView1.DataSource = ds.Tables["chartAcam"];
            }
            catch (MySqlException ex)
            { MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally 
            { }
            
        }*/

        private void chartAcam_Load(object sender, EventArgs e)
        {
            conn = db.getConn();
            conn_tmp = db_tmp.getConn();
            //this.chartacamTableAdapter.Connection.ConnectionString = db.getConnString();
            ldgrTpe_cb.SelectedIndex = 2;
            date_from.Value = uc.StartOfMonth;
            date_to.Value = uc.EndOfMonth;

            loadchart();

            if(!(_usertype_.Equals("Admin")))
            {
                addAccntCode_btn.Enabled = false;
                editAccntCode_btn.Enabled = false;
                setForward_btn.Enabled = false;
            }

        }

    

        private void chartacamBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           this.Validate();
           // this.chartacamBindingSource.EndEdit();
           // this.tableAdapterManager.UpdateAll(this.chart_dataSource);
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {          
        }

        

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void addNewAccountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {
            addChartAccountFrm frm = new addChartAccountFrm();
            frm.frmtitle_lb.Text = "Add chart of account";
            frm.ShowDialog();
        }

        private void close_bnt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void genLedger_btn_Click(object sender, EventArgs e)
        {
            accountLedgerFrm frm = new accountLedgerFrm();

            try
            {
                globalcutoff.isforward = false;
                //int selectedrowindex = chartaGridView.SelectedCells[0].RowIndex;
                //DataGridViewRow sRow = chartaGridView.Rows[selectedrowindex];

                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);
                                
                frm.accountcode_tf.Text = gridControl.GetRowCellValue(RowCount, "accountcode").ToString(); // sRow.Cells[0].Value.ToString();
                frm.accountname_tf.Text = gridControl.GetRowCellValue(RowCount, "accountname").ToString();//sRow.Cells[1].Value.ToString();
                frm.dateasof_dp.Value = DateTime.Parse(gridControl.GetRowCellValue(RowCount, "dateAsOf").ToString()); //DateTime.Parse(sRow.Cells[4].Value.ToString());
                frm.balance_tf.Text = Double.Parse(gridControl.GetRowCellValue(RowCount, "BalAsOf").ToString()).ToString("N02", uc.ci);//Double.Parse(sRow.Cells[5].Value.ToString().Replace(",", "")).ToString("N02", uc.ci);
                frm.atype_tf.Text = gridControl.GetRowCellValue(RowCount, "accounttype").ToString();//sRow.Cells[3].Value.ToString();
                frm.category_tf.Text = gridControl.GetRowCellValue(RowCount, "category").ToString();//sRow.Cells[2].Value.ToString();
            }
            catch
            { }

            frm.ShowDialog();
        }

        private void loadchart()
        {
            //bank_cb.GetItemText(bank_cb.SelectedItem).ToString()
            // bank_cb.FindStringExact(dr.GetString("bank"))
            String typeCB = ldgrTpe_cb.GetItemText(ldgrTpe_cb.SelectedItem).ToString();

            if (ldgrTpe_cb.GetItemText(ldgrTpe_cb.SelectedItem).ToString() == "ALL")
                typeCB = "";            

            /*String qry = " Select f.*,(f.balasof+f.debit-f.credit) as endingbal from    " +
                        "    (Select   " +
                        "      (ifnull((Select sum(ifnull(cvj.debit, 0)) from cvjournal cvj left join checkvoucher cv on cv.cvnumber = cvj.cvnumber  where cv.cvnumber = cvj.cvnumber and cvj.accountcode = c.accountcode and cv.cvdate between @datefrom and @dateto), 0) +   " +
                        "      ifnull((Select sum(ifnull(ad.debit, 0)) from apvdetails ad left join apvoucher a on a.apvnumber = ad.apvnumber where a.apvnumber = ad.apvnumber and ad.accountcode = c.accountcode and a.apvdate between @datefrom and @dateto), 0) +   " +
                        "      ifnull((Select sum(ifnull(jd.debit, 0)) from jvdetails jd  left join journalv j on j.jvnumber = jd.jvnumber where j.jvnumber = jd.jvnumber and jd.accountcode = c.accountcode and DATE_FORMAT(j.jvdate, '%Y-%m-%d') between @datefrom and @dateto),0)   +   " +
                        "      ifnull((Select sum(ifnull(mt.debit, 0)) from mctdetails mt left join materialct m on m.mctno = mt.mctno where m.mctno = mt.mctno and mt.accountcode = c.accountcode and DATE_FORMAT(m.mctdate, '%Y-%m-%d') between @datefrom and @dateto),0) ) as Debit,         " +
                        "      (ifnull((Select sum(ifnull(cvj.credit, 0)) from cvjournal cvj left join checkvoucher cv on cv.cvnumber = cvj.cvnumber  where cv.cvnumber = cvj.cvnumber and cvj.accountcode = c.accountcode and cv.cvdate between @datefrom and @dateto), 0) +   " +
                        "      ifnull((Select sum(ifnull(ad.credit, 0)) from apvdetails ad left join apvoucher a on a.apvnumber = ad.apvnumber where a.apvnumber = ad.apvnumber and ad.accountcode = c.accountcode and a.apvdate between @datefrom and @dateto),0)   +   " +
                        "      ifnull((Select sum(ifnull(jd.credit, 0)) from jvdetails jd  left join journalv j on j.jvnumber = jd.jvnumber where j.jvnumber = jd.jvnumber and jd.accountcode = c.accountcode and DATE_FORMAT(j.jvdate, '%Y-%m-%d') between @datefrom and @dateto),0)   +   " +
                        "      ifnull((Select sum(ifnull(mt.credit, 0)) from mctdetails mt left join materialct m on m.mctno = mt.mctno where m.mctno = mt.mctno and mt.accountcode = c.accountcode and DATE_FORMAT(m.mctdate, '%Y-%m-%d') between @datefrom and @dateto),0) ) as Credit,	     " +
                        "      c.*   " +
                        "    from chart c   " +
                        "    where (c.accountcode like @code OR c.accountname like @acode)   " +
                        "    group by c.accountcode ) f   " +
                        " where f.accounttype like @atype and (ifnull(f.BalAsOf, 0) <> 0 OR ifnull(f.debit,0) <> 0 OR ifnull(f.credit,0) <> 0 )  " +
                        " order by f.accountcode   ";*/

            String qry = "  Select f.*," +
                         "         if((f.balasof + f.debit - f.credit)>0,(f.balasof + f.debit - f.credit),0.00) as endingdebit," +
                         "         if((f.balasof + f.debit - f.credit)<0,-(f.balasof + f.debit - f.credit),0.00) as endingcredit, " +
                         "         (f.balasof + f.debit - f.credit) as endingbal from       "+
                         "             (Select             " +
                         "               ifnull(da.debit, 0) as Debit,       " +
                         "               ifnull(da.credit, 0) as Credit,       " +
                         "               c.*       " +
                         "             from chart c          " +
                         "             left join (       " +
                         "                        Select sum(ifnull(ff.debit, 0)) debit, sum(ifnull(ff.credit, 0)) credit, ff.accountcode from(       " +
                         "                                   (Select sum(ifnull(cvj.debit, 0)) as debit, sum(ifnull(cvj.credit, 0)) as credit, cvj.accountcode from cvjournal cvj left join checkvoucher cv on cv.cvnumber = cvj.cvnumber  where cv.cvdate between @datefrom and @dateto group by cvj.accountcode) union       " +
                         "                                   (Select sum(ifnull(ad.debit, 0)) as debit, sum(ifnull(ad.credit, 0)) as credit, ad.accountcode from apvdetails ad left join apvoucher a on a.apvnumber = ad.apvnumber where a.apvdate between @datefrom and @dateto  group by ad.accountcode) union       " +
                         "                                   (Select sum(ifnull(jd.debit, 0)) as debit, sum(ifnull(jd.credit, 0)) as credit, jd.accountcode from jvdetails jd  left join journalv j on j.jvnumber = jd.jvnumber where DATE_FORMAT(j.jvdate, '%Y-%m-%d') between @datefrom and @dateto  group by jd.accountcode) union       " +
                         "                                   (Select sum(ifnull(mt.debit, 0)) as debit, sum(ifnull(mt.credit, 0)) as credit, mt.accountcode from mctdetails mt left join materialct m on m.mctno = mt.mctno where DATE_FORMAT(m.mctdate, '%Y-%m-%d') between @datefrom and @dateto  group by mt.accountcode)       " +
                         "                        ) ff group by ff.accountcode            " +
                         "             ) da on da.accountcode = c.accountcode       " +
                         "             where c.accountcode like @code OR c.accountname like @code       " +
                         "    ) f       " +
                         "    where(ifnull(f.BalAsOf, 0) <> 0 OR ifnull(f.debit, 0) > 0 OR ifnull(f.credit, 0) > 0)       " +
                         "    order by f.accountcode       ";

            ds = new DataSet();
                       
            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry,conn_tmp);
                da.SelectCommand.Parameters.AddWithValue("@code","%"+ CodeName_tf.Text + "%");
                //da.SelectCommand.Parameters.AddWithValue("@atype", "%"+typeCB+"%");
                da.SelectCommand.Parameters.AddWithValue("@datefrom", date_from.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto", date_to.Value);

                da.Fill(ds, "chart");
                //chartaGridView.AutoGenerateColumns = false;
                //chartaGridView.DataSource = ds.Tables["chart"];                
                gridControl1.DataSource = ds.Tables["chart"];

                da.Dispose();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }           
        }

        private void editAccntCode_btn_Click(object sender, EventArgs e)
        {
            addChartAccountFrm frm = new addChartAccountFrm();
            frm.frmtitle_lb.Text = "Update chart of account";
            frm.chartAcamFrmInitl(this);
            frm.ShowDialog();            
        }

       

        private void ldgrTpe_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadchart();
        }

        private void ledgertoExcel()
        {
            //String glcode = "";
            MySqlDataAdapter daGL = new MySqlDataAdapter();
            MySqlDataAdapter daSL = new MySqlDataAdapter();
            DataTable ledgerGL = new DataTable();
            DataTable ledgerSL = new DataTable();
            DataTable ledgerChart = new DataTable();           
                                    ledgerChart.Columns.Add("Account Code", typeof(string) );//typeof(int)
                                    ledgerChart.Columns.Add("Account Name", typeof(string));                                        
                                    ledgerChart.Columns.Add("DateAsOf", typeof(DateTime));
                                    ledgerChart.Columns.Add("Beginning Balance", typeof(Decimal));
                                    ledgerChart.Columns.Add("Covoered Debit", typeof(Decimal));
                                    ledgerChart.Columns.Add("Covered Credit", typeof(Decimal));
                                    ledgerChart.Columns.Add("Ending Debit", typeof(Decimal));
                                    ledgerChart.Columns.Add("Ending Credit", typeof(Decimal));


            /*try
            {              

                int rowcnt = chartaGridView.Rows.Count; // tb_dbGrid.Rows.Count;
                Double debit_ = 0.00;
                Double credit_ = 0.00;                

                for (int i = 0; i < rowcnt - 1; i++)
                {

                    if (Double.Parse(chartaGridView.Rows[i].Cells[12].Value.ToString().Replace(",", "")) > 0)
                        debit_ = Double.Parse(chartaGridView.Rows[i].Cells[12].Value.ToString().Replace(",", ""));
                    if (Double.Parse(chartaGridView.Rows[i].Cells[12].Value.ToString().Replace(",", "")) < 0)
                        credit_ = -Double.Parse(chartaGridView.Rows[i].Cells[12].Value.ToString().Replace(",", ""));

                    ledgerChart.Rows.Add(chartaGridView.Rows[i].Cells[0].Value.ToString(),
                                         chartaGridView.Rows[i].Cells[1].Value.ToString(),
                                         chartaGridView.Rows[i].Cells[4].Value.ToString(),
                                         Double.Parse(chartaGridView.Rows[i].Cells[5].Value.ToString().Replace(",", "")),
                                         Double.Parse(chartaGridView.Rows[i].Cells[6].Value.ToString().Replace(",", "")),
                                         Double.Parse(chartaGridView.Rows[i].Cells[7].Value.ToString().Replace(",", "")),
                                         debit_,
                                         credit_);

                    debit_ = 0.00;
                    credit_ = 0.00;
                }
                    //data table to excel file===============================

                Excel.ExcelUtlity obj = new Excel.ExcelUtlity();
                obj.WriteDataTableToExcel(ledgerChart, "Chart of Account", "D:\\AccountingExcel\\ChartOFAccount.xlsx", "Covered: "+ date_from.Value.ToString("M/d/yyyy")+'-'+ date_to.Value.ToString("M/d/yyyy"));

                MessageBox.Show("Excel successfully created to D:\\AccountingExcel\\ChartOFAccount.xlsx...", uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Information);

                ledgerChart.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                daGL.Dispose();
                daSL.Dispose();
                ledgerChart.Dispose();
                conn_tmp.Close();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ledgertoExcel();
            SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
            saveFileDialogExcel.Title = "Export Excel";
            saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialogExcel.FileName;

                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                
                gridView1.ViewCaption = date_from.Value.ToString("MMM d, yyyy", CultureInfo.InvariantCulture) +" - "+ date_to.Value.ToString("MMM d, yyyy", CultureInfo.InvariantCulture);
                gridControl1.ExportToXlsx(exportFilePath);                
                DevExpress.XtraEditors.XtraMessageBox.Show("Save successful!", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void setForward_btn_Click(object sender, EventArgs e)
        {
            forwardedbalanceFrm frm = new forwardedbalanceFrm();
            frm.ShowDialog();
        }

        private void chartBal_btn_Click(object sender, EventArgs e)
        {
            
        }
        private void printTrialbal()
        {
            String typeCB = ldgrTpe_cb.GetItemText(ldgrTpe_cb.SelectedItem).ToString();

            if (ldgrTpe_cb.GetItemText(ldgrTpe_cb.SelectedItem).ToString() == "ALL")
                typeCB = "";

            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            trialbalanceRpt myReport = new trialbalanceRpt();
            DataTable trialbal_table = new DataTable();

            /*String qry = "Set @cnt :=0;" +
                "         Select f.accountcode," +
                "                 f.accountname," +
                "                 if((f.debit-f.credit+f.Balasof)>0,(f.debit - f.credit + f.Balasof),0.00) as debit," +
                "                 if((f.debit-f.credit+f.Balasof)<0,-(f.debit-f.credit+f.Balasof),0.00) as credit," +
                "                 if((f.debit-f.credit+f.Balasof)>0,format((f.debit-f.credit+f.Balasof), 2),'') as debitAmnt, " +
                "                 if((f.debit-f.credit+f.Balasof)<0,format(-(f.debit-f.credit+f.Balasof), 2),'') as creditAmnt," +
                "                 f.dateStmnt," +
                "                 format(@cnt := @cnt+1,0) as cnt " +
                        "  from    " +
                        "    (Select   " +
                        "      c.accountcode," +
                        "      c.accountname," +
                        "      (ifnull((Select sum(ifnull(cvj.debit, 0)) from cvjournal cvj left join checkvoucher cv on cv.cvnumber = cvj.cvnumber  where cv.cvnumber = cvj.cvnumber and cvj.accountcode = c.accountcode and cv.cvdate between @datefrom and @dateto), 0) +   " +
                        "      ifnull((Select sum(ifnull(ad.debit, 0)) from apvdetails ad left join apvoucher a on a.apvnumber = ad.apvnumber where a.apvnumber = ad.apvnumber and ad.accountcode = c.accountcode and a.apvdate between @datefrom and @dateto), 0) +   " +
                        "      ifnull((Select sum(ifnull(jd.debit, 0)) from jvdetails jd  left join journalv j on j.jvnumber = jd.jvnumber where j.jvnumber = jd.jvnumber and jd.accountcode = c.accountcode and DATE_FORMAT(j.jvdate, '%Y-%m-%d') between @datefrom and @dateto),0)   +   " +
                        "      ifnull((Select sum(ifnull(mt.debit, 0)) from mctdetails mt left join materialct m on m.mctno = mt.mctno where m.mctno = mt.mctno and mt.accountcode = c.accountcode and DATE_FORMAT(m.mctdate, '%Y-%m-%d') between @datefrom and @dateto),0) ) as Debit,         " +
                        "      (ifnull((Select sum(ifnull(cvj.credit, 0)) from cvjournal cvj left join checkvoucher cv on cv.cvnumber = cvj.cvnumber  where cv.cvnumber = cvj.cvnumber and cvj.accountcode = c.accountcode and cv.cvdate between @datefrom and @dateto), 0) +   " +
                        "      ifnull((Select sum(ifnull(ad.credit, 0)) from apvdetails ad left join apvoucher a on a.apvnumber = ad.apvnumber where a.apvnumber = ad.apvnumber and ad.accountcode = c.accountcode and a.apvdate between @datefrom and @dateto),0)   +   " +
                        "      ifnull((Select sum(ifnull(jd.credit, 0)) from jvdetails jd  left join journalv j on j.jvnumber = jd.jvnumber where j.jvnumber = jd.jvnumber and jd.accountcode = c.accountcode and DATE_FORMAT(j.jvdate, '%Y-%m-%d') between @datefrom and @dateto),0)   +   " +
                        "      ifnull((Select sum(ifnull(mt.credit, 0)) from mctdetails mt left join materialct m on m.mctno = mt.mctno where m.mctno = mt.mctno and mt.accountcode = c.accountcode and DATE_FORMAT(m.mctdate, '%Y-%m-%d') between @datefrom and @dateto),0) ) as Credit,	     " +                        
                        "      c.Balasof," +
                        "        concat('For the Period From ', " +
                        "                 DATE_FORMAT(@datefrom,'%e %b %Y'),' to '," +
                        "                 DATE_FORMAT(@dateto,'%e %b %Y') ) dateStmnt," +
                        "     c.accounttype " +
                        "    from chart c   " +
                        "    where (c.accountcode like @code OR c.accountname like @acode)   " +
                        "    group by c.accountcode ) f   " +
                        " where f.accounttype like @atype and (ifnull(f.BalAsOf, 0) <> 0 OR ifnull(f.debit,0) <> 0 OR ifnull(f.credit,0) <> 0 )  " +
                        " order by f.accountcode   ";*/

            String qry = " Set @cnt :=0; " +
                         " Select " +
                         "        f.accountcode," +
                         "        f.accountname," +
                         "        if((f.Debit-f.Credit+f.Balasof)>0,(f.Debit - f.Credit + f.Balasof),0.00) as debit," +
                         "        if((f.Debit-f.Credit+f.Balasof)<0,-(f.Debit-f.Credit+f.Balasof),0.00) as credit, " +
                         "        if((f.Debit-f.Credit+f.Balasof)>0,(f.Debit - f.Credit + f.Balasof),'') as debitAmnt, " +
                         "        if((f.Debit-f.Credit+f.Balasof)<0,-(f.Debit-f.Credit+f.Balasof),'') as creditAmnt, " +
                         "        concat('For the Period From ', " +
                         "                 DATE_FORMAT(@datefrom,'%e %b %Y'),' to '," +
                         "                 DATE_FORMAT(@dateto,'%e %b %Y') ) dateStmnt," +
                         "        format(@cnt := @cnt+1,0) as cnt " +
                         " from       " +
                         "             (Select             " +
                         "               ifnull(da.debit, 0) as Debit,       " +
                         "               ifnull(da.credit, 0) as Credit,       " +
                         "               c.*       " +
                         "             from chart c          " +
                         "             left join (       " +
                         "                        Select sum(ifnull(ff.debit, 0)) debit, sum(ifnull(ff.credit, 0)) credit, ff.accountcode from(       " +
                         "                                   (Select sum(ifnull(cvj.debit, 0)) as debit, sum(ifnull(cvj.credit, 0)) as credit, cvj.accountcode from cvjournal cvj left join checkvoucher cv on cv.cvnumber = cvj.cvnumber  where cv.cvdate between @datefrom and @dateto group by cvj.accountcode) union       " +
                         "                                   (Select sum(ifnull(ad.debit, 0)) as debit, sum(ifnull(ad.credit, 0)) as credit, ad.accountcode from apvdetails ad left join apvoucher a on a.apvnumber = ad.apvnumber where a.apvdate between @datefrom and @dateto  group by ad.accountcode) union       " +
                         "                                   (Select sum(ifnull(jd.debit, 0)) as debit, sum(ifnull(jd.credit, 0)) as credit, jd.accountcode from jvdetails jd  left join journalv j on j.jvnumber = jd.jvnumber where DATE_FORMAT(j.jvdate, '%Y-%m-%d') between @datefrom and @dateto  group by jd.accountcode) union       " +
                         "                                   (Select sum(ifnull(mt.debit, 0)) as debit, sum(ifnull(mt.credit, 0)) as credit, mt.accountcode from mctdetails mt left join materialct m on m.mctno = mt.mctno where DATE_FORMAT(m.mctdate, '%Y-%m-%d') between @datefrom and @dateto  group by mt.accountcode)       " +
                         "                        ) ff group by ff.accountcode            " +
                         "             ) da on da.accountcode = c.accountcode       " +
                         "             where c.accountcode like @code OR c.accountname like @code       " +
                         "    ) f       " +
                         "    where(ifnull(f.BalAsOf, 0) <> 0 OR ifnull(f.debit, 0) > 0 OR ifnull(f.credit, 0) > 0)       " +
                         "    order by f.accountcode       ";

            try
            {
                da = new MySqlDataAdapter(qry, conn_tmp);
                //da.SelectCommand.Parameters.AddWithValue("@dateF", daterange_dp.Value.ToString("yyyy-MM-dd"));
                // da.SelectCommand.Parameters.AddWithValue("@dateStmnt",daterange_dp.Value.ToString("d MMM yyyy"));

                da.SelectCommand.Parameters.AddWithValue("@code", "%" + CodeName_tf.Text + "%");
                //da.SelectCommand.Parameters.AddWithValue("@atype", "%" + typeCB + "%");
                da.SelectCommand.Parameters.AddWithValue("@datefrom", date_from.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto", date_to.Value);


                conn_tmp.Open();
                da.Fill(trialbal_table);
                da.Dispose();
                ds.Tables.Add(trialbal_table);
                ds.Tables[0].TableName = "trialbal";

                da.Dispose();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                conn_tmp.Close();
            }
            //set report and view===============
            try
            {
                myReport.SetDataSource(ds);
                frm.crystalRptViewer.ReportSource = myReport;
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chartaGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            trialdate_p.Visible = false;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            printTrialbal();
        }

        private void trialBal_btn_Click(object sender, EventArgs e)
        {
            //trialdate_p.Location = new Point(446, 200);
            //trialdate_p.Visible = true;
            printTrialbal();
        }

        private void changeEndingAmntBalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //addChartAccountFrm frm = new addChartAccountFrm();
            //frm.frmtitle_lb.Text = "Update chart of account";
            // frm.chartAcamFrmInitl(this);
            // frm.ShowDialog();
        }

        private void editAccountCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addChartAccountFrm frm = new addChartAccountFrm();
            frm.frmtitle_lb.Text = "Add chart of account";
            frm.ShowDialog();
        }

        private void addAccountCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Remember the vertical scroll position of the DataGridView
                //int saveVScroll = 0;
                //if (chartaGridView.Rows.Count > 0)
                //    saveVScroll = chartaGridView.FirstDisplayedCell.RowIndex;

                //========================================================
                //this.chartacamTableAdapter.Fill(this.chart_dataSource.chart, CodeName_tf.Text, "%" + CodeName_tf.Text + "%");
                loadchart();

                // Go back to the saved vertical scroll position if available
                //if (saveVScroll != 0 && saveVScroll < chartaGridView.Rows.Count)
                //    chartaGridView.FirstDisplayedScrollingRowIndex = saveVScroll;

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void menuAccount_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void changeEndingAmntBalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //int selectedrowindex = chartaGridView.SelectedCells[0].RowIndex;
            //DataGridViewRow sRow = chartaGridView.Rows[selectedrowindex];

            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

            

            txtacode.Text = gridControl.GetRowCellValue(RowCount, "accountcode").ToString(); // sRow.Cells[0].Value.ToString();
            txtaname.Text = gridControl.GetRowCellValue(RowCount, "accountname").ToString(); //sRow.Cells[1].Value.ToString();
            dateasof_dp.Value = DateTime.Parse(gridControl.GetRowCellValue(RowCount, "dateAsOf").ToString());
            txtEndingbal.Text = Double.Parse(gridControl.GetRowCellValue(RowCount, "endingbal").ToString()).ToString("");

            panel5.Location = new Point(426, 100);
            panel5.Visible = true;
        }

        private void txtEndingbal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtEndingbal_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtEndingbal_Leave(object sender, EventArgs e)
        {
            txtEndingbal.Text = Double.Parse(txtEndingbal.Text.Replace(",", "")).ToString("N02", uc.ci);
        }

        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accountLedgerFrm frm = new accountLedgerFrm();

            try
            {
                globalcutoff.isforward = false;
                //int selectedrowindex = chartaGridView.SelectedCells[0].RowIndex;
                //DataGridViewRow sRow = chartaGridView.Rows[selectedrowindex];

                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                

                frm.accountcode_tf.Text = gridControl.GetRowCellValue(RowCount, "accountcode").ToString(); // sRow.Cells[0].Value.ToString();
                frm.accountname_tf.Text = gridControl.GetRowCellValue(RowCount, "accountname").ToString();//sRow.Cells[1].Value.ToString();
                frm.dateasof_dp.Value = DateTime.Parse(gridControl.GetRowCellValue(RowCount, "dateAsOf").ToString()); //DateTime.Parse(sRow.Cells[4].Value.ToString());
                frm.balance_tf.Text = Double.Parse(gridControl.GetRowCellValue(RowCount, "BalAsOf").ToString()).ToString("N02", uc.ci);//Double.Parse(sRow.Cells[5].Value.ToString().Replace(",", "")).ToString("N02", uc.ci);
                frm.atype_tf.Text = gridControl.GetRowCellValue(RowCount, "accounttype").ToString();//sRow.Cells[3].Value.ToString();
                frm.category_tf.Text = gridControl.GetRowCellValue(RowCount, "category").ToString();//sRow.Cells[2].Value.ToString();
            }
            catch
            { }

            frm.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Remember the vertical scroll position of the DataGridView
                //int saveVScroll = 0;
                //if (chartaGridView.Rows.Count > 0)
                //    saveVScroll = chartaGridView.FirstDisplayedCell.RowIndex;

                //========================================================
                //this.chartacamTableAdapter.Fill(this.chart_dataSource.chart, CodeName_tf.Text, "%" + CodeName_tf.Text + "%");
                loadchart();

                // Go back to the saved vertical scroll position if available
                //if (saveVScroll != 0 && saveVScroll < chartaGridView.Rows.Count)
                //    chartaGridView.FirstDisplayedScrollingRowIndex = saveVScroll;

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void invalidtrans_btn_Click(object sender, EventArgs e)
        {
            invalidtransFrm frm = new invalidtransFrm();
            frm.ShowDialog();
        }
    }
}

/*
 (Select f.* from (
Select 'CV' as type,cvj.cvnumber as docno,cv.cvdate as date, sum(ifnull(cvj.debit,0)) as debit,sum(ifnull(cvj.credit,0)) as credit 
from cvjournal cvj left join checkvoucher cv on cv.cvnumber = cvj.cvnumber  group by cvj.cvnumber) 
f where f.debit <> f.credit)
union
(Select f.* from (
Select 'APV' as type,a.apvnumber as docno,a.apvdate as date,sum(ifnull(ad.debit,0)) as debit, sum(ifnull(ad.credit,0)) as credit 
 from apvdetails ad left join apvoucher a on a.apvnumber  = ad.apvnumber group by ad.apvnumber) f where f.debit <> f.credit)
 union
(Select f.* from ( 
Select 'MCT' as type,m.mctno as docno, m.mctdate as date,sum(ifnull(mt.debit,0)) as debit,sum(ifnull(mt.credit,0)) as credit 
from mctdetails mt left join materialct m on m.mctno = mt.mctno group by mt.mctno) f where f.debit <> f.credit)
union
(Select f.* from ( 
Select 'JV' as type,j.jvnumber as docno, j.jvdate as date,sum(ifnull(jd.debit,0)) debit,sum(ifnull(jd.credit,0)) credit 
from jvdetails jd  left join journalv j on j.jvnumber = jd.jvnumber group by jd.jvnumber) f where f.debit <> f.credit) 
     */
