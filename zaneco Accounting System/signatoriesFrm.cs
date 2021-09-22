using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace zaneco_Accounting_System
{
    public partial class signatoriesFrm : DevExpress.XtraEditors.XtraForm
    {
        public signatoriesFrm()
        {
            InitializeComponent();
        }

        private void cv_page_Click(object sender, EventArgs e)
        {

        }

        private void close_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}