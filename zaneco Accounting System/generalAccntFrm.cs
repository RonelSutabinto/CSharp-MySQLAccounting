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
    public partial class generalAccntFrm : Form
    {
        
        private addChartAccountFrm frm_addChartAccount = new addChartAccountFrm();
        public generalAccntFrm()
        {
            InitializeComponent();
        }

        public void addChartAccountInitl(addChartAccountFrm frm_addChartAccount1)
        {
            this.frm_addChartAccount = frm_addChartAccount1;
        }

        private void search_btn_Click(object sender, EventArgs e)
        {            
            this.chartGeneralAccntTableAdapter.Fill(this.chartDS.chartGeneralAccnt, "%"+ search_tf.Text+ "%", "%" + search_tf.Text + "%");
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void generalaccount_datagrid_KeyDown(object sender, KeyEventArgs e)
        {
           /*
            if (e.KeyCode == Keys.Enter)
            {
                int selectedrowindex = generalaccount_datagrid.SelectedCells[0].RowIndex;
                DataGridViewRow sRow = generalaccount_datagrid.Rows[selectedrowindex];

                frm_addChartAccount.gacode_tf.Text = sRow.Cells[0].Value.ToString();
                frm_addChartAccount.ganame_tf.Text = sRow.Cells[1].Value.ToString();

                Close();
            }*/
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = generalaccount_datagrid.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = generalaccount_datagrid.Rows[selectedrowindex];

            frm_addChartAccount.gacode_tf.Text = sRow.Cells[0].Value.ToString();
            frm_addChartAccount.ganame_tf.Text = sRow.Cells[1].Value.ToString();

            Close();
        }
    }
}
