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
using zaneco_Accounting_System.module;

namespace zaneco_Accounting_System
{
    public partial class jobentryFrm : Form
    {
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        //private MySqlDataReader dr;
        //private MySqlDataAdapter da;

        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private unitClass uc = new unitClass();
        private journalvJobFrm frm_journaljob = new journalvJobFrm();

        //==Global Event Variables===========================
        public delegate void DoEvent();
        public event DoEvent RefreshDgv;
        //==================================================

        public jobentryFrm()
        {
            InitializeComponent();
        }

        public void journaljobFrmInitl(journalvJobFrm frm_journaljob1)
        {
            this.frm_journaljob = frm_journaljob1;
        }

        private void jobentryFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
        }

        private void insertjob()
        {
            String qry = "insert into journaljob(code,name,userid,datetrans)" +
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
                MessageBox.Show("Job entry successfully saved...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Close();
                //frm_journaljob.loadjob();
            }
            catch (Exception ex)
            {
                MessageBox.Show("jod ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }
        private void updatejob()
        {
            String qry = "update journaljob set code = @code, " +
                           "                   name = @name," +
                           "                   userid = @userid," +
                           "                   datetrans = now() " +
                           " where idjournaljob = @id";

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

                MessageBox.Show("Job entry successfully saved...",uc.getMsgFrm(),MessageBoxButtons.OK,MessageBoxIcon.Information);
                //frm_journaljob.loadjob();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Job update ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(title_lb.Text == "Add Journal Job entry")
            {
                insertjob();
            }
            else if (title_lb.Text == "Update Journal Job entry")
            {
                updatejob();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void jobentryFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RefreshDgv();
        }
    }
}
