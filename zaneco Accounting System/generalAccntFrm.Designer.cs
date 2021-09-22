namespace zaneco_Accounting_System
{
    partial class generalAccntFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(generalAccntFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.print_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.generalaccount_datagrid = new System.Windows.Forms.DataGridView();
            this.chartGeneralAccntBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chartDS = new zaneco_Accounting_System.DataSource.chartDS();
            this.chartGeneralAccntTableAdapter = new zaneco_Accounting_System.DataSource.chartDSTableAdapters.chartGeneralAccntTableAdapter();
            this.search_tf = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.accountcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalaccount_datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGeneralAccntBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDS)).BeginInit();
            this.SuspendLayout();
            // 
            // print_btn
            // 
            this.print_btn.Image = ((System.Drawing.Image)(resources.GetObject("print_btn.Image")));
            this.print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.print_btn.Location = new System.Drawing.Point(445, 389);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(87, 35);
            this.print_btn.TabIndex = 426;
            this.print_btn.Text = "Select";
            this.print_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(538, 389);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(87, 35);
            this.close_btn.TabIndex = 427;
            this.close_btn.Text = "Cancel";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel5.Controls.Add(this.label12);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(637, 38);
            this.panel5.TabIndex = 425;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(366, 27);
            this.label12.TabIndex = 405;
            this.label12.Tag = "";
            this.label12.Text = "Select General Account";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // generalaccount_datagrid
            // 
            this.generalaccount_datagrid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.generalaccount_datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.generalaccount_datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountcodeDataGridViewTextBoxColumn,
            this.accountnameDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn});
            this.generalaccount_datagrid.DataSource = this.chartGeneralAccntBindingSource;
            this.generalaccount_datagrid.EnableHeadersVisualStyles = false;
            this.generalaccount_datagrid.Location = new System.Drawing.Point(15, 92);
            this.generalaccount_datagrid.Name = "generalaccount_datagrid";
            this.generalaccount_datagrid.ReadOnly = true;
            this.generalaccount_datagrid.RowHeadersWidth = 20;
            this.generalaccount_datagrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.generalaccount_datagrid.RowTemplate.Height = 24;
            this.generalaccount_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.generalaccount_datagrid.Size = new System.Drawing.Size(610, 279);
            this.generalaccount_datagrid.TabIndex = 424;
            this.generalaccount_datagrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.generalaccount_datagrid_KeyDown);
            // 
            // chartGeneralAccntBindingSource
            // 
            this.chartGeneralAccntBindingSource.DataMember = "chartGeneralAccnt";
            this.chartGeneralAccntBindingSource.DataSource = this.chartDS;
            // 
            // chartDS
            // 
            this.chartDS.DataSetName = "chartDS";
            this.chartDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chartGeneralAccntTableAdapter
            // 
            this.chartGeneralAccntTableAdapter.ClearBeforeFill = true;
            // 
            // search_tf
            // 
            this.search_tf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.search_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.search_tf.Location = new System.Drawing.Point(15, 59);
            this.search_tf.Margin = new System.Windows.Forms.Padding(4);
            this.search_tf.Name = "search_tf";
            this.search_tf.Size = new System.Drawing.Size(569, 26);
            this.search_tf.TabIndex = 429;
            // 
            // search_btn
            // 
            this.search_btn.AutoSize = true;
            this.search_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.search_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("search_btn.BackgroundImage")));
            this.search_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.search_btn.Location = new System.Drawing.Point(591, 57);
            this.search_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(34, 32);
            this.search_btn.TabIndex = 428;
            this.search_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // accountcodeDataGridViewTextBoxColumn
            // 
            this.accountcodeDataGridViewTextBoxColumn.DataPropertyName = "accountcode";
            this.accountcodeDataGridViewTextBoxColumn.HeaderText = "Account Code";
            this.accountcodeDataGridViewTextBoxColumn.Name = "accountcodeDataGridViewTextBoxColumn";
            this.accountcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accountnameDataGridViewTextBoxColumn
            // 
            this.accountnameDataGridViewTextBoxColumn.DataPropertyName = "accountname";
            this.accountnameDataGridViewTextBoxColumn.HeaderText = "Account Name";
            this.accountnameDataGridViewTextBoxColumn.Name = "accountnameDataGridViewTextBoxColumn";
            this.accountnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.accountnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Width = 60;
            // 
            // generalAccntFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 440);
            this.Controls.Add(this.search_tf);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.generalaccount_datagrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "generalAccntFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "generalAccntFrm";
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.generalaccount_datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGeneralAccntBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.DataGridView generalaccount_datagrid;
        private System.Windows.Forms.BindingSource chartGeneralAccntBindingSource;
        private DataSource.chartDS chartDS;
        private DataSource.chartDSTableAdapters.chartGeneralAccntTableAdapter chartGeneralAccntTableAdapter;
        public System.Windows.Forms.TextBox search_tf;
        internal System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
    }
}