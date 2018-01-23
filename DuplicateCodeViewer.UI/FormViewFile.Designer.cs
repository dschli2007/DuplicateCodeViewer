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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MnuForm = new System.Windows.Forms.MenuStrip();
            this.MnuPrior = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.GridFile = new System.Windows.Forms.DataGridView();
            this.CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GridDuplicateFiles = new System.Windows.Forms.DataGridView();
            this.FILENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridDuplicateFileContent = new System.Windows.Forms.DataGridView();
            this.DUPLICATECONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MnuForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDuplicateFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDuplicateFileContent)).BeginInit();
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
            this.MnuForm.Size = new System.Drawing.Size(1112, 24);
            this.MnuForm.TabIndex = 0;
            this.MnuForm.Text = "menuStrip1";
            // 
            // MnuPrior
            // 
            this.MnuPrior.Name = "MnuPrior";
            this.MnuPrior.Size = new System.Drawing.Size(44, 20);
            this.MnuPrior.Text = "Prior";
            this.MnuPrior.Click += new System.EventHandler(this.MnuPrior_Click);
            // 
            // MnuNext
            // 
            this.MnuNext.Name = "MnuNext";
            this.MnuNext.Size = new System.Drawing.Size(43, 20);
            this.MnuNext.Text = "Next";
            this.MnuNext.Click += new System.EventHandler(this.MnuNext_Click);
            // 
            // MnuClose
            // 
            this.MnuClose.Name = "MnuClose";
            this.MnuClose.Size = new System.Drawing.Size(48, 20);
            this.MnuClose.Text = "Close";
            this.MnuClose.Click += new System.EventHandler(this.MnuClose_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GridFile);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1112, 659);
            this.splitContainer2.SplitterDistance = 517;
            this.splitContainer2.TabIndex = 4;
            // 
            // GridFile
            // 
            this.GridFile.AllowUserToAddRows = false;
            this.GridFile.AllowUserToDeleteRows = false;
            this.GridFile.AllowUserToResizeRows = false;
            this.GridFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridFile.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridFile.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CONTENT});
            this.GridFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridFile.Location = new System.Drawing.Point(0, 0);
            this.GridFile.Name = "GridFile";
            this.GridFile.ReadOnly = true;
            this.GridFile.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridFile.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.GridFile.RowHeadersWidth = 60;
            this.GridFile.Size = new System.Drawing.Size(517, 659);
            this.GridFile.TabIndex = 2;
            this.GridFile.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridFile_DataBindingComplete);
            this.GridFile.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridFile_RowEnter);
            // 
            // CONTENT
            // 
            this.CONTENT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CONTENT.DataPropertyName = "Content";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONTENT.DefaultCellStyle = dataGridViewCellStyle9;
            this.CONTENT.HeaderText = "Content";
            this.CONTENT.MinimumWidth = 100;
            this.CONTENT.Name = "CONTENT";
            this.CONTENT.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GridDuplicateFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GridDuplicateFileContent);
            this.splitContainer1.Size = new System.Drawing.Size(591, 659);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 4;
            // 
            // GridDuplicateFiles
            // 
            this.GridDuplicateFiles.AllowUserToAddRows = false;
            this.GridDuplicateFiles.AllowUserToDeleteRows = false;
            this.GridDuplicateFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridDuplicateFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridDuplicateFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GridDuplicateFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDuplicateFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FILENAME});
            this.GridDuplicateFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDuplicateFiles.Location = new System.Drawing.Point(0, 0);
            this.GridDuplicateFiles.Name = "GridDuplicateFiles";
            this.GridDuplicateFiles.ReadOnly = true;
            this.GridDuplicateFiles.RowHeadersVisible = false;
            this.GridDuplicateFiles.Size = new System.Drawing.Size(591, 303);
            this.GridDuplicateFiles.TabIndex = 0;
            this.GridDuplicateFiles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDuplicateFiles_RowEnter);
            this.GridDuplicateFiles.SelectionChanged += new System.EventHandler(this.GridDuplicateFiles_SelectionChanged);
            // 
            // FILENAME
            // 
            this.FILENAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FILENAME.DataPropertyName = "Filename";
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FILENAME.DefaultCellStyle = dataGridViewCellStyle12;
            this.FILENAME.HeaderText = "Duplicate filenames";
            this.FILENAME.Name = "FILENAME";
            this.FILENAME.ReadOnly = true;
            this.FILENAME.Width = 114;
            // 
            // GridDuplicateFileContent
            // 
            this.GridDuplicateFileContent.AllowUserToAddRows = false;
            this.GridDuplicateFileContent.AllowUserToDeleteRows = false;
            this.GridDuplicateFileContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridDuplicateFileContent.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridDuplicateFileContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridDuplicateFileContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDuplicateFileContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DUPLICATECONTENT});
            this.GridDuplicateFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDuplicateFileContent.Location = new System.Drawing.Point(0, 0);
            this.GridDuplicateFileContent.Name = "GridDuplicateFileContent";
            this.GridDuplicateFileContent.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDuplicateFileContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.GridDuplicateFileContent.RowHeadersWidth = 60;
            this.GridDuplicateFileContent.Size = new System.Drawing.Size(591, 352);
            this.GridDuplicateFileContent.TabIndex = 0;
            this.GridDuplicateFileContent.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridDuplicateFileContent_DataBindingComplete);
            // 
            // DUPLICATECONTENT
            // 
            this.DUPLICATECONTENT.DataPropertyName = "Content";
            this.DUPLICATECONTENT.HeaderText = "Content";
            this.DUPLICATECONTENT.Name = "DUPLICATECONTENT";
            this.DUPLICATECONTENT.ReadOnly = true;
            this.DUPLICATECONTENT.Width = 69;
            // 
            // FormViewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 683);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.MnuForm);
            this.MainMenuStrip = this.MnuForm;
            this.Name = "FormViewFile";
            this.Text = "FormViewFile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MnuForm.ResumeLayout(false);
            this.MnuForm.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridFile)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDuplicateFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDuplicateFileContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MnuForm;
        private System.Windows.Forms.ToolStripMenuItem MnuPrior;
        private System.Windows.Forms.ToolStripMenuItem MnuNext;
        private System.Windows.Forms.ToolStripMenuItem MnuClose;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView GridFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTENT;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView GridDuplicateFiles;
        private System.Windows.Forms.DataGridView GridDuplicateFileContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUPLICATECONTENT;
    }
}