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


namespace zaneco_Accounting_System
{
    public partial class selectrefFrm : Form
    {
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private MySqlDataReader dr_sf;
        private MySqlCommand cmd_sf = new MySqlCommand();
        private MySqlDataAdapter da;        

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private connectionDB_budget db_bget = new connectionDB_budget();
        private MySqlConnection conn_bget = new MySqlConnection();
        private MySqlConnection conn_budgettmp = new MySqlConnection();

        private unitClass uc = new unitClass();
        private checkvoucherFrm frm_checkVoucher;
        

        //==Global Event Variables===========================
        // public delegate void DoEventRef(String refno);
        // public event DoEventRef refdeteails_;
        //==================================================

        private String refnoTmp = "";
        public selectrefFrm()
        {
            InitializeComponent();
        }
        
         public void frmcheckVoucherInitl(checkvoucherFrm frm_checkVoucher1)
        {
            frm_checkVoucher = frm_checkVoucher1;
        }

        public void setRefno(String refno)
        {
            this.refnoTmp = refno;
        }

        private void closeProc_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectrefFrm_Load(object sender, EventArgs e)
        {
            rvproFrom.Value = uc.StartOfMonth;
            rvproTo.Value = uc.EndOfMonth;
            apvFrom_dp.Value = uc.StartOfMonth;
            apvTo_dp.Value = uc.EndOfMonth;

            conn_bget = db_bget.getConn();
            conn_budgettmp = db_bget.getConn();
            conn_tmp = db_tmp.getConn();

            conn = db.getConn();

            this.journalTableAdapter.Connection.ConnectionString = db_bget.getConnString();            
            //this.chartacamTableAdapter.Connection.ConnectionString = db.getConnString();
            
            loadapv();
            loadallocatedRvPo();
            searchrvpo_tf.Focus();
            this.ActiveControl = searchrvpo_tf;
            
        }

        
       
        private void search_tf_TextChanged(object sender, EventArgs e)
        {
           // this.ActiveControl = search_tf;
           // loadjournal();
            
        }

        private void search_tf_KeyDown(object sender, KeyEventArgs e)
        {
          //  if (e.KeyCode == Keys.Enter)
          //      this.ActiveControl = journalbud_dgrid;
        }

        private void selectProc_btn_Click(object sender, EventArgs e)
        {
          //  selectrefNo();
          //  Close();
        }

        private void addCVdebit(String amountRV,String Accountname)
        {
            frm_checkVoucher.tb_dbGrid.Rows.Clear();
            frm_checkVoucher.tb_dbGrid.Rows.Add("",
                                                "...",
                                                "",// Accountname,//dr.GetString("accountname"),
                                                amountRV,//dr.GetDouble("credit").ToString("N02", ci),
                                                "0.00",
                                                "",
                                                "",
                                                "0",//getisSF(dr.GetString("accountcode")),
                                                "",//dr.GetString("glaccountcode"),
                                                "",//.GetString("glaccountname"),
                                                "...",
                                                "",
                                                "RV Debit");
        }
        private void selectrefNo()
        {
            //Double rvamount = 0.00;
            int selectedrowindex = rvpoDatagridView.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = rvpoDatagridView.Rows[selectedrowindex];

            frm_checkVoucher.setdoctype("RV");
            frm_checkVoucher.refno_tf.Text = sRow.Cells[5].Value.ToString();
            //frm_checkVoucher.cvamount_tf.Text = sRow.Cells[6].Value.ToString();
            frm_checkVoucher.pcode_tf.Text = sRow.Cells[10].Value.ToString();
            frm_checkVoucher.pname_tf.Text = sRow.Cells[11].Value.ToString();
            frm_checkVoucher.paydesc_tf.Text = sRow.Cells[12].Value.ToString();            
            //frm_checkVoucher.amountWords_tf.Text = uc.ToWords(Double.Parse(sRow.Cells[6].Value.ToString().Replace(",", "")));
            frm_checkVoucher.Refamount_tf.Text = sRow.Cells[14].Value.ToString().Replace(",", "");
            addCVdebit(sRow.Cells[14].Value.ToString(), sRow.Cells[13].Value.ToString());
            refnoTmp =  sRow.Cells[5].Value.ToString();
            //==========================================================
            //==========================================================
            String qry = "Select * from payee where pcode = '" + sRow.Cells[8].Value.ToString() + "'";
            try
            {          
                cmd = new MySqlCommand(qry, conn_tmp);
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                   frm_checkVoucher.paddress_tf.Text = dr["Address"].ToString();

                dr.Close();               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn_tmp.Close();
            }


           // try
           // {
           //     this.refdeteails_(refnoTmp);
            //}
           // catch
           // { }
        }

        private void selectRefnoApv()
        {
            
            int selectedrowindex = apvGridView.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = apvGridView.Rows[selectedrowindex];

            Double unpaidAmnt = Double.Parse(sRow.Cells[3].Value.ToString().Replace(",", "")) - Double.Parse(sRow.Cells[4].Value.ToString().Replace(",", ""));

            frm_checkVoucher.setdoctype("APV");
            frm_checkVoucher.refno_tf.Text = sRow.Cells[0].Value.ToString();            
            frm_checkVoucher.pcode_tf.Text = sRow.Cells[1].Value.ToString();
            frm_checkVoucher.pname_tf.Text = sRow.Cells[6].Value.ToString();
            frm_checkVoucher.paddress_tf.Text = sRow.Cells[7].Value.ToString();
            frm_checkVoucher.paydesc_tf.Text = sRow.Cells[8].Value.ToString();
            frm_checkVoucher.Refamount_tf.Text = sRow.Cells[9].Value.ToString().Replace(",", "");
            refnoTmp = sRow.Cells[0].Value.ToString();

            selectapvdetails(sRow.Cells[0].Value.ToString(), sRow.Cells[9].Value.ToString());
        }


        //===========get SF source==================================
        private String getisSF(String code)
        {
            String isCF = "0";
            String qry = "Select isCF,glAccountcode,glaccountname from chart where accountcode = '" + code + "'";
            cmd_sf = new MySqlCommand(qry, conn);

            try
            {
                conn.Open();
                dr_sf = cmd_sf.ExecuteReader();

                if (dr.Read())
                {
                    isCF = dr_sf.GetString("isCF");                   
                }

                dr_sf.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr_sf.Close();
                conn.Close();
            }

            return isCF;
        }
        //==============================================
        //==============================================

        private void selectapvdetails(String apvno,String balance_)
        {
            CultureInfo ci = new CultureInfo("en-us");
            String qry = "SELECT * FROM apvdetails where apvnumber = @apvno and credit>0";
            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@apvno", apvno);

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                frm_checkVoucher.tb_dbGrid.Rows.Clear();

                if (dr.Read())
                {                   
                    frm_checkVoucher.tb_dbGrid.Rows.Add(dr.GetString("accountcode"),
                                                         "...",
                                                        dr.GetString("accountname"),
                                                        balance_,//dr.GetDouble("credit").ToString("N02", ci),
                                                        "0.00",
                                                        "",
                                                        "",
                                                        getisSF(dr.GetString("accountcode")),
                                                        dr.GetString("glaccountcode"),
                                                        dr.GetString("glaccountname"),
                                                        "...",
                                                        "",
                                                        "APV Debit");

                   
                }

              
                dr.Close();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);                
                conn_tmp.Close();
            }
        }

        private void journalbud_dgrid_KeyDown(object sender, KeyEventArgs e)
        {
           
               
        }

        private void rvposelect_btn_Click(object sender, EventArgs e)
        {
            selectrefNo();
            selectrefDetail(refnoTmp);
            //frm_checkVoucher.refdeteails(refno_);
           

            Close();
        }

        private void selectrefDetail(String refno)
        {
            CultureInfo ci = new CultureInfo("en-us");//("N02", ci           
            String qry = "        set @code_ = '';    " +
                         "        set @name_ = '';    " +
                         "        set @glcode = '';    " +
                         "        set @glname = '';    " +
                         "        set @job_ = '';       " +
                         "        set @jobname_ = '';   " +                         
                         "        (Select     " +
                         "           ifnull(rd.rddescription,'') as description,     " +
                         "           ifnull(rd.rdqty,0) as qty,     " +
                         "           ifnull(rd.rdunit,'') as unit,     " +
                         "           ifnull(rd.rdcost,'') as cost,     " +
                         "           format((ifnull(rd.rdqty, 0) * ifnull(rd.rdcost, 0)), 2) as amount,    " +
                         "           '' accountcode,    " +
                         "           '' accountname,    " +
                         "           '' glaccountcode,    " +
                         "           '' glaccountname," +
                         "           '' job," +
                         "           '' jobname    " +
                         "           from requisition r     " +
                         "           right join zanecobudget.requisitiondetail rd on rd.idrequisition = r.idrequisition     " +
                         "       where r.rvnumber = @docno )     " +
                         "       union     " +
                         "      ( Select    " +
                         "          ifnull(pd.desc,'') as description,     " +
                         "          ifnull(pd.qty,0) as qty,     " +
                         "          ifnull(pd.unit,0) as unit,    " +
                         "          ifnull(pd.cost,0) as cost,     " +
                         "          format((ifnull(pd.qty, 0) * ifnull(pd.cost, 0)), 2) as amount ,    " +
                         "          '' accountcode,    " +
                         "          '' accountname,    " +
                         "          '' glaccountcode,    " +
                         "          '' glaccountname," +
                         "          '' job," +
                         "          '' jobname    " +
                         "          from po p     " +
                         "          right join podetail pd on pd.idpo = p.idpo     " +
                         "      where p.ponumber = @docno )     " +
                         "      union    " +
                         "       (Select    " +
                         "          f.description,    " +
                         "          f.qty,    " +
                         "          f.unit,    " +
                         "          f.cost,    " +
                         "          f.amount,    " +
                         "          @code_ as accountcode,    " +
                         "          @name_ as accountname,    " +
                         "          @glcode as glaccountcode,    " +
                         "          @glname as glaccountname," +
                         "          @job_ as job," +
                         "          @jobname_ as jobname    " +
                         "        from    " +
                         "         ( (    " +
                         "         Select    " +
                         "           0 flag,     " +
                         "           ifnull(ad.particulars,'') as description,     " +
                         "           ifnull(ad.qty,0) as qty,    " +
                         "           ifnull(ad.unit,'') as unit,    " +
                         "           ifnull(ad.cost,0) as cost,    " +
                         "           format((ifnull(ad.qty, 0) * ifnull(ad.cost, 0)), 2) as amount ,    " +
                         "           '' glcode,    " +
                         "           '' glname," +
                         "           @job_ := ifnull(ad.jobid,'') as job," +
                         "           @jobname_ := ifnull(ad.jobname,'') as jobname    " +
                         "          from zanecoaccounting.apvoucher a     " +
                         "          right join zanecoaccounting.apvdetails ad on ad.idapv = a.idapvoucher and ad.debit > 0      " +
                         "          where a.apvnumber =  @docno  )      " +
                         "          union    " +
                         "          ( Select    " +
                         "           1 flag,     " +
                         "           @code_ := ifnull(ad.accountcode,'') as description,     " +
                         "           ifnull(ad.qty,0) as qty,    " +
                         "           @name_ := ifnull(ad.accountname,'') as unit,    " +
                         "           ifnull(ad.cost,0) as cost,    " +
                         "           format((ifnull(ad.qty, 0) * ifnull(ad.cost, 0)), 2) as amount,    " +
                         "           @glcode := ifnull(ad.glaccountcode,'') as glcode,    " +
                         "           @glname := ifnull(ad.glaccountname,'') as glname," +
                         "           '' job," +
                         "           '' jobname    " +
                         "          from zanecoaccounting.apvoucher a      " +
                         "          right join zanecoaccounting.apvdetails ad on ad.idapv = a.idapvoucher and ad.credit > 0     " +
                         "          where a.apvnumber =   @docno    " +
                         "          limit 1    " +
                         "          ) ) f where flag = 0    " +
                         "      )    ";
                        

            //int selectedrowindex = rvpoDatagridView.SelectedCells[0].RowIndex;
            //DataGridViewRow sRow = rvpoDatagridView.Rows[selectedrowindex];                    
           
            cmd = new MySqlCommand(qry, conn_bget);
            cmd.Parameters.AddWithValue("@docno", refno);

            frm_checkVoucher.refdetailDatagrid.Rows.Clear();
            //=====================================================
            //=====================================================          
            //try
            //{
                conn_bget.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    frm_checkVoucher.refdetailDatagrid.Rows.Add(dr.GetString("qty"),
                                                                dr.GetString("description"),
                                                                dr.GetString("unit"),
                                                                dr.GetDouble("cost").ToString("N02", ci),
                                                                dr.GetString("amount"),
                                                                dr.GetString("accountcode"),
                                                                dr.GetString("accountname"),
                                                                dr.GetString("glaccountcode"),
                                                                dr.GetString("glaccountname"),
                                                                dr.GetString("job"),
                                                                dr.GetString("jobname"));
                   
                }
           // }
           // catch
           // { }
        }

        private void loadallocatedRvPo()
        {
            /* String qry = " Select  " +
                          "  ja.*  " +
                          " from  " +
                          "  (  " +
                          "   Select  " +
                          "    IFNULL(a.docnumber, IFNULL(c.refnumber, NULL)) docno,  " +
                          "    IF(a.docnumber is not NULL, 'APV', IF(c.refnumber is not NULL, 'CV', '')) doc,  " +
                          "    fnl.*  " +
                          "   from  " +
                          "   (  " +
                          "   Select  " +
                          "    f.*,  " +
                          "    if (doctype = 'RV',r.idrequisition,p.idpo) identry,  " +
                          "    r.rvdate,  " +
                          "    r.rvpcode pcode_,  " +
                          "    r.rvname pname_,  " +
                          "    r.rvdescription  " +
                          "   from  " +
                          "   (  " +
                          "    SELECT  " +
                          "     j.documentdate approveddate,  " +
                          "     if (j.documenttype = 'RV','RV','PO') doctype,  " +
                          "     if (j.documenttype = 'RV',j.documentnumber,j.documenttype) rvnumber,  " +
                          "     j.documentnumber,  " +
                          "     format(j.credit,2) amountApprove  " +
                          "    FROM zanecobudget.journal j  " +
                          "      where j.documentdate between @from  and @to  " +
                          "      group by j.documentnumber  " +
                          "      order by j.idjournal desc  " +
                          "    ) f  " +
                          "   left join requisition r on r.rvnumber = f.rvnumber  " +
                          "   left join po p on p.ponumber = f.documentnumber  " +
                          "  ) fnl  " +
                          "  left join zanecoaccounting.checkvoucher c on c.refnumber = fnl.documentnumber  " +
                          "  left join zanecoaccounting.apvoucher a on a.docnumber = fnl.documentnumber  " +
                          " ) ja where ja.docno is null AND ja.documentnumber like @refno or ja.docno is null and ja.pcode_ like  @refno ";
              */
            /*
                         String qry = " Select fnl.*, " +
                                      "  format(fnl.amountpaid,2)  as amountpaidF," +
                                      "  format(fnl.amountApprove,2) as amountApproveF," +
                                      "  fnl.amountApprove - fnl.amountpaid  bal_    " +
                                      "  from           " +
                                      "  (Select           " +
                                      "     f.*,           " +
                                      "     r.idrequisition identry,           " +
                                      "     r.rvdate,           " +
                                      "     r.rvpcode pcode_,           " +
                                      "     r.rvname pname_,           " +
                                      "     r.rvdescription,           " +
                                      "     sum(IFNULL(c.total, 0)) as amountpaid           " +
                                      "    from           " +
                                      "    (           " +
                                      "     SELECT           " +
                                      "      j.documentdate approveddate,           " +
                                      "      'RV' doctype,           " +
                                      "      j.documentnumber rvnumber,           " +
                                      "      j.documentnumber,           " +
                                      "      j.accountname,           " +
                                      "      ifnull(j.credit,0) amountApprove           " +
                                      "     FROM zanecobudget.journal j           " +
                                      "        where j.documentdate between @from  and @to  and documenttype = 'RV'           " +
                                      "        group by j.documentnumber           " +
                                      "        order by j.idjournal desc           " +
                                      "      ) f           " +
                                      "     left join zanecobudget.requisition r on r.rvnumber = f.rvnumber           " +
                                      "     left join zanecoaccounting.checkvoucher c on c.refnumber = f.rvnumber and c.cvpcode <> 'CANCELED' and" +
                                      "                                                  c.cvnumber <> @cvno_          " +
                                      "     group by f.rvnumber           " +
                                      "     ) fnl where fnl.amountpaid < fnl.amountApprove and           " +
                                      "                  fnl.rvnumber like @refno or " +
                                      "                  fnl.amountpaid < fnl.amountApprove and fnl.pcode_ like  @refno           ";*/

            String qry_cutoff = "SELECT DATE_SUB(Cutoffdate, INTERVAL 1 YEAR) as Cutoffdate FROM zanecobudget.chart order by Cutoffdate desc limit 1;";
            String year = DateTime.Now.AddYears(-1).ToString("yyyy");        
            cmd = new MySqlCommand(qry_cutoff, conn_tmp);
            //cmd.Parameters.AddWithValue("@apvno", apvno);

             try
             {
                 conn_tmp.Open();
                 dr = cmd.ExecuteReader();                 

                 if (dr.Read())
                 {
                    //dr.GetDateTime("voiddate");
                    //dr.GetString("accountname")                   
                    year = dr.GetDateTime("Cutoffdate").ToString("yyyy");
                 }

                 dr.Close();
                 conn_tmp.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                 conn_tmp.Close();
             }

            //=====================================
            //=====================================
            //=====================================           
            String qry = " Select fnl.*, " +
                          "  format(fnl.amountpaid,2)  as amountpaidF," +
                          "  format(fnl.amountApprove,2) as amountApproveF," +
                          "  fnl.amountApprove - fnl.amountpaid  bal_    " +
                          "  from           " +
                          "  (Select           " +
                          "     f.*,           " +
                          "     r.idrequisition identry,           " +
                          "     r.rvdate,           " +
                          "     r.rvpcode pcode_,           " +
                          "     r.rvname pname_,           " +
                          "     r.rvdescription,           " +
                          "     sum(IFNULL(c.total, 0)) as amountpaid," +
                          "     a.docnumber docno           " +
                          "    from           " +
                          "    ( (          " +
                          "       SELECT           " +
                          "         j.documentdate approveddate,           " +
                          "         'RV' doctype,           " +
                          "         if(j.documenttype = 'RV',j.documentnumber,j.documenttype) rvnumber,           " +
                          "         j.documentnumber,           " +
                          "         j.accountname,           " +
                          "         ifnull(j.credit,0) amountApprove           " +
                          "       FROM zanecobudget.journal j           " +
                          "        where j.documentdate between @from  and @to " +
                          "        group by j.documentnumber           " +
                          "        order by j.idjournal desc        " +
                          "       ) union " +
                          "      (SELECT" +
                          "        rq.rvdate approveddate,           " +
                          "        'RV' doctype,           " +
                          "        rq.rvnumber rvnumber,           " +
                          "        rq.rvnumber documentnumber,           " +
                          "        '' accountname,           " +
                          "        sum(ifnull(rqd.rdamount,0)) amountApprove        " +
                          "        FROM zanecobudget.requisition rq  " +
                          "        left join zanecobudget.requisitiondetail rqd on rqd.idrequisition = rq.idrequisition         " +
                          "        where rq.rvdate between @from  and @to " +
                          "             and date_format( rq.rvdate,'%Y') =" + year +
                          "             and rq.status = 'APPROVED' " +
                          "             and not exists (Select journal.documentdate from journal where journal.documentnumber = rq.rvnumber)" +
                          "         group by rq.rvnumber " +
                          "        )   " +
                          "    ) f  " +
                          "     left join zanecobudget.requisition r on r.rvnumber = f.rvnumber  " +
                          "     left join zanecoaccounting.checkvoucher c on c.refnumber = f.documentnumber and c.cvpcode <> 'CANCELED' " +
                          "     left join zanecoaccounting.apvoucher a on a.docnumber = f.documentnumber" +                          
                          "     group by f.rvnumber           " +
                          "     ) fnl "+
                          "     where fnl.rvnumber like @refno or " +
                          "           fnl.pcode_ like  @refno           ";
                          
            ds = new DataSet();

            try
            {
                conn_budgettmp.Open();                
                da = new MySqlDataAdapter(qry, conn_budgettmp);
                
                da.SelectCommand.Parameters.AddWithValue("@from", rvproFrom.Value);
                da.SelectCommand.Parameters.AddWithValue("@to",rvproTo.Value);
                da.SelectCommand.Parameters.AddWithValue("@refno", "%"+searchrvpo_tf.Text+"%");
                //da.SelectCommand.Parameters.AddWithValue("@cvno_",frm_checkVoucher.cvNo_lb.Text);
                da.Fill(ds,"allocatedproc");
                rvpoDatagridView.AutoGenerateColumns = false;
                rvpoDatagridView.DataSource = ds.Tables["allocatedproc"];

                da.Dispose();
                conn_budgettmp.Close();
            }
            catch(Exception ex)
            {                
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_budgettmp.Close();                
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadallocatedRvPo();
        }

        private void searchrvpo_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = rvpoDatagridView;
        }

        private void rvpoDatagridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectrefNo();
                Close();
            }
        }

        private void searchrvpo_tf_TextChanged(object sender, EventArgs e)
        {
            loadallocatedRvPo();
        }

        private void apvload_btn_Click(object sender, EventArgs e)
        {
            loadapv();
        }
        private void loadapv()
        {
            String qry = " Select f.*," +
                         "   f.amount - f.amountpaidF as bal_ " +
                         " from" +
                         " ( SELECT " +
                         "      a.*, " +
                         "      if (a.posted = 1,'YES','NO') postedF, " +
                         "      sum(IFNULL(c.total,0)) as amountpaidF " +
                         "    FROM apvoucher a " +
                         "    left join checkvoucher c on c.refnumber = a.apvnumber and c.cvpcode <>'CANCELED' " +
                         "    where a.apvnumber like @apvno and " +
                         "        a.apvdate between @datefrom and @dateto or " +
                         "        a.pcode like @pcode and " +
                         "        a.apvdate between @datefrom and @dateto group by a.apvnumber) f"+
                         "  Where f.amountpaidF < f.amount ";

            
             ds = new DataSet();
            
            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry,conn_tmp);

                da.SelectCommand.Parameters.AddWithValue("@apvno","%"+ apvSearch_tf.Text + "%");
                da.SelectCommand.Parameters.AddWithValue("@pcode", "%" + apvSearch_tf.Text + "%");
                da.SelectCommand.Parameters.AddWithValue("@datefrom",apvFrom_dp.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto",apvTo_dp.Value);

                da.Fill(ds, "apv");
                apvGridView.AutoGenerateColumns = false;
                apvGridView.DataSource = ds.Tables["apv"];

                da.Dispose();
                conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            } 
             
        }

        private void apvSearch_tf_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void apvSearch_tf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadapv();
            }
        }

        private void apvSelect_btn_Click(object sender, EventArgs e)
        {
            selectRefnoApv();
            selectrefDetail(refnoTmp);
            Close();
        }

        private void rvpoclose_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void apvClose_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
