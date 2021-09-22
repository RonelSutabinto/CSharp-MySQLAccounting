namespace zaneco_Accounting_System
{
    partial class cvJournal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cvJournal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.export_btn = new System.Windows.Forms.Button();
            this.cancelledd_btn = new System.Windows.Forms.Button();
            this.update_btn = new System.Windows.Forms.Button();
            this.close_bnt = new System.Windows.Forms.Button();
            this.deleteAccntCode_btn = new System.Windows.Forms.Button();
            this.preview_btn = new System.Windows.Forms.Button();
            this.addAccntCode_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.fr_date = new System.Windows.Forms.DateTimePicker();
            this.chartacamDataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvpcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvpnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checknumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkvoucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkvoucher_ds = new zaneco_Accounting_System.DataSource.checkvoucher_ds();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cancelPanel = new System.Windows.Forms.Panel();
            this.okcancel_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.remarkCancel_tf = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cvlbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checknumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.select_btn = new System.Windows.Forms.Button();
            this.CodeName_tf = new System.Windows.Forms.TextBox();
            this.tableAdapterManager = new zaneco_Accounting_System.DataSource.chart_dataSourceTableAdapters.TableAdapterManager();
            this.checkvoucherTableAdapter = new zaneco_Accounting_System.DataSource.checkvoucher_dsTableAdapters.checkvoucherTableAdapter();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartacamDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkvoucherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkvoucher_ds)).BeginInit();
            this.panel3.SuspendLayout();
            this.cancelPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.export_btn);
            this.panel4.Controls.Add(this.cancelledd_btn);
            this.panel4.Controls.Add(this.update_btn);
            this.panel4.Controls.Add(this.close_bnt);
            this.panel4.Controls.Add(this.deleteAccntCode_btn);
            this.panel4.Controls.Add(this.preview_btn);
            this.panel4.Controls.Add(this.addAccntCode_btn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 680);
            this.panel4.TabIndex = 16;
            // 
            // export_btn
            // 
            this.export_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.export_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.export_btn.ForeColor = System.Drawing.Color.Black;
            this.export_btn.Image = ((System.Drawing.Image)(resources.GetObject("export_btn.Image")));
            this.export_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.export_btn.Location = new System.Drawing.Point(13, 259);
            this.export_btn.Margin = new System.Windows.Forms.Padding(0);
            this.export_btn.Name = "export_btn";
            this.export_btn.Size = new System.Drawing.Size(216, 45);
            this.export_btn.TabIndex = 419;
            this.export_btn.Text = "Export to Excel";
            this.export_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.export_btn.UseVisualStyleBackColor = false;
            this.export_btn.Click += new System.EventHandler(this.export_btn_Click);
            // 
            // cancelledd_btn
            // 
            this.cancelledd_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cancelledd_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelledd_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelledd_btn.ForeColor = System.Drawing.Color.Black;
            this.cancelledd_btn.Image = ((System.Drawing.Image)(resources.GetObject("cancelledd_btn.Image")));
            this.cancelledd_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelledd_btn.Location = new System.Drawing.Point(13, 214);
            this.cancelledd_btn.Margin = new System.Windows.Forms.Padding(0);
            this.cancelledd_btn.Name = "cancelledd_btn";
            this.cancelledd_btn.Size = new System.Drawing.Size(216, 45);
            this.cancelledd_btn.TabIndex = 418;
            this.cancelledd_btn.Text = "Cancelled Detail";
            this.cancelledd_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelledd_btn.UseVisualStyleBackColor = false;
            this.cancelledd_btn.Click += new System.EventHandler(this.cancelledd_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.update_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_btn.ForeColor = System.Drawing.Color.Black;
            this.update_btn.Image = ((System.Drawing.Image)(resources.GetObject("update_btn.Image")));
            this.update_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update_btn.Location = new System.Drawing.Point(13, 79);
            this.update_btn.Margin = new System.Windows.Forms.Padding(0);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(216, 45);
            this.update_btn.TabIndex = 417;
            this.update_btn.Text = "Update Check Voucher";
            this.update_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // close_bnt
            // 
            this.close_bnt.BackColor = System.Drawing.Color.IndianRed;
            this.close_bnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_bnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_bnt.ForeColor = System.Drawing.Color.Black;
            this.close_bnt.Image = ((System.Drawing.Image)(resources.GetObject("close_bnt.Image")));
            this.close_bnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_bnt.Location = new System.Drawing.Point(13, 304);
            this.close_bnt.Margin = new System.Windows.Forms.Padding(0);
            this.close_bnt.Name = "close_bnt";
            this.close_bnt.Size = new System.Drawing.Size(216, 45);
            this.close_bnt.TabIndex = 416;
            this.close_bnt.Text = "Close";
            this.close_bnt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_bnt.UseVisualStyleBackColor = false;
            this.close_bnt.Click += new System.EventHandler(this.close_bnt_Click);
            // 
            // deleteAccntCode_btn
            // 
            this.deleteAccntCode_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.deleteAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAccntCode_btn.ForeColor = System.Drawing.Color.Black;
            this.deleteAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("deleteAccntCode_btn.Image")));
            this.deleteAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteAccntCode_btn.Location = new System.Drawing.Point(13, 169);
            this.deleteAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.deleteAccntCode_btn.Name = "deleteAccntCode_btn";
            this.deleteAccntCode_btn.Size = new System.Drawing.Size(216, 45);
            this.deleteAccntCode_btn.TabIndex = 406;
            this.deleteAccntCode_btn.Text = "Cancel CV";
            this.deleteAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteAccntCode_btn.UseVisualStyleBackColor = false;
            this.deleteAccntCode_btn.Click += new System.EventHandler(this.deleteAccntCode_btn_Click);
            // 
            // preview_btn
            // 
            this.preview_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.preview_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preview_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preview_btn.ForeColor = System.Drawing.Color.Black;
            this.preview_btn.Image = ((System.Drawing.Image)(resources.GetObject("preview_btn.Image")));
            this.preview_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.preview_btn.Location = new System.Drawing.Point(13, 124);
            this.preview_btn.Margin = new System.Windows.Forms.Padding(0);
            this.preview_btn.Name = "preview_btn";
            this.preview_btn.Size = new System.Drawing.Size(216, 45);
            this.preview_btn.TabIndex = 405;
            this.preview_btn.Text = "Preview Check Voucher";
            this.preview_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.preview_btn.UseVisualStyleBackColor = false;
            this.preview_btn.Click += new System.EventHandler(this.editAccntCode_btn_Click);
            // 
            // addAccntCode_btn
            // 
            this.addAccntCode_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.addAccntCode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAccntCode_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAccntCode_btn.ForeColor = System.Drawing.Color.Black;
            this.addAccntCode_btn.Image = ((System.Drawing.Image)(resources.GetObject("addAccntCode_btn.Image")));
            this.addAccntCode_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addAccntCode_btn.Location = new System.Drawing.Point(13, 34);
            this.addAccntCode_btn.Margin = new System.Windows.Forms.Padding(0);
            this.addAccntCode_btn.Name = "addAccntCode_btn";
            this.addAccntCode_btn.Size = new System.Drawing.Size(216, 45);
            this.addAccntCode_btn.TabIndex = 404;
            this.addAccntCode_btn.Text = "Add Check Voucher";
            this.addAccntCode_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAccntCode_btn.UseVisualStyleBackColor = false;
            this.addAccntCode_btn.Click += new System.EventHandler(this.addAccntCode_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(447, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 401;
            this.label2.Text = "Covered Date";
            // 
            // to_date
            // 
            this.to_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_date.Location = new System.Drawing.Point(734, 15);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(151, 27);
            this.to_date.TabIndex = 400;
            // 
            // fr_date
            // 
            this.fr_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fr_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fr_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fr_date.Location = new System.Drawing.Point(581, 16);
            this.fr_date.Name = "fr_date";
            this.fr_date.Size = new System.Drawing.Size(147, 27);
            this.fr_date.TabIndex = 399;
            // 
            // chartacamDataGridView1
            // 
            this.chartacamDataGridView1.AutoGenerateColumns = false;
            this.chartacamDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chartacamDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cvnumberDataGridViewTextBoxColumn,
            this.cvdateDataGridViewTextBoxColumn,
            this.cvpcodeDataGridViewTextBoxColumn,
            this.cvpnameDataGridViewTextBoxColumn,
            this.cvamountDataGridViewTextBoxColumn,
            this.refnumberDataGridViewTextBoxColumn,
            this.checknumberDataGridViewTextBoxColumn,
            this.bank});
            this.chartacamDataGridView1.DataSource = this.checkvoucherBindingSource;
            this.chartacamDataGridView1.Location = new System.Drawing.Point(286, 692);
            this.chartacamDataGridView1.Name = "chartacamDataGridView1";
            this.chartacamDataGridView1.ReadOnly = true;
            this.chartacamDataGridView1.RowHeadersWidth = 30;
            this.chartacamDataGridView1.RowTemplate.Height = 24;
            this.chartacamDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chartacamDataGridView1.Size = new System.Drawing.Size(1080, 467);
            this.chartacamDataGridView1.TabIndex = 6;
            this.chartacamDataGridView1.Visible = false;
            this.chartacamDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.chartacamDataGridView_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "idcheckvoucher";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 70;
            // 
            // cvnumberDataGridViewTextBoxColumn
            // 
            this.cvnumberDataGridViewTextBoxColumn.DataPropertyName = "cvnumber";
            this.cvnumberDataGridViewTextBoxColumn.HeaderText = "CVNo.";
            this.cvnumberDataGridViewTextBoxColumn.Name = "cvnumberDataGridViewTextBoxColumn";
            this.cvnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.cvnumberDataGridViewTextBoxColumn.Width = 80;
            // 
            // cvdateDataGridViewTextBoxColumn
            // 
            this.cvdateDataGridViewTextBoxColumn.DataPropertyName = "cvdate";
            this.cvdateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.cvdateDataGridViewTextBoxColumn.Name = "cvdateDataGridViewTextBoxColumn";
            this.cvdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.cvdateDataGridViewTextBoxColumn.Width = 80;
            // 
            // cvpcodeDataGridViewTextBoxColumn
            // 
            this.cvpcodeDataGridViewTextBoxColumn.DataPropertyName = "cvpcode";
            this.cvpcodeDataGridViewTextBoxColumn.HeaderText = "Payee Code";
            this.cvpcodeDataGridViewTextBoxColumn.Name = "cvpcodeDataGridViewTextBoxColumn";
            this.cvpcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.cvpcodeDataGridViewTextBoxColumn.Width = 130;
            // 
            // cvpnameDataGridViewTextBoxColumn
            // 
            this.cvpnameDataGridViewTextBoxColumn.DataPropertyName = "cvpname";
            this.cvpnameDataGridViewTextBoxColumn.HeaderText = "Payee";
            this.cvpnameDataGridViewTextBoxColumn.Name = "cvpnameDataGridViewTextBoxColumn";
            this.cvpnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cvpnameDataGridViewTextBoxColumn.Width = 150;
            // 
            // cvamountDataGridViewTextBoxColumn
            // 
            this.cvamountDataGridViewTextBoxColumn.DataPropertyName = "cvamount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.cvamountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cvamountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.cvamountDataGridViewTextBoxColumn.Name = "cvamountDataGridViewTextBoxColumn";
            this.cvamountDataGridViewTextBoxColumn.ReadOnly = true;
            this.cvamountDataGridViewTextBoxColumn.Width = 90;
            // 
            // refnumberDataGridViewTextBoxColumn
            // 
            this.refnumberDataGridViewTextBoxColumn.DataPropertyName = "refnumber";
            this.refnumberDataGridViewTextBoxColumn.HeaderText = "Ref.No.";
            this.refnumberDataGridViewTextBoxColumn.Name = "refnumberDataGridViewTextBoxColumn";
            this.refnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.refnumberDataGridViewTextBoxColumn.Width = 80;
            // 
            // checknumberDataGridViewTextBoxColumn
            // 
            this.checknumberDataGridViewTextBoxColumn.DataPropertyName = "checknumber";
            this.checknumberDataGridViewTextBoxColumn.HeaderText = "CheckNo.";
            this.checknumberDataGridViewTextBoxColumn.Name = "checknumberDataGridViewTextBoxColumn";
            this.checknumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bank
            // 
            this.bank.DataPropertyName = "bank";
            this.bank.HeaderText = "Bank";
            this.bank.Name = "bank";
            this.bank.ReadOnly = true;
            this.bank.Width = 60;
            // 
            // checkvoucherBindingSource
            // 
            this.checkvoucherBindingSource.DataMember = "checkvoucher";
            this.checkvoucherBindingSource.DataSource = this.checkvoucher_ds;
            // 
            // checkvoucher_ds
            // 
            this.checkvoucher_ds.DataSetName = "checkvoucher_ds";
            this.checkvoucher_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "cvNo./Payee";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cancelPanel);
            this.panel3.Controls.Add(this.gridControl1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.chartacamDataGridView1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1443, 680);
            this.panel3.TabIndex = 18;
            // 
            // cancelPanel
            // 
            this.cancelPanel.Controls.Add(this.okcancel_btn);
            this.cancelPanel.Controls.Add(this.close_btn);
            this.cancelPanel.Controls.Add(this.label6);
            this.cancelPanel.Controls.Add(this.remarkCancel_tf);
            this.cancelPanel.Controls.Add(this.panel6);
            this.cancelPanel.Location = new System.Drawing.Point(491, 357);
            this.cancelPanel.Name = "cancelPanel";
            this.cancelPanel.Size = new System.Drawing.Size(490, 210);
            this.cancelPanel.TabIndex = 19;
            this.cancelPanel.Visible = false;
            // 
            // okcancel_btn
            // 
            this.okcancel_btn.BackColor = System.Drawing.Color.SeaGreen;
            this.okcancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okcancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okcancel_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.okcancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okcancel_btn.Location = new System.Drawing.Point(262, 158);
            this.okcancel_btn.Margin = new System.Windows.Forms.Padding(0);
            this.okcancel_btn.Name = "okcancel_btn";
            this.okcancel_btn.Size = new System.Drawing.Size(106, 36);
            this.okcancel_btn.TabIndex = 418;
            this.okcancel_btn.Text = "OK";
            this.okcancel_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okcancel_btn.UseVisualStyleBackColor = false;
            this.okcancel_btn.Click += new System.EventHandler(this.okcancel_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.IndianRed;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.close_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_btn.Location = new System.Drawing.Point(368, 158);
            this.close_btn.Margin = new System.Windows.Forms.Padding(0);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(106, 36);
            this.close_btn.TabIndex = 417;
            this.close_btn.Text = "Cancel";
            this.close_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Remarks";
            // 
            // remarkCancel_tf
            // 
            this.remarkCancel_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remarkCancel_tf.Location = new System.Drawing.Point(26, 75);
            this.remarkCancel_tf.Multiline = true;
            this.remarkCancel_tf.Name = "remarkCancel_tf";
            this.remarkCancel_tf.Size = new System.Drawing.Size(448, 68);
            this.remarkCancel_tf.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel6.Controls.Add(this.cvlbl);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(490, 38);
            this.panel6.TabIndex = 0;
            // 
            // cvlbl
            // 
            this.cvlbl.AutoSize = true;
            this.cvlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cvlbl.ForeColor = System.Drawing.Color.Yellow;
            this.cvlbl.Location = new System.Drawing.Point(175, 10);
            this.cvlbl.Name = "cvlbl";
            this.cvlbl.Size = new System.Drawing.Size(111, 18);
            this.cvlbl.TabIndex = 1;
            this.cvlbl.Text = "(CV2021-000)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cencel CV Entry";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_EmbeddedNavigator_KeyDown);
            this.gridControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(246, 52);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1197, 628);
            this.gridControl1.TabIndex = 449;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.HotTrack;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.HotTrack;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn6,
            this.checknumber,
            this.gridColumn8,
            this.gridColumn11,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", this.gridColumn10, "(Amount: SUM={0:c2})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "idcheckvoucher";
            this.gridColumn2.FieldName = "idcheckvoucher";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 125;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CV No.";
            this.gridColumn1.FieldName = "cvnumber";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 108;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Date";
            this.gridColumn7.FieldName = "cvdate";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Payee Code";
            this.gridColumn9.FieldName = "cvpcode";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 130;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Payee";
            this.gridColumn3.FieldName = "cvpname";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 192;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Description";
            this.gridColumn5.FieldName = "paymentDesc";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 187;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Amount";
            this.gridColumn10.DisplayFormat.FormatString = "c2";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "total";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "SUM={0:c2}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            this.gridColumn10.Width = 130;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ref. No.";
            this.gridColumn6.FieldName = "refnumber";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 97;
            // 
            // checknumber
            // 
            this.checknumber.Caption = "Check No.";
            this.checknumber.FieldName = "checknumber";
            this.checknumber.MinWidth = 25;
            this.checknumber.Name = "checknumber";
            this.checknumber.Visible = true;
            this.checknumber.VisibleIndex = 7;
            this.checknumber.Width = 117;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Bank";
            this.gridColumn8.FieldName = "bank";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 150;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "voidcheck";
            this.gridColumn11.FieldName = "voidcheck";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 143;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "userID";
            this.gridColumn4.FieldName = "userID";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 94;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.to_date);
            this.panel1.Controls.Add(this.fr_date);
            this.panel1.Controls.Add(this.select_btn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CodeName_tf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(246, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 52);
            this.panel1.TabIndex = 17;
            // 
            // select_btn
            // 
            this.select_btn.AutoSize = true;
            this.select_btn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_btn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.select_btn.Location = new System.Drawing.Point(363, 13);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(53, 32);
            this.select_btn.TabIndex = 411;
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // CodeName_tf
            // 
            this.CodeName_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeName_tf.Location = new System.Drawing.Point(134, 16);
            this.CodeName_tf.Name = "CodeName_tf";
            this.CodeName_tf.Size = new System.Drawing.Size(229, 27);
            this.CodeName_tf.TabIndex = 0;
            this.CodeName_tf.TextChanged += new System.EventHandler(this.CodeName_tf_TextChanged);
            this.CodeName_tf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeName_tf_KeyDown);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.acctcategoryTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = zaneco_Accounting_System.DataSource.chart_dataSourceTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // checkvoucherTableAdapter
            // 
            this.checkvoucherTableAdapter.ClearBeforeFill = true;
            // 
            // cvJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1451, 688);
            this.Controls.Add(this.panel3);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "cvJournal";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Check Voucher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.cvJournal_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartacamDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkvoucherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkvoucher_ds)).EndInit();
            this.panel3.ResumeLayout(false);
            this.cancelPanel.ResumeLayout(false);
            this.cancelPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button close_bnt;
        private System.Windows.Forms.Button deleteAccntCode_btn;
        private System.Windows.Forms.Button preview_btn;
        private System.Windows.Forms.Button addAccntCode_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView chartacamDataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private DataSource.chart_dataSourceTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource checkvoucherBindingSource;
        private DataSource.checkvoucher_ds checkvoucher_ds;
        private DataSource.checkvoucher_dsTableAdapters.checkvoucherTableAdapter checkvoucherTableAdapter;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvpcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvpnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvamountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checknumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank;
        public System.Windows.Forms.DateTimePicker to_date;
        public System.Windows.Forms.DateTimePicker fr_date;
        public System.Windows.Forms.TextBox CodeName_tf;
        internal System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.Panel cancelPanel;
        private System.Windows.Forms.Button okcancel_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox remarkCancel_tf;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label cvlbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelledd_btn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn checknumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Button export_btn;
        public DevExpress.XtraGrid.GridControl gridControl1;
    }
}