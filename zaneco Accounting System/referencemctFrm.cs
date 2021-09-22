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
    public partial class referencemctFrm : Form
    {
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private MySqlDataAdapter da;

        private connDBtmp db_tmp = new connDBtmp(); //connectionDB_inv();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();
        private mctdetailsFrm Frm_mctdetails = new mctdetailsFrm();


        //==Global Event Variables===========================
        public delegate void DoEvent();
        public event DoEvent RefreshDgv;
        //==================================================

        public referencemctFrm()
        {
            InitializeComponent();
        }

        public void mctdetailsFrmInitl(mctdetailsFrm Frm_mctdetails1)
        {
            Frm_mctdetails = Frm_mctdetails1;
        }
        private void rvposelect_btn_Click(object sender, EventArgs e)
        {
            Selectmct();
            this.RefreshDgv();
            Close();
        }

        private void Selectmct()
        {
            int rowCnt = 0;
            int cnt = 0;
            
            //=======LOAD MCT===================================
            //==================================================
           

            int selectedrowindex = tblDatagridView.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = tblDatagridView.Rows[selectedrowindex];

            String mctno_ = sRow.Cells[1].Value.ToString();

            Frm_mctdetails.mctdate_dp.Value = DateTime.Now;
            Frm_mctdetails.mctno_tf.Text = "";
            Frm_mctdetails.requester_tf.Text = "";
            Frm_mctdetails.desc_tf.Text = "";

            //Frm_mctdetails.mctdate_dp.Enabled = false;
            Frm_mctdetails.mctno_tf.ReadOnly = true;
            Frm_mctdetails.requester_tf.ReadOnly = true;
            Frm_mctdetails.desc_tf.ReadOnly = true;

            Frm_mctdetails.mctdate_dp.Value = DateTime.Parse(sRow.Cells[0].Value.ToString());
            Frm_mctdetails.mctno_tf.Text = mctno_;
            Frm_mctdetails.desc_tf.Text = sRow.Cells[2].Value.ToString();            
            Frm_mctdetails.requester_tf.Text = sRow.Cells[3].Value.ToString();


            /*String qry = "Select s.sccode," +
                         " c.glaccountcode," +
                         " c.glaccountname," +
                         " s.scparticulars," +
                         " ifnull(s.scissuance,0) scissuance," +
                         " s.globalid," +
                         " s.iditemindex," +
                         " i.acamacodein,i.acamacodeout," +
                         " i.acamanamein, i.acamanameout," +
                         " ifnull(i.iiunit,'') iiunit from stockcard s " +
                         " left join itemindex i on i.iditemindex = s.iditemindex" +
                         " left join zanecoaccounting.chart c on c.accountcode = i.acamacodeout" +
                         " where s.scdocument = @mctno order by s.sccode asc";*/

            String qry = "Select s.itemcode sccode,     " +
                         "   c.glaccountcode,     " +
                         "   c.glaccountname,     " +
                         "   cc.glaccountcode glaccountcodein,     " +
                         "   cc.glaccountname glaccountnamein,     " +
                         "   i.itemname as scparticulars,     " +
                         "   ifnull(s.quantity, 0) as scissuance,     " +
                         "   ifnull(i.iditemindex,0) as globalid,     " +
                         "   ifnull(i.iditemindex,0) iditemindex,     " +
                         "   cc.accountcode acamacodein, c.accountcode acamacodeout,     " +
                         "   cc.accountname acamanamein, c.accountname acamanameout,     " +
                         "   ifnull(i.unit, '') iiunit     " +
                         " from zanecoinvphp.tbl_issuancedetails s     " +
                         " left join zanecoinvphp.tbl_itemindex i on i.itemcode = s.itemcode     " +
                         " left join zanecoaccounting.chart c on c.accountcode = i.acamacodeout     " +
                         " left join zanecoaccounting.chart cc on cc.accountcode = i.acamacodein     " +
                         " where s.inumber = @mctno order by s.itemcode asc     ";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@mctno", mctno_);
            Frm_mctdetails.tb_dbGrid.Rows.Clear();
            
            //load debit details of mct===============================
            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    try
                    {
                        
                        Frm_mctdetails.tb_dbGrid.Rows.Add(dr.GetString("acamacodeout"),
                                                          "...",
                                                          dr.GetString("acamanameout"),
                                                          dr.GetString("sccode"),
                                                          "...",
                                                          dr.GetString("scparticulars"),
                                                          dr.GetString("scissuance"),
                                                          dr.GetString("iiunit"),
                                                          "0.00",
                                                          "0.00",
                                                          "0.00",
                                                          "",
                                                          "",
                                                          mctno_,
                                                          dr.GetString("glaccountcode"),
                                                          dr.GetString("glaccountname"),
                                                          DateTime.Now,
                                                          dr.GetString("iditemindex"),
                                                          dr.GetString("globalid"),
                                                          cnt,
                                                          "1",
                                                          "1");                                               

                        Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[9].Style.ForeColor = Color.Green;//--
                        Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[3].ReadOnly = true;
                        Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[4].ReadOnly = true;
                        Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[5].ReadOnly = true;//--

                        Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[9].ReadOnly = false;
                        Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[10].ReadOnly = true;

                        Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[0].Style.BackColor = Color.Green;//--
                        Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[2].Style.BackColor = Color.Green;//--
                        
                        rowCnt++;
                        cnt++;
                    }
                    catch { }

                }

                

                dr.Close();
                conn_tmp.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }


            try
            {
                //=================Credit load=================================
                //=============================================================
                //dr.Close();
                //conn_tmp.Close();

                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    try
                    {
                        Frm_mctdetails.tb_dbGrid.Rows.Add(dr.GetString("acamacodein"),
                                                          "...",
                                                          dr.GetString("acamanamein"),
                                                          dr.GetString("sccode"),
                                                          "...",
                                                          dr.GetString("scparticulars"),
                                                          dr.GetString("scissuance"),
                                                          dr.GetString("iiunit"),
                                                          "0.00",
                                                          "0.00",
                                                          "0.00",
                                                          "",
                                                          "",
                                                          mctno_,
                                                          dr.GetString("glaccountcodein"),
                                                          dr.GetString("glaccountnamein"),
                                                          DateTime.Now,
                                                          dr.GetString("iditemindex"),
                                                          dr.GetString("globalid"),
                                                          cnt,
                                                          "1",
                                                          "0");

                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[10].Style.ForeColor = Color.Red;//--
                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[9].Style.ForeColor = Color.Black;//--

                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[3].ReadOnly = true;
                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[4].ReadOnly = true;
                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[5].ReadOnly = true;//--

                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[9].ReadOnly = true;
                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[10].ReadOnly = false;

                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[0].Style.BackColor = Color.Red;//--
                        Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[2].Style.BackColor = Color.Red;//--
                        //Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[8].ReadOnly = true;
                        //Frm_mctdetails.tb_dbGrid.Rows[cnt].Cells[9].ReadOnly = true;

                        cnt++;
                    }
                    catch { }
                }

                dr.Close();
                conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }

            //======Feltering average amount of Item Code========================================================
            //===================================================================================================

            /*qry = " Select           " +
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
                        "        fnl.presAmount / fnl.presUnit,'0.00') Average           "+
                        "  from           " +
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
                        "               ItemIndex.IIName,           "+
                        "               sum(If(scdate < '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' , ifnull(stockcard.screceipts, 0), 0)) PrevTotalReceipts,           " +
                        "               sum(If(scdate < '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuance, 0), 0)) PrevTotalIssuance,           " +
                        "               sum(If(scdate < '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.screceiptsAmount, 0), 0)) PrevTotalReceiptsAmount,           " +
                        "               sum(If(scdate < '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuanceAmount, 0), 0)) PrevTotalIssuanceAmount,           " +
                        "               sum(If(scdate between '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument not like '%MCrT%' and scdocument not like '%ADJ%', ifnull(stockcard.screceipts, 0), 0)) PresTotalReceipts,           " +
                        "               sum(If(scdate between '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%MCrT%', ifnull(stockcard.screceipts, 0), 0)) PresTotalMCrT,           " +
                        "               sum(If(scdate between '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument not like '%ADJ%', ifnull(stockcard.scIssuance, 0), 0)) PresTotalIssuance,           " +
                        "               sum(If(scdate between '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%ADJ%', ifnull(stockcard.scIssuance, 0), 0)) PresTotalAdjIssuance,           " +
                        "               sum(If(scdate between '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and scdocument like '%ADJ%', ifnull(stockcard.scReceipts, 0), 0)) PresTotalAdjReceipts,           " +
                        "               sum(If(scdate between '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.screceiptsAmount, 0), 0)) PresTotalReceiptsAmount,           " +
                        "               sum(If(scdate between '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "' and '" + Frm_mctdetails.mctdate_dp.Value.ToString("yyyy-MM-dd") + "', ifnull(stockcard.scIssuanceAmount, 0), 0)) PresTotalIssuanceAmount           " +
                        "       from ItemIndex           " +
                        "       left join stockcard on (ItemIndex.iicode = stockcard.sccode)           " +
                        "       where stockcard.scaverage <> 0 "+
                        " and ItemIndex.IICode in (";  */

            qry = " Select                    " +
                  "      f.itemcode,                    " +
                  "      f.itemname,                    " +
                  "      f.category,                    " +
                  "      f.closingdate,                    " +
                  "      ROUND((f.average + unitcost) / (f.actualqty + f.quantity), 2) as Amount,                    " +
                  "      f.acamacodein,                    " +
                  "      f.acamacodeout                    " +
                  "      from                    " +
                  "      ( SELECT                    " +
                  "              i.itemcode,                    " +
                  "              i.itemname,                    " +
                  "              i.category,                    " +
                  "              i.closingdate,                    " +
                  "              ifnull(i.actualqty, 0) actualqty,                    " +
                  "              ifnull(i.average, 0) as average,                    " +
                  "              sum(ifnull(r.unitcost, 0)) unitcost,                    " +
                  "              sum(ifnull(r.quantity, 0)) quantity,                    " +
                  "              i.acamacodein,                    " +
                  "              i.acamacodeout                    " +
                  "          FROM zanecoinvphp.tbl_itemindex i                    " +
                  "          right join zanecoinvphp.tbl_receiptsdetails r on r.itemcode = i.itemcode and                    " +
                  "                                             DATE_FORMAT(r.datelogs, '%Y-%m-%d') > DATE_FORMAT(i.closingdate, '%Y-%m-%d')                    " +
                  "          where i.itemcode in (";
                 
                        
                
                Boolean startloop = true;
                foreach (DataGridViewRow dgv in Frm_mctdetails.tb_dbGrid.Rows)
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

            qry = qry + "       ) group by i.itemcode  " +
                        "       ) f                     ";


            cmd = new MySqlCommand(qry, conn_tmp);

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = 0;
                    foreach (DataGridViewRow dgv in Frm_mctdetails.tb_dbGrid.Rows)
                    {
                        
                        try
                        {
                           // MessageBox.Show(dgv.Cells[3].Value.ToString() + "\n " + dr.GetString("Itemcode"));
                            if ((dgv.Cells[3].Value.ToString() == dr.GetString("Itemcode")) && (Frm_mctdetails.mctno_tf.Text.Substring(0, 3) != "MTT"))
                            {
                                if (count <= rowCnt-1)
                                {
                                    //dgv.Cells[9].Value = double.Parse(dr.GetString("Amount")) * double.Parse(dgv.Cells[6].Value.ToString());//--
                                    //dgv.Cells[8].Value = dr.GetString("Amount");//--
                                }
                                else
                                {
                                    dgv.Cells[10].Value = double.Parse(dr.GetString("Amount")) * double.Parse(dgv.Cells[6].Value.ToString());//--
                                    //dgv.Cells[8].Value = dr.GetString("Amount");//--
                                }
                                
                            }
                        }
                        catch
                        {
                           // MessageBox.Show(ex.Message);
                        }

                        count++;
                    }

                    
                }

                dr.Close();
                conn_tmp.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }

            //===============Forwarded Area Enabled========================
            //=============================================================
            if (Frm_mctdetails.mctno_tf.Text.Substring(0, 3) == "MTT")
            {
                Frm_mctdetails.panel6.Enabled = true;
            }
            else
            {
                Frm_mctdetails.panel6.Enabled = false;
                Frm_mctdetails.Forwarded_cb.Checked = false;
                Frm_mctdetails.txtAreaFrom.Text = "";
                Frm_mctdetails.txtAreaTo.Text = "";
            }

            //load credit details of mct===============================
            /*try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();
                cnt = 0;

                while (dr.Read())
                {                                   

                    Frm_mctdetails.tb_dbGrid.Rows.Add("",
                                                      "...",
                                                      "",
                                                      dr.GetString("scparticulars"),
                                                      dr.GetString("scissuance"),
                                                      "",
                                                      "0.00",
                                                      "0.00",
                                                      "0.00",
                                                      "",
                                                      "",
                                                      mctno_,
                                                      "",
                                                      "",
                                                      DateTime.Now,
                                                      dr.GetString("sccode"),
                                                      dr.GetString("iditemindex"),
                                                      dr.GetString("globalid"),
                                                      cnt);

                    Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[8].Style.ForeColor = Color.Red;//MediumTurquoise
                    Frm_mctdetails.tb_dbGrid.Rows[rowCnt].Cells[7].Style.ForeColor = Color.Black;
                    rowCnt++;
                    cnt++;
                }

                dr.Close();
                conn_tmp.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }*/


        }
        private void loadmct()
        {
            /*String qry = "   Select   " +
                         "      f.*  " +
                         "      from  " +
                         "      (  SELECT  " +
                         "          i.idate,  " +
                         "          i.inumber as mct,  " +
                         "          i.idescription,  " +
                         "          i.Requisitioner,  " +
                         "          a.idmaterialct  " +
                         "     FROM zanecoinv.issuance i  " +
                         "     left join zanecoaccounting.materialct a on a.mctno = i.inumber  " +
                         "     where i.inumber like @mctno and i.idate between @dateFrom and @dateTo  " +
                         "     ) f where f.idmaterialct is NULL order by f.idate  ";*/

            String qry = "   Select  " +
                         "      f.*  " +
                         "      from  " +
                         "      (SELECT  " +
                         "          i.idate,  " +
                         "          i.inumber as mct,  " +
                         "          i.purpose idescription,  " +
                         "          i.requester Requisitioner,  " +
                         "          a.idmaterialct  " +
                         "     FROM zanecoinvphp.tbl_issuance i  " +
                         "     left join zanecoaccounting.materialct a on a.mctno = i.inumber  " +
                         "     where i.inumber like @mctno and i.idate between @dateFrom and @dateTo " +
                         "     ) f where f.idmaterialct is NULL order by f.idate  ";



            ds = new DataSet();

            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);

                da.SelectCommand.Parameters.AddWithValue("@dateFrom", From_dp.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateTo", To_dp.Value);
                da.SelectCommand.Parameters.AddWithValue("@mctno", "%" + search_tf.Text + "%");
                da.Fill(ds, "mct");
                tblDatagridView.AutoGenerateColumns = false;
                tblDatagridView.DataSource = ds.Tables["mct"];

                da.Dispose();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }

        }

        private void referencemctFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            From_dp.Value = uc.StartOfMonth;
            To_dp.Value = uc.EndOfMonth;

            loadmct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadmct();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.RefreshDgv();
            Close();
        }

        private void referencemctFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RefreshDgv();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void From_dp_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
