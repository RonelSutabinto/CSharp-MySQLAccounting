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
using zaneco_Accounting_System.Reports;
using zaneco_Accounting_System.module;

namespace zaneco_Accounting_System
{
    public partial class apvdetailsFrm : Form
    {

        //private connDBtmp db_tmp = new connDBtmp();
        //private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        //private DataTable dt = new DataTable();
        private MySqlDataAdapter da;

        public DataGridViewRow sRow;
        private unitClass uc = new unitClass();
        private DateTime rvdate_;
        private String rvno_ = "";
        private String idapv = "";
        private Boolean isErrUpdate;

        private accntpayablevFrm frm_accntpayablev = new accntpayablevFrm();
        private unpaidapvFrm frm_unpaidapv = new unpaidapvFrm();


        public apvdetailsFrm()
        {
            InitializeComponent();
        }
        public void accntpayablevInitl(accntpayablevFrm frm_accntpayablev1)
        {
            frm_accntpayablev = frm_accntpayablev1;
        }
        public void unpaidapvInitl(unpaidapvFrm frm_unpaidapv1)
        {
            frm_unpaidapv = frm_unpaidapv1;
        }

        public void setrvdate(DateTime dt)
        {
            this.rvdate_ = dt;
        }
        public void setrvno(String rv)
        {
            this.rvno_ = rv;
        }

        public void setidapv(String id)
        {
            this.idapv = id;
        }
         
        private void loadapv(String id)
        {
            CultureInfo ci = new CultureInfo("en-us");
            String qry = "Select * from apvoucher where idapvoucher = '" + id + "'";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());            

            try
            {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();
                
                if(dr.Read())
                {
                    refno_tf.Text = dr.GetString("docnumber");
                    pcode_tf.Text = dr.GetString("pcode");
                    pname_tf.Text = dr.GetString("pName");
                    paddress_tf.Text = dr.GetString("pAddress");
                    desc_tf.Text = dr.GetString("pDescription");
                    apvamount_tf.Text = dr.GetDouble("amount").ToString("N02", ci);
                    duedate_dp.Value = dr.GetDateTime("apvduedate");
                    apvdate_dp.Value = dr.GetDateTime("apvDate");
                    rvno_tf.Text = dr.GetString("rvnumber");
                    rvdate_dp.Value = dr.GetDateTime("pDate");
                    apvNo_lb.Text = dr.GetString("apvNumber");
                    due2_dp.Value = dr.GetDateTime("apvduedate2nd");
                    due3_dp.Value = dr.GetDateTime("apvduedate3rd");
              
                }

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
            
        private void loadcapvdetail(String id)
        {
            String btnJob = "...";
            String qry = "Select apvdetails.*," +
                         "       ifnull(jobid,'') job," +
                         "       ifnull(jobname,'') jobname_ " +
                         " from apvdetails where idapv = '" + id + "'";
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());

            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");

            tb_dbGrid.Rows.Clear();
            try
            {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    if(dr.GetString("job").Length>1)                    
                        btnJob = "X";                    
                    else                    
                        btnJob = "...";
                   
                    tb_dbGrid.Rows.Add(dr.GetString("particulars"),
                                       dr.GetString("accountcode"),
                                       "...",
                                       dr.GetString("accountname"),
                                       dr.GetDouble("debit").ToString("N02", ci),
                                       dr.GetDouble("credit").ToString("N02", ci), 
                                       dr.GetString("glaccountcode"),
                                       dr.GetString("glaccountname"),
                                       dr.GetString("qty"),
                                       dr.GetString("unit"),
                                       dr.GetString("cost"),
                                       dr.GetString("idapvdetails"),
                                       "","","","","0.00",
                                       btnJob,
                                       dr.GetString("job"),
                                       dr.GetString("jobname_"));


                    if (dr.GetDouble("debit") > 0)
                    {
                        refdetailDatagrid.Rows.Add(dr.GetString("qty"),
                                                   dr.GetString("particulars"),
                                                   dr.GetString("unit"),
                                                   dr.GetDouble("cost").ToString("N02", ci),
                                                   dr.GetDouble("debit").ToString("N02", ci));
                    }
                                       
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
             
        private void save_btn_Click(object sender, EventArgs e)
        {
            String bal = bal_lb.Text.Replace(",", ""); 
            String debittmp = debitTotal_lb.Text.Replace(",", "");
            Boolean isDue_ = false;            

            sumDC();

            if (frm_accntpayablev.dues_cb.Checked)
                isDue_ = true;

            //==Checking apv details========================
            if (Double.Parse(bal) != 0.0)
            {
                MessageBox.Show("Unable to continue this process. \r\nDebit and credit should be equal value...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(bal.ToString());
                return;
            }

            if (pcode_tf.Text.Length<2)
            {
                MessageBox.Show("Unable to continue this process. \r\nInvalid payee code entry.", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                pcode_tf.Select();
                return;
                
            }

            if (refno_tf.Text.Length <= 2)
            {
                MessageBox.Show("Unable to continue this process. \r\nInvalid reference number entry.", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                refno_tf.Select();
                return;

            }

            //try
            //{
            //    credittmp = Double.Parse(creditTotal_lb.Text.Replace(",", ""));
            //}
            //catch { }

            if (Double.Parse(credittmp_tf.Text.Replace(",", "") )<= 0)
            {
                MessageBox.Show("Unable to continue this process. \r\nIncomplete details entry.", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }


            /*if (Double.Parse(apvamount_tf.Text.Replace(",", "")) != Double.Parse(debittmp.Replace("P ", "")))
            {
                MessageBox.Show("Unable to continue this process. \r\nDebit and credit should be equal to APV amount...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            //===============================================
            //===============================================
                

            if (this.Text == "Add Accounts Payable Voucher")
            {
                this.isErrUpdate = false;
                int rowcnt = tb_dbGrid.Rows.Count;

                for (int i = 0; i < rowcnt - 1; i++)
                {
                    if (tb_dbGrid.Rows[i].Cells[1].Value.ToString() == "")
                        this.isErrUpdate = true;
                }
                

                if (isErrUpdate)
                {
                    MessageBox.Show("Unable to complete this process. \r\n Please complete the accountcode entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    insertapv(rvdate_dp.Value, apvdate_dp.Value, duedate_dp.Value, rvno_tf.Text, refno_tf.Text, apvNo_lb.Text, pcode_tf.Text, pname_tf.Text, paddress_tf.Text, desc_tf.Text, apvamount_tf.Text.Replace(",", ""));
                    insertapvCounter();
                    addapvdetails();

                    MessageBox.Show("APV entry successfully saved...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_accntpayablev.loadapv(frm_accntpayablev.apvsearch_tf.Text, frm_accntpayablev.fr_date.Value, frm_accntpayablev.to_date.Value,isDue_);
                    Close();
                }
            }
            else if (this.Text == "Update Accounts Payable Voucher")
            {
                updateapv(rvdate_dp.Value, duedate_dp.Value, rvno_tf.Text, refno_tf.Text, apvNo_lb.Text, pcode_tf.Text, pname_tf.Text, paddress_tf.Text, desc_tf.Text, apvamount_tf.Text.Replace(",", ""));
                filterupdateapvd();
                frm_accntpayablev.loadapv(frm_accntpayablev.apvsearch_tf.Text, frm_accntpayablev.fr_date.Value, frm_accntpayablev.to_date.Value,isDue_);
            }
                      

        }

        private void addapvdetails()
        {
            String idapv_a = getapvID(apvNo_lb.Text);
            //String idapvd = "0";
            String accountcode_a = "";
            String accountname_a = "";
            String glaccountcode_a = "";
            String glaccountname_a = "";
            String particulars_a = "";
            String qty_a = "1";
            String unit_a = "";
            String cost_a = "0.00";
            String debit_a = "0.00";
            String credit_a = "0.00";
            String jobid = "";
            String jobname = "";
            this.isErrUpdate = false;

            int rowcnt = tb_dbGrid.Rows.Count;
            
            for (int i = 0; i < rowcnt - 1; i++)
            {
                try
                {
                    particulars_a = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                }
                catch { }

                try
                {
                    accountcode_a = tb_dbGrid.Rows[i].Cells[1].Value.ToString();
                }
                catch { }

                try
                {
                    accountname_a = tb_dbGrid.Rows[i].Cells[3].Value.ToString();
                }
                catch { }

                try
                {
                    glaccountcode_a = tb_dbGrid.Rows[i].Cells[6].Value.ToString();
                }
                catch { }

                try
                {
                    glaccountname_a = tb_dbGrid.Rows[i].Cells[7].Value.ToString();
                }
                catch { }

                try
                {
                    debit_a = tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "");
                }
                catch
                { }

                try
                {
                    credit_a = tb_dbGrid.Rows[i].Cells[5].Value.ToString().Replace(",", "");
                }
                catch
                { }

                try
                {
                    qty_a = tb_dbGrid.Rows[i].Cells[8].Value.ToString();
                }
                catch
                { }

                try
                {
                    unit_a = tb_dbGrid.Rows[i].Cells[9].Value.ToString();
                }
                catch
                { }

                try
                {
                    cost_a = tb_dbGrid.Rows[i].Cells[10].Value.ToString().Replace(",", "");
                }
                catch
                { } 
                
                try
                {
                    jobid = tb_dbGrid.Rows[i].Cells[18].Value.ToString();
                }
                catch
                { }

                try
                {
                    jobname = tb_dbGrid.Rows[i].Cells[19].Value.ToString();
                }
                catch
                { }

                insertapvdetail(idapv_a, apvNo_lb.Text, accountcode_a, accountname_a, glaccountcode_a, glaccountname_a, particulars_a, int.Parse(qty_a), unit_a, Double.Parse(cost_a), Double.Parse(debit_a), Double.Parse(credit_a),jobid,jobname);

                //idapvd = "0";
                jobid = "";
                jobname = "";
                accountcode_a = "";
                accountname_a = "";
                glaccountcode_a = "";
                glaccountname_a = "";
                particulars_a = "";
                qty_a = "1";
                unit_a = "";
                cost_a = "0.00";
                debit_a = "0.00";
                credit_a = "0.00";
            }              
            
        }
        //select check voucher ID=====================================
        private String getapvID(String apvno)
        {
            String id = "0";

            
             String sql = "SELECT * FROM apvoucher where apvnumber = '" + apvno+"'";
             cmd = new MySqlCommand(sql, globalmainFrm.getConn_accnt());

             //OPEN CON
             try
              {
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    id = dr.GetString("idapvoucher");
                }

                dr.Close();
                //conn_tmp.Close();                
                
             }
             catch (Exception ex)
             {

                MessageBox.Show(ex.Message);               
                //conn_tmp.Close();                
             }

             
            return id; 
        }  
             
        private void filterupdateapvd()
        {
            String idapv_f = getapvID(apvNo_lb.Text);            
            String apvnotmp = apvNo_lb.Text;
            String idapvd = "0";            
            String accountcode_f = "";
            String accountname_f = "";
            String glaccountcode_f = "";
            String glaccountname_f = "";
            String particulars_f = "";
            String qty_f = "1";
            String unit_f = "";
            String cost_f = "0.00";
            String debit_f = "0.00";
            String credit_f = "0.00";
            String jobid = "";
            String jobname = "";
            this.isErrUpdate = false;

            Boolean ifnewref = false;


            String qry = "Select * from mctdetails where idmctdetails = @mctd";
            
            int rowcnt = tb_dbGrid.Rows.Count;
            for (int i = 0; i < rowcnt - 1; i++)
            {
                if (tb_dbGrid.Rows[i].Cells[1].Value.ToString() == "")
                    this.isErrUpdate = true;
            }

            if (isErrUpdate)
            {
                MessageBox.Show("Unable to complete this process. \r\n Please complete the accountcode entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < rowcnt - 1; i++)
                {

                    try
                    {
                        idapvd = tb_dbGrid.Rows[i].Cells[11].Value.ToString();
                    }
                    catch
                    { }

                    try
                    {
                        jobid = tb_dbGrid.Rows[i].Cells[18].Value.ToString();
                    }
                    catch
                    { }

                    try
                    {
                        jobname = tb_dbGrid.Rows[i].Cells[19].Value.ToString();
                    }
                    catch
                    { }

                    try
                    {
                        cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                        cmd.Parameters.AddWithValue("@idapvd", int.Parse(idapvd));

                        //conn_tmp.Open();
                        dr = cmd.ExecuteReader();

                        if (dr.Read()) //check voucher update statement========================
                        {
                            dr.Close();
                            //conn_tmp.Close();                            

                            particulars_f = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                            accountcode_f = tb_dbGrid.Rows[i].Cells[1].Value.ToString();
                            accountname_f = tb_dbGrid.Rows[i].Cells[3].Value.ToString();
                            debit_f = tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "");
                            credit_f = tb_dbGrid.Rows[i].Cells[5].Value.ToString().Replace(",", "");
                            glaccountcode_f = tb_dbGrid.Rows[i].Cells[6].Value.ToString();
                            glaccountname_f = tb_dbGrid.Rows[i].Cells[7].Value.ToString();
                            qty_f = tb_dbGrid.Rows[i].Cells[8].Value.ToString();
                            unit_f = tb_dbGrid.Rows[i].Cells[9].Value.ToString();
                            cost_f = tb_dbGrid.Rows[i].Cells[10].Value.ToString().Replace(",","");

                            updateapvdetail(idapvd, accountcode_f, accountname_f, glaccountcode_f, glaccountname_f, particulars_f,int.Parse(qty_f), unit_f, Double.Parse(cost_f), Double.Parse(debit_f), Double.Parse(credit_f),jobid,jobname);                            

                        }
                        else //check voucher insert statement===========================================
                        {
                            dr.Close();
                            //conn_tmp.Close();

                            particulars_f = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                            accountcode_f = tb_dbGrid.Rows[i].Cells[1].Value.ToString();
                            accountname_f = tb_dbGrid.Rows[i].Cells[3].Value.ToString();
                            debit_f = tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "");
                            credit_f = tb_dbGrid.Rows[i].Cells[5].Value.ToString().Replace(",", "");
                            glaccountcode_f = tb_dbGrid.Rows[i].Cells[6].Value.ToString();
                            glaccountname_f = tb_dbGrid.Rows[i].Cells[7].Value.ToString();
                            qty_f = tb_dbGrid.Rows[i].Cells[8].Value.ToString();
                            unit_f = tb_dbGrid.Rows[i].Cells[9].Value.ToString();
                            cost_f = tb_dbGrid.Rows[i].Cells[10].Value.ToString().Replace(",", "");

                            if (!(ifnewref))
                            {
                                deleteapvdetails(idapv_f);
                                ifnewref = true;
                            }

                            insertapvdetail(idapv_f, apvnotmp, accountcode_f, accountname_f, glaccountcode_f, glaccountname_f, particulars_f, int.Parse(qty_f), unit_f, Double.Parse(cost_f), Double.Parse(debit_f), Double.Parse(credit_f),jobid,jobname);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dr.Close();
                        //conn_tmp.Close();

                        break;
                    }

                    idapvd = "0";
                    accountcode_f = "";
                    accountname_f = "";
                    glaccountcode_f = "";
                    glaccountname_f = "";
                    particulars_f = "";
                    qty_f = "1";
                    unit_f = "";
                    cost_f = "0.00";
                    debit_f = "0.00";
                    credit_f = "0.00";
                    jobid = "";
                    jobname = "";

                }

                MessageBox.Show("Accounts payable voucher details successfully updated...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }
           
        private void deleteapvdetails(String idapv_d)
        {
            String qry = "Delete from apvdetails where idapv like @idapv";

            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            cmd.Parameters.AddWithValue("@idapv",idapv_d);
            
            try
            {
                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("APV detail add ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
            }


        }

        private void insertapv(DateTime _rvdate,DateTime _apvdate,DateTime _duedate,String _rvno, String _refno,String _apvno,String _pcode,String _pname,String _paddress,String _desc,String _amount)
        {
            String qry = "insert into apvoucher(pDate,apvDate,apvduedate,rvnumber,docnumber,apvNumber,pcode,pName,pAddress,pDescription,Amount,apvduedate2nd,apvduedate3rd,userid,entrydate)" +
                         " values (@pDate,@apvDate,@apvduedate,@rvnumber,@docnumber,@apvNumber,@pcode,@pName,@pAddress,@pDescription,@Amount,@apvduedate2nd,@apvduedate3rd,@userid,now())";

            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            cmd.Parameters.AddWithValue("@pDate", _rvdate);
            cmd.Parameters.AddWithValue("@apvDate", _apvdate);
            cmd.Parameters.AddWithValue("@apvduedate", _duedate);
            cmd.Parameters.AddWithValue("@rvnumber", _rvno);
            cmd.Parameters.AddWithValue("@docnumber", _refno);
            cmd.Parameters.AddWithValue("@apvNumber", _apvno);
            cmd.Parameters.AddWithValue("@pcode", _pcode);
            cmd.Parameters.AddWithValue("@pName", _pname);
            cmd.Parameters.AddWithValue("@pAddress", _paddress);
            cmd.Parameters.AddWithValue("@pDescription", _desc);
            cmd.Parameters.AddWithValue("@apvduedate2nd", due2_dp.Value);
            cmd.Parameters.AddWithValue("@apvduedate3rd", due3_dp.Value);
            cmd.Parameters.AddWithValue("@Amount", Double.Parse(apvamount_tf.Text.Replace(",", "")));
            cmd.Parameters.AddWithValue("@userid",globalmainFrm.userlog);
            
            try
            {
                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();                
            }
            catch(Exception ex)
            {
                MessageBox.Show("APV detail add ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
            }
        }
        private void updateapv(DateTime _rvdate, DateTime _duedate, String _rvno, String _refno, String _apvno, String _pcode, String _pname, String _paddress, String _desc, String _amount)
        {
            String qry = "update apvoucher set pDate = @pDate," +
                           "                   apvDate = @apvDate, " +
                           "                   apvduedate = @apvduedate," +
                           "                   rvnumber = @rvnumber," +
                           "                   docnumber = @docnumber," +
                           "                   pcode = @pcode," +
                           "                   pName = @pName," +
                           "                   pAddress = @pAddress," +
                           "                   pDescription = @pDescription," +
                           "                   Amount = @Amount, " +
                           "                   apvduedate2nd = @apvduedate2nd," +
                           "                   apvduedate3rd = @apvduedate3rd " +
                           " where apvNumber = @apvNumber";

            try
            {
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@pDate", _rvdate);
                cmd.Parameters.AddWithValue("@apvDate", apvdate_dp.Value);
                cmd.Parameters.AddWithValue("@apvduedate", _duedate);
                cmd.Parameters.AddWithValue("@rvnumber", _rvno);
                cmd.Parameters.AddWithValue("@docnumber", _refno);
                cmd.Parameters.AddWithValue("@pcode", _pcode);
                cmd.Parameters.AddWithValue("@pName", _pname);
                cmd.Parameters.AddWithValue("@pAddress", _paddress);
                cmd.Parameters.AddWithValue("@pDescription", _desc);
                cmd.Parameters.AddWithValue("@Amount", Double.Parse(apvamount_tf.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@apvNumber", _apvno);
                cmd.Parameters.AddWithValue("@apvduedate2nd", due2_dp.Value);
                cmd.Parameters.AddWithValue("@apvduedate3rd", due3_dp.Value);
                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("APV update ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();                
            }
        }

        private void apvdetailsFrm_Load(object sender, EventArgs e)
        {
            //conn_tmp = db_tmp.getConn();
           

            if (this.Text == "Add Accounts Payable Voucher")
            {
                apvcounter();
                refno_tf.ReadOnly = false;
            }
            else if (this.Text == "Update Accounts Payable Voucher")
            {
                refno_tf.ReadOnly = false;
                apvNo_lb.ReadOnly = true;
                loadapv(idapv);
                loadcapvdetail(idapv);
                sumDC();
            }
            else if (this.Text == "Preview Accounts Payable Voucher")
            {
                refno_tf.Enabled = false;
                desc_tf.Enabled = false;
                apvdate_dp.Enabled = false;
                duedate_dp.Enabled = false;
                save_btn.Enabled = false;
                delete_btn.Enabled = false;
                apvNo_lb.ReadOnly = true;

                loadapv(idapv);
                loadcapvdetail(idapv);
                sumDC();
            }
                        
        }

        private void insertapvCounter()
        {
            idapv = getapvID(apvNo_lb.Text);
            String qry = "insert into counterapv(apvdate,yymm,cntr,idapv) values (@apvdate,@yymm,@cntr,@idapv)";
            
            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());

            cmd.Parameters.AddWithValue("@apvdate", DateTime.Now);            
            cmd.Parameters.AddWithValue("@yymm",apvNo_lb.Text.Substring(3,4));
            cmd.Parameters.AddWithValue("@cntr",int.Parse(apvNo_lb.Text.Substring(8,3)));            
            cmd.Parameters.AddWithValue("@idapv", int.Parse(idapv));           

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
        
        private void insertapvdetail(String id,String apvno,String acode,String aname, String glacode, String glaname, String particulars,int qty,String unit,Double cost,Double debit,Double credit,String jobid,String jobname)
        {
            
            String qry = "insert into apvdetails( idapv,apvnumber,date,accountcode,accountname,glaccountcode,glaccountname,particulars,qty,unit,cost,debit,credit,jobid,jobname,userid,entrydate)" +
                         " values ( @idapv,@apvnumber,@date,@accountcode,@accountname,@glaccountcode,@glaccountname,@particulars,@qty,@unit,@cost,@debit,@credit,@jobid,@jobname,@userid,now())";
            
           try
           {                    
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@idapv", int.Parse(id));
                cmd.Parameters.AddWithValue("@apvnumber", apvno);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@accountcode", acode);                        
                cmd.Parameters.AddWithValue("@accountname", aname);               
                cmd.Parameters.AddWithValue("@glaccountcode", glacode);                        
                cmd.Parameters.AddWithValue("@glaccountname", glaname);
                cmd.Parameters.AddWithValue("@particulars", particulars);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@unit", unit);
                cmd.Parameters.AddWithValue("@cost", cost);
                cmd.Parameters.AddWithValue("@debit", debit);
                cmd.Parameters.AddWithValue("@credit", credit);
                cmd.Parameters.AddWithValue("@jobid", jobid);
                cmd.Parameters.AddWithValue("@jobname", jobname);
                cmd.Parameters.AddWithValue("@userid",globalmainFrm.userlog);

                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
                    
           }
           catch (Exception ex)
           {
                MessageBox.Show("APV detail add ERROR: "+ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();                
           }
            
        }
        
        private void updateapvdetail(String idapvd,String acode, String aname, String glacode, String glaname, String particulars, int qty, String unit, Double cost, Double debit, Double credit,String jobid,String jobname)
        {
            String qry = "update apvdetails set date = @date, " +
                         "                     accountcode = @accountcode," +
                         "                     accountname = @accountname," +
                         "                     glaccountcode = @glaccountcode," +
                         "                     glaccountname = @glaccountname," +
                         "                     particulars = @particulars," +
                         "                     qty = @qty, " +
                         "                     unit = @unit, " +
                         "                     cost = @cost, " +
                         "                     debit = @debit, " +
                         "                     credit = @credit," +
                         "                     jobid = @jobid," +
                         "                     jobname = @jobname " +
                         " where idapvdetails = @idapvd";

            cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@accountcode", acode);
            cmd.Parameters.AddWithValue("@accountname", aname);
            cmd.Parameters.AddWithValue("@glaccountcode", glacode);
            cmd.Parameters.AddWithValue("@glaccountname", glaname);
            cmd.Parameters.AddWithValue("@particulars", particulars);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@unit", unit);
            cmd.Parameters.AddWithValue("@cost", cost);
            cmd.Parameters.AddWithValue("@debit", debit);
            cmd.Parameters.AddWithValue("@credit", credit);
            cmd.Parameters.AddWithValue("@idapvd", idapvd);
            cmd.Parameters.AddWithValue("@jobid", jobid);
            cmd.Parameters.AddWithValue("@jobname", jobname);

            try
            {
                //conn_tmp.Open();
                cmd.ExecuteNonQuery();
                //conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("APV detail update ERROR: "+ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
               
            }
        } 
             
        private void apvcounter()
        {
            String qry = "Select * from counterapv where yymm = '"+DateTime.Now.ToString("yMM")+"' order by idcounterapv desc limit 1";
            int cntr = 1;

            apvNo_lb.Text = "";
            try
            {

                //conn_tmp.Open();
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cntr = int.Parse(dr["cntr"].ToString());
                    cntr++;
                }

                    String num = cntr.ToString();
                    apvNo_lb.Text = "APV" + DateTime.Now.ToString("yMM") + "-" + num.PadLeft(3, '0');
                               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                //conn_tmp.Close();
            }
                  
        }

        private void ref_btn_Click(object sender, EventArgs e)
        {
            apvreferenceFrm frm = new apvreferenceFrm();
            frm.apvdetailsFrmInitl(this);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refdetail_p.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refdetail_p.Location = new Point(148,83);
            //= 148,243;
           
            refdetail_p.Visible = true;
        }

        private void tb_dbGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String code_ = "";
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                //rowIndex_ = tb_dbGrid.SelectedCells[0].RowIndex;
                int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];

                
                if (e.ColumnIndex == 2)
                {
                    
                    selectChartFrm frm = new selectChartFrm();
                    frm.apvdetailsFrmInitl(this);
                    frm.Text = "Accounts Payable";

                    String codein = "";

                    try
                    {
                        codein = sRow.Cells[12].Value.ToString();
                    }
                    catch
                    { }

                    //if (refno_tf.Text.Length == 0)
                    //    return;
                                                          
                    try
                    {
                        code_ = sRow.Cells[1].Value.ToString();
                    }
                    catch
                    { }

                    frm.setAccountcode(code_);

                    //if ((refno_tf.Text.Substring(0, 2) != "RR") || (refno_tf.Text.Substring(0, 2) == "RR") && (codein.Length == 0))
                     frm.ShowDialog();

                    
                }
                else if (e.ColumnIndex == 17)
                {
                    String jobBtn = "...";

                    try
                    {
                        jobBtn = sRow.Cells[17].Value.ToString();
                    }
                    catch
                    { }

                    if (jobBtn.Equals("X"))
                    {
                        DialogResult d = MessageBox.Show("Are you sure you want to remove the job code entry?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (d == DialogResult.Yes)
                        {
                            sRow.Cells[18].Value = "";
                            sRow.Cells[19].Value = "";
                            sRow.Cells[17].Value = "...";
                        }
                        
                    }
                    else
                    {
                        SelectjobFrm frm = new SelectjobFrm();
                        frm.apvdetailsFrmInitl(this);
                        frm.lblTag.Text = "apvdetails";
                        frm.ShowDialog();
                    }
                    
                }

                
            }
        }

        public void sumDC()
        {
            Double debit_ = 0.00;
            Double credit_ = 0.00;
            Double bal_ = 0.00;

            credittmp_tf.Text = "0.00";

            // String code_ = "";
            // String name_ = "";
            //  Boolean osf = false;
            // Double cashFund = 0.00;

            // Display string representations of numbers for en-us culture 
            // doctype_
            CultureInfo ci = new CultureInfo("en-us");
           // Double balAmount = 0.00;

            //=================================
            //=================================
            //foreach (DataGridViewRow row in tb_dbGrid.Rows)
            int rowcnt = tb_dbGrid.Rows.Count;
            for (int i = 0; i < rowcnt - 1; i++)
            {
                /*try
                {
                    code_ = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                }
                catch
                { }*/

               /* try
                {
                    name_ = tb_dbGrid.Rows[i].Cells[2].Value.ToString();
                }
                catch
                { }*/


                try
                {
                    debit_ = debit_ + Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", ""));
                }
                catch
                { }

                try
                {
                    credit_ = credit_ + Double.Parse(tb_dbGrid.Rows[i].Cells[5].Value.ToString().Replace(",", ""));

                }
                catch
                { }
                               
            }

            bal_ = debit_ - credit_;
            debitTotal_lb.Text = "P " + debit_.ToString("N02", ci);
            creditTotal_lb.Text = "P " + credit_.ToString("N02", ci);
            credittmp_tf.Text = credit_.ToString("N02", ci);
            bal_lb.Text = bal_.ToString("N02", ci);
            apvamount_tf.Text = credit_.ToString("N02", ci);

            /* if (doctype_ != "RV")
             {
                 cvamount_tf.Text = cvAmount.ToString("N02", ci); //removed this statement============
                 amountWords_tf.Text = uc.ToWords(cvAmount);
             }*/

            //=================================
            //=================================
            for (int i = 0; i < rowcnt - 1; i++)
            {
                tb_dbGrid.Rows[i].Cells[4].Style.ForeColor = Color.Black;
                tb_dbGrid.Rows[i].Cells[5].Style.ForeColor = Color.Black;

                try
                {
                    if (Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "")) != 0.00)
                        tb_dbGrid.Rows[i].Cells[4].Style.ForeColor = Color.Green;

                    tb_dbGrid.Rows[i].Cells[4].Value = Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString()).ToString("N02", ci);
                }
                catch
                { }

                try
                {
                    if (Double.Parse(tb_dbGrid.Rows[i].Cells[5].Value.ToString().Replace(",",""))!=0.00)
                        tb_dbGrid.Rows[i].Cells[5].Style.ForeColor = Color.Red;

                    tb_dbGrid.Rows[i].Cells[5].Value = Double.Parse(tb_dbGrid.Rows[i].Cells[5].Value.ToString()).ToString("N02", ci); // "0.00";
                }
                catch
                { }
            }
        }
        private void close_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            printAPV();
        }

        
        private void printAPV()
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            apvRpt myReport = new apvRpt();           

            DataTable apvTable = new DataTable();
            DataTable apvdetailsTable = new DataTable();
            DataTable sigTable = new DataTable();
            this.idapv = getapvID(apvNo_lb.Text);

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
                       "  from signatories where reportType like 'accountspayable' ";
            String qry = "  Select   " +
                         "   idAPVoucher,  " +
                         "   pDate,  " +
                         "   apvDate,  " +
                         "   apvduedate,  " +
                         "   rvnumber,  " +
                         "   docnumber,  " +
                         "   apvNumber,  " +
                         "   pcode,  " +
                         "   pName,  " +
                         "   pAddress,  " +
                         "   pDescription,  " +
                         "   Amount,  " +
                         "   apvstatus,  " +
                         "   amountpaid,  " +
                         "   posted,  " +
                         "   Remarks," +
                         "   Amount as apvAmount  " +
                         "  from apvoucher where idAPVoucher = '"+ idapv+"' ";
            /* String qry2 = "  set @d:= '';  " +
                           "  set @c:= '';  " +
                           "  set @ptclr:= '';  " +
                           "  set @acode:= '';  " +
                           "  select  " +
                           "     @acode  accountcode,  " +
                           "     @ptclr Particulars,  " +
                           "     @d  debit,  " +
                           "     @c credit  " +
                           "    from  " +
                           "    (Select  " +
                           "      @acode:= concat(@acode, accountcode, '\r\n \r\n') acode,  " +
                           "      @ptclr:= concat(@ptclr, particulars, '\r\n \r\n') particulars,  " +
                           "      @d:= concat(@d, if(debit>0,format(debit,2),' '), '\r\n \r\n') debit,  " +
                           "      @c:= concat(@c, if(credit>0,format(credit,2),' '), '\r\n \r\n') credit  " +
                           "    from apvdetails where  " +
                           "         idapv = '" + idapv + "') f limit 1  ";*/

            String qry2 =
                          "    Select  " +
                          "      accountcode,  " +
                          "      particulars,  " +
                          "      format(debit,2) debit,  " +
                          "      format(credit,2) credit,  " +
                          "      ifnull(debit,0) debitF,  " +
                          "      ifnull(credit,0) creditF," +
                          "      accountname  " +
                          "    from apvdetails where  " +
                          "         idapv = '" + idapv + "' ";

            try
            {
                da = new MySqlDataAdapter(qry, globalmainFrm.getConn_accnt());
                //conn_tmp.Open();
                da.Fill(apvTable);
                //da.Dispose();
                ds.Tables.Add(apvTable);
                ds.Tables[0].TableName = "apvRep";

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
                da.Fill(apvdetailsTable);
               // da.Dispose();
                ds.Tables.Add(apvdetailsTable);
                ds.Tables[1].TableName = "apvdetailsRepF";

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
                //da.Dispose();
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

        private void tb_dbGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void tb_dbGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            String codein = "";
            String amnt = "";
            String refno = "";

            if (e.RowIndex >= 0)
            {
                int rowcnt = tb_dbGrid.Rows.Count;
                for (int i = 0; i < rowcnt - 1; i++)
                {                    
                    codein = "";
                    amnt = "";
                    try
                    {
                        codein = tb_dbGrid.Rows[i].Cells[12].Value.ToString();
                        amnt = tb_dbGrid.Rows[i].Cells[16].Value.ToString();
                        refno = refno_tf.Text.Substring(0, 2);
                    }
                    catch
                    { }

                    if ((refno == "RR") && (codein.Length > 0))
                    {
                        tb_dbGrid.Rows[i].Cells[4].Value = amnt;
                        tb_dbGrid.Rows[i].Cells[5].Value = "0.00";
                    }
                }

                sumDC();



            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void deleteRow()
        {
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            sRow = tb_dbGrid.Rows[selectedrowindex];

            String msgcode = "";
            String codein = "";
            String idapvd = "";

            try
            {
                msgcode = sRow.Cells[1].Value.ToString();
            }
            catch
            { }

            try
            {
                codein = sRow.Cells[12].Value.ToString();
            }
            catch
            { }

            try
            {
                idapvd = sRow.Cells[11].Value.ToString();
            }
            catch
            { }

            if ((codein.Length > 5) || (idapvd != ""))
                return;

            DialogResult d = MessageBox.Show(msgcode + "\n Are you sure you want to delete this row?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                tb_dbGrid.Rows.RemoveAt(selectedrowindex);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            Close();
        }

        //===Numeric Input only==============================
        //===================================================
        private void tb_dbGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if ((tb_dbGrid.CurrentCell.ColumnIndex == 4) || (tb_dbGrid.CurrentCell.ColumnIndex == 5))//Desired Column
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            priviewApvCV(apvNo_lb.Text);
        }

        private void priviewApvCV(String apvNo)
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            apvCVdetail myReport = new apvCVdetail();
            DataTable apvTable = new DataTable();

            String qry = " Select                " +
                         "       c.userid as user,                " +
                         "       cj.accountcode,                " +
                         "       cj.cvparticulars,                " +
                         "       concat(c.paymentdesc, ' : ', c.cvpcode, ' - ', c.cvpname) as description,                " +
                         "       c.checknumber as checkno,	                " +
                         "       date_format(c.cvdate,'%c/%e/%Y') as date,                " +
                         "       cj.credit as amount, " +                         
                         "       c.cvnumber,                " +
                         "       c.total " +                         
                         "   from                " +
                         "   checkvoucher c                " +
                         "   right join cvjournal cj on cj.cvnumber = c.cvnumber and                " +
                         "                              cj.descSF = 'Source Of Fund' and                " +
                         "                              cj.credit > 0                " +
                         "   where c.refnumber = '"+ apvNo + "' ";            

            try
            {
                da = new MySqlDataAdapter(qry, globalmainFrm.getConn_accnt());
                //conn_tmp.Open();
                da.Fill(apvTable);
                //da.Dispose();
                ds.Tables.Add(apvTable);
                ds.Tables[0].TableName = "apvCvdetails";

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectPayeeFrm frm = new selectPayeeFrm();
            frm.frmapvdetailsInitl(this);
            frm.Text = "apv voucher";
            frm.ShowDialog();
        }
        //================================================
        //================================================
                        
    }
}
