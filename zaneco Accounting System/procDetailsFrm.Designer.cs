namespace zaneco_Accounting_System
{
    partial class procDetailsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(procDetailsFrm));
            this.chart_lv = new System.Windows.Forms.ListView();
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.debitTotal_lb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeProc_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_lv
            // 
            this.chart_lv.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.chart_lv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chart_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.code,
            this.name,
            this.bal});
            this.chart_lv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F);
            this.chart_lv.ForeColor = System.Drawing.Color.SteelBlue;
            this.chart_lv.FullRowSelect = true;
            this.chart_lv.GridLines = true;
            this.chart_lv.HideSelection = false;
            this.chart_lv.Location = new System.Drawing.Point(13, 13);
            this.chart_lv.Margin = new System.Windows.Forms.Padding(4);
            this.chart_lv.Name = "chart_lv";
            this.chart_lv.Size = new System.Drawing.Size(729, 263);
            this.chart_lv.TabIndex = 291;
            this.chart_lv.UseCompatibleStateImageBehavior = false;
            this.chart_lv.View = System.Windows.Forms.View.Details;
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
            // bal
            // 
            this.bal.Text = "Balance";
            this.bal.Width = 120;
            // 
            // debitTotal_lb
            // 
            this.debitTotal_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debitTotal_lb.ForeColor = System.Drawing.Color.SeaGreen;
            this.debitTotal_lb.Location = new System.Drawing.Point(526, 1);
            this.debitTotal_lb.Margin = new System.Windows.Forms.Padding(2);
            this.debitTotal_lb.Name = "debitTotal_lb";
            this.debitTotal_lb.Size = new System.Drawing.Size(183, 26);
            this.debitTotal_lb.TabIndex = 23;
            this.debitTotal_lb.Text = "0.00";
            this.debitTotal_lb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "TOTAL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.debitTotal_lb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 32);
            this.panel1.TabIndex = 292;
            // 
            // closeProc_btn
            // 
            this.closeProc_btn.Image = ((System.Drawing.Image)(resources.GetObject("closeProc_btn.Image")));
            this.closeProc_btn.Location = new System.Drawing.Point(615, 335);
            this.closeProc_btn.Name = "closeProc_btn";
            this.closeProc_btn.Size = new System.Drawing.Size(127, 35);
            this.closeProc_btn.TabIndex = 303;
            this.closeProc_btn.Text = "Cancel";
            this.closeProc_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeProc_btn.UseVisualStyleBackColor = true;
            this.closeProc_btn.Click += new System.EventHandler(this.closeProc_btn_Click);
            // 
            // procDetailsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 390);
            this.Controls.Add(this.closeProc_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart_lv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "procDetailsFrm";
            this.Text = "procDetailsFrm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView chart_lv;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader bal;
        private System.Windows.Forms.Label debitTotal_lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeProc_btn;
    }
}