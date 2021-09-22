namespace zaneco_Accounting_System
{
    partial class apv_cvdetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(apv_cvdetails));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.refdetail_p = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.refdetailDatagrid = new System.Windows.Forms.DataGridView();
            this.qty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refdetail_p.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refdetailDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // refdetail_p
            // 
            this.refdetail_p.BackColor = System.Drawing.Color.LightSkyBlue;
            this.refdetail_p.Controls.Add(this.panel5);
            this.refdetail_p.Controls.Add(this.refdetailDatagrid);
            this.refdetail_p.Location = new System.Drawing.Point(31, 37);
            this.refdetail_p.Name = "refdetail_p";
            this.refdetail_p.Size = new System.Drawing.Size(903, 321);
            this.refdetail_p.TabIndex = 25;
            this.refdetail_p.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(903, 27);
            this.panel5.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 2);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(245, 23);
            this.label12.TabIndex = 405;
            this.label12.Text = "APV Check Voucher  Details";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(870, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 24);
            this.button1.TabIndex = 404;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // refdetailDatagrid
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.refdetailDatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.refdetailDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qty1,
            this.description1,
            this.unit1,
            this.cost1,
            this.Amount1});
            this.refdetailDatagrid.EnableHeadersVisualStyles = false;
            this.refdetailDatagrid.Location = new System.Drawing.Point(6, 31);
            this.refdetailDatagrid.Name = "refdetailDatagrid";
            this.refdetailDatagrid.ReadOnly = true;
            this.refdetailDatagrid.RowTemplate.Height = 24;
            this.refdetailDatagrid.Size = new System.Drawing.Size(896, 279);
            this.refdetailDatagrid.TabIndex = 0;
            // 
            // qty1
            // 
            this.qty1.HeaderText = "Qty";
            this.qty1.Name = "qty1";
            this.qty1.ReadOnly = true;
            this.qty1.Width = 70;
            // 
            // description1
            // 
            this.description1.HeaderText = "Particulars";
            this.description1.Name = "description1";
            this.description1.ReadOnly = true;
            this.description1.Width = 250;
            // 
            // unit1
            // 
            this.unit1.HeaderText = "Unit";
            this.unit1.Name = "unit1";
            this.unit1.ReadOnly = true;
            this.unit1.Width = 80;
            // 
            // cost1
            // 
            this.cost1.HeaderText = "Cost";
            this.cost1.Name = "cost1";
            this.cost1.ReadOnly = true;
            this.cost1.Width = 80;
            // 
            // Amount1
            // 
            this.Amount1.HeaderText = "Amount";
            this.Amount1.Name = "Amount1";
            this.Amount1.ReadOnly = true;
            // 
            // apv_cvdetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 331);
            this.Controls.Add(this.refdetail_p);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "apv_cvdetails";
            this.Text = "apv_cvdetails";
            this.Load += new System.EventHandler(this.apv_cvdetails_Load);
            this.refdetail_p.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refdetailDatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel refdetail_p;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView refdetailDatagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn description1;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount1;
    }
}