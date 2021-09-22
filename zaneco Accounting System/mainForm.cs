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
using AutoUpdaterDotNET;

namespace zaneco_Accounting_System
{
    public partial class mainFrm : Form
    {
        private MySqlCommand cmd = new MySqlCommand();
        private DataSet ds = new DataSet();
        private MySqlDataReader dr;
        //private MySqlDataAdapter da;

        
        private unitClass uc = new unitClass();

        private int cntTmr = 0;

        private Boolean _isCV_;
        private Boolean _isAPV_;
        private Boolean _isMCT_;
        private Boolean _isJV_;
        private Boolean _isUser_;
        private Boolean _ischart_;
        private Boolean _isbankrecon_;
        //private String userID;

        public mainFrm()
        {
            InitializeComponent();

            this._isCV_ = false;
            this._isAPV_ = false;
            this._isMCT_ = false;
            this._isJV_ = false;
            this._isUser_ = false;
            this._ischart_ = false;
            this._isbankrecon_ = false;

        }

        /*public String useridlog
        {
            get { return userID; }
            set { this.userID = value; }
        }*/

        //=================================
        //=================================
        public void setisCV(Boolean iscv)
        {
            this._isCV_ = iscv;
        }
        public Boolean getisCV()
        {
            return _isCV_;
        }
        public void setisAPV(Boolean isapv)
        {
            this._isAPV_ = isapv;
        }
        public Boolean getisAPV()
        {
            return _isAPV_;
        }

        public void setisMCT(Boolean ismct)
        {
            this._isMCT_ = ismct;
        }
        public Boolean getisMCT()
        {
            return _isMCT_;
        }
        public void setisJV(Boolean isjv)
        {
            this._isJV_ = isjv;
        }
        public Boolean getisJV()
        {
            return _isJV_;
        }

        public void setisUser(Boolean isuser)
        {
            this._isUser_ = isuser;
        }
        public Boolean getisUser()
        {
            return _isUser_;
        }
        public void setisChart(Boolean ischart)
        {
            this._ischart_ = ischart;
        }
        public Boolean getisChart()
        {
            return _ischart_;
        }

        public void setisbankrecon(Boolean isbankrecon_)
        {
            this._isbankrecon_ = isbankrecon_;
        }
        //=================================
        //=================================

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
           
        timeStatus.Text = "TIME: "+DateTime.Now.ToString("HH:mm:ss tt"); 
        dateStatus.Text = "DATE: " + DateTime.Now.ToString("MMMM dd, yyyy");     
        
        }

       

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void mainFrm_Load(object sender, EventArgs e)
        {
               

            //this.userID = userStatus.Text;
            globalmainFrm.userlog = userStatus.Text;
            globalmainFrm.usertype = userType_Status.Text;

            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            AutoUpdater.Start("http://192.168.1.2/zanecoAcctg/accounting.xml");
        }

        private void jobSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void noteTmr_Tick(object sender, EventArgs e)
        {
            //dueAPV();
        }
        private void dueAPV()
        {
            //==Counter for dues APV============================
            String qry_cnt = "   Select sum(f.noapv) cntr " +
                             "   from(SELECT " +
                             "          1 as noapv, " +
                             "          sum(IFNULL(c.cvamount, 0)) amountpaidF, a.* " +
                             "    FROM apvoucher a " +
                             "    left join checkvoucher c on c.refnumber = a.apvnumber and c.cvpcode <> 'CANCELED' " +
                             "    where  a.amount > 0 and " +
                             "          CURDATE() >= a.apvduedate and " +
                             "           a.apvduedate >= DATE_SUB( CURDATE(), INTERVAL 2 YEAR) " +
                             "         group by a.apvnumber " +
                             "         ) f where f.amountpaidF < f.amount ";
            //====================================================

            if (cntTmr < 5)
            {
                String cntr_ = "0";
                try
                {
                   // conn_tmp.Open();
                    cmd = new MySqlCommand(qry_cnt, globalmainFrm.getConn_accnt());
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        cntr_ = dr.GetString("cntr");
                    }
                    dr.Close();
                    //conn_tmp.Close();
                }
                catch
                {
                    //conn_tmp.Close();
                }
                //========================================
                //========================================

                if (cntr_ != "0")
                {
                    noteAPV.Text = "Export DataTable Utility";
                    noteAPV.Visible = true;
                    noteAPV.BalloonTipTitle = cntr_ + " Dues APV";
                    noteAPV.BalloonTipText = "Click Here to see details";
                    noteAPV.ShowBalloonTip(100);
                }

            }

            if (cntTmr >= 5)
                noteTmr.Enabled = false;

            cntTmr++;
        }

        private void noteAPV_BalloonTipClicked(object sender, EventArgs e)
        {
            accntpayablevFrm frm = new accntpayablevFrm();
            frm.MdiParent = this;
            frm.setisdue(true);
            frm.Show();
        }

        private void mainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        

        private void bbiReceipts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(userType_Status.Text.Equals("Admin")))
            {
                MessageBox.Show("You don't have permission to access this interface, please refer to your system administrator.", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            usersettingsFrm frm = new usersettingsFrm();
            frm.ShowDialog();
        }

        private void close_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void chart_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((_ischart_ == false) && (userType_Status.Text.Equals("User")))
            {
                MessageBox.Show("You don't have permission to access this interface, please refer to your system administrator.", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chartAcamFrm frm = new chartAcamFrm();
            frm.MdiParent = this;
            frm.setuserType(userType_Status.Text);
            frm.Show();
        }

        private void cv_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            cvJournal frm = new cvJournal();
            frm.MdiParent = this;
            frm.setisCV(_isCV_);
            frm.Show();
        }

        private void jv_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            journalFrm frm = new journalFrm();
            frm.MdiParent = this;
            frm.setisJV(_isJV_);
            frm.Show();
        }

        private void apv_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            accntpayablevFrm frm = new accntpayablevFrm();
            frm.MdiParent = this;
            frm.setisdue(false);
            frm.setisAPV(_isAPV_);
            frm.Show();
        }

        private void mct_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mctFrm frm = new mctFrm();
            frm.MdiParent = this;
            frm.setisMCT(_isMCT_);

            frm.Show();
        }

        private void bankrecon_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bankReconFrm frm = new bankReconFrm();
            frm.setisbankrecon(_isbankrecon_);
            frm.MdiParent = this;        

            frm.Show();
        }

        private void accountCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void job_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(globalmainFrm.usertype.Equals("Admin")))
            {
                MessageBox.Show("You do not have permission to access this page, please refer to your system administrator.", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }                

            journalvJobFrm frm = new journalvJobFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void payee_menu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(globalmainFrm.usertype.Equals("Admin")))
            {
                MessageBox.Show("You do not have permission to access this page, please refer to your system administrator.", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            payeeFrm frm = new payeeFrm();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void mainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            globalmainFrm.closeConn_accnt();
            globalmainFrm.closeConn_budget();

            this.Dispose();
            this.Close();

            Application.Exit();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;           
           // AutoUpdater.Start("http://192.168.1.2/zanecoAcctg/accounting.xml");
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    var dialogResult =
                        MessageBox.Show(
                            string.Format(
                                "There is new version {0} avilable. You are using version {1}. Do you want to update the application now?",
                                args.CurrentVersion, args.InstalledVersion), @"Update Available",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        try
                        {
                            //You can use Download Update dialog used by AutoUpdater.NET to download the update.

                            AutoUpdater.DownloadPath = Application.StartupPath;
                            AutoUpdater.DownloadUpdate(args);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
               /* else
                {
                    MessageBox.Show(@"There is no update avilable please try again later.", @"No update available",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
            }
            else
            {
                MessageBox.Show(
                       @"There is a problem reaching update server please check your internet connection and try again later.",
                       @"Update check failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
