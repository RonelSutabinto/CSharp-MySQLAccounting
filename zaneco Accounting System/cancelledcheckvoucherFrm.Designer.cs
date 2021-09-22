namespace zaneco_Accounting_System
{
    partial class cancelledcheckvoucherFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cancelledcheckvoucherFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.viewAPVDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dt_gridview = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.fr_date = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.select_btn = new System.Windows.Forms.Button();
            this.CodeName_tf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cvdate_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datecancelled_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checknumber_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvamount_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_gridview)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.button1.Location = new System.Drawing.Point(968, 690);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 50);
            this.button1.TabIndex = 437;
            this.button1.Text = "Export to Excel";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // close_btn
            // 
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(1154, 690);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(168, 50);
            this.close_btn.TabIndex = 436;
            this.close_btn.Text = "Close";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // viewAPVDetailsToolStripMenuItem
            // 
            this.viewAPVDetailsToolStripMenuItem.Name = "viewAPVDetailsToolStripMenuItem";
            this.viewAPVDetailsToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.viewAPVDetailsToolStripMenuItem.Text = "View APV Details";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAPVDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 28);
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
            this.cvdate_,
            this.datecancelled_,
            this.checknumber_,
            this.pcode_,
            this.pname_,
            this.remarks_,
            this.cvamount_});
            this.dt_gridview.ContextMenuStrip = this.contextMenuStrip1;
            this.dt_gridview.EnableHeadersVisualStyles = false;
            this.dt_gridview.Location = new System.Drawing.Point(22, 133);
            this.dt_gridview.Margin = new System.Windows.Forms.Padding(0);
            this.dt_gridview.Name = "dt_gridview";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_gridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dt_gridview.RowHeadersWidth = 25;
            this.dt_gridview.RowTemplate.Height = 24;
            this.dt_gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_gridview.Size = new System.Drawing.Size(1312, 535);
            this.dt_gridview.TabIndex = 434;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(18, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cancelled Check Voucher";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(452, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 18);
            this.label6.TabIndex = 416;
            this.label6.Text = "Date To";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(434, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 414;
            this.label2.Text = "Date From";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // to_date
            // 
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_date.Location = new System.Drawing.Point(528, 91);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(178, 22);
            this.to_date.TabIndex = 413;
            this.to_date.ValueChanged += new System.EventHandler(this.to_date_ValueChanged);
            // 
            // fr_date
            // 
            this.fr_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fr_date.Location = new System.Drawing.Point(528, 63);
            this.fr_date.Name = "fr_date";
            this.fr_date.Size = new System.Drawing.Size(178, 22);
            this.fr_date.TabIndex = 412;
            this.fr_date.ValueChanged += new System.EventHandler(this.fr_date_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1359, 42);
            this.panel2.TabIndex = 432;
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select_btn.Location = new System.Drawing.Point(309, 80);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(59, 32);
            this.select_btn.TabIndex = 439;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click_1);
            // 
            // CodeName_tf
            // 
            this.CodeName_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeName_tf.Location = new System.Drawing.Point(23, 83);
            this.CodeName_tf.Name = "CodeName_tf";
            this.CodeName_tf.Size = new System.Drawing.Size(286, 27);
            this.CodeName_tf.TabIndex = 438;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 440;
            this.label1.Text = "Check Number";
            // 
            // cvdate_
            // 
            this.cvdate_.DataPropertyName = "cvdate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cvdate_.DefaultCellStyle = dataGridViewCellStyle2;
            this.cvdate_.HeaderText = "CV Date";
            this.cvdate_.Name = "cvdate_";
            this.cvdate_.ReadOnly = true;
            // 
            // datecancelled_
            // 
            this.datecancelled_.DataPropertyName = "datecancelled";
            this.datecancelled_.HeaderText = "Date Cancelled";
            this.datecancelled_.Name = "datecancelled_";
            this.datecancelled_.ReadOnly = true;
            // 
            // checknumber_
            // 
            this.checknumber_.DataPropertyName = "checknumber";
            this.checknumber_.HeaderText = "Check No.";
            this.checknumber_.Name = "checknumber_";
            this.checknumber_.ReadOnly = true;
            this.checknumber_.Width = 160;
            // 
            // pcode_
            // 
            this.pcode_.DataPropertyName = "cvpcode";
            this.pcode_.HeaderText = "pcode";
            this.pcode_.Name = "pcode_";
            this.pcode_.ReadOnly = true;
            this.pcode_.Visible = false;
            // 
            // pname_
            // 
            this.pname_.DataPropertyName = "cvpname";
            this.pname_.HeaderText = "Payee";
            this.pname_.Name = "pname_";
            this.pname_.ReadOnly = true;
            this.pname_.Width = 150;
            // 
            // remarks_
            // 
            this.remarks_.DataPropertyName = "remarks";
            this.remarks_.HeaderText = "Remarks";
            this.remarks_.Name = "remarks_";
            this.remarks_.ReadOnly = true;
            this.remarks_.Width = 310;
            // 
            // cvamount_
            // 
            this.cvamount_.DataPropertyName = "cvamount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.cvamount_.DefaultCellStyle = dataGridViewCellStyle3;
            this.cvamount_.HeaderText = "CV Amount";
            this.cvamount_.Name = "cvamount_";
            this.cvamount_.ReadOnly = true;
            this.cvamount_.Width = 120;
            // 
            // cancelledcheckvoucherFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 753);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.select_btn);
            this.Controls.Add(this.CodeName_tf);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.to_date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt_gridview);
            this.Controls.Add(this.fr_date);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cancelledcheckvoucherFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelled Check Voucher";
            this.Load += new System.EventHandler(this.cancelledcheckvoucherFrm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_gridview)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.ToolStripMenuItem viewAPVDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dt_gridview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker to_date;
        public System.Windows.Forms.DateTimePicker fr_date;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button select_btn;
        public System.Windows.Forms.TextBox CodeName_tf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvdate_;
        private System.Windows.Forms.DataGridViewTextBoxColumn datecancelled_;
        private System.Windows.Forms.DataGridViewTextBoxColumn checknumber_;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode_;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname_;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks_;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvamount_;
    }
}