
namespace DownloadFromTFS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageConnectToTfs = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbTestSuites = new System.Windows.Forms.ComboBox();
            this.cbTeamProjects = new System.Windows.Forms.ComboBox();
            this.cbTestSubSuites = new System.Windows.Forms.ComboBox();
            this.cbTestPlans = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btDownloadResults = new System.Windows.Forms.Button();
            this.btDownload = new System.Windows.Forms.Button();
            this.btUpload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btConnectTFS = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.invertSelection = new System.Windows.Forms.Button();
            this.checkAll = new System.Windows.Forms.Button();
            this.uncheckAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageConnectToTfs.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1134, 642);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageConnectToTfs);
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(9, 14);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1108, 651);
            this.tabControl.TabIndex = 9;
            // 
            // tabPageConnectToTfs
            // 
            this.tabPageConnectToTfs.BackColor = System.Drawing.Color.MintCream;
            this.tabPageConnectToTfs.Controls.Add(this.invertSelection);
            this.tabPageConnectToTfs.Controls.Add(this.uncheckAll);
            this.tabPageConnectToTfs.Controls.Add(this.listView1);
            this.tabPageConnectToTfs.Controls.Add(this.checkAll);
            this.tabPageConnectToTfs.Controls.Add(this.panel4);
            this.tabPageConnectToTfs.Controls.Add(this.panel2);
            this.tabPageConnectToTfs.Controls.Add(this.panel1);
            this.tabPageConnectToTfs.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageConnectToTfs.Location = new System.Drawing.Point(4, 33);
            this.tabPageConnectToTfs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageConnectToTfs.Name = "tabPageConnectToTfs";
            this.tabPageConnectToTfs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageConnectToTfs.Size = new System.Drawing.Size(1100, 614);
            this.tabPageConnectToTfs.TabIndex = 0;
            this.tabPageConnectToTfs.Text = "Connect to TFS";
            this.tabPageConnectToTfs.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 242);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(1070, 289);
            this.listView1.TabIndex = 11;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "WorkItem#";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Title";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 159;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Run Status and Date";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 159;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Test case type";
            this.columnHeader5.Width = 100;
            // 
            // panel4
            // 
            this.panel4.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.panel4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cbTestSuites);
            this.panel4.Controls.Add(this.cbTeamProjects);
            this.panel4.Controls.Add(this.cbTestSubSuites);
            this.panel4.Controls.Add(this.cbTestPlans);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(12, 118);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1070, 113);
            this.panel4.TabIndex = 18;
            // 
            // cbTestSuites
            // 
            this.cbTestSuites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTestSuites.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTestSuites.FormattingEnabled = true;
            this.cbTestSuites.Location = new System.Drawing.Point(682, 14);
            this.cbTestSuites.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTestSuites.Name = "cbTestSuites";
            this.cbTestSuites.Size = new System.Drawing.Size(346, 32);
            this.cbTestSuites.TabIndex = 3;
            this.cbTestSuites.SelectedValueChanged += new System.EventHandler(this.cbTestSuites_SelectedValueChanged);
            // 
            // cbTeamProjects
            // 
            this.cbTeamProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeamProjects.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTeamProjects.FormattingEnabled = true;
            this.cbTeamProjects.Location = new System.Drawing.Point(174, 15);
            this.cbTeamProjects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTeamProjects.Name = "cbTeamProjects";
            this.cbTeamProjects.Size = new System.Drawing.Size(330, 32);
            this.cbTeamProjects.TabIndex = 1;
            this.cbTeamProjects.SelectedValueChanged += new System.EventHandler(this.cbTeamProjects_SelectedValueChanged);
            // 
            // cbTestSubSuites
            // 
            this.cbTestSubSuites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTestSubSuites.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTestSubSuites.FormattingEnabled = true;
            this.cbTestSubSuites.Location = new System.Drawing.Point(682, 62);
            this.cbTestSubSuites.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTestSubSuites.Name = "cbTestSubSuites";
            this.cbTestSubSuites.Size = new System.Drawing.Size(346, 32);
            this.cbTestSubSuites.TabIndex = 4;
            this.cbTestSubSuites.SelectedValueChanged += new System.EventHandler(this.cbTestSubSuites_SelectedValueChanged);
            // 
            // cbTestPlans
            // 
            this.cbTestPlans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTestPlans.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTestPlans.FormattingEnabled = true;
            this.cbTestPlans.Location = new System.Drawing.Point(174, 60);
            this.cbTestPlans.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTestPlans.Name = "cbTestPlans";
            this.cbTestPlans.Size = new System.Drawing.Size(330, 32);
            this.cbTestPlans.TabIndex = 2;
            this.cbTestPlans.SelectedIndexChanged += new System.EventHandler(this.cbTestPlans_SelectedIndexChanged);
            this.cbTestPlans.SelectedValueChanged += new System.EventHandler(this.cbTestPlans_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(32, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Test Plans";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(540, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sub-Suites";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(540, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Test Suites";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Team Projects";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btDownloadResults);
            this.panel2.Controls.Add(this.btDownload);
            this.panel2.Controls.Add(this.btUpload);
            this.panel2.Location = new System.Drawing.Point(153, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 93);
            this.panel2.TabIndex = 17;
            // 
            // btDownloadResults
            // 
            this.btDownloadResults.BackColor = System.Drawing.Color.White;
            this.btDownloadResults.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDownloadResults.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDownloadResults.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btDownloadResults.Location = new System.Drawing.Point(302, 8);
            this.btDownloadResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btDownloadResults.Name = "btDownloadResults";
            this.btDownloadResults.Size = new System.Drawing.Size(134, 72);
            this.btDownloadResults.TabIndex = 14;
            this.btDownloadResults.Text = "Download Test Results";
            this.btDownloadResults.UseVisualStyleBackColor = false;
            this.btDownloadResults.Click += new System.EventHandler(this.btDownloadResults_Click);
            // 
            // btDownload
            // 
            this.btDownload.BackColor = System.Drawing.Color.White;
            this.btDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btDownload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDownload.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDownload.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btDownload.Location = new System.Drawing.Point(6, 8);
            this.btDownload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(138, 72);
            this.btDownload.TabIndex = 0;
            this.btDownload.Text = "Download attachments from Test steps";
            this.btDownload.UseVisualStyleBackColor = false;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // btUpload
            // 
            this.btUpload.BackColor = System.Drawing.Color.White;
            this.btUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btUpload.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpload.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btUpload.Location = new System.Drawing.Point(150, 8);
            this.btUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(144, 72);
            this.btUpload.TabIndex = 12;
            this.btUpload.Text = "Upload attachments to Test steps";
            this.btUpload.UseVisualStyleBackColor = false;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btConnectTFS);
            this.panel1.Location = new System.Drawing.Point(12, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 93);
            this.panel1.TabIndex = 16;
            // 
            // btConnectTFS
            // 
            this.btConnectTFS.BackColor = System.Drawing.Color.White;
            this.btConnectTFS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btConnectTFS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btConnectTFS.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConnectTFS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btConnectTFS.Location = new System.Drawing.Point(10, 8);
            this.btConnectTFS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btConnectTFS.Name = "btConnectTFS";
            this.btConnectTFS.Size = new System.Drawing.Size(104, 72);
            this.btConnectTFS.TabIndex = 1;
            this.btConnectTFS.Text = "Conntect to TFS";
            this.btConnectTFS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btConnectTFS.UseVisualStyleBackColor = false;
            this.btConnectTFS.Click += new System.EventHandler(this.btConnectTFS_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "C:\\";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // invertSelection
            // 
            this.invertSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invertSelection.Image = ((System.Drawing.Image)(resources.GetObject("invertSelection.Image")));
            this.invertSelection.Location = new System.Drawing.Point(89, 541);
            this.invertSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.invertSelection.Name = "invertSelection";
            this.invertSelection.Size = new System.Drawing.Size(34, 40);
            this.invertSelection.TabIndex = 2;
            this.invertSelection.UseVisualStyleBackColor = true;
            this.invertSelection.Click += new System.EventHandler(this.invertSelection_Click);
            this.invertSelection.MouseHover += new System.EventHandler(this.invertSelection_MouseHover);
            // 
            // checkAll
            // 
            this.checkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAll.Image = ((System.Drawing.Image)(resources.GetObject("checkAll.Image")));
            this.checkAll.Location = new System.Drawing.Point(12, 541);
            this.checkAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(34, 40);
            this.checkAll.TabIndex = 0;
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.Click += new System.EventHandler(this.checkAll_Click);
            this.checkAll.MouseHover += new System.EventHandler(this.checkAll_MouseHover);
            // 
            // uncheckAll
            // 
            this.uncheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uncheckAll.Image = ((System.Drawing.Image)(resources.GetObject("uncheckAll.Image")));
            this.uncheckAll.Location = new System.Drawing.Point(49, 541);
            this.uncheckAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uncheckAll.Name = "uncheckAll";
            this.uncheckAll.Size = new System.Drawing.Size(34, 40);
            this.uncheckAll.TabIndex = 1;
            this.uncheckAll.UseVisualStyleBackColor = true;
            this.uncheckAll.Click += new System.EventHandler(this.uncheckAll_Click);
            this.uncheckAll.MouseHover += new System.EventHandler(this.uncheckAll_MouseHover);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1134, 642);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TFS-DownloadAndExecute";
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageConnectToTfs.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }



        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTestPlans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btUpload;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cbTeamProjects;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btConnectTFS;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbTestSuites;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTestSubSuites;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btDownloadResults;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageConnectToTfs;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button invertSelection;
        private System.Windows.Forms.Button uncheckAll;
        private System.Windows.Forms.Button checkAll;
    }
}

