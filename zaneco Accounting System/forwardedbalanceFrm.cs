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
using zaneco_Accounting_System.Reports;

namespace zaneco_Accounting_System
{
    public partial class forwardedbalanceFrm : Form
    {
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private unitClass uc = new unitClass();
        private DataTable dt = new DataTable();

        public forwardedbalanceFrm()
        {
            InitializeComponent();
        }

        private void close_bnt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadcutoff()
        {
            String qry = "Select * from forwardedchart where DATE_FORMAT(cutoffdate,'%Y-%m-%d') = @cutoff and accountcode like @accountcode";
            ds = new DataSet();

            try
            {
                conn.Open();
                da = new MySqlDataAdapter(qry, conn);
                da.SelectCommand.Parameters.AddWithValue("@cutoff", cutoffdate_cb.GetItemText(cutoffdate_cb.SelectedItem).ToString());
                da.SelectCommand.Parameters.AddWithValue("@accountcode","%" +search_tf.Text+"%");

                da.Fill(ds, "cutoff");
                cutoffgridview.AutoGenerateColumns = false;
                cutoffgridview.DataSource = ds.Tables["cutoff"];

                da.Dispose();
                conn.Close();

            }
            catch
            {
                conn.Close();
            }
        }

        private void cutoffCB()
        {
            String qry = "Select DATE_FORMAT(cutoffdate,'%Y-%m-%d') cutoffdate from forwardedchart  group by cutoffdate order by cutoffdate desc";
            try
            {
                cutoffdate_cb.Items.Clear();

                conn = db.getConn();
                if (db.OpenConnection())
                {
                    cmd = new MySqlCommand(qry, conn);
                    dr = cmd.ExecuteReader();
                                        
                    while (dr.Read())
                    {
                        cutoffdate_cb.Items.Add(dr["cutoffdate"].ToString());                        
                    }
                    dr.Close();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {
            setcutoffFrm frm = new setcutoffFrm();
            frm.ShowDialog();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            postingAccountFrm frm = new postingAccountFrm();
            frm.ShowDialog();
        }

        private void searchCode_btn_Click(object sender, EventArgs e)
        {
            loadcutoff();
        }

        private void forwardedbalanceFrm_Load(object sender, EventArgs e)
        {
            conn = db.getConn();
            cutoffCB();
        }

        private void cutoffdate_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcutoff();
        }

        private void genLedger_btn_Click(object sender, EventArgs e)
        {
            accountLedgerFrm frm = new accountLedgerFrm();
            globalcutoff.idforwardedchart = "";

            try
            {
                int selectedrowindex = cutoffgridview.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = cutoffgridview.Rows[selectedrowindex];

                globalcutoff.cutoffDate = DateTime.Parse(sRow.Cells[0].Value.ToString());
                globalcutoff.dateAsOf = DateTime.Parse(sRow.Cells[4].Value.ToString());
                globalcutoff.idforwardedchart = sRow.Cells[8].Value.ToString();
                globalcutoff.isforward = true;

                frm.accountcode_tf.Text = sRow.Cells[1].Value.ToString();
                frm.accountname_tf.Text = sRow.Cells[2].Value.ToString();
                frm.dateasof_dp.Value = globalcutoff.dateAsOf;
                frm.balance_tf.Text = Double.Parse(sRow.Cells[5].Value.ToString().Replace(",", "")).ToString("N02", uc.ci);                         
                frm.category_tf.Text = sRow.Cells[3].Value.ToString();
            }
            catch
            { }

            frm.ShowDialog();

        }

        private void trialBal_btn_Click(object sender, EventArgs e)
        {
            printtrialbal(false);
        }

        private void printtrialbal(Boolean isfiltered)
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            trialbalanceRpt myReport = new trialbalanceRpt();
            DataTable trialbal_table = new DataTable();

            String qry = " Select fn.* from (Select   " +
                        "     c.accountcode,   " +
                        "     c.accountname,   " +
                        "     ifnull(fnl.debit, 0) debit,   " +
                        "     ifnull(fnl.credit, 0) credit,   " +
                        "     fnl.dateStmnt, " +
                        "     ifnull(fnl.debitAmnt, '') debitAmnt,   " +
                        "     ifnull(fnl.creditAmnt, '') creditAmnt   " +
                        "    from  forwardedchart c   " +
                        "   left join  (   " +
                        "     select   " +
                        "         f.accountcode,   " +
                        "         f.accountname,   " +
                        "         sum(f.debit) debitA,   " +
                        "         sum(f.credit) creditA,   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,sum(f.debit) - sum(f.credit),0) debit,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,sum(f.debit) - sum(f.credit),0) credit,	   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,format(sum(f.debit) - sum(f.credit), 2),'') debitAmnt,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,format(-1 * (sum(f.debit) - sum(f.credit)), 2),'') creditAmnt," +
                        "         f.dateStmnt   " +
                        "     from(   " +
                        "         (Select   " +
                        "             'cv' tcode,   " +
                        "             c1.accountcode,   " +
                        "             c1.accountname,   " +
                        "             sum(ifnull(cvj.debit, 0)) as debit,   " +
                        "             sum(ifnull(cvj.credit, 0)) as credit," +
                        "             concat('Period Covered: ',DATE_ADD(c1.dateAsof, INTERVAL 1 DAY),' - ', c1.cutoffdate) as dateStmnt   " +
                        "         from cvjournal cvj   " +
                        "         left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher   " +
                        "         left  join forwardedchart c1 on c1.accountcode = cvj.accountcode and" +
                        "                                         c1.cutoffdate = @cutoff   " +
                        "         where cvj.date between DATE_ADD(c1.dateAsof, INTERVAL 1 DAY) and c1.cutoffdate   " +
                        "         group by cvj.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "               'apv' tcode,   " +
                        "               ad.accountcode,   " +
                        "               c2.accountname,   " +
                        "               sum(ifnull(ad.debit, 0)) as debit,   " +
                        "               sum(ifnull(ad.credit, 0)) as credit,   " +
                        "               concat('Period Covered: ',DATE_ADD(c2.dateAsof, INTERVAL 1 DAY),' - ', c2.cutoffdate) as dateStmnt   " +
                        "         from apvdetails ad   " +
                        "         left join apvoucher a on a.idAPVoucher = ad.idapv   " +
                        "         left join forwardedchart c2 on c2.accountcode =  ad.accountcode and" +
                        "                                        c2.cutoffdate = @cutoff   " +
                        "         where ad.date between DATE_ADD(c2.dateAsof, INTERVAL 1 DAY) and c2.cutoffdate   " +
                        "         group by ad.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "             'jv' tcode,   " +
                        "             jd.accountcode slcode,   " +
                        "             c3.accountname,   " +
                        "             sum(ifnull(jd.debit, 0)) as debit,   " +
                        "             sum(ifnull(jd.credit, 0)) as credit,   " +
                        "             concat('Period Covered: ',DATE_ADD(c3.dateAsof, INTERVAL 1 DAY),' - ', c3.cutoffdate) as dateStmnt   " +
                        "         from jvdetails jd   " +
                        "         left join journalv j on j.idjournal = jd.idjournalv   " +
                        "         left join forwardedchart c3 on c3.accountcode = jd.accountcode and" +
                        "                                        c3.cutoffdate = @cutoff   " +
                        "         where jd.date between DATE_ADD(c3.dateAsof, INTERVAL 1 DAY) and c3.cutoffdate   " +
                        "         group by jd.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "                'mct' tcode,   " +
                        "                mt.accountcode,   " +
                        "                c4.accountname,   " +
                        "                sum(ifnull(mt.debit, 0)) as debit,   " +
                        "                sum(ifnull(mt.credit, 0)) as credit,   " +
                        "                concat('Period Covered: ',DATE_ADD(c4.dateAsof, INTERVAL 1 DAY),' - ', c4.cutoffdate) as dateStmnt   " +
                        "         from mctdetails mt   " +
                        "         left join materialct m on m.idmaterialct = mt.idmct   " +
                        "         left join forwardedchart c4 on c4.accountcode =  mt.accountcode and" +
                        "                                        c4.cutoffdate = @cutoff   " +
                        "         where DATE_FORMAT(mt.date, '%Y-%m-%e') between DATE_ADD(c4.dateAsof, INTERVAL 1 DAY) and c4.cutoffdate   " +
                        "         group by mt.accountcode)   " +
                        "         ) f   " +
                        "         group by f.accountcode   " +
                        "     ) fnl on c.accountcode = fnl.accountcode  " +
                        " where  c.cutoffdate = @cutoff ) fn";
                        

            if (isfiltered)
                qry = qry + " where fn.debit <> 0 or fn.credit <> 0 order by fn.accountcode ";
            else
                qry = qry + " order by fn.accountcode  ";

            try
            {
                da = new MySqlDataAdapter(qry, conn);
                da.SelectCommand.Parameters.AddWithValue("@cutoff", DateTime.Parse(cutoffdate_cb.GetItemText(cutoffdate_cb.SelectedItem).ToString()).ToString("yyyy-MM-dd"));                
                conn.Open();
                da.Fill(trialbal_table);
                da.Dispose();
                ds.Tables.Add(trialbal_table);
                ds.Tables[0].TableName = "trialbal";

                da.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
                conn.Close();
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

        private void fileteredTBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printtrialbal(true);
        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printtrialbal(false);
        }

        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accountLedgerFrm frm = new accountLedgerFrm();
            globalcutoff.idforwardedchart = "";

            try
            {
                int selectedrowindex = cutoffgridview.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = cutoffgridview.Rows[selectedrowindex];

                globalcutoff.cutoffDate = DateTime.Parse(sRow.Cells[0].Value.ToString());
                globalcutoff.dateAsOf = DateTime.Parse(sRow.Cells[4].Value.ToString());
                globalcutoff.idforwardedchart = sRow.Cells[8].Value.ToString();
                globalcutoff.isforward = true;

                frm.accountcode_tf.Text = sRow.Cells[1].Value.ToString();
                frm.accountname_tf.Text = sRow.Cells[2].Value.ToString();
                frm.dateasof_dp.Value = globalcutoff.dateAsOf;
                frm.balance_tf.Text = Double.Parse(sRow.Cells[5].Value.ToString().Replace(",", "")).ToString("N02", uc.ci);
                frm.category_tf.Text = sRow.Cells[3].Value.ToString();
            }
            catch
            { }

            frm.ShowDialog();
        }
    }
}
