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

namespace zaneco_Accounting_System
{
    public partial class unpostedmonthFrm : Form
    {
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private unitClass uc = new unitClass();
        private DataTable dt = new DataTable();

        //==============DoEvent Statement=========
        public delegate void DoEventLoadunpost(String mmyy);
        public event DoEventLoadunpost loadaccount;
        //========================================

        private postingAccountFrm Frm_postingAccount = new postingAccountFrm();
        
        public unpostedmonthFrm()
        {
            InitializeComponent();
        }

        private void refdetailDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void postingAccountFrmInitl(postingAccountFrm Frm_postingAccount_)
        {
            this.Frm_postingAccount = Frm_postingAccount_;
        }
        private void unpostedmonthFrm_Load(object sender, EventArgs e)
        {
            conn = db.getConn();
            loadunposted();
        }

        private void loadunposted()
        {            

            String qry = " Select       " +
                         "          f.slcode,       " +
                         "          sum(ifnull(f.dt,0)) as debit,       " +
                         "          sum(ifnull(f.ct,0)) as credit,       " +
                         "          sum(f.cnt) as Cnt, " +                         
                         "          f.pmonth       " +
                         "      from       " +
                         "      (       " +
                         "          (Select       " +
                         "              cvj.accountcode slcode,       " +
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
                         "          where cv.cvnumber = cvj.cvnumber and cv.posted = 0 and DATE_FORMAT(cv.cvdate, '%Y-%m-%d') between c1.dateAsof and current_date() )       " +                                                                                                                            //"          where if(@atype = 'GL',cvj.glaccountcode,cvj.accountcode) = @acode and cvj.date between @datefrom and @dateto)       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              ad.accountcode slcode,       " +
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
                         "          where a.apvnumber = ad.apvnumber and a.posted = 0 and DATE_FORMAT(a.apvdate, '%Y-%m-%d') between c2.dateAsof and current_date() )       " +
                         "          union       " +
                         "          (Select       " +
                         "              jd.accountcode slcode,       " +
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
                         "          where j.jvnumber = jd.jvnumber and j.isposted = 0 and DATE_FORMAT(j.jvdate, '%Y-%m-%d') between c3.dateAsof and current_date())" +//DATE_ADD(c3.dateAsof, INTERVAL 1 DAY) and current_date() )       " +                         
                         "          union       " +
                         "          (Select       " +
                         "              mt.accountcode slcode,       " +
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
                         "          where m.mctno = mt.mctno and m.posted = 0 and DATE_FORMAT(m.mctdate, '%Y-%m-%d') between c4.dateAsof and current_date())       " +
                         "      ) f  group by f.pmonth     ";

            try
            {
                conn.Open();
                da = new MySqlDataAdapter(qry, conn);
                

                da.Fill(ds, "unposted");
                tbl_datagrid.AutoGenerateColumns = false;
                tbl_datagrid.DataSource = ds.Tables["unposted"];

                da.Dispose();
                conn.Close();
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = tbl_datagrid.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = tbl_datagrid.Rows[selectedrowindex];

            try
            {
                loadaccount(sRow.Cells[0].Value.ToString());
                Close();
            }
            catch
            { }                                  
            
        }
    }
}
