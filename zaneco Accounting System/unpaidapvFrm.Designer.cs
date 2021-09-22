namespace zaneco_Accounting_System.Reports
{
    partial class unpaidapvFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(unpaidapvFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accountname_tf = new System.Windows.Forms.TextBox();
            this.accountcode_tf = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.select_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.fr_date = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dt_gridview = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.totalapv_lbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._accountname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apvnumber_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docnumber_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDescription_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apvamount_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idapv_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idapvdetails_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewAPVDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gridview)).BeginInit();
            this.panel5.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountname_tf
            // 
            this.accountname_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountname_tf.Location = new System.Drawing.Point(130, 46);
            this.accountname_tf.Name = "accountname_tf";
            this.accountname_tf.ReadOnly = true;
            this.accountname_tf.Size = new System.Drawing.Size(506, 27);
            this.accountname_tf.TabIndex = 2;
            // 
            // accountcode_tf
            // 
            this.accountcode_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountcode_tf.Location = new System.Drawing.Point(130, 13);
            this.accountcode_tf.Name = "accountcode_tf";
            this.accountcode_tf.ReadOnly = true;
            this.accountcode_tf.Size = new System.Drawing.Size(506, 27);
            this.accountcode_tf.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 408;
            this.label5.Text = "Account Name";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Account Code";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.select_btn);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.to_date);
            this.panel3.Controls.Add(this.fr_date);
            this.panel3.Controls.Add(this.accountname_tf);
            this.panel3.Controls.Add(this.accountcode_tf);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(22, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1300, 85);
            this.panel3.TabIndex = 422;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.checkBox1.Location = new System.Drawing.Point(1141, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(127, 45);
            this.checkBox1.TabIndex = 417;
            this.checkBox1.Text = "Select All \r\nUnpaid APV";
            this.checkBox1.UseCompatibleTextRendering = true;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(799, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 18);
            this.label6.TabIndex = 416;
            this.label6.Text = "Date To";
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select_btn.Location = new System.Drawing.Point(1061, 21);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(59, 50);
            this.select_btn.TabIndex = 415;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(782, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 414;
            this.label2.Text = "Date From";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // to_date
            // 
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_date.Location = new System.Drawing.Point(877, 49);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(178, 22);
            this.to_date.TabIndex = 413;
            // 
            // fr_date
            // 
            this.fr_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fr_date.Location = new System.Drawing.Point(877, 21);
            this.fr_date.Name = "fr_date";
            this.fr_date.Size = new System.Drawing.Size(178, 22);
            this.fr_date.TabIndex = 412;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1344, 48);
            this.panel2.TabIndex = 418;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(18, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unpaid APV List";
            // 
            // dt_gridview
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_gridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_gridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cb_,
            this._accountname,
            this.apvnumber_,
            this.docnumber_,
            this.pcode_,
            this.pname_,
            this.pDescription_,
            this.apvamount_,
            this.credit_,
            this.idapv_,
            this.idapvdetails_});
            this.dt_gridview.ContextMenuStrip = this.contextMenuStrip1;
            this.dt_gridview.EnableHeadersVisualStyles = false;
            this.dt_gridview.Location = new System.Drawing.Point(22, 155);
            this.dt_gridview.Margin = new System.Windows.Forms.Padding(0);
            this.dt_gridview.Name = "dt_gridview";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_gridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dt_gridview.RowHeadersWidth = 25;
            this.dt_gridview.RowTemplate.Height = 24;
            this.dt_gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_gridview.Size = new System.Drawing.Size(1300, 343);
            this.dt_gridview.TabIndex = 420;
            this.dt_gridview.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_gridview_CellEndEdit);
            this.dt_gridview.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dt_gridview_CellMouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1344, 10);
            this.panel1.TabIndex = 419;
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
            this.button1.Location = new System.Drawing.Point(968, 568);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 50);
            this.button1.TabIndex = 430;
            this.button1.Text = "Import to CV";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // close_btn
            // 
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(1154, 568);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(168, 50);
            this.close_btn.TabIndex = 428;
            this.close_btn.Text = "Close";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.Controls.Add(this.totalapv_lbl);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Location = new System.Drawing.Point(22, 498);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1300, 48);
            this.panel5.TabIndex = 431;
            // 
            // totalapv_lbl
            // 
            this.totalapv_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalapv_lbl.ForeColor = System.Drawing.Color.RoyalBlue;
            this.totalapv_lbl.Location = new System.Drawing.Point(1057, 11);
            this.totalapv_lbl.Name = "totalapv_lbl";
            this.totalapv_lbl.Size = new System.Drawing.Size(201, 22);
            this.totalapv_lbl.TabIndex = 414;
            this.totalapv_lbl.Text = "0.00";
            this.totalapv_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(859, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 25);
            this.label10.TabIndex = 413;
            this.label10.Text = "Total Unpaid APV";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // cb_
            // 
            this.cb_.HeaderText = "";
            this.cb_.Name = "cb_";
            this.cb_.Width = 35;
            // 
            // _accountname
            // 
            this._accountname.DataPropertyName = "apvdate";
            this._accountname.HeaderText = "Date";
            this._accountname.Name = "_accountname";
            this._accountname.ReadOnly = true;
            this._accountname.Width = 80;
            // 
            // apvnumber_
            // 
            this.apvnumber_.DataPropertyName = "apvnumber";
            this.apvnumber_.HeaderText = "APV Number";
            this.apvnumber_.Name = "apvnumber_";
            this.apvnumber_.ReadOnly = true;
            this.apvnumber_.Width = 90;
            // 
            // docnumber_
            // 
            this.docnumber_.DataPropertyName = "docnumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.docnumber_.DefaultCellStyle = dataGridViewCellStyle2;
            this.docnumber_.HeaderText = "Ref.Number";
            this.docnumber_.Name = "docnumber_";
            this.docnumber_.ReadOnly = true;
            this.docnumber_.Width = 90;
            // 
            // pcode_
            // 
            this.pcode_.DataPropertyName = "pcode";
            this.pcode_.HeaderText = "pcode";
            this.pcode_.Name = "pcode_";
            this.pcode_.ReadOnly = true;
            this.pcode_.Visible = false;
            // 
            // pname_
            // 
            this.pname_.DataPropertyName = "pname";
            this.pname_.HeaderText = "Payee";
            this.pname_.Name = "pname_";
            this.pname_.ReadOnly = true;
            this.pname_.Width = 150;
            // 
            // pDescription_
            // 
            this.pDescription_.DataPropertyName = "pDescription";
            this.pDescription_.HeaderText = "Description";
            this.pDescription_.Name = "pDescription_";
            this.pDescription_.ReadOnly = true;
            this.pDescription_.Width = 270;
            // 
            // apvamount_
            // 
            this.apvamount_.DataPropertyName = "apvamount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.apvamount_.DefaultCellStyle = dataGridViewCellStyle3;
            this.apvamount_.HeaderText = "APV Amount";
            this.apvamount_.Name = "apvamount_";
            this.apvamount_.ReadOnly = true;
            // 
            // credit_
            // 
            this.credit_.DataPropertyName = "credit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.credit_.DefaultCellStyle = dataGridViewCellStyle4;
            this.credit_.HeaderText = "Accnt Amount";
            this.credit_.Name = "credit_";
            this.credit_.ReadOnly = true;
            // 
            // idapv_
            // 
            this.idapv_.DataPropertyName = "idapv";
            this.idapv_.HeaderText = "idapv";
            this.idapv_.Name = "idapv_";
            this.idapv_.Visible = false;
            // 
            // idapvdetails_
            // 
            this.idapvdetails_.DataPropertyName = "idapvdetails";
            this.idapvdetails_.HeaderText = "idapvdetails";
            this.idapvdetails_.Name = "idapvdetails_";
            this.idapvdetails_.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAPVDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 28);
            // 
            // viewAPVDetailsToolStripMenuItem
            // 
            this.viewAPVDetailsToolStripMenuItem.Name = "viewAPVDetailsToolStripMenuItem";
            this.viewAPVDetailsToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.viewAPVDetailsToolStripMenuItem.Text = "View APV Details";
            this.viewAPVDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewAPVDetailsToolStripMenuItem_Click);
            // 
            // unpaidapvFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 630);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dt_gridview);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "unpaidapvFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unpaid APV";
            this.Load += new System.EventHandler(this.unpaidapvFrm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gridview)).EndInit();
            this.panel5.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox accountname_tf;
        public System.Windows.Forms.TextBox accountcode_tf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dt_gridview;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button close_btn;
        internal System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker to_date;
        public System.Windows.Forms.DateTimePicker fr_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label totalapv_lbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cb_;
        private System.Windows.Forms.DataGridViewTextBoxColumn _accountname;
        private System.Windows.Forms.DataGridViewTextBoxColumn apvnumber_;
        private System.Windows.Forms.DataGridViewTextBoxColumn docnumber_;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode_;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname_;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDescription_;
        private System.Windows.Forms.DataGridViewTextBoxColumn apvamount_;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit_;
        private System.Windows.Forms.DataGridViewTextBoxColumn idapv_;
        private System.Windows.Forms.DataGridViewTextBoxColumn idapvdetails_;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewAPVDetailsToolStripMenuItem;
    }
}