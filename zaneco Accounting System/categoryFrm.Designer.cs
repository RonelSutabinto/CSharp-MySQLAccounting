namespace zaneco_Accounting_System
{
    partial class categoryFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(categoryFrm));
            this.search_tf = new System.Windows.Forms.TextBox();
            this.category_lv = new System.Windows.Forms.ListView();
            this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.select_btn = new System.Windows.Forms.Button();
            this.cmd_showInvent = new System.Windows.Forms.Button();
            this.category_dgrid = new System.Windows.Forms.DataGridView();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryDS1 = new zaneco_Accounting_System.DataSource.categoryDS();
            this.categoryTableAdapter1 = new zaneco_Accounting_System.DataSource.categoryDSTableAdapters.categoryTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.category_dgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDS1)).BeginInit();
            this.SuspendLayout();
            // 
            // search_tf
            // 
            this.search_tf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.search_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.search_tf.Location = new System.Drawing.Point(13, 15);
            this.search_tf.Margin = new System.Windows.Forms.Padding(4);
            this.search_tf.Name = "search_tf";
            this.search_tf.Size = new System.Drawing.Size(337, 26);
            this.search_tf.TabIndex = 287;
            this.search_tf.TextChanged += new System.EventHandler(this.search_tf_TextChanged);
            this.search_tf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_tf_KeyDown);
            // 
            // category_lv
            // 
            this.category_lv.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.category_lv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.category_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.category});
            this.category_lv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
            this.category_lv.ForeColor = System.Drawing.Color.SteelBlue;
            this.category_lv.FullRowSelect = true;
            this.category_lv.GridLines = true;
            this.category_lv.HideSelection = false;
            this.category_lv.Location = new System.Drawing.Point(27, 425);
            this.category_lv.Margin = new System.Windows.Forms.Padding(4);
            this.category_lv.Name = "category_lv";
            this.category_lv.Size = new System.Drawing.Size(422, 263);
            this.category_lv.TabIndex = 285;
            this.category_lv.UseCompatibleStateImageBehavior = false;
            this.category_lv.View = System.Windows.Forms.View.Details;
            this.category_lv.Visible = false;
            this.category_lv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.category_lv_KeyDown);
            // 
            // category
            // 
            this.category.Text = "Category";
            this.category.Width = 370;
            // 
            // select_btn
            // 
            this.select_btn.BackColor = System.Drawing.Color.White;
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.select_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.select_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.select_btn.FlatAppearance.BorderSize = 0;
            this.select_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.select_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.select_btn.ForeColor = System.Drawing.Color.Black;
            this.select_btn.Location = new System.Drawing.Point(401, 9);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(34, 32);
            this.select_btn.TabIndex = 284;
            this.select_btn.Text = "X";
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // cmd_showInvent
            // 
            this.cmd_showInvent.AutoSize = true;
            this.cmd_showInvent.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cmd_showInvent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_showInvent.BackgroundImage")));
            this.cmd_showInvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmd_showInvent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd_showInvent.Location = new System.Drawing.Point(361, 9);
            this.cmd_showInvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmd_showInvent.Name = "cmd_showInvent";
            this.cmd_showInvent.Size = new System.Drawing.Size(34, 32);
            this.cmd_showInvent.TabIndex = 286;
            this.cmd_showInvent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmd_showInvent.UseVisualStyleBackColor = false;
            this.cmd_showInvent.Click += new System.EventHandler(this.cmd_showInvent_Click);
            // 
            // category_dgrid
            // 
            this.category_dgrid.AutoGenerateColumns = false;
            this.category_dgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.category_dgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.categoryDataGridViewTextBoxColumn});
            this.category_dgrid.DataSource = this.categoryBindingSource;
            this.category_dgrid.Location = new System.Drawing.Point(13, 48);
            this.category_dgrid.Name = "category_dgrid";
            this.category_dgrid.ReadOnly = true;
            this.category_dgrid.RowHeadersWidth = 20;
            this.category_dgrid.RowTemplate.Height = 24;
            this.category_dgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.category_dgrid.Size = new System.Drawing.Size(422, 280);
            this.category_dgrid.TabIndex = 288;
            this.category_dgrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.category_dgrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "category";
            this.categoryBindingSource.DataSource = this.categoryDS1;
            // 
            // categoryDS1
            // 
            this.categoryDS1.DataSetName = "categoryDS";
            this.categoryDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryTableAdapter1
            // 
            this.categoryTableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idcategory";
            this.dataGridViewTextBoxColumn1.HeaderText = "idcategory";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Account Type";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Width = 250;
            // 
            // categoryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 344);
            this.Controls.Add(this.category_dgrid);
            this.Controls.Add(this.search_tf);
            this.Controls.Add(this.cmd_showInvent);
            this.Controls.Add(this.category_lv);
            this.Controls.Add(this.select_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "categoryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "categoryFrm";
            this.Load += new System.EventHandler(this.categoryFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.category_dgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDS1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox search_tf;
        internal System.Windows.Forms.ListView category_lv;
        private System.Windows.Forms.ColumnHeader category;
        internal System.Windows.Forms.Button select_btn;
        internal System.Windows.Forms.Button cmd_showInvent;
        private System.Windows.Forms.DataGridView category_dgrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryTypeDataGridViewTextBoxColumn;
        private DataSource.categoryDS categoryDS;
        private DataSource.categoryDSTableAdapters.categoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private DataSource.categoryDS categoryDS1;
        private DataSource.categoryDSTableAdapters.categoryTableAdapter categoryTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
    }
}