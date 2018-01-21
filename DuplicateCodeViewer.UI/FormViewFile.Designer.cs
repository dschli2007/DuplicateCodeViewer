namespace DuplicateCodeViewer.UI
{
    partial class FormViewFile
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
            this.MnuForm = new System.Windows.Forms.MenuStrip();
            this.MnuPrior = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.GridFile = new System.Windows.Forms.DataGridView();
            this.MnuForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFile)).BeginInit();
            this.SuspendLayout();
            // 
            // MnuForm
            // 
            this.MnuForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuPrior,
            this.MnuNext,
            this.MnuClose});
            this.MnuForm.Location = new System.Drawing.Point(0, 0);
            this.MnuForm.Name = "MnuForm";
            this.MnuForm.Size = new System.Drawing.Size(679, 24);
            this.MnuForm.TabIndex = 0;
            this.MnuForm.Text = "menuStrip1";
            // 
            // MnuPrior
            // 
            this.MnuPrior.Name = "MnuPrior";
            this.MnuPrior.Size = new System.Drawing.Size(44, 20);
            this.MnuPrior.Text = "Prior";
            // 
            // MnuNext
            // 
            this.MnuNext.Name = "MnuNext";
            this.MnuNext.Size = new System.Drawing.Size(43, 20);
            this.MnuNext.Text = "Next";
            // 
            // MnuClose
            // 
            this.MnuClose.Name = "MnuClose";
            this.MnuClose.Size = new System.Drawing.Size(48, 20);
            this.MnuClose.Text = "Close";
            this.MnuClose.Click += new System.EventHandler(this.MnuClose_Click);
            // 
            // GridFile
            // 
            this.GridFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFile.Location = new System.Drawing.Point(0, 27);
            this.GridFile.Name = "GridFile";
            this.GridFile.Size = new System.Drawing.Size(325, 374);
            this.GridFile.TabIndex = 1;
            this.GridFile.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GridFile_CellPainting);
            // 
            // FormViewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 528);
            this.Controls.Add(this.GridFile);
            this.Controls.Add(this.MnuForm);
            this.MainMenuStrip = this.MnuForm;
            this.Name = "FormViewFile";
            this.Text = "FormViewFile";
            this.Load += new System.EventHandler(this.FormViewFile_Load);
            this.MnuForm.ResumeLayout(false);
            this.MnuForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MnuForm;
        private System.Windows.Forms.ToolStripMenuItem MnuPrior;
        private System.Windows.Forms.ToolStripMenuItem MnuNext;
        private System.Windows.Forms.ToolStripMenuItem MnuClose;
        private System.Windows.Forms.DataGridView GridFile;
    }
}