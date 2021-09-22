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
    public partial class memoBankreconFrm : Form
    {
        private bankReconFrm frm_bankrecon = new bankReconFrm();

        private connectionDB db = new connectionDB();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        //private MySqlDataAdapter da;

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();

        Rectangle _Rectangle;
        private String _Accontcode = "";

        //==============DoEvent Statement=========
        public delegate void DoEventMemo(String code);
        public event DoEventMemo memoTotal;
        //========================================


        public memoBankreconFrm()
        {
            InitializeComponent();

            dgv.Controls.Add(datepicker_dgv);
            datepicker_dgv.Visible = false;
            datepicker_dgv.Format = DateTimePickerFormat.Custom;
            datepicker_dgv.TextChanged += new EventHandler(datepicker_dgv_TextChange);
        }

        public void frmBankreconInitl(bankReconFrm frm_bankrecon_)
        {
            this.frm_bankrecon = frm_bankrecon_;
        }

        public void setAccountcode(String code)
        {
            this._Accontcode = code;
        }
        /*
        private void memoTotal()
        {
            int rowcnt = dgv.Rows.Count;
            
            Double debit = 0.00;
            Double credit = 0.00;
            String idmemo = "";

            int dCnt = 0;
            int cCnt = 0;
            Double dTotal = 0.00;
            Double cTotal = 0.00;

            for (int i = 0; i < rowcnt - 1; i++)
            {                             

                try
                {
                    debit = Double.Parse(dgv.Rows[i].Cells[5].Value.ToString().Replace(",", ""));
                }
                catch
                { }

                try
                {
                    credit = Double.Parse(dgv.Rows[i].Cells[6].Value.ToString().Replace(",", ""));
                }
                catch
                { }

                try
                {
                    idmemo = dgv.Rows[i].Cells[7].Value.ToString();
                }
                catch
                { }


                if(!idmemo.Equals(""))
                {
                    if(debit>0)
                    {
                        dTotal = dTotal + debit;
                        dCnt++;
                    }
                    else if(credit >0)
                    {
                        cTotal = cTotal + credit;
                        cCnt++;
                    }
                }
                
                debit = 0.00;
                credit = 0.00;
                idmemo = "";
            }

            frm_bankrecon.lbl_debitCnt_memo.Text = dCnt.ToString();
            frm_bankrecon.lbl_debitTotal_memo.Text = dTotal.ToString("N02",uc.ci);
            frm_bankrecon.lbl_creditCnt_memo.Text = cCnt.ToString();
            frm_bankrecon.lbl_creditTotal_memo.Text = cTotal.ToString("N02",uc.ci);
        }*/

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rowcnt = dgv.Rows.Count;
            String accountcode = "";
            String accountname = "";
            String date = "";// DateTime.Now.ToString("yyyy-MM-dd");
            String description = "";
            String accountSF = accountcode_tf.Text;
            String accountnameSF = accountname_tf.Text;
            String userid = "";
            Double debit = 0.00;
            Double credit = 0.00;
            String idmemo = "0";

            for (int i = 0; i < rowcnt - 1; i++)
            {
                try
                {
                    accountcode = dgv.Rows[i].Cells[1].Value.ToString();
                }
                catch
                { }

                try
                {
                    accountname = dgv.Rows[i].Cells[3].Value.ToString();
                }
                catch
                { }

                try
                {
                    description = dgv.Rows[i].Cells[4].Value.ToString();
                }
                catch
                { }

                try
                {
                    debit = Double.Parse(dgv.Rows[i].Cells[5].Value.ToString().Replace(",", ""));
                }
                catch
                { }

                try
                {
                    credit = Double.Parse(dgv.Rows[i].Cells[6].Value.ToString().Replace(",", ""));
                }
                catch
                { }

                try
                {
                    idmemo = dgv.Rows[i].Cells[7].Value.ToString();
                }
                catch
                { }

                try
                {
                    date = dgv.Rows[i].Cells[0].Value.ToString();
                }
                catch
                { }

                //===Statement for inserting and updating records==============
                //=============================================================
                if (!date.Equals(""))
                {
                    if (searchMemo(idmemo))
                    {                        
                        updateMemo(accountcode, accountname, DateTime.Parse(date).ToString("yyyy-MM-dd"), description, userid, debit, credit, idmemo);
                    }
                    else
                    {                       
                        saveMemo(accountcode, accountname, DateTime.Parse(date).ToString("yyyy-MM-dd"), description, accountSF, accountnameSF, userid, debit, credit);
                    }
                }else
                {
                    MessageBox.Show("Unable to save empty date entry...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //=================================================
                //=================================================

                accountcode = "";
                accountname = "";
                date = "";
                description = "";                
                userid = "";
                debit = 0.00;
                credit = 0.00;
                idmemo = "0";
            }

            MessageBox.Show("Memo entry successfully saved...",uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Information);
            loadMemoB();
        }


        private void loadMemo(String accountcode, String dateto)
        {
            Double memobal = 0.00;
            String qry = "Set @creditA = 0.00; " +
                         "Set @debitA = 0.00; " +
                         " Select f.*," +
                         "        @credit as creditT," +
                         "        @debit as debitT," +
                         "        if(f.credit = 0,'',format(f.credit,2)) as creditF," +
                         "        if(f.debit = 0,'',format(f.debit,2)) as debitF " +
                         " from " +
                         "  (Select m.idmemobankrecon, " +
                         "          ifnull(m.accountcode,'') accountcode, " +
                         "          ifnull(m.accountname,'') accountname, " +
                         "          m.date, " +
                         "          ifnull(m.description,'') description, " +
                         "          ifnull(m.accountSF,'') accountSF, " +
                         "          ifnull(m.accountnameSF,'') accountnameSF, " +
                         "          ifnull(m.userid,'') userid, " +
                         "          ifnull(m.debit,0) debit, " +
                         "          ifnull(m.credit,0) mcredit, " +
                         "          @creditA = @creditA + ifnull(m.credit,0) credit_," +
                         "          @debitA = @debitA + ifnull(m.debit,0) debit_," +
                         "          c.dateasof " +
                         "  from memobankrecon m " +
                         "  left join chart c on c.accountcode = m.accountSF" +
                         "  where m.accountSF = @accountSF m.date between c.dateasof and @dateto " +
                         " ) f ";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("accountSF",accountcode);
            cmd.Parameters.AddWithValue("@dateto",dateto);
                         
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add(dr.GetString("date"),                                    
                                 dr.GetString("accountcode"),
                                 "...",
                                 dr.GetString("accountname"),
                                 dr.GetString("description"),
                                 dr.GetString("debitF"),
                                 dr.GetString("creditF"),
                                 dr.GetString("idmemobankrecon"));

                    lbl_debit.Text = dr.GetDouble("debitT").ToString("N02",uc.ci);
                    lbl_credit.Text = dr.GetDouble("creditT").ToString("N02", uc.ci);

                    memobal = dr.GetDouble("debitT") - dr.GetDouble("creditT");

                    if (memobal < 0)
                    {
                        lbl_endingBal.Text = "( " + (memobal * (-1)).ToString("N02", uc.ci) + " )";
                        balance_tf.Text = "( " + (memobal * (-1)).ToString("N02", uc.ci) + " )";
                    }
                    else
                    {
                        lbl_endingBal.Text = memobal.ToString("N02", uc.ci);
                        balance_tf.Text = memobal.ToString("N02", uc.ci);
                    }

                    dateasof_dp.Value = dr.GetDateTime("dateasof");
                    //dateto_dp.Value = DateTime.Parse(dateto);
                }

                this.ActiveControl = dgv;
                dr.Close();
                conn_tmp.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);               
                conn_tmp.Close();
            }
             
        }

        private Boolean searchMemo(String idmemo)
        {
            Boolean value = false;

            String qry = "Select * from memobankrecon where idmemobankrecon = @idmemo";

            try
            {

                conn_tmp.Open();
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@idmemo", idmemo);                
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    value = true;

                dr.Close();
                conn_tmp.Close();
            }
            catch
            {
                conn_tmp.Close();
            }

            return value;
        }

        private void updateMemo(String accountcode, String accountname, String date, String description, String userid, Double debit, Double credit, String idmemo)
        {
            String qry = "update memobankrecon set" +
                         "     accountcode = @accountcode," +
                         "     accountname = @accountname," +
                         "     date = @date," +
                         "     description = @description," +
                         "     userid = @userid," +
                         "     debit = @debit," +
                         "     credit = @credit " +
                         " where idmemobankrecon = @idmemo";

            cmd = new MySqlCommand(qry, conn_tmp);

            cmd.Parameters.AddWithValue("@accountcode", accountcode);
            cmd.Parameters.AddWithValue("@accountname", accountname);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@description", description);         
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@debit", debit);
            cmd.Parameters.AddWithValue("@credit", credit);
            cmd.Parameters.AddWithValue("@idmemo", idmemo);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch
            {
                conn_tmp.Clone();
            }
        }

        private void saveMemo(String accountcode, String accountname, String date, String description, String accountSF, String accountnameSF, String userid,Double debit,Double credit)
        {
            String qry = "insert into memobankrecon(accountcode,accountname,date,description,accountSF,accountnameSF,userid,debit,credit) " +
                         " values(@accountcode,@accountname,@date,@description,@accountSF,@accountnameSF,@userid,@debit,@credit)";

            cmd = new MySqlCommand(qry,conn_tmp);

            cmd.Parameters.AddWithValue("@accountcode", accountcode);
            cmd.Parameters.AddWithValue("@accountname", accountname);
            cmd.Parameters.AddWithValue("@date",date);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@accountSF", accountSF);
            cmd.Parameters.AddWithValue("@accountnameSF", accountnameSF);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@debit",debit);
            cmd.Parameters.AddWithValue("@credit",credit);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
            }
            catch
            {
                conn_tmp.Clone();
            }            
        }

        private void memoBankreconFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            loadChart(_Accontcode);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*switch(dgv.Columns[e.ColumnIndex].Name)
            {
                case "Date":
                    _Rectangle = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    datepicker_dgv.Size = new Size(_Rectangle.Width,_Rectangle.Height);
                    datepicker_dgv.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    datepicker_dgv.Visible = true;
                    break;
            }*/

            if(dgv.Columns[e.ColumnIndex].Name.Equals("Date"))
            {                
                _Rectangle = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                datepicker_dgv.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                datepicker_dgv.Location = new Point(_Rectangle.X, _Rectangle.Y);
                datepicker_dgv.Visible = true;                  
            }
            else
            {
                datepicker_dgv.Visible = false;
            }
        }

        private void datepicker_dgv_TextChange(object sender,EventArgs e)
        {
            dgv.CurrentCell.Value = datepicker_dgv.Text.ToString();
        }

        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            datepicker_dgv.Visible = false;
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            datepicker_dgv.Visible = false;
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                dgv.Rows[e.RowIndex].Cells[6].Value = "";
                //sumDC();
            }
            else if (e.ColumnIndex == 6)
            {
                dgv.Rows[e.RowIndex].Cells[5].Value = "";
                //sumDC();
            }

            sumMemo();
        }

        private void datepicker_dgv_CloseUp(object sender, EventArgs e)
        {
            dgv.CurrentCell.Value = datepicker_dgv.Text.ToString();            
        }

        private void sumMemo()
        {
            String idmemo = "";
            Double creditT = 0.00;
            Double debitT = 0.00;
            Double memobal = 0.00;
            //dgv.Rows[i].Cells[3].Value.ToString();
            int rowcnt = dgv.Rows.Count;
            for (int i = 0; i < rowcnt - 1; i++)
            {
                try
                {
                    dgv.Rows[i].Cells[5].Value = Double.Parse(dgv.Rows[i].Cells[5].Value.ToString().Replace(",", "")).ToString("N02", uc.ci);
                    debitT = debitT + Double.Parse(dgv.Rows[i].Cells[5].Value.ToString().Replace(",", ""));
                }
                catch
                {                   
                }

                try
                {
                    dgv.Rows[i].Cells[6].Value = Double.Parse(dgv.Rows[i].Cells[6].Value.ToString().Replace(",", "")).ToString("N02", uc.ci);
                    creditT = creditT + Double.Parse(dgv.Rows[i].Cells[6].Value.ToString().Replace(",", ""));
                }
                catch
                { }
                                
                //=======================================
                //=======================================
                try
                {
                    idmemo = dgv.Rows[i].Cells[7].Value.ToString();
                }
                catch
                { }
                                
                if (idmemo.Equals(""))
                {
                    dgv.Rows[i].Cells[5].Style.ForeColor = Color.Black;
                    dgv.Rows[i].Cells[6].Style.ForeColor = Color.Black;
                }
                else
                {
                    dgv.Rows[i].Cells[5].Style.ForeColor = Color.SeaGreen;
                    dgv.Rows[i].Cells[6].Style.ForeColor = Color.Crimson;
                }

                idmemo = "";
                //==========================================
            }


            //===============================================
            //===============================================
            lbl_debit.Text = debitT.ToString("N02", uc.ci);
            lbl_credit.Text = creditT.ToString("N02", uc.ci);

            memobal = debitT - creditT;

            if (memobal < 0)
            {
                lbl_endingBal.Text = "( " + (memobal * (-1)).ToString("N02", uc.ci) + " )";
                //balance_tf.Text = "( " + (memobal * (-1)).ToString("N02", uc.ci) + " )";
            }
            else
            {
                lbl_endingBal.Text = memobal.ToString("N02", uc.ci);
                //balance_tf.Text = memobal.ToString("N02", uc.ci);
            }
        }
                

        //============Numeric input only=====================
        //===================================================
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if ((dgv.CurrentCell.ColumnIndex == 5) || (dgv.CurrentCell.ColumnIndex == 6) )//Desired Column
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

        //================================================
        //================================================

        private void loadChart(String code)
        {
            Boolean withRecord = false;
            String qry = "Select * from chart where accountcode = @accountcode";

            cmd = new MySqlCommand(qry,conn_tmp);
            cmd.Parameters.AddWithValue("@accountcode",code);

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    accountcode_tf.Text = code;
                    accountname_tf.Text = dr.GetString("accountname");
                    dateasof_dp.Value = DateTime.Parse(dr.GetString("dateAsOf"));
                    dateto_dp.Value = DateTime.Now;

                    withRecord = true;
                }

                dr.Close();
                conn_tmp.Close();

                if (withRecord)
                {
                    loadMemoB();                    
                }
            }
            catch
            {
                conn_tmp.Close();
            }
        }


        private void loadMemoB()
        {
            Double memobal = 0.00;
            String qry = "Set @creditA := 0.00; " +
                         "Set @debitA := 0.00; " +
                         " Select f.*," +
                         "        @creditA as creditT," +
                         "        @debitA as debitT," +
                         "        if(f.credit = 0,'',format(f.credit,2)) as creditF," +
                         "        if(f.debit = 0,'',format(f.debit,2)) as debitF " +
                         " from " +
                         "( Select m.idmemobankrecon, " +
                         "          ifnull(m.accountcode,'') accountcode, " +
                         "          ifnull(m.accountname,'') accountname, " +
                         "          DATE_FORMAT(m.date,'%c/%e/%Y') date, " +
                         "          ifnull(m.description,'') description, " +
                         "          ifnull(m.accountSF,'') accountSF, " +
                         "          ifnull(m.accountnameSF,'') accountnameSF, " +
                         "          ifnull(m.userid,'') userid, " +
                         "          ifnull(m.debit,0) debit, " +
                         "          ifnull(m.credit,0) credit, " +
                         "          @creditA := @creditA + ifnull(m.credit,0) credit_," +
                         "          @debitA := @debitA + ifnull(m.debit,0) debit_ " + 
                         " from memobankrecon m " +
                         " where m.accountSF = @accountcode  " +
                         // "       and m.date between @datefrom and @dateto " +
                         " ) f";

            cmd = new MySqlCommand(qry,conn_tmp);
            cmd.Parameters.AddWithValue("@accountcode", accountcode_tf.Text);
            // cmd.Parameters.AddWithValue("@datefrom",dateasof_dp.Value);
            // cmd.Parameters.AddWithValue("@dateto",dateto_dp.Value);
                        
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add(dr.GetString("date"),
                                dr.GetString("accountcode"),
                                "...",
                                dr.GetString("accountname"),
                                dr.GetString("description"),
                                dr.GetString("debitF"),
                                dr.GetString("creditF"),
                                dr.GetString("idmemobankrecon"));

                    lbl_debit.Text = dr.GetDouble("debitT").ToString("N02", uc.ci);
                    lbl_credit.Text = dr.GetDouble("creditT").ToString("N02", uc.ci);

                    memobal = dr.GetDouble("debitT") - dr.GetDouble("creditT");

                    if (memobal < 0)
                    {
                        lbl_endingBal.Text = "( " + (memobal * (-1)).ToString("N02", uc.ci) + " )";
                        balance_tf.Text = "( " + (memobal * (-1)).ToString("N02", uc.ci) + " )";
                    }
                    else
                    {
                        lbl_endingBal.Text = memobal.ToString("N02", uc.ci);
                        balance_tf.Text = memobal.ToString("N02", uc.ci);
                    }
                                        
                }

                dr.Close();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                conn_tmp.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dgv.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = dgv.Rows[selectedrowindex];

            String msgcode = "";
            String idmemo = "0";
            String d_ = "", c_ = "";

            try
            {
                msgcode = "Date: "+ sRow.Cells[0].Value.ToString();
            }
            catch
            { }

            try
            {
                 d_ = sRow.Cells[5].Value.ToString();
            }
            catch
            { }

            try
            {
                c_ = sRow.Cells[6].Value.ToString();
            }
            catch
            { }

            msgcode = msgcode + "\n" + "Debit: " + d_ + "\n" + "Credit: " + c_;

            try
            {
                idmemo = sRow.Cells[7].Value.ToString();
            }
            catch
            { }

            DialogResult d = MessageBox.Show(msgcode+ "\n \n Are you sure you want to delete this row?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                dgv.Rows.RemoveAt(selectedrowindex);
                deleteMemo(idmemo);
                sumMemo();
            }
        }

        private void deleteMemo(String id)
        {
            String qry = "Delete from memobankrecon where idmemobankrecon = @id";
            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@id",id);

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

        private void memoBankreconFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            memoTotal(accountcode_tf.Text);
        }
    }
}
