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
    public partial class mctdetailsFrm : Form
    {
        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private connectionDB_inv db_inv = new connectionDB_inv();
        private MySqlConnection conn_inv = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        //private DataTable dt = new DataTable();
        //private MySqlDataAdapter da;
        private unitClass uc = new unitClass();
        //private Double amountT = 0.00;

        private Boolean isErrUpdate;
        private String mctnoF = "";

        private MySqlDataAdapter da;

        mctFrm Frm_mct = new mctFrm();

        //==Global Event Variables===========================
        public delegate void DoEvent();
        public event DoEvent RefreshDgv;
        //==================================================

        private ContextMenuStrip menu_tb = new ContextMenuStrip();

        public mctdetailsFrm()
        {
            InitializeComponent();
        }

        public void mctFrmInitl(mctFrm Frm_mct1)
        {
            this.Frm_mct = Frm_mct1;
        }
        private void close_btn_Click(object sender, EventArgs e)
        {
            sumAmount();
            /*String bal = bal_lb.Text.Replace(",", "");

            if (Double.Parse(bal) != 0.0)
            {
                MessageBox.Show("Unable to close. \r\nDebit and credit should be equal value...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            this.RefreshDgv();
            Close();
        }

        public void setmctno(String mctno1)
        {
            this.mctnoF = mctno1;
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            String bal = bal_lb.Text.Replace(",", "");
            String acode_ = "";
            int debitCnt = 0;
            int creditCnt = 0;

            this.isErrUpdate = false;
            int rowcnt = tb_dbGrid.Rows.Count;

            int cnt = tb_dbGrid.Rows.Count;
            for (int i = 0; i < rowcnt - 1; i++)
            {
                try
                {
                    acode_ = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                }
                catch
                {
                    acode_ = "";
                }                

                if ((acode_.Equals("")))// || (Double.Parse(amount_tf.Text.Replace(",", "")) <= 0.00))
                    this.isErrUpdate = true;
                try
                {
                    if (tb_dbGrid.Rows[i].Cells[21].Value.ToString().Equals("1"))
                        debitCnt++;
                    else
                        creditCnt++;
                }catch
                { }


                //if ((Double.Parse(tb_dbGrid.Rows[i].Cells[7].Value.ToString().Replace(",", "")) <= 0.00) && (i < (cnt / 2)))
                //    this.isErrUpdate = true;
            }

            if (mctno_tf.Text.Length < 12) 
            {
                MessageBox.Show("Unable to complete this process. \r\n Invalid MCT or MTT entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if((mctno_tf.Text.Substring(0, 3) != "MTT") && (mctno_tf.Text.Substring(0, 3) != "MCT"))
            {
                MessageBox.Show("Unable to complete this process. \r\n Invalid MCT or MTT entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (debitCnt != creditCnt)//(tb_dbGrid.Rows.Count-1) % 2 != 0)
            //{
            //    MessageBox.Show("Unable to complete this process. \r\n Error trial balance statement entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            // if ((isErrUpdate) || (rowcnt - 1 == 0) ||( (mctno_tf.Text.Substring(0,3)=="MTT") && (Forwarded_cb.Checked==false) ) )
            if ((rowcnt - 1 <= 0) )//|| ((mctno_tf.Text.Substring(0, 3) == "MTT") && (Forwarded_cb.Checked == false)))
            {
                MessageBox.Show("Unable to complete this process. \r\n Please complete the accountcode and amount entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Double.Parse(bal) != 0.0)
            {
                MessageBox.Show("Unable to continue this process. \r\nDebit and credit should be equal value...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sumAmount();

            


            if (this.Text == "Add MCT Details Entry")
            {
                insertmct(mctdate_dp.Value, date_dp.Value, mctno_tf.Text, refno_tf.Text, desc_tf.Text, requester_tf.Text, amount_tf.Text.Replace(",", ""));
                filterupdateapvd();

                MessageBox.Show("MCT details successfully saved...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Frm_mct.loadmct();
                Close();
            }
            else if (this.Text == "Update MCT Details")
            {
                updatemct(mctno_tf.Text, refno_tf.Text, amount_tf.Text,requester_tf.Text,desc_tf.Text);
                filterupdateapvd();

                MessageBox.Show("MCT details successfully saved...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Frm_mct.loadmct();
                Close();
            }

        }
        private void calculateAmnt()
        {
            Double cost_ = 0.00;
            Double qty_ = 0.00;
            CultureInfo ci = new CultureInfo("en-us");

            //=================================
            //=================================
            //foreach (DataGridViewRow row in tb_dbGrid.Rows)
            int rowcnt = refdetailDatagrid.Rows.Count;
            for (int i = 0; i < rowcnt - 1; i++)
            {
                cost_ = Double.Parse(refdetailDatagrid.Rows[i].Cells[3].Value.ToString().Replace(",", ""));
                qty_ = Double.Parse(refdetailDatagrid.Rows[i].Cells[0].Value.ToString().Replace(",", ""));

                refdetailDatagrid.Rows[i].Cells[4].Value = cost_ * qty_;
                refdetailDatagrid.Rows[i].Cells[3].Value = Double.Parse(refdetailDatagrid.Rows[i].Cells[3].Value.ToString()).ToString("N02", ci);
            }
        }
        private void sumAmount()
        {
            Double debit_ = 0.00;
            Double credit_ = 0.00;
            CultureInfo ci = new CultureInfo("en-us");

            Double d_ = 0.00;
            Double c_ = 0.00;

            //=================================
            //=================================
            //foreach (DataGridViewRow row in tb_dbGrid.Rows)
            int rowcnt = tb_dbGrid.Rows.Count;
            for (int i = 0; i < rowcnt - 1; i++)
            {
                d_ = 0.00;
                c_ = 0.00;

                try
                {
                    d_ = Double.Parse(tb_dbGrid.Rows[i].Cells[9].Value.ToString().Replace(",", ""));//--
                }
                catch
                { }

                try
                {
                    c_ = Double.Parse(tb_dbGrid.Rows[i].Cells[10].Value.ToString().Replace(",", ""));//--
                }
                catch
                { }

                //debit_ = debit_ + Double.Parse(tb_dbGrid.Rows[i].Cells[8].Value.ToString().Replace(",", ""));
                //credit_ = credit_ + Double.Parse(tb_dbGrid.Rows[i].Cells[9].Value.ToString().Replace(",", ""));

                debit_ = debit_ + d_;
                credit_ = credit_ + c_;

                tb_dbGrid.Rows[i].Cells[9].Value = d_.ToString("N02", ci);//--
                tb_dbGrid.Rows[i].Cells[10].Value = c_.ToString("N02", ci);//--

                /*
                try
                {
                    if (tb_dbGrid.Rows[i].Cells[20].Value.ToString().Equals("1"))//--
                    {
                        tb_dbGrid.Rows[i].Cells[3].Style.BackColor = Color.White;
                        tb_dbGrid.Rows[i].Cells[5].Style.BackColor = Color.White;//--
                        //tb_dbGrid.Rows[i].Cells[9].Style.BackColor = Color.White;//--
                        //tb_dbGrid.Rows[i].Cells[10].Style.BackColor = Color.White;//--
                    }
                    else
                    {
                        tb_dbGrid.Rows[i].Cells[3].Style.BackColor = Color.LightCyan;//--
                        tb_dbGrid.Rows[i].Cells[5].Style.BackColor = Color.LightCyan;//--
                        //tb_dbGrid.Rows[i].Cells[9].Style.BackColor = Color.LightCyan;//--
                        //tb_dbGrid.Rows[i].Cells[10].Style.BackColor = Color.LightCyan;//--
                    }
                        
                }
                catch
                {
                    tb_dbGrid.Rows[i].Cells[3].Style.BackColor = Color.LightCyan;
                    tb_dbGrid.Rows[i].Cells[5].Style.BackColor = Color.LightCyan;//--
                    tb_dbGrid.Rows[i].Cells[9].Style.BackColor = Color.LightCyan;//--
                    tb_dbGrid.Rows[i].Cells[10].Style.BackColor = Color.LightCyan;//--
                }*/

            }

            amount_tf.Text = debit_.ToString("N02", ci);
            debitTotal_lb.Text = debit_.ToString("N02", ci);
            creditTotal_lb.Text = credit_.ToString("N02", ci);
            bal_lb.Text = (debit_ - credit_).ToString("N02", ci);                                  

        }

        private void loadmct(String mctno)
        {
            String qry = "Select materialct.*, " +
                         " ifnull(forwardedFrom,'') forwardedFrom_," +
                         " ifnull(forwardedTo,'') forwardedTo_" +
                         " from materialct where mctno = '" + mctno + "'";
            cmd = new MySqlCommand(qry, conn_tmp);

            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");

            tb_dbGrid.Rows.Clear();
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    mctno_tf.Text = dr.GetString("mctno");
                    refno_tf.Text = dr.GetString("refno");
                    desc_tf.Text = dr.GetString("description");
                    amount_tf.Text = dr.GetDouble("amount").ToString("N02", ci);
                    date_dp.Value = dr.GetDateTime("date");
                    mctdate_dp.Value = dr.GetDateTime("mctdate");
                    requester_tf.Text = dr.GetString("requester");
                    Forwarded_cb.Checked= dr.GetBoolean("isforwarded");
                    txtAreaFrom.Text = dr.GetString("forwardedFrom_");
                    txtAreaTo.Text = dr.GetString("forwardedTo_");
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

        private void loadmctdetails(String mctno)
        {
            String qry = "Select * from mctdetails where mctno = '" + mctno + "' order by sccode,isdebit";
            cmd = new MySqlCommand(qry, conn_tmp);

            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");

            tb_dbGrid.Rows.Clear();
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();
                int rowCnt = 0;
                while (dr.Read())
                {
                    tb_dbGrid.Rows.Add(dr.GetString("accountcode"),
                                       "...",
                                       dr.GetString("accountname"),
                                       dr.GetString("sccode"),
                                       "...",
                                       dr.GetString("particulars"),
                                       dr.GetString("qty"),
                                       dr.GetString("unit"),
                                       dr.GetString("cost"),
                                       dr.GetDouble("debit").ToString("N02", ci),
                                       dr.GetDouble("credit").ToString("N02", ci),
                                       dr.GetString("idmctdetails"),
                                       dr.GetString("idmct"),
                                       dr.GetString("mctno"),
                                       dr.GetString("glaccountcode"),
                                       dr.GetString("glaccountname"),
                                       dr.GetString("date"),
                                       dr.GetString("iditemindex"),
                                       dr.GetString("globalid"),
                                       "0",
                                       dr.GetString("isload"),
                                       dr.GetString("isdebit"));

                    if (dr.GetString("isdebit").Equals("1"))
                    {
                        tb_dbGrid.Rows[rowCnt].Cells[9].Style.ForeColor = Color.Green;//--
                        tb_dbGrid.Rows[rowCnt].Cells[10].Style.ForeColor = Color.Black;//--
                        tb_dbGrid.Rows[rowCnt].Cells[10].ReadOnly = true;

                        tb_dbGrid.Rows[rowCnt].Cells[0].Style.BackColor = Color.Green;//--
                        tb_dbGrid.Rows[rowCnt].Cells[2].Style.BackColor = Color.Green;//--
                    }
                    else if (dr.GetString("isdebit").Equals("0"))
                    {
                        tb_dbGrid.Rows[rowCnt].Cells[9].Style.ForeColor = Color.Black;//--
                        tb_dbGrid.Rows[rowCnt].Cells[10].Style.ForeColor = Color.Red;//--
                        tb_dbGrid.Rows[rowCnt].Cells[9].ReadOnly = true;

                        tb_dbGrid.Rows[rowCnt].Cells[0].Style.BackColor = Color.Red;//--
                        tb_dbGrid.Rows[rowCnt].Cells[2].Style.BackColor = Color.Red;//--
                    }

                    if (dr.GetString("isload").Equals("1"))
                    {
                        tb_dbGrid.Rows[rowCnt].Cells[3].ReadOnly = true;
                        tb_dbGrid.Rows[rowCnt].Cells[4].ReadOnly = true;//--
                        tb_dbGrid.Rows[rowCnt].Cells[5].ReadOnly = true;//--                        
                        //tb_dbGrid.Rows[rowCnt].Cells[8].ReadOnly = true;
                        //tb_dbGrid.Rows[rowCnt].Cells[9].ReadOnly = true;
                    }

                    rowCnt++;
                }

                this.ActiveControl = tb_dbGrid;
                dr.Close();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                conn_tmp.Close();
            }
        }

        private void mctdetailsFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            conn_inv = db_inv.getConn();

            if (this.Text == "Preview MCT Details")
            {
                ref_btn.Enabled = false;
                refno_tf.Enabled = false;
                save_btn.Enabled = false;
                button2.Enabled = false;
                delete_btn.Enabled = false;

                loadmct(mctnoF);
                loadmctdetails(mctnoF);
                sumAmount();
                mctno_tf.ReadOnly = true;


            }
            else if (this.Text == "Update MCT Details")
            {
                ref_btn.Enabled = false;
                mctno_tf.ReadOnly = true;
                //requester_tf.ReadOnly = true;
                //desc_tf.ReadOnly = true;

                loadmct(mctnoF);
                loadmctdetails(mctnoF);
                sumAmount();
            }

            //====PopUp Menu=============
            //popupMenu.Items.Add(new MenuItem("Google", new System.EventHandler(this.popupMenu_ItemClicked)));
            //popupMenu.Items.Add(new MenuItem("Yahoo", new System.EventHandler(this.ItemClick)));
            Image img = null;
            menu_tb.Items.Add("Move Up", img, new System.EventHandler(ContextMenuClick));
            menu_tb.Items.Add("Move Down", img, new System.EventHandler(ContextMenuClick));
            tb_dbGrid.ContextMenuStrip = menu_tb;

            try
            {
                if (mctno_tf.Text.Substring(0, 3) == "MTT")
                    panel6.Enabled = true;
                else
                    panel6.Enabled = false;
            }
            catch
            { }
        }

        private void ContextMenuClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            switch (sender.ToString().Trim())
            {
                case "Move Up":
                    rowUp(tb_dbGrid);
                    break;
                case "Move Down":
                    rowDown(tb_dbGrid);
                    break;
            }

        }

        private void ref_btn_Click(object sender, EventArgs e)
        {
            referencemctFrm frm = new referencemctFrm();

            //===set to global form event============================
            frm.RefreshDgv += new referencemctFrm.DoEvent(sumAmount);

            frm.mctdetailsFrmInitl(this);
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refdetailDatagrid.Rows.Clear();
            int rowcnt = tb_dbGrid.Rows.Count;

            for (int i = 0; i < rowcnt-1; i++)
            {
                try
                {
                    if (tb_dbGrid.Rows[i].Cells[21].Value.ToString().Equals("1"))
                    {
                        refdetailDatagrid.Rows.Add(tb_dbGrid.Rows[i].Cells[6].Value.ToString(),//--
                                                    tb_dbGrid.Rows[i].Cells[5].Value.ToString(),//--
                                                    tb_dbGrid.Rows[i].Cells[7].Value.ToString(),//--
                                                    tb_dbGrid.Rows[i].Cells[8].Value.ToString(),//--
                                                    tb_dbGrid.Rows[i].Cells[10].Value.ToString(),//--
                                                    tb_dbGrid.Rows[i].Cells[17].Value.ToString()//--
                                                    );
                    }

                }
                catch
                { }

            }

            refdetail_p.Location = new Point(148, 83);
            refdetail_p.Visible = true;
            calculateAmnt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refdetail_p.Visible = false;
        }

        private void refdetailDatagrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateAmnt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadDC();
            MessageBox.Show("Please save the MCT details in order to stored records permanently...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            refdetail_p.Visible = false;

        }

        private void loadDC()
        {
            CultureInfo ci = new CultureInfo("en-us");
            int rowcntmctd = tb_dbGrid.Rows.Count;
            int rows_ = tb_dbGrid.Rows.Count;
            int row_ref = refdetailDatagrid.Rows.Count;

            for (int i = 0; i < rowcntmctd - 1; i++)
            {
                for (int a = 0; a < row_ref - 1; a++)
                {
                    try
                    {
                        if ((refdetailDatagrid.Rows[a].Cells[5].Value.ToString() == tb_dbGrid.Rows[i].Cells[17].Value.ToString()))//--
                        {
                            tb_dbGrid.Rows[i].Cells[7].Value = refdetailDatagrid.Rows[a].Cells[2].Value.ToString();//--
                        }
                    }
                    catch
                    { }

                }
            }

            sumAmount();
        }

        private void tb_dbGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sumAmount();
        }
               
        //select check voucher ID=====================================
        private String getmctID(String mctno)
        {
            String id = "0";


            string sql = "SELECT * FROM materialct where mctno = '" + mctno + "'";
            cmd = new MySqlCommand(sql, conn_tmp);

            //OPEN CON
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    id = dr.GetString("idmaterialct");
                }

                dr.Close();
                conn_tmp.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                dr.Close();
                conn_tmp.Close();
            }


            return id;
        }
        private void filterupdateapvd()
        {
            String idmct_f = getmctID(mctno_tf.Text);
            String idmctd_f = "";
            String mctno_f = mctno_tf.Text;
            String sccode_f = "";
            String iditemindex_f = "";
            String globalid_f = "";
            String particulars_f = "";
            String unit_f = "";
            Double qty_f = 0;
            String cost_f = "";
            String accountcode_f = "";
            String accountname_f = "";
            String glaccountcode_f = "";
            String glaccountname_f = "";
            String debit_f = "";
            String credit_f = "";
            String user_f = "";
            Boolean isload_f = false;
            Boolean isdebit_f = false;


            this.isErrUpdate = false;

            // Boolean ifnewref = false;


            String qry = "Select * from mctdetails where idmctdetails = @idmctd and mctno = @mctno";
            int rowcnt = tb_dbGrid.Rows.Count;
            for (int i = 0; i < rowcnt-1 ; i++)
            {
                               
                try
                {
                    idmctd_f = tb_dbGrid.Rows[i].Cells[11].Value.ToString();//--

                    if (idmctd_f == "")
                        idmctd_f = "0";
                }
                catch
                {
                    idmctd_f = "0";
                }

                
                try
                {
                    cmd = new MySqlCommand(qry, conn_tmp);
                    cmd.Parameters.AddWithValue("@idmctd", int.Parse(idmctd_f));
                    cmd.Parameters.AddWithValue("@mctno", mctno_f);

                    conn_tmp.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.Read()) //check voucher update statement========================
                    {
                        dr.Close();
                        conn_tmp.Close();
                        try
                        {
                            sccode_f = tb_dbGrid.Rows[i].Cells[3].Value.ToString();
                            iditemindex_f = tb_dbGrid.Rows[i].Cells[17].Value.ToString();//--
                            globalid_f = tb_dbGrid.Rows[i].Cells[18].Value.ToString();//--
                            particulars_f = tb_dbGrid.Rows[i].Cells[5].Value.ToString();//--
                            unit_f = tb_dbGrid.Rows[i].Cells[7].Value.ToString();//--                            
                            qty_f = Double.Parse(tb_dbGrid.Rows[i].Cells[6].Value.ToString().Replace(",", ""));//--
                            cost_f = tb_dbGrid.Rows[i].Cells[8].Value.ToString().Replace(",", "");//--
                            accountcode_f = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                            accountname_f = tb_dbGrid.Rows[i].Cells[2].Value.ToString();
                            glaccountcode_f = tb_dbGrid.Rows[i].Cells[14].Value.ToString();//--
                            glaccountname_f = tb_dbGrid.Rows[i].Cells[15].Value.ToString();//--
                            debit_f = tb_dbGrid.Rows[i].Cells[9].Value.ToString().Replace(",", "");//--
                            credit_f = tb_dbGrid.Rows[i].Cells[10].Value.ToString().Replace(",", "");//--

                            if (tb_dbGrid.Rows[i].Cells[20].Value.ToString().Equals("1"))//--
                                isload_f = true;
                            else
                                isload_f = false;

                            if (tb_dbGrid.Rows[i].Cells[21].Value.ToString().Equals("1"))//--
                                isdebit_f = true;
                            else
                                isdebit_f = false;

                            if (sccode_f == "")
                                cost_f = debit_f;
                        }
                        catch
                        { }

                        updatemctdetail(idmctd_f, idmct_f, mctno_f, sccode_f, iditemindex_f, globalid_f, particulars_f, unit_f, qty_f, cost_f,
                                        accountcode_f, accountname_f, glaccountcode_f, glaccountname_f, debit_f, credit_f, user_f,isload_f,isdebit_f);


                    }
                    else //check voucher insert statement===========================================
                    {
                        dr.Close();
                        conn_tmp.Close();

                        
                        sccode_f = tb_dbGrid.Rows[i].Cells[3].Value.ToString();
                        try
                        {
                            iditemindex_f = tb_dbGrid.Rows[i].Cells[17].Value.ToString();//--
                        }
                        catch { }

                        try
                        {
                            globalid_f = tb_dbGrid.Rows[i].Cells[18].Value.ToString();//--
                        }
                        catch { }

                        particulars_f = tb_dbGrid.Rows[i].Cells[5].Value.ToString();//--  
                        try
                        {
                            unit_f = tb_dbGrid.Rows[i].Cells[7].Value.ToString();//--
                        }
                        catch { }

                        //try
                        //{
                        qty_f = Double.Parse(tb_dbGrid.Rows[i].Cells[6].Value.ToString().Replace(",", ""));//--
                        //}
                        //catch { }

                        try
                        {
                            cost_f = tb_dbGrid.Rows[i].Cells[8].Value.ToString().Replace(",", "");//--
                        }
                        catch { }

                        try
                        {
                            accountcode_f = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                        }
                        catch { }

                        try
                        {
                            accountname_f = tb_dbGrid.Rows[i].Cells[2].Value.ToString();
                        }
                        catch { }

                        try
                        {
                            glaccountcode_f = tb_dbGrid.Rows[i].Cells[14].Value.ToString();//--
                        }
                        catch { }
                        try
                        {
                            glaccountname_f = tb_dbGrid.Rows[i].Cells[15].Value.ToString();//--
                        }
                        catch { }
                        try
                        {
                            debit_f = tb_dbGrid.Rows[i].Cells[9].Value.ToString().Replace(",", "");//--
                        }
                        catch { }
                        try
                        {
                            credit_f = tb_dbGrid.Rows[i].Cells[10].Value.ToString().Replace(",", "");//--
                        }
                        catch { }



                            if (sccode_f == "")
                                cost_f = debit_f;
                        

                        /* if (!(ifnewref))
                         {
                             deleteapvdetails(idapv_f);
                             ifnewref = true;
                         }*/

                        try
                        {
                            if (tb_dbGrid.Rows[i].Cells[20].Value.ToString().Equals("1"))//--
                                isload_f = true;
                            else
                                isload_f = false;
                        }
                        catch
                        {
                            isload_f = false;
                        }


                        try
                        {
                            if (tb_dbGrid.Rows[i].Cells[21].Value.ToString().Equals("1"))//--
                                isdebit_f = true;
                            else
                                isdebit_f = false;
                        }
                        catch
                        {
                            isdebit_f = false;
                        }

                        //MessageBox.Show("Ronel ", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        insertmctdetail(idmct_f, mctno_f, sccode_f, iditemindex_f, globalid_f, particulars_f, unit_f, qty_f, cost_f, accountcode_f, accountname_f, glaccountcode_f,
                                        glaccountname_f, debit_f, credit_f, isload_f, isdebit_f);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //   dr.Close();
                    conn_tmp.Close();

                    break;
                }

                idmctd_f = "";
                sccode_f = "";
                iditemindex_f = "";
                globalid_f = "";
                particulars_f = "";
                unit_f = "";
                qty_f = 0;
                cost_f = "";
                accountcode_f = "";
                accountname_f = "";
                glaccountcode_f = "";
                glaccountname_f = "";
                debit_f = "";
                credit_f = "";
                user_f = "";

            }


        }

        private void insertmct(DateTime _mctdate, DateTime _date, String _mctno, String _refno, String _desc, String _requester, String _amount)
        {
            String qry = "insert into materialct(mctdate,mctno,refno,description,requester,amount,date,userid,isForwarded,forwardedFrom,forwardedTo)" +
                         " values (@mctdate,@mctno,@refno,@description,@requester,@amount,@date,@userid,@isForwarded,@forwardedFrom,@forwardedTo)";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@mctdate", _mctdate);
            cmd.Parameters.AddWithValue("@mctno", _mctno);
            cmd.Parameters.AddWithValue("@refno", _refno);
            cmd.Parameters.AddWithValue("@description", _desc);
            cmd.Parameters.AddWithValue("@requester", _requester);
            cmd.Parameters.AddWithValue("@date", _date);
            cmd.Parameters.AddWithValue("@userid", globalmainFrm.userlog);
            cmd.Parameters.AddWithValue("@amount", Double.Parse(_amount));
            cmd.Parameters.AddWithValue("@forwardedFrom", txtAreaFrom.Text);
            cmd.Parameters.AddWithValue("@forwardedTo", txtAreaTo.Text);

            if (Forwarded_cb.Checked)
            {
                cmd.Parameters.AddWithValue("@isForwarded", "1");
            }
            else
            {
                cmd.Parameters.AddWithValue("@isForwarded", "0");
            }
            


            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MCT detail add ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }
                
        private void updatemct(String _mctno, String _refno, String _amount, String _requester, String _desc)
        {
            String qry = "update materialct set refno = @refno, " +
                           "                   amount = @amount," +
                           "                   isforwarded = @isforwarded," +
                           "                   forwardedFrom = @forwardedFrom," +
                           "                   forwardedTo = @forwardedTo, " +
                           "                   refno = @refno," +
                           "                   description = @description," +
                           "                   requester = @requester " +
                           " where mctno = @mctno";

            try
            {
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@refno", _refno);
                cmd.Parameters.AddWithValue("@amount", Double.Parse(_amount));
                cmd.Parameters.AddWithValue("@mctno", _mctno);
                cmd.Parameters.AddWithValue("@description", _desc);
                cmd.Parameters.AddWithValue("@requester", _requester);
                cmd.Parameters.AddWithValue("@forwardedFrom", txtAreaFrom.Text);
                cmd.Parameters.AddWithValue("@forwardedTo", txtAreaTo.Text);

                if(Forwarded_cb.Checked)               
                    cmd.Parameters.AddWithValue("@isforwarded", "1");
                else
                    cmd.Parameters.AddWithValue("@isforwarded", "0");

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MCT update ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

        private void insertmctdetail(String idmct, String mctno, String sccode, String iditemindex, String globalid, String particulars, String unit, Double qty, String cost, String accountcode, String accountname, String glaccountcode, String glaccountname, String debit, String credit, Boolean isload, Boolean isdebit)
        {
            String qry = "insert into mctdetails( idmct,mctno,sccode,iditemindex,globalid,particulars,unit,qty,cost,accountcode,accountname,glaccountcode,glaccountname,debit,credit,date,userid,isload,isdebit)" +
                         " values (@idmct,@mctno,@sccode,@iditemindex,@globalid,@particulars,@unit,@qty,@cost,@accountcode,@accountname,@glaccountcode,@glaccountname,@debit,@credit,@date,@userid,@isload,@isdebit)";


            try
            {
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@idmct", int.Parse(idmct));
                cmd.Parameters.AddWithValue("@mctno", mctno);
                cmd.Parameters.AddWithValue("@sccode", sccode);
                cmd.Parameters.AddWithValue("@iditemindex", iditemindex);
                cmd.Parameters.AddWithValue("@globalid", globalid);
                cmd.Parameters.AddWithValue("@particulars", particulars);
                cmd.Parameters.AddWithValue("@unit", unit);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@cost", Double.Parse(cost));
                cmd.Parameters.AddWithValue("@accountcode", accountcode);
                cmd.Parameters.AddWithValue("@accountname", accountname);
                cmd.Parameters.AddWithValue("@glaccountcode", glaccountcode);
                cmd.Parameters.AddWithValue("@glaccountname", glaccountname);
                cmd.Parameters.AddWithValue("@debit", Double.Parse(debit));
                cmd.Parameters.AddWithValue("@credit", Double.Parse(credit));
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@userid", globalmainFrm.userlog);
                cmd.Parameters.AddWithValue("@isload", isload);
                cmd.Parameters.AddWithValue("@isdebit", isdebit);

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("MCT detail add ROERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }

        }


        private void updatemctdetail(String idmctd, String idmct, String mctno, String sccode, String iditemindex, String globalid, String particulars, String unit, Double qty, String cost, String accountcode, String accountname, String glaccountcode, String glaccountname, String debit, String credit, String user, Boolean isload, Boolean isdebit)
        {
            String qry = "update mctdetails set idmct = @idmct, " +
                         "                     mctno = @mctno," +
                         "                     sccode = @sccode," +
                         "                     iditemindex = @iditemindex," +
                         "                     globalid = @globalid," +
                         "                     particulars = @particulars," +
                         "                     unit = @unit, " +
                         "                     qty = @qty, " +
                         "                     cost = @cost, " +
                         "                     accountcode = @accountcode, " +
                         "                     accountname = @accountname, " +
                         "                     glaccountcode = @glaccountcode," +
                         "                     glaccountname = @glaccountname," +
                         "                     debit = @debit," +
                         "                     credit = @credit," +
                         "                     date = @date," +
                         "                     userid = @user," +
                         "                     isload = @isload," +
                         "                     isdebit = @isdebit " +

                         " where idmctdetails = @idmctd";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@idmctd", int.Parse(idmctd));
            cmd.Parameters.AddWithValue("@idmct", int.Parse(idmct));
            cmd.Parameters.AddWithValue("@mctno", mctno);
            cmd.Parameters.AddWithValue("@sccode", sccode);
            cmd.Parameters.AddWithValue("@iditemindex", iditemindex);
            cmd.Parameters.AddWithValue("@globalid", globalid);
            cmd.Parameters.AddWithValue("@particulars", particulars);
            cmd.Parameters.AddWithValue("@unit", unit);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@cost", Double.Parse(cost));
            cmd.Parameters.AddWithValue("@accountcode", accountcode);
            cmd.Parameters.AddWithValue("@accountname", accountname);
            cmd.Parameters.AddWithValue("@glaccountcode", glaccountcode);
            cmd.Parameters.AddWithValue("@glaccountname", glaccountname);
            cmd.Parameters.AddWithValue("@debit", Double.Parse(debit));
            cmd.Parameters.AddWithValue("@credit", Double.Parse(credit));
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@isload", isload);
            cmd.Parameters.AddWithValue("@isdebit", isdebit);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MCT detail update ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();

            }
        }

        private void tb_dbGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String code_ = "";
            var senderGrid = (DataGridView)sender;
            String isload = "0";
            String idmctd__ = "0";

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                //rowIndex_ = tb_dbGrid.SelectedCells[0].RowIndex;
                int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];
                try
                {
                    isload = sRow.Cells[20].Value.ToString();
                }                    
                catch
                { }

                if (e.ColumnIndex == 1)
                {                   

                    /*try
                    {
                        if (sRow.Cells[20].Value.ToString().Equals("1"))
                            return;
                    }
                    catch
                    { }*/
                                        
                    selectChartFrm frm = new selectChartFrm();
                    frm.mctdetailsFrmInitl(this);
                    frm.Text = "Material Charge Ticket";

                    try
                    {
                        code_ = sRow.Cells[0].Value.ToString();
                    }
                    catch
                    { }

                    frm.setAccountcode(code_);

                    frm.ShowDialog();
                }
                else if ((e.ColumnIndex ==4) && (!(isload.Equals("1"))) )
                {
                    selectitemindexFrm frm = new selectitemindexFrm();
                    frm.mctdetailsFrmInitl(this);
                    //frm.Text = "Material Charge Ticket";
                    try
                    {
                        idmctd__= sRow.Cells[11].Value.ToString();                      
                    }
                    catch
                    {}

                    try
                    {
                        if (sRow.Cells[21].Value.ToString().Equals("1"))
                            frm.setDebitcredit(sRow.Cells[9].Value.ToString());
                        else
                            frm.setDebitcredit(sRow.Cells[10].Value.ToString());
                    }
                    catch { }
                    
                    frm.setIdmctd(idmctd__);                                        
                    frm.ShowDialog();
                }
            }
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            printmct();
        }
        private void printmct()
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            mctRpt myReport = new mctRpt();
            DataTable dt = new DataTable();
            dt.Columns.Add("acode", typeof(string));
            dt.Columns.Add("aname", typeof(string));
            dt.Columns.Add("particulars", typeof(string));
            dt.Columns.Add("qty", typeof(int));
            dt.Columns.Add("unit", typeof(string));
            dt.Columns.Add("cost", typeof(Double));
            dt.Columns.Add("glacode", typeof(string));
            dt.Columns.Add("glaname", typeof(string));
            dt.Columns.Add("debit", typeof(Double));
            dt.Columns.Add("credit", typeof(Double));
            dt.Columns.Add("date", typeof(DateTime));
            dt.Columns.Add("sccode", typeof(string));

            //set report and view===============
            try
            {



                int rowCnt = tb_dbGrid.Rows.Count;
                int cnt = 0;
                foreach (DataGridViewRow dgv in tb_dbGrid.Rows)
                {
                    if (cnt < rowCnt - 1)
                    {
                        dt.Rows.Add(dgv.Cells[0].Value,
                                    dgv.Cells[2].Value,
                                    dgv.Cells[5].Value,//--
                                    dgv.Cells[6].Value,//--
                                    dgv.Cells[7].Value,//--
                                    dgv.Cells[8].Value,//--
                                    dgv.Cells[14].Value,//--
                                    dgv.Cells[15].Value,//--
                                    dgv.Cells[9].Value,//--
                                    dgv.Cells[10].Value,//--
                                    dgv.Cells[16].Value,//--
                                    dgv.Cells[3].Value);
                        cnt++;
                    }
                }

                if (dt.Rows.Count > 0)
                {

                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "mct";

                    myReport.SetDataSource(ds);
                    myReport.SetParameterValue("mctno", mctno_tf.Text);
                    myReport.SetParameterValue("mctdate", mctdate_dp.Value);
                    myReport.SetParameterValue("date", date_dp.Value);
                    myReport.SetParameterValue("desc", desc_tf.Text);
                    myReport.SetParameterValue("refno", refno_tf.Text);
                    myReport.SetParameterValue("requester", requester_tf.Text);
                    myReport.SetParameterValue("forwardedArea", txtAreaFrom.Text+"-"+txtAreaTo.Text);

                    if(mctno_tf.Text.Substring(0,3)=="MTT")
                    {
                        myReport.SetParameterValue("header", "MATERIAL TRANSFER TICKET");
                        myReport.SetParameterValue("forwarded", "Forwarded");
                        myReport.SetParameterValue("forwardedArea", txtAreaFrom.Text+" - "+txtAreaTo.Text);
                    }
                    else
                    {
                        myReport.SetParameterValue("header", "MATERIAL CHARGE TICKET");
                        myReport.SetParameterValue("forwarded", "");
                        myReport.SetParameterValue("forwardedArea", "");
                    }

                    frm.crystalRptViewer.ReportSource = myReport;
                    frm.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mctRecap_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            recapPanel.Location = new Point(148, 83);
            recapPanel.Visible = true;
        }

        private void printmctRecap()
        {
            List<string> itemcodeList = new List<string>();
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            mctRecap myReport = new mctRecap();
            DataTable mctRecapTable = new DataTable();




            String qry = " Select           " +
                         "      fnl.Itemcode,           " +
                         "      fnl.Description,           " +
                         "      fnl.preUnit,            " +
                         "      fnl.prevamount,           " +
                         "      fnl.Receipt,           " +
                         "      fnl.Issuance,           " +
                         "      fnl.isReturn,              " +
                         "      fnl.presUnit,                " +
                         "      format(fnl.presAmount, 2) presAmount,           " +
                         "      if (fnl.presUnit > 0 ,           " +
                         "        format(fnl.presAmount / fnl.presUnit, 2),0) Average,           ";

            //==================================
            //==================================
            if (!(isAllItem.Checked))
            {
                qry = qry + "      Concat('Covered Period : ','" + mctdate_dp.Value.ToString("M/d/yyyy") + " - " + mctdate_dp.Value.ToString("M/d/yyyy") + "'" + ") datecovered, '' tmp ";
            }
            else
            {
                qry = qry + "      Concat('Covered Period : ','" + from_dp.Value.ToString("M/d/yyyy") + " - " + To_dp.Value.ToString("M/d/yyyy") + "'" + ") datecovered, '' tmp ";
            }

            //===================================
            //===================================
            qry = qry + "  from           " +
                         "    (           " +
                         "     Select           " +
                         "      f.iicode Itemcode,           " +
                         "      f.iiname Description,           " +
                         "      (f.PrevTotalReceipts - f.PrevTotalIssuance) preUnit,           " +
                         "      format((f.PrevTotalReceiptsAmount - f.PrevTotalIssuanceAmount), 2)  prevamount,           " +
                         "      f.PresTotalReceipts Receipt,           " +
                         "      f.PresTotalIssuance Issuance,           " +
                         "      f.PresTotalMCrT isReturn,           " +
                         "      (f.PrevTotalReceipts - f.PrevTotalIssuance) +           " +
                         "      (f.PresTotalReceipts - f.PresTotalIssuance) +           " +
                         "      f.PresTotalMCrT  presUnit,            " +
                         "      (f.PrevTotalReceiptsAmount - f.PrevTotalIssuanceAmount) +           " +
                         "      (f.PresTotalReceiptsAmount - f.PresTotalIssuanceAmount)  presAmount            " +
                         "     from           " +
                         "       (           " +
                         "        select ItemIndex.IICode,           " +
                         "               ItemIndex.IIName,           ";

            //============================================
            //============================================
            if (!(isAllItem.Checked))
            {
                qry = qry + "          sum(If(scdate < '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' , ifnull(stockcard.screceipts, 0), 0)) PrevTotalReceipts,           " +
                        "              sum(If(scdate < '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuance, 0), 0)) PrevTotalIssuance,           " +
                        "              sum(If(scdate < '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.screceiptsAmount, 0), 0)) PrevTotalReceiptsAmount,           " +
                        "              sum(If(scdate < '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuanceAmount, 0), 0)) PrevTotalIssuanceAmount,           " +
                        "              sum(If(scdate between '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument not like '%MCrT%' and scdocument not like '%ADJ%', ifnull(stockcard.screceipts, 0), 0)) PresTotalReceipts,           " +
                        "              sum(If(scdate between '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%MCrT%', ifnull(stockcard.screceipts, 0), 0)) PresTotalMCrT,           " +
                        "              sum(If(scdate between '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument not like '%ADJ%', ifnull(stockcard.scIssuance, 0), 0)) PresTotalIssuance,           " +
                        "              sum(If(scdate between '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%ADJ%', ifnull(stockcard.scIssuance, 0), 0)) PresTotalAdjIssuance,           " +
                        "              sum(If(scdate between '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%ADJ%', ifnull(stockcard.scReceipts, 0), 0)) PresTotalAdjReceipts,           " +
                        "              sum(If(scdate between '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.screceiptsAmount, 0), 0)) PresTotalReceiptsAmount,           " +
                        "              sum(If(scdate between '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuanceAmount, 0), 0)) PresTotalIssuanceAmount           " +
                        "       from ItemIndex           " +
                        "       left join stockcard on (ItemIndex.iicode = stockcard.sccode)           " +
                        "       where stockcard.scaverage <> 0 ";
            }
            else
            {
                qry = qry + "          sum(If(scdate < '" + from_dp.Value.ToString("yyyy-MM-dd") + "' , ifnull(stockcard.screceipts, 0), 0)) PrevTotalReceipts,           " +
                        "              sum(If(scdate < '" + from_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuance, 0), 0)) PrevTotalIssuance,           " +
                        "              sum(If(scdate < '" + from_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.screceiptsAmount, 0), 0)) PrevTotalReceiptsAmount,           " +
                        "              sum(If(scdate < '" + from_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuanceAmount, 0), 0)) PrevTotalIssuanceAmount,           " +
                        "              sum(If(scdate between '" + from_dp.Value.ToString("yyyy-MM-dd") + "' and '" + To_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument not like '%MCrT%' and scdocument not like '%ADJ%', ifnull(stockcard.screceipts, 0), 0)) PresTotalReceipts,           " +
                        "              sum(If(scdate between '" + from_dp.Value.ToString("yyyy-MM-dd") + "' and '" + To_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%MCrT%', ifnull(stockcard.screceipts, 0), 0)) PresTotalMCrT,           " +
                        "              sum(If(scdate between '" + from_dp.Value.ToString("yyyy-MM-dd") + "' and '" + To_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument not like '%ADJ%', ifnull(stockcard.scIssuance, 0), 0)) PresTotalIssuance,           " +
                        "              sum(If(scdate between '" + from_dp.Value.ToString("yyyy-MM-dd") + "' and '" + To_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%ADJ%', ifnull(stockcard.scIssuance, 0), 0)) PresTotalAdjIssuance,           " +
                        "              sum(If(scdate between '" + from_dp.Value.ToString("yyyy-MM-dd") + "' and '" + To_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%ADJ%', ifnull(stockcard.scReceipts, 0), 0)) PresTotalAdjReceipts,           " +
                        "              sum(If(scdate between '" + from_dp.Value.ToString("yyyy-MM-dd") + "' and '" + To_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.screceiptsAmount, 0), 0)) PresTotalReceiptsAmount,           " +
                        "              sum(If(scdate between '" + from_dp.Value.ToString("yyyy-MM-dd") + "' and '" + To_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuanceAmount, 0), 0)) PresTotalIssuanceAmount           " +
                        "       from ItemIndex           " +
                        "       left join stockcard on (ItemIndex.iicode = stockcard.sccode)           " +
                        "       where stockcard.scaverage <> 0 ";
            }


            //=========================================
            //=========================================
            if (!(isAllItem.Checked))
            {
                qry = qry + " and ItemIndex.IICode in (";

                int rowCnt = tb_dbGrid.Rows.Count;
                Boolean startloop = true;
                foreach (DataGridViewRow dgv in tb_dbGrid.Rows)
                {
                    try
                    {
                        if (startloop)
                        {
                            qry = qry + "'" + dgv.Cells[3].Value.ToString() + "'";
                            startloop = false;
                        }
                        else
                            qry = qry + ",'" + dgv.Cells[3].Value.ToString() + "'";

                    }
                    catch
                    { }

                }

                if (rowCnt == 1)
                    qry = qry + "'~~'";

                qry = qry + "       ) group by iicode           " +
                           "       ) f           " +
                           "       ) fnl           " +
                           "       order by fnl.Itemcode           ";
            }
            else
            {
                qry = qry + "      group by iicode           " +
                           "       ) f           " +
                           "       ) fnl           " +
                           "       order by fnl.Itemcode           ";
            }

            try
            {
                da = new MySqlDataAdapter(qry, conn_inv);
                conn_inv.Open();
                da.Fill(mctRecapTable);

                da.Dispose();
                ds.Tables.Add(mctRecapTable);
                ds.Tables[0].TableName = "mctRecap";

                conn_inv.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_inv.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            recapPanel.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            printmctRecap();
        }

        private void tb_dbGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            /*int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];

            try
            {
                if (sRow.Cells[3].Value.ToString() != "")
                { 
                    sRow.Cells[8].ReadOnly = true;
                    sRow.Cells[8].Value = "0.00";
                }
            }
            catch
            { }*/

            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            int columnIndex = tb_dbGrid.CurrentCell.ColumnIndex;

            DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];


            if ((columnIndex != 9) && (columnIndex != 10) && (columnIndex != 0) && (columnIndex != 2))
            {
                sRow.Cells[columnIndex].Style.BackColor = Color.LightBlue;
                sRow.Cells[columnIndex].Style.ForeColor = Color.Black;
                sRow.Cells[columnIndex].Style.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            }
            
            
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];
            String idmctd = "0";
            String desc = "";
            Boolean isload = false;

            try
            {
                idmctd = sRow.Cells[11].Value.ToString();//--
            }
            catch
            { }

            try
            {
                desc = sRow.Cells[5].Value.ToString();//--
            }
            catch
            { }

            try
            {
                if (sRow.Cells[20].Value.ToString().Equals("1"))//--
                    isload = true;
                else
                    isload = false;
            }
            catch
            {
                isload = false;
            }

            try
            {
                //if (!(isload))
                //{
                    DialogResult d = MessageBox.Show(desc + "\n Are you sure you want to delete this row?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (d == DialogResult.Yes)
                    {
                        tb_dbGrid.Rows.RemoveAt(selectedrowindex);
                        deletemctdetail(idmctd);
                        sumAmount();

                    }
                //}

            }
            catch
            { }
        }

        private void deletemctdetail(String id)
        {
            String qry = "Delete from mctdetails where idmctdetails = '" + id + "'";

            cmd = new MySqlCommand(qry, conn_tmp);
            conn_tmp.Open();

            try
            {
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }

        }

        private void mctdetailsFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RefreshDgv();
        }

        private void rowUp(DataGridView dgv)
        {
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex - 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
            }
            catch { }

        }

        private void rowDown(DataGridView dgv)
        {
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex + 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
            catch { }

        }

        

        private void tb_dbGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //popupMenu.Show(tb_dbGrid, new Point(e.X, e.Y));
                int currentMouseOverRow = tb_dbGrid.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    menu_tb.Items.Add(string.Format("", currentMouseOverRow.ToString()));
                }
                menu_tb.Show(tb_dbGrid, new Point(e.X, e.Y));

            }                        
        }

        private void popupMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void popupMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            /*var m = (MenuItem)sender;

            if (m.Text == "Move Up")
            {
                rowUp(tb_dbGrid);
            }
            else if(m.Text == "Move Down")
            {
                rowDown(tb_dbGrid);
            }*/

        }

        private void Forwarded_cb_Click(object sender, EventArgs e)
        {
            if(Forwarded_cb.Checked)
            {
                panel8.Location = new Point(168, 123);
                panel8.Visible = true;

                areaFrom_cb.SelectedIndex = areaFrom_cb.FindStringExact("DMO");
                areaTo_cb.SelectedIndex = areaTo_cb.FindStringExact("DMO");
                panel3.Enabled = false;
                panel4.Enabled = false;
                // bank_cb.SelectedIndex = bank_cb.FindStringExact(dr.GetString("bank"));

            }
            else
            {                              

                txtAreaFrom.Text = "";
                txtAreaTo.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Forwarded_cb.Checked = false;
            panel8.Visible = false;
            panel3.Enabled = true;
            panel4.Enabled = true;
        }

        private void Forwarded_cb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void forwardedProceed_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtAreaFrom.Text = areaFrom_cb.Text;
            txtAreaTo.Text = areaTo_cb.Text;
            panel8.Visible = false;
            panel3.Enabled = true;
            panel4.Enabled = true;

        }

        //===Numeric Input only=========================
        //==============================================
        private void tb_dbGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {       
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);            

            if ((tb_dbGrid.CurrentCell.ColumnIndex == 9) || (tb_dbGrid.CurrentCell.ColumnIndex == 10))//Desired Column//--
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);                    
                }
            }

           
            /* int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
             int columnIndex = tb_dbGrid.CurrentCell.ColumnIndex;
             DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];

             sRow.Cells[columnIndex].Style.BackColor = Color.LightBlue;
             sRow.Cells[columnIndex].Style.ForeColor = Color.Black;*/

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

        private void date_dp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tb_dbGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tb_dbGrid_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void tb_dbGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = 0;
            int columnIndex = 0;
            Boolean isload = false;

            try
            {
                selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
                columnIndex = tb_dbGrid.CurrentCell.ColumnIndex;        
                               
            }
            catch
            { }

            DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];

            try
            {
                if (sRow.Cells[20].Value.ToString().Equals("1"))//--
                    isload = true;
                else
                    isload = false;

            }
            catch
            {
                isload = false;
            }

            if ((isload) && (columnIndex!=9) && (columnIndex!=10) && (columnIndex != 0) && (columnIndex != 2))
            {
                sRow.Cells[columnIndex].Style.BackColor = Color.White;
                sRow.Cells[columnIndex].Style.ForeColor = Color.Black;
                sRow.Cells[columnIndex].Style.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                //Microsoft Sans Serif, 9pt
            }else if ((!(isload)) && (columnIndex != 9) && (columnIndex != 10))
            {
                sRow.Cells[columnIndex].Style.BackColor = Color.LightCyan;
                sRow.Cells[columnIndex].Style.ForeColor = Color.Black;
                sRow.Cells[columnIndex].Style.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);                
            }
        }

        //================================================
        //================================================
    }
}

