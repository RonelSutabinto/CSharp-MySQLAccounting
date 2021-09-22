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
    public partial class addChartAccountFrm : Form
    {
        
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        private unitClass uc = new unitClass();
        //private unitClass uc;
        private chartAcamFrm chartAcam_frm = new chartAcamFrm();

        public addChartAccountFrm()
        {
            InitializeComponent();
        }

        public void chartAcamFrmInitl(chartAcamFrm chartAcam_frm1)
        {
            chartAcam_frm = chartAcam_frm1;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadCategoryCB()
        {
            //String qry = "Select * from ";
        }

        private void addChartAccountFrm_Load(object sender, EventArgs e)
        {           
            conn = db.getConn();

            if(frmtitle_lb.Text== "Update chart of account")
            {
               
                /*int selectedrowindex = chartAcam_frm.chartaGridView.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = chartAcam_frm.chartaGridView.Rows[selectedrowindex];

               
                accntCode_tf.Text = sRow.Cells[0].Value.ToString();
                accntName_tf.Text = sRow.Cells[1].Value.ToString();
                category_tf.Text = sRow.Cells[2].Value.ToString();
                accntType_cb.SelectedIndex = accntType_cb.FindStringExact(sRow.Cells[3].Value.ToString());
                gacode_tf.Text = sRow.Cells[9].Value.ToString();
                ganame_tf.Text = sRow.Cells[10].Value.ToString();
                txtIDchart.Text = sRow.Cells[11].Value.ToString();
                idcategory.Text = sRow.Cells[12].Value.ToString();*/
            }
        }

        private void searchCode_btn_Click(object sender, EventArgs e)
        {
            categoryFrm frm = new categoryFrm();
            frm.addChartAccountInitl(this);
            frm.ShowDialog();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (accntType_cb.GetItemText(accntType_cb.SelectedItem).ToString().Equals("GA"))
            {
                gacode_tf.Text = accntCode_tf.Text;
                ganame_tf.Text = accntName_tf.Text;
            }
            else if( !(accntType_cb.GetItemText(accntType_cb.SelectedItem).ToString().Equals("SA")))
                return;
            
            //areaTo_cb.SelectedIndex = areaTo_cb.FindStringExact("DMO");
            if (frmtitle_lb.Text.Equals("Add chart of account"))
                insertchart();
            else if (frmtitle_lb.Text.Equals("Update chart of account"))
                updatechart();            
        }

        private void gacode_tf_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGa_Click(object sender, EventArgs e)
        {
            generalAccntFrm frm = new generalAccntFrm();
            frm.addChartAccountInitl(this);
            frm.ShowDialog();
        }

        private void accntType_cb_TextChanged(object sender, EventArgs e)
        {

            if(accntType_cb.Text.Equals("GA"))
            {
                gacode_tf.Text = accntCode_tf.Text;
                ganame_tf.Text = accntName_tf.Text;
                btnGa.Enabled = false;
            }else
            {
                btnGa.Enabled = true;
            }
        }


        private void updatechart()
        {
            String qry = "update chart set" +
                         "   accountcode = @accountcode," +
                         "   accountname = @accountname," +
                         "   accounttype = @accounttype," +
                         "   glAccountcode = @glAccountcode," +
                         "   glAccountname = @glAccountname," +
                         "   idcategory = @idcategory," +
                         "   category = @category " +
                         " where idchart = @idchart ";

            try
            {
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@accountcode", accntCode_tf.Text);
                cmd.Parameters.AddWithValue("@accountname", accntName_tf.Text);
                cmd.Parameters.AddWithValue("@accounttype", accntType_cb.GetItemText(accntType_cb.SelectedItem).ToString());
                cmd.Parameters.AddWithValue("@glAccountcode", gacode_tf.Text);
                cmd.Parameters.AddWithValue("@glAccountname", ganame_tf.Text);
                cmd.Parameters.AddWithValue("@idcategory", idcategory.Text);
                cmd.Parameters.AddWithValue("@category", category_tf.Text);
                cmd.Parameters.AddWithValue("@idchart", txtIDchart.Text);                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Chart of account successfully updated...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chart of account update ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

        }

        private void insertchart()
        {
            String qry = "insert into chart(accountcode,accountname,accounttype,glAccountcode,glAccountname,idcategory,category,cstatus) " +
                         " values(@accountcode,@accountname,@accounttype,@glAccountcode,@glAccountname,@idcategory,@category,1) ";

            cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@accountcode", accntCode_tf.Text);
            cmd.Parameters.AddWithValue("@accountname", accntName_tf.Text);
            cmd.Parameters.AddWithValue("@accounttype", accntType_cb.GetItemText(accntType_cb.SelectedItem).ToString());
            cmd.Parameters.AddWithValue("@glAccountcode", gacode_tf.Text);
            cmd.Parameters.AddWithValue("@glAccountname", ganame_tf.Text);
            cmd.Parameters.AddWithValue("@idcategory", idcategory.Text);
            cmd.Parameters.AddWithValue("@category", category_tf.Text);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Chart of account successfully added...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chart of account ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
        
    }
}
