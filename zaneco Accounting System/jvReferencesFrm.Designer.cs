namespace zaneco_Accounting_System
{
    partial class jvReferencesFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(jvReferencesFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.table_dg = new System.Windows.Forms.DataGridView();
            this.cvdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rvdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.To_dp = new System.Windows.Forms.DateTimePicker();
            this.From_dp = new System.Windows.Forms.DateTimePicker();
            this.search_tf = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.transdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcrtblsumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.billCollDS = new zaneco_Accounting_System.DataSource.billCollDS();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toDP = new System.Windows.Forms.DateTimePicker();
            this.fromDP = new System.Windows.Forms.DateTimePicker();
            this.cdcr_tblsumTableAdapter = new zaneco_Accounting_System.DataSource.billCollDSTableAdapters.cdcr_tblsumTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_dg)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdcrtblsumBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billCollDS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(938, 515);
            this.tabControl1.TabIndex = 339;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.table_dg);
            this.tabPage1.Controls.Add(this.select_btn);
            this.tabPage1.Controls.Add(this.close_btn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.To_dp);
            this.tabPage1.Controls.Add(this.From_dp);
            this.tabPage1.Controls.Add(this.search_tf);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(930, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CV/RV";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // table_dg
            // 
            this.table_dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cvdate,
            this.cvno,
            this.jobname,
            this.description,
            this.amount,
            this.rvdate});
            this.table_dg.Location = new System.Drawing.Point(15, 80);
            this.table_dg.Name = "table_dg";
            this.table_dg.ReadOnly = true;
            this.table_dg.RowHeadersWidth = 30;
            this.table_dg.RowTemplate.Height = 24;
            this.table_dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_dg.Size = new System.Drawing.Size(898, 325);
            this.table_dg.TabIndex = 342;
            this.table_dg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.table_dg_KeyDown_1);
            // 
            // cvdate
            // 
            this.cvdate.DataPropertyName = "cvdate";
            this.cvdate.HeaderText = "Date";
            this.cvdate.Name = "cvdate";
            this.cvdate.ReadOnly = true;
            this.cvdate.Width = 80;
            // 
            // cvno
            // 
            this.cvno.DataPropertyName = "cvnumber";
            this.cvno.HeaderText = "CV No.";
            this.cvno.Name = "cvno";
            this.cvno.ReadOnly = true;
            this.cvno.Width = 80;
            // 
            // jobname
            // 
            this.jobname.DataPropertyName = "rvnumber";
            this.jobname.HeaderText = "RV No.";
            this.jobname.Name = "jobname";
            this.jobname.ReadOnly = true;
            this.jobname.Width = 80;
            // 
            // description
            // 
            this.description.DataPropertyName = "paymentdesc";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 230;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "cvamount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.amount.DefaultCellStyle = dataGridViewCellStyle1;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // rvdate
            // 
            this.rvdate.DataPropertyName = "rvdate";
            this.rvdate.HeaderText = "RVDate";
            this.rvdate.Name = "rvdate";
            this.rvdate.ReadOnly = true;
            this.rvdate.Visible = false;
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select_btn.Location = new System.Drawing.Point(627, 41);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(34, 32);
            this.select_btn.TabIndex = 340;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click_1);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.LightCoral;
            this.close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.close_btn.FlatAppearance.BorderSize = 0;
            this.close_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.close_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close_btn.ForeColor = System.Drawing.Color.Black;
            this.close_btn.Location = new System.Drawing.Point(799, 431);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(114, 32);
            this.close_btn.TabIndex = 339;
            this.close_btn.Text = "X  Cancel";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 18);
            this.label1.TabIndex = 347;
            this.label1.Text = "Search CV No./RV No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 346;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 345;
            this.label5.Text = "From";
            // 
            // To_dp
            // 
            this.To_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.To_dp.Location = new System.Drawing.Point(436, 14);
            this.To_dp.Name = "To_dp";
            this.To_dp.Size = new System.Drawing.Size(130, 23);
            this.To_dp.TabIndex = 344;
            // 
            // From_dp
            // 
            this.From_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.From_dp.Location = new System.Drawing.Point(269, 14);
            this.From_dp.Name = "From_dp";
            this.From_dp.Size = new System.Drawing.Size(130, 23);
            this.From_dp.TabIndex = 343;
            // 
            // search_tf
            // 
            this.search_tf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.search_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tf.ForeColor = System.Drawing.Color.DarkGray;
            this.search_tf.Location = new System.Drawing.Point(15, 43);
            this.search_tf.Margin = new System.Windows.Forms.Padding(4);
            this.search_tf.Name = "search_tf";
            this.search_tf.Size = new System.Drawing.Size(605, 26);
            this.search_tf.TabIndex = 341;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cancelBtn);
            this.tabPage2.Controls.Add(this.importBtn);
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.toDP);
            this.tabPage2.Controls.Add(this.fromDP);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(930, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Billing Collection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.LightCoral;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.Black;
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.Location = new System.Drawing.Point(799, 431);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(114, 36);
            this.cancelBtn.TabIndex = 424;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.ForeColor = System.Drawing.Color.Black;
            this.importBtn.Image = ((System.Drawing.Image)(resources.GetObject("importBtn.Image")));
            this.importBtn.Location = new System.Drawing.Point(662, 431);
            this.importBtn.Margin = new System.Windows.Forms.Padding(0);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(114, 36);
            this.importBtn.TabIndex = 423;
            this.importBtn.Text = "Import";
            this.importBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.importBtn.UseVisualStyleBackColor = false;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(428, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(94, 20);
            this.linkLabel1.TabIndex = 422;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "View Detail";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transdateDataGridViewTextBoxColumn,
            this.areaDataGridViewTextBoxColumn,
            this.debitDataGridViewTextBoxColumn,
            this.creditDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cdcrtblsumBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(15, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(898, 361);
            this.dataGridView1.TabIndex = 421;
            // 
            // transdateDataGridViewTextBoxColumn
            // 
            this.transdateDataGridViewTextBoxColumn.DataPropertyName = "transdate";
            this.transdateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.transdateDataGridViewTextBoxColumn.Name = "transdateDataGridViewTextBoxColumn";
            this.transdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.DataPropertyName = "area";
            this.areaDataGridViewTextBoxColumn.HeaderText = "Area";
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            this.areaDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaDataGridViewTextBoxColumn.Width = 80;
            // 
            // debitDataGridViewTextBoxColumn
            // 
            this.debitDataGridViewTextBoxColumn.DataPropertyName = "debit";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.debitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.debitDataGridViewTextBoxColumn.HeaderText = "Debit";
            this.debitDataGridViewTextBoxColumn.Name = "debitDataGridViewTextBoxColumn";
            this.debitDataGridViewTextBoxColumn.ReadOnly = true;
            this.debitDataGridViewTextBoxColumn.Width = 150;
            // 
            // creditDataGridViewTextBoxColumn
            // 
            this.creditDataGridViewTextBoxColumn.DataPropertyName = "credit";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.creditDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.creditDataGridViewTextBoxColumn.HeaderText = "Credit";
            this.creditDataGridViewTextBoxColumn.Name = "creditDataGridViewTextBoxColumn";
            this.creditDataGridViewTextBoxColumn.ReadOnly = true;
            this.creditDataGridViewTextBoxColumn.Width = 150;
            // 
            // cdcrtblsumBindingSource
            // 
            this.cdcrtblsumBindingSource.DataMember = "cdcr_tblsum";
            this.cdcrtblsumBindingSource.DataSource = this.billCollDS;
            this.cdcrtblsumBindingSource.CurrentChanged += new System.EventHandler(this.cdcrtblsumBindingSource_CurrentChanged);
            // 
            // billCollDS
            // 
            this.billCollDS.DataSetName = "billCollDS";
            this.billCollDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(370, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 32);
            this.button1.TabIndex = 419;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 351;
            this.label3.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 350;
            this.label6.Text = "From";
            // 
            // toDP
            // 
            this.toDP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDP.Location = new System.Drawing.Point(234, 15);
            this.toDP.Name = "toDP";
            this.toDP.Size = new System.Drawing.Size(130, 23);
            this.toDP.TabIndex = 349;
            // 
            // fromDP
            // 
            this.fromDP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDP.Location = new System.Drawing.Point(67, 15);
            this.fromDP.Name = "fromDP";
            this.fromDP.Size = new System.Drawing.Size(130, 23);
            this.fromDP.TabIndex = 348;
            // 
            // cdcr_tblsumTableAdapter
            // 
            this.cdcr_tblsumTableAdapter.ClearBeforeFill = true;
            // 
            // jvReferencesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(938, 515);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "jvReferencesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "jvReferencesFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.jvReferencesFrm_FormClosed);
            this.Load += new System.EventHandler(this.jvReferencesFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_dg)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdcrtblsumBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billCollDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.DataGridView table_dg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvno;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobname;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvdate;
        internal System.Windows.Forms.Button select_btn;
        internal System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker To_dp;
        private System.Windows.Forms.DateTimePicker From_dp;
        internal System.Windows.Forms.TextBox search_tf;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker toDP;
        private System.Windows.Forms.DateTimePicker fromDP;
        public System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource cdcrtblsumBindingSource;
        private DataSource.billCollDS billCollDS;
        private DataSource.billCollDSTableAdapters.cdcr_tblsumTableAdapter cdcr_tblsumTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditDataGridViewTextBoxColumn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}