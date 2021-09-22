namespace zaneco_Accounting_System
{
    partial class payeeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(payeeFrm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.add_btn = new DevExpress.XtraBars.BarButtonItem();
            this.edit_btn = new DevExpress.XtraBars.BarButtonItem();
            this.delete_btn = new DevExpress.XtraBars.BarButtonItem();
            this.refresh_btn = new DevExpress.XtraBars.BarButtonItem();
            this.Close_btn = new DevExpress.XtraBars.BarButtonItem();
            this.bar6 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.entryPanel = new System.Windows.Forms.Panel();
            this.id_tf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.name_tf = new System.Windows.Forms.TextBox();
            this.code_tf = new System.Windows.Forms.TextBox();
            this.okcancel_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cvlbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.entryPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(4, 34);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1372, 659);
            this.gridControl1.TabIndex = 451;
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn7});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Payee Code";
            this.gridColumn2.FieldName = "PCode";
            this.gridColumn2.MinWidth = 190;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 460;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Payee Name";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 950;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ID";
            this.gridColumn7.FieldName = "idpayee";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 94;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.FloatLocation = new System.Drawing.Point(159, 161);
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar5,
            this.bar6});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.add_btn,
            this.edit_btn,
            this.delete_btn,
            this.Close_btn,
            this.refresh_btn});
            this.barManager1.MainMenu = this.bar5;
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar6;
            // 
            // bar5
            // 
            this.bar5.BarName = "Main menu";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.FloatLocation = new System.Drawing.Point(998, 287);
            this.bar5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.add_btn),
            new DevExpress.XtraBars.LinkPersistInfo(this.edit_btn),
            new DevExpress.XtraBars.LinkPersistInfo(this.delete_btn),
            new DevExpress.XtraBars.LinkPersistInfo(this.refresh_btn),
            new DevExpress.XtraBars.LinkPersistInfo(this.Close_btn)});
            this.bar5.OptionsBar.MultiLine = true;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Main menu";
            // 
            // add_btn
            // 
            this.add_btn.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.add_btn.Caption = "Add";
            this.add_btn.Id = 0;
            this.add_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("add_btn.ImageOptions.Image")));
            this.add_btn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("add_btn.ImageOptions.LargeImage")));
            this.add_btn.Name = "add_btn";
            this.add_btn.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.add_btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.add_btn_ItemClick);
            // 
            // edit_btn
            // 
            this.edit_btn.Caption = "Edit";
            this.edit_btn.Id = 1;
            this.edit_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("edit_btn.ImageOptions.Image")));
            this.edit_btn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("edit_btn.ImageOptions.LargeImage")));
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.edit_btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.edit_btn_ItemClick);
            // 
            // delete_btn
            // 
            this.delete_btn.Caption = "Delete";
            this.delete_btn.Id = 2;
            this.delete_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("delete_btn.ImageOptions.Image")));
            this.delete_btn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("delete_btn.ImageOptions.LargeImage")));
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.delete_btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.delete_btn_ItemClick);
            // 
            // refresh_btn
            // 
            this.refresh_btn.Caption = "Refresh";
            this.refresh_btn.Id = 4;
            this.refresh_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("refresh_btn.ImageOptions.Image")));
            this.refresh_btn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("refresh_btn.ImageOptions.LargeImage")));
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.refresh_btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.refresh_btn_ItemClick);
            // 
            // Close_btn
            // 
            this.Close_btn.Caption = "Close";
            this.Close_btn.Id = 3;
            this.Close_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Close_btn.ImageOptions.Image")));
            this.Close_btn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Close_btn.ImageOptions.LargeImage")));
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Close_btn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Close_btn_ItemClick);
            // 
            // bar6
            // 
            this.bar6.BarName = "Status bar";
            this.bar6.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar6.DockCol = 0;
            this.bar6.DockRow = 0;
            this.bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar6.OptionsBar.AllowQuickCustomization = false;
            this.bar6.OptionsBar.DrawDragBorder = false;
            this.bar6.OptionsBar.UseWholeRow = true;
            this.bar6.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(4, 4);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1372, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(4, 693);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1372, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(4, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 659);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1376, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 659);
            // 
            // bar4
            // 
            this.bar4.BarName = "Main menu";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.FloatLocation = new System.Drawing.Point(159, 161);
            this.bar4.OptionsBar.MultiLine = true;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Main menu";
            // 
            // entryPanel
            // 
            this.entryPanel.BackColor = System.Drawing.Color.Azure;
            this.entryPanel.Controls.Add(this.id_tf);
            this.entryPanel.Controls.Add(this.label2);
            this.entryPanel.Controls.Add(this.label1);
            this.entryPanel.Controls.Add(this.name_tf);
            this.entryPanel.Controls.Add(this.code_tf);
            this.entryPanel.Controls.Add(this.okcancel_btn);
            this.entryPanel.Controls.Add(this.button1);
            this.entryPanel.Controls.Add(this.panel6);
            this.entryPanel.Location = new System.Drawing.Point(445, 255);
            this.entryPanel.Name = "entryPanel";
            this.entryPanel.Size = new System.Drawing.Size(561, 254);
            this.entryPanel.TabIndex = 456;
            this.entryPanel.Visible = false;
            // 
            // id_tf
            // 
            this.id_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_tf.Location = new System.Drawing.Point(139, 42);
            this.id_tf.Name = "id_tf";
            this.id_tf.Size = new System.Drawing.Size(395, 27);
            this.id_tf.TabIndex = 423;
            this.id_tf.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 23);
            this.label2.TabIndex = 422;
            this.label2.Text = "Payee Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 421;
            this.label1.Text = "Payee Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // name_tf
            // 
            this.name_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_tf.Location = new System.Drawing.Point(140, 108);
            this.name_tf.Multiline = true;
            this.name_tf.Name = "name_tf";
            this.name_tf.Size = new System.Drawing.Size(395, 53);
            this.name_tf.TabIndex = 420;
            // 
            // code_tf
            // 
            this.code_tf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code_tf.Location = new System.Drawing.Point(140, 75);
            this.code_tf.Name = "code_tf";
            this.code_tf.Size = new System.Drawing.Size(317, 27);
            this.code_tf.TabIndex = 419;
            // 
            // okcancel_btn
            // 
            this.okcancel_btn.BackColor = System.Drawing.Color.SeaGreen;
            this.okcancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okcancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okcancel_btn.ForeColor = System.Drawing.Color.SeaShell;
            this.okcancel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okcancel_btn.Location = new System.Drawing.Point(139, 195);
            this.okcancel_btn.Margin = new System.Windows.Forms.Padding(0);
            this.okcancel_btn.Name = "okcancel_btn";
            this.okcancel_btn.Size = new System.Drawing.Size(106, 36);
            this.okcancel_btn.TabIndex = 418;
            this.okcancel_btn.Text = "OK";
            this.okcancel_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okcancel_btn.UseVisualStyleBackColor = false;
            this.okcancel_btn.Click += new System.EventHandler(this.okcancel_btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SeaShell;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(245, 195);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 36);
            this.button1.TabIndex = 417;
            this.button1.Text = "Cancel";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel6.Controls.Add(this.cvlbl);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(561, 38);
            this.panel6.TabIndex = 0;
            // 
            // cvlbl
            // 
            this.cvlbl.AutoSize = true;
            this.cvlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cvlbl.ForeColor = System.Drawing.Color.Yellow;
            this.cvlbl.Location = new System.Drawing.Point(137, 10);
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
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Payee Entry";
            // 
            // payeeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1380, 721);
            this.Controls.Add(this.entryPanel);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "payeeFrm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payee Record";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.payeeFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.entryPanel.ResumeLayout(false);
            this.entryPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarButtonItem add_btn;
        private DevExpress.XtraBars.BarButtonItem edit_btn;
        private DevExpress.XtraBars.BarButtonItem delete_btn;
        private DevExpress.XtraBars.BarButtonItem Close_btn;
        private DevExpress.XtraBars.Bar bar6;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar4;
        private System.Windows.Forms.Panel entryPanel;
        private System.Windows.Forms.Button okcancel_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label cvlbl;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraBars.BarButtonItem refresh_btn;
        public System.Windows.Forms.TextBox id_tf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox name_tf;
        public System.Windows.Forms.TextBox code_tf;
    }
}