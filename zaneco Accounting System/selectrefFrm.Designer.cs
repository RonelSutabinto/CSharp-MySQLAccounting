namespace zaneco_Accounting_System
{
    partial class selectrefFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectrefFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rvpoDatagridView = new System.Windows.Forms.DataGridView();
            this.docno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approveddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rvnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountApprove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issuedAmnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rvdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rvdescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apprv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rvproTo = new System.Windows.Forms.DateTimePicker();
            this.rvproFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.searchrvpo_tf = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rvpodetails_btn = new System.Windows.Forms.Button();
            this.rvpoclose_btn = new System.Windows.Forms.Button();
            this.rvposelect_btn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.apvClose_btn = new System.Windows.Forms.Button();
            this.apvSelect_btn = new System.Windows.Forms.Button();
            this.apvGridView = new System.Windows.Forms.DataGridView();
            this.apvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountpaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceApv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.apvTo_dp = new System.Windows.Forms.DateTimePicker();
            this.apvFrom_dp = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.apvSearch_tf = new System.Windows.Forms.TextBox();
            this.apvload_btn = new System.Windows.Forms.Button();
            this.journalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.journalBudget = new zaneco_Accounting_System.DataSource.journalBudget();
            this.journalTableAdapter = new zaneco_Accounting_System.DataSource.journalBudgetTableAdapters.journalTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rvpoDatagridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apvGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1048, 27);
            this.panel2.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1048, 549);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rvpoDatagridView);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.rvproTo);
            this.tabPage3.Controls.Add(this.rvproFrom);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.searchrvpo_tf);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.rvpodetails_btn);
            this.tabPage3.Controls.Add(this.rvpoclose_btn);
            this.tabPage3.Controls.Add(this.rvposelect_btn);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1040, 515);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Approved RV/Purchase Order";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rvpoDatagridView
            // 
            this.rvpoDatagridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rvpoDatagridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docno,
            this.doc,
            this.approveddate,
            this.doctype,
            this.rvnumber,
            this.documentnumber,
            this.amountApprove,
            this.issuedAmnt,
            this.identry,
            this.rvdate,
            this.pcode_,
            this.pname_,
            this.rvdescription,
            this.accountname,
            this.balance,
            this.apprv,
            this.req});
            this.rvpoDatagridView.Location = new System.Drawing.Point(16, 72);
            this.rvpoDatagridView.Name = "rvpoDatagridView";
            this.rvpoDatagridView.ReadOnly = true;
            this.rvpoDatagridView.RowHeadersWidth = 28;
            this.rvpoDatagridView.RowTemplate.Height = 24;
            this.rvpoDatagridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rvpoDatagridView.Size = new System.Drawing.Size(981, 363);
            this.rvpoDatagridView.TabIndex = 314;
            this.rvpoDatagridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rvpoDatagridView_KeyDown);
            // 
            // docno
            // 
            this.docno.DataPropertyName = "docno";
            this.docno.HeaderText = "docno";
            this.docno.Name = "docno";
            this.docno.ReadOnly = true;
            this.docno.Visible = false;
            // 
            // doc
            // 
            this.doc.DataPropertyName = "doc";
            this.doc.HeaderText = "doc";
            this.doc.Name = "doc";
            this.doc.ReadOnly = true;
            this.doc.Visible = false;
            // 
            // approveddate
            // 
            this.approveddate.DataPropertyName = "approveddate";
            this.approveddate.HeaderText = "Date";
            this.approveddate.Name = "approveddate";
            this.approveddate.ReadOnly = true;
            // 
            // doctype
            // 
            this.doctype.DataPropertyName = "doctype";
            this.doctype.HeaderText = "doctype";
            this.doctype.Name = "doctype";
            this.doctype.ReadOnly = true;
            this.doctype.Visible = false;
            // 
            // rvnumber
            // 
            this.rvnumber.DataPropertyName = "rvnumber";
            this.rvnumber.HeaderText = "rvnumber";
            this.rvnumber.Name = "rvnumber";
            this.rvnumber.ReadOnly = true;
            this.rvnumber.Visible = false;
            // 
            // documentnumber
            // 
            this.documentnumber.DataPropertyName = "documentnumber";
            this.documentnumber.HeaderText = "Doc.No.";
            this.documentnumber.Name = "documentnumber";
            this.documentnumber.ReadOnly = true;
            // 
            // amountApprove
            // 
            this.amountApprove.DataPropertyName = "amountApproveF";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amountApprove.DefaultCellStyle = dataGridViewCellStyle1;
            this.amountApprove.HeaderText = "Alloc. Amnt";
            this.amountApprove.Name = "amountApprove";
            this.amountApprove.ReadOnly = true;
            // 
            // issuedAmnt
            // 
            this.issuedAmnt.DataPropertyName = "amountpaidF";
            this.issuedAmnt.HeaderText = "IssuedAmnt";
            this.issuedAmnt.Name = "issuedAmnt";
            this.issuedAmnt.ReadOnly = true;
            this.issuedAmnt.Visible = false;
            // 
            // identry
            // 
            this.identry.DataPropertyName = "identry";
            this.identry.HeaderText = "identry";
            this.identry.Name = "identry";
            this.identry.ReadOnly = true;
            this.identry.Visible = false;
            // 
            // rvdate
            // 
            this.rvdate.DataPropertyName = "rvdate";
            this.rvdate.HeaderText = "rvdate";
            this.rvdate.Name = "rvdate";
            this.rvdate.ReadOnly = true;
            this.rvdate.Visible = false;
            // 
            // pcode_
            // 
            this.pcode_.DataPropertyName = "pcode_";
            this.pcode_.HeaderText = "Payee Code";
            this.pcode_.Name = "pcode_";
            this.pcode_.ReadOnly = true;
            this.pcode_.Width = 120;
            // 
            // pname_
            // 
            this.pname_.DataPropertyName = "pname_";
            this.pname_.HeaderText = "Payee Name";
            this.pname_.Name = "pname_";
            this.pname_.ReadOnly = true;
            this.pname_.Visible = false;
            this.pname_.Width = 170;
            // 
            // rvdescription
            // 
            this.rvdescription.DataPropertyName = "rvdescription";
            this.rvdescription.HeaderText = "Description";
            this.rvdescription.Name = "rvdescription";
            this.rvdescription.ReadOnly = true;
            this.rvdescription.Width = 300;
            // 
            // accountname
            // 
            this.accountname.DataPropertyName = "accountname";
            this.accountname.HeaderText = "accountname";
            this.accountname.Name = "accountname";
            this.accountname.ReadOnly = true;
            this.accountname.Visible = false;
            // 
            // balance
            // 
            this.balance.DataPropertyName = "bal_";
            this.balance.HeaderText = "balance";
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            this.balance.Visible = false;
            // 
            // apprv
            // 
            this.apprv.DataPropertyName = "amountpaid";
            this.apprv.HeaderText = "paid";
            this.apprv.Name = "apprv";
            this.apprv.ReadOnly = true;
            // 
            // req
            // 
            this.req.DataPropertyName = "amountreq";
            this.req.HeaderText = "req";
            this.req.Name = "req";
            this.req.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(611, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 309;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(421, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 308;
            this.label5.Text = "From";
            // 
            // rvproTo
            // 
            this.rvproTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rvproTo.Location = new System.Drawing.Point(645, 33);
            this.rvproTo.Name = "rvproTo";
            this.rvproTo.Size = new System.Drawing.Size(130, 24);
            this.rvproTo.TabIndex = 307;
            // 
            // rvproFrom
            // 
            this.rvproFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rvproFrom.Location = new System.Drawing.Point(475, 33);
            this.rvproFrom.Name = "rvproFrom";
            this.rvproFrom.Size = new System.Drawing.Size(130, 24);
            this.rvproFrom.TabIndex = 306;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 18);
            this.label6.TabIndex = 305;
            this.label6.Text = "Doc.No/Payee Code";
            // 
            // searchrvpo_tf
            // 
            this.searchrvpo_tf.BackColor = System.Drawing.Color.White;
            this.searchrvpo_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchrvpo_tf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.searchrvpo_tf.Location = new System.Drawing.Point(16, 36);
            this.searchrvpo_tf.Margin = new System.Windows.Forms.Padding(4);
            this.searchrvpo_tf.Name = "searchrvpo_tf";
            this.searchrvpo_tf.Size = new System.Drawing.Size(316, 26);
            this.searchrvpo_tf.TabIndex = 304;
            this.searchrvpo_tf.TextChanged += new System.EventHandler(this.searchrvpo_tf_TextChanged);
            this.searchrvpo_tf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchrvpo_tf_KeyDown);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(339, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 32);
            this.button1.TabIndex = 303;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rvpodetails_btn
            // 
            this.rvpodetails_btn.Image = ((System.Drawing.Image)(resources.GetObject("rvpodetails_btn.Image")));
            this.rvpodetails_btn.Location = new System.Drawing.Point(604, 441);
            this.rvpodetails_btn.Name = "rvpodetails_btn";
            this.rvpodetails_btn.Size = new System.Drawing.Size(127, 50);
            this.rvpodetails_btn.TabIndex = 310;
            this.rvpodetails_btn.Text = "Details";
            this.rvpodetails_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rvpodetails_btn.UseVisualStyleBackColor = true;
            // 
            // rvpoclose_btn
            // 
            this.rvpoclose_btn.Image = ((System.Drawing.Image)(resources.GetObject("rvpoclose_btn.Image")));
            this.rvpoclose_btn.Location = new System.Drawing.Point(870, 441);
            this.rvpoclose_btn.Name = "rvpoclose_btn";
            this.rvpoclose_btn.Size = new System.Drawing.Size(127, 50);
            this.rvpoclose_btn.TabIndex = 312;
            this.rvpoclose_btn.Text = "Close";
            this.rvpoclose_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rvpoclose_btn.UseVisualStyleBackColor = true;
            this.rvpoclose_btn.Click += new System.EventHandler(this.rvpoclose_btn_Click);
            // 
            // rvposelect_btn
            // 
            this.rvposelect_btn.Image = ((System.Drawing.Image)(resources.GetObject("rvposelect_btn.Image")));
            this.rvposelect_btn.Location = new System.Drawing.Point(737, 441);
            this.rvposelect_btn.Name = "rvposelect_btn";
            this.rvposelect_btn.Size = new System.Drawing.Size(127, 50);
            this.rvposelect_btn.TabIndex = 311;
            this.rvposelect_btn.Text = "Select";
            this.rvposelect_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rvposelect_btn.UseVisualStyleBackColor = true;
            this.rvposelect_btn.Click += new System.EventHandler(this.rvposelect_btn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Bisque;
            this.tabPage2.Controls.Add(this.apvClose_btn);
            this.tabPage2.Controls.Add(this.apvSelect_btn);
            this.tabPage2.Controls.Add(this.apvGridView);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.apvTo_dp);
            this.tabPage2.Controls.Add(this.apvFrom_dp);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.apvSearch_tf);
            this.tabPage2.Controls.Add(this.apvload_btn);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1040, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Accounts Payable Voucher";
            // 
            // apvClose_btn
            // 
            this.apvClose_btn.Image = ((System.Drawing.Image)(resources.GetObject("apvClose_btn.Image")));
            this.apvClose_btn.Location = new System.Drawing.Point(881, 452);
            this.apvClose_btn.Name = "apvClose_btn";
            this.apvClose_btn.Size = new System.Drawing.Size(127, 50);
            this.apvClose_btn.TabIndex = 417;
            this.apvClose_btn.Text = "Close";
            this.apvClose_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.apvClose_btn.UseVisualStyleBackColor = true;
            this.apvClose_btn.Click += new System.EventHandler(this.apvClose_btn_Click);
            // 
            // apvSelect_btn
            // 
            this.apvSelect_btn.Image = ((System.Drawing.Image)(resources.GetObject("apvSelect_btn.Image")));
            this.apvSelect_btn.Location = new System.Drawing.Point(748, 452);
            this.apvSelect_btn.Name = "apvSelect_btn";
            this.apvSelect_btn.Size = new System.Drawing.Size(127, 50);
            this.apvSelect_btn.TabIndex = 416;
            this.apvSelect_btn.Text = "Select";
            this.apvSelect_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.apvSelect_btn.UseVisualStyleBackColor = true;
            this.apvSelect_btn.Click += new System.EventHandler(this.apvSelect_btn_Click);
            // 
            // apvGridView
            // 
            this.apvGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apvGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apvno,
            this.pcode,
            this.date,
            this.amount,
            this.amountpaid,
            this.duedate,
            this.payee,
            this.paddress,
            this.pDescription,
            this.balanceApv});
            this.apvGridView.Location = new System.Drawing.Point(27, 72);
            this.apvGridView.Name = "apvGridView";
            this.apvGridView.ReadOnly = true;
            this.apvGridView.RowHeadersWidth = 28;
            this.apvGridView.RowTemplate.Height = 24;
            this.apvGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.apvGridView.Size = new System.Drawing.Size(981, 363);
            this.apvGridView.TabIndex = 415;
            // 
            // apvno
            // 
            this.apvno.DataPropertyName = "apvNumber";
            this.apvno.HeaderText = "APV No.";
            this.apvno.Name = "apvno";
            this.apvno.ReadOnly = true;
            // 
            // pcode
            // 
            this.pcode.DataPropertyName = "pcode";
            this.pcode.HeaderText = "Payee Code";
            this.pcode.Name = "pcode";
            this.pcode.ReadOnly = true;
            this.pcode.Width = 200;
            // 
            // date
            // 
            this.date.DataPropertyName = "apvDate";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 80;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 90;
            // 
            // amountpaid
            // 
            this.amountpaid.DataPropertyName = "amountpaidF";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.amountpaid.DefaultCellStyle = dataGridViewCellStyle3;
            this.amountpaid.HeaderText = "AmntPaid";
            this.amountpaid.Name = "amountpaid";
            this.amountpaid.ReadOnly = true;
            this.amountpaid.Width = 90;
            // 
            // duedate
            // 
            this.duedate.DataPropertyName = "apvduedate";
            this.duedate.HeaderText = "DueDate";
            this.duedate.Name = "duedate";
            this.duedate.ReadOnly = true;
            this.duedate.Width = 80;
            // 
            // payee
            // 
            this.payee.DataPropertyName = "pName";
            this.payee.HeaderText = "payee";
            this.payee.Name = "payee";
            this.payee.ReadOnly = true;
            this.payee.Visible = false;
            // 
            // paddress
            // 
            this.paddress.DataPropertyName = "pAddress";
            this.paddress.HeaderText = "paddress";
            this.paddress.Name = "paddress";
            this.paddress.ReadOnly = true;
            this.paddress.Visible = false;
            // 
            // pDescription
            // 
            this.pDescription.DataPropertyName = "pDescription";
            this.pDescription.HeaderText = "pDescription";
            this.pDescription.Name = "pDescription";
            this.pDescription.ReadOnly = true;
            this.pDescription.Visible = false;
            // 
            // balanceApv
            // 
            this.balanceApv.DataPropertyName = "bal_";
            this.balanceApv.HeaderText = "balance";
            this.balanceApv.Name = "balanceApv";
            this.balanceApv.ReadOnly = true;
            this.balanceApv.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 316;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 315;
            this.label2.Text = "From";
            // 
            // apvTo_dp
            // 
            this.apvTo_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.apvTo_dp.Location = new System.Drawing.Point(656, 33);
            this.apvTo_dp.Name = "apvTo_dp";
            this.apvTo_dp.Size = new System.Drawing.Size(130, 24);
            this.apvTo_dp.TabIndex = 314;
            // 
            // apvFrom_dp
            // 
            this.apvFrom_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.apvFrom_dp.Location = new System.Drawing.Point(486, 33);
            this.apvFrom_dp.Name = "apvFrom_dp";
            this.apvFrom_dp.Size = new System.Drawing.Size(130, 24);
            this.apvFrom_dp.TabIndex = 313;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 18);
            this.label3.TabIndex = 312;
            this.label3.Text = "APV No./ Payee Code";
            // 
            // apvSearch_tf
            // 
            this.apvSearch_tf.BackColor = System.Drawing.Color.White;
            this.apvSearch_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apvSearch_tf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.apvSearch_tf.Location = new System.Drawing.Point(27, 36);
            this.apvSearch_tf.Margin = new System.Windows.Forms.Padding(4);
            this.apvSearch_tf.Name = "apvSearch_tf";
            this.apvSearch_tf.Size = new System.Drawing.Size(316, 26);
            this.apvSearch_tf.TabIndex = 311;
            this.apvSearch_tf.TextChanged += new System.EventHandler(this.apvSearch_tf_TextChanged);
            this.apvSearch_tf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.apvSearch_tf_KeyDown);
            // 
            // apvload_btn
            // 
            this.apvload_btn.AutoSize = true;
            this.apvload_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.apvload_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("apvload_btn.BackgroundImage")));
            this.apvload_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.apvload_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.apvload_btn.Location = new System.Drawing.Point(350, 33);
            this.apvload_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.apvload_btn.Name = "apvload_btn";
            this.apvload_btn.Size = new System.Drawing.Size(34, 32);
            this.apvload_btn.TabIndex = 310;
            this.apvload_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.apvload_btn.UseVisualStyleBackColor = false;
            this.apvload_btn.Click += new System.EventHandler(this.apvload_btn_Click);
            // 
            // journalBindingSource
            // 
            this.journalBindingSource.DataMember = "journal";
            this.journalBindingSource.DataSource = this.journalBudget;
            // 
            // journalBudget
            // 
            this.journalBudget.DataSetName = "journalBudget";
            this.journalBudget.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // journalTableAdapter
            // 
            this.journalTableAdapter.ClearBeforeFill = true;
            // 
            // selectrefFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 576);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "selectrefFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Reference Number";
            this.Load += new System.EventHandler(this.selectrefFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rvpoDatagridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apvGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalBudget)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource journalBindingSource;
        private DataSource.journalBudget journalBudget;
        private DataSource.journalBudgetTableAdapters.journalTableAdapter journalTableAdapter;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker rvproTo;
        private System.Windows.Forms.DateTimePicker rvproFrom;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox searchrvpo_tf;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button rvpodetails_btn;
        private System.Windows.Forms.Button rvpoclose_btn;
        private System.Windows.Forms.Button rvposelect_btn;
        private System.Windows.Forms.DataGridView rvpoDatagridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker apvTo_dp;
        private System.Windows.Forms.DateTimePicker apvFrom_dp;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox apvSearch_tf;
        internal System.Windows.Forms.Button apvload_btn;
        private System.Windows.Forms.DataGridView apvGridView;
        private System.Windows.Forms.Button apvClose_btn;
        private System.Windows.Forms.Button apvSelect_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apvno;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountpaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn duedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn payee;
        private System.Windows.Forms.DataGridViewTextBoxColumn paddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceApv;
        private System.Windows.Forms.DataGridViewTextBoxColumn docno;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn approveddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctype;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountApprove;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuedAmnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn identry;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode_;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname_;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvdescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountname;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn apprv;
        private System.Windows.Forms.DataGridViewTextBoxColumn req;
    }
}