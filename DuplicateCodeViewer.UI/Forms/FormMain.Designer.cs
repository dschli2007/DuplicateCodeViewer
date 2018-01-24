namespace DuplicateCodeViewer.UI.Forms
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuOpenXmlFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSelectDupFinderExe = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.GridFiles = new System.Windows.Forms.DataGridView();
            this.FILENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FRAGMENTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(940, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuOpenProject,
            this.MnuOpenXmlFile,
            this.toolStripSeparator1,
            this.MnuQuit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MnuOpenProject
            // 
            this.MnuOpenProject.Name = "MnuOpenProject";
            this.MnuOpenProject.Size = new System.Drawing.Size(272, 22);
            this.MnuOpenProject.Text = "Open Visual Studio Project/Solution...";
            this.MnuOpenProject.Click += new System.EventHandler(this.MnuOpenProject_Click);
            // 
            // MnuOpenXmlFile
            // 
            this.MnuOpenXmlFile.Name = "MnuOpenXmlFile";
            this.MnuOpenXmlFile.Size = new System.Drawing.Size(272, 22);
            this.MnuOpenXmlFile.Text = "Open Xml file...";
            this.MnuOpenXmlFile.Click += new System.EventHandler(this.MnuOpenXmlFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(269, 6);
            // 
            // MnuQuit
            // 
            this.MnuQuit.Name = "MnuQuit";
            this.MnuQuit.Size = new System.Drawing.Size(272, 22);
            this.MnuQuit.Text = "Quit";
            this.MnuQuit.Click += new System.EventHandler(this.MnuQuit_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSelectDupFinderExe});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // MnuSelectDupFinderExe
            // 
            this.MnuSelectDupFinderExe.Name = "MnuSelectDupFinderExe";
            this.MnuSelectDupFinderExe.Size = new System.Drawing.Size(192, 22);
            this.MnuSelectDupFinderExe.Text = "Select DupFinder.exe...";
            this.MnuSelectDupFinderExe.Click += new System.EventHandler(this.MnuSelectDupFinderExe_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MnuAbout
            // 
            this.MnuAbout.Name = "MnuAbout";
            this.MnuAbout.Size = new System.Drawing.Size(223, 22);
            this.MnuAbout.Text = "About DuplicateCodeViewer";
            this.MnuAbout.Click += new System.EventHandler(this.MnuAbout_Click);
            // 
            // GridFiles
            // 
            this.GridFiles.AllowUserToAddRows = false;
            this.GridFiles.AllowUserToDeleteRows = false;
            this.GridFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FILENAME,
            this.FRAGMENTS,
            this.COST});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridFiles.Location = new System.Drawing.Point(0, 24);
            this.GridFiles.MultiSelect = false;
            this.GridFiles.Name = "GridFiles";
            this.GridFiles.ReadOnly = true;
            this.GridFiles.RowHeadersVisible = false;
            this.GridFiles.Size = new System.Drawing.Size(940, 474);
            this.GridFiles.TabIndex = 1;
            this.GridFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridFiles_CellDoubleClick);
            // 
            // FILENAME
            // 
            this.FILENAME.DataPropertyName = "SourceFile";
            this.FILENAME.HeaderText = "Filename";
            this.FILENAME.MinimumWidth = 200;
            this.FILENAME.Name = "FILENAME";
            this.FILENAME.ReadOnly = true;
            this.FILENAME.Width = 200;
            // 
            // FRAGMENTS
            // 
            this.FRAGMENTS.DataPropertyName = "LazyFragments";
            this.FRAGMENTS.HeaderText = "Fragments";
            this.FRAGMENTS.Name = "FRAGMENTS";
            this.FRAGMENTS.ReadOnly = true;
            this.FRAGMENTS.Width = 95;
            // 
            // COST
            // 
            this.COST.DataPropertyName = "LazyCost";
            this.COST.HeaderText = "Cost";
            this.COST.Name = "COST";
            this.COST.ReadOnly = true;
            this.COST.Width = 60;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 498);
            this.Controls.Add(this.GridFiles);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DuplicateCodeViewer";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuOpenProject;
        private System.Windows.Forms.ToolStripMenuItem MnuOpenXmlFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuQuit;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuSelectDupFinderExe;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuAbout;
        private System.Windows.Forms.DataGridView GridFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FRAGMENTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COST;
    }
}

