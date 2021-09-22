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
    public partial class login : Form
    {
        //private connDBtmp db_tmp = new connDBtmp();
        //private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        //private DataTable dt = new DataTable();
        //private MySqlDataAdapter da;

        public DataGridViewRow sRow;
        private unitClass uc = new unitClass();
        public login()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            logIn();           
                
            //  mainFrm frm = new mainFrm();
            //frm.MdiParent = this;  mdi m1 = (mdi)this.Parent.TopLevelControl;
            //frm.Show();
            //this.Hide();

            //shows the mdi form and hide the login form
            //Mdi_parent1 childMdi = new Mdi_parent1();
            // childMdi.Show();
            // this.Hide();

        }

        private void logIn()
        {
            try
            {
                String qry = "Select * from user where userID = @userid and password = md5(@pass)";
                cmd = new MySqlCommand(qry, globalmainFrm.getConn_accnt());
                cmd.Parameters.AddWithValue("@userid", UsernameTextBox.Text);
                cmd.Parameters.AddWithValue("@pass", PasswordTextBox.Text);
                            
                //conn_tmp.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if(dr.GetBoolean("status")==false)
                    {
                        MessageBox.Show("Unable to log-in the system, Please activate your user ID... ", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dr.Close();
                        //conn_tmp.Close();

                        this.ActiveControl = UsernameTextBox;
                        return;
                    }

                    MessageBox.Show("User successfully log ", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    mainFrm frm = new mainFrm();
                    frm.StatusLevel.Text = "User: " +
                                           dr.GetString("userID") + " - " +
                                           dr.GetString("name") + " (" +
                                           dr.GetString("userType") + ")";
                    frm.userType_Status.Text = dr.GetString("userType");
                    frm.userStatus.Text = dr.GetString("userID");
                    frm.toolStripVersion.Text = $"App. Ver. {Application.ProductVersion}";

                    frm.setisCV(dr.GetBoolean("isCV"));
                    frm.setisAPV(dr.GetBoolean("isapv"));
                    frm.setisMCT(dr.GetBoolean("ismct"));
                    frm.setisJV(dr.GetBoolean("isjv"));
                    frm.setisUser(dr.GetBoolean("isuser"));
                    frm.setisChart(dr.GetBoolean("ischart"));
                    frm.setisbankrecon(dr.GetBoolean("isbankrecon"));

                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid user ID or Password?", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = UsernameTextBox;
                }

                dr.Close();
                //conn_tmp.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("User log ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //conn_tmp.Close();
            }

            
        }

        private void login_Load(object sender, EventArgs e)
        {
            // conn_tmp = db_tmp.getConn();
            //uc.closeConn_accnt();
            // uc.setConn_accnt();

            globalmainFrm.closeConn_accnt();
            globalmainFrm.setConn_accnt();

            globalmainFrm.closeConn_budget();
            globalmainFrm.setConn_budget();

            ver_lbl.Text = $"App. Ver. {Application.ProductVersion}";
        }             

       
        private void UsernameTextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = PasswordTextBox;
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = btnLogin;
        }
    }
}
