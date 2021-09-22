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
    public partial class accountLedgerFrm : Form
    {
        public String descSource { get; set; }
        public String date__fr { get; set; }
        public String date__to { get; set; }

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        //private MySqlDataReader dr ;
        private DataTable dt = new DataTable();
        private MySqlDataAdapter da;
        private DataSet ds = new DataSet();
        private unitClass uc= new unitClass();
        private chartAcamFrm frm_chartacam = new chartAcamFrm();

        public accountLedgerFrm()
        {
            InitializeComponent();
        }       
        public void chartAcamFrmInitl(chartAcamFrm frm_chartacam1)
        {
            this.frm_chartacam = frm_chartacam1;
        }
        private void print_btn_Click(object sender, EventArgs e)
        {
            //exportExcelGL();
            SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
            saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialogExcel.FileName;
                //gridControl1.DataSource = selectgridvalues();
                gridControl1.ExportToXlsx(exportFilePath);
            }
        }

        private void exportExcelGL()
        {
            //String glcode = "";
            MySqlDataAdapter daGL = new MySqlDataAdapter();
            //MySqlDataAdapter daSL = new MySqlDataAdapter();
            DataTable ledgerGL = new DataTable();
            DataTable ledgerSL = new DataTable();
            DataTable ledgerChart = new DataTable();
            ledgerChart.Columns.Add("Date", typeof(DateTime));//typeof(int)            
            ledgerChart.Columns.Add("Doc. No.", typeof(string));
            ledgerChart.Columns.Add("Reference", typeof(string));
            ledgerChart.Columns.Add("Trans. Description", typeof(string));            
            ledgerChart.Columns.Add("Debit", typeof(Decimal));
            ledgerChart.Columns.Add("Credit", typeof(Decimal));
           // ledgerChart.Columns.Add("Balance", typeof(Decimal));


            String qry = "Set @dt:=0.00; Set @ctt:=0.00; " +
                         "(Select @dateAsof date, " +
                         "        '' docno," +
                         "        '' ref,  " +
                         "        'Beginning Balance' transDesc, " +
                         "        @dt := @dt + if(@beginningbal>0,@beginningbal,0.00)  as dtF,      " +
                         "        @ctt := @ctt + if(@beginningbal<0,-@beginningbal,0.00) as ctF,    " +
                         "        ifnull(@beginningbal,0) as beginning,    " +
                         "        0.00 dtF_,      " +
                         "        0.00 ctF_ )    " +
                         " union " +
                         "( Select   DATE_FORMAT(fnl.datetmp, '%c/%e/%Y') date," +
                         "           fnl.docno,  " +
                         "           fnl.reference ref," +
                         "           fnl.Description transDesc," +
                         "           ifnull(fnl.dt,0) as dtF," +
                         "           ifnull(fnl.ct,0) as ctF, " +
                         "           0.00 as beginning,    " +
                         "           @dt := @dt + ifnull(fnl.dt,0) as dtF_," +
                         "           @ctt := @ctt + ifnull(fnl.ct,0) as ctF_ " +
                         "from  (  " +
                         "(   Select concat(@acode,' - ',@aname) accountcode,   " +
                         "           f.*," +
                         "           2 ordr " +
                         "      from       " +
                         "      (       " +
                         "          (Select       " +
                         "              cvj.accountcode slcode,       " +
                         "              cv.cvdate datetmp,     " +
                         "              cv.cvnumber as docno,       " +
                         "              cv.refnumber as refno,       " +
                         "              cv.cvpcode as pcode,       " +
                         "              if(cvj.debit = 0,'',format(cvj.debit,2) ) as debit,       " +
                         "              if(cvj.credit = 0,'',format(cvj.credit,2) ) as credit,        " +
                         "              cvj.cvparticulars particular,       " +
                         "              ifnull(cvj.debit,0) as dt,       " +
                         "              ifnull(cvj.credit,0) as ct, " +
                         "              cv.paymentDesc as Description," +
                         "              concat(cv.bank,' ',cv.checknumber) as reference       " +
                         "          from cvjournal cvj       " +
                         "          left join checkvoucher cv on cv.cvnumber = cvj.cvnumber       " +
                         "          left join chart c1 on c1.accountcode = cvj.accountcode " +
                         "          where cv.cvnumber = cvj.cvnumber and cvj.accountcode = @acode and cv.cvdate between @datefrom and @dateto )       " +
                         "          union       " +
                         "          (Select       " +
                         "              ad.accountcode slcode,       " +
                         "              a.apvdate datetmp,       " +
                         "              a.apvnumber as docno,       " +
                         "              a.docnumber as refno,       " +
                         "              a.pcode as pcode,       " +
                        "               if(ad.debit = 0,'',format(ad.debit,2) ) as debit,       " +
                         "              if(ad.credit = 0,'',format(ad.credit,2) ) as credit,        " +
                         "              ad.particulars particular, " +
                         "              ifnull(ad.debit,0) as dt,       " +
                         "              ifnull(ad.credit,0) as ct, " +
                         "              a.pDescription as Description," +
                         "              a.pcode as reference       " +
                         "          from apvdetails ad       " +
                         "          left join apvoucher a on a.apvnumber = ad.apvnumber       " +
                         "          left join chart c2 on c2.accountcode = ad.accountcode " +
                         "          where a.apvnumber = ad.apvnumber and ad.accountcode = @acode and a.apvdate between @datefrom and @dateto )       " +
                         "          union       " +
                         "          (Select       " +
                         "              jd.accountcode slcode,       " +
                         "              j.jvdate datetmp,       " +
                         "              j.jvnumber as docno,       " +
                         "              '' as refno,       " +
                         "              '' as pcode,       " +
                         "              if(jd.debit = 0,'',format(jd.debit,2) ) as debit,       " +
                         "              if(jd.credit = 0,'',format(jd.credit,2) ) as credit,        " +
                         "              jd.particulars particular,       " +
                         "              ifnull(jd.debit,0) as dt,       " +
                         "              ifnull(jd.credit,0) as ct, " +
                         "              j.description as Description," +
                         "              if(ifnull(j.reference,'')='others',j.others,j.reference) as reference       " +
                         "          from jvdetails jd       " +
                         "          left join journalv j on j.jvnumber = jd.jvnumber       " +
                         "          left join chart c3 on c3.accountcode = jd.accountcode " +
                         "          where j.jvnumber = jd.jvnumber and jd.accountcode = @acode and  DATE_FORMAT(j.jvdate,'%Y-%m-%d') between @datefrom and @dateto )       " +
                         "          union       " +
                         "          (Select       " +
                         "              mt.accountcode slcode,       " +
                         "              m.mctdate datetmp,       " +
                         "              m.mctno as docno,       " +
                         "              m.refno as refno,       " +
                         "              m.requester as pcode,       " +
                         "              if(mt.debit = 0,'',format(mt.debit,2) ) as debit,       " +
                         "              if(mt.credit = 0,'',format(mt.credit,2) ) as credit,        " +
                         "              mt.particulars particular,       " +
                         "              ifnull(mt.debit,0) as dt,       " +
                         "              ifnull(mt.credit,0) as ct, " +
                         "              m.Description as Description," +
                         "              concat('Req. ',m.requester) as reference       " +
                         "          from mctdetails mt       " +
                         "          left join materialct m on m.mctno = mt.mctno       " +
                         "          left join chart c4 on c4.accountcode = mt.accountcode " +
                         "          where  m.mctno = mt.mctno and mt.accountcode = @acode and DATE_FORMAT(m.mctdate,'%Y-%m-%d') between @datefrom and @dateto )       " +
                         "          ) f  order by f.datetmp       )" +
                         ") fnl  where ifnull(fnl.docno,'') <> '' order by fnl.ordr,fnl.datetmp )" +
                         " union " +
                         "(Select now() date," +
                         "        '' docno," +
                         "        '' ref,  " +
                         "        'Total ' transDesc," +
                         "        @dt  as dtF,      " +
                         "        @ctt  as ctF,    " +
                         "        ifnull(@beginningbal,0) as beginning,    " +
                         "        @dt  as dtF_,      " +
                         "        @ctt  as ctF_ )    " +
                         " union " +
                         "(Select now() date," +
                         "        '' docno," +
                         "        '' ref,  " +
                         "        'Ending Balance ' transDesc," +
                         "        0.00  as dtF,      " +
                         "        @dt-@ctt as ctF,    " +
                         "        @dt-@ctt as beginning,    " +
                         "        @dt  as dtF_,      " +
                         "        @ctt  as ctF_ )    ";





            try
            {
                conn_tmp.Open();
                daGL = new MySqlDataAdapter(qry, conn_tmp);               
                daGL.SelectCommand.Parameters.AddWithValue("@acode", accountcode_tf.Text);
                daGL.SelectCommand.Parameters.AddWithValue("@beginningbal", Double.Parse(balance_tf.Text.Replace(",", "")));
                daGL.SelectCommand.Parameters.AddWithValue("@dateAsof", dateasof_dp.Value);
                daGL.SelectCommand.Parameters.AddWithValue("@aname", accountname_tf.Text);
                daGL.SelectCommand.Parameters.AddWithValue("@datefrom", date_from.Value);
                daGL.SelectCommand.Parameters.AddWithValue("@dateto", date_to.Value);
                daGL.Fill(ledgerGL);
                conn_tmp.Close();
                
                foreach (DataRow datarow in ledgerGL.Rows)
                {
                    ledgerChart.Rows.Add(datarow[0].ToString(),
                                         datarow[1].ToString(),
                                         datarow[2].ToString(),
                                         datarow[3].ToString(),
                                         datarow[4].ToString(),
                                         datarow[5].ToString());
                                       
                }
                daGL.Dispose();                

                //data table to excel file===============================

                Excel.ExcelUtlity obj = new Excel.ExcelUtlity();
                obj.WriteDataTableToExcel(ledgerChart, "General Ledger ("+ accountcode_tf.Text+")", "D:\\AccountingExcel\\GeneralLedger.xlsx", "General Ledger (" + accountcode_tf.Text + ")");

                MessageBox.Show("Excel successfully created to D:\\AccountingExcel\\GeneralLedger.xlsx...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                ledgerChart.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                daGL.Dispose();                
                ledgerChart.Dispose();
                conn_tmp.Close();
            }
        }

        private void loadleger()
        {
            //Double endingBal = 0.00;
            String qry = " Set @dt:=0.00;Set @ct := 0.00;       " +
                         "   Select       " +
                         "          f.*,       " +
                         "          format(@dt,2) as dtF,       " +
                         "          format(@ct,2) as ctF " +                        
                         "      from       " +
                         "      (       " +
                         "          (Select " +
                         "                '' slcode, " +
                         "                @dateAsof date, " +
                         "                @acode docno," +
                         "                '' refno," +
                         "                '' pcode,  " +                        
                         "                if(@beginningbal>0,@beginningbal,0.00)  as debit,      " +
                         "                if(@beginningbal<0,-@beginningbal,0.00) as credit,  " +
                         "                ''  particular," +
                         "                @dt := @dt + if(@beginningbal>0,@beginningbal,0.00)  as dt,      " +
                         "                @ctt := @ctt + if(@beginningbal<0,-@beginningbal,0.00) as ct,  " +
                         "                Concat('Beginning Balance (',@acode,':',@accountname,')') as Description,    " +
                         "                '' reference," +
                         "                '' payee," +
                         "                1 beginning )     " +                        
                         "          union " +
                         "          (Select       " +
                         "              cvj.accountcode slcode,       " +
                         "              cv.cvdate date,       " +
                         "              cv.cvnumber as docno,       " +
                         "              cv.refnumber as refno,       " +
                         "              cv.cvpcode as pcode,       " +
                         "              ifnull(cvj.debit,0) as debit,       " +
                         "              ifnull(cvj.credit,0) as credit,        " +
                         "              cvj.cvparticulars particular,       " +
                         "              @dt := @dt + ifnull(cvj.debit,0) as dt,       " +
                         "              @ct := @ct + ifnull(cvj.credit,0) as ct, " +
                         "              cv.paymentDesc as Description," +
                         "              concat(cv.bank,' ',cv.checknumber) as reference," +
                         "              cv.cvpname payee," +
                         "              0 beginning       " +
                         "          from cvjournal cvj       " +
                         "          left join checkvoucher cv on cv.cvnumber = cvj.cvnumber       " +
                         "          left join chart c1 on c1.accountcode = cvj.accountcode " +
                         "          where cv.cvnumber = cvj.cvnumber and cvj.accountcode = @acode and DATE_FORMAT(cv.cvdate,'%Y-%m-%d') between DATE_FORMAT(@datefrom,'%Y-%m-%d') and DATE_FORMAT(@dateto,'%Y-%m-%d') )       " + //DATE_FORMAT(date,'%Y-%m-%e')                                                                                                                           //"          where if(@atype = 'GL',cvj.glaccountcode,cvj.accountcode) = @acode and cvj.date between @datefrom and @dateto)       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              ad.accountcode slcode,       " +
                         "              a.apvdate date,       " +
                         "              a.apvnumber as docno,       " +
                         "              a.docnumber as refno,       " +
                         "              a.pcode as pcode,       " +
                        "               ifnull(ad.debit,0) as debit,       " +
                         "              ifnull(ad.credit,0) as credit,        " +
                         "              ad.particulars particular,       " +
                         "              @dt := @dt+ ifnull(ad.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(ad.credit,0) as ct,       " +
                         "              a.pDescription as Description," +
                         "              a.pcode as reference," +
                         "              a.pname payee," +
                         "              0 beginning       " +
                         "          from apvdetails ad       " +
                         "          left join apvoucher a on a.apvnumber = ad.apvnumber       " +
                         "          left join chart c2 on c2.accountcode = ad.accountcode " +
                         "          where a.apvnumber = ad.apvnumber and ad.accountcode = @acode and DATE_FORMAT(a.apvdate,'%Y-%m-%d') between DATE_FORMAT(@datefrom,'%Y-%m-%d') and DATE_FORMAT(@dateto,'%Y-%m-%d') )       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              jd.accountcode slcode,       " +
                         "              j.jvdate date,       " +
                         "              j.jvnumber as docno,       " +
                         "              '' as refno,       " +
                         "              '' as pcode,       " +
                         "              ifnull(jd.debit,0) as debit,       " +
                         "              ifnull(jd.credit,0) as credit,        " +
                         "              jd.particulars particular,       " +
                         "              @dt := @dt+ ifnull(jd.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(jd.credit,0) as ct,       " +
                         "              j.description as Description," +
                         "              if(ifnull(j.reference,'')='others',j.others,j.reference) as reference," +
                         "              '' payee," +
                         "              0 beginning       " +
                         "          from jvdetails jd       " +
                         "          left join journalv j on j.jvnumber = jd.jvnumber       " +
                         "          left join chart c3 on c3.accountcode = jd.accountcode " +
                         "          where j.jvnumber = jd.jvnumber and jd.accountcode = @acode and DATE_FORMAT(j.jvdate,'%Y-%m-%d') between DATE_FORMAT(@datefrom,'%Y-%m-%d') and DATE_FORMAT(@dateto,'%Y-%m-%d'))" +//DATE_ADD(c3.dateAsof, INTERVAL 1 DAY) and current_date() )       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              mt.accountcode slcode,       " +
                         "              m.mctdate date,       " +
                         "              m.mctno as docno,       " +
                         "              m.refno as refno,       " +
                         "              m.requester as pcode,       " +
                         "              ifnull(mt.debit,0) as debit,       " +
                         "              ifnull(mt.credit,0) as credit,        " +
                         "              mt.particulars particular,       " +
                         "              @dt := @dt+ ifnull(mt.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(mt.credit,0) as ct,       " +
                         "              m.Description as Description," +
                         "              concat('Req. ',m.requester) as reference," +
                         "              '' payee," +
                         "              0 beginning       " +
                         "          from mctdetails mt       " +
                         "          left join materialct m on m.mctno = mt.mctno       " +
                         "          left join chart c4 on c4.accountcode = mt.accountcode " +
                         "          where m.mctno = mt.mctno and mt.accountcode = @acode and DATE_FORMAT(m.mctdate,'%Y-%m-%d') between DATE_FORMAT(@datefrom,'%Y-%m-%d') and DATE_FORMAT(@dateto,'%Y-%m-%d') )       " +
                         "      ) f  where ifnull(f.docno,'') <> '' OR f.beginning = 1  order by f.beginning desc,f.date asc      ";

           /* String qryForwarded = " Set @dt:=0.00;Set @ct := 0.00;       " +
                         "   Select       " +
                         "          f.*,       " +
                         "          format(@dt,2) as dtF,       " +
                         "          format(@ct,2) as ctF       " +
                         "      from       " +
                         "      (       " +
                         "          (Select       " +
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
                         "              concat(cv.bank,' ',cv.checknumber) as reference       " +
                         "          from cvjournal cvj       " +
                         "          left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher       " +
                         "          left join forwardedchart c1 on c1.idforwardedchart = @idforwardedchart " +
                         "          where cvj.accountcode = @acode and cvj.date between DATE_ADD(c1.dateAsof, INTERVAL 1 DAY) and c1.cutoffdate )       " + //DATE_FORMAT(date,'%Y-%m-%e')
                                                                                                                                   //"          where if(@atype = 'GL',cvj.glaccountcode,cvj.accountcode) = @acode and cvj.date between @datefrom and @dateto)       " +                         
                         "          union       " +
                         "          (Select       " +
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
                         "              a.pcode as reference       " +
                         "          from apvdetails ad       " +
                         "          left join apvoucher a on a.idAPVoucher = ad.idapv       " +
                         "          left join forwardedchart c2 on c2.idforwardedchart = @idforwardedchart " +
                         "          where ad.accountcode = @acode and ad.date between DATE_ADD(c2.dateAsof, INTERVAL 1 DAY) and c2.cutoffdate )       " +
                         //"          where if(@atype = 'GL',ad.glaccountcode,ad.accountcode) = @acode and ad.date between @datefrom and @dateto)       " +
                         "          union       " +
                         "          (Select       " +
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
                         "              if(ifnull(j.reference,'')='others',j.others,j.reference) as reference       " +
                         "          from jvdetails jd       " +
                         "          left join journalv j on j.idjournal = jd.idjournalv       " +
                         "          left join forwardedchart c3 on c3.idforwardedchart = @idforwardedchart " +
                         "          where jd.accountcode = @acode and jd.date between DATE_ADD(c3.dateAsof, INTERVAL 1 DAY) and c3.cutoffdate )       " +
                         //"          where if(@atype = 'GL',jd.glaccountcode,jd.accountcode) = @acode and jd.date between @datefrom and @dateto)       " +
                         "          union       " +
                         "          (Select       " +
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
                         "              concat('Req. ',m.requester) as reference       " +
                         "          from mctdetails mt       " +
                         "          left join materialct m on m.idmaterialct = mt.idmct       " +
                         "          left join forwardedchart c4 on c4.idforwardedchart = @idforwardedchart " +
                         "          where mt.accountcode = @acode and DATE_FORMAT(mt.date,'%Y-%m-%e') between DATE_ADD(c4.dateAsof, INTERVAL 1 DAY) and c4.cutoffdate )       " +
                         //"          where if(@atype = 'GL',mt.glaccountcode,mt.accountcode) = @acode and mt.date between @datefrom and @dateto)       " +
                         //"      ) f where f.slcode like @slcode OR f.pcode like @slcode order by f.date       ";
                         "      ) f   where ifnull(f.docno,'') <> '' order by f.date       ";*/

            //if (globalcutoff.isforward)
             //   qry = qryForwarded;

            ds = new DataSet();
                       

            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);                
                da.SelectCommand.Parameters.AddWithValue("@acode",accountcode_tf.Text);
                da.SelectCommand.Parameters.AddWithValue("@accountname", accountname_tf.Text);                
                da.SelectCommand.Parameters.AddWithValue("@datefrom", date_from.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto", date_to.Value);
                da.SelectCommand.Parameters.AddWithValue("@beginningbal", Double.Parse(balance_tf.Text.Replace(",", "")));
                da.SelectCommand.Parameters.AddWithValue("@dateAsof", dateasof_dp.Value);

                if (globalcutoff.isforward)
                    da.SelectCommand.Parameters.AddWithValue("@idforwardedchart",int.Parse(globalcutoff.idforwardedchart));

                da.Fill(ds, "ledger");
                //ledgerGridView.AutoGenerateColumns = false;
                //ledgerGridView.DataSource = ds.Tables["ledger"];
                gridControl1.DataSource = ds.Tables["ledger"];

                da.Dispose();
                conn_tmp.Close();

                /*this.ActiveControl = ledgerGridView;
                if (ledgerGridView.Rows.Count > 0)
                {
                    int selectedrowindex = ledgerGridView.SelectedCells[0].RowIndex;
                    DataGridViewRow sRow = ledgerGridView.Rows[selectedrowindex];

                    endingBal = Double.Parse(balance_tf.Text.Replace(",","")) +
                                Double.Parse(sRow.Cells[9].Value.ToString().Replace(",", "")) -
                                Double.Parse(sRow.Cells[10].Value.ToString().Replace(",", ""));

                    lbl_credit.Text = Double.Parse(sRow.Cells[10].Value.ToString().Replace(",", "")).ToString("N02",uc.ci);
                    lbl_debit.Text = Double.Parse(sRow.Cells[9].Value.ToString().Replace(",", "")).ToString("N02", uc.ci);

                    if (endingBal<0)
                    {
                        lbl_totalapv.Text ="( "+ (endingBal *(-1)).ToString("N02", uc.ci)+" )";
                    }else
                    {
                        lbl_totalapv.Text = endingBal.ToString("N02", uc.ci);
                    }
                        
                    //credit_lb.Text = sRow.Cells[9].Value.ToString();

                    //lbl_endingBal.Text
                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

        private void accountLedger_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            date_from.Value = uc.StartOfMonth;
            date_to.Value = uc.EndOfMonth;

            try
            {
                if (descSource.Equals("mct"))
                {
                    //date__fr = date_from.Value.ToString("yyyy-MM-dd");
                    date_from.Value = DateTime.Parse(date__fr);
                    date_to.Value = DateTime.Parse(date__to);
                }
            }
            catch { }

            loadleger();

           
        }

        private void search_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadleger();               
            }
        }

        private void searchCode_btn_Click(object sender, EventArgs e)
        {
            loadleger();            
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrintRecords_Click(object sender, EventArgs e)
        {
            //printledger(atype_tf.Text, search_tf.Text, accountcode_tf.Text);
            printGLaccount();
        }
        private void printGLaccount()
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            GLsystembalanceRpt myReport = new GLsystembalanceRpt();
            DataTable GL_table = new DataTable();            

            String qry =// " Set @dt:=0.00;Set @ct := 0.00; " +                        
                         "(Select concat(@acode,' - ',@aname) accountcode," +
                         "        concat('For the Period From ', " +
                         "                 DATE_FORMAT(@datefrom,'%e %b %Y'),' to '," +
                         "                 DATE_FORMAT(@dateto,'%e %b %Y') ) dateStmnt," +
                         "        @beginningbal as   beginningbal," +
                         "        if(@beginningbal>0,format(@beginningbal,2),'') debit," +
                         "        if(@beginningbal<0,format(-@beginningbal,2),'') credit," +
                         "        '' ref," +
                         "        DATE_FORMAT(@dateAsof,'%c/%e/%Y') date," +
                         "        '' jrnl," +
                         "        'Beginning Balance' transDesc," +
                         "        '' docno,  " +
                         "        if(@beginningbal>0,@beginningbal,0.00) as dtF,      " +
                         "        if(@beginningbal<0,-@beginningbal,0.00) as ctF )    " +                         
                         " union " +
                         "( Select  concat(@acode,' - ',@aname) accountcode," +
                         "          concat('For the Period From '," +
                         "                 DATE_FORMAT(@dateAsof,'%e %b %Y'),' to '," +
                         "                 DATE_FORMAT(current_date(),'%e %b %Y') ) dateStmnt," +
                         "          @beginningbal as   beginningbal," +
                         "          fnl.debit," +
                         "          fnl.credit," +
                         "          fnl.reference ref," +
                         "          DATE_FORMAT(fnl.datetmp,'%c/%e/%Y') date," +
                         "          '' jrnl," +
                         "          fnl.Description transDesc," +
                         "          fnl.docno,  " +
                         //"          @dt + if(@beginningbal>0,@beginningbal,0.00) as dtF,      " +
                         //"          @ct + if(@beginningbal<0,@beginningbal,0.00) as ctF     " +
                         "          ifnull(fnl.dt,0) as dtF," +
                         "          ifnull(fnl.ct,0) as ctF " +
                         "          " +
                         "from  (  " +                        
                         "(   Select concat(@acode,' - ',@aname) accountcode,   " +
                         "           f.*," +
                         "           2 ordr " +                        
                         "      from       " +
                         "      (       " +
                         "          (Select       " +
                         "              cvj.accountcode slcode,       " +
                         "              cv.cvdate datetmp,     " +
                         "              cv.cvnumber as docno,       " +
                         "              cv.refnumber as refno,       " +
                         "              cv.cvpcode as pcode,       " +
                         "              if(cvj.debit = 0,'',format(cvj.debit,2) ) as debit,       " +
                         "              if(cvj.credit = 0,'',format(cvj.credit,2) ) as credit,        " +
                         "              cvj.cvparticulars particular,       " +                         
                         "              ifnull(cvj.debit,0) as dt,       " +
                         "              ifnull(cvj.credit,0) as ct, " +
                         "              cv.paymentDesc as Description," +
                         "              concat(cv.bank,' ',cv.checknumber) as reference       " +
                         "          from cvjournal cvj       " +
                         "          left join checkvoucher cv on cv.cvnumber = cvj.cvnumber       " +
                         "          left join chart c1 on c1.accountcode = cvj.accountcode " +
                         "          where cv.cvnumber = cvj.cvnumber and cvj.accountcode = @acode and cv.cvdate between @datefrom and @dateto )       " + //DATE_FORMAT(date,'%Y-%m-%e')
                                                                                                                                   //"          where if(@atype = 'GL',cvj.glaccountcode,cvj.accountcode) = @acode and cvj.date between @datefrom and @dateto)       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              ad.accountcode slcode,       " +
                         "              a.apvdate datetmp,       " +
                         "              a.apvnumber as docno,       " +
                         "              a.docnumber as refno,       " +
                         "              a.pcode as pcode,       " +
                         "               if(ad.debit = 0,'',format(ad.debit,2) ) as debit,       " +
                         "              if(ad.credit = 0,'',format(ad.credit,2) ) as credit,        " +
                         "              ad.particulars particular, " +                         
                         "              ifnull(ad.debit,0) as dt,       " +
                         "              ifnull(ad.credit,0) as ct, " +
                         "              a.pDescription as Description," +
                         "              a.pcode as reference       " +
                         "          from apvdetails ad       " +
                         "          left join apvoucher a on a.apvnumber = ad.apvnumber       " +
                         "          left join chart c2 on c2.accountcode = ad.accountcode " +
                         "          where a.apvnumber = ad.apvnumber and ad.accountcode = @acode and a.apvdate between @datefrom and @dateto )       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              jd.accountcode slcode,       " +
                         "              j.jvdate datetmp,       " +
                         "              j.jvnumber as docno,       " +
                         "              '' as refno,       " +
                         "              '' as pcode,       " +
                         "              if(jd.debit = 0,'',format(jd.debit,2) ) as debit,       " +
                         "              if(jd.credit = 0,'',format(jd.credit,2) ) as credit,        " +
                         "              jd.particulars particular,       " +                        
                         "              ifnull(jd.debit,0) as dt,       " +
                         "              ifnull(jd.credit,0) as ct, " +
                         "              j.description as Description," +
                         "              if(ifnull(j.reference,'')='others',j.others,j.reference) as reference       " +
                         "          from jvdetails jd       " +
                         "          left join journalv j on j.jvnumber = jd.jvnumber       " +
                         "          left join chart c3 on c3.accountcode = jd.accountcode " +
                         "          where j.jvnumber = jd.jvnumber and jd.accountcode = @acode and DATE_FORMAT(j.jvdate,'%Y-%m-%d') between @datefrom and @dateto )       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              mt.accountcode slcode,       " +
                         "              m.mctdate datetmp,       " +
                         "              m.mctno as docno,       " +
                         "              m.refno as refno,       " +
                         "              m.requester as pcode,       " +
                         "              if(mt.debit = 0,'',format(mt.debit,2) ) as debit,       " +
                         "              if(mt.credit = 0,'',format(mt.credit,2) ) as credit,        " +
                         "              mt.particulars particular,       " +                         
                         "              ifnull(mt.debit,0) as dt,       " +
                         "              ifnull(mt.credit,0) as ct, " +
                         "              m.Description as Description," +
                         "              concat('Req. ',m.requester) as reference       " +
                         "          from mctdetails mt       " +
                         "          left join materialct m on m.mctno = mt.mctno       " +
                         "          left join chart c4 on c4.accountcode = mt.accountcode " +
                         "          where m.mctno = mt.mctno and mt.accountcode = @acode and DATE_FORMAT(m.mctdate,'%Y-%m-%d') between @datefrom and @dateto )       " +             
                         "          ) f  order by f.datetmp       )" +
                         ") fnl  where ifnull(fnl.docno,'') <> '' order by fnl.ordr,fnl.datetmp )";

            
            try
            {
                da = new MySqlDataAdapter(qry, conn_tmp);
                da.SelectCommand.Parameters.AddWithValue("@acode", accountcode_tf.Text);
                da.SelectCommand.Parameters.AddWithValue("@beginningbal",Double.Parse(balance_tf.Text.Replace(",","")));
                da.SelectCommand.Parameters.AddWithValue("@dateAsof",dateasof_dp.Value);
                da.SelectCommand.Parameters.AddWithValue("@aname",accountname_tf.Text);
                da.SelectCommand.Parameters.AddWithValue("@datefrom", date_from.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto", date_to.Value);

                //if (globalcutoff.isforward)
                //    da.SelectCommand.Parameters.AddWithValue("@idforwardedchart",int.Parse(globalcutoff.idforwardedchart));

                conn_tmp.Open();
                da.Fill(GL_table);
                da.Dispose();
                ds.Tables.Add(GL_table);
                ds.Tables[0].TableName = "glBalance";

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

        private void printledger(String codeType, String slCode, String code)
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            //ledgerRpt myReport = new ledgerRpt();
            DataTable ledger_T = new DataTable();
            DataTable chart_T = new DataTable();
            String qry = "  Select     " +
                         "     idchart,     " +
                         "     accountcode,     " +
                         "     accountname,     " +
                         "     accounttype,     " +
                         "     glAccountcode,     " +
                         "     glAccountname,     " +                        
                         "     BalAsOf,     " +
                         "     dateAsOf,     " +
                         "     category,     " +
                         "     0.00 debitF,     " +
                         "     0.00 creditF,     " +
                         "     0.00 totalBalance,     " +
                         "     Concat('Date Covered: ', DATE_FORMAT(@dateFrom,'%m/%e/%Y') , ' - ',  DATE_FORMAT(@dateTo,'%m/%e/%Y')) covered     " +
                         "    From chart     " +
                         "    where accountcode = @accountcode     ";

            String qryLdger =  " Set @dt:=0.00;Set @ct := 0.00;       " +
                         "   Select       " +
                         "          f.slcode,DATE_FORMAT(f.date,'%m/%e/%Y') date,f.docno,f.refno,f.pcode,       " +
                         "          f.debit as dtF,       " +
                         "          f.credit as ctF,       " +
                         //"          format(@dt,2) as dtF,       " +
                         //"          format(@ct,2) as ctF,       " +
                         "          f.particular    " +
                         "      from       " +
                         "      (       " +
                         "          (Select       " +
                         "              cvj.accountcode slcode,       " +
                         "              cvj.date,       " +
                         "              cv.cvnumber as docno,       " +
                         "              cv.refnumber as refno,       " +
                         "              cv.cvpcode as pcode,       " +
                         "              cvj.debit,       " +
                         "              cvj.credit,       " +
                         "              cvj.cvparticulars particular,       " +
                         "              @dt := @dt + ifnull(cvj.debit,0) as dt,       " +
                         "              @ct := @ct + ifnull(cvj.credit,0) as ct       " +
                         "          from cvjournal cvj       " +
                         "          left join checkvoucher cv on cv.idcheckvoucher = cvj.idcheckvoucher       " +
                         "          where if(@atype = 'GL',cvj.glaccountcode,cvj.accountcode) = @acode and cvj.date between @datefrom and @dateto)       " +
                         "          union       " +
                         "          (Select       " +
                         "              ad.accountcode slcode,       " +
                         "              ad.date,       " +
                         "              a.apvnumber as docno,       " +
                         "              a.docnumber as refno,       " +
                         "              a.pcode as pcode,       " +
                         "              ad.debit,       " +
                         "              ad.credit,       " +
                         "              ad.particulars particular,       " +
                         "              @dt := @dt+ ifnull(ad.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(ad.credit,0) as ct       " +
                         "          from apvdetails ad       " +
                         "          left join apvoucher a on a.idAPVoucher = ad.idapv       " +
                         "          where if(@atype = 'GL',ad.glaccountcode,ad.accountcode) = @acode and ad.date between @datefrom and @dateto)       " +
                         "          union       " +
                         "          (Select       " +
                         "              jd.accountcode slcode,       " +
                         "              jd.date,       " +
                         "              j.jvnumber as docno,       " +
                         "              '' as refno,       " +
                         "              '' as pcode,       " +
                         "              jd.debit,       " +
                         "              jd.credit,       " +
                         "              jd.particulars particular,       " +
                         "              @dt := @dt+ ifnull(jd.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(jd.credit,0) as ct       " +
                         "          from jvdetails jd       " +
                         "          left join journalv j on j.idjournal = jd.idjournalv       " +
                         "          where if(@atype = 'GL',jd.glaccountcode,jd.accountcode) = @acode and jd.date between @datefrom and @dateto)       " +
                         "          union       " +
                         "          (Select       " +
                         "              mt.accountcode slcode,       " +
                         "              mt.date,       " +
                         "              m.mctno as docno,       " +
                         "              m.refno as refno,       " +
                         "              m.requester as pcode,       " +
                         "              mt.debit,       " +
                         "              mt.credit,       " +
                         "              mt.particulars particular,       " +
                         "              @dt := @dt+ ifnull(mt.debit,0) as dt,       " +
                         "              @ct := @ct+ ifnull(mt.credit,0) as ct       " +
                         "          from mctdetails mt       " +
                         "          left join materialct m on m.idmaterialct = mt.idmct       " +
                         "          where if(@atype = 'GL',mt.glaccountcode,mt.accountcode) = @acode and mt.date between @datefrom and @dateto)       " +
                         "      ) f where f.slcode like @slcode OR f.pcode like @slcode order by f.date       ";
            
           

            try
            {
                da = new MySqlDataAdapter(qryLdger, conn_tmp);
                da.SelectCommand.Parameters.AddWithValue("@atype", codeType);
                da.SelectCommand.Parameters.AddWithValue("@slcode", "%" + slCode + "%");
                da.SelectCommand.Parameters.AddWithValue("@acode", code);
                //da.SelectCommand.Parameters.AddWithValue("@dateFrom", fr_date.Value);
                //da.SelectCommand.Parameters.AddWithValue("@dateTo", to_date.Value);

                conn_tmp.Open();
                da.Fill(ledger_T);
                da.Dispose();
                ds.Tables.Add(ledger_T);
                ds.Tables[0].TableName = "ledger";

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
                da = new MySqlDataAdapter(qry, conn_tmp);
                da.SelectCommand.Parameters.AddWithValue("@accountcode", code);
               // da.SelectCommand.Parameters.AddWithValue("@dateFrom", fr_date.Value);
               // da.SelectCommand.Parameters.AddWithValue("@dateTo", to_date.Value);

                conn_tmp.Open();
                da.Fill(chart_T);
                da.Dispose();
                ds.Tables.Add(chart_T);
                ds.Tables[1].TableName = "chart";

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
               // myReport.SetDataSource(ds);
               // frm.crystalRptViewer.ReportSource = myReport;
               // frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            unpaidapvFrm frm = new unpaidapvFrm();                   
            frm.accountcode_tf.Text = accountcode_tf.Text;
            frm.accountname_tf.Text = accountname_tf.Text;
            frm.ShowDialog();
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            loadleger();
        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
