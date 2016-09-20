namespace GetLinks
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Details");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Links");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonGetLinks = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHomePage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxParentPage = new System.Windows.Forms.TextBox();
            this.contextMenuStripCopyList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radWaitingBarLoading = new Telerik.WinControls.UI.RadWaitingBar();
            this.backgroundWorkerDownloadingLinks = new System.ComponentModel.BackgroundWorker();
            this.radListViewLinks = new Telerik.WinControls.UI.RadListView();
            this.labelAlbumName = new System.Windows.Forms.Label();
            this.contextMenuStripCopyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBarLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListViewLinks)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetLinks
            // 
            this.buttonGetLinks.Location = new System.Drawing.Point(552, 33);
            this.buttonGetLinks.Name = "buttonGetLinks";
            this.buttonGetLinks.Size = new System.Drawing.Size(75, 23);
            this.buttonGetLinks.TabIndex = 1;
            this.buttonGetLinks.Text = "Get links";
            this.buttonGetLinks.UseVisualStyleBackColor = true;
            this.buttonGetLinks.Click += new System.EventHandler(this.buttonGetLinks_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start page : ";
            // 
            // comboBoxHomePage
            // 
            this.comboBoxHomePage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHomePage.FormattingEnabled = true;
            this.comboBoxHomePage.Location = new System.Drawing.Point(92, 6);
            this.comboBoxHomePage.Name = "comboBoxHomePage";
            this.comboBoxHomePage.Size = new System.Drawing.Size(336, 21);
            this.comboBoxHomePage.TabIndex = 3;
            this.comboBoxHomePage.SelectedIndexChanged += new System.EventHandler(this.comboBoxHomePage_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current page : ";
            // 
            // textBoxParentPage
            // 
            this.textBoxParentPage.Location = new System.Drawing.Point(92, 35);
            this.textBoxParentPage.Name = "textBoxParentPage";
            this.textBoxParentPage.Size = new System.Drawing.Size(457, 20);
            this.textBoxParentPage.TabIndex = 5;
            // 
            // contextMenuStripCopyList
            // 
            this.contextMenuStripCopyList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToDownloadToolStripMenuItem,
            this.massDownloadToolStripMenuItem});
            this.contextMenuStripCopyList.Name = "contextMenuStripCopyList";
            this.contextMenuStripCopyList.Size = new System.Drawing.Size(170, 48);
            this.contextMenuStripCopyList.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripCopyList_Opening);
            // 
            // copyToDownloadToolStripMenuItem
            // 
            this.copyToDownloadToolStripMenuItem.Name = "copyToDownloadToolStripMenuItem";
            this.copyToDownloadToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToDownloadToolStripMenuItem.Text = "Copy to clipboard";
            this.copyToDownloadToolStripMenuItem.Click += new System.EventHandler(this.copyToDownloadToolStripMenuItem_Click);
            // 
            // massDownloadToolStripMenuItem
            // 
            this.massDownloadToolStripMenuItem.Name = "massDownloadToolStripMenuItem";
            this.massDownloadToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.massDownloadToolStripMenuItem.Text = "Mass download";
            this.massDownloadToolStripMenuItem.Click += new System.EventHandler(this.massDownloadToolStripMenuItem_Click);
            // 
            // radWaitingBarLoading
            // 
            this.radWaitingBarLoading.Location = new System.Drawing.Point(484, 6);
            this.radWaitingBarLoading.Name = "radWaitingBarLoading";
            this.radWaitingBarLoading.Size = new System.Drawing.Size(141, 21);
            this.radWaitingBarLoading.TabIndex = 7;
            this.radWaitingBarLoading.Text = "Please wait";
            this.radWaitingBarLoading.Visible = false;
            this.radWaitingBarLoading.WaitingSpeed = 100;
            this.radWaitingBarLoading.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Throbber;
            // 
            // backgroundWorkerDownloadingLinks
            // 
            this.backgroundWorkerDownloadingLinks.WorkerReportsProgress = true;
            this.backgroundWorkerDownloadingLinks.WorkerSupportsCancellation = true;
            this.backgroundWorkerDownloadingLinks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDownloadingLinks_DoWork);
            this.backgroundWorkerDownloadingLinks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDownloadingLinks_RunWorkerCompleted);
            // 
            // radListViewLinks
            // 
            this.radListViewLinks.AllowEdit = false;
            this.radListViewLinks.AllowRemove = false;
            listViewDetailColumn1.HeaderText = "Details";
            listViewDetailColumn2.HeaderText = "Links";
            listViewDetailColumn2.Width = 390F;
            this.radListViewLinks.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2});
            this.radListViewLinks.ContextMenuStrip = this.contextMenuStripCopyList;
            this.radListViewLinks.DisplayMember = "Text";
            this.radListViewLinks.EnableKineticScrolling = true;
            this.radListViewLinks.ItemSpacing = -1;
            this.radListViewLinks.Location = new System.Drawing.Point(12, 65);
            this.radListViewLinks.MultiSelect = true;
            this.radListViewLinks.Name = "radListViewLinks";
            this.radListViewLinks.SelectLastAddedItem = false;
            this.radListViewLinks.Size = new System.Drawing.Size(615, 407);
            this.radListViewLinks.TabIndex = 8;
            this.radListViewLinks.Text = "radListView1";
            this.radListViewLinks.ValueMember = "Value";
            this.radListViewLinks.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.radListViewLinks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radListViewLinks_KeyUp);
            this.radListViewLinks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.radListViewLinks_MouseDoubleClick);
            // 
            // labelAlbumName
            // 
            this.labelAlbumName.AutoSize = true;
            this.labelAlbumName.Location = new System.Drawing.Point(434, 9);
            this.labelAlbumName.Name = "labelAlbumName";
            this.labelAlbumName.Size = new System.Drawing.Size(0, 13);
            this.labelAlbumName.TabIndex = 9;
            this.labelAlbumName.Tag = "=> {0}";
            this.labelAlbumName.Click += new System.EventHandler(this.labelAlbumName_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonGetLinks;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 480);
            this.Controls.Add(this.labelAlbumName);
            this.Controls.Add(this.radWaitingBarLoading);
            this.Controls.Add(this.radListViewLinks);
            this.Controls.Add(this.textBoxParentPage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxHomePage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGetLinks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get Links from URL";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStripCopyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBarLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListViewLinks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetLinks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxHomePage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxParentPage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCopyList;
        private System.Windows.Forms.ToolStripMenuItem copyToDownloadToolStripMenuItem;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBarLoading;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDownloadingLinks;
        private System.Windows.Forms.ToolStripMenuItem massDownloadToolStripMenuItem;
        private Telerik.WinControls.UI.RadListView radListViewLinks;
        private System.Windows.Forms.Label labelAlbumName;
    }
}

