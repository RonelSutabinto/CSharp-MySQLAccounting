using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;
using System.Globalization;
using zaneco_Accounting_System.module;

namespace zaneco_Accounting_System
{
    public partial class invalidtransFrm : Form
    {
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        //private MySqlDataReader dr;
        private unitClass uc = new unitClass();
        private DataTable dt = new DataTable();
        
        public invalidtransFrm()
        {
            InitializeComponent();
        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            loadinvalidTrans();
        }

        private void loadinvalidTrans()
        {
            String qry = " Select f.*          " +
                        "    from(        " +
                        "    (Select sum(ifnull(cvj.debit, 0)) as debit, sum(ifnull(cvj.credit, 0)) as credit,        " +
                        "            cv.cvdate as docdate,        " +
                        "            cv.cvnumber as docno,        " +
                        "            cv.paymentDesc as description,        " +
                        "            'CV' as doctype,        " +
                        "            cv.userid," +
                        "            cv.idcheckvoucher as iddoc        " +
                        "       from cvjournal cvj        " +
                        "       left join checkvoucher cv on cv.cvnumber = cvj.cvnumber        " +
                        "       where cv.cvnumber is not null and cv.cvdate between @datefrom and @dateto group by cvj.cvnumber) union        " +
                        "    (Select sum(ifnull(ad.debit, 0)) as debit, sum(ifnull(ad.credit, 0)) as credit,        " +
                        "            a.apvdate as docdate,        " +
                        "            a.apvnumber as docno,        " +
                        "            a.pDescription as description,        " +
                        "            'APV' as doctype,        " +
                        "            a.userid,        " +
                        "            a.idAPVoucher as iddoc        " +
                        "       from apvdetails ad        " +
                        "       left join apvoucher a on a.apvnumber = ad.apvnumber        " +
                        "       where a.apvnumber is not null and a.apvdate between @datefrom and @dateto  group by ad.apvnumber) union        " +
                        "    (Select sum(ifnull(jd.debit, 0)) as debit, sum(ifnull(jd.credit, 0)) as credit,        " +
                        "            j.jvdate as docdate,        " +
                        "            j.jvnumber as docno,        " +
                        "            j.description as description,        " +
                        "            'JV' as doctype,        " +
                        "            j.userid,        " +
                        "            j.idjournal as iddoc        " +
                        "       from jvdetails jd        " +
                        "       left join journalv j on j.jvnumber = jd.jvnumber        " +
                        "       where j.jvnumber is not null and DATE_FORMAT(j.jvdate, '%Y-%m-%d') between @datefrom and @dateto  group by jd.jvnumber) union        " +
                        "    (Select sum(ifnull(mt.debit, 0)) as debit, sum(ifnull(mt.credit, 0)) as credit,        " +
                        "            m.mctdate as docdate,        " +
                        "            m.mctno as docno,        " +
                        "            m.description as description,        " +
                        "            'MCT' as doctype,        " +
                        "            m.userid,        " +
                        "            m.idmaterialct as iddoc        " +
                        "       from mctdetails mt        " +
                        "       left join materialct m on m.mctno = mt.mctno        " +
                        "       where m.mctno is not null and DATE_FORMAT(m.mctdate, '%Y-%m-%d') between @datefrom and @dateto  group by mt.mctno)        " +
                        "    ) f where f.debit<> f.credit order by f.docdate desc, f.docno asc        ";


            ds = new DataSet();

            try
            {
                conn.Open();
                da = new MySqlDataAdapter(qry, conn);                
                da.SelectCommand.Parameters.AddWithValue("@datefrom", date_from.Value);
                da.SelectCommand.Parameters.AddWithValue("@dateto", date_to.Value);

                da.Fill(ds, "doctrans");
                //chartaGridView.AutoGenerateColumns = false;
                //chartaGridView.DataSource = ds.Tables["chart"];                
                gridControl1.DataSource = ds.Tables["doctrans"];

                da.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void invalidtransFrm_Load(object sender, EventArgs e)
        {
            conn = db.getConn();
            date_from.Value = uc.StartOfMonth;
            date_to.Value = uc.EndOfMonth;

            loadinvalidTrans();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ledgertoExcel();
            SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
            saveFileDialogExcel.Title = "Export Excel";
            saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialogExcel.FileName;

                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();

                gridView1.ViewCaption = date_from.Value.ToString("MMM d, yyyy", CultureInfo.InvariantCulture) + " - " + date_to.Value.ToString("MMM d, yyyy", CultureInfo.InvariantCulture);
                gridControl1.ExportToXlsx(exportFilePath);
                DevExpress.XtraEditors.XtraMessageBox.Show("Save successful!", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {

        }

        private void updateCV()
        {
            String cvno = "";
            String code = "";

            try
            {
                checkvoucherFrm frm = new checkvoucherFrm();
                frm.Text = "Update Check Voucher (Payment)";

                GridView gridControl = new GridView();
                int RowCount = 0;
                RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;
                gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                cvno = gridControl.GetRowCellValue(RowCount, "iddoc").ToString();
                code = gridControl.GetRowCellValue(RowCount, "docno").ToString();

                if (gridControl.GetRowCellValue(RowCount, "cvpcode").ToString() == "CANCELLED")
                {
                    MessageBox.Show("Unable to update the cancelled CV entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                /*
                if (!(gridControl.GetRowCellValue(RowCount, "userID").ToString().Equals(globalmainFrm.userlog)))
                {
                    MessageBox.Show("Authorize user ID: " + gridControl.GetRowCellValue(RowCount, "userID").ToString() + "\nUnable to continue this process, restricted user entry..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


