namespace zaneco_Accounting_System
{
    partial class accountLedgerFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(accountLedgerFrm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ledgerGridView = new System.Windows.Forms.DataGridView();
            this.slcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._accountname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.particular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tdebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tcredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrintRecords = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.print_btn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_totalapv = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_credit = new System.Windows.Forms.Label();
            this.lbl_debit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.accountname_tf = new System.Windows.Forms.TextBox();
            this.accountcode_tf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.date_from = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.atype_tf = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateasof_dp = new System.Windows.Forms.DateTimePicker();
            this.balance_tf = new System.Windows.Forms.TextBox();
            this.category_tf = new System.Windows.Forms.TextBox();
            this.select_btn = new System.Windows.Forms.Button();
            this.date_to = new System.Windows.Forms.DateTimePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerGridView)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1166, 34);
            this.panel2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(18, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Account Ledger";
            // 
            // ledgerGridView
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ledgerGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ledgerGridView.ColumnHeadersHeight = 35;
            this.ledgerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ledgerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slcode,
            this._accountname,
            this.docno,
            this.Reference,
            this.particular,
            this._tdebit,
            this._tcredit,
            this.pcode,
            this.refno,
            this.dtF,
            this.ctF});
            this.ledgerGridView.EnableHeadersVisualStyles = false;
            this.ledgerGridView.Location = new System.Drawing.Point(1317, 289);
            this.ledgerGridView.Name = "ledgerGridView";
            this.ledgerGridView.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ledgerGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ledgerGridView.RowHeadersWidth = 30;
            this.ledgerGridView.RowTemplate.Height = 24;
            this.ledgerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ledgerGridView.Size = new System.Drawing.Size(1245, 329);
            this.ledgerGridView.TabIndex = 19;
            this.ledgerGridView.Visible = false;
            // 
            // slcode
            // 
            this.slcode.DataPropertyName = "slcode";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slcode.DefaultCellStyle = dataGridViewCellStyle2;
            this.slcode.HeaderText = "SL Code";
            this.slcode.Name = "slcode";
            this.slcode.ReadOnly = true;
            this.slcode.Visible = false;
            this.slcode.Width = 90;
            // 
            // _accountname
            // 
            this._accountname.DataPropertyName = "date";
            this._accountname.HeaderText = "Date";
            this._accountname.Name = "_accountname";
            this._accountname.ReadOnly = true;
            this._accountname.Width = 80;
            // 
            // docno
            // 
            this.docno.DataPropertyName = "docno";
            this.docno.HeaderText = "Doc.No.";
            this.docno.Name = "docno";
            this.docno.ReadOnly = true;
            // 
            // Reference
            // 
            this.Reference.DataPropertyName = "Reference";
            this.Reference.HeaderText = "Reference";
            this.Reference.Name = "Reference";
            this.Reference.ReadOnly = true;
            // 
            // particular
            // 
            this.particular.DataPropertyName = "Description";
            this.particular.HeaderText = "Trans Description";
            this.particular.Name = "particular";
            this.particular.ReadOnly = true;
            this.particular.Width = 250;
            // 
            // _tdebit
            // 
            this._tdebit.DataPropertyName = "debit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this._tdebit.DefaultCellStyle = dataGridViewCellStyle3;
            this._tdebit.HeaderText = "Debit";
            this._tdebit.Name = "_tdebit";
            this._tdebit.ReadOnly = true;
            // 
            // _tcredit
            // 
            this._tcredit.DataPropertyName = "credit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this._tcredit.DefaultCellStyle = dataGridViewCellStyle4;
            this._tcredit.HeaderText = "Credit";
            this._tcredit.Name = "_tcredit";
            this._tcredit.ReadOnly = true;
            // 
            // pcode
            // 
            this.pcode.DataPropertyName = "pcode";
            this.pcode.HeaderText = "PayeeCode";
            this.pcode.Name = "pcode";
            this.pcode.ReadOnly = true;
            this.pcode.Visible = false;
            this.pcode.Width = 150;
            // 
            // refno
            // 
            this.refno.DataPropertyName = "refno";
            this.refno.HeaderText = "Ref.No.";
            this.refno.Name = "refno";
            this.refno.ReadOnly = true;
            this.refno.Visible = false;
            // 
            // dtF
            // 
            this.dtF.DataPropertyName = "dtF";
            this.dtF.HeaderText = "dt";
            this.dtF.Name = "dtF";
            this.dtF.ReadOnly = true;
            this.dtF.Visible = false;
            // 
            // ctF
            // 
            this.ctF.DataPropertyName = "ctF";
            this.ctF.HeaderText = "ct";
            this.ctF.Name = "ctF";
            this.ctF.ReadOnly = true;
            this.ctF.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(452, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 50);
            this.button1.TabIndex = 25;
            this.button1.Text = "Unpaid APV";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrintRecords
            // 
            this.btnPrintRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintRecords.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.btnPrintRecords.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnPrintRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnPrintRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintRecords.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintRecords.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintRecords.Image")));
            this.btnPrintRecords.Location = new System.Drawing.Point(628, 27);
            this.btnPrintRecords.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintRecords.Name = "btnPrintRecords";
            this.btnPrintRecords.Size = new System.Drawing.Size(168, 50);
            this.btnPrintRecords.TabIndex = 24;
            this.btnPrintRecords.Text = "Print Preview";
            this.btnPrintRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintRecords.UseVisualStyleBackColor = true;
            this.btnPrintRecords.Click += new System.EventHandler(this.btnPrintRecords_Click);
            // 
            // close_btn
            // 
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(977, 28);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(168, 50);
            this.close_btn.TabIndex = 23;
            this.close_btn.Text = "Close";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // print_btn
            // 
            this.print_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print_btn.Image = ((System.Drawing.Image)(resources.GetObject("print_btn.Image")));
            this.print_btn.Location = new System.Drawing.Point(803, 28);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(168, 50);
            this.print_btn.TabIndex = 18;
            this.print_btn.Text = "ExportToExcel";
            this.print_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.Controls.Add(this.lbl_totalapv);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Location = new System.Drawing.Point(25, 741);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1046, 32);
            this.panel5.TabIndex = 413;
            // 
            // lbl_totalapv
            // 
            this.lbl_totalapv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalapv.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_totalapv.Location = new System.Drawing.Point(831, 5);
            this.lbl_totalapv.Name = "lbl_totalapv";
            this.lbl_totalapv.Size = new System.Drawing.Size(201, 22);
            this.lbl_totalapv.TabIndex = 414;
            this.lbl_totalapv.Text = "0.00";
            this.lbl_totalapv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(589, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 25);
            this.label10.TabIndex = 413;
            this.label10.Text = "Ending Balance";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // lbl_credit
            // 
            this.lbl_credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_credit.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_credit.Location = new System.Drawing.Point(906, 712);
            this.lbl_credit.Name = "lbl_credit";
            this.lbl_credit.Size = new System.Drawing.Size(151, 22);
            this.lbl_credit.TabIndex = 415;
            this.lbl_credit.Text = "0.00";
            this.lbl_credit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_debit
            // 
            this.lbl_debit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_debit.Location = new System.Drawing.Point(749, 712);
            this.lbl_debit.Name = "lbl_debit";
            this.lbl_debit.Size = new System.Drawing.Size(151, 22);
            this.lbl_debit.TabIndex = 416;
            this.lbl_debit.Text = "0.00";
            this.lbl_debit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(614, 713);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 417;
            this.label1.Text = "Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(802, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 17);
            this.label11.TabIndex = 439;
            this.label11.Text = "Date To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(787, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 438;
            this.label2.Text = "Date From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 425;
            this.label4.Text = "Account Code";
            // 
            // accountname_tf
            // 
            this.accountname_tf.Location = new System.Drawing.Point(143, 50);
            this.accountname_tf.Name = "accountname_tf";
            this.accountname_tf.ReadOnly = true;
            this.accountname_tf.Size = new System.Drawing.Size(508, 23);
            this.accountname_tf.TabIndex = 424;
            // 
            // accountcode_tf
            // 
            this.accountcode_tf.Location = new System.Drawing.Point(143, 19);
            this.accountcode_tf.Name = "accountcode_tf";
            this.accountcode_tf.ReadOnly = true;
            this.accountcode_tf.Size = new System.Drawing.Size(508, 23);
            this.accountcode_tf.TabIndex = 423;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 431;
            this.label6.Text = "Beginning Balance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(787, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 430;
            this.label7.Text = "DateAsOf";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 429;
            this.label5.Text = "Account Name";
            // 
            // date_from
            // 
            this.date_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_from.Location = new System.Drawing.Point(867, 78);
            this.date_from.Name = "date_from";
            this.date_from.Size = new System.Drawing.Size(204, 23);
            this.date_from.TabIndex = 435;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 17);
            this.label9.TabIndex = 434;
            this.label9.Text = "Account Type";
            this.label9.Visible = false;
            // 
            // atype_tf
            // 
            this.atype_tf.Location = new System.Drawing.Point(143, 78);
            this.atype_tf.Name = "atype_tf";
            this.atype_tf.ReadOnly = true;
            this.atype_tf.Size = new System.Drawing.Size(508, 23);
            this.atype_tf.TabIndex = 433;
            this.atype_tf.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 432;
            this.label8.Text = "Category";
            // 
            // dateasof_dp
            // 
            this.dateasof_dp.Enabled = false;
            this.dateasof_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateasof_dp.Location = new System.Drawing.Point(867, 19);
            this.dateasof_dp.Name = "dateasof_dp";
            this.dateasof_dp.Size = new System.Drawing.Size(269, 23);
            this.dateasof_dp.TabIndex = 428;
            // 
            // balance_tf
            // 
            this.balance_tf.Location = new System.Drawing.Point(867, 50);
            this.balance_tf.Name = "balance_tf";
            this.balance_tf.ReadOnly = true;
            this.balance_tf.Size = new System.Drawing.Size(269, 23);
            this.balance_tf.TabIndex = 427;
            // 
            // category_tf
            // 
            this.category_tf.Location = new System.Drawing.Point(143, 106);
            this.category_tf.Name = "category_tf";
            this.category_tf.ReadOnly = true;
            this.category_tf.Size = new System.Drawing.Size(508, 23);
            this.category_tf.TabIndex = 426;
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select_btn.Location = new System.Drawing.Point(1077, 78);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(60, 48);
            this.select_btn.TabIndex = 437;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // date_to
            // 
            this.date_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_to.Location = new System.Drawing.Point(867, 106);
            this.date_to.Name = "date_to";
            this.date_to.Size = new System.Drawing.Size(204, 23);
            this.date_to.TabIndex = 436;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_EmbeddedNavigator_KeyDown);
            this.gridControl1.Location = new System.Drawing.Point(0, 190);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1166, 362);
            this.gridControl1.TabIndex = 450;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.HotTrack;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.HotTrack;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn12});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jvamount", this.gridColumn6, "(Amount: SUM={0:c2})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "slcode";
            this.gridColumn2.FieldName = "slcode";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 125;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Date";
            this.gridColumn1.FieldName = "date";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 120;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Doc. No.";
            this.gridColumn7.FieldName = "docno";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 119;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Reference";
            this.gridColumn3.FieldName = "Reference";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 119;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Payee";
            this.gridColumn5.FieldName = "payee";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 138;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Trans. Description";
            this.gridColumn11.FieldName = "Description";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 264;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Debit";
            this.gridColumn6.DisplayFormat.FormatString = "c2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "debit";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "SUM={0:c2}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 170;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Credit";
            this.gridColumn8.DisplayFormat.FormatString = "c2";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "credit";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "SUM={0:c2}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 170;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "pcode";
            this.gridColumn4.FieldName = "pcode";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 94;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "refno";
            this.gridColumn9.FieldName = "refno";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 94;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "dtF";
            this.gridColumn10.FieldName = "dtF";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 94;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "ctF";
            this.gridColumn12.FieldName = "ctF";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 94;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label11);
            this.panelControl1.Controls.Add(this.accountcode_tf);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.date_to);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.select_btn);
            this.panelControl1.Controls.Add(this.accountname_tf);
            this.panelControl1.Controls.Add(this.category_tf);
            this.panelControl1.Controls.Add(this.balance_tf);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.dateasof_dp);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.atype_tf);
            this.panelControl1.Controls.Add(this.date_from);
            this.panelControl1.Controls.Add(this.label9);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 34);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1166, 156);
            this.panelControl1.TabIndex = 451;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.button1);
            this.panelControl2.Controls.Add(this.btnPrintRecords);
            this.panelControl2.Controls.Add(this.print_btn);
            this.panelControl2.Controls.Add(this.close_btn);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 552);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1166, 102);
            this.panelControl2.TabIndex = 452;
            // 
            // accountLedgerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 654);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_debit);
            this.Controls.Add(this.lbl_credit);
            this.Controls.Add(this.ledgerGridView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "accountLedgerFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Ledger";
            this.Load += new System.EventHandler(this.accountLedger_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ledgerGridView;
        internal System.Windows.Forms.Button btnPrintRecords;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_totalapv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn slcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn _accountname;
        private System.Windows.Forms.DataGridViewTextBoxColumn docno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn particular;
        private System.Windows.Forms.DataGridViewTextBoxColumn _tdebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _tcredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn refno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctF;
        private System.Windows.Forms.Label lbl_credit;
        private System.Windows.Forms.Label lbl_debit;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox accountname_tf;
        public System.Windows.Forms.TextBox accountcode_tf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker date_from;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox atype_tf;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DateTimePicker dateasof_dp;
        public System.Windows.Forms.TextBox balance_tf;
        public System.Windows.Forms.TextBox category_tf;
        internal System.Windows.Forms.Button select_btn;
        public System.Windows.Forms.DateTimePicker date_to;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}