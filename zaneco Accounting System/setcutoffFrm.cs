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
using zaneco_Accounting_System.Reports;
using zaneco_Accounting_System.module;

namespace zaneco_Accounting_System
{
    public partial class setcutoffFrm : Form
    {
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private unitClass uc = new unitClass();
        private DataTable dt = new DataTable();

        private Double unposte_dAmnt = 0.00;

        public setcutoffFrm()
        {
            InitializeComponent();
        }

        private void loadaccount()
        {
            /*String qry = "   Set @dt_av = 0.00;      " +
                        "    Set @ct_av = 0.00;      " +
                        "    Set @dt_cv = 0.00;      " +
                        "    Set @ct_cv = 0.00;      " +
                        "    Set @dt_jv = 0.00;      " +
                        "    Set @ct_jv = 0.00;      " +
                        "    set @dt_mct = 0.00;     " +
                        "    set @ct_mct = 0.00;     " +
                        "    set @avUn = 0.00;          " +
                        "    set @jvUn = 0.00;          " +
                        "    set @cvUn = 0.00;          " +
                        "    set @mctUn = 0.00 ;         " +

                        "    SELECT      " +
                        "         concat(@dt_av:= 0.00, @dt_cv:= 0.00, @dt_jv:= 0.00, @ct_av:= 0.00, @ct_cv:= 0.00, @ct_jv:= 0.00,@dt_mct:=0.00,@ct_mct:=0.00, @avUn := 0.00,@jvUn := 0.00,@cvUn := 0.00, @mctUn := 0.00) tmp,      " +
                        "         c.accountcode ,      " +
                        "         c.accountname,       " +
                        "         c.category,         " +
                        "         c.accounttype,      " +
                        "         c.balAsOf,         " +
                        "         c.dateasof,        " +
                        "         (Select Concat(@dt_av:= sum( if(a.posted=1,ifnull(a.debit, 0),0.00) ), @ct_av:= sum(if(a.posted=1,ifnull(a.credit, 0),0.00) ) ," +
                        "                        @avUn:= sum( if(a.posted=1, 0.00,a.debit + a.credit) ) ) amnt from   apvdetails a where if (c.accounttype = 'GL',a.glaccountcode,a.accountcode) = c.accountcode  and      " +
                        "                                                                                                                             a.date > c.dateasof   ) as apv,      " +
                        "         (Select Concat(@dt_cv:= sum( if(cv.posted=1,ifnull(cv.debit, 0), 0.00) ), @ct_cv:= sum( if(cv.posted=1,ifnull(cv.credit, 0),0.00) ) ," +
                        "                        @cvUn:= sum( if(cv.posted=1, 0.00,cv.debit + cv.credit) )  ) amnt from   cvjournal cv where if (c.accounttype = 'GL',cv.glaccountcode,cv.accountcode) = c.accountcode  and      " +
                        "                                                                                                                             cv.date > c.dateasof   ) as checkv,      " +
                        "         (Select Concat(@dt_jv:= sum( if(jv.posted=1,ifnull(jv.debit, 0), 0.00) ), @ct_jv:= sum( if(jv.posted=1,ifnull(jv.credit, 0), 0.00) )," +
                        "                        @jvUn:= sum( if(jv.posted=1, 0.00,jv.debit + jv.credit) )  ) amnt from jvdetails jv where if (c.accounttype = 'GL',jv.glaccountcode,jv.accountcode) = c.accountcode  and      " +
                        "                                                                                                                             jv.date > c.dateasof   ) as journalv,      " +
                        "         (Select Concat(@dt_mct:= sum( if(mt.posted=1, ifnull(mt.debit, 0), 0.00) ), @ct_mct:= sum( if(mt.posted=1, ifnull(mt.credit, 0), 0.00) )," +
                        "                        @mctUn:= sum( if(mt.posted=1, 0.00,mt.debit + mt.credit) )  ) amnt from mctdetails mt where if (c.accounttype = 'GL',mt.glaccountcode,mt.accountcode) = c.accountcode  and   " +
                        "                                                                                                                             mt.date > c.dateasof   ) as mct,   " +
                        "         Format(ifnull(@dt_av, 0) + ifnull(@dt_cv, 0) + ifnull(@dt_jv, 0) + ifnull(@dt_mct,0), 2) as debitF,      " +
                        "         Format(ifnull(@ct_av, 0) + ifnull(@ct_cv, 0) + ifnull(@ct_jv, 0) + ifnull(@ct_mct,0), 2) as creditF,      " +

                        "         Format(c.balAsOf +      " +
                        "                (ifnull(@dt_av, 0) + ifnull(@dt_cv, 0) + ifnull(@dt_jv, 0) + ifnull(@dt_mct,0) ) -      " +
                        "                (ifnull(@ct_av, 0) + ifnull(@ct_cv, 0) + ifnull(@ct_jv, 0) + ifnull(@dt_mct,0) ) -      " +
                        "                (ifnull(@avUn,0) + ifnull(@cvUn,0) + ifnull(@jvUn,0)+ ifnull(@mctUn,0) ), 2) as Balance,      " +
                        "         format((ifnull(@avUn,0) + ifnull(@cvUn,0) + ifnull(@jvUn,0)+ ifnull(@mctUn,0) ),2) unposted      " +
                        "     FROM zanecoaccounting.chart c      ";*/

            String qry = " Select   " +
                        "     c.accountcode,   " +
                        "     c.accountname,  " +
                        "     c.balasof as balance, " +                       
                        "     ifnull(fnl.debit, 0) debit,   " +
                        "     ifnull(fnl.credit, 0) credit,   " +
                        "     ifnull(fnl.udebit, 0) udebit,   " +
                        "     ifnull(fnl.ucredit, 0) ucredit   " +
                        //"     concat('As of ',@dateStmnt) dateStmnt, " +
                        //"     ifnull(fnl.debitAmnt, '') debitAmnt,   " +
                        //"     ifnull(fnl.creditAmnt, '') creditAmnt   " +
                        "    from  chart c   " +
                        "   left join  (   " +
                        "     select   " +
                        "         f.accountcode,   " +
                        "         f.accountname,   " +
                        "         sum(f.debit) debitA,   " +
                        "         sum(f.credit) creditA,   " +                        
                        "         if (sum(f.debit) - sum(f.credit) > 0,sum(f.debit) - sum(f.credit),0) debit,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,-1 *(sum(f.debit) - sum(f.credit)),0) credit,	   " +
                        "         if (sum(f.udebit) - sum(f.ucredit) > 0,sum(f.udebit) - sum(f.ucredit),0) udebit,   " +
                        "         if (sum(f.udebit) - sum(f.ucredit) < 0,-1 *(sum(f.udebit) - sum(f.ucredit)),0) ucredit,	   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,format(sum(f.debit) - sum(f.credit), 2),'') debitAmnt,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,format(-1 * (sum(f.debit) - sum(f.credit)), 2),'') creditAmnt   " +
                        "     from(   " +
                        "         (Select   " +
                        "             'cv' tcode,   " +
                        "             c1.accountcode,   " +
                        "             c1.accountname,   " +
                        "             sum(if(cvj.posted=1,ifnull(cvj.debit,0), 0) ) as debit,   " +
                        "             sum(if(cvj.posted=1,ifnull(cvj.credit,0), 0) ) as credit, " +
                        "             sum(if(cvj.posted=0,ifnull(cvj.debit,0), 0) ) as udebit, " +
                        "             sum(if(cvj.posted=0,ifnull(cvj.credit,0), 0) ) as ucredit   " +
                        "         from cvjournal cvj   " +
                        "         left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher   " +
                        "         left  join chart c1 on c1.accountcode = cvj.accountcode   " +
                        "         where cvj.date between c1.dateAsof and @dateF   " +
                        "         group by cvj.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "               'apv' tcode,   " +
                        "               ad.accountcode,   " +
                        "               c2.accountname,   " +
                        "               sum(if(ad.posted=1,ifnull(ad.debit,0), 0) ) as debit,   " +
                        "               sum(if(ad.posted=1,ifnull(ad.credit,0), 0) ) as credit," +
                        "               sum(if(ad.posted=0,ifnull(ad.debit,0), 0) ) as udebit," +
                        "               sum(if(ad.posted=0,ifnull(ad.credit,0), 0) ) as ucredit   " +
                        "         from apvdetails ad   " +
                        "         left join apvoucher a on a.idAPVoucher = ad.idapv   " +
                        "         left join chart c2 on c2.accountcode = ad.accountcode   " +
                        "         where ad.date between c2.dateAsof and @dateF   " +
                        "         group by ad.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "             'jv' tcode,   " +
                        "             jd.accountcode slcode,   " +
                        "             c3.accountname,   " +
                        "             sum(if(jd.posted=1,ifnull(jd.debit,0), 0) ) as debit,   " +
                        "             sum(if(jd.posted=1,ifnull(jd.credit,0), 0) ) as credit," +
                        "             sum(if(jd.posted=0,ifnull(jd.debit,0), 0) ) as udebit," +
                        "             sum(if(jd.posted=0,ifnull(jd.credit,0), 0) ) as ucredit   " +
                        "         from jvdetails jd   " +
                        "         left join journalv j on j.idjournal = jd.idjournalv   " +
                        "         left join chart c3 on c3.accountcode = jd.accountcode   " +
                        "         where jd.date between c3.dateAsof and @dateF   " +
                        "         group by jd.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "                'mct' tcode,   " +
                        "                mt.accountcode,   " +
                        "                c4.accountname,   " +
                        "                sum(if(mt.posted=1,ifnull(mt.debit,0), 0) ) as debit,   " +
                        "                sum(if(mt.posted=1,ifnull(mt.credit,0), 0) ) as credit," +
                        "                sum(if(mt.posted=0,ifnull(mt.debit,0), 0) ) as udebit, " +
                        "                sum(if(mt.posted=0,ifnull(mt.credit,0), 0) ) as ucredit  " +
                        "         from mctdetails mt   " +
                        "         left join materialct m on m.idmaterialct = mt.idmct   " +
                        "         left join chart c4 on c4.accountcode = mt.accountcode   " +
                        "         where DATE_FORMAT(mt.date, '%Y-%m-%e') between c4.dateAsof and @dateF   " +
                        "         group by mt.accountcode)   " +
                        "         ) f   " +
                        "         group by f.accountcode   " +
                        "     ) fnl on c.accountcode = fnl.accountcode   " +                         
                        " order by c.accountcode   ";
            String qryUnposted = " Select   " +
                        "     c.accountcode,   " +
                        "     c.accountname,  " +
                        "     c.balasof as balance, " +
                        "     ifnull(fnl.debit, 0) debit,   " +
                        "     ifnull(fnl.credit, 0) credit,   " +
                        "     ifnull(fnl.udebit, 0) udebit,   " +
                        "     ifnull(fnl.ucredit, 0) ucredit   " +
                        //"     concat('As of ',@dateStmnt) dateStmnt, " +
                        //"     ifnull(fnl.debitAmnt, '') debitAmnt,   " +
                        //"     ifnull(fnl.creditAmnt, '') creditAmnt   " +
                        "    from  chart c   " +
                        "   left join  (   " +
                        "     select   " +
                        "         f.accountcode,   " +
                        "         f.accountname,   " +
                        "         sum(f.debit) debitA,   " +
                        "         sum(f.credit) creditA,   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,sum(f.debit) - sum(f.credit),0) debit,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,-1 *(sum(f.debit) - sum(f.credit)),0) credit,	   " +
                        "         if (sum(f.udebit) - sum(f.ucredit) > 0,sum(f.udebit) - sum(f.ucredit),0) udebit,   " +
                        "         if (sum(f.udebit) - sum(f.ucredit) < 0,-1 *(sum(f.udebit) - sum(f.ucredit)),0) ucredit,	   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,format(sum(f.debit) - sum(f.credit), 2),'') debitAmnt,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,format(-1 * (sum(f.debit) - sum(f.credit)), 2),'') creditAmnt   " +
                        "     from(   " +
                        "         (Select   " +
                        "             'cv' tcode,   " +
                        "             c1.accountcode,   " +
                        "             c1.accountname,   " +
                        "             sum(if(cvj.posted=1,ifnull(cvj.debit,0), 0) ) as debit,   " +
                        "             sum(if(cvj.posted=1,ifnull(cvj.credit,0), 0) ) as credit, " +
                        "             sum(if(cvj.posted=0,ifnull(cvj.debit,0), 0) ) as udebit, " +
                        "             sum(if(cvj.posted=0,ifnull(cvj.credit,0), 0) ) as ucredit   " +
                        "         from cvjournal cvj   " +
                        "         left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher   " +
                        "         left  join chart c1 on c1.accountcode = cvj.accountcode   " +
                        "         where cvj.date between c1.dateAsof and @dateF   " +
                        "         group by cvj.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "               'apv' tcode,   " +
                        "               ad.accountcode,   " +
                        "               c2.accountname,   " +
                        "               sum(if(ad.posted=1,ifnull(ad.debit,0), 0) ) as debit,   " +
                        "               sum(if(ad.posted=1,ifnull(ad.credit,0), 0) ) as credit," +
                        "               sum(if(ad.posted=0,ifnull(ad.debit,0), 0) ) as udebit," +
                        "               sum(if(ad.posted=0,ifnull(ad.credit,0), 0) ) as ucredit   " +
                        "         from apvdetails ad   " +
                        "         left join apvoucher a on a.idAPVoucher = ad.idapv   " +
                        "         left join chart c2 on c2.accountcode = ad.accountcode   " +
                        "         where ad.date between c2.dateAsof and @dateF   " +
                        "         group by ad.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "             'jv' tcode,   " +
                        "             jd.accountcode slcode,   " +
                        "             c3.accountname,   " +
                        "             sum(if(jd.posted=1,ifnull(jd.debit,0), 0) ) as debit,   " +
                        "             sum(if(jd.posted=1,ifnull(jd.credit,0), 0) ) as credit," +
                        "             sum(if(jd.posted=0,ifnull(jd.debit,0), 0) ) as udebit," +
                        "             sum(if(jd.posted=0,ifnull(jd.credit,0), 0) ) as ucredit   " +
                        "         from jvdetails jd   " +
                        "         left join journalv j on j.idjournal = jd.idjournalv   " +
                        "         left join chart c3 on c3.accountcode = jd.accountcode   " +
                        "         where jd.date between c3.dateAsof and @dateF   " +
                        "         group by jd.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "                'mct' tcode,   " +
                        "                mt.accountcode,   " +
                        "                c4.accountname,   " +
                        "                sum(if(mt.posted=1,ifnull(mt.debit,0), 0) ) as debit,   " +
                        "                sum(if(mt.posted=1,ifnull(mt.credit,0), 0) ) as credit," +
                        "                sum(if(mt.posted=0,ifnull(mt.debit,0), 0) ) as udebit, " +
                        "                sum(if(mt.posted=0,ifnull(mt.credit,0), 0) ) as ucredit  " +
                        "         from mctdetails mt   " +
                        "         left join materialct m on m.idmaterialct = mt.idmct   " +
                        "         left join chart c4 on c4.accountcode = mt.accountcode   " +
                        "         where DATE_FORMAT(mt.date, '%Y-%m-%e') between c4.dateAsof and @dateF   " +
                        "         group by mt.accountcode)   " +
                        "         ) f   " +
                        "         group by f.accountcode   " +
                        "     ) fnl on c.accountcode = fnl.accountcode  " +
                        " where ifnull(fnl.udebit,0) > 0 or ifnull(fnl.ucredit,0) > 0 " +
                        " order by c.accountcode   ";

            if (unposted_cb.Checked)
                qry = qryUnposted;


            ds = new DataSet();

            try
            {
                
                da = new MySqlDataAdapter(qry, conn);
                da.SelectCommand.Parameters.AddWithValue("@dateF", dateTimePicker1.Value.ToString("yyyy-MM-dd")); 
                conn.Open();

                da.Fill(ds, "chart");
                tb_dbgdview.AutoGenerateColumns = false;
                tb_dbgdview.DataSource = ds.Tables["chart"];

                da.Dispose();
                conn.Close();

                //====================================
                //====Unposted amount=================
                int rowcnt = tb_dbgdview.Rows.Count;                
                for (int i = 0; i < rowcnt - 1; i++)
                {
                    this.unposte_dAmnt = unposte_dAmnt + 
                                         Double.Parse(tb_dbgdview.Rows[i].Cells[5].Value.ToString().Replace(",", "")) +
                                         Double.Parse(tb_dbgdview.Rows[i].Cells[6].Value.ToString().Replace(",", ""));
                }
                //=====================================
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {
            if (unposte_dAmnt > 0)
            {
                MessageBox.Show("Unable to continue this process...\nPlease post all unposted account...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //MessageBox.Show("RonCut-off date successfully executed...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //if (checkcutoffExist())
            //    return;
            
            if(lessDateasof())
            {
                MessageBox.Show("Unable to continue this process, selected date should be ahead of the existing posted cutoff date.",uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            

            forwardaccount();            
        }

        private Boolean lessDateasof()
        {
            Boolean islessDate = false;
            DateTime dateasof = DateTime.Now;
            String qry = " Select f.dateasof from (" +
                         "  (Select 1 cnt, dateasof from chart order by dateasof desc limit 1) union " +
                         "  (Select 2 cnt, dateasof from forwardedchart order by dateasof desc limit 1)" +
                         " ) f order by f.dateasof desc limit 1 ";
            cmd = new MySqlCommand(qry, conn);         

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    dateasof = dr.GetDateTime("dateasof");

                dr.Close();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

            if (dateTimePicker1.Value <= dateasof)
                islessDate = true;

            return islessDate;
        }
      
        private Boolean checkcutoffExist()
        {
            Boolean iscutoffexist = false;
            String qry = "Select * from forwardedchart where DATE_FORMAT(cutoffdate,'%Y') = @yyyy limit 1";
            cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@yyyy", dateTimePicker1.Value.ToString("YYYY"));
            
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    iscutoffexist = true;

                dr.Close();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                conn.Close();
            }

            return iscutoffexist;

        }
        private void forwardaccount()
        {
            DateTime cutoffdate = dateTimePicker1.Value;
            String qry = " Insert into forwardedchart(idchart,accountcode,accountname,accounttype,glAccountcode,glAccountname,accountledgertype,BalAsOf,dateAsOf,idcategory,category,cstatus,isCF,isSF,bankcode,cutoffdate,debit,credit,user,date) " +
                         " (Select c.*, @cutoffdate, 0.00, 0.00, @user,now() from chart c) ";

            try
            {
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@cutoffdate", cutoffdate);
                cmd.Parameters.AddWithValue("@user", globalmainFrm.userlog);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                //===========================================
                //===========================================
                int rowcnt = tb_dbgdview.Rows.Count;
                progressBar1.Maximum = rowcnt;
                for (int i = 0; i < rowcnt - 1; i++)
                {
                    progressBar1.Value = i;

                    updatecutoff(tb_dbgdview.Rows[i].Cells[3].Value.ToString().Replace(",",""),
                                 tb_dbgdview.Rows[i].Cells[4].Value.ToString().Replace(",", ""),                                 
                                 tb_dbgdview.Rows[i].Cells[0].Value.ToString(),
                                 cutoffdate);

                    //MessageBox.Show(tb_dbgdview.Rows[i].Cells[4].Value.ToString()+"\n"+ tb_dbgdview.Rows[i].Cells[5].Value.ToString());

                    updatechart(cutoffdate,
                                Double.Parse(tb_dbgdview.Rows[i].Cells[3].Value.ToString().Replace(",", "")) -
                                Double.Parse(tb_dbgdview.Rows[i].Cells[4].Value.ToString().Replace(",", "")),
                                tb_dbgdview.Rows[i].Cells[0].Value.ToString());
                }

                progressBar1.Value = rowcnt;
                
                MessageBox.Show("Cut-off date successfully executed...",uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("RonelCut-off date ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }



        }
        private void updatechart(DateTime dateasof,Double balasof,String accountcode)
        {
            String qry = "update chart set dateasof = @cutoffdate, balasof = @balasof where accountcode = @accountcode";

            try
            {
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@cutoffdate", dateasof);
                cmd.Parameters.AddWithValue("@balasof", balasof);
                cmd.Parameters.AddWithValue("@accountcode", accountcode);
               
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cut-off date ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
        private void updatecutoff(String debit,String credit, String accountcode,DateTime cutoff)
        {
            String qry = "Update forwardedchart set debit = @debit,credit=@credit where accountcode = @accountcode and DATE_FORMAT(cutoffdate,'%Y-%m-%d') =@cutoffdate ";

            try
            {
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@debit", Double.Parse(debit));
                cmd.Parameters.AddWithValue("@credit", Double.Parse(credit));                
                cmd.Parameters.AddWithValue("@accountcode", accountcode);
                cmd.Parameters.AddWithValue("@cutoffdate", cutoff.ToString("yyyy-MM-dd"));               
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cut-off date ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void setcutoffFrm_Load(object sender, EventArgs e)
        {
            conn = db.getConn();
            loadaccount();
        }

        private void unposted_cb_CheckedChanged(object sender, EventArgs e)
        {
            loadaccount();
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            printCutoff();
        }

        private void printCutoff()
        {            
            String qry = //" set " +
                        " Select   " +
                        "     c.accountcode,   " +
                        "     c.accountname,  " +
                        "     c.balasof as balance, " +
                        "     ifnull(fnl.debit, 0) debit,   " +
                        "     ifnull(fnl.credit, 0) credit,   " +
                        "     ifnull(fnl.udebit, 0) udebit,   " +
                        "     ifnull(fnl.ucredit, 0) ucredit," +
                        "     concat('Period Covered: ',DATE_FORMAT(c.dateasof, '%M %e, %Y'),' to ',@dateto) as datecovered " +                                        
                        "    from  chart c   " +
                        "   left join  (   " +
                        "     select   " +
                        "         f.accountcode,   " +
                        "         f.accountname,   " +
                        "         sum(f.debit) debitA,   " +
                        "         sum(f.credit) creditA,   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,sum(f.debit) - sum(f.credit),0) debit,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,-1 *(sum(f.debit) - sum(f.credit)),0) credit,	   " +
                        "         if (sum(f.udebit) - sum(f.ucredit) > 0,sum(f.udebit) - sum(f.ucredit),0) udebit,   " +
                        "         if (sum(f.udebit) - sum(f.ucredit) < 0,-1 *(sum(f.udebit) - sum(f.ucredit)),0) ucredit,	   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,format(sum(f.debit) - sum(f.credit), 2),'') debitAmnt,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,format(-1 * (sum(f.debit) - sum(f.credit)), 2),'') creditAmnt   " +
                        "     from(   " +
                        "         (Select   " +
                        "             'cv' tcode,   " +
                        "             c1.accountcode,   " +
                        "             c1.accountname,   " +
                        "             sum(if(cvj.posted=1,ifnull(cvj.debit,0), 0) ) as debit,   " +
                        "             sum(if(cvj.posted=1,ifnull(cvj.credit,0), 0) ) as credit, " +
                        "             sum(if(cvj.posted=0,ifnull(cvj.debit,0), 0) ) as udebit, " +
                        "             sum(if(cvj.posted=0,ifnull(cvj.credit,0), 0) ) as ucredit   " +
                        "         from cvjournal cvj   " +
                        "         left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher   " +
                        "         left  join chart c1 on c1.accountcode = cvj.accountcode   " +
                        "         where cvj.date between c1.dateAsof and @dateF   " +
                        "         group by cvj.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "               'apv' tcode,   " +
                        "               ad.accountcode,   " +
                        "               c2.accountname,   " +
                        "               sum(if(ad.posted=1,ifnull(ad.debit,0), 0) ) as debit,   " +
                        "               sum(if(ad.posted=1,ifnull(ad.credit,0), 0) ) as credit," +
                        "               sum(if(ad.posted=0,ifnull(ad.debit,0), 0) ) as udebit," +
                        "               sum(if(ad.posted=0,ifnull(ad.credit,0), 0) ) as ucredit   " +
                        "         from apvdetails ad   " +
                        "         left join apvoucher a on a.idAPVoucher = ad.idapv   " +
                        "         left join chart c2 on c2.accountcode = ad.accountcode   " +
                        "         where ad.date between c2.dateAsof and @dateF   " +
                        "         group by ad.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "             'jv' tcode,   " +
                        "             jd.accountcode slcode,   " +
                        "             c3.accountname,   " +
                        "             sum(if(jd.posted=1,ifnull(jd.debit,0), 0) ) as debit,   " +
                        "             sum(if(jd.posted=1,ifnull(jd.credit,0), 0) ) as credit," +
                        "             sum(if(jd.posted=0,ifnull(jd.debit,0), 0) ) as udebit," +
                        "             sum(if(jd.posted=0,ifnull(jd.credit,0), 0) ) as ucredit   " +
                        "         from jvdetails jd   " +
                        "         left join journalv j on j.idjournal = jd.idjournalv   " +
                        "         left join chart c3 on c3.accountcode = jd.accountcode   " +
                        "         where jd.date between c3.dateAsof and @dateF   " +
                        "         group by jd.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "                'mct' tcode,   " +
                        "                mt.accountcode,   " +
                        "                c4.accountname,   " +
                        "                sum(if(mt.posted=1,ifnull(mt.debit,0), 0) ) as debit,   " +
                        "                sum(if(mt.posted=1,ifnull(mt.credit,0), 0) ) as credit," +
                        "                sum(if(mt.posted=0,ifnull(mt.debit,0), 0) ) as udebit, " +
                        "                sum(if(mt.posted=0,ifnull(mt.credit,0), 0) ) as ucredit  " +
                        "         from mctdetails mt   " +
                        "         left join materialct m on m.idmaterialct = mt.idmct   " +
                        "         left join chart c4 on c4.accountcode = mt.accountcode   " +
                        "         where DATE_FORMAT(mt.date, '%Y-%m-%e') between c4.dateAsof and @dateF   " +
                        "         group by mt.accountcode)   " +
                        "         ) f   " +
                        "         group by f.accountcode   " +
                        "     ) fnl on c.accountcode = fnl.accountcode   " +
                        " order by c.accountcode   ";
            String qryUnposted = " Select   " +
                        "     c.accountcode,   " +
                        "     c.accountname,  " +
                        "     c.balasof as balance, " +
                        "     ifnull(fnl.debit, 0) debit,   " +
                        "     ifnull(fnl.credit, 0) credit,   " +
                        "     ifnull(fnl.udebit, 0) udebit,   " +
                        "     ifnull(fnl.ucredit, 0) ucredit,   " +
                        "     concat('Period Covered: ',DATE_FORMAT(c.dateasof, '%M %e, %Y'),' to ',@dateto) as datecovered " +
                        "    from  chart c   " +
                        "   left join  (   " +
                        "     select   " +
                        "         f.accountcode,   " +
                        "         f.accountname,   " +
                        "         sum(f.debit) debitA,   " +
                        "         sum(f.credit) creditA,   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,sum(f.debit) - sum(f.credit),0) debit,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,-1 *(sum(f.debit) - sum(f.credit)),0) credit,	   " +
                        "         if (sum(f.udebit) - sum(f.ucredit) > 0,sum(f.udebit) - sum(f.ucredit),0) udebit,   " +
                        "         if (sum(f.udebit) - sum(f.ucredit) < 0,-1 *(sum(f.udebit) - sum(f.ucredit)),0) ucredit,	   " +
                        "         if (sum(f.debit) - sum(f.credit) > 0,format(sum(f.debit) - sum(f.credit), 2),'') debitAmnt,   " +
                        "         if (sum(f.debit) - sum(f.credit) < 0,format(-1 * (sum(f.debit) - sum(f.credit)), 2),'') creditAmnt   " +
                        "     from(   " +
                        "         (Select   " +
                        "             'cv' tcode,   " +
                        "             c1.accountcode,   " +
                        "             c1.accountname,   " +
                        "             sum(if(cvj.posted=1,ifnull(cvj.debit,0), 0) ) as debit,   " +
                        "             sum(if(cvj.posted=1,ifnull(cvj.credit,0), 0) ) as credit, " +
                        "             sum(if(cvj.posted=0,ifnull(cvj.debit,0), 0) ) as udebit, " +
                        "             sum(if(cvj.posted=0,ifnull(cvj.credit,0), 0) ) as ucredit   " +
                        "         from cvjournal cvj   " +
                        "         left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher   " +
                        "         left  join chart c1 on c1.accountcode = cvj.accountcode   " +
                        "         where cvj.date between c1.dateAsof and @dateF   " +
                        "         group by cvj.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "               'apv' tcode,   " +
                        "               ad.accountcode,   " +
                        "               c2.accountname,   " +
                        "               sum(if(ad.posted=1,ifnull(ad.debit,0), 0) ) as debit,   " +
                        "               sum(if(ad.posted=1,ifnull(ad.credit,0), 0) ) as credit," +
                        "               sum(if(ad.posted=0,ifnull(ad.debit,0), 0) ) as udebit," +
                        "               sum(if(ad.posted=0,ifnull(ad.credit,0), 0) ) as ucredit   " +
                        "         from apvdetails ad   " +
                        "         left join apvoucher a on a.idAPVoucher = ad.idapv   " +
                        "         left join chart c2 on c2.accountcode = ad.accountcode   " +
                        "         where ad.date between c2.dateAsof and @dateF   " +
                        "         group by ad.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "             'jv' tcode,   " +
                        "             jd.accountcode slcode,   " +
                        "             c3.accountname,   " +
                        "             sum(if(jd.posted=1,ifnull(jd.debit,0), 0) ) as debit,   " +
                        "             sum(if(jd.posted=1,ifnull(jd.credit,0), 0) ) as credit," +
                        "             sum(if(jd.posted=0,ifnull(jd.debit,0), 0) ) as udebit," +
                        "             sum(if(jd.posted=0,ifnull(jd.credit,0), 0) ) as ucredit   " +
                        "         from jvdetails jd   " +
                        "         left join journalv j on j.idjournal = jd.idjournalv   " +
                        "         left join chart c3 on c3.accountcode = jd.accountcode   " +
                        "         where jd.date between c3.dateAsof and @dateF   " +
                        "         group by jd.accountcode)   " +
                        "         union   " +
                        "         (Select   " +
                        "                'mct' tcode,   " +
                        "                mt.accountcode,   " +
                        "                c4.accountname,   " +
                        "                sum(if(mt.posted=1,ifnull(mt.debit,0), 0) ) as debit,   " +
                        "                sum(if(mt.posted=1,ifnull(mt.credit,0), 0) ) as credit," +
                        "                sum(if(mt.posted=0,ifnull(mt.debit,0), 0) ) as udebit, " +
                        "                sum(if(mt.posted=0,ifnull(mt.credit,0), 0) ) as ucredit  " +
                        "         from mctdetails mt   " +
                        "         left join materialct m on m.idmaterialct = mt.idmct   " +
                        "         left join chart c4 on c4.accountcode = mt.accountcode   " +
                        "         where DATE_FORMAT(mt.date, '%Y-%m-%e') between c4.dateAsof and @dateF   " +
                        "         group by mt.accountcode)   " +
                        "         ) f   " +
                        "         group by f.accountcode   " +
                        "     ) fnl on c.accountcode = fnl.accountcode  " +
                        " where ifnull(fnl.udebit,0) > 0 or ifnull(fnl.ucredit,0) > 0 " +
                        " order by c.accountcode   ";

            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            CutoffRpt myReport = new CutoffRpt();
            DataTable cutoff_table = new DataTable();

            if (unposted_cb.Checked)
                qry = qryUnposted;

            try
            {

                da = new MySqlDataAdapter(qry, conn);
                da.SelectCommand.Parameters.AddWithValue("@dateF", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                da.SelectCommand.Parameters.AddWithValue("@dateto", dateTimePicker1.Value.ToString("MMMM d, yyyy"));               
                conn.Open();

                da.Fill(cutoff_table);
                da.Dispose();
                ds.Tables.Add(cutoff_table);
                ds.Tables[0].TableName = "chart";

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadaccount();
        }

        private void viewPostedTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printUnposted(true);
        }

        private void printUnposted(Boolean isposted_)
        {
            String qry = " Select   " +
                        "     f.accountcode,   " +
                        "     f.accountname,  " +
                        "     f.docno ref, " +
                        "     f.description, " +
                        "     f.date, " +
                        "     f.debit," +
                        "     f.credit," +
                        "     f.dateasof as datefrom," +
                        "     @dateto dateto," +
                        "     if(f.posted = 1,'Posted','Unposted') as postedtype," +
                        "     f.balasof as beginningbal," +
                        "     concat('Period Covered: ',DATE_FORMAT(f.dateasof, '%e %b %Y'),' to ',DATE_FORMAT(@dateto, '%e %b %Y')) as ascovered " +
                        "    from  " +
                        "    (   " +
                        "         (Select   " +
                        "             'cv' tcode,   " +
                        "             c1.accountcode,   " +
                        "             c1.accountname,   " +
                        "             cvj.debit, " +
                        "             cvj.credit, " +
                        //"             if(cvj.posted=1,ifnull(cvj.debit,0), 0) as debit,   " +
                        //"             if(cvj.posted=1,ifnull(cvj.credit,0), 0)  as credit, " +
                        //"             if(cvj.posted=0,ifnull(cvj.debit,0), 0)  as udebit, " +
                        //"             if(cvj.posted=0,ifnull(cvj.credit,0), 0)  as ucredit," +
                        "             cvj.date," +
                        "             cv.paymentDesc as description," +
                        "             cv.cvnumber as docno," +
                        "             cvj.posted," +
                        "             c1.dateasof," +
                        "             c1.balasof," +
                        "             cvj.idcvJournal idcnt   " +
                        "         from cvjournal cvj   " +
                        "         left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher   " +
                        "         left  join chart c1 on c1.accountcode = cvj.accountcode   " +
                        "         where cvj.accountcode = @accountcode and cvj.date between c1.dateAsof and @dateF   " +
                        "         )   " +
                        "         union   " +
                        "         (Select   " +
                        "               'apv' tcode,   " +
                        "               c2.accountcode,   " +
                        "               c2.accountname,   " +
                        "               ad.debit, " +
                        "               ad.credit, " +
                        "               ad.date date," +
                        "               a.pdescription as description," +
                        "               a.apvnumber as docno," +
                        "               ad.posted,   " +
                        "               c2.dateasof," +
                        "               c2.balasof," +
                        "               ad.idapvdetails idcnt   " +
                        "         from apvdetails ad   " +
                        "         left join apvoucher a on a.idAPVoucher = ad.idapv   " +
                        "         left join chart c2 on c2.accountcode = ad.accountcode   " +
                        "         where ad.accountcode = @accountcode and ad.date between c2.dateAsof and @dateF   " +
                        "         )   " +
                        "         union   " +
                        "         (Select   " +
                        "             'jv' tcode,   " +
                        "              c3.accountcode,   " +
                        "              c3.accountname,   " +
                        "              jd.debit, " +
                        "              jd.credit, " +
                        "              jd.date," +
                        "              j.description ," +
                        "              j.jvnumber as docno," +
                        "              jd.posted,   " +
                        "              c3.dateasof," +
                        "              c3.balasof," +
                        "              jd.idjvdetails idcnt   " +
                        "         from jvdetails jd   " +
                        "         left join journalv j on j.idjournal = jd.idjournalv   " +
                        "         left join chart c3 on c3.accountcode = jd.accountcode   " +
                        "         where jd.accountcode = @accountcode and jd.date between c3.dateAsof and @dateF   " +
                        "         )   " +
                        "         union   " +
                        "         (Select   " +
                        "                'mct' tcode,   " +
                        "                c4.accountcode,   " +
                        "                c4.accountname,   " +
                        "                mt.debit, " +
                        "                mt.credit, " +
                        "                mt.date," +
                        "                m.description ," +
                        "                m.mctno as docno," +
                        "                mt.posted,   " +
                        "                c4.dateasof," +
                        "                c4.balasof," +
                        "                mt.idmctdetails idcnt   " +
                        "         from mctdetails mt   " +
                        "         left join materialct m on m.idmaterialct = mt.idmct   " +
                        "         left join chart c4 on c4.accountcode = mt.accountcode   " +
                        "         where mt.accountcode = @accountcode and DATE_FORMAT(mt.date, '%Y-%m-%e') between c4.dateAsof and @dateF " +
                        "         )   " +
                        "     ) f   " +
                        " where f.posted = @isposted " +
                        " order by f.date,f.docno   ";

            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            postedaccountRpt myReport = new postedaccountRpt();
            DataTable posted_table = new DataTable();

            int isposted = 0;
            String accountcode = "";
                        
            if (isposted_)
                isposted = 1;

            int selectedrowindex = tb_dbgdview.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = tb_dbgdview.Rows[selectedrowindex];

            try
            {
                accountcode = sRow.Cells[0].Value.ToString();
            }
            catch
            { }

            try
            {

                da = new MySqlDataAdapter(qry, conn);
                da.SelectCommand.Parameters.AddWithValue("@dateF", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                da.SelectCommand.Parameters.AddWithValue("@dateto", dateTimePicker1.Value);
                da.SelectCommand.Parameters.AddWithValue("@isposted", isposted);
                da.SelectCommand.Parameters.AddWithValue("@accountcode", accountcode);

                conn.Open();

                da.Fill(posted_table);
                da.Dispose();
                ds.Tables.Add(posted_table);
                ds.Tables[0].TableName = "postedAccount";

                da.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void viewUnpostedTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printUnposted(false);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
