namespace zaneco_Accounting_System
{
    partial class selectChartFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectChartFrm));
            this.search_tf = new System.Windows.Forms.TextBox();
            this.select_btn = new System.Windows.Forms.Button();
            this.chart_lv = new System.Windows.Forms.ListView();
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bankcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.close_btn = new System.Windows.Forms.Button();
            this.isSource_cb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // search_tf
            // 
            this.search_tf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.search_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.search_tf.Location = new System.Drawing.Point(13, 12);
            this.search_tf.Margin = new System.Windows.Forms.Padding(4);
            this.search_tf.Name = "search_tf";
            this.search_tf.Size = new System.Drawing.Size(472, 26);
            this.search_tf.TabIndex = 291;
            this.search_tf.TextChanged += new System.EventHandler(this.search_tf_TextChanged);
            this.search_tf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_tf_KeyDown);
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select_btn.Location = new System.Drawing.Point(492, 6);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(34, 32);
            this.select_btn.TabIndex = 290;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // chart_lv
            // 
            this.chart_lv.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.chart_lv.BackColor = System.Drawing.SystemColors.Window;
            this.chart_lv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chart_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.code,
            this.name,
            this.Type,
            this.bankcode});
            this.chart_lv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
            this.chart_lv.ForeColor = System.Drawing.Color.SteelBlue;
            this.chart_lv.FullRowSelect = true;
            this.chart_lv.GridLines = true;
            this.chart_lv.HideSelection = false;
            this.chart_lv.Location = new System.Drawing.Point(13, 46);
            this.chart_lv.Margin = new System.Windows.Forms.Padding(4);
            this.chart_lv.Name = "chart_lv";
            this.chart_lv.Size = new System.Drawing.Size(736, 263);
            this.chart_lv.TabIndex = 289;
            this.chart_lv.UseCompatibleStateImageBehavior = false;
            this.chart_lv.View = System.Windows.Forms.View.Details;
            this.chart_lv.SelectedIndexChanged += new System.EventHandler(this.chart_lv_SelectedIndexChanged);
            this.chart_lv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chart_lv_KeyDown);
            // 
            // code
            // 
            this.code.Text = "Account Code";
            this.code.Width = 120;
            // 
            // name
            // 
            this.name.Text = "Account Name";
            this.name.Width = 250;
            // 
            // Type
            // 
            this.Type.DisplayIndex = 3;
            this.Type.Text = "Type";
            this.Type.Width = 150;
            // 
            // bankcode
            // 
            this.bankcode.DisplayIndex = 2;
            this.bankcode.Width = 0;
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.White;
            this.close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.close_btn.FlatAppearance.BorderSize = 0;
            this.close_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.close_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.close_btn.ForeColor = System.Drawing.Color.Black;
            this.close_btn.Location = new System.Drawing.Point(715, 6);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(34, 32);
            this.close_btn.TabIndex = 288;
            this.close_btn.Text = "X";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // isSource_cb
            // 
            this.isSource_cb.AutoSize = true;
            this.isSource_cb.Location = new System.Drawing.Point(532, 17);
            this.isSource_cb.Name = "isSource_cb";
            this.isSource_cb.Size = new System.Drawing.Size(127, 21);
            this.isSource_cb.TabIndex = 292;
            this.isSource_cb.Text = "Source of Fund";
            this.isSource_cb.UseVisualStyleBackColor = true;
            this.isSource_cb.Visible = false;
            // 
            // selectChartFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(762, 347);
            this.Controls.Add(this.isSource_cb);
            this.Controls.Add(this.search_tf);
            this.Controls.Add(this.select_btn);
            this.Controls.Add(this.chart_lv);
            this.Controls.Add(this.close_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "selectChartFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "selectChartFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.selectChartFrm_FormClosed);
            this.Load += new System.EventHandler(this.selectChartFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox search_tf;
        internal System.Windows.Forms.Button select_btn;
        internal System.Windows.Forms.ListView chart_lv;
        private System.Windows.Forms.ColumnHeader code;
        internal System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.ColumnHeader name;
        public System.Windows.Forms.CheckBox isSource_cb;
        private System.Windows.Forms.ColumnHeader bankcode;
        private System.Windows.Forms.ColumnHeader Type;
    }
}