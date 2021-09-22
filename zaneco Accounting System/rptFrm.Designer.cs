namespace zaneco_Accounting_System
{
    partial class rptFrm
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
            this.crystalRptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalRptViewer
            // 
            this.crystalRptViewer.ActiveViewIndex = -1;
            this.crystalRptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalRptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalRptViewer.Location = new System.Drawing.Point(0, 0);
            this.crystalRptViewer.Name = "crystalRptViewer";
            this.crystalRptViewer.Size = new System.Drawing.Size(1156, 694);
            this.crystalRptViewer.TabIndex = 0;
            this.crystalRptViewer.Load += new System.EventHandler(this.crystalRptViewer_Load);
            // 
            // rptFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 694);
            this.Controls.Add(this.crystalRptViewer);
            this.Name = "rptFrm";
            this.Text = "rptFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRptViewer;
    }
}