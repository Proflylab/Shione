namespace Shione
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.listDetails = new System.Windows.Forms.ListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFansub = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAnime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMAL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsInformation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tafasuTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMAL = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTafasu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFilterID = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFilterFansub = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsIDM = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsWithIDM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolBtnGO = new System.Windows.Forms.ToolStripButton();
            this.dbtnSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.cmsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsIDMPath = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsClearCache = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdGotoPage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInformation.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // listDetails
            // 
            this.listDetails.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnFansub,
            this.columnAnime,
            this.columnLink,
            this.columnMAL,
            this.columnFB});
            this.listDetails.ContextMenuStrip = this.cmsInformation;
            this.listDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDetails.FullRowSelect = true;
            this.listDetails.HoverSelection = true;
            this.listDetails.Location = new System.Drawing.Point(0, 25);
            this.listDetails.Name = "listDetails";
            this.listDetails.Size = new System.Drawing.Size(832, 416);
            this.listDetails.TabIndex = 3;
            this.listDetails.UseCompatibleStateImageBehavior = false;
            this.listDetails.View = System.Windows.Forms.View.Details;
            this.listDetails.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listDetails_ColumnClick);
            this.listDetails.DoubleClick += new System.EventHandler(this.listDetails_DoubleClick);
            this.listDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listDetails_KeyPress);
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            this.columnID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnID.Width = 0;
            // 
            // columnFansub
            // 
            this.columnFansub.Text = "Fansub";
            this.columnFansub.Width = 100;
            // 
            // columnAnime
            // 
            this.columnAnime.Text = "Anime";
            this.columnAnime.Width = 600;
            // 
            // columnLink
            // 
            this.columnLink.Text = "Link";
            this.columnLink.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLink.Width = 0;
            // 
            // columnMAL
            // 
            this.columnMAL.Text = "MAL";
            this.columnMAL.Width = 0;
            // 
            // columnFB
            // 
            this.columnFB.Text = "Facebook";
            this.columnFB.Width = 0;
            // 
            // cmsInformation
            // 
            this.cmsInformation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsInfo,
            this.cmsTafasu,
            this.toolStripSeparator1,
            this.cmsFilter,
            this.toolStripSeparator2,
            this.cmsIDM,
            this.cmsWithIDM});
            this.cmsInformation.Name = "cmsInformation";
            this.cmsInformation.ShowImageMargin = false;
            this.cmsInformation.Size = new System.Drawing.Size(244, 126);
            this.cmsInformation.Opening += new System.ComponentModel.CancelEventHandler(this.cmsInformation_Opening);
            // 
            // cmsInfo
            // 
            this.cmsInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tafasuTopicToolStripMenuItem,
            this.cmsMAL,
            this.cmsFacebook});
            this.cmsInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsInfo.Name = "cmsInfo";
            this.cmsInfo.Size = new System.Drawing.Size(243, 22);
            this.cmsInfo.Text = "Information";
            // 
            // tafasuTopicToolStripMenuItem
            // 
            this.tafasuTopicToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tafasuTopicToolStripMenuItem.Name = "tafasuTopicToolStripMenuItem";
            this.tafasuTopicToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tafasuTopicToolStripMenuItem.Text = "Tafasu Topic";
            this.tafasuTopicToolStripMenuItem.Click += new System.EventHandler(this.tafasuTopicToolStripMenuItem_Click);
            // 
            // cmsMAL
            // 
            this.cmsMAL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsMAL.Name = "cmsMAL";
            this.cmsMAL.Size = new System.Drawing.Size(160, 22);
            this.cmsMAL.Text = "MyAnimeList";
            this.cmsMAL.Click += new System.EventHandler(this.cmsMAL_Click);
            // 
            // cmsFacebook
            // 
            this.cmsFacebook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsFacebook.Name = "cmsFacebook";
            this.cmsFacebook.Size = new System.Drawing.Size(160, 22);
            this.cmsFacebook.Text = "Fanpage Fansub";
            this.cmsFacebook.Click += new System.EventHandler(this.cmsFacebook_Click);
            // 
            // cmsTafasu
            // 
            this.cmsTafasu.Name = "cmsTafasu";
            this.cmsTafasu.Size = new System.Drawing.Size(243, 22);
            this.cmsTafasu.Text = "Go to link tafasu.com";
            this.cmsTafasu.Click += new System.EventHandler(this.cmsTafasu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(240, 6);
            // 
            // cmsFilter
            // 
            this.cmsFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFilterID,
            this.cmsFilterFansub});
            this.cmsFilter.Name = "cmsFilter";
            this.cmsFilter.Size = new System.Drawing.Size(243, 22);
            this.cmsFilter.Text = "Filter this anime by ...";
            // 
            // cmsFilterID
            // 
            this.cmsFilterID.Name = "cmsFilterID";
            this.cmsFilterID.Size = new System.Drawing.Size(112, 22);
            this.cmsFilterID.Text = "ID";
            this.cmsFilterID.Click += new System.EventHandler(this.cmsFilterID_Click);
            // 
            // cmsFilterFansub
            // 
            this.cmsFilterFansub.Name = "cmsFilterFansub";
            this.cmsFilterFansub.Size = new System.Drawing.Size(112, 22);
            this.cmsFilterFansub.Text = "Fansub";
            this.cmsFilterFansub.Click += new System.EventHandler(this.cmsFilterFansub_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(240, 6);
            // 
            // cmsIDM
            // 
            this.cmsIDM.Name = "cmsIDM";
            this.cmsIDM.Size = new System.Drawing.Size(243, 22);
            this.cmsIDM.Text = "Download to IDM";
            this.cmsIDM.Click += new System.EventHandler(this.cmsIDM_Click);
            // 
            // cmsWithIDM
            // 
            this.cmsWithIDM.Name = "cmsWithIDM";
            this.cmsWithIDM.Size = new System.Drawing.Size(243, 22);
            this.cmsWithIDM.Text = "Download Queue (0 selected) to IDM";
            this.cmsWithIDM.Click += new System.EventHandler(this.cmsWithIDM_Click);
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.toolBtnGO,
            this.dbtnSettings});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(832, 25);
            this.toolBar.TabIndex = 2;
            this.toolBar.Text = "toolStrip1";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 25);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // toolBtnGO
            // 
            this.toolBtnGO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnGO.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnGO.Image")));
            this.toolBtnGO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnGO.Name = "toolBtnGO";
            this.toolBtnGO.Size = new System.Drawing.Size(23, 22);
            this.toolBtnGO.Text = "Search";
            this.toolBtnGO.Click += new System.EventHandler(this.toolBtnGO_Click);
            // 
            // dbtnSettings
            // 
            this.dbtnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dbtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dbtnSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSettings,
            this.cmdGotoPage,
            this.toolStripSeparator3,
            this.aboutToolStripMenuItem});
            this.dbtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("dbtnSettings.Image")));
            this.dbtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dbtnSettings.Name = "dbtnSettings";
            this.dbtnSettings.Size = new System.Drawing.Size(29, 22);
            this.dbtnSettings.ToolTipText = "Settings";
            // 
            // cmsSettings
            // 
            this.cmsSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsIDMPath,
            this.cmsClearCache});
            this.cmsSettings.Name = "cmsSettings";
            this.cmsSettings.Size = new System.Drawing.Size(182, 22);
            this.cmsSettings.Text = "Settings";
            // 
            // cmsIDMPath
            // 
            this.cmsIDMPath.Name = "cmsIDMPath";
            this.cmsIDMPath.Size = new System.Drawing.Size(134, 22);
            this.cmsIDMPath.Text = "IDM";
            // 
            // cmsClearCache
            // 
            this.cmsClearCache.Name = "cmsClearCache";
            this.cmsClearCache.Size = new System.Drawing.Size(134, 22);
            this.cmsClearCache.Text = "ClearCache";
            this.cmsClearCache.Click += new System.EventHandler(this.cmsClearCache_Click);
            // 
            // cmdGotoPage
            // 
            this.cmdGotoPage.Name = "cmdGotoPage";
            this.cmdGotoPage.Size = new System.Drawing.Size(182, 22);
            this.cmdGotoPage.Text = "Go to the web pages";
            this.cmdGotoPage.Click += new System.EventHandler(this.cmdGotoPage_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 441);
            this.Controls.Add(this.listDetails);
            this.Controls.Add(this.toolBar);
            this.MinimumSize = new System.Drawing.Size(848, 480);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shione - TAFASU Fansub Community";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.cmsInformation.ResumeLayout(false);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listDetails;
        private System.Windows.Forms.ColumnHeader columnMAL;
        private System.Windows.Forms.ColumnHeader columnFansub;
        private System.Windows.Forms.ColumnHeader columnAnime;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnLink;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton toolBtnGO;
        private System.Windows.Forms.ContextMenuStrip cmsInformation;
        private System.Windows.Forms.ToolStripMenuItem cmsWithIDM;
        private System.Windows.Forms.ToolStripMenuItem cmsInfo;
        private System.Windows.Forms.ToolStripMenuItem cmsTafasu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsIDM;
        private System.Windows.Forms.ToolStripMenuItem cmsFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsFilterID;
        private System.Windows.Forms.ToolStripMenuItem cmsFilterFansub;
        private System.Windows.Forms.ToolStripMenuItem cmsMAL;
        private System.Windows.Forms.ToolStripMenuItem tafasuTopicToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnFB;
        private System.Windows.Forms.ToolStripMenuItem cmsFacebook;
        private System.Windows.Forms.ToolStripDropDownButton dbtnSettings;
        private System.Windows.Forms.ToolStripMenuItem cmsSettings;
        private System.Windows.Forms.ToolStripMenuItem cmdGotoPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsIDMPath;
        private System.Windows.Forms.ToolStripMenuItem cmsClearCache;
    }
}

