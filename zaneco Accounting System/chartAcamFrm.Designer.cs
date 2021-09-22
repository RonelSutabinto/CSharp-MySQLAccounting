namespace zaneco_Accounting_System
{
    partial class chartAcamFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chartAcamFrm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.menuAccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAccountCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAccountCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeEndingAmntBalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeEndingAmntBalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dateasof_dp = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEndingbal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtaname = new System.Windows.Forms.TextBox();
            this.txtacode = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.trialdate_p = new System.Windows.Forms.Panel();
            this.btnprint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.daterange_dp = new System.Windows.Forms.DateTimePicker();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zerot_cb = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.date_from = new System.Windows.Forms.DateTimePicker();
            this.date_to = new System.Windows.Forms.DateTimePicker();
            this.select_btn = new System.Windows.Forms.Button();
            this.ldgrTpe_cb = new System.Windows.Forms.ComboBox();
            this.CodeName_tf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.invalidtrans_btn = new System.Windows.Forms.Button();
            this.exportExcel_btn = new System.Windows.Forms.Button();
            this.close_bnt = new System.Windows.Forms.Button();
            this.trialBal_btn = new System.Windows.Forms.Button();
            this.genLedger_btn = new System.Windows.Forms.Button();
            this.setForward_btn = new System.Windows.Forms.Button();
            this.editAccntCode_btn = new System.Windows.Forms.Button();
            this.addAccntCode_btn = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.menuAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.trialdate_p.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.trialdate_p);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1902, 717);
            this.panel3.TabIndex = 15;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.menuAccount;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_EmbeddedNavigator_KeyDown);
            this.gridControl1.Location = new System.Drawing.Point(252, 78);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1650, 639);
            this.gridControl1.TabIndex = 448;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // menuAccount
            // 
            this.menuAccount.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountCodeToolStripMenuItem,
            this.editAccountCodeToolStripMenuItem,
            this.changeEndingAmntBalToolStripMenuItem,
            this.generalLedgerToolStripMenuItem,
            this.changeEndingAmntBalToolStripMenuItem1});
            this.menuAccount.Name = "menuAccount";
            this.menuAccount.Size = new System.Drawing.Size(248, 132);
            this.menuAccount.Opening += new System.ComponentModel.CancelEventHandler(this.menuAccount_Opening);
            // 
            // addAccountCodeToolStripMenuItem
            // 
            this.addAccountCodeToolStripMenuItem.AutoSize = false;
            this.addAccountCodeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addAccountCodeToolStripMenuItem.Image")));
            this.addAccountCodeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addAccountCodeToolStripMenuItem.Name = "addAccountCodeToolStripMenuItem";
            this.addAccountCodeToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.addAccountCodeToolStripMenuItem.Text = "Refresh Record";
            this.addAccountCodeToolStripMenuItem.Click += new System.EventHandler(this.addAccountCodeToolStripMenuItem_Click);
            // 
            // editAccountCodeToolStripMenuItem
            // 
            this.editAccountCodeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editAccountCodeToolStripMenuItem.Image")));
            this.editAccountCodeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editAccountCodeToolStripMenuItem.Name = "editAccountCodeToolStripMenuItem";
            this.editAccountCodeToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.editAccountCodeToolStripMenuItem.Text = "Add Account Code";
            this.editAccountCodeToolStripMenuItem.Click += new System.EventHandler(this.editAccountCodeToolStripMenuItem_Click);
            // 
            // changeEndingAmntBalToolStripMenuItem
            // 
            this.changeEndingAmntBalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeEndingAmntBalToolStripMenuItem.Image")));
            this.changeEndingAmntBalToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changeEndingAmntBalToolStripMenuItem.Name = "changeEndingAmntBalToolStripMenuItem";
            this.changeEndingAmntBalToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.changeEndingAmntBalToolStripMenuItem.Text = "Edit Account Code";
            this.changeEndingAmntBalToolStripMenuItem.Click += new System.EventHandler(this.changeEndingAmntBalToolStripMenuItem_Click);
            // 
            // generalLedgerToolStripMenuItem
            // 
            this.generalLedgerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generalLedgerToolStripMenuItem.Image")));
            this.generalLedgerToolStripMenuItem.Name = "generalLedgerToolStripMenuItem";
            this.generalLedgerToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.generalLedgerToolStripMenuItem.Text = "General Ledger";
            this.generalLedgerToolStripMenuItem.Click += new System.EventHandler(this.generalLedgerToolStripMenuItem_Click);
            // 
            // changeEndingAmntBalToolStripMenuItem1
            // 
            this.changeEndingAmntBalToolStripMenuItem1.Enabled = false;
            this.changeEndingAmntBalToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("changeEndingAmntBalToolStripMenuItem1.Image")));
            this.changeEndingAmntBalToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changeEndingAmntBalToolStripMenuItem1.Name = "changeEndingAmntBalToolStripMenuItem1";
            this.changeEndingAmntBalToolStripMenuItem1.Size = new System.Drawing.Size(247, 26);
            this.changeEndingAmntBalToolStripMenuItem1.Text = "Change Ending Amnt Bal";
            this.changeEndingAmntBalToolStripMenuItem1.Click += new System.EventHandler(this.changeEndingAmntBalToolStripMenuItem1_Click);
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
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", this.gridColumn7, "(Debit: SUM={0:c2})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", this.gridColumn8, "(Credit: SUM={0:c2})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "endingdebit", this.gridColumn9, "(Ending Debit: SUM={0:c2})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "endingcredit", this.gridColumn10, "(Ending Credit: SUM={0:c2})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsPrint.PrintPreview = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.ViewCaption = "Excel Ronel";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Account Code";
            this.gridColumn1.FieldName = "accountcode";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 111;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Account Name";
            this.gridColumn2.FieldName = "accountname";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 223;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Account Type";
            this.gridColumn3.FieldName = "category";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 160;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Category";
            this.gridColumn4.FieldName = "accounttype";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "DateAsOf";
            this.gridColumn5.DisplayFormat.FormatString = "d";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "dateAsOf";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 101;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Beginning Bal.";
            this.gridColumn6.DisplayFormat.FormatString = "c2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "BalAsOf";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 170;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Debit (Covered)";
            this.gridColumn7.DisplayFormat.FormatString = "c2";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Debit";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "SUM={0:c2}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 170;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Credit (Covered)";
            this.gridColumn8.DisplayFormat.FormatString = "c2";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Credit";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "SUM={0:c2}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 170;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ending Debit";
            this.gridColumn9.DisplayFormat.FormatString = "c2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "endingdebit";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "endingdebit", "SUM={0:c2}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 170;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Ending Credit";
            this.gridColumn10.DisplayFormat.FormatString = "c2";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "endingcredit";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "endingcredit", "SUM={0:c2}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 170;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "idchart";
            this.gridColumn11.FieldName = "idchart";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 94;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "idcategory";
            this.gridColumn12.FieldName = "idcategory";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 94;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.dateasof_dp);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.txtEndingbal);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.txtaname);
            this.panel5.Controls.Add(this.txtacode);
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(904, 234);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(413, 255);
            this.panel5.TabIndex = 39;
            this.panel5.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(304, 181);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 38);
            this.btnCancel.TabIndex = 330;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dateasof_dp
            // 
            this.dateasof_dp.Enabled = false;
            this.dateasof_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateasof_dp.Location = new System.Drawing.Point(146, 115);
            this.dateasof_dp.Name = "dateasof_dp";
            this.dateasof_dp.Size = new System.Drawing.Size(242, 22);
            this.dateasof_dp.TabIndex = 329;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 17);
            this.label9.TabIndex = 328;
            this.label9.Text = "Ending Balance";
            // 
            // txtEndingbal
            // 
            this.txtEndingbal.Location = new System.Drawing.Point(146, 143);
            this.txtEndingbal.Name = "txtEndingbal";
            this.txtEndingbal.Size = new System.Drawing.Size(242, 22);
            this.txtEndingbal.TabIndex = 327;
            this.txtEndingbal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndingbal_KeyDown);
            this.txtEndingbal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndingbal_KeyPress);
            this.txtEndingbal.Leave += new System.EventHandler(this.txtEndingbal_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 326;
            this.label8.Text = "Date As Of";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 325;
            this.label7.Text = "Account Name";
            // 
            // txtaname
            // 
            this.txtaname.Enabled = false;
            this.txtaname.Location = new System.Drawing.Point(146, 87);
            this.txtaname.Name = "txtaname";
            this.txtaname.Size = new System.Drawing.Size(242, 22);
            this.txtaname.TabIndex = 323;
            // 
            // txtacode
            // 
            this.txtacode.Enabled = false;
            this.txtacode.Location = new System.Drawing.Point(146, 59);
            this.txtacode.Name = "txtacode";
            this.txtacode.Size = new System.Drawing.Size(242, 22);
            this.txtacode.TabIndex = 322;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(206, 181);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 38);
            this.btnSave.TabIndex = 321;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 320;
            this.label5.Text = "Account Code";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(413, 27);
            this.panel7.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 4);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(314, 23);
            this.label6.TabIndex = 405;
            this.label6.Text = "Change Ending Balance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trialdate_p
            // 
            this.trialdate_p.Controls.Add(this.btnprint);
            this.trialdate_p.Controls.Add(this.label4);
            this.trialdate_p.Controls.Add(this.daterange_dp);
            this.trialdate_p.Controls.Add(this.panel6);
            this.trialdate_p.Location = new System.Drawing.Point(446, 200);
            this.trialdate_p.Name = "trialdate_p";
            this.trialdate_p.Size = new System.Drawing.Size(407, 168);
            this.trialdate_p.TabIndex = 38;
            this.trialdate_p.Visible = false;
            // 
            // btnprint
            // 
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.Location = new System.Drawing.Point(129, 102);
            this.btnprint.Margin = new System.Windows.Forms.Padding(0);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(133, 38);
            this.btnprint.TabIndex = 321;
            this.btnprint.Text = "Print Preview";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 320;
            this.label4.Text = "Date Range";
            // 
            // daterange_dp
            // 
            this.daterange_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.daterange_dp.Location = new System.Drawing.Point(129, 59);
            this.daterange_dp.Name = "daterange_dp";
            this.daterange_dp.Size = new System.Drawing.Size(190, 22);
            this.daterange_dp.TabIndex = 319;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(407, 27);
            this.panel6.TabIndex = 28;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 4);
            this.label21.Margin = new System.Windows.Forms.Padding(2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(314, 23);
            this.label21.TabIndex = 405;
            this.label21.Text = "Select Date Range (Trial Balance)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(367, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 24);
            this.button1.TabIndex = 404;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.zerot_cb);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.date_from);
            this.panel1.Controls.Add(this.date_to);
            this.panel1.Controls.Add(this.select_btn);
            this.panel1.Controls.Add(this.ldgrTpe_cb);
            this.panel1.Controls.Add(this.CodeName_tf);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(252, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1650, 78);
            this.panel1.TabIndex = 17;
            // 
            // zerot_cb
            // 
            this.zerot_cb.AutoSize = true;
            this.zerot_cb.Checked = true;
            this.zerot_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zerot_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zerot_cb.ForeColor = System.Drawing.Color.RoyalBlue;
            this.zerot_cb.Location = new System.Drawing.Point(937, 12);
            this.zerot_cb.Name = "zerot_cb";
            this.zerot_cb.Size = new System.Drawing.Size(291, 24);
            this.zerot_cb.TabIndex = 450;
            this.zerot_cb.Text = "View only Covered Transaction";
            this.zerot_cb.UseVisualStyleBackColor = true;
            this.zerot_cb.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(454, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 17);
            this.label11.TabIndex = 449;
            this.label11.Text = "Date To";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(439, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 448;
            this.label10.Text = "Date From";
            // 
            // date_from
            // 
            this.date_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_from.Location = new System.Drawing.Point(519, 15);
            this.date_from.Name = "date_from";
            this.date_from.Size = new System.Drawing.Size(204, 22);
            this.date_from.TabIndex = 445;
            // 
            // date_to
            // 
            this.date_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_to.Location = new System.Drawing.Point(519, 43);
            this.date_to.Name = "date_to";
            this.date_to.Size = new System.Drawing.Size(204, 22);
            this.date_to.TabIndex = 446;
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select_btn.Location = new System.Drawing.Point(348, 33);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(59, 32);
            this.select_btn.TabIndex = 412;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // ldgrTpe_cb
            // 
            this.ldgrTpe_cb.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ldgrTpe_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ldgrTpe_cb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ldgrTpe_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldgrTpe_cb.FormattingEnabled = true;
            this.ldgrTpe_cb.Items.AddRange(new object[] {
            "GL",
            "SL",
            "ALL"});
            this.ldgrTpe_cb.Location = new System.Drawing.Point(937, 37);
            this.ldgrTpe_cb.Name = "ldgrTpe_cb";
            this.ldgrTpe_cb.Size = new System.Drawing.Size(283, 26);
            this.ldgrTpe_cb.TabIndex = 402;
            this.ldgrTpe_cb.Visible = false;
            this.ldgrTpe_cb.SelectedIndexChanged += new System.EventHandler(this.ldgrTpe_cb_SelectedIndexChanged);
            // 
            // CodeName_tf
            // 
            this.CodeName_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeName_tf.Location = new System.Drawing.Point(19, 36);
            this.CodeName_tf.Name = "CodeName_tf";
            this.CodeName_tf.Size = new System.Drawing.Size(329, 27);
            this.CodeName_tf.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Code/Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(809, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 403;
            this.label2.Text = "Account Type";
            this.label2.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.invalidtrans_btn);
            this.panel4.Controls.Add(this.exportExcel_btn);
            this.panel4.Controls.Add(this.close_bnt);
            this.panel4.Controls.Add(this.trialBal_btn);
            this.panel4.Controls.Add(this.genLedger_btn);
            this.panel4.Controls.Add(this.setForward_btn);
            this.panel4.Controls.Add(this.editAccntCode_btn);
            this.panel4.Controls.Add(this.addAccntCode_btn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(252, 717);
            this.panel4.TabIndex = 16;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // invalidtrans_btn
            // 
            this.invalidtrans_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.invalidtrans_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invalidtrans_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invalidtrans_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.invalidtrans_btn.Image = ((System.Drawing.Image)(resources.GetObject("invalidtrans_btn.Image")));
            this.invalidtrans_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.invalidtrans_btn.Location = new System.Drawing.Point(18, 166);
            this.invalidtrans_btn.Margin = new System.Windows.Forms.Padding(0);
            this.invalidtrans_btn.Name = "invalidtrans_btn";
            this.invalidtrans_btn.Size = new System.Drawing.Size(216, 45);
            this.invalidtrans_btn.TabIndex = 418;
            this.invalidtrans_btn.Text = "Invalid Account Trans.";
            this.invalidtrans_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.invalidtrans_btn.UseVisualStyleBackColor = false;
            this.invalidtrans_btn.Click += new System.EventHandler(this.invalidtrans_btn_Click);
            // 
            // exportExcel_btn
            // 
            this.exportExcel_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.exportExcel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportExcel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportExcel_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.exportExcel_btn.Image = ((System.Drawing.Image)(resources.GetObject("exportExcel_btn.Image")));
            this.exportExcel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportExcel_btn.Location = new System.Drawing.Point(18, 301);
            this.exportExcel_btn.Margin = new System.Windows.Forms.Padding(0);
            this.exportExcel_btn.Name = "exportExcel_btn";
            this.exportExcel_btn.Size = new System.Drawing.Size(216, 45);
            this.exportExcel_btn.TabIndex = 417;
            this.exportExcel_btn.Text = "Export Chart of Account";
            this.exportExcel_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exportExcel_btn.UseVisualStyleBackColor = false;
            this.exportExcel_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // close_bnt
            // 
            this.close_bnt.BackColor = System.Drawing.Color.IndianRed;
            this.close_bnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_bnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_bnt.ForeColor = System.Drawing.Color.SeaShell;
            this.close_bnt.Image = ((System.Drawing.Image)(resources.GetObject("close_bnt.Image")));
            this.close_bnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_bnt.Location = new System.Drawing.Point(18, 346);
            this.close_bnt.Margin = new System.Windows.Forms.Padding(0);
            this.close_bnt.Name = "close_bnt";
            this.close_bnt.Size = new System.Drawing.Size(216, 45);
            this.close_bnt.TabIndex = 416;
            this.close_bnt.Text = "Close";
            this.close_bnt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_bnt.UseVisualStyleBackColor = false;
            this.close_bnt.Click += new System.EventHandler(this.close_bnt_Click);
            // 
            // trialBal_btn
            // 
            this.trialBal_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.trialBal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trialBal_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trialBal_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.trialBal_btn.Image = ((System.Drawing.Image)(resources.GetObject("trialBal_btn.Image")));
            this.trialBal_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.trialBal_btn.Location = new System.Drawing.Point(18, 256);
            this.trialBal_btn.Margin = new System.Windows.Forms.Padding(0);
            this.trialBal_btn.Name = "trialBal_btn";
            this.trialBal_btn.Size = new System.Drawing.Size(216, 45);
            this.trialBal_btn.TabIndex = 411;
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
            this.genLedger_btn.Location = new System.Drawing.Point(18, 211);
            this.genLedger_btn.Margin = new System.Windows.Forms.Padding(0);
            this.genLedger_btn.Name = "genLedger_btn";
            this.genLedger_btn.Size = new System.Drawing.Size(216, 45);
            this.genLedger_btn.TabIndex = 409;
            this.genLedger_btn.Text = "General Ledger";
            this.genLedger_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.genLedger_btn.UseVisualStyleBackColor = false;
            this.genLedger_btn.Click += new System.EventHandler(this.genLedger_btn_Click);
            // 
            // setForward_btn
            // 
            this.setForward_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.setForward_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setForward_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setForward_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.setForward_btn.Image = ((System.Drawing.Image)(resources.GetObject("setForward_btn.Image")));
            this.setForward_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setForward_btn.Location = new System.Drawing.Point(18, 121);
            this.setForward_btn.Margin = new System.Windows.Forms.Padding(0);
            this.setForward_btn.Name = "setForward_btn";
            this.setForward_btn.Size = new System.Drawing.Size(216, 45);
            this.setForward_btn.TabIndex = 407;
            this.setForward_btn.Text = "Cut-Off Account";
            this.setForward_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.setForward_btn.UseVisualStyleBackColor = false;
            this.setForward_btn.Click += new System.EventHandler(this.setForward_btn_Click);
            // 
            // editAccntCode_btn
            // 
            this.editAccntCode_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.editAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAccntCode_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.editAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("editAccntCode_btn.Image")));
            this.editAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editAccntCode_btn.Location = new System.Drawing.Point(18, 76);
            this.editAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.editAccntCode_btn.Name = "editAccntCode_btn";
            this.editAccntCode_btn.Size = new System.Drawing.Size(216, 45);
            this.editAccntCode_btn.TabIndex = 405;
            this.editAccntCode_btn.Text = "Update Account Code";
            this.editAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editAccntCode_btn.UseVisualStyleBackColor = false;
            this.editAccntCode_btn.Click += new System.EventHandler(this.editAccntCode_btn_Click);
            // 
            // addAccntCode_btn
            // 
            this.addAccntCode_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.addAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAccntCode_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.addAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("addAccntCode_btn.Image")));
            this.addAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAccntCode_btn.Location = new System.Drawing.Point(18, 31);
            this.addAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.addAccntCode_btn.Name = "addAccntCode_btn";
            this.addAccntCode_btn.Size = new System.Drawing.Size(216, 45);
            this.addAccntCode_btn.TabIndex = 404;
            this.addAccntCode_btn.Text = "Add Account Code";
            this.addAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAccntCode_btn.UseVisualStyleBackColor = false;
            this.addAccntCode_btn.Click += new System.EventHandler(this.addAccntCode_btn_Click);
            // 
            // chartAcamFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1910, 725);
            this.Controls.Add(this.panel3);
            this.Name = "chartAcamFrm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Chart of Account";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.chartAcam_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.menuAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.trialdate_p.ResumeLayout(false);
            this.trialdate_p.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CodeName_tf;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button setForward_btn;
        private System.Windows.Forms.Button editAccntCode_btn;
        private System.Windows.Forms.Button addAccntCode_btn;
        private System.Windows.Forms.Button trialBal_btn;
        private System.Windows.Forms.Button genLedger_btn;
        private System.Windows.Forms.Button close_bnt;
        private System.Windows.Forms.ComboBox ldgrTpe_cb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exportExcel_btn;
        private System.Windows.Forms.Panel trialdate_p;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker daterange_dp;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.ContextMenuStrip menuAccount;
        private System.Windows.Forms.ToolStripMenuItem addAccountCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAccountCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeEndingAmntBalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeEndingAmntBalToolStripMenuItem1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEndingbal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtaname;
        private System.Windows.Forms.TextBox txtacode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dateasof_dp;
        private System.Windows.Forms.ToolStripMenuItem generalLedgerToolStripMenuItem;
        internal System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DateTimePicker date_from;
        public System.Windows.Forms.DateTimePicker date_to;
        private System.Windows.Forms.CheckBox zerot_cb;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.Button invalidtrans_btn;
    }
}