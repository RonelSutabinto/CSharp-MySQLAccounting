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
    public partial class usersettingsFrm : Form
    {
        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        //private DataTable dt = new DataTable();
        //private MySqlDataAdapter da;

        public DataGridViewRow sRow;
        private unitClass uc = new unitClass();

        public usersettingsFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbUserType.GetItemText(cmbUserType.SelectedItem).ToString() == "")
            {
                MessageBox.Show("Please select user type..", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon. Information);
                return;
            }

            insertUser();
            loaduser();

            newEntry();

        }

        private void newEntry()
        {
            txtUserID.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
            txtPosition.Text = "";
            cmbUserType.SelectedIndex = cmbUserType.FindStringExact("");
            txtEmailID.Text = "";
            txtContactNo.Text = "";
            chkActive.Checked = false;
            chkAPV.Checked = false;
            chkCV.Checked = false;
            chkJV.Checked = false;
            chkMCT.Checked = false;
            chkUSer.Checked = false;
            chkChart.Checked = false;
        }
        private void updateUser()
        {
            String qry = "update user set " +
                         "   userID = @userID," +
                         "   password = md5(@password)," +
                         "   name = @name," +
                         "   position = @position," +
                         "   usertype = @usertype," +
                         "   emailID = @emailID," +
                         "   contactNo = @contactNo," +
                         "   status = @status," +
                         "   iscv = @iscv," +
                         "   isjv = @isjv," +
                         "   isapv = @isapv," +
                         "   ismct = @ismct," +
                         "   isuser = @isuser," +
                         "   datelog = @datelog," +
                         "   ischart = @ischart," +
                         "   isbankrecon = @isbankrecon " +
                         " where iduser = @iduser ";

            int isStatus = 0;
            int isApv = 0;
            int isMct = 0;
            int isCv = 0;
            int isJv = 0;
            int isUser = 0;
            int isChart = 0;
            int isbankrecon = 0;

            if (chkActive.Checked)
                isStatus = 1;

            if (chkCV.Checked)
                isCv = 1;

            if (chkAPV.Checked)
                isApv = 1;

            if (chkMCT.Checked)
                isMct = 1;

            if (chkJV.Checked)
                isJv = 1;

            if (chkUSer.Checked)
                isUser = 1;

            if (chkChart.Checked)
                isChart = 1;

            if (chkbankrecon.Checked)
                isbankrecon = 1;

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@userID", txtUserID.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@position", txtPosition.Text);
            cmd.Parameters.AddWithValue("@usertype", cmbUserType.GetItemText(cmbUserType.SelectedItem).ToString());
            cmd.Parameters.AddWithValue("@emailID", txtEmailID.Text);
            cmd.Parameters.AddWithValue("@contactNo", txtContactNo.Text);
            cmd.Parameters.AddWithValue("@status", isStatus);
            cmd.Parameters.AddWithValue("@iscv", isCv);
            cmd.Parameters.AddWithValue("@isjv", isJv);
            cmd.Parameters.AddWithValue("@isapv", isApv);
            cmd.Parameters.AddWithValue("@ismct", isMct);
            cmd.Parameters.AddWithValue("@isuser", isUser);
            cmd.Parameters.AddWithValue("@iduser", txtiduser_.Text);
            cmd.Parameters.AddWithValue("@ischart", isChart);
            cmd.Parameters.AddWithValue("@isbankrecon", isbankrecon);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();

                MessageBox.Show("Selected user detail successfully updated...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                // btnSave.Enabled = false;
                // btnDelete.Enabled = true;
                // btnUpdate.Enabled = true;
                // dgv.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("User detail update ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
           
        }
        private void insertUser()
        {            
            String qry = "insert into user(userID,password,name,position,usertype,emailID,contactNo,status,iscv,isjv,isapv,ismct,isuser,datelog,ischart,isbankrecon)" +
                         " values(@userID,md5(@password),@name,@position,@usertype,@emailID,@contactNo,@status,@iscv,@isjv,@isapv,@ismct,@isuser,NOW(),@ischart,@isbankrecon)";
            if (cmbUserType.GetItemText(cmbUserType.SelectedItem).ToString() == "")
                return;

            int isStatus=0;
            int isApv = 0;
            int isMct = 0;
            int isCv = 0;
            int isJv = 0;
            Boolean isUser = false;
            int isChart = 0;
            int isbankrecon = 0;

            if (chkActive.Checked)
                isStatus = 1;

            if (chkCV.Checked)
                isCv = 1;

            if (chkAPV.Checked)
                isApv = 1;

            if (chkMCT.Checked)
                isMct = 1;

            if (chkJV.Checked)
                isJv = 1;

            if (chkUSer.Checked)
                isUser = true;

            if (chkChart.Checked)
                isChart = 1;

            if (chkbankrecon.Checked)
                isbankrecon = 1;
            MessageBox.Show("User detail add ERROR: ",  uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@userID", txtUserID.Text);            
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@position", txtPosition.Text);
            cmd.Parameters.AddWithValue("@usertype", cmbUserType.GetItemText(cmbUserType.SelectedItem).ToString());
            cmd.Parameters.AddWithValue("@emailID", txtEmailID.Text);
            cmd.Parameters.AddWithValue("@contactNo", txtContactNo.Text);
            cmd.Parameters.AddWithValue("@status", isStatus);
            cmd.Parameters.AddWithValue("@iscv", isCv);
            cmd.Parameters.AddWithValue("@isjv", isJv);
            cmd.Parameters.AddWithValue("@isapv", isApv);
            cmd.Parameters.AddWithValue("@ismct", isMct);
            cmd.Parameters.AddWithValue("@isuser", isUser);            
            cmd.Parameters.AddWithValue("@ischart",isChart);
            cmd.Parameters.AddWithValue("@isbankrecon", isbankrecon);

            try
            {
                conn_tmp.Open();
                cmd.ExecuteNonQuery();
                conn_tmp.Close();

                btnSave.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                dgv.Enabled = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("User detail add ERROR: " + ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
                      
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newEntry();
            this.ActiveControl = txtUserID;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dgv.Enabled = false;
        }

        private void loaduser()
        {
            String qry = "Select userID," +
                         "       password," +
                         "       name," +
                         "       position," +
                         "       usertype," +
                         "       ifnull(emailID,'') emailID," +
                         "       ifnull(contactNo,'') contactNo," +
                         "       status," +
                         "       iscv," +
                         "       isjv," +
                         "       isapv," +
                         "       ismct," +
                         "       isuser," +
                         "       ischart," +
                         "       isbankrecon, " +
                         "       ifnull(datelog,'') datelog,iduser from user ";
            cmd = new MySqlCommand(qry,conn_tmp);

            dgv.Rows.Clear();

            try
            {
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    dgv.Rows.Add(dr.GetString("userID"),
                                 dr.GetString("usertype"),
                                 dr.GetString("name"),
                                 dr.GetString("position"),
                                 dr.GetString("emailID"),
                                 dr.GetString("contactNo"),
                                 dr.GetBoolean("status"),
                                 dr.GetString("datelog"),
                                 dr.GetString("iduser"),
                                 dr.GetString("iscv"),
                               //  dr.GetBoolean("iscv"),
                                 dr.GetBoolean("isjv"),
                                 dr.GetBoolean("isapv"),
                                 dr.GetBoolean("ismct"),
                                 dr.GetBoolean("isuser"),
                                 dr.GetBoolean("ischart"),
                                 dr.GetBoolean("isbankrecon"));
                }

                dr.Close();
                conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);         
                conn_tmp.Close();
            }

            
        }

        private void usersettingsFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();

            loaduser();

            btnSave.Enabled = false;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dgv.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = dgv.Rows[selectedrowindex];

         

            txtUserID.Text = sRow.Cells[0].Value.ToString(); 
            //txtPassword.Text = sRow.Cells[0].Value.ToString();
            txtName.Text = sRow.Cells[2].Value.ToString();
            txtPosition.Text = sRow.Cells[3].Value.ToString();
            cmbUserType.SelectedIndex = cmbUserType.FindStringExact(sRow.Cells[1].Value.ToString());
            txtEmailID.Text = sRow.Cells[4].Value.ToString();
            txtContactNo.Text = sRow.Cells[5].Value.ToString();
            chkActive.Checked =Boolean.Parse(sRow.Cells[6].Value.ToString());
            chkAPV.Checked = Boolean.Parse(sRow.Cells[11].Value.ToString());
            chkCV.Checked = Boolean.Parse(sRow.Cells[9].Value.ToString());
            chkJV.Checked = Boolean.Parse(sRow.Cells[10].Value.ToString()); 
            chkMCT.Checked = Boolean.Parse(sRow.Cells[12].Value.ToString()); 
            chkUSer.Checked = Boolean.Parse(sRow.Cells[13].Value.ToString());
            chkChart.Checked = Boolean.Parse(sRow.Cells[14].Value.ToString());
            chkbankrecon.Checked = Boolean.Parse(sRow.Cells[15].Value.ToString());
            txtiduser_.Text = sRow.Cells[8].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateUser();

            loaduser();
            newEntry();
        }
    }
}
