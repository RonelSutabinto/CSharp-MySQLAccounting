namespace zaneco_Accounting_System
{
    partial class memoBankreconFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(memoBankreconFrm));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.datepicker_dgv = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateto_dp = new System.Windows.Forms.DateTimePicker();
            this.accountname_tf = new System.Windows.Forms.TextBox();
            this.accountcode_tf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateasof_dp = new System.Windows.Forms.DateTimePicker();
            this.balance_tf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_debit = new System.Windows.Forms.Label();
            this.lbl_credit = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_endingBal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.print_btn = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.AccountCode,
            this.btn,
            this.accountname,
            this.Description,
            this.Debit,
            this.Credit,
            this.idmemo});
            this.dgv.Location = new System.Drawing.Point(12, 212);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1088, 286);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            this.dgv.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgv_ColumnWidthChanged);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            this.dgv.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgv_Scroll);
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Date.Width = 170;
            // 
            // AccountCode
            // 
            this.AccountCode.HeaderText = "AccountCode";
            this.AccountCode.Name = "AccountCode";
            this.AccountCode.Visible = false;
            this.AccountCode.Width = 120;
            // 
            // btn
            // 
            this.btn.HeaderText = "";
            this.btn.Name = "btn";
            this.btn.Visible = false;
            this.btn.Width = 25;
            // 
            // accountname
            // 
            this.accountname.HeaderText = "Accountname";
            this.accountname.Name = "accountname";
            this.accountname.Visible = false;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 320;
            // 
            // Debit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SeaGreen;
            this.Debit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.Width = 120;
            // 
            // Credit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Crimson;
            this.Credit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.Width = 120;
            // 
            // idmemo
            // 
            this.idmemo.HeaderText = "idmemo";
            this.idmemo.Name = "idmemo";
            this.idmemo.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.datepicker_dgv);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dateto_dp);
            this.panel3.Controls.Add(this.accountname_tf);
            this.panel3.Controls.Add(this.accountcode_tf);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dateasof_dp);
            this.panel3.Controls.Add(this.balance_tf);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(12, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1088, 115);
            this.panel3.TabIndex = 32;
            // 
            // datepicker_dgv
            // 
            this.datepicker_dgv.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datepicker_dgv.Location = new System.Drawing.Point(708, 81);
            this.datepicker_dgv.Name = "datepicker_dgv";
            this.datepicker_dgv.Size = new System.Drawing.Size(195, 22);
            this.datepicker_dgv.TabIndex = 413;
            this.datepicker_dgv.Visible = false;
            this.datepicker_dgv.CloseUp += new System.EventHandler(this.datepicker_dgv_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(643, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 412;
            this.label1.Text = "Date To";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Visible = false;
            // 
            // dateto_dp
            // 
            this.dateto_dp.Enabled = false;
            this.dateto_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateto_dp.Location = new System.Drawing.Point(708, 53);
            this.dateto_dp.Name = "dateto_dp";
            this.dateto_dp.Size = new System.Drawing.Size(195, 22);
            this.dateto_dp.TabIndex = 411;
            this.dateto_dp.Visible = false;
            // 
            // accountname_tf
            // 
            this.accountname_tf.Location = new System.Drawing.Point(126, 47);
            this.accountname_tf.Name = "accountname_tf";
            this.accountname_tf.ReadOnly = true;
            this.accountname_tf.Size = new System.Drawing.Size(349, 22);
            this.accountname_tf.TabIndex = 2;
            // 
            // accountcode_tf
            // 
            this.accountcode_tf.Location = new System.Drawing.Point(126, 19);
            this.accountcode_tf.Name = "accountcode_tf";
            this.accountcode_tf.ReadOnly = true;
            this.accountcode_tf.Size = new System.Drawing.Size(349, 22);
            this.accountcode_tf.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 410;
            this.label6.Text = "Memo Balance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(628, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 409;
            this.label7.Text = "Date From";
            this.label7.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 408;
            this.label5.Text = "Account Name";
            // 
            // dateasof_dp
            // 
            this.dateasof_dp.Enabled = false;
            this.dateasof_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateasof_dp.Location = new System.Drawing.Point(708, 22);
            this.dateasof_dp.Name = "dateasof_dp";
            this.dateasof_dp.Size = new System.Drawing.Size(195, 22);
            this.dateasof_dp.TabIndex = 407;
            this.dateasof_dp.Visible = false;
            // 
            // balance_tf
            // 
            this.balance_tf.Location = new System.Drawing.Point(126, 75);
            this.balance_tf.Name = "balance_tf";
            this.balance_tf.ReadOnly = true;
            this.balance_tf.Size = new System.Drawing.Size(195, 22);
            this.balance_tf.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Account Code";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 24);
            this.panel1.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1113, 34);
            this.panel2.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(18, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Undefined Transaction";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(601, 514);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 425;
            this.label2.Text = "Total";
            // 
            // lbl_debit
            // 
            this.lbl_debit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debit.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_debit.Location = new System.Drawing.Point(733, 513);
            this.lbl_debit.Name = "lbl_debit";
            this.lbl_debit.Size = new System.Drawing.Size(151, 22);
            this.lbl_debit.TabIndex = 424;
            this.lbl_debit.Text = "0.00";
            this.lbl_debit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_credit
            // 
            this.lbl_credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_credit.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_credit.Location = new System.Drawing.Point(890, 513);
            this.lbl_credit.Name = "lbl_credit";
            this.lbl_credit.Size = new System.Drawing.Size(151, 22);
            this.lbl_credit.TabIndex = 423;
            this.lbl_credit.Text = "0.00";
            this.lbl_credit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.Controls.Add(this.lbl_endingBal);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Location = new System.Drawing.Point(12, 542);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1075, 32);
            this.panel5.TabIndex = 422;
            // 
            // lbl_endingBal
            // 
            this.lbl_endingBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_endingBal.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_endingBal.Location = new System.Drawing.Point(828, 5);
            this.lbl_endingBal.Name = "lbl_endingBal";
            this.lbl_endingBal.Size = new System.Drawing.Size(201, 22);
            this.lbl_endingBal.TabIndex = 414;
            this.lbl_endingBal.Text = "0.00";
            this.lbl_endingBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(589, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 25);
            this.label10.TabIndex = 413;
            this.label10.Text = "Memo Balance";
            // 
            // print_btn
            // 
            this.print_btn.Image = ((System.Drawing.Image)(resources.GetObject("print_btn.Image")));
            this.print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.print_btn.Location = new System.Drawing.Point(21, 592);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(133, 38);
            this.print_btn.TabIndex = 427;
            this.print_btn.Text = "Print Memo";
            this.print_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(815, 591);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 50);
            this.btnSave.TabIndex = 426;
            this.btnSave.Text = "Save Memo";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Image = ((System.Drawing.Image)(resources.GetObject("cancel_btn.Image")));
            this.cancel_btn.Location = new System.Drawing.Point(954, 591);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(133, 50);
            this.cancel_btn.TabIndex = 428;
            this.cancel_btn.Text = "Close";
            this.cancel_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_btn.Image = ((System.Drawing.Image)(resources.GetObject("delete_btn.Image")));
            this.delete_btn.Location = new System.Drawing.Point(676, 592);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(133, 50);
            this.delete_btn.TabIndex = 430;
            this.delete_btn.Text = "Delete";
            this.delete_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // memoBankreconFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 654);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_debit);
            this.Controls.Add(this.lbl_credit);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "memoBankreconFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memo Bank Reconcilation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.memoBankreconFrm_FormClosed);
            this.Load += new System.EventHandler(this.memoBankreconFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dateto_dp;
        public System.Windows.Forms.TextBox accountname_tf;
        public System.Windows.Forms.TextBox accountcode_tf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dateasof_dp;
        public System.Windows.Forms.TextBox balance_tf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_debit;
        private System.Windows.Forms.Label lbl_credit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_endingBal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.DateTimePicker datepicker_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmemo;
        private System.Windows.Forms.Button delete_btn;
    }
}