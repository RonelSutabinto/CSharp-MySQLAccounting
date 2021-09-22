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

namespace zaneco_Accounting_System.Reports
{
    public partial class unpaidapvFrm : Form
    {        
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        private MySqlDataAdapter da;        

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();
  
        public unpaidapvFrm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
              

        private void select_btn_Click(object sender, EventArgs e)
        {
            loadunpaidApv();
        }

        private void loadunpaidApv()
        {
            String qry = " Select f.*,(f.ocvdamount+f.cvamount) as cvtotal from  (     "+
                         "    SELECT a.apvdate, a.pDescription, a.pcode, pname, a.docnumber,     " +
                         "           ad.*, ifnull(ocvd.amountdetail, 0) as ocvdamount, sum(ifnull(c.total, 0)) as cvamount, ifnull(a.amount, 0) as apvamount     " +
                         "    FROM zanecoaccounting.apvdetails ad     " +
                         "    left join zanecoaccounting.apvoucher a on a.apvnumber = ad.apvnumber     " +
                         "    left join zanecoaccounting.othercvdetail ocvd on ocvd.apvnumber = a.apvnumber and     " +
                         "                                                     ocvd.accountcode = ad.accountcode     " +
                         "    left join zanecoaccounting.checkvoucher c on c.refnumber = ad.apvnumber     " +
                         "    where a.apvdate between @datefrom and @dateto  and     " +
                         "          ad.accountcode = @accountcode and     " +
                         "          ifnull(ad.credit, 0) > 0 and     " +
                         "          ifnull(ocvd.amountdetail, 0) <= 0     " +
                         "    group by ad.apvnumber     " +
                         " ) f     " +
                         " where(f.ocvdamount + f.cvamount) < f.apvamount order by f.apvdate,f.apvnumber";

            ds = new DataSet();

            try
            {               

                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);

                da.SelectCommand.Parameters.AddWithValue("@datefrom",fr_date.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto",to_date.Value);
                da.SelectCommand.Parameters.AddWithValue("@accountcode",accountcode_tf.Text);

                da.Fill(ds, "apvunpaid");
                dt_gridview.AutoGenerateColumns = false;
                dt_gridview.DataSource = ds.Tables["apvunpaid"];

                da.Dispose();
                conn_tmp.Close();
               
                try
                { dt_gridview.Rows[dt_gridview.Rows.Count - 1].Cells[0].ReadOnly = true; }
                catch { }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Clone();
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void unpaidapvFrm_Load(object sender, EventArgs e)
        {            
            fr_date.Value = uc.StartOfMonth;
            to_date.Value = uc.EndOfMonth;

            conn_tmp = db_tmp.getConn();
            loadunpaidApv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkvoucherFrm frm = new checkvoucherFrm();
            frm.unpaidapvInitl(this);

            //frm.tb_dbGrid.ad
            /*frm_checkVoucher.refdetailDatagrid.Rows.Add(dr.GetString("qty"),
                                                                dr.GetString("description"),
                                                                dr.GetString("unit"),
                                                                dr.GetDouble("cost").ToString("N02", ci),
                                                                dr.GetString("amount"),
                                                                dr.GetString("accountcode"),
                                                                dr.GetString("accountname"),
                                                                dr.GetString("glaccountcode"),
                                                                dr.GetString("glaccountname"),
                                                                dr.GetString("job"),
                                                                dr.GetString("jobname"));*/
        }

        private void totalselected()
        {
            double totalapv = 0.00;
            Boolean ischeck = false;
            int rowcnt = dt_gridview.Rows.Count;
            for (int i = 0; i < rowcnt; i++)
            {
                try
                {
                    ischeck = Boolean.Parse(dt_gridview.Rows[i].Cells[0].Value.ToString());
                }
                catch { }
           
                if(ischeck)
                {
                    try
                    {
                        totalapv = totalapv + Double.Parse(dt_gridview.Rows[i].Cells[8].Value.ToString().Replace(",", ""));
                    }
                    catch
                    { }
                }

                ischeck = false;
            }

            totalapv_lbl.Text = totalapv.ToString("N02", uc.ci);
               
        }

       

        private void dt_gridview_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dt_gridview.Columns["cb_"].Index)
            {
                dt_gridview.EndEdit();
            }
        }

        private void dt_gridview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            

            if (e.ColumnIndex == dt_gridview.Columns["cb_"].Index)
            {
                //do some stuff                              
                totalselected();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int rowcnt = dt_gridview.Rows.Count;
            if (checkBox1.Checked)
            {                
                for (int i = 0; i < rowcnt-1; i++)
                    dt_gridview.Rows[i].Cells[0].Value = true;
            }
            else
            {
                for (int i = 0; i < rowcnt-1; i++)
                    dt_gridview.Rows[i].Cells[0].Value = false;
            }

            totalselected();
        }

        private void viewAPVDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apvdetailsFrm frm = new apvdetailsFrm();
            frm.Text = "Preview Accounts Payable Voucher";
            frm.unpaidapvInitl(this);

            int selectedIndex = 0;

            if (dt_gridview.Rows.Count <= 0)
                return;

            try
            {
                selectedIndex = dt_gridview.SelectedCells[0].RowIndex;
            }
            catch
            { }

            DataGridViewRow sRow = dt_gridview.Rows[selectedIndex];

            //if (sRow.Cells[2].Value.ToString() == "CANCELLED")
            //    return;

            if (dt_gridview.SelectedCells.Count > 0)
            {
                frm.setidapv(sRow.Cells[9].Value.ToString());
                frm.apvNo_lb.Text = sRow.Cells[2].Value.ToString();
                frm.ShowDialog();

            }
        }
    }
}
