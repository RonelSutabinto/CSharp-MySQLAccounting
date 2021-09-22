namespace zaneco_Accounting_System
{
    partial class forwardedbalanceFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forwardedbalanceFrm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.exportExcel_btn = new System.Windows.Forms.Button();
            this.trialBal_btn = new System.Windows.Forms.Button();
            this.genLedger_btn = new System.Windows.Forms.Button();
            this.update_btn = new System.Windows.Forms.Button();
            this.close_bnt = new System.Windows.Forms.Button();
            this.deleteAccntCode_btn = new System.Windows.Forms.Button();
            this.addAccntCode_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cutoffdate_cb = new System.Windows.Forms.ComboBox();
            this.search_tf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchCode_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cutoffgridview = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateasof = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idforwardedchart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.generalLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trialBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileteredTBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cutoffgridview)).BeginInit();
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
            this.panel2.Size = new System.Drawing.Size(1374, 34);
            this.panel2.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(18, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cut-off Account Interface";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.exportExcel_btn);
            this.panel4.Controls.Add(this.trialBal_btn);
            this.panel4.Controls.Add(this.genLedger_btn);
            this.panel4.Controls.Add(this.update_btn);
            this.panel4.Controls.Add(this.close_bnt);
            this.panel4.Controls.Add(this.deleteAccntCode_btn);
            this.panel4.Controls.Add(this.addAccntCode_btn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(252, 575);
            this.panel4.TabIndex = 21;
            // 
            // exportExcel_btn
            // 
            this.exportExcel_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.exportExcel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportExcel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportExcel_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.exportExcel_btn.Image = ((System.Drawing.Image)(resources.GetObject("exportExcel_btn.Image")));
            this.exportExcel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportExcel_btn.Location = new System.Drawing.Point(18, 196);
            this.exportExcel_btn.Margin = new System.Windows.Forms.Padding(0);
            this.exportExcel_btn.Name = "exportExcel_btn";
            this.exportExcel_btn.Size = new System.Drawing.Size(216, 34);
            this.exportExcel_btn.TabIndex = 420;
            this.exportExcel_btn.Text = "Export Trial Balance";
            this.exportExcel_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exportExcel_btn.UseVisualStyleBackColor = false;
            // 
            // trialBal_btn
            // 
            this.trialBal_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.trialBal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trialBal_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trialBal_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.trialBal_btn.Image = ((System.Drawing.Image)(resources.GetObject("trialBal_btn.Image")));
            this.trialBal_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.trialBal_btn.Location = new System.Drawing.Point(18, 162);
            this.trialBal_btn.Margin = new System.Windows.Forms.Padding(0);
            this.trialBal_btn.Name = "trialBal_btn";
            this.trialBal_btn.Size = new System.Drawing.Size(216, 34);
            this.trialBal_btn.TabIndex = 419;
            this.trialBal_btn.Text = "Trial Balance";
            this.trialBal_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.trialBal_btn.UseVisualStyleBackColor = false;
            this.trialBal_btn.Click += new System.EventHandler(this.trialBal_btn_Click);
            // 
            // genLedger_btn
            // 
            this.genLedger_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.genLedger_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genLedger_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genLedger_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.genLedger_btn.Image = ((System.Drawing.Image)(resources.GetObject("genLedger_btn.Image")));
            this.genLedger_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.genLedger_btn.Location = new System.Drawing.Point(18, 128);
            this.genLedger_btn.Margin = new System.Windows.Forms.Padding(0);
            this.genLedger_btn.Name = "genLedger_btn";
            this.genLedger_btn.Size = new System.Drawing.Size(216, 34);
            this.genLedger_btn.TabIndex = 418;
            this.genLedger_btn.Text = "General Ledger";
            this.genLedger_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.genLedger_btn.UseVisualStyleBackColor = false;
            this.genLedger_btn.Click += new System.EventHandler(this.genLedger_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.update_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.update_btn.Image = ((System.Drawing.Image)(resources.GetObject("update_btn.Image")));
            this.update_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update_btn.Location = new System.Drawing.Point(18, 60);
            this.update_btn.Margin = new System.Windows.Forms.Padding(0);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(216, 34);
            this.update_btn.TabIndex = 417;
            this.update_btn.Text = "Posting Monthly Account";
            this.update_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // close_bnt
            // 
            this.close_bnt.BackColor = System.Drawing.Color.IndianRed;
            this.close_bnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_bnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_bnt.ForeColor = System.Drawing.Color.SeaShell;
            this.close_bnt.Image = ((System.Drawing.Image)(resources.GetObject("close_bnt.Image")));
            this.close_bnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_bnt.Location = new System.Drawing.Point(18, 230);
            this.close_bnt.Margin = new System.Windows.Forms.Padding(0);
            this.close_bnt.Name = "close_bnt";
            this.close_bnt.Size = new System.Drawing.Size(216, 31);
            this.close_bnt.TabIndex = 416;
            this.close_bnt.Text = "Close";
            this.close_bnt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_bnt.UseVisualStyleBackColor = false;
            this.close_bnt.Click += new System.EventHandler(this.close_bnt_Click);
            // 
            // deleteAccntCode_btn
            // 
            this.deleteAccntCode_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.deleteAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAccntCode_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.deleteAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("deleteAccntCode_btn.Image")));
            this.deleteAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteAccntCode_btn.Location = new System.Drawing.Point(18, 94);
            this.deleteAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.deleteAccntCode_btn.Name = "deleteAccntCode_btn";
            this.deleteAccntCode_btn.Size = new System.Drawing.Size(216, 34);
            this.deleteAccntCode_btn.TabIndex = 406;
            this.deleteAccntCode_btn.Text = "Posting History";
            this.deleteAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteAccntCode_btn.UseVisualStyleBackColor = false;
            // 
            // addAccntCode_btn
            // 
            this.addAccntCode_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.addAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAccntCode_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.addAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("addAccntCode_btn.Image")));
            this.addAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAccntCode_btn.Location = new System.Drawing.Point(18, 26);
            this.addAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.addAccntCode_btn.Name = "addAccntCode_btn";
            this.addAccntCode_btn.Size = new System.Drawing.Size(216, 34);
            this.addAccntCode_btn.TabIndex = 404;
            this.addAccntCode_btn.Text = "Set Cut-off Account";
            this.addAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAccntCode_btn.UseVisualStyleBackColor = false;
            this.addAccntCode_btn.Click += new System.EventHandler(this.addAccntCode_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.cutoffdate_cb);
            this.panel1.Controls.Add(this.search_tf);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.searchCode_btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(252, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 49);
            this.panel1.TabIndex = 22;
            // 
            // cutoffdate_cb
            // 
            this.cutoffdate_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cutoffdate_cb.FormattingEnabled = true;
            this.cutoffdate_cb.Location = new System.Drawing.Point(575, 12);
            this.cutoffdate_cb.Name = "cutoffdate_cb";
            this.cutoffdate_cb.Size = new System.Drawing.Size(200, 24);
            this.cutoffdate_cb.TabIndex = 409;
            this.cutoffdate_cb.SelectedIndexChanged += new System.EventHandler(this.cutoffdate_cb_SelectedIndexChanged);
            // 
            // search_tf
            // 
            this.search_tf.Location = new System.Drawing.Point(116, 14);
            this.search_tf.Name = "search_tf";
            this.search_tf.Size = new System.Drawing.Size(294, 22);
            this.search_tf.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 408;
            this.label2.Text = "Cut-off Date";
            // 
            // searchCode_btn
            // 
            this.searchCode_btn.BackColor = System.Drawing.Color.LightSlateGray;
            this.searchCode_btn.FlatAppearance.BorderSize = 0;
            this.searchCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchCode_btn.Font = new System.Drawing.Font("Century Gothic", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchCode_btn.ForeColor = System.Drawing.Color.White;
            this.searchCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("searchCode_btn.Image")));
            this.searchCode_btn.Location = new System.Drawing.Point(417, 13);
            this.searchCode_btn.Margin = new System.Windows.Forms.Padding(4);
            this.searchCode_btn.Name = "searchCode_btn";
            this.searchCode_btn.Size = new System.Drawing.Size(36, 23);
            this.searchCode_btn.TabIndex = 398;
            this.searchCode_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchCode_btn.UseVisualStyleBackColor = false;
            this.searchCode_btn.Click += new System.EventHandler(this.searchCode_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "AccountCode";
            // 
            // cutoffgridview
            // 
            this.cutoffgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cutoffgridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.accountcode,
            this.accountname,
            this.category,
            this.dateasof,
            this.balance,
            this.debit,
            this.credit,
            this.idforwardedchart});
            this.cutoffgridview.ContextMenuStrip = this.contextMenuStrip1;
            this.cutoffgridview.Location = new System.Drawing.Point(252, 89);
            this.cutoffgridview.Name = "cutoffgridview";
            this.cutoffgridview.ReadOnly = true;
            this.cutoffgridview.RowHeadersWidth = 28;
            this.cutoffgridview.RowTemplate.Height = 24;
            this.cutoffgridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cutoffgridview.Size = new System.Drawing.Size(1106, 467);
            this.cutoffgridview.TabIndex = 24;
            // 
            // date
            // 
            this.date.DataPropertyName = "cutoffDate";
            this.date.HeaderText = "Cut-offDate";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 80;
            // 
            // accountcode
            // 
            this.accountcode.DataPropertyName = "accountcode";
            this.accountcode.HeaderText = "AccountCode";
            this.accountcode.Name = "accountcode";
            this.accountcode.ReadOnly = true;
            this.accountcode.Width = 90;
            // 
            // accountname
            // 
            this.accountname.DataPropertyName = "accountname";
            this.accountname.HeaderText = "AccountName";
            this.accountname.Name = "accountname";
            this.accountname.ReadOnly = true;
            this.accountname.Width = 200;
            // 
            // category
            // 
            this.category.DataPropertyName = "category";
            this.category.HeaderText = "Category";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // dateasof
            // 
            this.dateasof.DataPropertyName = "dateAsOf";
            this.dateasof.HeaderText = "DateAsOF";
            this.dateasof.Name = "dateasof";
            this.dateasof.ReadOnly = true;
            this.dateasof.Width = 80;
            // 
            // balance
            // 
            this.balance.DataPropertyName = "BalAsOf";
            this.balance.HeaderText = "Balance";
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            // 
            // debit
            // 
            this.debit.DataPropertyName = "debit";
            this.debit.HeaderText = "Debit";
            this.debit.Name = "debit";
            this.debit.ReadOnly = true;
            // 
            // credit
            // 
            this.credit.DataPropertyName = "credit";
            this.credit.HeaderText = "Credit";
            this.credit.Name = "credit";
            this.credit.ReadOnly = true;
            // 
            // idforwardedchart
            // 
            this.idforwardedchart.DataPropertyName = "idforwardedchart";
            this.idforwardedchart.HeaderText = "id";
            this.idforwardedchart.Name = "idforwardedchart";
            this.idforwardedchart.ReadOnly = true;
            this.idforwardedchart.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalLedgerToolStripMenuItem,
            this.trialBalanceToolStripMenuItem,
            this.fileteredTBToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(229, 110);
            // 
            // generalLedgerToolStripMenuItem
            // 
            this.generalLedgerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generalLedgerToolStripMenuItem.Image")));
            this.generalLedgerToolStripMenuItem.Name = "generalLedgerToolStripMenuItem";
            this.generalLedgerToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.generalLedgerToolStripMenuItem.Text = "General Ledger";
            this.generalLedgerToolStripMenuItem.Click += new System.EventHandler(this.generalLedgerToolStripMenuItem_Click);
            // 
            // trialBalanceToolStripMenuItem
            // 
            this.trialBalanceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("trialBalanceToolStripMenuItem.Image")));
            this.trialBalanceToolStripMenuItem.Name = "trialBalanceToolStripMenuItem";
            this.trialBalanceToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.trialBalanceToolStripMenuItem.Text = "Trial Balance";
            this.trialBalanceToolStripMenuItem.Click += new System.EventHandler(this.trialBalanceToolStripMenuItem_Click);
            // 
            // fileteredTBToolStripMenuItem
            // 
            this.fileteredTBToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileteredTBToolStripMenuItem.Image")));
            this.fileteredTBToolStripMenuItem.Name = "fileteredTBToolStripMenuItem";
            this.fileteredTBToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.fileteredTBToolStripMenuItem.Text = "Filetered Trial Balance";
            this.fileteredTBToolStripMenuItem.Click += new System.EventHandler(this.fileteredTBToolStripMenuItem_Click);
            // 
            // forwardedbalanceFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 609);
            this.Controls.Add(this.cutoffgridview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "forwardedbalanceFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cut-off Account Settings";
            this.Load += new System.EventHandler(this.forwardedbalanceFrm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cutoffgridview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button close_bnt;
        private System.Windows.Forms.Button deleteAccntCode_btn;
        private System.Windows.Forms.Button addAccntCode_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cutoffdate_cb;
        private System.Windows.Forms.TextBox search_tf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchCode_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView cutoffgridview;
        private System.Windows.Forms.Button genLedger_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountname;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateasof;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn idforwardedchart;
        private System.Windows.Forms.Button trialBal_btn;
        private System.Windows.Forms.Button exportExcel_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generalLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trialBalanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileteredTBToolStripMenuItem;
    }
}