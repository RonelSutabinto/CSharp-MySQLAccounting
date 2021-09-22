using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;
using zaneco_Accounting_System.Reports;
using zaneco_Accounting_System.Reports.checkvoucher;
using zaneco_Accounting_System.module;

namespace zaneco_Accounting_System
{
    public partial class checkvoucherFrm : Form
    {
        //private connDBtmp db_tmp = new connDBtmp();
        //private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr ;
        private DataTable dt = new DataTable();
        private MySqlDataAdapter da;

        public DataGridViewRow sRow;
        private unitClass uc = new unitClass();
        private String idcv = "0";

        private cvJournal frm_cvjournal = new cvJournal();
        private static String id_tmp;
        private static Double cvAmount = 0.00;
        private static Double cancel_cvAmnt = 0.00;
        private static String doctype_ = "";

        private DateTime dateF = DateTime.Now;
        private DateTime dateT = DateTime.Now;
        private String filter_tf = "";
        private String userid = "";


        private DataSet ds = new DataSet();
        private Boolean isErrUpdate = false;        

        //==Global Event Variables===========================
        public delegate void DoEvent(string dateFR, string dateTo, string filterTF);
        public event DoEvent RefreshDgv;
        //==================================================
                
        //private connectionDB_budget db_bget = new connectionDB_budget();
        //private MySqlConnection conn_bget = new MySqlConnection();
        
        private ContextMenuStrip menu_tb = new ContextMenuStrip();
        private unpaidapvFrm frm_unpaidapv = new unpaidapvFrm();

        public checkvoucherFrm()
        {
            InitializeComponent();         
        }

        public void unpaidapvInitl(unpaidapvFrm frm_unpaidapv1)
        {
            this.frm_unpaidapv = frm_unpaidapv1;
        }

        public void setUserid(String uid)
        {
            this.userid = uid;
        }

        public void setdateF(DateTime dtF)
        {
            this.dateF = dtF;
        }
        public void setdateT(DateTime dtT)
        {
            this.dateT = dtT;
        }
        public void setfilter(String filtf)
        {
            this.filter_tf = filtf;
        }

        public void setcvNum(String id)
        {
            id_tmp = id;
        }
        public void setdoctype(String doctmp)
        {
            doctype_ = doctmp;
        }
        public void frmcvJournalInitl(cvJournal frm_cvjournal1)
        {
            frm_cvjournal = frm_cvjournal1;
        }
       

       
        private Double getAPVamount(String apv_no)
        {
            Double amnt = 0.00;
           
            String qry = "Select * from apvoucher where apvnumber = '" + apv_no + "'";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                       
            try
            {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    amnt = dr.GetDouble("amount");           
                }

                dr.Close();
                //conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                dr.Close();
                //conn_tmp.Close();
            }

            return amnt;
        }

        private Double getAPVbalance(String apvno, String docno)
        {
            String qry = "  Select f.*, " +
                         "      f.amount - f.amountpaidF as bal_ " +
                         "     from " +
                         "   (SELECT " +
                         "      a.*, " +
                         "      if (a.posted = 1,'YES','NO') postedF, " +
                         "      sum(if(c.cvnumber <> @docno,IFNULL(c.total, 0),0.00)) as amountpaidF " +
                         "      FROM apvoucher a " +
                         "      left join checkvoucher c on c.refnumber = a.apvnumber and c.cvpcode <> 'CANCELED' " +
                         "     where a.apvnumber like @apvno ) f ";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            Double bal = 0.0;
            try
            {
                //conn_tmp.Open();
                cmd.Parameters.AddWithValue("@apvno", apvno);
                cmd.Parameters.AddWithValue("@docno", docno);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    bal = dr.GetDouble("bal_");
                }

                dr.Close();
                //conn_tmp.Close();
            }
            catch
            {
                //conn_tmp.Close();
            }

            return bal;
        }

        private Double getRVbalance(String rvno , String docno)
        {
            String qry = " Select fnl.*, " +                       
                        "  fnl.amountApprove - fnl.amountpaid  bal_    " +
                        "  from           " +
                        "  (Select           " +
                        "     f.*,           " +                                              
                        "     sum(if(c.cvnumber <> @docno,IFNULL(c.total, 0),0.00)) as amountpaid           " +
                        "    from           " +
                        "    (           " +
                        "     SELECT           " +                       
                        "      j.documentnumber rvnumber,           " +                      
                        "      ifnull(j.credit,0) amountApprove           " +
                        "     FROM zanecobudget.journal j           " +
                        "        where j.documentnumber = @rvno           " +                       
                        "      ) f           " +                       
                        "     left join zanecoaccounting.checkvoucher c on c.refnumber = f.rvnumber and c.cvpcode <> 'CANCELED'           " +                       
                        "     ) fnl ";

            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            Double bal = 0.0;
            try
            {
                //conn_tmp.Open();
                cmd.Parameters.AddWithValue("@rvno",rvno);
                cmd.Parameters.AddWithValue("@docno", docno);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    bal = dr.GetDouble("bal_");
                }

                dr.Close();
                //conn_tmp.Close();
            }
            catch
            {               
                //conn_tmp.Close();
            }
            
            return bal;
        }

        private void checkvoucherFrm_Load(object sender, EventArgs e)
        {
            //conn_tmp = db_tmp.getConn();
            //conn_bget = db_bget.getConn();
            doctype_ = "RV";

            if (this.Text == "Add Check Voucher (Payment)")
            {
                cvcounter();
                print_btn.Enabled = false;
                printCheck_btn.Enabled = true;
                cvdate_dp.Value = DateTime.Now;                               
            }
            else if (this.Text == "Update Check Voucher (Payment)")
            {                
                loadcvjournal(id_tmp);
                loadFilteredCV(id_tmp);
               
                if (refno_tf.Text.Substring(0, 3) == "APV" )               
                    Refamount_tf.Text = getAPVbalance(refno_tf.Text,cvNo_lb.Text).ToString();
                else
                    Refamount_tf.Text = getRVbalance(refno_tf.Text, cvNo_lb.Text).ToString();
               
                if (refno_tf.Text.Substring(0, 3) == "APV")
                    doctype_ = "APV";

                loadcvvoiddate(cvNo_lb.Text);

                if(globalmainFrm.userlog.Equals(userid))
                    printCheck_btn.Enabled = true;

                cvNo_lb.ReadOnly = true;
            }

            else if (this.Text == "Preview Check Voucher (Payment)")
            {
                loadcvjournal(id_tmp);
                loadFilteredCV(id_tmp);

                tb_dbGrid.ReadOnly = true;
                ref_btn.Enabled = false;
                payee_btn.Enabled = false;
                delete_btn.Enabled = false;
                save_btn.Enabled = false;
                cvdate_dp.Enabled = false;
                checkno_tf.Enabled = false;
                refno_tf.Enabled = false;
                paydesc_tf.Enabled = false;
                cvNo_lb.ReadOnly = true;

                loadcvvoiddate(cvNo_lb.Text);

                //if (globalmainFrm.userlog.Equals(userid))
                //    printCheck_btn.Enabled = true;
                printCheck_btn.Enabled = true;
            }

            sumDC();
            refdeteails(refno_tf.Text);
            
        }

        void refdeteails(String refno_)
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


            cmd = new MySqlCommand(qry, globalmainFrm.getConn_budget());
            cmd.Parameters.AddWithValue("@docno", refno_);

           
            //=====================================================
            //=====================================================          
            try
            {       
                //conn_bget.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    refdetailDatagrid.Rows.Add(dr.GetString("qty"),
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
            }
            catch
            { }
        }

        private void loadcvjournal(String id)
        {
            String qry = "Select cvjournal.*,ifnull(jobid,'') jobid_,ifnull(jobname,'') jobname_ from cvjournal where idcheckvoucher = '" + id + "' OR cvnumber = '" + id + "'";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            String GLFund = "";
            String btnJob = "...";

            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");

            try
            {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    if (dr.GetString("descSF").Equals("Source Of Fund"))
                        GLFund = dr.GetString("glaccountname");
                    else
                        GLFund = "";

                    if(dr.GetString("jobid_").Length>1)
                    {
                        btnJob = "X";
                    }
                    else
                    {
                        btnJob = "...";
                    }

                    tb_dbGrid.Rows.Add(dr.GetString("accountcode"),
                                       "...",
                                       dr.GetString("cvparticulars"),
                                       dr.GetDouble("debit").ToString("N02", ci),
                                       dr.GetDouble("credit").ToString("N02", ci), 
                                       dr.GetString("cvnumber"),
                                       dr.GetString("idcvJournal"),
                                       dr.GetBoolean("isSF"),
                                       dr.GetString("glaccountcode"),
                                       dr.GetString("glaccountname"),
                                       "...",
                                       GLFund,
                                       dr.GetString("descSF"),
                                       "",
                                       btnJob,
                                       dr.GetString("jobid_"),
                                       dr.GetString("jobname_"));
                   
                }

                this.ActiveControl = tb_dbGrid;
                dr.Close();
                //conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                //conn_tmp.Close();
            }
        }
        private void loadFilteredCV(String id)
        {
            CultureInfo ci = new CultureInfo("en-us");
            String ref_no = "";
            int cvnoCnt = 0;
            int bankCntchr = 0;
            String qry = "Select * from checkvoucher where idcheckvoucher = '" + id + "'";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());            

            try
            {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();
                
                if(dr.Read())
                {
                    cvnoCnt = dr.GetString("checknumber").Length; 
                    ref_no = dr.GetString("refnumber");
                    bankCntchr = dr.GetString("bank").Length;

                    cvNo_lb.Text = dr.GetString("cvnumber");
                    refno_tf.Text = ref_no;
                    pname_tf.Text = dr.GetString("cvpname");
                    pcode_tf.Text = dr.GetString("cvpcode");
                    paddress_tf.Text = dr.GetString("cvpaddress");
                    paydesc_tf.Text = dr.GetString("paymentDesc");
                    checkno_tf.Text = dr.GetString("checknumber").Substring(bankCntchr + 1, cvnoCnt - (bankCntchr + 1));
                    checkDate_dp.Value = dr.GetDateTime("voiddate");
                    cvamount_tf.Text = dr.GetDouble("cvamount").ToString("N02", ci);
                    bank_cb.SelectedIndex = bank_cb.FindStringExact(dr.GetString("bank"));                   
                    amountWords_tf.Text = uc.ToWords(dr.GetDouble("cvamount"));
                    cvdate_dp.Value = dr.GetDateTime("cvdate");
                    cvAmount = dr.GetDouble("cvamount");        
                    Refamount_tf.Text = dr.GetString("total");
                    idcv_tf.Text = dr.GetString("idcheckvoucher");

                    if (dr.GetString("forliquidation").Equals("1"))
                        isliquidated_cb.Checked = true;
                    else
                        isliquidated_cb.Checked = false;
                }

                dr.Close();
                //conn_tmp.Close();

                Refamount_tf.Text = getAPVamount(ref_no).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                //conn_tmp.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
           
        //select check voucher ID=====================================
        private String getcvID(String cvno)
        {
            String id = "0";

            
             string sql = "SELECT * FROM checkvoucher where cvnumber = '"+cvno+"'";
             cmd = new MySqlCommand(sql, globalmainFrm.getConn_accnt());

             //OPEN CON
             try
              {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    id = dr.GetString("idcheckvoucher");
                }

                dr.Close();
                //conn_tmp.Close();                
                
             }
             catch (Exception ex)
             {

                MessageBox.Show(ex.Message);
                dr.Close();
                //conn_tmp.Close();               
             }

             
            return id; 
        }

        private String getTotalCV(String total_lb)
        {            
            string[] totallb_ = total_lb.Split(' ');           

            return totallb_[1].Replace(",", "");
        }
        //INSERT INTO check voucher===================================
        private void addcv(Boolean isSave)
        {            
           //SQL STMT          
            String qry = "insert into checkvoucher(cvnumber,cvdate,cvpcode,cvpname,cvpaddress,cvamount,total,refnumber,checknumber,voiddate,paymentDesc,bank,forliquidation,userID,entrydate)" +
                            " values (@cvnumber,@cvdate,@cvpcode,@cvpname,@cvpaddress,@cvamount,@total,@refnumber,@checknumber,@voiddate,@desc,@bank,@forliquidation,@userid,now())";

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());

                //ADD PARAMETERS  
                cmd.Parameters.AddWithValue("@cvnumber", cvNo_lb.Text);
                cmd.Parameters.AddWithValue("@cvdate", cvdate_dp.Value);//DateTime.Now);
                cmd.Parameters.AddWithValue("@cvpcode", pcode_tf.Text);
                cmd.Parameters.AddWithValue("@cvpname", pname_tf.Text);
                cmd.Parameters.AddWithValue("@cvpaddress", paddress_tf.Text);
                cmd.Parameters.AddWithValue("@cvamount", Double.Parse(cvamount_tf.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@total", Double.Parse(getTotalCV(creditTotal_lb.Text)) );
                cmd.Parameters.AddWithValue("@refnumber", refno_tf.Text);
                cmd.Parameters.AddWithValue("@checknumber", bank_cb.GetItemText(bank_cb.SelectedItem).ToString() + " " + checkno_tf.Text);
                cmd.Parameters.AddWithValue("@voiddate", checkDate_dp.Value);
                cmd.Parameters.AddWithValue("@desc",paydesc_tf.Text);
                cmd.Parameters.AddWithValue("@bank", bank_cb.GetItemText(bank_cb.SelectedItem).ToString());
                cmd.Parameters.AddWithValue("@userID", globalmainFrm.userlog);

                if(isliquidated_cb.Checked)
                    cmd.Parameters.AddWithValue("@forliquidation", 1);
                else
                    cmd.Parameters.AddWithValue("@forliquidation", 0);
            
                //cmd.ExecuteNonQuery();
                //OPEN CON AND EXEC insert
            
            
                //conn_tmp.Open();

                cmd.ExecuteNonQuery();
                //conn_tmp.Close();

                
                idcv = getcvID(cvNo_lb.Text);

                insertcvCntr();
                insertcvJournal();               

                
                frm_cvjournal.loadCV();

                tb_dbGrid.Rows.Clear();
                loadcvjournal(cvNo_lb.Text);

                if (isSave)
                {
                    MessageBox.Show("Check voucher successfully save...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                
            }
           catch (Exception ex)
           {
             MessageBox.Show("Ronel ERROR "+ex.Message);
             //conn_tmp.Close();
           }

        }
        
        private void insertcvCntr()
        {
            String qry = "insert into countercv(cvdate,yymm,cntr,idcv) values (@cvdate,@yymm,@cntr,@idcv)";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());

            cmd.Parameters.AddWithValue("@cvdate",DateTime.Now);            
            cmd.Parameters.AddWithValue("@yymm",cvNo_lb.Text.Substring(2,4));
            cmd.Parameters.AddWithValue("@cntr",int.Parse(cvNo_lb.Text.Substring(7,3)));            
            cmd.Parameters.AddWithValue("@idcv",int.Parse(idcv));           

            try
            {
                //conn_tmp.Open();
                cmd.ExecuteNonQuery();

                //conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //conn_tmp.Close();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            sRow = tb_dbGrid.Rows[selectedrowindex];

            String msgcode = "";
            String idcvJ="";
            String descSF = "";

            try
            {
                msgcode = sRow.Cells[0].Value.ToString();
            }
            catch
            { }

            try
            {
                descSF = sRow.Cells[12].Value.ToString();
            }
            catch
            { }

            try
            {
                idcvJ = sRow.Cells[6].Value.ToString();
            }
            catch
            { }

            //if (descSF == "APV Debit")
            //    return;

            DialogResult d = MessageBox.Show(msgcode + "\n Are you sure you want to delete this row?", uc.getMsgFrm()+ " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (d == DialogResult.Yes)
            {               
                tb_dbGrid.Rows.RemoveAt(selectedrowindex);
                deletecvJournal(idcvJ);
                sumDC();
            }


        }

        private void deletecvJournal(String id)
        {
            String qry = "Delete from cvjournal where idcvjournal = '"+id+"'";

            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            //conn_tmp.Open();

            try
            {                
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                //conn_tmp.Close();
            }
            
        }
        private void deleteSelectedCell()
        {
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            sRow = tb_dbGrid.Rows[selectedrowindex];
            
           /* sRow.Cells[0].Value = "";
            sRow.Cells[2].Value = "";
            sRow.Cells[3].Value = "0.00";
            sRow.Cells[4].Value = "0.00";*/
        }

        public void setAccountCode(String code,String name)
        {
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            sRow = tb_dbGrid.Rows[selectedrowindex];

            sRow.Cells[0].Value = code;
            sRow.Cells[2].Value = name;
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {          
                     
        }
               

        private void updatecv(String cvno,String pcode,String pname,String address,String cvamount,String total,String refno,String checkno,DateTime voiddate,String bank,String paymentDesc)
        {
            String qry = "update checkvoucher set cvpcode = @pcode, " +
                         "                        cvpname = @pname," +
                         "                        cvpaddress = @address," +
                         "                        cvamount = @cvamount," +
                         "                        total =@total, "+
                         "                        refnumber = @refno," +
                         "                        checknumber = @checkno," +
                         "                        voiddate = @voiddate," +
                         "                        bank = @bank," +
                         "                        paymentDesc = @paymentDesc," +
                         "                        forliquidation = @forliquidation," +
                         "                        cvdate = @cvdate " +                         
                         " where cvnumber = @cvno";
            int liqCB = 0;

            if (isliquidated_cb.Checked)
                liqCB = 1;

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@pcode", pcode);
                cmd.Parameters.AddWithValue("@pname", pname);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@cvamount", Double.Parse(cvamount));
                cmd.Parameters.AddWithValue("@total",Double.Parse(total));
                cmd.Parameters.AddWithValue("@refno", refno);
                cmd.Parameters.AddWithValue("@checkno", checkno);
                cmd.Parameters.AddWithValue("@voiddate", voiddate);
                cmd.Parameters.AddWithValue("@bank", bank);
                cmd.Parameters.AddWithValue("@paymentDesc", paymentDesc);
                cmd.Parameters.AddWithValue("@cvno", cvno);
                cmd.Parameters.AddWithValue("forliquidation", liqCB);
                cmd.Parameters.AddWithValue("@cvdate", cvdate_dp.Value);
                
                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("CV update ERROR: "+ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
                this.isErrUpdate = true;
            }
            
        }
        private void insertcvJ(String id,String code,String particulars,String debit,String credit,String cvno,Boolean is_SF, String glaccountcode, String glaname,String descSF,String jobid,String jobname)
        {
            String qry = "insert into cvjournal(idcheckvoucher,accountcode,cvparticulars,date,debit,credit,cvnumber,isSF,glaccountcode,glaccountname,descSF,jobid,jobname,userID,entryDate)" +
                         " values (@idcheckvoucher,@accountcode,@cvparticulars,@cvdate,@debit,@credit,@cvnumber,@isSF,@glaccountcode,@glaname,@descSF,@jobid,@jobname,@userid,now())";


           try
           {                    
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@idcheckvoucher", int.Parse(id));
                cmd.Parameters.AddWithValue("@accountcode", code);
                cmd.Parameters.AddWithValue("@cvparticulars", particulars);
                cmd.Parameters.AddWithValue("@cvdate", cvdate_dp.Value);//DateTime.Now);                        
                cmd.Parameters.AddWithValue("@debit", Double.Parse(debit));               
                cmd.Parameters.AddWithValue("@credit", Double.Parse(credit));                        
                cmd.Parameters.AddWithValue("@cvnumber", cvno);
                cmd.Parameters.AddWithValue("@isSF",is_SF);
                cmd.Parameters.AddWithValue("@glaccountcode", glaccountcode);
                cmd.Parameters.AddWithValue("@glaname", glaname);
                cmd.Parameters.AddWithValue("@descSF", descSF);
                cmd.Parameters.AddWithValue("@jobid", jobid);
                cmd.Parameters.AddWithValue("@jobname",jobname);
                cmd.Parameters.AddWithValue("@userid",globalmainFrm.userlog);

                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
                    
           }
           catch (Exception ex)
           {
                MessageBox.Show("CV detail add ERROR: "+ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
                this.isErrUpdate = true;
           }
            
        }

        private void updatecvJ(String id,String code,String particulars,String debit,String credit,Boolean is_SF,String glaccountcode,String glaname,String descSF,String jobid,String jobname)
        {
            String qry = "update cvjournal set accountcode = @code, " +
                         "                     cvparticulars = @particulars,"+                         
                         "                     date = @date," +
                         "                     debit = @debit," +
                         "                     credit = @credit," +
                         "                     isSF = @isSF, "+
                         "                     glaccountcode = @glaccountcode," +
                         "                     glaccountname = @glaname," +
                         "                     descSF = @descSF," +
                         "                     jobid = @jobid," +
                         "                     jobname = @jobname " +                        
                         " where idcvjournal = @idcvj";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            cmd.Parameters.AddWithValue("@code",code);
            cmd.Parameters.AddWithValue("@particulars", particulars);
            cmd.Parameters.AddWithValue("@date", cvdate_dp.Value);//DateTime.Now);
            cmd.Parameters.AddWithValue("@debit",Double.Parse(debit));
            cmd.Parameters.AddWithValue("@credit",Double.Parse(credit));
            cmd.Parameters.AddWithValue("@idcvj",int.Parse(id));
            cmd.Parameters.AddWithValue("@isSF",is_SF);
            cmd.Parameters.AddWithValue("@glaccountcode", glaccountcode);
            cmd.Parameters.AddWithValue("@glaname", glaname);
            cmd.Parameters.AddWithValue("@descSF", descSF);
            cmd.Parameters.AddWithValue("@jobid", jobid);
            cmd.Parameters.AddWithValue("@jobname", jobname);
            //cmd.Parameters.AddWithValue("@cvdate", cvdate_dp.Value);

            try
            {
                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CV detail update ERROR: "+ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
                this.isErrUpdate = true;
            }
        }
        private void filterupdatecvJ(Boolean isSave)
        {
            String idcv = getcvID(cvNo_lb.Text);
            String code = "";
            String particulars = "";
            String debit = "0.00";
            String credit = "0.00";
            String cvno = cvNo_lb.Text;
            String idcvj = "0";
            this.isErrUpdate = false;
            //Boolean CashFund = false;
            String descSF = "";
            String jobid = "";
            String jobname = "";

            
            String qry = "Select * from cvjournal where idcvJournal = @idcvj";

            
            int rowcnt = tb_dbGrid.Rows.Count;

            if (isErrUpdate==false)
            {
                for (int i = 0; i < rowcnt - 1; i++)
                {

                    try
                    {
                        idcvj = tb_dbGrid.Rows[i].Cells[6].Value.ToString();
                    }
                    catch
                    { }

                    try
                    {
                        descSF = tb_dbGrid.Rows[i].Cells[12].Value.ToString();
                    }
                    catch
                    { }

                    try
                    {
                        jobid = tb_dbGrid.Rows[i].Cells[15].Value.ToString();
                    }
                    catch
                    { }

                    try
                    {
                        jobname = tb_dbGrid.Rows[i].Cells[16].Value.ToString();
                    }
                    catch
                    { }

                    try
                    {

                        cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                        cmd.Parameters.AddWithValue("@idcvj", int.Parse(idcvj));

                        //conn_tmp.Open();
                        dr = cmd.ExecuteReader();

                        if (dr.Read()) //check voucher update statement========================
                        {

                            dr.Close();
                            //conn_tmp.Close();

                            if ((tb_dbGrid.Rows[i].Cells[0].Value != null) && (tb_dbGrid.Rows[i].Cells[2].Value != null))
                            {
                                code = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                                particulars = tb_dbGrid.Rows[i].Cells[2].Value.ToString();

                                if (tb_dbGrid.Rows[i].Cells[3].Value != null)
                                    debit = tb_dbGrid.Rows[i].Cells[3].Value.ToString().Replace(",", "");

                                if (tb_dbGrid.Rows[i].Cells[4].Value != null)
                                    credit = tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "");

                                //CashFund = Boolean.Parse(tb_dbGrid.Rows[i].Cells[7].Value.ToString());


                                updatecvJ(idcvj, code, particulars, debit, credit,true, tb_dbGrid.Rows[i].Cells[8].Value.ToString(), tb_dbGrid.Rows[i].Cells[9].Value.ToString(), descSF,jobid,jobname);
                            }
                                                       
                        }
                        else //check voucher insert statement===========================================
                        {

                            dr.Close();
                            //conn_tmp.Close();

                            if ((tb_dbGrid.Rows[i].Cells[0].Value != null) && (tb_dbGrid.Rows[i].Cells[2].Value != null))
                            {
                                code = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                                particulars = tb_dbGrid.Rows[i].Cells[2].Value.ToString();

                                if (tb_dbGrid.Rows[i].Cells[3].Value != null)
                                    debit = tb_dbGrid.Rows[i].Cells[3].Value.ToString().Replace(",", "");

                                if (tb_dbGrid.Rows[i].Cells[4].Value != null)
                                    credit = tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "");

                                //CashFund = Boolean.Parse(tb_dbGrid.Rows[i].Cells[7].Value.ToString());

                                insertcvJ(idcv, code, particulars, debit, credit, cvno, true, tb_dbGrid.Rows[i].Cells[8].Value.ToString(), tb_dbGrid.Rows[i].Cells[9].Value.ToString(),descSF,jobid,jobname);
                            }
                                                        
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dr.Close();
                        //conn_tmp.Close();                                              

                        break;
                    }

                    idcvj = "0";
                    code = "";
                    particulars = "";
                    debit = "0.00";
                    credit = "0.00";
                    descSF = "";
                    jobid = "";
                    jobname = "";
                    //CashFund = false;

                    if (isErrUpdate == true)
                        break;
                }

                if(isSave)
                MessageBox.Show("Check voucher details successfully updated...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void insertcvJournal()
        {
            String qry = "insert into cvjournal(idcheckvoucher,accountcode,cvparticulars,date,debit,credit,cvnumber,isSF,glaccountcode,glaccountname,descSF,jobid,jobname,userID,entryDate)" +
                         " values (@idcheckvoucher,@accountcode,@cvparticulars,@cvdate,@debit,@credit,@cvnumber,@isSF,@glaccountcode,@glaname,@descSF,@jobid,@jobname,@userID,now())";
            

            int rowcnt = tb_dbGrid.Rows.Count;
            String jobid = "";
            String jobname = "";
            //foreach (DataGridViewRow row in tb_dbGrid.Rows)
            for(int i=0; i<rowcnt-1; i++)
            {
                try
                {
                    jobid = tb_dbGrid.Rows[i].Cells[15].Value.ToString();
                }
                catch
                { }

                try
                {
                    jobname = tb_dbGrid.Rows[i].Cells[16].Value.ToString();
                }
                catch
                { }

                try
                {
                    if ((tb_dbGrid.Rows[i].Cells[0].Value != null) && (tb_dbGrid.Rows[i].Cells[2].Value != null))
                    {
                        cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                        cmd.Parameters.AddWithValue("@idcheckvoucher", int.Parse(idcv));
                        cmd.Parameters.AddWithValue("@accountcode", tb_dbGrid.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@cvparticulars", tb_dbGrid.Rows[i].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@cvdate", DateTime.Now);
                        

                        if (tb_dbGrid.Rows[i].Cells[3].Value != null)
                            cmd.Parameters.AddWithValue("@debit", Double.Parse(tb_dbGrid.Rows[i].Cells[3].Value.ToString().Replace(",", "")));
                        else
                            cmd.Parameters.AddWithValue("@debit", 0.00);

                        if (tb_dbGrid.Rows[i].Cells[4].Value != null)
                            cmd.Parameters.AddWithValue("@credit", Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "")));
                        else
                            cmd.Parameters.AddWithValue("@credit", 0.00);

                        cmd.Parameters.AddWithValue("@cvnumber",cvNo_lb.Text);// tb_dbGrid.Rows[i].Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@isSF", 1);
                        cmd.Parameters.AddWithValue("@glaccountcode", tb_dbGrid.Rows[i].Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@glaname", tb_dbGrid.Rows[i].Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@descSF", tb_dbGrid.Rows[i].Cells[12].Value.ToString());
                        cmd.Parameters.AddWithValue("@jobid",jobid);
                        cmd.Parameters.AddWithValue("@jobname", jobname);
                        cmd.Parameters.AddWithValue("@userID",globalmainFrm.userlog);

                        //conn_tmp.Open();
                        cmd.ExecuteNonQuery();
                        //conn_tmp.Close();


                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                    //conn_tmp.Close();
                }


                jobid = "";
                jobname = "";

            }

            
        }        

        //===check if CV already has a source of fund======================
        //=================================================================
        private String getSF(int sRow_)
        {
            String sf = "";
            int rowcnt = tb_dbGrid.Rows.Count;
            for (int i = 0; i < rowcnt; i++)
            {
                try
                {
                    if ((tb_dbGrid.Rows[i].Cells[12].Value.ToString() == "Source Of Fund") && (sRow_!=i))
                        sf = tb_dbGrid.Rows[i].Cells[12].Value.ToString();                   
                }
                catch
                {}
            }

            return sf;
        }
        //=========================================================

        private void sumDC()
        {
            Double debit_ = 0.00;
            Double credit_ = 0.00;
            Double bal_ = 0.00;

            String code_ = "";
            String name_ = "";
            //Boolean osf = false;
            // cashFund = 0.00;

            // Display string representations of numbers for en-us culture 
            // doctype_
            CultureInfo ci = new CultureInfo("en-us");
            cvAmount = 0.00;

            //String descSF = "";            

            //=================================
            //=================================
            //foreach (DataGridViewRow row in tb_dbGrid.Rows)
            int rowcnt = tb_dbGrid.Rows.Count;
            for(int i=0; i<rowcnt-1; i++)
            {
                

                try
                {
                    code_ = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                }
                catch
                { }

                try
                {
                    name_ = tb_dbGrid.Rows[i].Cells[2].Value.ToString();
                }
                catch
                { }


               try
               {                    
                    debit_ = debit_ + Double.Parse(tb_dbGrid.Rows[i].Cells[3].Value.ToString().Replace(",",""));                    
                }            
               catch
               { }

                try
                {                    
                    credit_ = credit_ + Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", ""));                  

                }
                catch
                { }

               
                try
                {
                    if ((tb_dbGrid.Rows[i].Cells[12].Value.ToString() == "Source Of Fund"))
                    {
                     cvAmount = cvAmount+Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", ""));                    
                    }
                }
                catch
                { }



            }

            cvamount_tf.Text = cvAmount.ToString("N02", ci);
            amountWords_tf.Text = uc.ToWords(cvAmount);

            bal_ = debit_ - credit_;
            debitTotal_lb.Text = "P "+debit_.ToString("N02",ci);
            creditTotal_lb.Text = "P "+credit_.ToString("N02",ci);
            bal_lb.Text = bal_.ToString("N02",ci);

            

            //=================================
            //=================================
            for (int i= 0; i < rowcnt-1; i++)
            {
                try
                {
                    //cancel_cvAmnt =  Double.Parse(tb_dbGrid.Rows[i].Cells[3].Value.ToString().Replace(",", ""));
                    tb_dbGrid.Rows[i].Cells[3].Value = Double.Parse(tb_dbGrid.Rows[i].Cells[3].Value.ToString()).ToString("N02",ci);
                }
                catch
                { }

                try
                {
                    tb_dbGrid.Rows[i].Cells[4].Value = Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString()).ToString("N02", ci); // "0.00";
                }
                catch
                { }

                if(isvoid_cb.Checked)
                {
                    tb_dbGrid.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                    tb_dbGrid.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                    tb_dbGrid.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                    tb_dbGrid.Rows[i].Cells[4].Style.ForeColor = Color.Red;
                    tb_dbGrid.Rows[i].Cells[11].Style.ForeColor = Color.Red;
                }
                else
                {                    
                    tb_dbGrid.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                    tb_dbGrid.Rows[i].Cells[2].Style.ForeColor = Color.Black;
                    tb_dbGrid.Rows[i].Cells[3].Style.ForeColor = Color.Black;
                    tb_dbGrid.Rows[i].Cells[4].Style.ForeColor = Color.Black;
                    tb_dbGrid.Rows[i].Cells[11].Style.ForeColor = Color.Black;
                }                     
                
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            
        }
        
        private void tb_dbGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;           
            Boolean isSF = true;
            string descSF = "";
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];
            //frm.setAccountcode(sRow.Cells[0].Value.ToString());
            String btnJob = "";
            String code_ = "";

            try
            {
                code_ = sRow.Cells[0].Value.ToString();
            }
            catch
            { }


            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    descSF = sRow.Cells[12].Value.ToString();
                }
                catch
                { }

                try
                {
                    btnJob = sRow.Cells[14].Value.ToString();
                }
                catch
                { }

                //TODO - Button Clicked - Execute Code Here
               
                if (e.ColumnIndex == 14)
                {                   

                    if (btnJob.Equals("X"))
                    {
                        DialogResult d = MessageBox.Show("Are you sure you want to remove the job code entry?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (d == DialogResult.Yes)
                        {
                            sRow.Cells[15].Value = "";
                            sRow.Cells[16].Value = "";
                            sRow.Cells[14].Value = "...";
                        }

                    }
                    else
                    {
                        SelectjobFrm frm = new SelectjobFrm();
                        frm.checkvoucherInitl(this);
                        frm.lblTag.Text = "checkvoucher";
                        frm.ShowDialog();
                    }
                }
                else
                {   //=======================================================
                    //Feltering the type of account added====================
                    if (//(e.ColumnIndex == 1) && (descSF == "APV Debit") ||
                        (e.ColumnIndex == 1) && (descSF == "Source Of Fund") ||
                        (e.ColumnIndex == 10) && (descSF == "APV Debit") ||
                        (e.ColumnIndex == 10) && (descSF == "RV Debit"))
                        return;

                    if ((e.ColumnIndex == 10) && (getSF(selectedrowindex) == "Source Of Fund"))
                        return;

                    try
                    {
                        isSF = Boolean.Parse(sRow.Cells[7].Value.ToString());
                    }
                    catch
                    { }
                    //==========================================================

                    selectChartFrm frm = new selectChartFrm();
                    frm.frmcheckVoucherInitl(this);
                    frm.Text = "check vouvher";

                    if (e.ColumnIndex == 1)
                    {
                        frm.isSource_cb.Checked = false;
                        frm.setAccountcode(code_);
                        frm.setDoctype("CV");
                    }
                    else if (e.ColumnIndex == 10)
                    {
                        frm.isSource_cb.Checked = true;
                        frm.setDoctype("cv_GF");

                        try
                        {
                            frm.setAccountcode(sRow.Cells[0].Value.ToString());
                        }
                        catch
                        { }
                    }


                    frm.ShowDialog();
                }
            }

            
        }

        private void tb_dbGrid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tb_dbGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
               
                int a = tb_dbGrid.CurrentCell.ColumnIndex;
                /*if(a==1)
                {
                    //selectChartFrm frm = new selectChartFrm();
                   // frm.frmcheckVoucherInitl(this);

                   // frm.ShowDialog();
                }*/                 
               
            }     

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
            selectrefFrm frm = new selectrefFrm();
            frm.frmcheckVoucherInitl(this);

            //===set to global form event============================
            //frm.refdeteails_ += new selectrefFrm.DoEventRef(refdeteails);
            
            frm.ShowDialog();
        }

        private void payee_btn_Click(object sender, EventArgs e)
        {
            selectPayeeFrm frm = new selectPayeeFrm();
            frm.frmcheckVoucherInitl(this);
            frm.Text = "check voucher";
            frm.ShowDialog();
        }

        private void cvcounter()
        {
            String qry = "Select * from countercv where yymm = '"+DateTime.Now.ToString("yMM")+"' order by idcounterCV desc limit 1";
            int cntr = 1;

            cvNo_lb.Text = "";
            try
            {               

                //if(db_tmp.OpenConnection())
                //{
                    cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        cntr = int.Parse(dr["cntr"].ToString());
                        cntr++;
                    }

                    String num = cntr.ToString();
                    cvNo_lb.Text = "CV" + DateTime.Now.ToString("yMM") + "-" + num.PadLeft(3, '0');
                //}               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                //db_tmp.CloseConnection();
            }
                  
        }

        private void tb_dbGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            String descSF = "";
            try
            {
                descSF = tb_dbGrid.Rows[e.RowIndex].Cells[12].Value.ToString();
            }
            catch
            { }

            if (e.RowIndex >= 0)
            {
                if((descSF == "APV Debit") || (descSF == "RV Debit"))
                {
                    tb_dbGrid.Rows[e.RowIndex].Cells[4].Value = "0.00";
                    sumDC();
                    return;
                }

                if ((descSF == "Surce Of Fund"))
                {
                    tb_dbGrid.Rows[e.RowIndex].Cells[3].Value = "0.00";
                    sumDC();
                    return;
                }

                if (e.ColumnIndex == 3)
                {
                    tb_dbGrid.Rows[e.RowIndex].Cells[4].Value = "0.00";
                    sumDC();
                }
                else if (e.ColumnIndex == 4)
                {
                    tb_dbGrid.Rows[e.RowIndex].Cells[3].Value = "0.00";
                    sumDC();
                }
            }

           
        }

        private void tb_dbGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
                         
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            printCV(idcv_tf.Text);

        }
        private void printCV(String idcv)
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            cvRpt myReport = new cvRpt();           

            DataTable cvTable = new DataTable();
            DataTable cvjTable = new DataTable();
            DataTable sigTable = new DataTable();

            String sig = "Select " +
                       "   preparedBy," +
                       "   PreparedPos," +
                       "   checkedBy," +
                       "   checkedPos," +
                       "   issuedBy," +
                       "   issuedPos," +
                       "   verifiedBy," +
                       "   verifiedPos," +
                       "   auditedBy," +
                       "   auditedPos," +
                       "   approvedBy," +
                       "   approvedPos," +
                       "   receivedBy," +
                       "   receivedPos " +
                       "  from signatories where reportType like 'checkvoucher' ";
            String qry = "Select idcheckvoucher," +
                       " cvnumber," +
                       " DATE_FORMAT(cvdate,'%M %e, %Y') cvdate," +
                       " cvpcode," +
                       " cvpname," +
                       " cvpaddress," +
                       " cvamount," +
                       " refnumber," +
                       " checknumber checknumber," +
                       " voidcheck," +
                       " voiddate," +
                       " bankaccount," +
                       " bank," +
                       " paymentDesc," +
                       " transCategory," +                       
                       " cvStatus," +
                       " userID from checkvoucher where idcheckvoucher = '" + idcv + "' ";

            /*String qry2 = "set @p:='';set @amnt:='';set @d:='';set @c:='';set @cde:='';"+
                      " Select idcvJournal," +
                      "     idcheckvoucher," +
                      "     @cde accountcode," +
                      "     @p cvparticulars," +
                      "     date," +
                      "     @d debit," +
                      "     @c credit," +
                      "     cvnumber," +                      
                      "     cvJamount from " +
                      "     ( Select idcvJournal," +
                      "              idcheckvoucher," +
                      "              @cde:=concat(@cde,accountcode,'\r\n \r\n') accountcode," +
                      "              cvparticulars," +
                      "              date," +
                      "              @d:=concat(@d,if(debit>0,format(debit,2),''),'\r\n \r\n') debit," +
                      "              @c:=concat(@c,if(credit>0,format(credit,2),''),'\r\n \r\n') credit," +
                      "              cvnumber," +                     
                      "              if(debit>0,debit,-credit) as cvJamount, " +
                      "              @p :=concat(@p,cvparticulars,'\r\n \r\n') partclrs, " +
                      "              @amnt:=concat(@amnt,format(if(debit>0,debit,-credit),2),'\r\n \r\n') amnt " +
                      "              from cvjournal where idcheckvoucher = '" + idcv + "') f " +
                      " limit 1";*/

            String qry2 = "set @p:='';set @amnt:='';set @d:='';set @c:='';set @cde:='';" +
                      " Select idcvJournal," +
                      "        idcheckvoucher," +
                      "        accountcode," +
                      "        cvparticulars," +
                      "        date," +
                      "        if(debit>0,format(debit,2),'') debit," +
                      "        if(credit>0,format(credit,2),'')  credit," +
                      "        cvnumber," +
                      "        if(debit>0,debit,-credit) as cvJamount " +
                      "  from cvjournal where idcheckvoucher = '" + idcv + "' ";
            try
            {
                da = new MySqlDataAdapter(qry, globalmainFrm.getConn_accnt());
                //conn_tmp.Open();
                da.Fill(cvTable);
                da.Dispose();
                ds.Tables.Add(cvTable);
                ds.Tables[0].TableName = "checkvoucher";

                da.Dispose();
                //conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                //conn_tmp.Close();
            }
            
            try
            {
                da = new MySqlDataAdapter(qry2, globalmainFrm.getConn_accnt());
                //conn_tmp.Open();
                da.Fill(cvjTable);
                da.Dispose();
                ds.Tables.Add(cvjTable);
                ds.Tables[1].TableName = "cvdetails";

                da.Dispose();
                //conn_tmp.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                //conn_tmp.Close();
            }

            try
            {
                da = new MySqlDataAdapter(sig, globalmainFrm.getConn_accnt());
                //conn_tmp.Open();
                da.Fill(sigTable);
                da.Dispose();
                ds.Tables.Add(sigTable);
                ds.Tables[2].TableName = "signatories";

                da.Dispose();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                //conn_tmp.Close();
            }

            //set report and view===============
            try
            {
                myReport.SetDataSource(ds);
                frm.crystalRptViewer.ReportSource = myReport;
                frm.ShowDialog();             

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void printcheck()
        {
            rptFrm frm = new rptFrm();
            
            int idcvjournal = 0;
            String gmName = "";
            String gmPos = "";;
                       
            //get signatories============================
            String sig = "Select * from signatories limit 1";
            cmd = new MySqlCommand(sig, globalmainFrm.getConn_accnt());
            try
            {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    gmName = dr.GetString("gm");
                    gmPos = dr.GetString("gmPos");
                }

                dr.Close();
                //conn_tmp.Close();
            }
            catch
            {
                dr.Close();
                //conn_tmp.Close();
            }

            //========Check CV Details ==================
            int rowcnt = tb_dbGrid.Rows.Count;
            for (int i = 0; i < rowcnt - 1; i++)
            {
                try
                {
                    if (Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "")) > 0)
                    {
                        idcvjournal = int.Parse(tb_dbGrid.Rows[i].Cells[6].Value.ToString());
                        break;
                    }
                }
                catch
                {
                }
            }

            ///Amount in Word cv query=====================================================
            DataSet ds = new DataSet();
            DataTable cvTable = new DataTable();

            String qry_aw = "Select idcheckvoucher," +
                       " cvnumber," +
                       " DATE_FORMAT(cvdate,'%M %e, %Y') cvdate," +
                       " cvpcode," +
                       " cvpname," +
                       " cvpaddress," +
                       " cvamount," +
                       " refnumber," +
                       " checknumber checknumber," +
                       " voidcheck," +
                       " voiddate," +
                       " bankaccount," +
                       " bank," +
                       " paymentDesc," +
                       " transCategory," +
                       " cvStatus," +
                       " userID from checkvoucher where cvnumber = '" + cvNo_lb.Text + "' ";// cvNo_lb.Text + "' ";

            try
            {
                da = new MySqlDataAdapter(qry_aw, globalmainFrm.getConn_accnt());
                //conn_tmp.Open();
                da.Fill(cvTable);
                da.Dispose();
                ds.Tables.Add(cvTable);
                ds.Tables[0].TableName = "checkvoucher";

                da.Dispose();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                //conn_tmp.Close();
            }
            //===============================================================================
            //===============================================================================


            //============Print check========================
            String sql = "SELECT * FROM cvjournal where cvnumber = '" + cvNo_lb.Text + "' and idcvjournal = "+idcvjournal;
            cmd = new MySqlCommand(sql, globalmainFrm.getConn_accnt());

           // MessageBox.Show(idcvjournal.ToString());
            try
            {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                   
                    if (bank_cb.GetItemText(bank_cb.SelectedItem).ToString() == "DBP")
                    {
                        DBPbank myReport = new DBPbank();

                        myReport.SetDataSource(ds);
                        myReport.SetParameterValue("accountcode", dr.GetString("accountcode"));
                        myReport.SetParameterValue("accountname", dr.GetString("cvparticulars"));
                        myReport.SetParameterValue("cvno", cvNo_lb.Text);
                        myReport.SetParameterValue("checkno", bank_cb.GetItemText(bank_cb.SelectedItem).ToString() + " " + checkno_tf.Text);
                        myReport.SetParameterValue("payee", uc.CenterString(pname_tf.Text, 62));
                        myReport.SetParameterValue("amountw", amountWords_tf.Text);
                        myReport.SetParameterValue("amount", uc.CenterAmntString(cvamount_tf.Text, 18));
                        myReport.SetParameterValue("date", cvdate_dp.Value);
                        myReport.SetParameterValue("gm", gmName);
                        myReport.SetParameterValue("gmpos", gmPos);                        
                        frm.crystalRptViewer.ReportSource = myReport;
                        
                    }
                    else if (bank_cb.GetItemText(bank_cb.SelectedItem).ToString() == "CB")
                    {
                        chinaBank myReport = new chinaBank();

                        myReport.SetDataSource(ds);
                        myReport.SetParameterValue("accountcode", dr.GetString("accountcode"));
                        myReport.SetParameterValue("accountname", dr.GetString("cvparticulars"));
                        myReport.SetParameterValue("cvno", cvNo_lb.Text);
                        myReport.SetParameterValue("checkno", bank_cb.GetItemText(bank_cb.SelectedItem).ToString() + " " + checkno_tf.Text);
                        myReport.SetParameterValue("payee", uc.CenterString(pname_tf.Text, 62));
                        myReport.SetParameterValue("amountw", amountWords_tf.Text);
                        myReport.SetParameterValue("amount", uc.CenterAmntString(cvamount_tf.Text, 18));
                        myReport.SetParameterValue("date", cvdate_dp.Value);
                        myReport.SetParameterValue("gm", gmName);
                        myReport.SetParameterValue("gmpos", gmPos);
                        frm.crystalRptViewer.ReportSource = myReport;
                    }
                    else if (bank_cb.GetItemText(bank_cb.SelectedItem).ToString() == "MB")
                    {
                        chinaBank myReport = new chinaBank();

                        myReport.SetDataSource(ds);
                        myReport.SetParameterValue("accountcode", dr.GetString("accountcode"));
                        myReport.SetParameterValue("accountname", dr.GetString("cvparticulars"));
                        myReport.SetParameterValue("cvno", cvNo_lb.Text);
                        myReport.SetParameterValue("checkno", bank_cb.GetItemText(bank_cb.SelectedItem).ToString() + " " + checkno_tf.Text);
                        myReport.SetParameterValue("payee", uc.CenterString(pname_tf.Text, 62));//56
                        myReport.SetParameterValue("amountw", amountWords_tf.Text);
                        myReport.SetParameterValue("amount", uc.CenterAmntString(cvamount_tf.Text, 18));
                        myReport.SetParameterValue("date", cvdate_dp.Value);
                        myReport.SetParameterValue("gm", gmName);
                        myReport.SetParameterValue("gmpos", gmPos);
                        frm.crystalRptViewer.ReportSource = myReport;
                    }
                    else if (bank_cb.GetItemText(bank_cb.SelectedItem).ToString() == "PNB")
                    {
                        pnbBank myReport = new pnbBank();

                        myReport.SetDataSource(ds);
                        myReport.SetParameterValue("accountcode", dr.GetString("accountcode"));
                        myReport.SetParameterValue("accountname", dr.GetString("cvparticulars"));
                        myReport.SetParameterValue("cvno", cvNo_lb.Text);
                        myReport.SetParameterValue("checkno", bank_cb.GetItemText(bank_cb.SelectedItem).ToString() + " " + checkno_tf.Text);
                        myReport.SetParameterValue("payee", uc.CenterString(pname_tf.Text, 62));//58
                        myReport.SetParameterValue("amountw", amountWords_tf.Text);
                        myReport.SetParameterValue("amount", uc.CenterAmntString(cvamount_tf.Text, 18));
                        myReport.SetParameterValue("date", cvdate_dp.Value);
                        myReport.SetParameterValue("gm", gmName);
                        myReport.SetParameterValue("gmpos", gmPos);
                        frm.crystalRptViewer.ReportSource = myReport;
                    }
                    else
                    {
                        LBPbank myReport = new LBPbank();

                        myReport.SetDataSource(ds);
                        myReport.SetParameterValue("accountcode", dr.GetString("accountcode"));
                        myReport.SetParameterValue("accountname", dr.GetString("cvparticulars"));
                        myReport.SetParameterValue("cvno", cvNo_lb.Text);
                        myReport.SetParameterValue("checkno", bank_cb.GetItemText(bank_cb.SelectedItem).ToString() + " " + checkno_tf.Text);
                        myReport.SetParameterValue("payee", uc.CenterString(pname_tf.Text, 62));
                        myReport.SetParameterValue("amountw", amountWords_tf.Text);
                        myReport.SetParameterValue("amount", uc.CenterAmntString(cvamount_tf.Text, 18));
                        myReport.SetParameterValue("date", cvdate_dp.Value);
                        myReport.SetParameterValue("gm", gmName);
                        myReport.SetParameterValue("gmpos", gmPos);
                        frm.crystalRptViewer.ReportSource = myReport;
                    }


                    //frm.crystalRptViewer.PrintReport();
                    frm.ShowDialog();

                    dr.Close();
                    //conn_tmp.Close();

                    Close();
                                        
                }                               
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                dr.Close();
                //conn_tmp.Close();
            }

            
        }


        private void checkvoucherFrm_Deactivate(object sender, EventArgs e)
        {            
        }

        private void printCheck_btn_Click(object sender, EventArgs e)
        {
            //conn_tmp.Close();
            //savecv(false);
            printcheck();            
        }

        private void tb_dbGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void isvoid_cb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void isvoid_cb_Click(object sender, EventArgs e)
        {

            voidcheck_p.Location = new Point(298, 183);            
            voidcheck_p.Visible = true;                      

            if (this.Text == "Update Check Voucher (Payment)")
            {
                postcv_lb.Enabled = true;
                cancelcv_lb.Enabled = true;
            }
            else
            {
                postcv_lb.Enabled = false;
                cancelcv_lb.Enabled = false;
            }

            loadcvvoiddate(cvNo_lb.Text);
        }

        private void closevp_btn_Click(object sender, EventArgs e)
        {
            voidcheck_p.Visible = false;
        }

        private void postvc_lb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult d = MessageBox.Show("CV No.:"+cvNo_lb.Text+"\n Are you sure, you want to void this check?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                postvoidDate(checkDate_dp.Value, reasonvoid_tf.Text, cvNo_lb.Text, idcv_tf.Text);
                loadcvvoiddate(cvNo_lb.Text);

                tb_dbGrid.Rows.Clear();
                loadcvjournal(id_tmp);
                loadFilteredCV(id_tmp);

                sumDC();

            }
            
        }

        private void postvoidDate(DateTime voiddate,String remarks,String cvno, String idcv)
        {
            //==update cv voidcheck=============================
            String qry = "update checkvoucher set  " +                     
                         "                        voiddate = @voiddate," +
                         "                        voidcheck = 1," +
                         "                        voidRemarks = @remarks, " +
                         "                        cvamount = 0.00, " +
                         "                        total = 0.00 " +
                         " where cvnumber = @cvno";

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@voiddate", voiddate);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@cvno", cvno);                

                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("CV ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
                this.isErrUpdate = true;
            }
            //===============================================================

            //update cv details==============================================
            qry = " set @c = 0.00; "+
                  "  update cvjournal set " +
                  "   debit = credit, " +
                  "   credit = @c " +
                  "  where idcheckvoucher = @idcv and(@c:= debit) IS NOT NULL";

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@idcv", idcv);                

                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CV ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
                this.isErrUpdate = true;
            }
            //=======================================================
            //=======================================================
        }

        private void cancelvoidDate(String cvno, String idcv)
        {
            //==update cv voidcheck=============================
            String qry = "update checkvoucher set  " +
                         "                        voiddate = CURDATE()," +
                         "                        voidcheck = 0," +
                         "                        voidRemarks = '', " +
                         "                        cvamount = @cvamount, " +
                         "                        total = @total " +
                         " where cvnumber = @cvno";

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());               
                cmd.Parameters.AddWithValue("@cvno", cvno);
                cmd.Parameters.AddWithValue("@cvamount", cancel_cvAmnt);
                cmd.Parameters.AddWithValue("@total", Double.Parse(getTotalCV(creditTotal_lb.Text)));

                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("CV ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
                this.isErrUpdate = true;
            }
            //===============================================================

            //update cv details==============================================
            qry = " set @c = 0.00; " +
                  "  update cvjournal set " +
                  "   debit = credit, " +
                  "   credit = @c " +
                  "  where idcheckvoucher = @idcv and(@c:= debit) IS NOT NULL";

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@idcv", idcv);

                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CV ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
                this.isErrUpdate = true;
            }
            //=======================================================
            //=======================================================
        }


        private void loadcvvoiddate(String cvno)
        {
            //get signatories============================
            String qry = "Select IFNULL(voidRemarks,'') voidremarks,voiddate,voidcheck  from checkvoucher where cvnumber =  @cvno";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            cmd.Parameters.AddWithValue("@cvno",cvno);
            
            try
            {
                //conn_tmp.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    checkDate_dp.Value = dr.GetDateTime("voiddate");
                    reasonvoid_tf.Text = dr.GetString("voidRemarks");
                    isvoid_cb.Checked = dr.GetBoolean("voidcheck");

                    if (dr.GetBoolean("voidcheck"))
                    {
                        voidDate_tf.Text = dr.GetDateTime("voiddate").ToString();

                        if (this.Text == "Update Check Voucher (Payment)")
                        {
                            postcv_lb.Enabled = false;
                            cancelcv_lb.Enabled = true;
                        }
                    }
                    else
                    {
                        voidDate_tf.Text = "";

                        if (this.Text == "Update Check Voucher (Payment)")
                        {
                            postcv_lb.Enabled = true;
                            cancelcv_lb.Enabled = false;
                        }
                    }
                }

                dr.Close();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //conn_tmp.Close();
            }
        }

        private void cancelcv_lb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           

            DialogResult d = MessageBox.Show("CV No.:" + cvNo_lb.Text + "\n Are you sure, you want to cancel the void check?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                int rowcnt = tb_dbGrid.Rows.Count;
                cancel_cvAmnt = 0.00;

                for (int i = 0; i < rowcnt; i++)
                {
                    try
                    {
                        if ((tb_dbGrid.Rows[i].Cells[12].Value.ToString() == "Source Of Fund"))
                        {
                            cancel_cvAmnt = Double.Parse(tb_dbGrid.Rows[i].Cells[3].Value.ToString().Replace(",", ""));
                        }
                    }
                    catch
                    {

                    }
                }

                cancelvoidDate(cvNo_lb.Text, idcv_tf.Text);
                loadcvvoiddate(cvNo_lb.Text);
                
                tb_dbGrid.Rows.Clear();
                loadcvjournal(id_tmp);
                loadFilteredCV(id_tmp);

                sumDC();
            }
        }

        private void checkvoucherFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.RefreshDgv(dateF.ToString("yyyy-MM-dd"),
                                dateT.ToString("yyyy-MM-dd"),
                                filter_tf);
            }
            catch
            { }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            try
            {
                this.RefreshDgv(dateF.ToString("yyyy-MM-dd"),
                            dateT.ToString("yyyy-MM-dd"),
                            filter_tf);
            }
            catch
            { }
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refdetail_p.Location = new Point(148, 83);
            refdetail_p.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refdetail_p.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertFirstRow();
            refdetail_p.Visible = false;
        }

        private void insertFirstRow()
        {
            String descSF = "";
            String JobBtn = "...";
            int rowcnt = refdetailDatagrid.Rows.Count; // tb_dbGrid.Rows.Count;

            if (refno_tf.Text.Substring(0, 3) == "APV")
            {
                descSF = "APV Debit";
            }else
            {
                descSF = "RV Debit";
            }

            for (int i = 0; i < rowcnt - 1; i++)
            {
                if (!(refdetailDatagrid.Rows[i].Cells[9].Value.ToString().Equals("")))
                    JobBtn = "X";

                tb_dbGrid.Rows.Insert(0, refdetailDatagrid.Rows[i].Cells[5].Value.ToString(),
                                        "...",
                                        refdetailDatagrid.Rows[i].Cells[6].Value.ToString(),
                                        refdetailDatagrid.Rows[i].Cells[4].Value.ToString(),
                                        "0.00",
                                        "",
                                        "",
                                        "0",
                                        refdetailDatagrid.Rows[i].Cells[7].Value.ToString(),
                                        refdetailDatagrid.Rows[i].Cells[8].Value.ToString(),
                                        "...",
                                        "",
                                        descSF,
                                        "",
                                        JobBtn,
                                        refdetailDatagrid.Rows[i].Cells[9].Value.ToString(),
                                        refdetailDatagrid.Rows[i].Cells[10].Value.ToString());                                
            }
        }
         
        //======Numeric Input only========================
        //================================================
        private void tb_dbGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if ((tb_dbGrid.CurrentCell.ColumnIndex == 3) || (tb_dbGrid.CurrentCell.ColumnIndex == 4))//Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }                
            }

        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
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

        private void refdetail_p_Paint(object sender, PaintEventArgs e)
        {

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            sumDC();

            //conn_tmp.Close();
            savecv(true);

            
        }

        private void savecv(Boolean isSave)
        {
            String bal = bal_lb.Text.Replace(",", "");
            CultureInfo ci = new CultureInfo("en-us");//("N02", ci

            if ((refno_tf.Text.Length <= 3) || (pcode_tf.Text.Length < 2) || (checkno_tf.Text.Length < 5) || (bank_cb.GetItemText(bank_cb.SelectedItem).ToString().Length < 2))
            {
                MessageBox.Show("Unable to continue this process. \r\nPlease complete the check details entry...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Double.Parse(bal) != 0.0)
            {
                MessageBox.Show("Unable to continue this process. \r\nDebit and credit should be equal value...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] totallb_ = creditTotal_lb.Text.Split(' ');

            
            //==check CV details if completed============================
            int rowcnt = tb_dbGrid.Rows.Count;

            for (int i = 0; i < rowcnt - 1; i++)
            {
                if (tb_dbGrid.Rows[i].Cells[0].Value.ToString() == "")
                {
                    MessageBox.Show("Unable to continue this process. \r\nIncomplete details account entry...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //===========================================================

            String apvAmnt = Double.Parse(Refamount_tf.Text).ToString("N02", ci);
            if ((doctype_ == "APV") && (Double.Parse(Refamount_tf.Text) < Double.Parse(cvamount_tf.Text.Replace(",", ""))))
            {
                MessageBox.Show("APV Amount: " + apvAmnt + "\r\nUnable to continue this process. \r\nCheck amount should be less than or equal to APV amount...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.Text == "Add Check Voucher (Payment)")
            {
                addcv(isSave);
            }
            else if (this.Text == "Update Check Voucher (Payment)")
            {
                filterupdatecvJ(isSave);

                updatecv( cvNo_lb.Text, pcode_tf.Text, pname_tf.Text, paddress_tf.Text, cvamount_tf.Text.Replace(",", ""), getTotalCV(creditTotal_lb.Text), refno_tf.Text,
                         bank_cb.GetItemText(bank_cb.SelectedItem).ToString() + " " + checkno_tf.Text, checkDate_dp.Value, bank_cb.GetItemText(bank_cb.SelectedItem).ToString(), paydesc_tf.Text);

                tb_dbGrid.Rows.Clear();
                loadcvjournal(id_tmp);
            }
        }
        //================================================
        //================================================
    }
}

