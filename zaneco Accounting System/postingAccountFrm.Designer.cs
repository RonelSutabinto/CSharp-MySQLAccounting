namespace zaneco_Accounting_System
{
    partial class postingAccountFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(postingAccountFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.posting_btn = new System.Windows.Forms.Button();
            this.tb_dbgdview = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printPreviewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.mmyy_tf = new System.Windows.Forms.TextBox();
            this.searchCode_btn = new System.Windows.Forms.Button();
            this.postporgress = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_tranNo = new System.Windows.Forms.Label();
            this.checkPosted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.accountcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glaccountcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glaccountname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unpostedAmnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accounttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cutoffdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2.Size = new System.Drawing.Size(846, 34);
            this.panel2.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(18, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Posting of Account";
            // 
            // posting_btn
            // 
            this.posting_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.posting_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.posting_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posting_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.posting_btn.Image = ((System.Drawing.Image)(resources.GetObject("posting_btn.Image")));
            this.posting_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.posting_btn.Location = new System.Drawing.Point(611, 45);
            this.posting_btn.Margin = new System.Windows.Forms.Padding(0);
            this.posting_btn.Name = "posting_btn";
            this.posting_btn.Size = new System.Drawing.Size(210, 39);
            this.posting_btn.TabIndex = 409;
            this.posting_btn.Text = "Execute Posting";
            this.posting_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.posting_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.posting_btn.UseVisualStyleBackColor = false;
            this.posting_btn.Click += new System.EventHandler(this.posting_btn_Click);
            // 
            // tb_dbgdview
            // 
            this.tb_dbgdview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_dbgdview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkPosted,
            this.accountcode,
            this.accountname,
            this.glaccountcode,
            this.glaccountname,
            this.balance,
            this.unpostedAmnt,
            this.credit,
            this.accounttype,
            this.cnt,
            this.total,
            this.cutoffdate});
            this.tb_dbgdview.ContextMenuStrip = this.contextMenuStrip1;
            this.tb_dbgdview.Location = new System.Drawing.Point(21, 91);
            this.tb_dbgdview.Name = "tb_dbgdview";
            this.tb_dbgdview.RowHeadersWidth = 28;
            this.tb_dbgdview.RowTemplate.Height = 24;
            this.tb_dbgdview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_dbgdview.Size = new System.Drawing.Size(800, 297);
            this.tb_dbgdview.TabIndex = 408;
            this.tb_dbgdview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_dbgdview_CellClick);
            this.tb_dbgdview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_dbgdview_CellValueChanged);
            this.tb_dbgdview.CurrentCellDirtyStateChanged += new System.EventHandler(this.tb_dbgdview_CurrentCellDirtyStateChanged);
            this.tb_dbgdview.Click += new System.EventHandler(this.tb_dbgdview_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPreviewDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(218, 30);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // printPreviewDetailsToolStripMenuItem
            // 
            this.printPreviewDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewDetailsToolStripMenuItem.Image")));
            this.printPreviewDetailsToolStripMenuItem.Name = "printPreviewDetailsToolStripMenuItem";
            this.printPreviewDetailsToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.printPreviewDetailsToolStripMenuItem.Text = "Print Preview Details";
            this.printPreviewDetailsToolStripMenuItem.Click += new System.EventHandler(this.printPreviewDetailsToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 407;
            this.label1.Text = "MMYY";
            // 
            // mmyy_tf
            // 
            this.mmyy_tf.Location = new System.Drawing.Point(76, 54);
            this.mmyy_tf.Name = "mmyy_tf";
            this.mmyy_tf.ReadOnly = true;
            this.mmyy_tf.Size = new System.Drawing.Size(282, 22);
            this.mmyy_tf.TabIndex = 410;
            // 
            // searchCode_btn
            // 
            this.searchCode_btn.BackColor = System.Drawing.Color.LightSlateGray;
            this.searchCode_btn.FlatAppearance.BorderSize = 0;
            this.searchCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchCode_btn.Font = new System.Drawing.Font("Century Gothic", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchCode_btn.ForeColor = System.Drawing.Color.White;
            this.searchCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("searchCode_btn.Image")));
            this.searchCode_btn.Location = new System.Drawing.Point(361, 53);
            this.searchCode_btn.Margin = new System.Windows.Forms.Padding(4);
            this.searchCode_btn.Name = "searchCode_btn";
            this.searchCode_btn.Size = new System.Drawing.Size(44, 25);
            this.searchCode_btn.TabIndex = 411;
            this.searchCode_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchCode_btn.UseVisualStyleBackColor = false;
            this.searchCode_btn.Click += new System.EventHandler(this.searchCode_btn_Click);
            // 
            // postporgress
            // 
            this.postporgress.Location = new System.Drawing.Point(200, 394);
            this.postporgress.MarqueeAnimationSpeed = 500;
            this.postporgress.Name = "postporgress";
            this.postporgress.Size = new System.Drawing.Size(621, 23);
            this.postporgress.Step = 1;
            this.postporgress.TabIndex = 412;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(15, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 414;
            this.label4.Text = " Note: ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(679, 33);
            this.label2.TabIndex = 415;
            this.label2.Text = "Posting of  monthly specific account is final  and restricted for other transacti" +
    "on updates.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(21, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 416;
            this.label5.Text = "Trans. No.:";
            // 
            // lbl_tranNo
            // 
            this.lbl_tranNo.AutoSize = true;
            this.lbl_tranNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tranNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_tranNo.Location = new System.Drawing.Point(129, 397);
            this.lbl_tranNo.Name = "lbl_tranNo";
            this.lbl_tranNo.Size = new System.Drawing.Size(19, 20);
            this.lbl_tranNo.TabIndex = 417;
            this.lbl_tranNo.Text = "0";
            // 
            // checkPosted
            // 
            this.checkPosted.HeaderText = "...";
            this.checkPosted.Name = "checkPosted";
            this.checkPosted.Width = 40;
            // 
            // accountcode
            // 
            this.accountcode.DataPropertyName = "accountcode";
            this.accountcode.HeaderText = "AccountCode";
            this.accountcode.Name = "accountcode";
            // 
            // accountname
            // 
            this.accountname.DataPropertyName = "accountname";
            this.accountname.HeaderText = "accountname";
            this.accountname.Name = "accountname";
            this.accountname.Visible = false;
            // 
            // glaccountcode
            // 
            this.glaccountcode.DataPropertyName = "glaccountcode";
            this.glaccountcode.HeaderText = "glaccountcode";
            this.glaccountcode.Name = "glaccountcode";
            this.glaccountcode.Visible = false;
            // 
            // glaccountname
            // 
            this.glaccountname.DataPropertyName = "glaccountname";
            this.glaccountname.HeaderText = "glaccountname";
            this.glaccountname.Name = "glaccountname";
            this.glaccountname.Visible = false;
            // 
            // balance
            // 
            this.balance.DataPropertyName = "pmonth";
            this.balance.HeaderText = "PMonth";
            this.balance.Name = "balance";
            // 
            // unpostedAmnt
            // 
            this.unpostedAmnt.DataPropertyName = "debit";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.unpostedAmnt.DefaultCellStyle = dataGridViewCellStyle1;
            this.unpostedAmnt.HeaderText = "Debit";
            this.unpostedAmnt.Name = "unpostedAmnt";
            // 
            // credit
            // 
            this.credit.DataPropertyName = "credit";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.credit.DefaultCellStyle = dataGridViewCellStyle2;
            this.credit.HeaderText = "Credit";
            this.credit.Name = "credit";
            // 
            // accounttype
            // 
            this.accounttype.DataPropertyName = "accounttype";
            this.accounttype.HeaderText = "accounttype";
            this.accounttype.Name = "accounttype";
            this.accounttype.Visible = false;
            // 
            // cnt
            // 
            this.cnt.DataPropertyName = "cnt";
            this.cnt.HeaderText = "Trans. No.";
            this.cnt.Name = "cnt";
            this.cnt.Width = 80;
            // 
            // total
            // 
            this.total.DataPropertyName = "cntT";
            this.total.HeaderText = "total";
            this.total.Name = "total";
            this.total.Visible = false;
            // 
            // cutoffdate
            // 
            this.cutoffdate.DataPropertyName = "cutoffdate";
            this.cutoffdate.HeaderText = "cutoffdate";
            this.cutoffdate.Name = "cutoffdate";
            this.cutoffdate.Visible = false;
            // 
            // postingAccountFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 487);
            this.Controls.Add(this.lbl_tranNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.postporgress);
            this.Controls.Add(this.searchCode_btn);
            this.Controls.Add(this.mmyy_tf);
            this.Controls.Add(this.posting_btn);
            this.Controls.Add(this.tb_dbgdview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "postingAccountFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Posting of Account";
            this.Load += new System.EventHandler(this.postingAccountFrm_Load);
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
        private System.Windows.Forms.Button posting_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchCode_btn;
        private System.Windows.Forms.ProgressBar postporgress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printPreviewDetailsToolStripMenuItem;
        public System.Windows.Forms.DataGridView tb_dbgdview;
        public System.Windows.Forms.TextBox mmyy_tf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_tranNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkPosted;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountname;
        private System.Windows.Forms.DataGridViewTextBoxColumn glaccountcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn glaccountname;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn unpostedAmnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn accounttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cutoffdate;
    }
}