namespace zaneco_Accounting_System
{
    partial class journalFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(journalFrm));
            this.docno_tf = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.fr_date = new System.Windows.Forms.DateTimePicker();
            this.select_btn = new System.Windows.Forms.Button();
            this.cntr_lb = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.export_bnt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.update_btn = new System.Windows.Forms.Button();
            this.close_bnt = new System.Windows.Forms.Button();
            this.deleteAccntCode_btn = new System.Windows.Forms.Button();
            this.preview_btn = new System.Windows.Forms.Button();
            this.addAccntCode_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // docno_tf
            // 
            this.docno_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docno_tf.Location = new System.Drawing.Point(132, 15);
            this.docno_tf.Name = "docno_tf";
            this.docno_tf.Size = new System.Drawing.Size(278, 27);
            this.docno_tf.TabIndex = 0;
            this.docno_tf.TextChanged += new System.EventHandler(this.docno_tf_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.to_date);
            this.panel1.Controls.Add(this.fr_date);
            this.panel1.Controls.Add(this.select_btn);
            this.panel1.Controls.Add(this.docno_tf);
            this.panel1.Controls.Add(this.cntr_lb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(250, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1235, 52);
            this.panel1.TabIndex = 17;
            // 
            // to_date
            // 
            this.to_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_date.Location = new System.Drawing.Point(766, 13);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(141, 27);
            this.to_date.TabIndex = 400;
            // 
            // fr_date
            // 
            this.fr_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fr_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fr_date.Location = new System.Drawing.Point(618, 14);
            this.fr_date.Name = "fr_date";
            this.fr_date.Size = new System.Drawing.Size(142, 27);
            this.fr_date.TabIndex = 399;
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select_btn.Location = new System.Drawing.Point(410, 13);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(59, 32);
            this.select_btn.TabIndex = 410;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // cntr_lb
            // 
            this.cntr_lb.BackColor = System.Drawing.Color.DodgerBlue;
            this.cntr_lb.Dock = System.Windows.Forms.DockStyle.Right;
            this.cntr_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntr_lb.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cntr_lb.Location = new System.Drawing.Point(1162, 3);
            this.cntr_lb.Margin = new System.Windows.Forms.Padding(3);
            this.cntr_lb.Name = "cntr_lb";
            this.cntr_lb.Padding = new System.Windows.Forms.Padding(7);
            this.cntr_lb.Size = new System.Drawing.Size(70, 46);
            this.cntr_lb.TabIndex = 408;
            this.cntr_lb.Text = "543";
            this.cntr_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cntr_lb.Click += new System.EventHandler(this.cntr_lb_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(976, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 403;
            this.label4.Text = "Trans. Category";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ALL",
            "DMO-Coll.",
            "LAO-Coll.",
            "PAO-Coll.",
            "SAO-Coll.",
            "ALL-Coll.",
            "Others"});
            this.comboBox1.Location = new System.Drawing.Point(976, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(171, 24);
            this.comboBox1.TabIndex = 402;
            this.comboBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(513, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 401;
            this.label2.Text = "Covered Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doc. No./JV Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(1489, 744);
            this.panel3.TabIndex = 19;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_EmbeddedNavigator_KeyDown);
            this.gridControl1.Location = new System.Drawing.Point(250, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1235, 684);
            this.gridControl1.TabIndex = 449;
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
            this.gridColumn4});
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
            this.gridColumn2.Caption = "idjournal";
            this.gridColumn2.FieldName = "idjournal";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 125;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "JV No.";
            this.gridColumn1.FieldName = "jvnumber";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Date";
            this.gridColumn7.FieldName = "jvdate";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 113;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "CV No.";
            this.gridColumn3.FieldName = "cvnumber";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 110;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "RV No.";
            this.gridColumn5.FieldName = "rvnumber";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 110;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Description";
            this.gridColumn11.FieldName = "description";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 250;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Amount";
            this.gridColumn6.DisplayFormat.FormatString = "c2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "jvamount";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jvamount", "SUM={0:c2}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 473;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "transCategory";
            this.gridColumn8.FieldName = "transCategory";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 167;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "userid";
            this.gridColumn4.FieldName = "userid";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 94;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.export_bnt);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.update_btn);
            this.panel4.Controls.Add(this.close_bnt);
            this.panel4.Controls.Add(this.deleteAccntCode_btn);
            this.panel4.Controls.Add(this.preview_btn);
            this.panel4.Controls.Add(this.addAccntCode_btn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 736);
            this.panel4.TabIndex = 16;
            // 
            // export_bnt
            // 
            this.export_bnt.BackColor = System.Drawing.Color.CornflowerBlue;
            this.export_bnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export_bnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.export_bnt.ForeColor = System.Drawing.Color.Black;
            this.export_bnt.Image = ((System.Drawing.Image)(resources.GetObject("export_bnt.Image")));
            this.export_bnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.export_bnt.Location = new System.Drawing.Point(14, 216);
            this.export_bnt.Margin = new System.Windows.Forms.Padding(0);
            this.export_bnt.Name = "export_bnt";
            this.export_bnt.Size = new System.Drawing.Size(216, 45);
            this.export_bnt.TabIndex = 418;
            this.export_bnt.Text = "Export Excel";
            this.export_bnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.export_bnt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.export_bnt.UseCompatibleTextRendering = true;
            this.export_bnt.UseVisualStyleBackColor = false;
            this.export_bnt.Click += new System.EventHandler(this.export_bnt_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.MistyRose;
            this.textBox1.Location = new System.Drawing.Point(14, 672);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 20;
            this.textBox1.Visible = false;
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.update_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_btn.ForeColor = System.Drawing.Color.Black;
            this.update_btn.Image = ((System.Drawing.Image)(resources.GetObject("update_btn.Image")));
            this.update_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update_btn.Location = new System.Drawing.Point(14, 81);
            this.update_btn.Margin = new System.Windows.Forms.Padding(0);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(216, 45);
            this.update_btn.TabIndex = 417;
            this.update_btn.Text = " Update JV";
            this.update_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.update_btn.UseCompatibleTextRendering = true;
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // close_bnt
            // 
            this.close_bnt.BackColor = System.Drawing.Color.IndianRed;
            this.close_bnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_bnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_bnt.ForeColor = System.Drawing.Color.Black;
            this.close_bnt.Image = ((System.Drawing.Image)(resources.GetObject("close_bnt.Image")));
            this.close_bnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_bnt.Location = new System.Drawing.Point(14, 261);
            this.close_bnt.Margin = new System.Windows.Forms.Padding(0);
            this.close_bnt.Name = "close_bnt";
            this.close_bnt.Size = new System.Drawing.Size(216, 45);
            this.close_bnt.TabIndex = 416;
            this.close_bnt.Text = " Close";
            this.close_bnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_bnt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_bnt.UseCompatibleTextRendering = true;
            this.close_bnt.UseVisualStyleBackColor = false;
            this.close_bnt.Click += new System.EventHandler(this.close_bnt_Click);
            // 
            // deleteAccntCode_btn
            // 
            this.deleteAccntCode_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.deleteAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAccntCode_btn.ForeColor = System.Drawing.Color.Black;
            this.deleteAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("deleteAccntCode_btn.Image")));
            this.deleteAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteAccntCode_btn.Location = new System.Drawing.Point(14, 171);
            this.deleteAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.deleteAccntCode_btn.Name = "deleteAccntCode_btn";
            this.deleteAccntCode_btn.Size = new System.Drawing.Size(216, 45);
            this.deleteAccntCode_btn.TabIndex = 406;
            this.deleteAccntCode_btn.Text = " Cancel JV";
            this.deleteAccntCode_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteAccntCode_btn.UseCompatibleTextRendering = true;
            this.deleteAccntCode_btn.UseVisualStyleBackColor = false;
            this.deleteAccntCode_btn.Click += new System.EventHandler(this.deleteAccntCode_btn_Click);
            // 
            // preview_btn
            // 
            this.preview_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.preview_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preview_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preview_btn.ForeColor = System.Drawing.Color.Black;
            this.preview_btn.Image = ((System.Drawing.Image)(resources.GetObject("preview_btn.Image")));
            this.preview_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.preview_btn.Location = new System.Drawing.Point(14, 126);
            this.preview_btn.Margin = new System.Windows.Forms.Padding(0);
            this.preview_btn.Name = "preview_btn";
            this.preview_btn.Size = new System.Drawing.Size(216, 45);
            this.preview_btn.TabIndex = 405;
            this.preview_btn.Text = " Preview JV";
            this.preview_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.preview_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.preview_btn.UseCompatibleTextRendering = true;
            this.preview_btn.UseVisualStyleBackColor = false;
            this.preview_btn.Click += new System.EventHandler(this.preview_btn_Click);
            // 
            // addAccntCode_btn
            // 
            this.addAccntCode_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.addAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAccntCode_btn.ForeColor = System.Drawing.Color.Black;
            this.addAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("addAccntCode_btn.Image")));
            this.addAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAccntCode_btn.Location = new System.Drawing.Point(14, 36);
            this.addAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.addAccntCode_btn.Name = "addAccntCode_btn";
            this.addAccntCode_btn.Size = new System.Drawing.Size(216, 45);
            this.addAccntCode_btn.TabIndex = 404;
            this.addAccntCode_btn.Text = " Add Journal Voucher";
            this.addAccntCode_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAccntCode_btn.UseVisualStyleBackColor = false;
            this.addAccntCode_btn.Click += new System.EventHandler(this.addAccntCode_btn_Click);
            // 
            // journalFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1489, 744);
            this.Controls.Add(this.panel3);
            this.Name = "journalFrm";
            this.Text = "Journal Voucher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.journalFrm_FormClosing);
            this.Load += new System.EventHandler(this.journalFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox docno_tf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker to_date;
        private System.Windows.Forms.DateTimePicker fr_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button close_bnt;
        private System.Windows.Forms.Button deleteAccntCode_btn;
        private System.Windows.Forms.Button preview_btn;
        private System.Windows.Forms.Button addAccntCode_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        //private DataSource.journalvTableAdapters.journalv_dtTableAdapter journalv_dtTableAdapter;
        private System.Windows.Forms.Label cntr_lb;
        private System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.Button select_btn;
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
        private System.Windows.Forms.Button export_bnt;
    }
}