using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zaneco_Accounting_System
{
    public partial class procDetailsFrm : Form
    {
        public procDetailsFrm()
        {
            InitializeComponent();
        }

        private void closeProc_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
