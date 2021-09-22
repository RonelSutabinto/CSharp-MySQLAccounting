namespace zaneco_Accounting_System
{
    partial class apvreferenceFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(apvreferenceFrm));
            this.rvpoDatagridView = new System.Windows.Forms.DataGridView();
            this.approveddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountApprove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rvdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rvdescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rvdate_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.rvpoDatagridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rvpoDatagridView
            // 
            this.rvpoDatagridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rvpoDatagridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rvpoDatagridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.rvpoDatagridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rvpoDatagridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.approveddate,
            this.doctype,
            this.documentnumber,
            this.amountApprove,
            this.rvdate,
            this.pcode_,
            this.pname_,
            this.rvdescription,
            this.rvdate_,
            this.address});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rvpoDatagridView.DefaultCellStyle = dataGridViewCellStyle22;
            this.rvpoDatagridView.EnableHeadersVisualStyles = false;
            this.rvpoDatagridView.Location = new System.Drawing.Point(33, 103);
            this.rvpoDatagridView.Name = "rvpoDatagridView";
            this.rvpoDatagridView.ReadOnly = true;
            this.rvpoDatagridView.RowHeadersWidth = 28;
            this.rvpoDatagridView.RowTemplate.Height = 18;
            this.rvpoDatagridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rvpoDatagridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rvpoDatagridView.Size = new System.Drawing.Size(981, 363);
            this.rvpoDatagridView.TabIndex = 325;
            this.rvpoDatagridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rvpoDatagridView_CellContentClick);
            // 
            // approveddate
            // 
            this.approveddate.DataPropertyName = "date";
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveddate.DefaultCellStyle = dataGridViewCellStyle14;
            this.approveddate.HeaderText = "Date";
            this.approveddate.Name = "approveddate";
            this.approveddate.ReadOnly = true;
            this.approveddate.Width = 80;
            // 
            // doctype
            // 
            this.doctype.DataPropertyName = "doctype";
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctype.DefaultCellStyle = dataGridViewCellStyle15;
            this.doctype.HeaderText = "doctype";
            this.doctype.Name = "doctype";
            this.doctype.ReadOnly = true;
            this.doctype.Visible = false;
            // 
            // documentnumber
            // 
            this.documentnumber.DataPropertyName = "docno";
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentnumber.DefaultCellStyle = dataGridViewCellStyle16;
            this.documentnumber.HeaderText = "Doc.No.";
            this.documentnumber.Name = "documentnumber";
            this.documentnumber.ReadOnly = true;
            // 
            // amountApprove
            // 
            this.amountApprove.DataPropertyName = "amount";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = "0.00";
            this.amountApprove.DefaultCellStyle = dataGridViewCellStyle17;
            this.amountApprove.HeaderText = "Amount";
            this.amountApprove.Name = "amountApprove";
            this.amountApprove.ReadOnly = true;
            this.amountApprove.Width = 80;
            // 
            // rvdate
            // 
            this.rvdate.DataPropertyName = "budgetNo";
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rvdate.DefaultCellStyle = dataGridViewCellStyle18;
            this.rvdate.HeaderText = "budgetNo";
            this.rvdate.Name = "rvdate";
            this.rvdate.ReadOnly = true;
            this.rvdate.Visible = false;
            // 
            // pcode_
            // 
            this.pcode_.DataPropertyName = "pcode";
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcode_.DefaultCellStyle = dataGridViewCellStyle19;
            this.pcode_.HeaderText = "Payee Code";
            this.pcode_.Name = "pcode_";
            this.pcode_.ReadOnly = true;
            this.pcode_.Width = 120;
            // 
            // pname_
            // 
            this.pname_.DataPropertyName = "pname";
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pname_.DefaultCellStyle = dataGridViewCellStyle20;
            this.pname_.HeaderText = "Payee Name";
            this.pname_.Name = "pname_";
            this.pname_.ReadOnly = true;
            this.pname_.Width = 170;
            // 
            // rvdescription
            // 
            this.rvdescription.DataPropertyName = "rvdescription";
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rvdescription.DefaultCellStyle = dataGridViewCellStyle21;
            this.rvdescription.HeaderText = "Description";
            this.rvdescription.Name = "rvdescription";
            this.rvdescription.ReadOnly = true;
            this.rvdescription.Width = 300;
            // 
            // rvdate_
            // 
            this.rvdate_.DataPropertyName = "rvdate";
            this.rvdate_.HeaderText = "rvdate";
            this.rvdate_.Name = "rvdate_";
            this.rvdate_.ReadOnly = true;
            this.rvdate_.Visible = false;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(628, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 321;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(438, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 320;
            this.label5.Text = "From";
            // 
            // rvproTo
            // 
            this.rvproTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rvproTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rvproTo.Location = new System.Drawing.Point(662, 64);
            this.rvproTo.Name = "rvproTo";
            this.rvproTo.Size = new System.Drawing.Size(130, 27);
            this.rvproTo.TabIndex = 319;
            // 
            // rvproFrom
            // 
            this.rvproFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rvproFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rvproFrom.Location = new System.Drawing.Point(492, 64);
            this.rvproFrom.Name = "rvproFrom";
            this.rvproFrom.Size = new System.Drawing.Size(130, 27);
            this.rvproFrom.TabIndex = 318;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 20);
            this.label6.TabIndex = 317;
            this.label6.Text = "Doc.No/Payee Code";
            // 
            // searchrvpo_tf
            // 
            this.searchrvpo_tf.BackColor = System.Drawing.Color.White;
            this.searchrvpo_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchrvpo_tf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.searchrvpo_tf.Location = new System.Drawing.Point(33, 67);
            this.searchrvpo_tf.Margin = new System.Windows.Forms.Padding(4);
            this.searchrvpo_tf.Name = "searchrvpo_tf";
            this.searchrvpo_tf.Size = new System.Drawing.Size(322, 27);
            this.searchrvpo_tf.TabIndex = 316;
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
            this.button1.Location = new System.Drawing.Point(356, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 32);
            this.button1.TabIndex = 315;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rvpodetails_btn
            // 
            this.rvpodetails_btn.Image = ((System.Drawing.Image)(resources.GetObject("rvpodetails_btn.Image")));
            this.rvpodetails_btn.Location = new System.Drawing.Point(621, 472);
            this.rvpodetails_btn.Name = "rvpodetails_btn";
            this.rvpodetails_btn.Size = new System.Drawing.Size(127, 46);
            this.rvpodetails_btn.TabIndex = 322;
            this.rvpodetails_btn.Text = "Details";
            this.rvpodetails_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rvpodetails_btn.UseVisualStyleBackColor = true;
            this.rvpodetails_btn.Click += new System.EventHandler(this.rvpodetails_btn_Click);
            // 
            // rvpoclose_btn
            // 
            this.rvpoclose_btn.Image = ((System.Drawing.Image)(resources.GetObject("rvpoclose_btn.Image")));
            this.rvpoclose_btn.Location = new System.Drawing.Point(887, 472);
            this.rvpoclose_btn.Name = "rvpoclose_btn";
            this.rvpoclose_btn.Size = new System.Drawing.Size(127, 46);
            this.rvpoclose_btn.TabIndex = 324;
            this.rvpoclose_btn.Text = "Close";
            this.rvpoclose_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rvpoclose_btn.UseVisualStyleBackColor = true;
            this.rvpoclose_btn.Click += new System.EventHandler(this.rvpoclose_btn_Click);
            // 
            // rvposelect_btn
            // 
            this.rvposelect_btn.Image = ((System.Drawing.Image)(resources.GetObject("rvposelect_btn.Image")));
            this.rvposelect_btn.Location = new System.Drawing.Point(754, 472);
            this.rvposelect_btn.Name = "rvposelect_btn";
            this.rvposelect_btn.Size = new System.Drawing.Size(127, 46);
            this.rvposelect_btn.TabIndex = 323;
            this.rvposelect_btn.Text = "Select";
            this.rvposelect_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rvposelect_btn.UseVisualStyleBackColor = true;
            this.rvposelect_btn.Click += new System.EventHandler(this.rvposelect_btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 27);
            this.panel2.TabIndex = 326;
            // 
            // apvreferenceFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 530);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rvpoDatagridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rvproTo);
            this.Controls.Add(this.rvproFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.searchrvpo_tf);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rvpodetails_btn);
            this.Controls.Add(this.rvpoclose_btn);
            this.Controls.Add(this.rvposelect_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "apvreferenceFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Reference Number";
            this.Load += new System.EventHandler(this.apvreferenceFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rvpoDatagridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView rvpoDatagridView;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn approveddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctype;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountApprove;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode_;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname_;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvdescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvdate_;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
    }
}