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
using DevExpress.XtraGrid.Views.Grid;
using zaneco_Accounting_System.module;

namespace zaneco_Accounting_System
{
    public partial class journalvJobFrm : Form
    {
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        //private MySqlDataReader dr;
        private MySqlDataAdapter da;

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();

        public journalvJobFrm()
        {
            InitializeComponent();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            jobentryFrm frm = new jobentryFrm();
            frm.title_lb.Text = "Add Journal Job entry";
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            
        }
        public void loadjob()
        {
            String qry = "Select * from journaljob where active = 1 and code like @code";

            ds = new DataSet();

            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);

                da.SelectCommand.Parameters.AddWithValue("@code", "%" + "" + "%");
               
                da.Fill(ds, "job");
                //dataGridView2.AutoGenerateColumns = false;
                //dataGridView2.DataSource = ds.Tables["job"];
                gridControl1.DataSource = ds.Tables["job"];

                da.Dispose();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

       
        private void journalvJobFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            loadjob();
        }

        private void gridControl1_EmbeddedNavigator_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void refresh_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadjob();
        }

        private void add_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            jobentryFrm frm = new jobentryFrm();
            frm.title_lb.Text = "Add Journal Job entry";

            //===set to global form event============================
            frm.RefreshDgv += new jobentryFrm.DoEvent(loadjob);

            frm.ShowDialog();
        }

        private void edit_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            jobentryFrm frm = new jobentryFrm();
            frm.title_lb.Text = "Update Journal Job entry";

            //===set to global form event============================
            frm.RefreshDgv += new jobentryFrm.DoEvent(loadjob);

            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

            frm.code_tf.Text = gridControl.GetRowCellValue(RowCount, "code").ToString();
            frm.name_tf.Text = gridControl.GetRowCellValue(RowCount, "name").ToString();
            frm.id_tf.Text = gridControl.GetRowCellValue(RowCount, "idjournaljob").ToString();

            frm.ShowDialog();
        }

        private void close_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void Delete_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);


            DialogResult d = MessageBox.Show("Job Code.:" + gridControl.GetRowCellValue(RowCount, "code").ToString() + "\n Are you sure, you want to delete this Job entry?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                inactivejob(gridControl.GetRowCellValue(RowCount, "idjournaljob").ToString());
                loadjob();
            }
        }

        private void inactivejob(String id)
        {
            String qry = "update journaljob set active = 0, " +
                         "               userid = @userid," +
                         "               datetrans = now() " +
                         " where idjournaljob = @id";

            try
            {
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userid", globalmainFrm.userlog);

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();

                MessageBox.Show("Selected Job successfully deleted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                loadjob();
            }
            catch
            { }
        }
    }
}
