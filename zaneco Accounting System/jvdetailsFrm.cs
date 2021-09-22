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
    public partial class jvdetailsFrm : Form
    {
        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        private MySqlDataAdapter da;
        private unitClass uc = new unitClass();

        private journalFrm journal_frm = new journalFrm();

        //private static Double cvAmount = 0.00;
        private static String idjv = "0";
        private static String jvno_tmp = "";
        private static Boolean isnotify = false;
        private static String emptCode = "";        

        private Boolean isErrUpdate = false;

        private ContextMenuStrip menu_tb = new ContextMenuStrip();
        public jvdetailsFrm()
        {
            InitializeComponent();
        }

        public void setjvno(String jno)
        {
            jvno_tmp = jno;
        }

        public void setIsnotify(Boolean isntfy)
        {
            isnotify = isntfy;
        }

        public void frmjournalInitl(journalFrm journal_frm1)
        {
            journal_frm = journal_frm1;
        }
        
        private void jvcounter()
        {
            String qry = "Select * from counterjv where yymm = '" + DateTime.Now.ToString("yMM") + "' order by idcounterjv desc limit 1";
            int cntr = 1;

            jvnumber_lb.Text = "";
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

                    String num = cntr.ToString();
                    jvnumber_lb.Text = "JV" + DateTime.Now.ToString("yMM") + "-" + num.PadLeft(3, '0');
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                db_tmp.CloseConnection();
            }
        }

        
        private void sumDC()
        {
            Double debit_ = 0.00;
            Double credit_ = 0.00;
            Double bal_ = 0.00;

            //String code_ = "";
            //String name_ = "";
            //Boolean osf = false;
            //Double cashFund = 0.00;

            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");
            
            //=================================
            //=================================
            //foreach (DataGridViewRow row in tb_dbGrid.Rows)
            int rowcnt = tb_dbGrid.Rows.Count;
            for(int i=0; i<rowcnt-1; i++)
            {
                /*try
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
                { }*/


               try
               {                    
                    debit_ = debit_ + Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",",""));                    
                }            
               catch
               { }

                try
                {                    
                    credit_ = credit_ + Double.Parse(tb_dbGrid.Rows[i].Cells[5].Value.ToString().Replace(",", ""));                  

                }
                catch
                { }

                try
                {
                    if (tb_dbGrid.Rows[i].Cells[0].Value.ToString().Equals(""))
                    {
                        tb_dbGrid.Rows[i].Cells[0].Style.BackColor = Color.Pink;
                        emptCode = "Please complete '" + tb_dbGrid.Rows[i].Cells[3].Value.ToString() + "' entry ";
                    }
                    else
                    {
                        tb_dbGrid.Rows[i].Cells[0].Style.BackColor = Color.White;
                    }
                }
                catch
                { }
                                
                /*  try
                  {
                      cashFund = Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", ""));                    

                      if ((osf == false) && (Boolean.Parse(tb_dbGrid.Rows[i].Cells[7].Value.ToString())) && (cashFund > 0.0))
                      {
                          codetmp_tf.Text = code_;
                          accountnametmp_tf.Text = name_;
                          osf = true;
                      }
                  }
                  catch
                  { }*/

                /* try
                 {
                     if (Boolean.Parse(tb_dbGrid.Rows[i].Cells[7].Value.ToString()))
                     {
                         cvAmount = cvAmount + Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", ""));
                     }
                 }
                 catch
                 { }  */



            }

            bal_ = debit_ - credit_;
            debitTotal_lb.Text = "P "+debit_.ToString("N02",ci);
            creditTotal_lb.Text = "P "+credit_.ToString("N02",ci);
            bal_lb.Text = bal_.ToString("N02",ci);
            jvamount_tf.Text = debit_.ToString("N02", ci);
            //amountWords_tf.Text = uc.ToWords(cvAmount);

            //=================================
            //=================================
            for (int i= 0; i < rowcnt - 1; i++)
            {
                try
                {
                    tb_dbGrid.Rows[i].Cells[4].Value = Double.Parse(tb_dbGrid.Rows[i].Cells[4].Value.ToString()).ToString("N02",ci);
                }
                catch
                { }

                try
                {
                    tb_dbGrid.Rows[i].Cells[5].Value = Double.Parse(tb_dbGrid.Rows[i].Cells[5].Value.ToString()).ToString("N02", ci); // "0.00";
                }
                catch
                { }
            }
        }
             
        private void jvdetailsFrm_Load(object sender, EventArgs e)
        {

            conn_tmp = db_tmp.getConn();
            if (this.Text == "Add Journal Voucher Entry")
            {
                jvcounter();
                print_btn.Enabled = false;

                if(isnotify)
                {
                    jvReferencesFrm frm = new jvReferencesFrm();
                    frm.jvdetailsFrmInitl(this);

                    if(isnotify)
                        frm.setIsnotify(true);

                    frm.ShowDialog();
                }
            }
            else if (this.Text == "Update Journal Voucher Entry")
            {
                ref_btn.Enabled = false;                
                loadjvdetails(jvno_tmp);
                loadFilteredJV(jvno_tmp);
            }
            else if (this.Text == "Preview Journal Voucher Entry")
            {
                loadjvdetails(jvno_tmp);
                loadFilteredJV(jvno_tmp);

                jvnumber_lb.ReadOnly = true;
                delete_btn.Enabled = false;
                save_btn.Enabled = false;
                tb_dbGrid.ReadOnly = true;
            }

            //========================================
            menu_tb.Items.Add("Move Up", null, new System.EventHandler(ContextMenuClick));
            menu_tb.Items.Add("Move Down", null, new System.EventHandler(ContextMenuClick));
            tb_dbGrid.ContextMenuStrip = menu_tb;
        }
        
        private void ContextMenuClick(object sender, EventArgs e)
        {
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

        
        private void rowDown(DataGridView dgv)
        {
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;

                if (rowIndex == totalRows - 1)
                    return;

                String rowColA = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                String rowColB = dgv.Rows[rowIndex + 1].Cells[7].Value.ToString();

                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex + 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;

                dgv.Rows[rowIndex].Cells[7].Value = rowColA;
                dgv.Rows[rowIndex + 1].Cells[7].Value = rowColB;
            }
            catch { }

        }

        private void rowUp(DataGridView dgv)
        {
            try
            {
                int totalRows = dgv.Rows.Count;
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                
                if (rowIndex == 0)
                    return;

                String rowColA = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                String rowColB = dgv.Rows[rowIndex-1].Cells[7].Value.ToString();

                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex - 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;

                dgv.Rows[rowIndex].Cells[7].Value = rowColA;
                dgv.Rows[rowIndex - 1].Cells[7].Value = rowColB;
            }
            catch { }
        }
       

        private void tb_dbGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    tb_dbGrid.Rows[e.RowIndex].Cells[5].Value = "0.00";
                }
                else if (e.ColumnIndex == 5)
                {
                    tb_dbGrid.Rows[e.RowIndex].Cells[4].Value = "0.00";
                }
            }

            sumDC();
        }

        private void tb_dbGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            sumDC();
            
            try
            {
                int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
                int columnIndex = tb_dbGrid.CurrentCell.ColumnIndex;

                DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];
                sRow.Cells[columnIndex].Style.BackColor = Color.White;
                sRow.Cells[columnIndex].Style.ForeColor = Color.Black;
                sRow.Cells[columnIndex].Style.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            catch { }            
            
        }

        private void tb_dbGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            String code_ = "";

            

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                //rowIndex_ = tb_dbGrid.SelectedCells[0].RowIndex;

                if (e.ColumnIndex == 1)
                {
                    selectChartFrm frm = new selectChartFrm();
                    frm.frmjournalvInitl(this);
                    frm.Text = "journal vouvher";
                    frm.setDoctype("journalv");

                    int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
                    DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];

                    try
                    {
                        code_ = sRow.Cells[0].Value.ToString();
                    }
                    catch
                    { }

                    frm.setAccountcode(code_);

                    frm.ShowDialog();
                }
                else if(e.ColumnIndex==9)
                {

                    DataGridViewRow sRow;
                    int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
                    sRow = tb_dbGrid.Rows[selectedrowindex];

                    try
                    {
                        if (sRow.Cells[10].Value.ToString().Length > 0)
                        {
                            DialogResult d = MessageBox.Show("Job: " + sRow.Cells[10].Value.ToString() + "\nAre you sure you want to remove this job code?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (d == DialogResult.Yes)
                            {
                                sRow.Cells[9].Value = "...";
                                sRow.Cells[10].Value = "";
                                sRow.Cells[11].Value = "";
                                return;
                                
                            }
                            
                        }
                    }
                    catch { }
                    
                   


                    SelectjobFrm frm = new SelectjobFrm();
                    frm.jvdetailsFrmInitl(this);                    
                    frm.ShowDialog();

                    /*selectPayeeFrm frm = new selectPayeeFrm();
                    frm.frmjournalvInitl(this);
                    frm.Text = "journal voucher";
                    frm.ShowDialog();*/
                }
            }
        }

        
         //INSERT INTO journal voucher===================================
        private void addjv()
        {
           // String cvdate = "";
           // String rvdate = "";
           // String cvdateVar = "";
           // String rvdateVar = "";


            //====CHECK Collection if exists==============================
            //============================================================
            /*String qryC = "Select * from journalv where jvdate = '" + jvDate_dp.Value.ToString("yyyy-MM-dd") + "' and collarea = '"+ collarea_tf .Text+ "'";
                       
            try
            {
                if (db_tmp.OpenConnection())
                {
                    cmd = new MySqlCommand(qryC, conn_tmp);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show(collarea_tf.Text+" entry already exists...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                dr.Close();
                db_tmp.CloseConnection();
            }*/
            //============================================================
            //====End Check===============================================

            /*if (txtcvDate.Text.Length > 4)
            {
                cvdate = ",cvdate";
                cvdateVar = ",@cvdate";                
            }*/

            /*if(txtrvDate.Text.Length>4)
            {
                cvdate = ",rvdate";
                cvdateVar = ",@rvdate";
            }*/
            
            //SQL STMT          
            String qry = "insert into journalv(jvnumber,jvdate,transCategory,docdate,description,jvamount,cvnumber,rvnumber,cvdate,rvdate,reference,others,userID,entrydate,collarea)" +
                            " values (@jvnumber,@jvdate,@transCategory,@docdate,@description,@jvamount,@cvnumber,@rvnumber,@cvdate,@rvdate,@reference,@others,@userID,now(),@collarea)";                       
            cmd = new MySqlCommand(qry, conn_tmp);

            //ADD PARAMETERS  
            cmd.Parameters.AddWithValue("@jvnumber", jvnumber_lb.Text);
            cmd.Parameters.AddWithValue("@jvdate", jv_date.Value);
            //cmd.Parameters.AddWithValue("@transCategory", category_cb.GetItemText(category_cb.SelectedItem).ToString());
            cmd.Parameters.AddWithValue("@docdate", docDate_dp.Value);
            cmd.Parameters.AddWithValue("@description",description_tf.Text);
            cmd.Parameters.AddWithValue("@jvamount", Double.Parse(jvamount_tf.Text.Replace(",", "")));
            cmd.Parameters.AddWithValue("@cvnumber",cvno_tf.Text);
            cmd.Parameters.AddWithValue("@rvnumber",rvno_tf.Text);
            cmd.Parameters.AddWithValue("@reference", category_cb.GetItemText(category_cb.SelectedItem).ToString());
            cmd.Parameters.AddWithValue("@others", othercategory_tf.Text);
            cmd.Parameters.AddWithValue("@userID", globalmainFrm.userlog);
            cmd.Parameters.AddWithValue("@collarea", collarea_tf.Text);
            cmd.Parameters.AddWithValue("@rvdate", rvdate_dp.Value);
            cmd.Parameters.AddWithValue("@cvdate", docDate_dp.Value);
                       
            //OPEN CON AND EXEC insert
            conn_tmp.Open();
            try
            {                 
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
                
                idjv = getjvID(jvnumber_lb.Text);

                insertjvCntr();
                insertjvdetails();
                updatecv(cvno_tf.Text);

                MessageBox.Show("Journal voucher successfully save...",uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Information);

                Close();
             }
           catch (Exception ex)
           {
             MessageBox.Show(ex.Message);
             conn_tmp.Close();
           }

        }
                
        private void insertjvdetails()
        {
            String accntcode = "";
            String accntname = "";
            String gacode = "";
            String particulars = "";
            String debit = "0.00";
            String credit = "0.00";
            String jobcode = "";
            String jobname = "";



            String qry = "insert into jvdetails(idjournalv,jvnumber,date,glaccountcode,accountcode,accountname,particulars,jobcode,jobname,debit,credit,glaccountname,userID,entrydate)" +
                         " values (@idjournalv,@jvnumber,@date,@glaccountcode,@accountcode,@accountname,@particulars,@jobcode,@jobname,@debit,@credit,@glaccountname,@userID,now())";
            

            int rowcnt = tb_dbGrid.Rows.Count;
            
            //foreach (DataGridViewRow row in tb_dbGrid.Rows)
            for(int i=0; i<rowcnt-1; i++)
            {
                try
                {
                    if ((tb_dbGrid.Rows[i].Cells[0].Value != null) && (tb_dbGrid.Rows[i].Cells[2].Value != null))
                    {

                        try
                        {
                            accntcode = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                        }
                        catch { }
                        try
                        {
                            accntname = tb_dbGrid.Rows[i].Cells[2].Value.ToString();
                        }
                        catch { }
                        try
                        {
                            gacode = tb_dbGrid.Rows[i].Cells[12].Value.ToString();
                        }
                        catch { }
                        try
                        {
                            particulars = tb_dbGrid.Rows[i].Cells[3].Value.ToString();
                        }
                        catch { }

                        try
                        {
                            if (tb_dbGrid.Rows[i].Cells[10].Value != null)
                                jobcode = tb_dbGrid.Rows[i].Cells[10].Value.ToString();
                        }
                        catch { }


                        try
                        {
                            if (tb_dbGrid.Rows[i].Cells[11].Value != null)
                                jobname = tb_dbGrid.Rows[i].Cells[11].Value.ToString();
                        }
                        catch { }

                        cmd = new MySqlCommand(qry, conn_tmp);
                        cmd.Parameters.AddWithValue("@idjournalv", int.Parse(idjv));
                        cmd.Parameters.AddWithValue("@jvnumber", jvnumber_lb.Text);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@accountcode", accntcode);
                        cmd.Parameters.AddWithValue("@accountname", accntname);
                        cmd.Parameters.AddWithValue("@glaccountcode", gacode);
                        cmd.Parameters.AddWithValue("@particulars", particulars);
                        cmd.Parameters.AddWithValue("@userID", globalmainFrm.userlog);
                        cmd.Parameters.AddWithValue("@jobcode", jobcode);
                        cmd.Parameters.AddWithValue("@jobname", jobname);

                       

                        try
                        {
                            debit = tb_dbGrid.Rows[i].Cells[4].Value.ToString();                           
                        }
                        catch { }

                        try
                        {
                            credit = tb_dbGrid.Rows[i].Cells[5].Value.ToString();
                        }
                        catch { }

                        
                        cmd.Parameters.AddWithValue("@debit", Double.Parse(debit.Replace(",", "")));
                        cmd.Parameters.AddWithValue("@credit", Double.Parse(credit.Replace(",", "")));
                        
                        conn_tmp.Open();
                        cmd.ExecuteNonQuery();
                        conn_tmp.Close();
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                    conn_tmp.Close();
                }


                accntcode = "";
                accntname = "";
                gacode = "";
                particulars = "";
                debit = "0.00";
                credit = "0.00";
                jobcode = "";
                jobname = "";

            }

            
        }        
             
        private void insertjvCntr()
        {
            String qry = "insert into counterjv(jvdate,yymm,cntr,idjv) values (@jvdate,@yymm,@cntr,@idjv)";
            cmd = new MySqlCommand(qry, conn_tmp);

            try
            {
                cmd.Parameters.AddWithValue("@jvdate",DateTime.Now);            
                cmd.Parameters.AddWithValue("@yymm",jvnumber_lb.Text.Substring(2,4));
                cmd.Parameters.AddWithValue("@cntr",int.Parse(jvnumber_lb.Text.Substring(7,3)));            
                cmd.Parameters.AddWithValue("@idjv",int.Parse(idjv));           
                            
                conn_tmp.Open();
                cmd.ExecuteNonQuery();

                conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn_tmp.Close();
            }
        }
             
        //select journal voucher ID=====================================
        private String getjvID(String jvno)
        {
            String id = "0";

            
             string sql = "SELECT * FROM journalv where jvnumber = '"+jvno+"'";
             cmd = new MySqlCommand(sql, conn_tmp);

             //OPEN CON
             try
              {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    id = dr.GetString("idjournal");
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
            
        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
       

    private void updatejv(String jvno, DateTime docdate, String description, String jvamount)
        {
            String qry = " update journalv set  " +
                         "      docdate = @docdate," +
                         "      description = @description," +
                         "      jvamount = @jvamount," +
                         "      reference = @reference," +
                         "      others = @others," +
                         "      jvdate = @jvdate," +
                         "      jvnumber = @jvnumber," +
                         "      cvdate = @cvdate," +
                         "      rvdate = @rvdate," +
                         "      cvnumber = @cvnumber," +
                         "      rvnumber = @rvnumber " +                        
                         " where jvnumber = @jvno";


            try
            {
                cmd = new MySqlCommand(qry, conn_tmp);
                // cmd.Parameters.AddWithValue("@transCategory", category);
                cmd.Parameters.AddWithValue("@docdate", docdate);
                cmd.Parameters.AddWithValue("@jvdate", jv_date.Value);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@jvamount", Double.Parse(jvamount));
                cmd.Parameters.AddWithValue("@jvno", jvno);
                cmd.Parameters.AddWithValue("@jvnumber", jvnumber_lb.Text);
                cmd.Parameters.AddWithValue("@reference", category_cb.GetItemText(category_cb.SelectedItem).ToString());
                cmd.Parameters.AddWithValue("@others", othercategory_tf.Text);

                cmd.Parameters.AddWithValue("@cvdate", docDate_dp.Value);
                cmd.Parameters.AddWithValue("@rvdate", rvdate_dp.Value);
                cmd.Parameters.AddWithValue("@cvnumber", cvno_tf.Text);
                cmd.Parameters.AddWithValue("@rvnumber", rvno_tf.Text);

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("JV update ERROR: "+ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
                this.isErrUpdate = true;
            }
            
        }
             
        private void filterupdatejvdetails()
        {
            String idjv = getjvID(jvno_tmp);
            String accntcode = "";
            String accntname = "";
            String particulars = "";
            String debit = "0.00";
            String credit = "0.00";
            String jvno = jvnumber_lb.Text;
            String jobcode = "";
            String jobname = "";
            String acode = "";
            String aname = "";
            String idjvd = "0";
            this.isErrUpdate = false;
            Boolean isCF = false;

            

            String qry = "Select * from jvdetails where idjvdetails = @idjvd";

            
            int rowcnt = tb_dbGrid.Rows.Count;

            if (isErrUpdate==false)
            {
                for (int i = 0; i < rowcnt - 1; i++)
                {

                    try
                    {
                        idjvd = tb_dbGrid.Rows[i].Cells[7].Value.ToString();
                    }
                    catch
                    { }
                    
                    try
                    {
                        cmd = new MySqlCommand(qry, conn_tmp);
                        cmd.Parameters.AddWithValue("@idjvd", int.Parse(idjvd));

                        conn_tmp.Open();
                        dr = cmd.ExecuteReader();

                        
                        if (dr.Read()) //journal voucher update statement========================
                        {
                            
                            dr.Close();
                            conn_tmp.Close();

                            if ((tb_dbGrid.Rows[i].Cells[0].Value != null) && (tb_dbGrid.Rows[i].Cells[2].Value != null))
                            {
                                try
                                {
                                    accntcode = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                                }
                                catch { }
                                try
                                {
                                    accntname = tb_dbGrid.Rows[i].Cells[2].Value.ToString();
                                }
                                catch { }
                                try
                                {
                                    particulars = tb_dbGrid.Rows[i].Cells[3].Value.ToString();
                                }
                                catch { }
                                try
                                {
                                    debit = tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "");
                                }
                                catch { }
                                try
                                {
                                    credit = tb_dbGrid.Rows[i].Cells[5].Value.ToString().Replace(",", "");
                                }
                                catch { }
                                try
                                {
                                    isCF = Boolean.Parse(tb_dbGrid.Rows[i].Cells[8].Value.ToString());
                                }
                                catch { }


                                try
                                {
                                    if (tb_dbGrid.Rows[i].Cells[10].Value != null)
                                        jobcode = tb_dbGrid.Rows[i].Cells[10].Value.ToString();
                                }
                                catch { }


                                try
                                {
                                    if (tb_dbGrid.Rows[i].Cells[11].Value != null)
                                        jobname = tb_dbGrid.Rows[i].Cells[11].Value.ToString();
                                }
                                catch { }

                                try
                                {
                                    if (tb_dbGrid.Rows[i].Cells[12].Value != null)
                                        acode = tb_dbGrid.Rows[i].Cells[12].Value.ToString();
                                }
                                catch { }

                                try
                                {
                                    if (tb_dbGrid.Rows[i].Cells[11].Value != null)
                                        aname = tb_dbGrid.Rows[i].Cells[13].Value.ToString();
                                }
                                catch { }
                                                               
                                                                
                                //MessageBox.Show("Ronel", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                updatejvdetails(idjvd,accntcode,accntname,jobcode,jobname,particulars,debit,credit,isCF, acode, aname);
                            }
                                                       
                        }
                        else //journal voucher insert statement===========================================
                        {

                            dr.Close();
                            conn_tmp.Close();

                            if ((tb_dbGrid.Rows[i].Cells[0].Value != null) && (tb_dbGrid.Rows[i].Cells[2].Value != null))
                            {
                                try
                                {
                                    accntcode = tb_dbGrid.Rows[i].Cells[0].Value.ToString();
                                }
                                catch { }

                                try
                                {
                                    accntname = tb_dbGrid.Rows[i].Cells[2].Value.ToString();
                                }
                                catch { }

                                try
                                {
                                    particulars = tb_dbGrid.Rows[i].Cells[3].Value.ToString();
                                }
                                catch { }
                                try
                                {
                                    debit = tb_dbGrid.Rows[i].Cells[4].Value.ToString().Replace(",", "");
                                }
                                catch { }
                                try
                                {
                                    credit = tb_dbGrid.Rows[i].Cells[5].Value.ToString().Replace(",", "");
                                }
                                catch { }

                                try
                                {
                                    if (tb_dbGrid.Rows[i].Cells[10].Value != null)
                                        jobcode = tb_dbGrid.Rows[i].Cells[10].Value.ToString();
                                }
                                catch { }

                                try
                                {
                                    if (tb_dbGrid.Rows[i].Cells[11].Value != null)
                                        jobname = tb_dbGrid.Rows[i].Cells[11].Value.ToString();
                                }
                                catch { }
                                try
                                {
                                    if (tb_dbGrid.Rows[i].Cells[12].Value != null)
                                        acode = tb_dbGrid.Rows[i].Cells[12].Value.ToString();
                                }
                                catch { }
                                try
                                {
                                    if (tb_dbGrid.Rows[i].Cells[11].Value != null)
                                        aname = tb_dbGrid.Rows[i].Cells[13].Value.ToString();
                                }
                                catch { }
                                                                
                                // isCF = Boolean.Parse(tb_dbGrid.Rows[i].Cells[8].Value.ToString
                                insertjvdtls(idjv, jvno,accntcode,accntname,particulars,jobcode,jobname,debit,credit, acode,aname );                               
                            }
                                                        
                        }

                    }
                    catch 
                    {
                        //MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dr.Close();
                        //conn_tmp.Close();

                        //break;
                    }

                    accntcode = "";
                    accntname = "";
                    particulars = "";
                    debit = "0.00";
                    credit = "0.00";                    
                    jobcode = "";
                    jobname = "";
                    idjvd = "0";

                    if (isErrUpdate == true)
                        break;
                }
            }
                        
            MessageBox.Show("Check voucher details successfully updated...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updatecv(String cvno)
        {
            String qry = "update checkvoucher set forliquidation = '0' " +
                         " where cvnumber = @cvnumber";
            cmd = new MySqlCommand(qry, conn_tmp);           
            cmd.Parameters.AddWithValue("@cvnumber", cvno);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CV update ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
                this.isErrUpdate = true;
            }
        }

        private void updatejvdetails(String idjvdetails,String accountcode, String accountname, String jobcode, String jobname, String particulars,String debit,String credit,Boolean is_CF,String glaccountcode, String glaccountname)
        {
            String qry = "update jvdetails set date = @date, " +
                         "                     glaccountcode = @glaccountcode," +
                         "                     glaccountname = @glaccountname," +
                         "                     accountcode = @accountcode," +
                         "                     accountname = @accountname," +
                         "                     jobcode = @jobcode," +
                         "                     jobname = @jobname," +
                         "                     particulars = @particulars, " +
                         "                     debit = @debit, " +
                         "                     credit = @credit, " +
                         "                     jvnumber = @jvnumber " +
                         " where idjvdetails = @idjvdetails";
            cmd = new MySqlCommand(qry,conn_tmp);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@accountcode", accountcode);           
            cmd.Parameters.AddWithValue("@accountname", accountname);
            cmd.Parameters.AddWithValue("@jobcode", jobcode);
            cmd.Parameters.AddWithValue("@jobname", jobname);
            cmd.Parameters.AddWithValue("@particulars", particulars);
            cmd.Parameters.AddWithValue("@debit", Double.Parse(debit));
            cmd.Parameters.AddWithValue("@credit", Double.Parse(credit));
            cmd.Parameters.AddWithValue("@isCF", is_CF);
            cmd.Parameters.AddWithValue("@idjvdetails", int.Parse(idjvdetails));
            cmd.Parameters.AddWithValue("@glaccountcode", glaccountcode);
            cmd.Parameters.AddWithValue("@glaccountname", glaccountname);
            cmd.Parameters.AddWithValue("@jvnumber", jvnumber_lb.Text);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("JV details update ERROR: "+ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
                this.isErrUpdate = true;
            }
        }

        private void insertjvdtls(String idjournalv,String jvnumber,String accountcode,String accountname,String particulars,
                                 String jobcode,String jobname, String debit, String credit, String glaccountcode,String glaccountname)
        {
            String qry = "insert into jvdetails(idjournalv,jvnumber,date,glaccountcode,accountcode,accountname,particulars,jobcode,jobname,debit,credit,glaccountname)" +
                         " values (@idjournalv,@jvnumber,@date,@glaccountcode,@accountcode,@accountname,@particulars,@jobcode,@jobname,@debit,@credit,@glaccountname)";

           
            try
            {                   
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@idjournalv", int.Parse(idjournalv));
                cmd.Parameters.AddWithValue("@jvnumber", jvnumber);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@accountcode", accountcode);
                cmd.Parameters.AddWithValue("@accountname", accountname);
                cmd.Parameters.AddWithValue("@particulars", particulars);
                cmd.Parameters.AddWithValue("@jobcode",jobcode);
                cmd.Parameters.AddWithValue("@jobname",jobname);
                cmd.Parameters.AddWithValue("@debit",Double.Parse(debit));
                cmd.Parameters.AddWithValue("@credit",Double.Parse(credit));
                //cmd.Parameters.AddWithValue("@isCF", isCF);
                cmd.Parameters.AddWithValue("@glaccountcode", glaccountcode);
                cmd.Parameters.AddWithValue("@glaccountname", glaccountname);
                

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();                  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
                this.isErrUpdate = true;
            }

            


        }
        private void tb_dbGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {              
        }


        private void loadjvdetails(String jvno_)
        {
            String qry = "Select idjvdetails," +
                         "       idjournalv," +
                         "       jvnumber," +
                         "       date," +
                         "       ifnull(glaccountcode,'') glaccountcode," +
                         "       ifnull(accountcode,'') accountcode," +
                         "       ifnull(accountname,'') accountname," +
                         "       ifnull(glaccountname,'') glaccountname," +
                         "       ifnull(jobcode,'') jobcode," +
                         "       ifnull(jobname,'') jobname," +
                         "       ifnull(particulars,'') particulars," +
                         "       ifnull(debit,0.00) debit," +
                         "       ifnull(credit,0.00) credit," +
                         "       isCF," +
                         "       ifnull(userID,'') userID," +
                         "       posted," +
                         "       ifnull(postedby,'') postedby," +
                         "       ifnull(DATE_FORMAT(posteddate,'%Y-%m-%e'),'') posteddate" +
                         "    from jvdetails where jvnumber = '" + jvno_ + "'";
            cmd = new MySqlCommand(qry, conn_tmp);

            // Display string representations of numbers for en-us culture
            CultureInfo ci = new CultureInfo("en-us");

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tb_dbGrid.Rows.Add(dr.GetString("accountcode"),
                                       "...",
                                       dr.GetString("accountname"),
                                       dr.GetString("particulars"),
                                       dr.GetDouble("debit").ToString("N02", ci),
                                       dr.GetDouble("credit").ToString("N02", ci),
                                       dr.GetString("jvnumber"),
                                       dr.GetString("idjvdetails"),
                                       dr.GetBoolean("isCF"),
                                       "..",
                                       dr.GetString("jobcode"),
                                       dr.GetString("jobname"),
                                       dr.GetString("glaccountcode"),
                                       dr.GetString("glaccountname"));

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

        private void loadFilteredJV(String jvno_)
        {
            CultureInfo ci = new CultureInfo("en-us");
            String qry = "Select idjournal," +
                         "       jvnumber," +
                         "       jvdate," +
                         "       ifnull(transCategory,'') transCategory," +
                         "       ifnull(othertranscatgry,'') othertranscatgry," +
                         "       docdate," +
                         "       ifnull(description,'') description," +
                         "       ifnull(jvamount,0) jvamount," +
                         "       isposted," +
                         "       ifnull(userid,'') user," +
                         "       ifnull(postedby,'') postedby," +
                         "       ifnull(cvnumber,'') cvnumber," +
                         "       ifnull(rvnumber,'') rvnumber," +
                         "       ifnull(DATE_FORMAT(cvdate,'%Y-%m-%e'),'')  cvdate," +
                         "       ifnull(DATE_FORMAT(rvdate,'%Y-%m-%e'),'') rvdate," +
                         "       reference," +
                         "       ifnull(others,'') others " +
                         " from journalv where jvnumber = '" + jvno_ + "'";
            cmd = new MySqlCommand(qry,conn_tmp);            

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();
                
                if(dr.Read())
                {

                    jvnumber_lb.Text = dr.GetString("jvnumber");
                    description_tf.Text = dr.GetString("description");
                    //docDate_dp.Value = dr.GetDateTime("docdate");
                    category_cb.SelectedIndex = category_cb.FindStringExact(dr.GetString("reference"));
                    jvamount_tf.Text = dr.GetDouble("jvamount").ToString("N02", ci);   
                    cvno_tf.Text = dr.GetString("cvnumber");

                    try
                    {
                        docDate_dp.Value = dr.GetDateTime("cvdate");//.ToString("yyyy-MM-dd");
                    }
                    catch { }

                    try
                    {
                        rvno_tf.Text = dr.GetString("rvnumber");
                    }
                    catch { }

                    try
                    {
                        rvdate_dp.Value = dr.GetDateTime("rvdate");
                    }
                    catch { }

                    try
                    {
                        jv_date.Value = dr.GetDateTime("jvdate");
                    }
                    catch { }

                    try
                    {
                        othercategory_tf.Text = dr.GetString("others");
                    }
                    catch { }
                                                          

                }

                dr.Close();
                conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                conn_tmp.Close();
            }
        }

        private void deletejvDetails(String id)
        {
            String qry = "Delete from jvdetails where idjvdetails = '" + id + "'";

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

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DataGridViewRow sRow;
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            sRow = tb_dbGrid.Rows[selectedrowindex];

            String msgcode = "";
            String idjvd = "";

            try
            {
                msgcode = sRow.Cells[0].Value.ToString();
            }
            catch
            { }

            try
            {
                idjvd = sRow.Cells[7].Value.ToString();
            }
            catch
            { }

            DialogResult d = MessageBox.Show(msgcode + "\n Are you sure you want to delete this row?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (d == DialogResult.Yes)
            {
                tb_dbGrid.Rows.RemoveAt(selectedrowindex);
                deletejvDetails(idjvd);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ref_btn_Click(object sender, EventArgs e)
        {
            jvReferencesFrm frm = new jvReferencesFrm();
            frm.jvdetailsFrmInitl(this);           

            frm.ShowDialog();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            emptCode = "";
            sumDC();

            String bal = bal_lb.Text.Replace(",", "");
            CultureInfo ci = new CultureInfo("en-us");
            Double amnt = 0.00;

            string sql = "SELECT * FROM checkvoucher where cvnumber = '" + cvno_tf.Text + "'";
            cmd = new MySqlCommand(sql, conn_tmp);


            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    amnt = dr.GetDouble("cvamount");
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
            //==========================================
            //==========================================
            /*if ((Double.Parse(jvamount_tf.Text.Replace(",", "")) != amnt) && (cvno_tf.Text != ""))
            {
                MessageBox.Show("CV Amount: " + amnt.ToString("N02", ci) + "\r\n Unable to continue this process. \r\n JV amount should be equal to CV amount...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            
            if (Double.Parse(bal) != 0.0)
            {
                MessageBox.Show("Unable to continue this process. \r\nDebit and credit should be equal value...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*if(!(emptCode.Equals("")))
            {
                MessageBox.Show(emptCode, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
                      
            
            if (this.Text == "Add Journal Voucher Entry")
            {               
                addjv();
            }
            else if (this.Text == "Update Journal Voucher Entry")
            {
                filterupdatejvdetails();                               

                updatejv(jvno_tmp,  docDate_dp.Value, description_tf.Text, jvamount_tf.Text.Replace(",", ""));


                //tb_dbGrid.Rows.Clear();
                //loadjvdetails(jvnumber_lb.Text);
            }
        }

        private void close_btn_Click_1(object sender, EventArgs e)
        {

        }

        private void delete_btn_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow sRow;
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            sRow = tb_dbGrid.Rows[selectedrowindex];

            String msgcode = "";
            String idjvd = "";

            try
            {
                msgcode = sRow.Cells[0].Value.ToString();
            }
            catch
            { }

            try
            {
                idjvd = sRow.Cells[7].Value.ToString();
            }
            catch
            { }

            DialogResult d = MessageBox.Show(msgcode + "\n Are you sure you want to delete this row?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                tb_dbGrid.Rows.RemoveAt(selectedrowindex);
                deletejvDetails(idjvd);
            }
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            printpreview(jvnumber_lb.Text);
        }

        private void printpreview(String jvnoTmp)
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            journalvRpt myReport = new journalvRpt();

            DataTable journal_tbl = new DataTable();
            DataTable journalD_tbl = new DataTable();
            DataTable sig_tbl = new DataTable();

            String qry = "Select idjournal," +
                         "       jvnumber," +
                         "       ifnull(DATE_FORMAT(jvdate,'%m/%e/%Y'),'') jvdate," +
                         "       ifnull(transCategory,'') transCategory," +
                         "       ifnull(othertranscatgry,'') othertranscatgry," +
                         "       ifnull(DATE_FORMAT(docdate,'%m/%e/%Y'),'') docdate," +
                         "       ifnull(description,'') description," +
                         "       ifnull(jvamount,0) jvamount," +
                         "       isposted," +
                         "       ifnull(userid,'') user," +
                         "       ifnull(postedby,'') postedby," +
                         "       ifnull(cvnumber,'') cvnumber," +
                         "       ifnull(rvnumber,'') rvnumber," +
                         "       ifnull(DATE_FORMAT(cvdate,'%Y-%m-%e'),'')  cvdate," +
                         "       ifnull(DATE_FORMAT(rvdate,'%Y-%m-%e'),'') rvdate" +
                         " from journalv where jvnumber = '" + jvnoTmp + "'";
            String qry2 = "Select * from jvdetails where jvnumber = '" + jvnoTmp + "'";
            String sig = "Select * from  signatories where reportType like 'checkvoucher' ";

            try
            {
                da = new MySqlDataAdapter(qry, conn_tmp);
                conn_tmp.Open();
                da.Fill(journal_tbl);
                da.Dispose();
                ds.Tables.Add(journal_tbl);
                ds.Tables[0].TableName = "journalv";

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
                da = new MySqlDataAdapter(qry2, conn_tmp);
                conn_tmp.Open();
                da.Fill(journalD_tbl);
                da.Dispose();
                ds.Tables.Add(journalD_tbl);
                ds.Tables[1].TableName = "journaldetail";

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
                da = new MySqlDataAdapter(sig, conn_tmp);
                conn_tmp.Open();
                da.Fill(sig_tbl);
                da.Dispose();
                ds.Tables.Add(sig_tbl);
                ds.Tables[2].TableName = "signatories";

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
            String sql_sign = "SELECT s.*,u.* FROM sign s " +
                              " left join user u on u.userid ='" + globalmainFrm.userlog+ "' "+
                              " where s.section = 'JV' ";
                             
            cmd = new MySqlCommand(sql_sign, globalmainFrm.getConn_accnt());


            try
            {
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    myReport.SetDataSource(ds);
                    myReport.SetParameterValue("prepared", dr.GetString("name"));
                    myReport.SetParameterValue("preparedpos", dr.GetString("position"));
                    myReport.SetParameterValue("checked", dr.GetString("checked"));
                    myReport.SetParameterValue("checkedpos", dr.GetString("checked_pos"));
                    myReport.SetParameterValue("reviewed", dr.GetString("reviewed"));
                    myReport.SetParameterValue("reviewedpos", dr.GetString("reviewed_pos"));
                    myReport.SetParameterValue("attested", dr.GetString("attested"));
                    myReport.SetParameterValue("attestedpos", dr.GetString("attested_pos"));
                    myReport.SetParameterValue("audited", dr.GetString("audited"));
                    myReport.SetParameterValue("auditedpos", dr.GetString("audited_pos"));
                    frm.crystalRptViewer.ReportSource = myReport;
                    frm.ShowDialog();
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (txtcvDate.Text.Length > 4)
                return;*/

            if (calcvdate.Visible)
                calcvdate.Visible = false;
            else
            {
                calcvdate.Location = new Point(335, 137);
                calcvdate.Visible = true;
            }
            
        }

        private void calcvdate_DateSelected(object sender, DateRangeEventArgs e)
        {
            /*DateTime EndOfMonth;
            EndOfMonth = new DateTime(calcvdate.SelectionRange.Start.Year,
                                      calcvdate.SelectionRange.Start.Month,
                                       DateTime.DaysInMonth(calcvdate.SelectionRange.Start.Year, calcvdate.SelectionRange.Start.Month));
            */        
            //calcvdate.Visible = false;
            //txtcvDate.Text = calcvdate.SelectionRange.Start.ToString("yyyy-MM-dd"); // EndOfMonth.ToString("yyyy-MM-dd");
        }
                      

        private void calrvdate_DateSelected(object sender, DateRangeEventArgs e)
        {
            calrvdate.Visible = false;
            //txtrvDate.Text = calrvdate.SelectionRange.Start.ToString("yyyy-MM-dd");
        }

        private void txtrvDate_DoubleClick(object sender, EventArgs e)
        {           
            DialogResult d = MessageBox.Show("Remove RV date entry?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                //txtrvDate.Text = "";
            }
        }

        private void category_cb_SelectedValueChanged(object sender, EventArgs e)
        {
            if(category_cb.GetItemText(category_cb.SelectedItem).ToString().Equals("Others"))
            {
                lbl_other.Visible = true;
                othercategory_tf.Visible = true;

                othercategory_tf.ReadOnly = false;
                this.ActiveControl = othercategory_tf;
            }
            else
            {
                lbl_other.Visible = false;
                othercategory_tf.Visible = false;

                othercategory_tf.ReadOnly = true;
                othercategory_tf.Text = "";
            }
        }

        //===Numeric Input Only============================
        //=================================================
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

        private void jvdetailsFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isnotify = false;
        }

        private void tb_dbGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int selectedrowindex = tb_dbGrid.SelectedCells[0].RowIndex;
            int columnIndex = tb_dbGrid.CurrentCell.ColumnIndex;

            DataGridViewRow sRow = tb_dbGrid.Rows[selectedrowindex];
            sRow.Cells[columnIndex].Style.BackColor = Color.LightBlue;
            sRow.Cells[columnIndex].Style.ForeColor = Color.Black;
            sRow.Cells[columnIndex].Style.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        }

        private void jvdetailsFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        //================================================
        //================================================
    }
}
