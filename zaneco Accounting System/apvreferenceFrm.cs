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
    public partial class apvreferenceFrm : Form
    {
        
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
        private apvdetailsFrm apvdetails_Frm = new apvdetailsFrm();


        public apvreferenceFrm()
        {
            InitializeComponent();
        }

        public void apvdetailsFrmInitl(apvdetailsFrm apvdetails_Frm1)
        {
            apvdetails_Frm = apvdetails_Frm1;
        }

        private void loadallocatedRvPo()
        {
            //rvpoDatagridView.EnableHeadersVisualStyles = false;
            //rvpoDatagridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;

            String qry = " Select f.*  from(      " +
                         "    Select      " +
                         "         fnl.*      " +
                         //"         IFNULL(a.docnumber, IFNULL(c.refnumber, NULL)) ifexistdoc      " +
                         "       from(      " +
                         "         (SELECT      " +
                         "                  j.documentdate date,      " +
                         "                  j.documenttype doctype,      " +
                         "                  j.documentnumber budgetNo,      " +
                         "                  j.documentnumber docno,      " +
                         "                  j.credit amount,       " +
                         "                  r.rvpcode pcode,      " +
                         "                  r.rvname pname,      " +
                         "                  r.rvdescription,      " +
                         "                  '' as address ,     " +
                         "                  r.rvdate "+
                         "               FROM zanecobudget.journal j      " +
                         "               left join requisition r on r.rvnumber = j.documentnumber      " +
                         "                where j.documentdate between @from  and @to and      " +
                         "                      j.documenttype = 'RV')      " +
                         "              union      " +
                         /*"              (Select      " +
                         "                  rr.rdate as date,      " +
                         "                  'RR' as doctype,      " +
                         "                  rr.rponumber as budgetno,      " +
                         "                  rr.rnumber as docno,      " +
                         "                  rr.ramount as amount,      " +
                         "                  rr.rsuppliercode as pcode,      " +
                         "                  rr.rsuppliername as pname,      " +
                         "                  r.rvdescription,      " +
                         "                  rr.raddress as address,      " +
                         "                  r.rvdate " +
                         "               from zanecoinvphp.receipts rr      " +
                         "               left join zanecobudget.po p on p.ponumber = rr.rponumber      " +
                         "               left join zanecobudget.podetail pd on pd.idpo = p.idpo      " +
                         "               left join zanecobudget.requisitiondetail rd on rd.idrequisitiondetail = pd.idrequisitiondetail      " +
                         "               left join zanecobudget.requisition r on r.idrequisition = rd.idrequisition      " +
                         "               where rr.rdate between @from  and @to )      " +*/
                         "            (Select   " +
                         "              rr.receivedate as date,        " +
                         "              'RR' as doctype,         " +
                         "              rr.ponumber as budgetno,         " +
                         "              rr.rrnumber as docno,         " +
                         "              Round(sum(rrd.quantity * rrd.unitcost), 2) as amount,         " +
                         "              rr.suppliers as pcode,         " +
                         "              ifnull(s.suppliername,'') as pname,       " +
                         "              r.rvdescription,         " +
                         "              s.address as address,         " +
                         "              r.rvdate   " +
                         "           from zanecoinvphp.tbl_receipts rr   " +
                         "           left join zanecoinvphp.tbl_receiptsdetails rrd on rrd.rrnumber = rr.rrnumber   " +
                         "           left join zanecobudget.po p on p.ponumber = rr.ponumber   " +
                         "           left join zanecobudget.podetail pd on pd.idpo = p.idpo   " +
                         "           left join zanecobudget.requisitiondetail rd on rd.idrequisitiondetail = pd.idrequisitiondetail   " +
                         "           left join zanecobudget.requisition r on r.idrequisition = rd.idrequisition   " +
                         "           left join zanecoinvphp.tbl_supplier s on s.suppliercode = rr.suppliers   " +
                         "           where rr.receivedate between @from and @to   " +
                         "           group by rr.rrnumber)  " +
                         "            union" +
                         "         (SELECT      " +
                         "                  r.rvdate date,      " +
                         "                  'RV' doctype,      " +
                         "                  r.rvnumber budgetNo,      " +
                         "                  r.rvnumber docno,      " +
                         "                  ifnull(r.amount,0) amount,       " +
                         "                  r.rvpcode pcode,      " +
                         "                  r.rvname pname,      " +
                         "                  r.rvdescription,      " +
                         "                  '' as address ,     " +
                         "                  r.rvdate " +
                         "               FROM zanecobudget.requisition r      " +                        
                         "                where r.rvdate between @from  and @to and   " +
                         "                      YEAR(now())> YEAR(r.rvdate) and" +
                         "                      not exists (Select * from zanecobudget.journal jo where jo.documentnumber = r.rvnumber ) )      " +
                         "      ) fnl   " +
                        // "      left join zanecoaccounting.checkvoucher c on c.refnumber = fnl.docno      " +
                        // "      left join zanecoaccounting.apvoucher a on a.docnumber = fnl.docno      " +
                         "       Where   fnl.docno like @refno  or fnl.pcode like  @refno) f      " +
                         // "   where f.ifexistdoc is null      " +
                         "   order by f.date,f.docno      ";

            ds = new DataSet();

            try
            {
                conn_budgettmp.Open();                
                da = new MySqlDataAdapter(qry, conn_budgettmp);

                da.SelectCommand.Parameters.AddWithValue("@from",rvproFrom.Value);
                da.SelectCommand.Parameters.AddWithValue("@to",rvproTo.Value);
                da.SelectCommand.Parameters.AddWithValue("@refno", "%"+searchrvpo_tf.Text+"%");
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

        private void searchrvpo_tf_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void apvreferenceFrm_Load(object sender, EventArgs e)
        {
            conn_budgettmp = db_bget.getConn();
            conn_tmp = db_tmp.getConn();
            conn_bget = db_bget.getConn();

            rvproFrom.Value = uc.StartOfMonth;
            rvproTo.Value = uc.EndOfMonth;

            loadallocatedRvPo();
        }
        
        private void selectrefNo()
        {
            CultureInfo ci = new CultureInfo("en-us");
            //=======LOAD APV===================================
            //==================================================
            int selectedrowindex = rvpoDatagridView.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = rvpoDatagridView.Rows[selectedrowindex];

            try
            {
                apvdetails_Frm.refno_tf.Text = sRow.Cells[2].Value.ToString();
            }
            catch { }

            try
            {
                apvdetails_Frm.pcode_tf.Text = sRow.Cells[5].Value.ToString();
            }
            catch { }

            try
            {
                apvdetails_Frm.pname_tf.Text = sRow.Cells[6].Value.ToString();
            }
            catch { }

            try
            {
                apvdetails_Frm.desc_tf.Text = sRow.Cells[7].Value.ToString();
            }
            catch { }

            try
            {
                apvdetails_Frm.apvamount_tf.Text = Double.Parse(sRow.Cells[3].Value.ToString()).ToString("N02", ci);
            }
            catch { }

            try
            {
                apvdetails_Frm.rvno_tf.Text = sRow.Cells[4].Value.ToString();
            }
            catch { }
            // apvdetails_Frm.rvdate_dp.Value = DateTime.Parse(sRow.Cells[8].Value.ToString());

            try
            {
                apvdetails_Frm.paddress_tf.Text = sRow.Cells[9].Value.ToString();
            }
            catch { }

            /*String qry = "Select * from payee where pcode = '" + sRow.Cells[7].Value.ToString() + "'";
            try
            {          
                cmd = new MySqlCommand(qry, conn_tmp);
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    apvdetails_Frm.paddress_tf.Text = dr["Address"].ToString();

                dr.Close();               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn_tmp.Close();
            }*/

            //=====LOAD APV DETAIL=================================
            //=====================================================
            Double amountT = 0.00;
            String qry = "    (Select     " +
                         "       rd.rddescription as description,       " +
                         "       rd.rdqty as qty,      " +
                         "       rd.rdunit as unit,       " +
                         "       rd.rdcost as cost,           " +
                         "       format((rd.rdqty * rd.rdcost), 2) as amount,     " +
                         "       '' as acodein,     " +
                         "       '' as anamein,     " +
                         "       '' as acodeout,     " +
                         "       '' as anameout,      " +
                         "       '' as glacode,    " +
                         "       '' as glaname    " +                        
                         "       from requisition r     " +
                         "       left join zanecobudget.requisitiondetail rd on rd.idrequisition = r.idrequisition     " +
                         "       where r.rvnumber = @docno and     " +
                         "              @doctype = 'RV')      " +
                         "      union     " +
                         "      (select     " +
                         "       s.particulars as description,     " +
                         "       s.quantity as qty,     " +
                         "       s.dmog_unit as unit,     " +
                         "       s.unitcost as cost,     " +
                         "       format((s.unitcost * s.quantity), 2) amount,     " +
                         "       i.acamacodein acodein,     " +
                         "       c.accountname anamein,     " +
                         "       i.acamacodeout acodeout,     " +
                         "       cc.accountname anameout,     " +
                         "       c.glaccountcode as glacode,     " +
                         "       c.glaccountname as glaname     " +
                         "      from zanecoinvphp.tbl_receiptsdetails s     " +
                         "      left join zanecoinvphp.tbl_itemindex i on i.itemcode = s.itemcode     " +
                         " left join zanecoaccounting.chart c on c.accountcode = i.acamacodein     " +
                         " left join zanecoaccounting.chart cc on cc.accountcode = i.acamacodeout     " +
                         "      where s.rrnumber = @docno and     " +
                         "         @doctype = 'RR' )    ";

            /*"      (select     " +
            "       s.scparticulars as description,     " +
            "       s.screceipts as qty,     " +
            "       s.scunits as unit,     " +
            "       s.screceiptscost as cost,     " +
            "       format((s.screceiptscost * s.screceipts), 2) amount,     " +
            "       i.acamacodein acodein,     " +
            "       i.acamanamein anamein,     " +
            "       i.acamacodeout acodeout,     " +
            "       i.acamanameout anameout,     " +
            "       c.glaccountcode as glacode,    " +
            "       c.glaccountname as glaname    " +                        
            "      from zanecoinv.stockcard s     " +
            "      left join zanecoinv.itemindex i on i.globalid = s.globalid   " +
            "      left join zanecoaccounting.chart c on c.accountcode = i.acamacodein  " +                         
            "      where s.scdocument = @docno and     " +
            "         @doctype = 'RR')     ";*/

            String docnoStr = "";
            String doctypeStr = "";

            //MessageBox.Show("Ronel");

            try
            {
                docnoStr = sRow.Cells[2].Value.ToString();
            }
            catch { }

            try
            {
                doctypeStr = sRow.Cells[1].Value.ToString();
            }
            catch { }

            cmd = new MySqlCommand(qry, conn_bget);
            cmd.Parameters.AddWithValue("@docno", docnoStr);
            cmd.Parameters.AddWithValue("@doctype", doctypeStr);

            //========DEBIT Details================================
            //=====================================================
            apvdetails_Frm.tb_dbGrid.Rows.Clear();
            apvdetails_Frm.refdetailDatagrid.Rows.Clear();
            try
            {
                conn_bget.Open();
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    apvdetails_Frm.tb_dbGrid.Rows.Add(dr.GetString("description"),
                                                      dr.GetString("acodein"),
                                                      "...",
                                                      dr.GetString("anamein"),
                                                      dr.GetString("Amount"),
                                                      "0.00",
                                                      dr.GetString("glacode"),
                                                      dr.GetString("glaname"),
                                                      dr.GetString("qty"),
                                                      dr.GetString("unit"),
                                                      dr.GetString("cost"),
                                                      "",
                                                      dr.GetString("acodein"),
                                                      dr.GetString("anamein"),
                                                      dr.GetString("acodeout"),
                                                      dr.GetString("anameout"),
                                                      dr.GetString("Amount"));

                    apvdetails_Frm.refdetailDatagrid.Rows.Add(dr.GetString("qty"),
                                                              dr.GetString("description"),
                                                              dr.GetString("unit"),
                                                              dr.GetString("cost"), 
                                                              dr.GetString("Amount"));

                    amountT = amountT + dr.GetDouble("Amount");
                }

                apvdetails_Frm.apvamount_tf.Text = amountT.ToString("N02", ci);
                dr.Close();
                conn_bget.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                conn_bget.Close();
            }

            //=====CREDIT Details====================================
            //=======================================================
            /*try
            {
                conn_bget.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    apvdetails_Frm.tb_dbGrid.Rows.Add(dr.GetString("description"),
                                                      "",
                                                      "...",
                                                      "",
                                                      "0.00",
                                                      dr.GetString("Amount"),
                                                      "",
                                                      "",
                                                      dr.GetString("qty"),
                                                      dr.GetString("unit"),
                                                      dr.GetString("cost"));
                }

                dr.Close();
                conn_bget.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dr.Close();
                conn_bget.Close();
            }*/

            
        }

        private void rvpoclose_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rvposelect_btn_Click(object sender, EventArgs e)
        {
            selectrefNo();
            //apvdetails_Frm.sumDC();
            Close();
        }

        private void rvpoDatagridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rvpodetails_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
