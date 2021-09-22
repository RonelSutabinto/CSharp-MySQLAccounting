namespace zaneco_Accounting_System
{
    partial class setcutoffFrm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setcutoffFrm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tb_dbgdview = new System.Windows.Forms.DataGridView();
            this.accountcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unpostedAmnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addAccntCode_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.unposted_cb = new System.Windows.Forms.CheckBox();
            this.print_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewPostedTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUnpostedTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_dbgdview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1152, 34);
            this.panel2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(18, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Set Cut-off Date ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 51);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(154, 22);
            this.dateTimePicker1.TabIndex = 21;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Cut-off Date";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 415);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1114, 23);
            this.progressBar1.TabIndex = 23;
            // 
            // tb_dbgdview
            // 
            this.tb_dbgdview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_dbgdview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountcode,
            this.AccountName,
            this.balance,
            this.unpostedAmnt,
            this.debit,
            this.credit,
            this.ucredit});
            this.tb_dbgdview.ContextMenuStrip = this.contextMenuStrip1;
            this.tb_dbgdview.Location = new System.Drawing.Point(21, 88);
            this.tb_dbgdview.Name = "tb_dbgdview";
            this.tb_dbgdview.RowHeadersWidth = 28;
            this.tb_dbgdview.RowTemplate.Height = 24;
            this.tb_dbgdview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_dbgdview.Size = new System.Drawing.Size(1119, 321);
            this.tb_dbgdview.TabIndex = 25;
            // 
            // accountcode
            // 
            this.accountcode.DataPropertyName = "accountcode";
            this.accountcode.HeaderText = "AccountCode";
            this.accountcode.Name = "accountcode";
            this.accountcode.ReadOnly = true;
            // 
            // AccountName
            // 
            this.AccountName.DataPropertyName = "accountname";
            this.AccountName.HeaderText = "AccountName";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            this.AccountName.Width = 200;
            // 
            // balance
            // 
            this.balance.DataPropertyName = "Balance";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N2";
            dataGridViewCellStyle21.NullValue = "0.00";
            this.balance.DefaultCellStyle = dataGridViewCellStyle21;
            this.balance.HeaderText = "Beginning Bal.";
            this.balance.Name = "balance";
            // 
            // unpostedAmnt
            // 
            this.unpostedAmnt.DataPropertyName = "debit";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            dataGridViewCellStyle22.NullValue = "0.00";
            this.unpostedAmnt.DefaultCellStyle = dataGridViewCellStyle22;
            this.unpostedAmnt.HeaderText = "Debit";
            this.unpostedAmnt.Name = "unpostedAmnt";
            this.unpostedAmnt.ReadOnly = true;
            // 
            // debit
            // 
            this.debit.DataPropertyName = "credit";
            dataGridViewCellStyle23.Format = "N2";
            dataGridViewCellStyle23.NullValue = "0.00";
            this.debit.DefaultCellStyle = dataGridViewCellStyle23;
            this.debit.HeaderText = "Credit";
            this.debit.Name = "debit";
            // 
            // credit
            // 
            this.credit.DataPropertyName = "udebit";
            dataGridViewCellStyle24.Format = "N2";
            dataGridViewCellStyle24.NullValue = "0.00";
            this.credit.DefaultCellStyle = dataGridViewCellStyle24;
            this.credit.HeaderText = "Unposted Debit";
            this.credit.Name = "credit";
            // 
            // ucredit
            // 
            this.ucredit.DataPropertyName = "ucredit";
            dataGridViewCellStyle25.Format = "N2";
            dataGridViewCellStyle25.NullValue = "0.00";
            this.ucredit.DefaultCellStyle = dataGridViewCellStyle25;
            this.ucredit.HeaderText = "Unposted Credit";
            this.ucredit.Name = "ucredit";
            // 
            // addAccntCode_btn
            // 
            this.addAccntCode_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.addAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAccntCode_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.addAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("addAccntCode_btn.Image")));
            this.addAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAccntCode_btn.Location = new System.Drawing.Point(971, 37);
            this.addAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.addAccntCode_btn.Name = "addAccntCode_btn";
            this.addAccntCode_btn.Size = new System.Drawing.Size(169, 39);
            this.addAccntCode_btn.TabIndex = 405;
            this.addAccntCode_btn.Text = "Execute Cut-off";
            this.addAccntCode_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAccntCode_btn.UseVisualStyleBackColor = false;
            this.addAccntCode_btn.Click += new System.EventHandler(this.addAccntCode_btn_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(718, 42);
            this.label2.TabIndex = 417;
            this.label2.Text = "Current account balance will be forwarded as beginning balance to the next trans." +
    " cut-off process.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(22, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 416;
            this.label4.Text = " Note: ";
            // 
            // unposted_cb
            // 
            this.unposted_cb.AutoSize = true;
            this.unposted_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unposted_cb.Location = new System.Drawing.Point(303, 51);
            this.unposted_cb.Name = "unposted_cb";
            this.unposted_cb.Size = new System.Drawing.Size(188, 22);
            this.unposted_cb.TabIndex = 418;
            this.unposted_cb.Text = "Filter Unposted Account";
            this.unposted_cb.UseVisualStyleBackColor = true;
            this.unposted_cb.CheckedChanged += new System.EventHandler(this.unposted_cb_CheckedChanged);
            // 
            // print_btn
            // 
            this.print_btn.Image = ((System.Drawing.Image)(resources.GetObject("print_btn.Image")));
            this.print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.print_btn.Location = new System.Drawing.Point(860, 487);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(137, 35);
            this.print_btn.TabIndex = 419;
            this.print_btn.Text = "Print Preview";
            this.print_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(1003, 487);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(137, 35);
            this.close_btn.TabIndex = 421;
            this.close_btn.Text = "Close";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPostedTransToolStripMenuItem,
            this.viewUnpostedTransToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(224, 84);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // viewPostedTransToolStripMenuItem
            // 
            this.viewPostedTransToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewPostedTransToolStripMenuItem.Image")));
            this.viewPostedTransToolStripMenuItem.Name = "viewPostedTransToolStripMenuItem";
            this.viewPostedTransToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.viewPostedTransToolStripMenuItem.Text = "View Posted Trans.";
            this.viewPostedTransToolStripMenuItem.Click += new System.EventHandler(this.viewPostedTransToolStripMenuItem_Click);
            // 
            // viewUnpostedTransToolStripMenuItem
            // 
            this.viewUnpostedTransToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewUnpostedTransToolStripMenuItem.Image")));
            this.viewUnpostedTransToolStripMenuItem.Name = "viewUnpostedTransToolStripMenuItem";
            this.viewUnpostedTransToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.viewUnpostedTransToolStripMenuItem.Text = "View Unposted Trans.";
            this.viewUnpostedTransToolStripMenuItem.Click += new System.EventHandler(this.viewUnpostedTransToolStripMenuItem_Click);
            // 
            // setcutoffFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 549);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.unposted_cb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addAccntCode_btn);
            this.Controls.Add(this.tb_dbgdview);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "setcutoffFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Cut-off Account";
            this.Load += new System.EventHandler(this.setcutoffFrm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_dbgdview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView tb_dbgdview;
        private System.Windows.Forms.Button addAccntCode_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox unposted_cb;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn unpostedAmnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ucredit;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewPostedTransToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUnpostedTransToolStripMenuItem;
    }
}