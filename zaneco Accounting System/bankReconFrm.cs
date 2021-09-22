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
using System.IO;
using System.Collections;
using zaneco_Accounting_System.Reports;
using zaneco_Accounting_System.module;
using DevExpress.XtraGrid.Views.Grid;


namespace zaneco_Accounting_System
{
    public partial class bankReconFrm : Form
    {
        readonly Dictionary<object, bool> checkedMap = new Dictionary<object, bool>();

        private connectionDB db = new connectionDB();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private MySqlDataAdapter da;

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private connectionDB_budget db_bget = new connectionDB_budget();
        private MySqlConnection conn_bget = new MySqlConnection();
        private MySqlConnection conn_budgettmp = new MySqlConnection();

        private unitClass uc = new unitClass();

        private Boolean _isbankrecon_;
       
        //==============================
        String _brnumber = "";
        String _date = "";
        int _idbankrecon = 0;
        String _accountcode = "";
        Boolean isUnclearedError = false;
        String isUnclearedError_msg = "";

        public bankReconFrm()
        {
            InitializeComponent();

            this._isbankrecon_ = false;
        }

        public void setisbankrecon(Boolean isbankrecon_)
        {
            this._isbankrecon_ = isbankrecon_;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bankReconFrm_Load(object sender, EventArgs e)
        {
            //gridView2.OptionsSelection.MultiSelect = true;
            //gridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
           // repositoryItemCheckEdit1.Properties.ValueChecked = "On";
           // repositoryItemCheckEdit1.Properties.ValueUnchecked = "Off";
           // repositoryItemCheckEdit1.CheckedChanged += repositoryItemCheckEdit1_CheckedChanged1;

            conn_tmp = db_tmp.getConn();

            txtStatementdate.Text = StatementCal_.SelectionRange.Start.ToString("MMMM dd, yyyy");
            showFilter_cb.SelectedIndex = showFilter_cb.FindStringExact("Checks/Deposit Uncleared");           
            
            if(_isbankrecon_==false)
            {
                button3.Enabled = false;
                btnSave.Enabled = false;
            }
        }


        public void memoTotal(String code)
        {
            Double memobal = 0.00;
            String qry = " Set @d_cnt = 0;" +
                         " Set @c_cnt = 0;" +
                         " Set @dTotal = 0.00; " +
                         " Set @cTotal = 0.00; " +
                         " Select @dTotal as debitT," +
                         "        @cTotal as creditT, " +
                         "        @d_cnt as dCount, " +
                         "        @c_cnt as cCount," +
                         "        f.accountSF " +
                         " from (Select " +
                         "     @d_cnt := @d_cnt + if(ifnull(debit,0)>0,1,0) dCount, " +
                         "     @c_cnt := @c_cnt + if(ifnull(credit,0)>0,1,0) cCount," +
                         "     @dTotal := @dTotal + ifnull(debit,0) debitT," +
                         "     @cTotal := @cTotal + ifnull(credit,0) creditT," +
                         "     accountSF  " +
                         " from memobankrecon where accountSF = @code) f group by f.accountSF ";
            cmd = new MySqlCommand(qry,conn_tmp);
            cmd.Parameters.AddWithValue("@code",code);

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    lbl_debitCnt_memo.Text = dr.GetString("dCount");
                    lbl_creditCnt_memo.Text = dr.GetString("cCount");
                    lbl_debitTotal_memo.Text = dr.GetDouble("debitT").ToString("N02",uc.ci);
                    lbl_creditTotal_memo.Text = dr.GetDouble("creditT").ToString("N02",uc.ci);

                    memobal = dr.GetDouble("debitT") - dr.GetDouble("creditT");

                    if (memobal >= 0)
                        lbl_memoBal.Text = memobal.ToString("N02", uc.ci);
                    else
                        lbl_memoBal.Text = "( " + (memobal * -1).ToString("N02",uc.ci)+" )";
                }

                dr.Close();
                conn_tmp.Close();
            }
            catch
            {
                conn_tmp.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatementCal_.Visible = true;
        }

        private void StatementCal__DateSelected(object sender, DateRangeEventArgs e)
        {
            /*DateTime EndOfMonth;
            EndOfMonth = new DateTime(StatementCal_.SelectionRange.Start.Year, 
                                      StatementCal_.SelectionRange.Start.Month,
                                       DateTime.DaysInMonth(StatementCal_.SelectionRange.Start.Year, StatementCal_.SelectionRange.Start.Month));
            */
            StatementCal_.Visible = false;            
            txtStatementdate.Text = StatementCal_.SelectionRange.Start.ToString("MMMM dd, yyyy"); //EndOfMonth.ToString("MMMM dd, yyyy");

            loadbankrecon(txtaccountcode.Text);
        }

        private void loadAccount()
        {
         
        }

        private void StatementCal__DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            printBankRecon(txtaccountcode.Text);
        }

        private void printBankRecon(String accountcode_)
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            bankreconcileRpt myReport = new bankreconcileRpt();
            //CrystalReport2 myReport = new CrystalReport2();
            DataTable dt_table = new DataTable();
            DataTable oc_table = new DataTable();
            DataTable memo_tabl3 = new DataTable();
            DataTable header_table = new DataTable();

            String qry_Header = " Set @dt:=0.00;Set @ct := 0.00;       " +
                         "   Select   concat('As of ',@dateAsOf) dateAsOf, " +
                         "            concat('Bank Statement Date: ',@dateStmnt) dateStmnt, " +
                         "            concat(f.slcode,' - ',f.accountname)  accountcode, " +
                         "            @dt debitGL," +
                         "            -1*@ct creditGL," +
                         "            @endingBankbal endingBankbal," +
                         "            @memodebit memodebit," +
                         "            -1*@memocredit memocredit," +
                         "            f.beginningbal " +
                         /*"          f.*,       " +
                         "          format(@dt,2) as dtF,       " +
                         "          format(@ct,2) as ctF       " +*/
                         "      from       " +
                         "      (       " +
                         "          (Select   c1.accountname,    " +
                         "              cvj.accountcode slcode,       " +
                         "              cvj.date,       " +
                         "              cv.cvnumber as docno,       " +
                         "              cv.refnumber as refno,       " +
                         "              cv.cvpcode as pcode,       " +
                         "              if(cvj.debit = 0,'',format(cvj.debit,2) ) as debit,       " +
                         "              if(cvj.credit = 0,'',format(cvj.credit,2) ) as credit,        " +
                         "              cvj.cvparticulars particular,       " +
                         "              @dt := @dt + ifnull(cvj.debit,0) as dt,       " +
                         "              @ct := @ct + ifnull(cvj.credit,0) as ct, " +
                         "              cv.paymentDesc as Description," +
                         "              ifnull(cv.checknumber,'') as reference," +
                         "              c1.BalAsOf as beginningbal       " +
                         "          from cvjournal cvj       " +
                         "          left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher       " +
                         "          left join chart c1 on c1.accountcode = cvj.accountcode " +
                         "          where cvj.accountcode ='"+ accountcode_ + "' and cvj.date between c1.dateAsof and current_date() )       " + //DATE_FORMAT(date,'%Y-%m-%e')                                                                                                                                  
                         "          union       " +
                         "          (Select  c2.accountname,     " +
                         "              ad.accountcode slcode,       " +
                         "              ad.date,       " +
                         "              a.apvnumber as docno,       " +
                         "              a.docnumber as refno,       " +
                         "              a.pcode as pcode,       " +
                        "               if(ad.debit = 0,'',format(ad.debit,2) ) as debit,       " +
                         "              if(ad.credit = 0,'',format(ad.credit,2) ) as credit,        " +
                         "              ad.particulars particular,       " +
                         "              @dt := @dt+ ifnull(ad.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(ad.credit,0) as ct,       " +
                         "              a.pDescription as Description," +
                         "              a.pcode as reference,       " +
                         "              c2.BalAsOf as beginningbal       " +
                         "          from apvdetails ad       " +
                         "          left join apvoucher a on a.idAPVoucher = ad.idapv       " +
                         "          left join chart c2 on c2.accountcode = ad.accountcode " +
                         "          where ad.accountcode ='" + accountcode_ + "' and ad.date between c2.dateAsof and current_date() )       " +
                         //"          where if(@atype = 'GL',ad.glaccountcode,ad.accountcode) = @acode and ad.date between @datefrom and @dateto)       " +
                         "          union       " +
                         "          (Select c3.accountname,      " +
                         "              jd.accountcode slcode,       " +
                         "              jd.date,       " +
                         "              j.jvnumber as docno,       " +
                         "              '' as refno,       " +
                         "              '' as pcode,       " +
                         "              if(jd.debit = 0,'',format(jd.debit,2) ) as debit,       " +
                         "              if(jd.credit = 0,'',format(jd.credit,2) ) as credit,        " +
                         "              jd.particulars particular,       " +
                         "              @dt := @dt+ ifnull(jd.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(jd.credit,0) as ct,       " +
                         "              j.description as Description," +
                         "              if(ifnull(j.reference,'')='others',j.others,j.reference) as reference,       " +
                         "              c3.BalAsOf as beginningbal       " +
                         "          from jvdetails jd       " +
                         "          left join journalv j on j.idjournal = jd.idjournalv       " +
                         "          left join chart c3 on c3.accountcode = jd.accountcode " +
                         "          where jd.accountcode = '" + accountcode_ + "' and jd.date between c3.dateAsof and current_date() )       " +
                         //"          where if(@atype = 'GL',jd.glaccountcode,jd.accountcode) = @acode and jd.date between @datefrom and @dateto)       " +
                         "          union       " +
                         "          (Select    c4.accountname,   " +
                         "              mt.accountcode slcode,       " +
                         "              mt.date,       " +
                         "              m.mctno as docno,       " +
                         "              m.refno as refno,       " +
                         "              m.requester as pcode,       " +
                         "              if(mt.debit = 0,'',format(mt.debit,2) ) as debit,       " +
                         "              if(mt.credit = 0,'',format(mt.credit,2) ) as credit,        " +
                         "              mt.particulars particular,       " +
                         "              @dt := @dt+ ifnull(mt.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(mt.credit,0) as ct,       " +
                         "              m.Description as Description," +
                         "              concat('Req. ',m.requester) as reference,       " +
                         "              c4.BalAsOf as beginningbal       " +
                         "          from mctdetails mt       " +
                         "          left join materialct m on m.idmaterialct = mt.idmct       " +
                         "          left join chart c4 on c4.accountcode = mt.accountcode " +
                         "          where mt.accountcode = '" + accountcode_ + "' and DATE_FORMAT(mt.date,'%Y-%m-%e') between c4.dateAsof and current_date() )       " +
                         "      ) f  group by f.slcode order by f.date ";
            String qry_memo = " set @cntD:= 0;   " +
                              " set @cntC := 0;   " +
                              " set @cntD_ := 0;   " +
                              " set @cntC_ := 0;   " +
                              " Select   " +
                              "    fn.*   " +
                              "   from   " +
                              "   (   " +
                              "     select   " +
                              "       'Memo' gourpDesc, " +
                              "       f.cnt,   " +
                              "       if (f.codeAmnt = 'd',f.date,null) dateD,   " +
                              "       if (f.codeAmnt = 'd',f.amount,null) debit,   " +
                              "       cdt.date dateC,   " +
                              "       -1 * cdt.amount credit   " +
                              "     from   " +
                              "     ((SELECT   " +
                              "         @cntD:= @cntD + 1 cnt,   " +
                              "         'd' codeAmnt,   " +
                              "         a.date,   " +
                              "         a.debit as amount   " +
                              "         FROM(Select * from zanecoaccounting.memobankrecon   " +
                              "               where accountSF = @accountcode and debit > 0 order by date)  a)   " +
                              "        union   " +
                              "       (SELECT   " +
                              "         @cntC:= @cntC + 1 cnt,   " +
                              "         'c' codeAmnt,   " +
                              "         b.date,   " +
                              "         b.credit as amount   " +
                              "        FROM(Select * from zanecoaccounting.memobankrecon   " +
                              "              where accountSF = @accountcode and credit > 0 order by date) b)   " +
                              "      ) f   " +
                              "   left join((SELECT   " +
                              "                @cntD_:= @cntD_ + 1 cnt,   " +
                              "                'd' codeAmnt,   " +
                              "                 c.date,   " +
                              "                 c.debit as amount   " +
                              "                 FROM(Select * from zanecoaccounting.memobankrecon   " +
                              "                       where accountSF = @accountcode and debit > 0 order by date) c)         " +
                              "                union   " +
                              "                (SELECT   " +
                              "                  @cntC_:= @cntC_ + 1 cnt,   " +
                              "                  'c' codeAmnt,   " +
                              "                  d.date,   " +
                              "                  d.credit as amount   " +
                              "                  FROM(Select * from zanecoaccounting.memobankrecon   " +
                              "                        where accountSF = @accountcode and credit > 0 order by date) d)   " +
                              "             ) cdt on cdt.cnt = f.cnt and cdt.codeAmnt = 'c'   " +
                              "   ) fn group by fn.cnt   ";
            string outstandingcheck_qry = "( Select  DATE_FORMAT(datecleared,'%c/%e/%Y') as description, " +
                                         "           f.datecleared as date,  " +
                                         "           f.ref,  " +
                                         "           f.paymentCredit as debit,  " +
                                         "           f.chekbankDebit as credit,  " +
                                         "           f.gourpDesc," +
                                         "           f.totalDesc,  " +
                                         "           if(f.gourpDesc = 'Add: Deposits in Transit', " +
                                         "              (if (f.chekbankDebit > 0,f.chekbankDebit,f.paymentCredit))," +
                                         "              -1 *(if (f.chekbankDebit > 0,f.chekbankDebit,f.paymentCredit))" +
                                         "           ) amnt  " +
                                         "    from " +
                                         "    (  " +
                                         "      (select cd.idcvJournal iddoc,  " +
                                         "              ifnull(checknumber, '') ref,  " +
                                         "              cd.cvnumber as docno,  " +
                                         "              c.cvdate as date,  " +
                                         "              cd.accountcode,  " +
                                         "              cd.glaccountcode,  " +
                                         "              cd.cvparticulars as accountname,  " +
                                         "              cd.glaccountname,  " +
                                         "              ifnull(cd.credit, 0) chekbankDebit,  " +
                                         "              ifnull(cd.debit, 0) paymentCredit,  " +
                                         "              c.paymentdesc description,  " +
                                         "              if (br.idbankrecondetail is null,0,1) iscleared,  " +
                                         "              if (cd.iscleared = 0,@brnumber,br.brnumber) as brnumber,  " +
                                         "              ifnull(br.date, '') datecleared,  " +
                                         "              if (ifnull(cd.credit, 0) > 0,'Less: Outstanding Check','Add: Deposits in Transit') gourpDesc,  " +
                                         "              if (ifnull(cd.credit, 0) > 0,'Total Outstanding Check','Total Deposits in Transit') totalDesc  " +
                                         "           from cvjournal cd  " +
                                         "        left join chart ch on ch.accountcode = cd.accountcode  " +
                                         "        left join bankrecondetail br on br.iddoc = cd.idcvjournal and br.docno = cd.cvnumber  " +
                                         "        left join checkvoucher c on c.cvnumber = cd.cvnumber  " +
                                         "        where ch.isSF = '1' and  " +
                                         "              c.cvdate between ch.dateAsOf and current_date()  and  " +
                                         "              cd.accountcode = @accountcode )   " +
                                         "        union  " +
                                         "        (Select jd.idjvdetails iddoc,  " +
                                         "                ifnull(j.description, '') ref,  " +
                                         "                jd.jvnumber as docno,  " +
                                         "                j.jvdate as date,  " +
                                         "                jd.accountcode,  " +
                                         "                jd.glaccountcode,  " +
                                         "                jd.accountname as accountname,  " +
                                         "                jd.glaccountname,  " +
                                         "                0.00 chekbankDebit,  " +
                                         "                ifnull(jd.debit, 0) paymentCredit,  " +
                                         "                ifnull(jd.particulars, '') description,  " +
                                         "                if (br.idbankrecondetail is null,0,1) iscleared,  " +
                                         "                if (jd.iscleared = 0,@brnumber,br.brnumber) as brnumber,  " +
                                         "                ifnull(br.date, '') datecleared,  " +
                                         "                'Add: Deposits in Transit' gourpDesc,  " +
                                         "                'Total Deposits in Transit' totalDesc  " +
                                         "            from jvdetails jd  " +
                                         "            left join chart ch on ch.accountcode = jd.accountcode  " +
                                         "            left join journalv j on j.jvnumber = jd.jvnumber  " +
                                         "            left join bankrecondetail br on br.iddoc = jd.idjvdetails and br.docno = jd.jvnumber  " +
                                         "            where ifnull(jd.debit, 0) > 0 and  " +
                                         "                  ch.isSF = '1' and  " +
                                         "                  j.jvdate between ch.dateAsOf and current_date()  and  " +
                                         "                  jd.accountcode = @accountcode )             " +
                                         "    ) f where f.iscleared = 1  order by f.gourpDesc,f.date,f.docno) " +
                                         " union " +
                                         "( Select   '' as description, " +
                                         "           null as date,  " +
                                         "           '' ref,  " +
                                         "           0.00 as debit,  " +
                                         "           0.00 as credit,  " +
                                         "           'Add: Deposits in Transit' gourpDesc," +
                                         "           'Total Deposits in Transit' totalDesc,  " +
                                         "           null amnt  ) " +
                                         " union " +
                                         "( Select   '' as description, " +
                                         "           null as date,  " +
                                         "           '' ref,  " +
                                         "           0.00 as debit,  " +
                                         "           0.00 as credit,  " +
                                         "           'Less: Outstanding Check' gourpDesc," +
                                         "           'Total Outstanding Check' totalDesc,  " +
                                         "           null amnt  ) ";

            string depositTransit_qry = "( Select   '' as description, " +
                                         "           f.datecleared as date,  " +
                                         "           f.ref,  " +
                                         "           f.paymentCredit as debit,  " +
                                         "           f.chekbankDebit as credit,  " +
                                         "           f.gourpDesc," +
                                         "           f.totalDesc,  " +
                                         "           if (f.chekbankDebit > 0,f.chekbankDebit,f.paymentCredit) amnt  " +
                                         "    from " +
                                         "    (  " +
                                         "      (select cd.idcvJournal iddoc,  " +
                                         "              concat(c.bank, ' ', ifnull(checknumber, '')) ref,  " +
                                         "              cd.cvnumber as docno,  " +
                                         "              c.cvdate as date,  " +
                                         "              cd.accountcode,  " +
                                         "              cd.glaccountcode,  " +
                                         "              cd.cvparticulars as accountname,  " +
                                         "              cd.glaccountname,  " +
                                         "              ifnull(cd.credit, 0) chekbankDebit,  " +
                                         "              ifnull(cd.debit, 0) paymentCredit,  " +
                                         "              c.paymentdesc description,  " +
                                         "              if (br.idbankrecondetail is null,0,1) iscleared,  " +
                                         "              if (cd.iscleared = 0,@brnumber,br.brnumber) as brnumber,  " +
                                         "              ifnull(br.date, '') datecleared,  " +
                                         "              if (ifnull(cd.credit, 0) > 0,'Ronel Less: Outstanding Check','Add: Deposits in Transit') gourpDesc,  " +
                                         "              if (ifnull(cd.credit, 0) > 0,'Ronel Total Outstanding Check','Total Deposits in Transit') totalDesc  " +
                                         "           from cvjournal cd  " +
                                         "        left join chart ch on ch.accountcode = cd.accountcode  " +
                                         "        left join bankrecondetail br on br.iddoc = cd.idcvjournal and br.docno = cd.cvnumber  " +
                                         "        left join checkvoucher c on c.cvnumber = cd.cvnumber  " +
                                         "        where ch.isSF = '1' and  " +
                                         "              c.cvdate between ch.dateAsOf and '2019-05-01' and  " +
                                         "              cd.accountcode = '121-101-00-003' )   " +
                                         "        union  " +
                                         "        (Select jd.idjvdetails iddoc,  " +
                                         "                ifnull(j.description, '') ref,  " +
                                         "                jd.jvnumber as docno,  " +
                                         "                j.jvdate as date,  " +
                                         "                jd.accountcode,  " +
                                         "                jd.glaccountcode,  " +
                                         "                jd.accountname as accountname,  " +
                                         "                jd.glaccountname,  " +
                                         "                0.00 chekbankDebit,  " +
                                         "                ifnull(jd.debit, 0) paymentCredit,  " +
                                         "                ifnull(jd.particulars, '') description,  " +
                                         "                if (br.idbankrecondetail is null,0,1) iscleared,  " +
                                         "                if (jd.iscleared = 0,@brnumber,br.brnumber) as brnumber,  " +
                                         "                ifnull(br.date, '') datecleared,  " +
                                         "                'Add: Deposits in Transit' gourpDesc,  " +
                                         "                'Total Deposits in Transit' totalDesc  " +
                                         "            from jvdetails jd  " +
                                         "            left join chart ch on ch.accountcode = jd.accountcode  " +
                                         "            left join journalv j on j.jvnumber = jd.jvnumber  " +
                                         "            left join bankrecondetail br on br.iddoc = jd.idjvdetails and br.docno = jd.jvnumber  " +
                                         "            where ifnull(jd.debit, 0) > 0 and  " +
                                         "                  ch.isSF = '1' and  " +
                                         "                  j.jvdate between ch.dateAsOf and '2019-05-01' and  " +
                                         "                  jd.accountcode = '121-101-00-003' )             " +
                                         "    ) f where f.iscleared = 1  order by f.gourpDesc,f.date,f.docno) " +
                                         " union " +
                                         "( Select   '' as description, " +
                                         "           null as date,  " +
                                         "           '' ref,  " +
                                         "           0.00 as debit,  " +
                                         "           0.00 as credit,  " +
                                         "           'Ronel Add: Deposits in Transit' gourpDesc," +
                                         "           'Ronel Total Deposits in Transit' totalDesc,  " +
                                         "           null amnt  ) " +
                                         " union " +
                                         "( Select   '' as description, " +
                                         "           null as date,  " +
                                         "           '' ref,  " +
                                         "           0.00 as debit,  " +
                                         "           0.00 as credit,  " +
                                         "           'Ronel : Outstanding Check' gourpDesc," +
                                         "           'Ronel Total Outstanding Check' totalDesc,  " +
                                         "           null amnt  ) ";
                                           

            try
            {
                da = new MySqlDataAdapter(outstandingcheck_qry, conn_tmp);
                da.SelectCommand.Parameters.AddWithValue("@accountcode", accountcode_);
                conn_tmp.Open();
                da.Fill(oc_table);
                da.Dispose();
                ds.Tables.Add(oc_table);
                ds.Tables[0].TableName = "OutstandingCheck";

                da.Dispose();
                conn_tmp.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                conn_tmp.Close();
            }

            try
            {
                da = new MySqlDataAdapter(depositTransit_qry , conn_tmp);
                conn_tmp.Open();
                da.Fill(dt_table);
                da.Dispose();
                ds.Tables.Add(dt_table);
                ds.Tables[1].TableName = "DepositTransit";

                da.Dispose();
                conn_tmp.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                conn_tmp.Close();
            }
            //=======================MEMO
            try
            {
                da = new MySqlDataAdapter(qry_memo, conn_tmp);
                da.SelectCommand.Parameters.AddWithValue("@accountcode", accountcode_);
                conn_tmp.Open();
                da.Fill(memo_tabl3);
                da.Dispose();
                ds.Tables.Add(memo_tabl3);
                ds.Tables[2].TableName = "memobankrecon";

                da.Dispose();
                conn_tmp.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                conn_tmp.Close();
            }
            //==================================
            /*
             * "   Select   @dateAsOf dateAsOf, " +
                         "            @dateStmnt dateStmnt, " +
                         "            f.slcode accountcode, " +
                         "            @dt debitGL," +
                         "            @ct creditGL," +
                         "            @endingBankbal endingBankbal," +
                         "            @memodebit memodebit," +
                         "            @memocredit memocredit " +  
                         StatementCal_.SelectionRange.Start.ToString("MMMM dd, yyyy"); //EndOfMonth.ToString("MMMM dd, yyyy");
             */
            try
            {
                da = new MySqlDataAdapter(qry_Header, conn_tmp);
                //da.SelectCommand.Parameters.AddWithValue("@search", txtSearch.Text);
                da.SelectCommand.Parameters.AddWithValue("@accountcode", "121-101-00-003");//accountCode);
                da.SelectCommand.Parameters.AddWithValue("@dateAsOf", StatementCal_.SelectionRange.Start.ToString("d MMM yyyy")); 
                da.SelectCommand.Parameters.AddWithValue("@dateStmnt", StatementCal_.SelectionRange.Start.ToString("d MMMM yyyy"));
                da.SelectCommand.Parameters.AddWithValue("@endingBankbal", Double.Parse(lbl_endingBankbal.Text.Replace(",","")) );
                da.SelectCommand.Parameters.AddWithValue("@memodebit",Double.Parse(lbl_debitTotal_memo.Text.Replace(",","")));
                da.SelectCommand.Parameters.AddWithValue("@memocredit",Double.Parse(lbl_creditTotal_memo.Text.Replace(",","")));
                conn_tmp.Open();
                da.Fill(header_table);
                da.Dispose();
                ds.Tables.Add(header_table);
                ds.Tables[3].TableName = "headerRep";

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
        public void loadbankrecon(String accountcode)
        {   txtbrnumber.Text = bankreconCntr();
            String cleared = "0";

            _accountcode = accountcode;

            if (showFilter_cb.GetItemText(showFilter_cb.SelectedItem).ToString().Equals("Checks/Deposit Cleared"))
            {
                cleared = "1";
                //dgv.Columns[0].ReadOnly = true;
                
            }
            else
            {
                //dgv.Columns[0].ReadOnly = false;
            }
            

            String qry = "Select F.* from " +
                        "( (select  " +
                        "    cd.idcvJournal iddoc,  " +
                        "    ifnull(c.checknumber, '') ref,  " +
                        "    cd.cvnumber as docno,  " +
                        "    c.cvdate as date,  " +
                        "    cd.accountcode,  " +
                        "    ifnull(cd.glaccountcode,'') glaccountcode,  " +
                        "    ifnull(cd.cvparticulars,'') as accountname,  " +
                        "    ifnull(cd.glaccountname,'') glaccountname,  " +
                        "    ifnull(cd.credit, 0) chekbankDebit,  " +
                        "    ifnull(cd.debit,0) paymentCredit,  " +
                        "    ifnull(c.paymentdesc,'') description,  " +                        
                        "    if(br.idbankrecondetail is null,0,1) iscleared,"+
                        "    if(cd.iscleared=0,@brnumber,br.brnumber) as brnumber," +
                        "    if(br.idbankrecondetail is null,True,False) iscleared_," +
                        "    ifnull(br.date, '') datecleared," +
                        "    ifnull(br.userid,'') as userid  " + 
                        " from cvjournal cd  " +
                        " left join chart ch on ch.accountcode = cd.accountcode   " +
                        " left join bankrecondetail br on br.iddoc = cd.idcvjournal and br.docno = cd.cvnumber  " +
                        " left join checkvoucher c on c.cvnumber = cd.cvnumber   " +
                        " where " +
                        "        (ifnull(cd.credit,0) > 0 OR ifnull(cd.debit,0) > 0 ) and  " +//Temporarily removed this statement=
                        //"        c.cvamount>0 and c.voidcheck = 0  and " +//Temporarily removed this statement=
                        "        ch.isSF = '1' and  " +                        
                        "        c.cvdate between ch.dateAsOf and @dateto and" +
                        "        cd.accountcode = @accountcode )" +                      
                        " union  " +
                        " (Select  " +
                        "    jd.idjvdetails iddoc,  " +
                        "    ifnull(j.description, '') ref,  " +
                        "    jd.jvnumber as docno,  " +
                        "    j.jvdate as date,  " +
                        "    jd.accountcode,  " +
                        "    jd.glaccountcode,  " +
                        "    jd.accountname as accountname,  " +
                        "    jd.glaccountname,  " +
                        "    0.00 chekbankDebit,  " +
                        "    ifnull(jd.debit, 0) paymentCredit,  " +
                        "    ifnull(jd.particulars, '') description,  " +                        
                        "    if(br.idbankrecondetail is null,0,1) iscleared," +
                        "    if(jd.iscleared=0,@brnumber,br.brnumber) as brnumber," +
                        "    if(br.idbankrecondetail is null,True,False) iscleared_," +
                        "    ifnull(br.date,'') datecleared,  " +
                        "    ifnull(br.userid,'') as userid  " +
                        " from jvdetails jd  " +
                        " left join chart ch on ch.accountcode = jd.accountcode  " +
                        " left join journalv j on j.jvnumber = jd.jvnumber " +
                        " left join bankrecondetail br on br.iddoc = jd.idjvdetails and br.docno = jd.jvnumber  " +
                        " where ifnull(jd.debit, 0) > 0 and  " +
                        "        ch.isSF = '1' and  " +                        
                        "        j.jvdate between ch.dateAsOf and @dateto and" +
                        "        jd.accountcode = @accountcode )" +                        
                        ") f where f.iscleared = @cleared order by f.date,f.docno ";

            cmd = new MySqlCommand(qry, conn_tmp);

            ds = new DataSet();

            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);                

                da.SelectCommand.Parameters.AddWithValue("@accountcode", accountcode);
                da.SelectCommand.Parameters.AddWithValue("@brnumber", txtbrnumber.Text);
                da.SelectCommand.Parameters.AddWithValue("@dateto", StatementCal_.SelectionRange.Start.ToString("yyyy-MM-dd"));
                da.SelectCommand.Parameters.AddWithValue("@cleared", cleared);

                da.Fill(ds, "bankrecon");
                //checkv_dg.AutoGenerateColumns = false;
                //checkv_dg.DataSource = ds.Tables["checkv"];
                gridControl1.DataSource = ds.Tables["bankrecon"];

                da.Dispose();
                conn_tmp.Close();
                this.ActiveControl = gridControl1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
            /*cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@accountcode", accountcode);
            cmd.Parameters.AddWithValue("@brnumber", txtbrnumber.Text);
            cmd.Parameters.AddWithValue("@dateto", StatementCal_.SelectionRange.Start.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@cleared",cleared);

            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");
            String ref_str = "";
            String glaccountcode_str = "";
            String glaccountname_str = "";
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                dgv.Rows.Clear();
                while (dr.Read())
                {
                    try
                    {
                        ref_str = dr.GetString("ref");
                    }
                    catch
                    { }

                    try
                    {
                        glaccountcode_str = dr.GetString("glaccountcode");
                    }
                    catch
                    { }

                    try
                    {
                        glaccountname_str = dr.GetString("glaccountname");
                    }
                    catch
                    { }

                    dgv.Rows.Add(dr.GetBoolean("iscleared"),
                                 ref_str,
                                 dr.GetString("docno"),
                                 dr.GetString("accountcode"),
                                 dr.GetString("accountname"),
                                 dr.GetDouble("paymentCredit").ToString("N02", ci),
                                 dr.GetDouble("chekbankDebit").ToString("N02", ci),
                                 dr.GetDateTime("date").ToString("M/d/yyyy"),
                                 dr.GetString("datecleared"),                                  
                                 dr.GetString("description"),
                                 dr.GetString("iddoc"),
                                 glaccountcode_str,
                                 glaccountname_str,
                                 dr.GetString("brnumber")
                                 );

                    ref_str = "";
                    //MessageBox.Show("Ronel", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.ActiveControl = dgv;
                dr.Close();
                conn_tmp.Close();

                //captureBankrecon(StatementCal_.SelectionRange.Start.ToString("yyyy-MM-dd"), accountcode);
                //lastBalance(accountcode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);               
                conn_tmp.Close();
            }*/

            //RowCheckBoxClick();
        }

        private String bankreconCntr()
        {
            String qry = "Select * from counterbankrecon where yymm = '" + DateTime.Now.ToString("yMM") + "' order by idcounterbankrecon desc limit 1";
            int cntr = 1;
            String num = "";            
            try
            {

                if (db_tmp.OpenConnection())
                {
                    cmd = new MySqlCommand(qry, conn_tmp);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        cntr = int.Parse(dr["cntr"].ToString());
                        cntr++;
                    }

                    num = cntr.ToString();
                    num = "BR" + DateTime.Now.ToString("yMM") + "-" + num.PadLeft(3, '0');
                }
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                num = "1";
                num = "BR" + DateTime.Now.ToString("yMM") + "-" + num.PadLeft(3, '0');
            }
            finally
            {
                dr.Close();
                db_tmp.CloseConnection();

            }

            return num;
        }

        private void insertbrcounter()
        {
            String qry = "insert into counterbankrecon(recondate,yymm,cntr,brnumber) values (@recondate,@yymm,@cntr,@brnumber)";
            cmd = new MySqlCommand(qry, conn_tmp);

            cmd.Parameters.AddWithValue("@recondate", DateTime.Now);
            cmd.Parameters.AddWithValue("@yymm", txtbrnumber.Text.Substring(2, 4));
            cmd.Parameters.AddWithValue("@cntr", int.Parse(txtbrnumber.Text.Substring(7, 3)));
            cmd.Parameters.AddWithValue("@brnumber", txtbrnumber.Text);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();

                conn_tmp.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn_tmp.Close();
            }
        }

        private void ref_btn_Click(object sender, EventArgs e)
        {
            selectChartFrm frm = new selectChartFrm();           
            frm.frmBankreconInitl(this);
            frm.Text = "bankrecon";
            frm.setAccountcode(txtaccountcode.Text);

            frm.loadBankReconDgv += new selectChartFrm.DoEvent(loadbankrecon);
            frm.memoTotal += new selectChartFrm.DoEventMemo(memoTotal);


            frm.ShowDialog();
        }

        private void txtaccountcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = gridControl1;
                loadbankrecon(txtaccountcode.Text);
            }

            
        }

        private void showFilter_cb_SelectedValueChanged(object sender, EventArgs e)
        {
            loadbankrecon(txtaccountcode.Text);       
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (showFilter_cb.GetItemText(showFilter_cb.SelectedItem).ToString().Equals("Checks/Deposit Uncleared"))
            {
                _date = DateTime.Now.ToString("yyyy-MM-dd");
                _brnumber = "";
                _idbankrecon = 0;

                if (showFilter_cb.GetItemText(showFilter_cb.SelectedItem).ToString().Equals("Checks/Deposit Uncleared"))
                {
                    //MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd"));

                    if (searchbankrecon(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        updatebankrecon(txtbrnumber.Text, _date, lbl_endingBankbal.Text.Replace(",", ""), globalmainFrm.userlog, lbl_glBalance.Text, txtaccountcode.Text);
                    }
                    else
                    {

                        //===insert brnumber counter=============
                        insertbrcounter();

                        //insert bankreon========================
                        insertbankrecon(txtbrnumber.Text, _date, lbl_endingBankbal.Text.Replace(",", ""), globalmainFrm.userlog, lbl_glBalance.Text, txtaccountcode.Text);

                        if (searchbankrecon(DateTime.Now.ToString("yyyy-MM-dd")))
                        { }
                    }

                    saveBankrecon();
                }
            }
            else if (showFilter_cb.GetItemText(showFilter_cb.SelectedItem).ToString().Equals("Checks/Deposit Cleared"))
            {
                isUnclearedError = false;
                isUnclearedError_msg = "";

                DialogResult d = MessageBox.Show("Please confirm, if you like to uncleared the bank transactions..?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.No)
                    return;
                
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "iscleared").ToString().Equals("0"))
                    {
                        if (gridView1.GetRowCellValue(i, "userid").ToString().Equals(globalmainFrm.userlog))
                        {
                            unclearedAccount(gridView1.GetRowCellValue(i, "iddoc").ToString(),
                                             gridView1.GetRowCellValue(i, "docno").ToString());
                        }else
                        {
                            MessageBox.Show("Unable to unclear document number "+ gridView1.GetRowCellValue(i, "docno").ToString() +". \n"+
                                            "Please refer to the responsible end user (user ID:"+ gridView1.GetRowCellValue(i, "userid").ToString()+").", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                            isUnclearedError = true;
                            isUnclearedError_msg = isUnclearedError_msg + "Invalid user ID access.\n";
                        }
                    }
                }

                if (isUnclearedError)
                {
                    MessageBox.Show("Error: "+ isUnclearedError_msg, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    MessageBox.Show("Bank reconciliation record successfully uncleared. " , uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                loadbankrecon(txtaccountcode.Text);

            }
        }

        private void unclearedAccount(String iddoc,String docno)
        {
            String qry = "Delete from bankrecondetail where iddoc = '" + iddoc + "' and docno ='" + docno + "'";

            cmd = new MySqlCommand(qry, conn_tmp);
            conn_tmp.Open();

            try
            {
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch(Exception ex) 
            {
                isUnclearedError = true;
                isUnclearedError_msg = "=> " + isUnclearedError_msg + ex + "\n"; 
                conn_tmp.Close();
            }

        }

        private void captureBankrecon(String dateStr,String code)
        {
            String qry = "Select ifnull(brnumber,'') brnumber," +
                         "       ifnull(DATE_FORMAT(date,'%Y-%m-%e'),'')  date," +
                         "       idbankrecon, " +
                         "       format(ifnull(bankstateAmount,0),2)  bankstateAmount " +
                         " from bankrecon where DATE_FORMAT(date,'%Y-%m-%e') = @date and accountcode = @accountcode";
                       
            try
            {               
                
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@date", dateStr);
                cmd.Parameters.AddWithValue("@accountcode", code);

                conn_tmp.Open();
                dr = cmd.ExecuteReader();
               
                if (dr.Read())
                {
                    _brnumber = dr["brnumber"].ToString();
                    _date = dr["date"].ToString();
                    _idbankrecon = int.Parse(dr["idbankrecon"].ToString());
                    txtbrnumber.Text = _brnumber;
                    lbl_endingBankbal.Text = dr["bankstateAmount"].ToString();                   
                }

                conn_tmp.Close();
                dr.Close();
            }
            catch
            {
                conn_tmp.Close();
            }           
        }

        //========================================
        private Boolean searchbankrecon(String dateStr)
        {
            Boolean found = false;
            String qry = "Select ifnull(brnumber,'') brnumber," +
                         "       ifnull(DATE_FORMAT(date,'%Y-%m-%e'),'')  date," +
                         "       idbankrecon, " +
                         "       format(ifnull(bankstateAmount,0),2)  bankstateAmount " +
                         " from bankrecon where DATE_FORMAT(date,'%Y-%m-%d') = @date and accountcode = @accountcode ";

            try
             {

                conn_tmp.Open();
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@date", dateStr);
                cmd.Parameters.AddWithValue("@accountcode",txtaccountcode.Text);
                dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    /* _brnumber = dr["brnumber"].ToString();
                       _date = dr["date"].ToString();*/
                    _idbankrecon = int.Parse(dr["idbankrecon"].ToString());
                      // txtbrnumber.Text = _brnumber;
                      // lbl_endingBankbal.Text = dr["bankstateAmount"].ToString(); 

                    found = true;                    
                }

                conn_tmp.Close();
                dr.Close();
            }
            catch
            {
                 conn_tmp.Close();
            }

            return found;
        }

        private void saveBankrecon()
        {
            //int rowcnt = dgv.Rows.Count;
            Boolean isdata = false;            

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {                
                if (gridView1.GetRowCellValue(i, "iscleared").ToString().Equals("1"))
                    isdata = true;
            }


            if (isdata)
            {
                DialogResult d = MessageBox.Show("Please confirm, if you like to cleared the selected bank transactions..?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {

                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, "iscleared").ToString().Equals("1"))
                        {
                            //MessageBox.Show(dgv.Rows[i].Cells[1].Value.ToString());
                            insertbankrecondetail(txtbrnumber.Text,
                                        int.Parse(gridView1.GetRowCellValue(i, "iddoc").ToString()),
                                        gridView1.GetRowCellValue(i, "ref").ToString(),
                                        gridView1.GetRowCellValue(i, "docno").ToString(),
                                        DateTime.Parse(gridView1.GetRowCellValue(i, "date").ToString()).ToString("yyyy-MM-dd"), //
                                        gridView1.GetRowCellValue(i, "accountcode").ToString(),
                                        gridView1.GetRowCellValue(i, "accountname").ToString(),
                                        gridView1.GetRowCellValue(i, "glaccountcode").ToString(),
                                        gridView1.GetRowCellValue(i, "glaccountname").ToString(),
                                        gridView1.GetRowCellValue(i, "chekbankDebit").ToString(),
                                        gridView1.GetRowCellValue(i, "paymentCredit").ToString(),
                                        globalmainFrm.userlog,
                                        _idbankrecon);
                        }
                    }


                    loadbankrecon(txtaccountcode.Text);
                    MessageBox.Show("Bank reconcilation successfully saved...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select unreconciled bank transaction...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updatebankrecon(String brnumber, String date_, String bankStateAmount, String userid, String glbalance, String accountcode)
        {
            String qry = "update bankrecon set " +
                         "  brnumber = @brnumber," +
                         "  bankStateAmount = @bankStateAmount," +
                         "  userid = @userid," +
                         "  glbalance = @glbalance " +                        
                         " where DATE_FORMAT(date,'%Y-%m-%d') = @date and accountcode = @accountcode ";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@brnumber", brnumber);
            cmd.Parameters.AddWithValue("@date", date_);
            cmd.Parameters.AddWithValue("@bankStateAmount", Double.Parse(bankStateAmount));
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@glbalance", Double.Parse(glbalance));
            cmd.Parameters.AddWithValue("@accountcode", accountcode);
                        
           try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
           catch //(Exception ex)
            {
                conn_tmp.Close();
            }
        }

        private void insertbankrecon(String brnumber,String date, String bankStateAmount,String userid,String glbalance, String accountcode)
        {
            String qry = "insert into bankrecon(brnumber,date,bankStateAmount,userid,glbalance,accountcode) " +
                         "values(@brnumber,@date,@bankStateAmount,@userid,@glbalance,@accountcode)";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@brnumber", brnumber);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@bankStateAmount",Double.Parse(bankStateAmount));
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@glbalance", Double.Parse(glbalance));
            cmd.Parameters.AddWithValue("@accountcode", accountcode);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();      
            }
            catch// (Exception ex)
            {                
                conn_tmp.Close();
            }
        }

        private void insertbankrecondetail(String brnumber, int iddoc,String reff,String docno,String docdate,String accountcode, String accountname,String glaccountcode,String glaccountname,String chekbankDebit, String paymentCredit, String userid,int idbankrecon)
        {
            String qry = " insert into bankrecondetail(brnumber, date, iddoc, ref, docno, docdate, accountcode, accountname, glaccountcode, glaccountname, chekbankDebit, paymentCredit, userid,idbankrecon) " +
                         "   values(@brnumber, now(), @iddoc, @ref, @docno, @docdate, @accountcode, @accountname, @glaccountcode, @glaccountname, @chekbankDebit, @paymentCredit, @userid,@idbankrecon)";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@brnumber", brnumber);
            cmd.Parameters.AddWithValue("@iddoc", iddoc);
            cmd.Parameters.AddWithValue("@ref", reff);
            cmd.Parameters.AddWithValue("@docno", docno);
            cmd.Parameters.AddWithValue("@docdate", docdate);
            cmd.Parameters.AddWithValue("@accountcode", accountcode);
            cmd.Parameters.AddWithValue("@accountname", accountname);
            cmd.Parameters.AddWithValue("@glaccountcode", glaccountcode);
            cmd.Parameters.AddWithValue("@glaccountname", glaccountname);
            cmd.Parameters.AddWithValue("@chekbankDebit", Double.Parse(chekbankDebit.Replace(",", "")));
            cmd.Parameters.AddWithValue("@paymentCredit", Double.Parse(paymentCredit.Replace(",", "")));
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@idbankrecon", idbankrecon);
            
            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close(); 
                
                //update cleared JV and CV transactions=============
                if(docno.Substring(0, 2).Equals("CV"))
                {
                    updatecv(iddoc.ToString());
                }else if(docno.Substring(0, 2).Equals("JV"))
                {
                    updatejv(iddoc.ToString());
                }
                //===================================================
                                
            }
            catch// (Exception ex)
            {
                //MessageBox.Show("Bank reconcilation detail add ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

        private void updatejv(String idjv)
        {
            String qry = " update jvdetails set iscleared = '1' where idjvdetails = @idjv";
            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@idjv", idjv);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bank reconcilation detail add ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

        private void updatecv(String idcv)
        {
            String qry = " update cvjournal set iscleared = '1' where idcvjournal = @idcv";
            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@idcv", idcv);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bank reconcilation detail add ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }

        }               

        private void lastBalance(String accountcode)
        {
            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");
            Double unreconcileDiff = 0.00;
            String qry = "set @debit = 0.00; " +
                        " set @credit = 0.00;" +
                        " Select " +
                        " sum(F.chekbankDebit) chekbankDebit," +
                        " sum(F.paymentCredit) paymentCredit," +
                        " (sum(F.paymentCredit) - sum(F.chekbankDebit)) + ch.BalAsof lastBal," +
                        " ch.BalAsof + @debit - @credit glbalance " +
                        " from " +
                        "( (select  " +                        
                        "    cd.cvnumber as docno,  " +                      
                        "    ifnull(cd.credit, 0) chekbankDebit,  " +
                        "    ifnull(cd.debit,0) paymentCredit,  " +                        
                        "    if(br.idbankrecon is null,0,1) iscleared," +
                        "    cd.accountcode," +
                        "    @debit := @debit + ifnull(cd.debit,0) debit," +
                        "    @credit := @credit + ifnull(cd.credit,0) credit " +                                               
                        " from cvjournal cd  " +
                        " left join chart ch on ch.accountcode = cd.accountcode   " +
                        " left join bankrecondetail br on br.iddoc = cd.idcvjournal and br.docno = cd.cvnumber  " +
                        " left join checkvoucher c on c.cvnumber = cd.cvnumber   " +
                        " where " +
                        // "        cd.credit > 0 and  " +==============Temporarily removed this statement
                        // "        c.cvamount > 0 and c.voidcheck = 0 and "+
                        "        ch.isSF = '1' and " +
                        "        cd.date between ch.dateAsof and current_date() and " +                        
                        "        cd.accountcode = @accountcode )" +
                        " union  " +
                        " (Select  " +                        
                        "    jd.jvnumber as docno,  " +                     
                        "    0.00 chekbankDebit,  " +
                        "    ifnull(jd.debit, 0) paymentCredit,  " +                       
                        "    if(br.idbankrecon is null,0,1) iscleared," +
                        "    jd.accountcode," +
                        "    @debit := @debit + ifnull(jd.debit,0) debit," +
                        "    @credit := @credit + ifnull(jd.credit,0) credit " +
                        " from jvdetails jd  " +
                        " left join chart ch on ch.accountcode = jd.accountcode  " +
                        " left join journalv j on j.jvnumber = jd.jvnumber " +
                        " left join bankrecondetail br on br.iddoc = jd.idjvdetails and br.docno = jd.jvnumber  " +
                        " where ifnull(jd.debit, 0) > 0 and  " +
                        "        ch.isSF = '1' and  " +
                        "        jd.date between ch.dateAsof and current_date() and " +                       
                        "        jd.accountcode = @accountcode )" +
                        ") f " +
                        "left join chart ch on ch.accountcode = f.accountcode  " +
                        "where f.iscleared = '0' ";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@accountcode", accountcode);

            //OPEN CON
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lbl_GlbalanceB.Text = dr.GetDouble("glbalance").ToString("N02", ci);
                    lbl_glBalance.Text = dr.GetDouble("glbalance").ToString("N02", ci);                    
                    lbl_outstandingcheck.Text = dr.GetDouble("chekbankDebit").ToString("N02", ci);
                    lbl_DepositTransit.Text = dr.GetDouble("paymentCredit").ToString("N02", ci);

                    unreconcileDiff = Double.Parse(lbl_endingBankbal.Text.Replace(",", "")) -
                                      dr.GetDouble("chekbankDebit") +
                                      dr.GetDouble("paymentCredit") -
                                      dr.GetDouble("glbalance");

                    if (unreconcileDiff < 0)
                        lbl_unreconciledDiff.Text = "( " + (unreconcileDiff * (-1)).ToString("N02", ci) + " )";
                    else
                        lbl_unreconciledDiff.Text = unreconcileDiff.ToString("N02", ci);
                }
                dr.Close();
                conn_tmp.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show( ex.Message);
                conn_tmp.Close();
            }
        }


        
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgv.Rows[dgv.CurrentRow.Index].Cells[0];

            if ((!(showFilter_cb.GetItemText(showFilter_cb.SelectedItem).ToString().Equals("Checks/Deposit Cleared"))) &&
                (e.RowIndex >= 0) &&
                (e.ColumnIndex==0)
               )
            {
                if (ch1.Value == null)
                    ch1.Value = false;

                switch (ch1.Value.ToString())
                {
                    case "True":
                        {
                            ch1.Value = false;
                            // MessageBox.Show("true");
                            break;
                        }
                    case "False":
                        {
                            ch1.Value = true;
                            //Where should I put the selected cell here?                       
                            break;
                        }
                }

                RowCheckBoxClick();
            }*/
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
           
        }

        private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            memoBankreconFrm frm = new memoBankreconFrm();
            frm.setAccountcode(txtaccountcode.Text);

            frm.memoTotal += new memoBankreconFrm.DoEventMemo(memoTotal);
            frm.ShowDialog(); 
        }




        private void RowCheckBoxClick()
        //private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            CultureInfo ci = new CultureInfo("en-us");
            /*Double cleared = 0.00;
            Double outstanding = 0.00;
            Double diff = 0.00;
            Double endingBal = 0.00;
            Double total = 0.00;*/

            //==================
            //Double debit = 0.00;
            //Double credit = 0.00;
            int debit_cnt = 0;
            int credit_cnt = 0;
            //==================
            Double debit_uc = 0.00;
            Double credit_uc = 0.00;
            int debitcnt_uc = 0;
            int creditcnt_uc = 0;

            Double outstandingcheck = 0.00;
            Double DepositTransit = 0.00;
            Double unreconcileDiff = 0.00;

            /*
            foreach (DataGridViewRow Row in dgv.Rows)
            {
                if ((bool)(Row.Cells["Status"].Value) == true)
                {
                    if (Double.Parse(Row.Cells[5].Value.ToString().Replace(",", "")) > 0)
                        debit_cnt++;
                    else if (Double.Parse(Row.Cells[6].Value.ToString().Replace(",", "")) > 0)
                        credit_cnt++;

                    DepositTransit = DepositTransit + Double.Parse(Row.Cells[5].Value.ToString().Replace(",", ""));
                    outstandingcheck = outstandingcheck + Double.Parse(Row.Cells[6].Value.ToString().Replace(",", ""));

                }
                else
                {

                    debit_uc = debit_uc + Double.Parse(Row.Cells[5].Value.ToString().Replace(",", ""));
                    credit_uc = credit_uc + Double.Parse(Row.Cells[6].Value.ToString().Replace(",", ""));

                    if (Double.Parse(Row.Cells[5].Value.ToString().Replace(",", "")) > 0)
                        debitcnt_uc++;
                    else if (Double.Parse(Row.Cells[6].Value.ToString().Replace(",", "")) > 0)
                        creditcnt_uc++;
                }

            }*/

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "iscleared").ToString().Equals("1"))
                {                    

                    if (Double.Parse(gridView1.GetRowCellValue(i, "paymentCredit").ToString()) > 0)
                        debit_cnt++;
                    else if (Double.Parse(gridView1.GetRowCellValue(i, "chekbankDebit").ToString()) > 0)
                        credit_cnt++;

                    DepositTransit = DepositTransit + Double.Parse(gridView1.GetRowCellValue(i, "paymentCredit").ToString());
                    outstandingcheck = outstandingcheck + Double.Parse(gridView1.GetRowCellValue(i, "chekbankDebit").ToString());

                }else if (gridView1.GetRowCellValue(i, "iscleared").ToString().Equals("0"))
                {
                    debit_uc = debit_uc + Double.Parse(gridView1.GetRowCellValue(i, "paymentCredit").ToString());
                    credit_uc = credit_uc + Double.Parse(gridView1.GetRowCellValue(i, "chekbankDebit").ToString());

                    if (Double.Parse(gridView1.GetRowCellValue(i, "paymentCredit").ToString()) > 0)
                        debitcnt_uc++;
                    else if (Double.Parse(gridView1.GetRowCellValue(i, "chekbankDebit").ToString()) > 0)
                        creditcnt_uc++;
                }
            }



            //===============================================
            lbl_totaldebitAmount.Text = DepositTransit.ToString("N02", ci);
            lbl_totalcreditAmount.Text = outstandingcheck.ToString("N02",ci);
            lbl_creditCnt.Text = credit_cnt.ToString();
            lbl_debitcnt.Text = debit_cnt.ToString();

            //===============================================
            lblCreditUnclear.Text = "Uncleared " + creditcnt_uc.ToString() + " for " + credit_uc.ToString("N02",ci);
            lblDebitUnclear.Text = "Uncleared " + debitcnt_uc.ToString() + " for " + debit_uc.ToString("N02", ci);
                        
            lbl_outstandingcheck.Text = credit_uc.ToString("N02", ci);
            lbl_DepositTransit.Text = debit_uc.ToString("N02", ci);

            unreconcileDiff = Double.Parse(lbl_endingBankbal.Text.Replace(",", "")) -
                              Double.Parse(lbl_outstandingcheck.Text.Replace(",", "")) +
                              Double.Parse(lbl_DepositTransit.Text.Replace(",", "")) -
                              Double.Parse(lbl_glBalance.Text.Replace(",", ""));

            if(unreconcileDiff<0)
                lbl_unreconciledDiff.Text ="( "+ (unreconcileDiff*(-1)).ToString("N02",ci)+" )";
            else
                lbl_unreconciledDiff.Text = unreconcileDiff.ToString("N02", ci) ;

        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {             
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void lbl_endingBankbal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void lbl_endingBankbal_Leave(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-us");
            lbl_endingBankbal.Text = Double.Parse(lbl_endingBankbal.Text.Replace(",", "")).ToString("N02",ci);
        }

        private void lbl_endingBankbal_Click(object sender, EventArgs e)
        {
            lbl_endingBankbal.SelectAll();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            loadglLedger();            
        }

        private void loadglLedger()
        {
            accountLedgerFrm frm = new accountLedgerFrm();
                                    
            //==========================================
            //==========================================
            String qry = "Select * from chart where accountcode = @accountcode";

            try
            {
                globalcutoff.isforward = false;
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@accountcode", txtaccountcode.Text);

                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {                  

                    frm.accountcode_tf.Text = dr["accountcode"].ToString();
                    frm.accountname_tf.Text = dr["accountname"].ToString();
                    frm.dateasof_dp.Value = DateTime.Parse(dr["DateAsOf"].ToString());
                    frm.balance_tf.Text = Double.Parse(dr["BalAsof"].ToString()).ToString("N02", uc.ci);
                    frm.atype_tf.Text = dr["accounttype"].ToString();
                    frm.category_tf.Text = dr["category"].ToString();
                }

                conn_tmp.Close();
                dr.Close();
            }
            catch
            {
                conn_tmp.Close();
            }
            //==========================================
            //==========================================

            frm.ShowDialog();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_GlbalanceB_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            GridView currentView = sender as GridView;

            //cvno = gridControl.GetRowCellValue(RowCount, "idcheckvoucher").ToString();
            //if (e. .FieldName == "isclearedF")
            // {

            //}
            //currentView.GetRowCellValue(e.RowHandle, "cost").ToString()
        }

        private void repositoryItemCheckEdit2_Click(object sender, EventArgs e)
        {
           /* GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl2.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
            gridControl = (gridControl2.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

            MessageBox.Show(gridControl.GetRowCellValue(RowCount, "iscleared").ToString());
            repositoryItemCheckEdit2.ValueChecked = true;*/
            //cvno = gridControl.GetRowCellValue(RowCount, "idcheckvoucher").ToString();
        }

        private void repositoryItemCheckEdit2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            /*GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);*/

            GridView currentView = sender as GridView;

            //cvno = gridControl.GetRowCellValue(RowCount, "idcheckvoucher").ToString();
            //if (e.Column.FieldName == "isclearedF")
           // {

           // }

        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            //Double cost_ = 0.00;
            //Double cost__ = 0.00;
            //MessageBox.Show(currentView.GetRowCellValue(e.RowHandle, "iscleare").ToString());
            if (e.Column.FieldName == "isclearedF")
            {
                MessageBox.Show(currentView.GetRowCellValue(e.RowHandle, "iscleare").ToString());
                /*try
                {
                    cost_ = Double.Parse(currentView.GetRowCellValue(e.RowHandle, "cost").ToString().Replace(",", ""));
                }
                catch { }
                try
                {
                    cost__ = Double.Parse(currentView.GetRowCellValue(e.RowHandle, "costOrgn").ToString().Replace(",", ""));
                }
                catch { }

                if (e.RowHandle >= 0)
                {
                    if (cost__ == cost_)
                    {
                        e.Appearance.BackColor = Color.White;
                    }
                    else
                        e.Appearance.BackColor = Color.MistyRose;
                }*/


            }
        }


        private void KeepSelection(MouseEventArgs e, GridView view)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo(e.Location);
            if (hi.InRow)
            {
                if (hi.Column.FieldName != "DX$CheckboxSelectorColumn")
                {
                    int[] selectedRows = view.GetSelectedRows();
                    bool isSelected = view.IsRowSelected(hi.RowHandle);
                    BeginInvoke(new Action(() =>
                    {
                        for (int i = 0; i < selectedRows.Length; i++)
                            view.SelectRow(selectedRows[i]);
                        if (!isSelected) view.UnselectRow(hi.RowHandle);
                    }));
                }
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            KeepSelection(e, view);
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            KeepSelection(e, view);
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            /*if (gridView1.PostEditor())
            {
                gridView1.UpdateCurrentRow();
            }*/
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            RowCheckBoxClick();
        }
    }
}
