namespace zaneco_Accounting_System
{
    partial class referencemctFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(referencemctFrm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.To_dp = new System.Windows.Forms.DateTimePicker();
            this.From_dp = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.search_tf = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.tblDatagridView = new System.Windows.Forms.DataGridView();
            this.mctdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mctno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblDatagridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 27);
            this.panel2.TabIndex = 338;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 333;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 332;
            this.label5.Text = "From";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // To_dp
            // 
            this.To_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.To_dp.Location = new System.Drawing.Point(644, 64);
            this.To_dp.Name = "To_dp";
            this.To_dp.Size = new System.Drawing.Size(130, 22);
            this.To_dp.TabIndex = 331;
            // 
            // From_dp
            // 
            this.From_dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.From_dp.Location = new System.Drawing.Point(474, 64);
            this.From_dp.Name = "From_dp";
            this.From_dp.Size = new System.Drawing.Size(130, 22);
            this.From_dp.TabIndex = 330;
            this.From_dp.ValueChanged += new System.EventHandler(this.From_dp_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 329;
            this.label6.Text = "MCT No.";
            // 
            // search_tf
            // 
            this.search_tf.BackColor = System.Drawing.Color.White;
            this.search_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.search_tf.Location = new System.Drawing.Point(15, 67);
            this.search_tf.Margin = new System.Windows.Forms.Padding(4);
            this.search_tf.Name = "search_tf";
            this.search_tf.Size = new System.Drawing.Size(316, 26);
            this.search_tf.TabIndex = 328;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(338, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 32);
            this.button1.TabIndex = 327;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // close_btn
            // 
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(869, 489);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(127, 35);
            this.close_btn.TabIndex = 336;
            this.close_btn.Text = "Close";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // tblDatagridView
            // 
            this.tblDatagridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDatagridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mctdate,
            this.mctno,
            this.description,
            this.requester});
            this.tblDatagridView.Location = new System.Drawing.Point(15, 103);
            this.tblDatagridView.Name = "tblDatagridView";
            this.tblDatagridView.ReadOnly = true;
            this.tblDatagridView.RowHeadersWidth = 28;
            this.tblDatagridView.RowTemplate.Height = 24;
            this.tblDatagridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblDatagridView.Size = new System.Drawing.Size(981, 363);
            this.tblDatagridView.TabIndex = 337;
            // 
            // mctdate
            // 
            this.mctdate.DataPropertyName = "idate";
            this.mctdate.HeaderText = "MCT Date";
            this.mctdate.Name = "mctdate";
            this.mctdate.ReadOnly = true;
            // 
            // mctno
            // 
            this.mctno.DataPropertyName = "mct";
            this.mctno.HeaderText = "MCT No.";
            this.mctno.Name = "mctno";
            this.mctno.ReadOnly = true;
            this.mctno.Width = 120;
            // 
            // description
            // 
            this.description.DataPropertyName = "idescription";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 280;
            // 
            // requester
            // 
            this.requester.DataPropertyName = "Requisitioner";
            this.requester.HeaderText = "Requisitioner";
            this.requester.Name = "requester";
            this.requester.ReadOnly = true;
            this.requester.Width = 150;
            // 
            // select_btn
            // 
            this.select_btn.Image = ((System.Drawing.Image)(resources.GetObject("select_btn.Image")));
            this.select_btn.Location = new System.Drawing.Point(736, 489);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(127, 35);
            this.select_btn.TabIndex = 335;
            this.select_btn.Text = "Select";
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.select_btn.UseVisualStyleBackColor = true;
            this.select_btn.Click += new System.EventHandler(this.rvposelect_btn_Click);
            // 
            // referencemctFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 549);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.To_dp);
            this.Controls.Add(this.From_dp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.search_tf);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.tblDatagridView);
            this.Controls.Add(this.select_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "referencemctFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Material Charge Ticket";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.referencemctFrm_FormClosed);
            this.Load += new System.EventHandler(this.referencemctFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblDatagridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker To_dp;
        private System.Windows.Forms.DateTimePicker From_dp;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox search_tf;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.DataGridView tblDatagridView;
        private System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mctdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn mctno;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn requester;
    }
}