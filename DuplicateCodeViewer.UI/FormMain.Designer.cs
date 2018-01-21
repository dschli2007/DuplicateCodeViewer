namespace DuplicateCodeViewer.UI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuOpenXmlFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSelectDupFinderExe = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSelectDupFinderExe});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
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
            // MnuSelectDupFinderExe
            // 
            this.MnuSelectDupFinderExe.Name = "MnuSelectDupFinderExe";
            this.MnuSelectDupFinderExe.Size = new System.Drawing.Size(192, 22);
            this.MnuSelectDupFinderExe.Text = "Select DupFinder.exe...";
            this.MnuSelectDupFinderExe.Click += new System.EventHandler(this.MnuSelectDupFinderExe_Click);
            // 
            // MnuAbout
            // 
            this.MnuAbout.Name = "MnuAbout";
            this.MnuAbout.Size = new System.Drawing.Size(223, 22);
            this.MnuAbout.Text = "About DuplicateCodeViewer";
            this.MnuAbout.Click += new System.EventHandler(this.MnuAbout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 331);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "DuplicateCodeViewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuOpenProject;
        private System.Windows.Forms.ToolStripMenuItem MnuOpenXmlFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuQuit;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuSelectDupFinderExe;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuAbout;
    }
}

