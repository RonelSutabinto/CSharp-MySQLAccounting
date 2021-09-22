namespace zaneco_Accounting_System
{
    partial class unpostedmonthFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(unpostedmonthFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbl_datagrid = new System.Windows.Forms.DataGridView();
            this.print_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.pmonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel5.Controls.Add(this.label12);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(564, 38);
            this.panel5.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(366, 27);
            this.label12.TabIndex = 405;
            this.label12.Tag = "";
            this.label12.Text = "Unposted Monthly Transactions";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbl_datagrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tbl_datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tbl_datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pmonth,
            this.debit,
            this.Credit,
            this.cnt});
            this.tbl_datagrid.EnableHeadersVisualStyles = false;
            this.tbl_datagrid.Location = new System.Drawing.Point(15, 53);
            this.tbl_datagrid.Name = "tbl_datagrid";
            this.tbl_datagrid.ReadOnly = true;
            this.tbl_datagrid.RowTemplate.Height = 24;
            this.tbl_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbl_datagrid.Size = new System.Drawing.Size(531, 279);
            this.tbl_datagrid.TabIndex = 29;
            this.tbl_datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.refdetailDatagrid_CellContentClick);
            // 
            // print_btn
            // 
            this.print_btn.Image = ((System.Drawing.Image)(resources.GetObject("print_btn.Image")));
            this.print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.print_btn.Location = new System.Drawing.Point(348, 338);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(96, 48);
            this.print_btn.TabIndex = 422;
            this.print_btn.Text = "Select";
            this.print_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(450, 338);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(96, 48);
            this.close_btn.TabIndex = 423;
            this.close_btn.Text = "Cancel";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // pmonth
            // 
            this.pmonth.DataPropertyName = "pmonth";
            this.pmonth.HeaderText = "PMonth";
            this.pmonth.Name = "pmonth";
            this.pmonth.ReadOnly = true;
            this.pmonth.Width = 80;
            // 
            // debit
            // 
            this.debit.DataPropertyName = "debit";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.debit.DefaultCellStyle = dataGridViewCellStyle2;
            this.debit.HeaderText = "Debit";
            this.debit.Name = "debit";
            this.debit.ReadOnly = true;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "credit";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.Credit.DefaultCellStyle = dataGridViewCellStyle3;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            // 
            // cnt
            // 
            this.cnt.DataPropertyName = "cnt";
            this.cnt.HeaderText = "Trans. No.";
            this.cnt.Name = "cnt";
            this.cnt.ReadOnly = true;
            // 
            // unpostedmonthFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 408);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tbl_datagrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "unpostedmonthFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "unpostedmonthFrm";
            this.Load += new System.EventHandler(this.unpostedmonthFrm_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_datagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.DataGridView tbl_datagrid;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnt;
    }
}