namespace zaneco_Accounting_System
{
    partial class mctFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mctFrm));
            this.mct_dgv = new System.Windows.Forms.DataGridView();
            this.mctnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mctdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postedf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForwardedArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.update_btn = new System.Windows.Forms.Button();
            this.close_bnt = new System.Windows.Forms.Button();
            this.deleteAccntCode_btn = new System.Windows.Forms.Button();
            this.preview_btn = new System.Windows.Forms.Button();
            this.addAccntCode_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.select_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.fr_date = new System.Windows.Forms.DateTimePicker();
            this.search_tf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cancelPanel = new System.Windows.Forms.Panel();
            this.okcancel_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.remarkCancel_tf = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.mctlbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mct_dgv)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cancelPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mct_dgv
            // 
            this.mct_dgv.BackgroundColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mct_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.mct_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mct_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mctnumber,
            this.mctdate,
            this.date,
            this.refno,
            this.description,
            this.Amount,
            this.Posted,
            this.postedf,
            this.userid,
            this.ForwardedArea});
            this.mct_dgv.EnableHeadersVisualStyles = false;
            this.mct_dgv.Location = new System.Drawing.Point(2282, 180);
            this.mct_dgv.Name = "mct_dgv";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mct_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.mct_dgv.RowHeadersWidth = 25;
            this.mct_dgv.RowTemplate.Height = 24;
            this.mct_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mct_dgv.Size = new System.Drawing.Size(1091, 613);
            this.mct_dgv.TabIndex = 6;
            this.mct_dgv.Visible = false;
            this.mct_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mct_dgv_CellContentClick);
            // 
            // mctnumber
            // 
            this.mctnumber.DataPropertyName = "mctno";
            this.mctnumber.HeaderText = "MCT No.";
            this.mctnumber.Name = "mctnumber";
            this.mctnumber.Width = 130;
            // 
            // mctdate
            // 
            this.mctdate.DataPropertyName = "mctdate";
            this.mctdate.HeaderText = "MCT Date";
            this.mctdate.Name = "mctdate";
            this.mctdate.Width = 120;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.Visible = false;
            this.date.Width = 110;
            // 
            // refno
            // 
            this.refno.DataPropertyName = "refno";
            this.refno.HeaderText = "Ref. No.";
            this.refno.Name = "refno";
            this.refno.Visible = false;
            this.refno.Width = 90;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.Width = 350;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "amount";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 130;
            // 
            // Posted
            // 
            this.Posted.DataPropertyName = "posted";
            this.Posted.HeaderText = "Posted";
            this.Posted.Name = "Posted";
            this.Posted.Visible = false;
            // 
            // postedf
            // 
            this.postedf.DataPropertyName = "postedf";
            this.postedf.HeaderText = "posted";
            this.postedf.Name = "postedf";
            this.postedf.Width = 60;
            // 
            // userid
            // 
            this.userid.DataPropertyName = "userid";
            this.userid.HeaderText = "userid";
            this.userid.Name = "userid";
            this.userid.Visible = false;
            // 
            // ForwardedArea
            // 
            this.ForwardedArea.DataPropertyName = "forwardarea";
            this.ForwardedArea.HeaderText = "Forwarded Area";
            this.ForwardedArea.Name = "ForwardedArea";
            this.ForwardedArea.Width = 90;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.update_btn);
            this.panel4.Controls.Add(this.close_bnt);
            this.panel4.Controls.Add(this.deleteAccntCode_btn);
            this.panel4.Controls.Add(this.preview_btn);
            this.panel4.Controls.Add(this.addAccntCode_btn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(252, 727);
            this.panel4.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(18, 226);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 50);
            this.button1.TabIndex = 418;
            this.button1.Text = "MCT Override Code";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.update_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_btn.ForeColor = System.Drawing.Color.Black;
            this.update_btn.Image = ((System.Drawing.Image)(resources.GetObject("update_btn.Image")));
            this.update_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update_btn.Location = new System.Drawing.Point(18, 76);
            this.update_btn.Margin = new System.Windows.Forms.Padding(0);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(216, 50);
            this.update_btn.TabIndex = 417;
            this.update_btn.Text = "Update MCT/MTT";
            this.update_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // close_bnt
            // 
            this.close_bnt.BackColor = System.Drawing.Color.IndianRed;
            this.close_bnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_bnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_bnt.ForeColor = System.Drawing.Color.Black;
            this.close_bnt.Image = ((System.Drawing.Image)(resources.GetObject("close_bnt.Image")));
            this.close_bnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_bnt.Location = new System.Drawing.Point(18, 276);
            this.close_bnt.Margin = new System.Windows.Forms.Padding(0);
            this.close_bnt.Name = "close_bnt";
            this.close_bnt.Size = new System.Drawing.Size(216, 50);
            this.close_bnt.TabIndex = 416;
            this.close_bnt.Text = "Close";
            this.close_bnt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_bnt.UseVisualStyleBackColor = false;
            this.close_bnt.Click += new System.EventHandler(this.close_bnt_Click);
            // 
            // deleteAccntCode_btn
            // 
            this.deleteAccntCode_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.deleteAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAccntCode_btn.ForeColor = System.Drawing.Color.Black;
            this.deleteAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("deleteAccntCode_btn.Image")));
            this.deleteAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteAccntCode_btn.Location = new System.Drawing.Point(18, 176);
            this.deleteAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.deleteAccntCode_btn.Name = "deleteAccntCode_btn";
            this.deleteAccntCode_btn.Size = new System.Drawing.Size(216, 50);
            this.deleteAccntCode_btn.TabIndex = 406;
            this.deleteAccntCode_btn.Text = "Cancel MCT/MTT";
            this.deleteAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteAccntCode_btn.UseVisualStyleBackColor = false;
            this.deleteAccntCode_btn.Click += new System.EventHandler(this.deleteAccntCode_btn_Click);
            // 
            // preview_btn
            // 
            this.preview_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.preview_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preview_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preview_btn.ForeColor = System.Drawing.Color.Black;
            this.preview_btn.Image = ((System.Drawing.Image)(resources.GetObject("preview_btn.Image")));
            this.preview_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.preview_btn.Location = new System.Drawing.Point(18, 126);
            this.preview_btn.Margin = new System.Windows.Forms.Padding(0);
            this.preview_btn.Name = "preview_btn";
            this.preview_btn.Size = new System.Drawing.Size(216, 50);
            this.preview_btn.TabIndex = 405;
            this.preview_btn.Text = "Preview MCT/MTT";
            this.preview_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.preview_btn.UseVisualStyleBackColor = false;
            this.preview_btn.Click += new System.EventHandler(this.preview_btn_Click);
            // 
            // addAccntCode_btn
            // 
            this.addAccntCode_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.addAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAccntCode_btn.ForeColor = System.Drawing.Color.Black;
            this.addAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("addAccntCode_btn.Image")));
            this.addAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAccntCode_btn.Location = new System.Drawing.Point(18, 26);
            this.addAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.addAccntCode_btn.Name = "addAccntCode_btn";
            this.addAccntCode_btn.Size = new System.Drawing.Size(216, 50);
            this.addAccntCode_btn.TabIndex = 404;
            this.addAccntCode_btn.Text = "Add MCT/MTT";
            this.addAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAccntCode_btn.UseVisualStyleBackColor = false;
            this.addAccntCode_btn.Click += new System.EventHandler(this.addAccntCode_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.select_btn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.to_date);
            this.panel1.Controls.Add(this.fr_date);
            this.panel1.Controls.Add(this.search_tf);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(256, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 52);
            this.panel1.TabIndex = 17;
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_btn.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.select_btn.Location = new System.Drawing.Point(327, 7);
            this.select_btn.Margin = new System.Windows.Forms.Padding(0);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(54, 33);
            this.select_btn.TabIndex = 411;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(384, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 27);
            this.label2.TabIndex = 401;
            this.label2.Text = "Covered Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // to_date
            // 
            this.to_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_date.Location = new System.Drawing.Point(714, 13);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(154, 27);
            this.to_date.TabIndex = 400;
            // 
            // fr_date
            // 
            this.fr_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fr_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fr_date.Location = new System.Drawing.Point(556, 13);
            this.fr_date.Name = "fr_date";
            this.fr_date.Size = new System.Drawing.Size(152, 27);
            this.fr_date.TabIndex = 399;
            // 
            // search_tf
            // 
            this.search_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tf.Location = new System.Drawing.Point(100, 10);
            this.search_tf.Name = "search_tf";
            this.search_tf.Size = new System.Drawing.Size(227, 27);
            this.search_tf.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "MCT No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mct_dgv);
            this.panel3.Controls.Add(this.cancelPanel);
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(1351, 735);
            this.panel3.TabIndex = 21;
            // 
            // cancelPanel
            // 
            this.cancelPanel.Controls.Add(this.okcancel_btn);
            this.cancelPanel.Controls.Add(this.close_btn);
            this.cancelPanel.Controls.Add(this.label6);
            this.cancelPanel.Controls.Add(this.remarkCancel_tf);
            this.cancelPanel.Controls.Add(this.panel6);
            this.cancelPanel.Location = new System.Drawing.Point(356, 146);
            this.cancelPanel.Name = "cancelPanel";
            this.cancelPanel.Size = new System.Drawing.Size(490, 210);
            this.cancelPanel.TabIndex = 20;
            this.cancelPanel.Visible = false;
            // 
            // okcancel_btn
            // 
            this.okcancel_btn.BackColor = System.Drawing.Color.SeaGreen;
            this.okcancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okcancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okcancel_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.okcancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okcancel_btn.Location = new System.Drawing.Point(262, 158);
            this.okcancel_btn.Margin = new System.Windows.Forms.Padding(0);
            this.okcancel_btn.Name = "okcancel_btn";
            this.okcancel_btn.Size = new System.Drawing.Size(106, 36);
            this.okcancel_btn.TabIndex = 418;
            this.okcancel_btn.Text = "OK";
            this.okcancel_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okcancel_btn.UseVisualStyleBackColor = false;
            this.okcancel_btn.Click += new System.EventHandler(this.okcancel_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.IndianRed;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.close_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_btn.Location = new System.Drawing.Point(368, 158);
            this.close_btn.Margin = new System.Windows.Forms.Padding(0);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(106, 36);
            this.close_btn.TabIndex = 417;
            this.close_btn.Text = "Cancel";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Remarks";
            // 
            // remarkCancel_tf
            // 
            this.remarkCancel_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remarkCancel_tf.Location = new System.Drawing.Point(26, 75);
            this.remarkCancel_tf.Multiline = true;
            this.remarkCancel_tf.Name = "remarkCancel_tf";
            this.remarkCancel_tf.Size = new System.Drawing.Size(448, 68);
            this.remarkCancel_tf.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel6.Controls.Add(this.mctlbl);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(490, 38);
            this.panel6.TabIndex = 0;
            // 
            // mctlbl
            // 
            this.mctlbl.AutoSize = true;
            this.mctlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mctlbl.ForeColor = System.Drawing.Color.Yellow;
            this.mctlbl.Location = new System.Drawing.Point(236, 10);
            this.mctlbl.Name = "mctlbl";
            this.mctlbl.Size = new System.Drawing.Size(111, 18);
            this.mctlbl.TabIndex = 1;
            this.mctlbl.Text = "(CV2021-000)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cencel MCT/MTT Entry";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_EmbeddedNavigator_KeyDown);
            this.gridControl1.Location = new System.Drawing.Point(256, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1091, 675);
            this.gridControl1.TabIndex = 448;
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
            this.gridColumn9,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn11});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "MCT No.";
            this.gridColumn2.FieldName = "mctno";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 125;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Date";
            this.gridColumn1.FieldName = "mctdate";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "dateEntry";
            this.gridColumn7.FieldName = "date";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 94;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ref. No.";
            this.gridColumn9.FieldName = "refno";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 137;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Description";
            this.gridColumn3.FieldName = "description";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 218;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Amount";
            this.gridColumn5.DisplayFormat.FormatString = "c2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "amount";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "SUM={0:c2}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 132;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "posted_";
            this.gridColumn10.FieldName = "posted";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 94;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Posted";
            this.gridColumn6.FieldName = "postedf";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 93;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "userid";
            this.gridColumn4.FieldName = "userID";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 94;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Forwarded Area";
            this.gridColumn8.FieldName = "forwardarea";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 129;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Requester";
            this.gridColumn11.FieldName = "requester";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 143;
            // 
            // mctFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 735);
            this.Controls.Add(this.panel3);
            this.Name = "mctFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Charge Ticket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mctFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mct_dgv)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.cancelPanel.ResumeLayout(false);
            this.cancelPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button close_bnt;
        private System.Windows.Forms.Button deleteAccntCode_btn;
        private System.Windows.Forms.Button preview_btn;
        private System.Windows.Forms.Button addAccntCode_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.DataGridView mct_dgv;
        public System.Windows.Forms.DateTimePicker to_date;
        public System.Windows.Forms.DateTimePicker fr_date;
        public System.Windows.Forms.TextBox search_tf;
        internal System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.Panel cancelPanel;
        private System.Windows.Forms.Button okcancel_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox remarkCancel_tf;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label mctlbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn mctnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn mctdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn refno;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posted;
        private System.Windows.Forms.DataGridViewTextBoxColumn postedf;
        private System.Windows.Forms.DataGridViewTextBoxColumn userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForwardedArea;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}