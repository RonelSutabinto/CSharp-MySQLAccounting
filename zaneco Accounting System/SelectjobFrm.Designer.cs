namespace zaneco_Accounting_System
{
    partial class SelectjobFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectjobFrm));
            this.search_tf = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.slect_btn = new System.Windows.Forms.Button();
            this.lblTag = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // search_tf
            // 
            this.search_tf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.search_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.search_tf.Location = new System.Drawing.Point(14, 36);
            this.search_tf.Margin = new System.Windows.Forms.Padding(4);
            this.search_tf.Name = "search_tf";
            this.search_tf.Size = new System.Drawing.Size(598, 26);
            this.search_tf.TabIndex = 304;
            this.search_tf.TextChanged += new System.EventHandler(this.search_tf_TextChanged);
            this.search_tf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_tf_KeyDown);
            // 
            // search_btn
            // 
            this.search_btn.AutoSize = true;
            this.search_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.search_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("search_btn.BackgroundImage")));
            this.search_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.search_btn.Location = new System.Drawing.Point(619, 34);
            this.search_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(34, 32);
            this.search_btn.TabIndex = 303;
            this.search_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.jobcode,
            this.jobname});
            this.dataGridView2.Location = new System.Drawing.Point(14, 69);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(639, 290);
            this.dataGridView2.TabIndex = 302;
            this.dataGridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView2_KeyDown);
            // 
            // id
            // 
            this.id.DataPropertyName = "idjournaljob";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // jobcode
            // 
            this.jobcode.DataPropertyName = "code";
            this.jobcode.HeaderText = "Job Code";
            this.jobcode.Name = "jobcode";
            this.jobcode.ReadOnly = true;
            this.jobcode.Width = 150;
            // 
            // jobname
            // 
            this.jobname.DataPropertyName = "name";
            this.jobname.HeaderText = "jobname";
            this.jobname.Name = "jobname";
            this.jobname.ReadOnly = true;
            this.jobname.Width = 230;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 27);
            this.panel2.TabIndex = 301;
            // 
            // slect_btn
            // 
            this.slect_btn.Image = ((System.Drawing.Image)(resources.GetObject("slect_btn.Image")));
            this.slect_btn.Location = new System.Drawing.Point(529, 378);
            this.slect_btn.Name = "slect_btn";
            this.slect_btn.Size = new System.Drawing.Size(124, 40);
            this.slect_btn.TabIndex = 305;
            this.slect_btn.Text = "Select";
            this.slect_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.slect_btn.UseVisualStyleBackColor = true;
            this.slect_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(25, 362);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(28, 17);
            this.lblTag.TabIndex = 306;
            this.lblTag.Text = "tag";
            this.lblTag.Visible = false;
            // 
            // SelectjobFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 435);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.search_tf);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.slect_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SelectjobFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Job code";
            this.Load += new System.EventHandler(this.SelectjobFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox search_tf;
        internal System.Windows.Forms.Button search_btn;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobname;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button slect_btn;
        public System.Windows.Forms.Label lblTag;
    }
}