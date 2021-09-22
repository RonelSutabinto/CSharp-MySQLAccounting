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
    public partial class postingAccountFrm : Form
    {
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private unitClass uc = new unitClass();
        private DataTable dt = new DataTable();
       // private String mmyy_ = "";
        private Double AmntPosted = 0.00;
        

        public postingAccountFrm()
        {
            InitializeComponent();            
        }
        private Double getPostedAmnt(String mmyy)
        {
            Double amnt = 0.00;
            String qry = "   Select     " +
                        "        f.*     " +
                        "    from  ( SELECT     " +
                        "            c.accountcode,     " +
                        "            c.accountname,     " +
                        "            c.category,     " +
                        "            c.accounttype,     " +
                        "            c.balAsOf,     " +
                        "            c.dateasof,     " +
                        "            @mmyy pmonth,     " +
                        "            (sum(ifnull(a.debit, 0)) + sum(ifnull(cv.debit, 0)) + sum(ifnull(jv.debit, 0)) + sum(ifnull(mt.debit, 0))) debit,     " +
                        "            (sum(ifnull(a.credit, 0)) + sum(ifnull(cv.credit, 0)) + sum(ifnull(jv.credit, 0)) + sum(ifnull(mt.credit, 0))) credit     " +
                        "        FROM zanecoaccounting.chart c     " +
                        "        left join apvdetails a on if (c.accounttype = 'GL',a.glaccountcode,a.accountcode) = c.accountcode and     " +
                        "                                    DATE_FORMAT(a.date, '%m%y') = @mmyy and a.posted = 1     " +
                        "        left join cvjournal cv on if (c.accounttype = 'GL',cv.glaccountcode,cv.accountcode) = c.accountcode and     " +
                        "                                  DATE_FORMAT(cv.date, '%m%y') = @mmyy and cv.posted = 1     " +
                        "        left join jvdetails jv on if (c.accounttype = 'GL',jv.glaccountcode,jv.accountcode) = c.accountcode and     " +
                        "                                  DATE_FORMAT(jv.date, '%m%y') = @mmyy and jv.posted = 1     " +
                        "        left join mctdetails mt on if (c.accounttype = 'GL',mt.glaccountcode,mt.accountcode) = c.accountcode and     " +
                        "                                  DATE_FORMAT(mt.date, '%m%y') = @mmyy and mt.posted = 1     " +
                        "        group by c.accountcode     " +
                        "        ) f where f.debit > 0 or f.credit > 0 limit 1     ";

            cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@mmyy", mmyy);

            //OPEN CON
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    amnt = dr.GetDouble("debit") + dr.GetDouble("credit");
                }

                dr.Close();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                dr.Close();
                conn.Close();
            }
            return amnt;
        }

        public void loadaccount(String mmyy)
        {
            mmyy_tf.Text = mmyy;
            /*String qry = "   Set @dt_av = 0.00;      " +
                        "    Set @ct_av = 0.00;      " +
                        "    Set @dt_cv = 0.00;      " +
                        "    Set @ct_cv = 0.00;      " +
                        "    Set @dt_jv = 0.00;      " +
                        "    Set @ct_jv = 0.00;      " +
                        "    set @dt_mct = 0.00;     " +
                        "    set @ct_mct = 0.00; " +
                        "    set @cnt_ = 0;" +
                        "    set @cntT = 0;" +
                        " Select f.*,@cntT as cntT " +
                        "         from ( " +                        
                        "    SELECT      " +
                        "         concat(@cnt_ := 0,@dt_av:= 0.00, @dt_cv:= 0.00, @dt_jv:= 0.00, @ct_av:= 0.00, @ct_cv:= 0.00, @ct_jv:= 0.00,@dt_mct:=0.00,@ct_mct:=0.00) tmp,      " +
                        "         c.accountcode ,      " +
                        "         c.accountname,       " +
                        "         c.glaccountcode ,      " +
                        "         c.glaccountname,       " +
                        "         c.category,         " +
                        "         c.accounttype,      " +
                        "         c.balAsOf,         " +
                        "         c.dateasof,        " +
                        "         @mmyy pmonth," +
                        "         c.dateasof as cutoffdate,      "+
                        "         (Select Concat(@dt_av:= sum( ifnull(a.debit, 0) )," +
                        "                        @ct_av:= sum(ifnull(a.credit, 0))," +
                        "                        @cnt_ := @cnt_ + count(*)," +
                        "                        @cntT := @cntT+ count(*) " +
                        "                        ) amnt from   apvdetails a where a.accountcode = c.accountcode  and      " +
                        "                                                         DATE_FORMAT(a.date,'%m%y')  = @mmyy   and a.posted=0 ) as apv,      " +
                        "         (Select Concat(@dt_cv:= sum( ifnull(cv.debit, 0) ), " +
                        "                        @ct_cv:= sum( ifnull(cv.credit, 0) )," +
                        "                        @cnt_ := @cnt_+count(*)," +
                        "                        @cntT := @cntT+ count(*) " +
                        "                        ) amnt from   cvjournal cv where cv.accountcode = c.accountcode  and      " +
                        "                                                         DATE_FORMAT(cv.date,'%m%y')  = @mmyy  and cv.posted=0 ) as checkv,      " +
                        "         (Select Concat(@dt_jv:= sum( ifnull(jv.debit, 0) ), " +
                        "                        @ct_jv:= sum( ifnull(jv.credit, 0) )," +
                        "                        @cnt_ := @cnt_+count(*)," +
                        "                        @cntT := @cntT+ count(*) " +
                        "                       ) amnt from jvdetails jv where jv.accountcode = c.accountcode  and      " +
                        "                                                      DATE_FORMAT(jv.date,'%m%y')  = @mmyy  and jv.posted=0 ) as journalv,      " +
                        "         (Select Concat(@dt_mct:= sum( ifnull(mt.debit, 0) )," +
                        "                        @ct_mct:= sum( ifnull(mt.credit, 0) )," +
                        "                        @cnt_ := @cnt_ + count(*)," +
                        "                        @cntT := @cntT+ count(*) " +
                        "                         ) amnt from mctdetails mt where mt.accountcode = c.accountcode  and   " +
                        "                                                         DATE_FORMAT(mt.date,'%m%y')  = @mmyy and mt.posted=0 ) as mct,   " +
                        "         if( (ifnull(@dt_av, 0) + ifnull(@dt_cv, 0) + ifnull(@dt_jv, 0) + ifnull(@dt_mct,0)) -" +
                        "             (ifnull(@ct_av, 0) + ifnull(@ct_cv, 0) + ifnull(@ct_jv, 0) + ifnull(@ct_mct,0)) > 0," +
                        "       format((ifnull(@dt_av, 0) + ifnull(@dt_cv, 0) + ifnull(@dt_jv, 0) + ifnull(@dt_mct,0)) -" +
                        "              (ifnull(@ct_av, 0) + ifnull(@ct_cv, 0) + ifnull(@ct_jv, 0) + ifnull(@ct_mct,0)),2) ,0.00) as debitF,      " +
                        "         if( (ifnull(@dt_av, 0) + ifnull(@dt_cv, 0) + ifnull(@dt_jv, 0) + ifnull(@dt_mct,0)) - " +
                        "             (ifnull(@ct_av, 0) + ifnull(@ct_cv, 0) + ifnull(@ct_jv, 0) + ifnull(@ct_mct,0)) < 0," +
                        "       format(-1*( (ifnull(@dt_av, 0) + ifnull(@dt_cv, 0) + ifnull(@dt_jv, 0) + ifnull(@dt_mct,0)) - " +
                        "                   (ifnull(@ct_av, 0) + ifnull(@ct_cv, 0) + ifnull(@ct_jv, 0) + ifnull(@ct_mct,0)) ),2) ,0.00) as creditF," +
                        "       @cnt_ as cnt " +                       
                        //"         Format(ifnull(@dt_av, 0) + ifnull(@dt_cv, 0) + ifnull(@dt_jv, 0) + ifnull(@dt_mct,0), 2) as debitF,      " +
                        //"         Format(ifnull(@ct_av, 0) + ifnull(@ct_cv, 0) + ifnull(@ct_jv, 0) + ifnull(@ct_mct,0), 2) as creditF      " +                       
                        "     FROM zanecoaccounting.chart c  ) f   where  f.debitF <> 0 or f.creditF <> 0";*/

            /*String qry = "   Select       " +
                         "          f.accountcode," +
                         "          f.accountname," +
                         "          f.beginningdate," +
                         "          f.beginningbal, " +
                         "          sum(ifnull(f.dt,0)) as debit,       " +
                         "          sum(ifnull(f.ct,0)) as credit,       " +
                         "          sum(f.cnt) as Cnt," +
                         "          f.pmonth       " +
                         "      from       " +
                         "      (       " +
                         "          (Select       " +
                         "              cvj.accountcode,       " +
                         "              c1.accountname, " +
                         "              c1.dateasof beginningdate," +
                         "              c1.balasof beginningbal,     " +
                         "              cv.cvdate date,       " +
                         "              cv.cvnumber as docno,       " +
                         "              cv.refnumber as refno,       " +
                         "              cv.cvpcode as pcode,       " +
                         "              if(cvj.debit = 0,'',format(cvj.debit,2) ) as debit,       " +
                         "              if(cvj.credit = 0,'',format(cvj.credit,2) ) as credit,        " +
                         "              cvj.cvparticulars particular,       " +
                         "              ifnull(cvj.debit,0) as dt,       " +
                         "              ifnull(cvj.credit,0) as ct, " +
                         "              cv.paymentDesc as Description," +
                         "              1 as cnt," +
                         "              date_format(cv.cvdate,'%m%y') as pmonth       " +
                         "          from cvjournal cvj       " +
                         "          left join checkvoucher cv on cv.cvnumber = cvj.cvnumber       " +
                         "          left join chart c1 on c1.accountcode = cvj.accountcode " +
                         "          where cv.cvnumber = cvj.cvnumber and cv.posted = 0 and DATE_FORMAT(cv.cvdate, '%Y-%m-%e') between c1.dateAsof and current_date() )       " +                                                                                                                            //"          where if(@atype = 'GL',cvj.glaccountcode,cvj.accountcode) = @acode and cvj.date between @datefrom and @dateto)       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              ad.accountcode,       " +
                         "              c2.accountname, " +
                         "              c2.dateasof beginningdate," +
                         "              c2.balasof beginningbal,     " +
                         "              a.apvdate date,       " +
                         "              a.apvnumber as docno,       " +
                         "              a.docnumber as refno,       " +
                         "              a.pcode as pcode,       " +
                        "               if(ad.debit = 0,'',format(ad.debit,2) ) as debit,       " +
                         "              if(ad.credit = 0,'',format(ad.credit,2) ) as credit,        " +
                         "              ad.particulars particular,       " +
                         "              ifnull(ad.debit,0) as dt,       " +
                         "              ifnull(ad.credit,0) as ct,       " +
                         "              a.pDescription as Description," +
                         "              1 as cnt," +
                         "              date_format(a.apvdate,'%m%y') as pmonth       " +
                         "          from apvdetails ad       " +
                         "          left join apvoucher a on a.apvnumber = ad.apvnumber       " +
                         "          left join chart c2 on c2.accountcode = ad.accountcode " +
                         "          where a.apvnumber = ad.apvnumber and a.posted = 0 and DATE_FORMAT(a.apvdate, '%Y-%m-%e') between c2.dateAsof and current_date() )       " +
                         "          union       " +
                         "          (Select       " +
                         "              jd.accountcode,       " +
                         "              c3.accountname, " +
                         "              c3.dateasof beginningdate," +
                         "              c3.balasof beginningbal,     " +
                         "              j.jvdate date,       " +
                         "              j.jvnumber as docno,       " +
                         "              '' as refno,       " +
                         "              '' as pcode,       " +
                         "              if(jd.debit = 0,'',format(jd.debit,2) ) as debit,       " +
                         "              if(jd.credit = 0,'',format(jd.credit,2) ) as credit,        " +
                         "              jd.particulars particular,       " +
                         "              ifnull(jd.debit,0) as dt,       " +
                         "              ifnull(jd.credit,0) as ct,       " +
                         "              j.description as Description," +
                         "              1 as cnt," +
                         "             date_format(j.jvdate,'%m%y') as pmonth       " +
                         "          from jvdetails jd       " +
                         "          left join journalv j on j.jvnumber = jd.jvnumber       " +
                         "          left join chart c3 on c3.accountcode = jd.accountcode " +
                         "          where j.jvnumber = jd.jvnumber and j.isposted = 0 and DATE_FORMAT(j.jvdate, '%Y-%m-%e') between c3.dateAsof and current_date())" +//DATE_ADD(c3.dateAsof, INTERVAL 1 DAY) and current_date() )       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              mt.accountcode, " +
                         "              c4.accountname, " +
                         "              c4.dateasof beginningdate," +
                         "              c4.balasof beginningbal,     " +
                         "              m.mctdate date,       " +
                         "              m.mctno as docno,       " +
                         "              m.refno as refno,       " +
                         "              m.requester as pcode,       " +
                         "              if(mt.debit = 0,'',format(mt.debit,2) ) as debit,       " +
                         "              if(mt.credit = 0,'',format(mt.credit,2) ) as credit,        " +
                         "              mt.particulars particular,       " +
                         "              @dt := @dt+ ifnull(mt.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(mt.credit,0) as ct,       " +
                         "              m.Description as Description," +
                         "              1 as cnt," +
                         "              date_format(m.mctdate,'%m%y') as pmonth       " +
                         "          from mctdetails mt       " +
                         "          left join materialct m on m.mctno = mt.mctno       " +
                         "          left join chart c4 on c4.accountcode = mt.accountcode " +
                         "          where m.mctno = mt.mctno and m.posted = 0 and DATE_FORMAT(m.mctdate, '%Y-%m-%e') between c4.dateAsof and current_date())       " +
                         "      ) f  group by f.accountcode     ";*/

            String qry = "   Select       " +
                         "          f.accountcode," +
                         "          f.accountname," +
                         "          f.beginningdate," +
                         "          f.beginningbal, " +
                         "          sum(ifnull(f.dt,0)) as debit,       " +
                         "          sum(ifnull(f.ct,0)) as credit,       " +
                         "          sum(f.cnt) as Cnt," +
                         "          f.pmonth       " +
                         "      from       " +
                         "      (       " +
                         "          (Select       " +
                         "              cvj.accountcode,       " +
                         "              c1.accountname, " +
                         "              c1.dateasof beginningdate," +
                         "              c1.balasof beginningbal,     " +
                         "              cv.cvdate date,       " +
                         "              cv.cvnumber as docno,       " +
                         "              cv.refnumber as refno,       " +
                         "              cv.cvpcode as pcode,       " +
                         "              if(cvj.debit = 0,'',format(cvj.debit,2) ) as debit,       " +
                         "              if(cvj.credit = 0,'',format(cvj.credit,2) ) as credit,        " +
                         "              cvj.cvparticulars particular,       " +
                         "              ifnull(cvj.debit,0) as dt,       " +
                         "              ifnull(cvj.credit,0) as ct, " +
                         "              cv.paymentDesc as Description," +
                         "              1 as cnt," +
                         "              date_format(cv.cvdate,'%m%y') as pmonth       " +
                         "          from cvjournal cvj       " +
                         "          left join checkvoucher cv on cv.cvnumber = cvj.cvnumber       " +
                         "          left join chart c1 on c1.accountcode = cvj.accountcode " +
                         "          where cv.cvnumber = cvj.cvnumber and cv.posted = 0 and date_format(cv.cvdate,'%m%y') = @mmyy)       " +                                                                                                                            //"          where if(@atype = 'GL',cvj.glaccountcode,cvj.accountcode) = @acode and cvj.date between @datefrom and @dateto)       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              ad.accountcode,       " +
                         "              c2.accountname, " +
                         "              c2.dateasof beginningdate," +
                         "              c2.balasof beginningbal,     " +
                         "              a.apvdate date,       " +
                         "              a.apvnumber as docno,       " +
                         "              a.docnumber as refno,       " +
                         "              a.pcode as pcode,       " +
                        "               if(ad.debit = 0,'',format(ad.debit,2) ) as debit,       " +
                         "              if(ad.credit = 0,'',format(ad.credit,2) ) as credit,        " +
                         "              ad.particulars particular,       " +
                         "              ifnull(ad.debit,0) as dt,       " +
                         "              ifnull(ad.credit,0) as ct,       " +
                         "              a.pDescription as Description," +
                         "              1 as cnt," +
                         "              date_format(a.apvdate,'%m%y') as pmonth       " +
                         "          from apvdetails ad       " +
                         "          left join apvoucher a on a.apvnumber = ad.apvnumber       " +
                         "          left join chart c2 on c2.accountcode = ad.accountcode " +
                         "          where a.apvnumber = ad.apvnumber and a.posted = 0 and date_format(a.apvdate,'%m%y') = @mmyy)       " +
                         "          union       " +
                         "          (Select       " +
                         "              jd.accountcode,       " +
                         "              c3.accountname, " +
                         "              c3.dateasof beginningdate," +
                         "              c3.balasof beginningbal,     " +
                         "              j.jvdate date,       " +
                         "              j.jvnumber as docno,       " +
                         "              '' as refno,       " +
                         "              '' as pcode,       " +
                         "              if(jd.debit = 0,'',format(jd.debit,2) ) as debit,       " +
                         "              if(jd.credit = 0,'',format(jd.credit,2) ) as credit,        " +
                         "              jd.particulars particular,       " +
                         "              ifnull(jd.debit,0) as dt,       " +
                         "              ifnull(jd.credit,0) as ct,       " +
                         "              j.description as Description," +
                         "              1 as cnt," +
                         "             date_format(j.jvdate,'%m%y') as pmonth       " +
                         "          from jvdetails jd       " +
                         "          left join journalv j on j.jvnumber = jd.jvnumber       " +
                         "          left join chart c3 on c3.accountcode = jd.accountcode " +
                         "          where j.jvnumber = jd.jvnumber and j.isposted = 0 and date_format(j.jvdate,'%m%y') = @mmyy)" +
                         "          union       " +
                         "          (Select       " +
                         "              mt.accountcode, " +
                         "              c4.accountname, " +
                         "              c4.dateasof beginningdate," +
                         "              c4.balasof beginningbal,     " +
                         "              m.mctdate date,       " +
                         "              m.mctno as docno,       " +
                         "              m.refno as refno,       " +
                         "              m.requester as pcode,       " +
                         "              if(mt.debit = 0,'',format(mt.debit,2) ) as debit,       " +
                         "              if(mt.credit = 0,'',format(mt.credit,2) ) as credit,        " +
                         "              mt.particulars particular,       " +
                         "              ifnull(mt.debit,0) as dt,       " +
                         "              ifnull(mt.credit,0) as ct,       " +
                         "              m.Description as Description," +
                         "              1 as cnt," +
                         "              date_format(m.mctdate,'%m%y') as pmonth       " +
                         "          from mctdetails mt       " +
                         "          left join materialct m on m.mctno = mt.mctno       " +
                         "          left join chart c4 on c4.accountcode = mt.accountcode " +
                         "          where m.mctno = mt.mctno and m.posted = 0 and date_format(m.mctdate,'%m%y') = @mmyy)       " +
                         "      ) f where ifnull(f.accountcode,'') <> ''  group by f.accountcode     ";



            ds = new DataSet();

            try
            {
                conn.Open();
                da = new MySqlDataAdapter(qry, conn);
                da.SelectCommand.Parameters.AddWithValue("@mmyy",mmyy_tf.Text);
               
                da.Fill(ds, "posted");
                tb_dbgdview.AutoGenerateColumns = false;
                tb_dbgdview.DataSource = ds.Tables["posted"];
                
                da.Dispose();
                conn.Close();

                //====================================
                //====assign amount posted============
                int rowcnt = tb_dbgdview.Rows.Count;
                postporgress.Maximum = rowcnt;
                for (int i = 0; i < rowcnt - 1; i++)
                {
                    this.AmntPosted = AmntPosted + Double.Parse(tb_dbgdview.Rows[i].Cells[6].Value.ToString().Replace(",", "")) +
                                                  Double.Parse(tb_dbgdview.Rows[i].Cells[7].Value.ToString().Replace(",", ""));                 

                }

                try
                {
                    lbl_tranNo.Text = tb_dbgdview.Rows[0].Cells[10].Value.ToString();
                }
                catch
                { }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
        private void addAccntCode_btn_Click(object sender, EventArgs e)
        {

        }

        private String counterpost()
        {
            String qry = "Select * from cntrmonthlypost where DATE_FORMAT(date,'%m%y') = '" + DateTime.Now.ToString("MMy") + "' order by idcntrmonthlypost desc limit 1";
            int cntr = 1;
            String postCode = "";
            
            try
            {                
                cmd = new MySqlCommand(qry, conn);
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cntr = int.Parse(dr["cntr"].ToString().Substring(7, 4));
                    cntr++;
                }
                else
                    cntr = 1;

                String num = cntr.ToString();
                postCode = "MP" + DateTime.Now.ToString("MMy") + "-" + num.PadLeft(4, '0');
                dr.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return postCode;

        }

        private void insertcntrPost(String cntr)
        {
            String qry = " insert into cntrmonthlypost(cntr,date)" +
                         " values (@cntr,now())";

            try
            {
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@cntr", cntr);
                

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("PMonth posting ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void postaccount()
        {
            String qry_ = "  Update apvoucher a,apvdetails ad set       " +
                         "            ad.posted = 1,       " +
                         "            ad.postedby = @userid,       " +
                         "            ad.posteddate = now(), " +
                         "            ad.mpcode = @mpcode,      " +
                         "            a.posted = 1,       " +
                         "            a.postedby = @userid,       " +
                         "            a.posteddate = now(),       " +
                         "            a.mpcode = @mpcode      " +
                         "  where ad.accountcode = @acode and ad.posted = 0 and DATE_FORMAT(a.apvdate,'%m%y')  = @monthY and " +
                         "        a.apvnumber = ad.apvnumber ;       " +                         
                         "  Update checkvoucher c, cvjournal cd set       " +
                         "            c.posted = 1,       " +
                         "            c.postedby = @userid,       " +
                         "            c.posteddate = now(),       " +
                         "            c.mpcode = @mpcode,      " +
                         "            cd.posted = 1,       " +
                         "            cd.postedby = @userid,       " +
                         "            cd.posteddate = now(),       " +
                         "            cd.mpcode = @mpcode      " +
                         "  where cd.accountcode = @acode and cd.posted = 0 and DATE_FORMAT(c.cvdate,'%m%y')  = @monthY and" +
                         "        c.cvnumber = cd.cvnumber;       " +                         
                         "  Update journalv j,jvdetails jd set       " +
                         "            j.isposted = 1,       " +
                         "            j.postedby = @userid,       " +
                         "            j.posteddate = now(),       " +
                         "            j.mpcode = @mpcode,      " +
                         "            jd.posted = 1,       " +
                         "            jd.postedby = @userid,       " +
                         "            jd.posteddate = now(),       " +
                         "            jd.mpcode = @mpcode      " +
                         "  where jd.accountcode = @acode and jd.posted = 0 and DATE_FORMAT(j.jvdate.date,'%m%y')  = @monthY and " +
                         "        jd.jvnumber = j.jvnumber;       " +
                         "  Update materialct m,mctdetails md set       " +
                         "            m.posted = 1,       " +
                         "            m.postedby = @userid,       " +
                         "            m.posteddate = now(),       " +
                         "            m.mpcode = @mpcode,      " +
                         "            md.posted = 1,       " +
                         "            md.postedby = @userid,       " +
                         "            md.posteddate = now(),       " +
                         "            md.mpcode = @mpcode      " +
                         "  where md.accountcode = @acode and md.posted = 0 and DATE_FORMAT(m.mctdate,'%m%y')  = @monthY and " +
                         "        md.mctno = m.mctno;       ";
            

            String mpcode;


            int rowcnt = tb_dbgdview.Rows.Count;
            postporgress.Maximum = rowcnt;

            for (int i = 0; i < rowcnt - 1; i++)
            {
                postporgress.Value = i;

                //if ((Double.Parse(tb_dbgdview.Rows[i].Cells[6].Value.ToString().Replace(",", "")) > 0) ||
                //    (Double.Parse(tb_dbgdview.Rows[i].Cells[7].Value.ToString().Replace(",", "")) > 0))
                if (Convert.ToBoolean(tb_dbgdview.Rows[i].Cells[0].Value))
                {
                    mpcode = counterpost();
                    insertcntrPost(mpcode);

                    cmd = new MySqlCommand(qry_, conn);
                    cmd.Parameters.AddWithValue("@monthY", tb_dbgdview.Rows[i].Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@acode", tb_dbgdview.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@mpcode", mpcode);
                    cmd.Parameters.AddWithValue("@userid", globalmainFrm.userlog);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                
                         insertposting(tb_dbgdview.Rows[i].Cells[1].Value.ToString(),
                                              tb_dbgdview.Rows[i].Cells[2].Value.ToString(),
                                              tb_dbgdview.Rows[i].Cells[3].Value.ToString(),
                                              tb_dbgdview.Rows[i].Cells[4].Value.ToString(),
                                              tb_dbgdview.Rows[i].Cells[8].Value.ToString(),
                                              tb_dbgdview.Rows[i].Cells[6].Value.ToString().Replace(",", ""),
                                              tb_dbgdview.Rows[i].Cells[7].Value.ToString().Replace(",", ""),
                                              tb_dbgdview.Rows[i].Cells[5].Value.ToString(),
                                              globalmainFrm.userlog,
                                              tb_dbgdview.Rows[i].Cells[11].Value.ToString(),
                                              mpcode);
                    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                    }
                }

            }

            postporgress.Value = rowcnt;
            MessageBox.Show("Account PMOnth successfully posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadaccount(mmyy_tf.Text);
        }

        private void insertposting(String accountcode, String accountname, String glaccountcode, String glaccountname, String accounttype, String debit, String credit, String pmonth, String user, String cutoffdate,String mpcode)
        {
            String qry = " insert into monthlyposted( date,accountcode,accountname,glaccountcode,glaccountname,accounttype,debit,credit,pmonth,user,cutoffdate,mpcode)" +
                         " values ( now(),@accountcode,@accountname,@glaccountcode,@glaccountname,@accounttype,@debit,@credit,@pmonth,@user,@cutoffdate,@mpcode)";


            try
            {
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@accountcode", accountcode);
                cmd.Parameters.AddWithValue("@accountname", accountname);
                cmd.Parameters.AddWithValue("@glaccountcode", glaccountcode);
                cmd.Parameters.AddWithValue("@glaccountname", glaccountname);
                cmd.Parameters.AddWithValue("@accounttype", accounttype);
                cmd.Parameters.AddWithValue("@debit", Double.Parse(debit));
                cmd.Parameters.AddWithValue("@credit", Double.Parse(credit));
                cmd.Parameters.AddWithValue("@pmonth", pmonth);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@cutoffdate", DateTime.Parse(cutoffdate));
                cmd.Parameters.AddWithValue("@mpcode", mpcode);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("PMonth posting ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

        }

        private void posting_btn_Click(object sender, EventArgs e)
        {
            if(mmyy_tf.Text.Length < 4)
            {
                MessageBox.Show("Invalid posting month...", uc.getMsgFrm(),MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if(AmntPosted<=0.00)
            {
                MessageBox.Show("Unable to continue this process.\nTherse's no transanction amount to be posted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            postaccount();
        }

        private void searchCode_btn_Click(object sender, EventArgs e)
        {            
            unpostedmonthFrm frm = new unpostedmonthFrm();
            frm.loadaccount += new unpostedmonthFrm.DoEventLoadunpost(loadaccount);
            frm.ShowDialog();
        }

        private void postingAccountFrm_Load(object sender, EventArgs e)
        {
            conn = db.getConn();
        }

        private void printPreviewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printUnposted(false);
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
                        "     concat('Month of ',@monthOf) as ascovered " +
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
                        "         where cvj.accountcode = @accountcode and DATE_FORMAT(cvj.date,'%m%y') = @mmyy  " +
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
                        "         where ad.accountcode = @accountcode and DATE_FORMAT(ad.date,'%m%y') = @mmyy " +
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
                        "         where jd.accountcode = @accountcode and DATE_FORMAT(jd.date,'%m%y') = @mmyy   " +
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
                        "         where mt.accountcode = @accountcode and DATE_FORMAT(mt.date, '%m%y') = @mmyy " +
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
                accountcode = sRow.Cells[1].Value.ToString();
            }
            catch
            { }

            try
            {
                //string iDate = "2005-05-05";
                //DateTime oDate = DateTime.Parse(iDate);

                da = new MySqlDataAdapter(qry, conn);
                da.SelectCommand.Parameters.AddWithValue("@mmyy", mmyy_tf.Text);                
                da.SelectCommand.Parameters.AddWithValue("@isposted", isposted);
                da.SelectCommand.Parameters.AddWithValue("@accountcode", accountcode);
                da.SelectCommand.Parameters.AddWithValue("@monthOf",DateTime.Parse("20"+mmyy_tf.Text.Substring(2,2)+ "-"+mmyy_tf.Text.Substring(0,2)+"-1").ToString("MMMM yyyy") );
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

        private void tb_dbgdview_Click(object sender, EventArgs e)
        {

        }

        private void tb_dbgdview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             foreach (DataGridViewRow row in tb_dbgdview.Rows)
             {
                 //If checked then highlight row

                 if (Convert.ToBoolean(row.Cells[0].Value))// Select is the name 
                                                                  //of chkbox column
                 {
                     //row.Selected = true;
                     // row.DefaultCellStyle.ba .SelectionBackColor = Color.LightSlateGray;
                     row.DefaultCellStyle.BackColor = Color.LightSlateGray;
                }
                else
                    row.DefaultCellStyle.BackColor = Color.White;
                //    row.Selected = false;
            }

            /*
                        //Check to ensure that the row CheckBox is clicked.
                        if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                        {
                            //Loop and uncheck all other CheckBoxes.
                            foreach (DataGridViewRow row in tb_dbgdview.Rows)
                            {
                                if (row.Index == e.RowIndex)
                                {
                                    // row.Cells[0].Value = !Convert.ToBoolean(row.Cells[0].EditedFormattedValue);
                                    row.Cells[0].Value = Convert.ToBoolean(row.Cells[0].EditedFormattedValue);
                                }
                                else
                                {
                                    row.Cells[0].Value = false;
                                }


                                if ((row.Cells[0].Selected == true) && (Convert.ToBoolean(row.Cells[0].Value) == false) )
                                {
                                    row.Cells[0].Value = true;
                                }
                                else
                                {
                                    row.Cells[0].Value = false;
                                }



                            }

                        }*/

        }

        private void tb_dbgdview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          /*  foreach (DataGridViewRow row in tb_dbgdview.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(true)) //3 is the column number of checkbox
                {
                    row.Selected = true;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                }
                else
                    row.Selected = false;
            }*/

        }

        private void tb_dbgdview_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
          /*  if (tb_dbgdview.IsCurrentCellDirty)
            {
                tb_dbgdview.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }*/
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
