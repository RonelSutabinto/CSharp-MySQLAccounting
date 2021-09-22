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
using zaneco_Accounting_System.module;

namespace zaneco_Accounting_System
{
    public partial class payeeFrm : Form
    {
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        //private MySqlDataReader dr;
        private MySqlDataAdapter da;

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();

        public payeeFrm()
        {
            InitializeComponent();
        }

        

        private void Close_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void add_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            code_tf.Text = "";
            name_tf.Text = "";

            cvlbl.Text = "(Add Record)";
            entryPanel.Location = new Point(480, 147);
            entryPanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entryPanel.Visible = false;
        }

        private void edit_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

            code_tf.Text = gridControl.GetRowCellValue(RowCount, "PCode").ToString();
            name_tf.Text = gridControl.GetRowCellValue(RowCount, "Name").ToString();
            id_tf.Text = gridControl.GetRowCellValue(RowCount, "idpayee").ToString();

            cvlbl.Text = "(Edit Record)";
            entryPanel.Location = new Point(480, 147);
            entryPanel.Visible = true;
        }

        public void loadpayee()
        {
            String qry = "Select * from payee where active =1";

            ds = new DataSet();

            try
            {
                conn_tmp.Open();
                da = new MySqlDataAdapter(qry, conn_tmp);
                //da.SelectCommand.Parameters.AddWithValue("@code", "%" + "" + "%");

                da.Fill(ds, "payee");               
                gridControl1.DataSource = ds.Tables["payee"];

                da.Dispose();
                conn_tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

        private void payeeFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            loadpayee();
        }

        private void refresh_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadpayee();
        }

        private void okcancel_btn_Click(object sender, EventArgs e)
        {
            if (cvlbl.Text == "(Add Record)")
            {
                insertpayee();
            }
            else if (cvlbl.Text=="(Edit Record)")
            {
                updatepayee();
            }
        }

        private void insertpayee()
        {
            String qry = "insert into payee(PCode,Name,userid,datetrans)" +
                         " values (@code,@name,@userid,now())";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@code", code_tf.Text);
            cmd.Parameters.AddWithValue("@name", name_tf.Text);
            cmd.Parameters.AddWithValue("@userid", globalmainFrm.userlog);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();
                MessageBox.Show("Payee entry successfully saved...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                entryPanel.Visible = false;
                loadpayee();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Payee ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }
        private void updatepayee()
        {
            String qry = "update payee set PCode = @code, " +
                           "               Name = @name," +
                           "               userid = @userid," +
                           "               datetrans = now() " +
                           " where idpayee = @id";

            try
            {
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@code", code_tf.Text);
                cmd.Parameters.AddWithValue("@name", name_tf.Text);
                cmd.Parameters.AddWithValue("@id", id_tf.Text);
                cmd.Parameters.AddWithValue("@userid", globalmainFrm.userlog);

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();

                MessageBox.Show("Payee entry successfully saved...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                entryPanel.Visible = false;
                loadpayee();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Payee update ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }

        private void inactivepayee(String id)
        {
            String qry = "update payee set active = 0, " +
                         "               userid = @userid," +
                         "               datetrans = now() " +
                         " where idpayee = @id";

            try
            {
                cmd = new MySqlCommand(qry, conn_tmp);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userid", globalmainFrm.userlog);

                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();

                MessageBox.Show("Selected Payee successfully deleted...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                entryPanel.Visible = false;
                loadpayee();
            }
            catch
            { }
        }

        private void delete_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView gridControl = new GridView();
            int RowCount = 0;
            RowCount = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle;

            gridControl = (gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView);

                      
            DialogResult d = MessageBox.Show("Payee Code.:" + gridControl.GetRowCellValue(RowCount, "PCode").ToString() + "\n Are you sure, you want to delete this Payee?", uc.getMsgFrm() + " (Question)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                inactivepayee(gridControl.GetRowCellValue(RowCount, "idpayee").ToString());
                loadpayee();
            }
           
        }
    }
}
