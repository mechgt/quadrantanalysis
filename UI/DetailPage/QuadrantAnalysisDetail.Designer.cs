namespace QuadrantAnalysis.UI.DetailPage
{
    partial class QuadrantAnalysisDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuadrantAnalysisDetail));
            this.ChartBanner = new ZoneFiveSoftware.Common.Visuals.ActionBanner();
            this.MaximizeButton = new ZoneFiveSoftware.Common.Visuals.Button();
            this.ButtonPanel = new ZoneFiveSoftware.Common.Visuals.Panel();
            this.ZoomInButton = new ZoneFiveSoftware.Common.Visuals.Button();
            this.ZoomOutButton = new ZoneFiveSoftware.Common.Visuals.Button();
            this.ZoomChartButton = new ZoneFiveSoftware.Common.Visuals.Button();
            this.btnPower = new ZoneFiveSoftware.Common.Visuals.Button();
            this.btnHelp = new ZoneFiveSoftware.Common.Visuals.Button();
            this.SaveImageButton = new ZoneFiveSoftware.Common.Visuals.Button();
            this.panelMain = new ZoneFiveSoftware.Common.Visuals.Panel();
            this.panelConfig = new ZoneFiveSoftware.Common.Visuals.Panel();
            this.txtCrank = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.txtCadence = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.txtPwrBands = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.txtPower = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.lblCredit = new System.Windows.Forms.Label();
            this.lblCrankLength = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.lblCadence = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.treeActivities = new ZoneFiveSoftware.Common.Visuals.TreeList();
            this.menuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelActivity = new ZoneFiveSoftware.Common.Visuals.Panel();
            this.chartMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cadenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedalVelocityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.picQ2 = new System.Windows.Forms.PictureBox();
            this.lblQ2 = new System.Windows.Forms.Label();
            this.picQ3 = new System.Windows.Forms.PictureBox();
            this.lblQ3 = new System.Windows.Forms.Label();
            this.picQ4 = new System.Windows.Forms.PictureBox();
            this.lblQ4 = new System.Windows.Forms.Label();
            this.picQ1 = new System.Windows.Forms.PictureBox();
            this.lblQ1 = new System.Windows.Forms.Label();
            this.zedChart = new ZoneFiveSoftware.Common.Visuals.Chart.ZedGraphControl();
            this.ChartBanner.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelConfig.SuspendLayout();
            this.menuTree.SuspendLayout();
            this.panelActivity.SuspendLayout();
            this.chartMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQ2)).BeginInit();
            this.picQ2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQ3)).BeginInit();
            this.picQ3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQ4)).BeginInit();
            this.picQ4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQ1)).BeginInit();
            this.picQ1.SuspendLayout();
            this.zedChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChartBanner
            // 
            this.ChartBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChartBanner.BackColor = System.Drawing.Color.Transparent;
            this.ChartBanner.Controls.Add(this.MaximizeButton);
            this.ChartBanner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChartBanner.HasMenuButton = true;
            this.ChartBanner.Location = new System.Drawing.Point(0, 0);
            this.ChartBanner.Name = "ChartBanner";
            this.ChartBanner.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChartBanner.Size = new System.Drawing.Size(400, 24);
            this.ChartBanner.Style = ZoneFiveSoftware.Common.Visuals.ActionBanner.BannerStyle.Header2;
            this.ChartBanner.TabIndex = 7;
            this.ChartBanner.Text = "Detail Pane Chart";
            this.ChartBanner.UseStyleFont = true;
            this.ChartBanner.MenuClicked += new System.EventHandler(this.ChartBanner_MenuClicked);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeButton.BackColor = System.Drawing.Color.Transparent;
            this.MaximizeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.MaximizeButton.CenterImage = ((System.Drawing.Image)(resources.GetObject("MaximizeButton.CenterImage")));
            this.MaximizeButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.MaximizeButton.HyperlinkStyle = false;
            this.MaximizeButton.ImageMargin = 2;
            this.MaximizeButton.LeftImage = null;
            this.MaximizeButton.Location = new System.Drawing.Point(2300, 0);
            this.MaximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.PushStyle = true;
            this.MaximizeButton.RightImage = null;
            this.MaximizeButton.Size = new System.Drawing.Size(24, 24);
            this.MaximizeButton.TabIndex = 0;
            this.MaximizeButton.TextAlign = System.Drawing.StringAlignment.Center;
            this.MaximizeButton.TextLeftMargin = 2;
            this.MaximizeButton.TextRightMargin = 2;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonPanel.Border = ZoneFiveSoftware.Common.Visuals.ControlBorder.Style.Square;
            this.ButtonPanel.BorderColor = System.Drawing.Color.Gray;
            this.ButtonPanel.Controls.Add(this.ZoomInButton);
            this.ButtonPanel.Controls.Add(this.ZoomOutButton);
            this.ButtonPanel.Controls.Add(this.ZoomChartButton);
            this.ButtonPanel.Controls.Add(this.btnPower);
            this.ButtonPanel.Controls.Add(this.btnHelp);
            this.ButtonPanel.Controls.Add(this.SaveImageButton);
            this.ButtonPanel.HeadingBackColor = System.Drawing.Color.LightBlue;
            this.ButtonPanel.HeadingFont = null;
            this.ButtonPanel.HeadingLeftMargin = 0;
            this.ButtonPanel.HeadingText = null;
            this.ButtonPanel.HeadingTextColor = System.Drawing.Color.Black;
            this.ButtonPanel.HeadingTopMargin = 0;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 23);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(400, 24);
            this.ButtonPanel.TabIndex = 6;
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomInButton.BackColor = System.Drawing.Color.Transparent;
            this.ZoomInButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.ZoomInButton.CenterImage = ((System.Drawing.Image)(resources.GetObject("ZoomInButton.CenterImage")));
            this.ZoomInButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ZoomInButton.HyperlinkStyle = false;
            this.ZoomInButton.ImageMargin = 2;
            this.ZoomInButton.LeftImage = null;
            this.ZoomInButton.Location = new System.Drawing.Point(374, 0);
            this.ZoomInButton.Margin = new System.Windows.Forms.Padding(0);
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.PushStyle = true;
            this.ZoomInButton.RightImage = null;
            this.ZoomInButton.Size = new System.Drawing.Size(24, 24);
            this.ZoomInButton.TabIndex = 0;
            this.ZoomInButton.TextAlign = System.Drawing.StringAlignment.Center;
            this.ZoomInButton.TextLeftMargin = 2;
            this.ZoomInButton.TextRightMargin = 2;
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomOutButton.BackColor = System.Drawing.Color.Transparent;
            this.ZoomOutButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.ZoomOutButton.CenterImage = ((System.Drawing.Image)(resources.GetObject("ZoomOutButton.CenterImage")));
            this.ZoomOutButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ZoomOutButton.HyperlinkStyle = false;
            this.ZoomOutButton.ImageMargin = 2;
            this.ZoomOutButton.LeftImage = null;
            this.ZoomOutButton.Location = new System.Drawing.Point(350, 0);
            this.ZoomOutButton.Margin = new System.Windows.Forms.Padding(0);
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.PushStyle = true;
            this.ZoomOutButton.RightImage = null;
            this.ZoomOutButton.Size = new System.Drawing.Size(24, 24);
            this.ZoomOutButton.TabIndex = 0;
            this.ZoomOutButton.TextAlign = System.Drawing.StringAlignment.Center;
            this.ZoomOutButton.TextLeftMargin = 2;
            this.ZoomOutButton.TextRightMargin = 2;
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // ZoomChartButton
            // 
            this.ZoomChartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomChartButton.BackColor = System.Drawing.Color.Transparent;
            this.ZoomChartButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.ZoomChartButton.CenterImage = global::QuadrantAnalysis.Resources.Images.ZoomFit;
            this.ZoomChartButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ZoomChartButton.HyperlinkStyle = false;
            this.ZoomChartButton.ImageMargin = 2;
            this.ZoomChartButton.LeftImage = null;
            this.ZoomChartButton.Location = new System.Drawing.Point(326, 0);
            this.ZoomChartButton.Margin = new System.Windows.Forms.Padding(0);
            this.ZoomChartButton.Name = "ZoomChartButton";
            this.ZoomChartButton.PushStyle = true;
            this.ZoomChartButton.RightImage = null;
            this.ZoomChartButton.Size = new System.Drawing.Size(24, 24);
            this.ZoomChartButton.TabIndex = 0;
            this.ZoomChartButton.TextAlign = System.Drawing.StringAlignment.Center;
            this.ZoomChartButton.TextLeftMargin = 2;
            this.ZoomChartButton.TextRightMargin = 2;
            this.ZoomChartButton.Click += new System.EventHandler(this.ZoomChartButton_Click);
            // 
            // btnPower
            // 
            this.btnPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPower.BackColor = System.Drawing.Color.Transparent;
            this.btnPower.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.btnPower.CenterImage = ((System.Drawing.Image)(resources.GetObject("btnPower.CenterImage")));
            this.btnPower.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPower.HyperlinkStyle = false;
            this.btnPower.ImageMargin = 2;
            this.btnPower.LeftImage = null;
            this.btnPower.Location = new System.Drawing.Point(278, 0);
            this.btnPower.Margin = new System.Windows.Forms.Padding(0);
            this.btnPower.Name = "btnPower";
            this.btnPower.PushStyle = true;
            this.btnPower.RightImage = null;
            this.btnPower.Size = new System.Drawing.Size(24, 24);
            this.btnPower.TabIndex = 0;
            this.btnPower.TextAlign = System.Drawing.StringAlignment.Center;
            this.btnPower.TextLeftMargin = 2;
            this.btnPower.TextRightMargin = 2;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.btnHelp.CenterImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.CenterImage")));
            this.btnHelp.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHelp.HyperlinkStyle = false;
            this.btnHelp.ImageMargin = 2;
            this.btnHelp.LeftImage = null;
            this.btnHelp.Location = new System.Drawing.Point(254, 0);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(0);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.PushStyle = true;
            this.btnHelp.RightImage = null;
            this.btnHelp.Size = new System.Drawing.Size(24, 24);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.TextAlign = System.Drawing.StringAlignment.Center;
            this.btnHelp.TextLeftMargin = 2;
            this.btnHelp.TextRightMargin = 2;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // SaveImageButton
            // 
            this.SaveImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveImageButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveImageButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.SaveImageButton.CenterImage = ((System.Drawing.Image)(resources.GetObject("SaveImageButton.CenterImage")));
            this.SaveImageButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SaveImageButton.HyperlinkStyle = false;
            this.SaveImageButton.ImageMargin = 2;
            this.SaveImageButton.LeftImage = null;
            this.SaveImageButton.Location = new System.Drawing.Point(302, 0);
            this.SaveImageButton.Margin = new System.Windows.Forms.Padding(0);
            this.SaveImageButton.Name = "SaveImageButton";
            this.SaveImageButton.PushStyle = true;
            this.SaveImageButton.RightImage = null;
            this.SaveImageButton.Size = new System.Drawing.Size(24, 24);
            this.SaveImageButton.TabIndex = 0;
            this.SaveImageButton.TextAlign = System.Drawing.StringAlignment.Center;
            this.SaveImageButton.TextLeftMargin = 2;
            this.SaveImageButton.TextRightMargin = 2;
            this.SaveImageButton.Click += new System.EventHandler(this.SaveImageButton_Click);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Border = ZoneFiveSoftware.Common.Visuals.ControlBorder.Style.Round;
            this.panelMain.BorderColor = System.Drawing.Color.Gray;
            this.panelMain.Controls.Add(this.ChartBanner);
            this.panelMain.Controls.Add(this.ButtonPanel);
            this.panelMain.Controls.Add(this.zedChart);
            this.panelMain.HeadingBackColor = System.Drawing.Color.LightBlue;
            this.panelMain.HeadingFont = null;
            this.panelMain.HeadingLeftMargin = 0;
            this.panelMain.HeadingText = null;
            this.panelMain.HeadingTextColor = System.Drawing.Color.Black;
            this.panelMain.HeadingTopMargin = 0;
            this.panelMain.Location = new System.Drawing.Point(0, 117);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(400, 283);
            this.panelMain.TabIndex = 8;
            // 
            // panelConfig
            // 
            this.panelConfig.BackColor = System.Drawing.Color.Transparent;
            this.panelConfig.Border = ZoneFiveSoftware.Common.Visuals.ControlBorder.Style.None;
            this.panelConfig.BorderColor = System.Drawing.Color.Gray;
            this.panelConfig.Controls.Add(this.txtCrank);
            this.panelConfig.Controls.Add(this.txtCadence);
            this.panelConfig.Controls.Add(this.txtPwrBands);
            this.panelConfig.Controls.Add(this.txtPower);
            this.panelConfig.Controls.Add(this.lblCredit);
            this.panelConfig.Controls.Add(this.lblCrankLength);
            this.panelConfig.Controls.Add(this.lblRange);
            this.panelConfig.Controls.Add(this.lblCadence);
            this.panelConfig.Controls.Add(this.lblPower);
            this.panelConfig.HeadingBackColor = System.Drawing.Color.LightBlue;
            this.panelConfig.HeadingFont = null;
            this.panelConfig.HeadingLeftMargin = 0;
            this.panelConfig.HeadingText = null;
            this.panelConfig.HeadingTextColor = System.Drawing.Color.Black;
            this.panelConfig.HeadingTopMargin = 3;
            this.panelConfig.Location = new System.Drawing.Point(0, 0);
            this.panelConfig.MaximumSize = new System.Drawing.Size(184, 117);
            this.panelConfig.MinimumSize = new System.Drawing.Size(184, 117);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(184, 117);
            this.panelConfig.TabIndex = 8;
            // 
            // txtCrank
            // 
            this.txtCrank.AcceptsReturn = false;
            this.txtCrank.AcceptsTab = false;
            this.txtCrank.BackColor = System.Drawing.Color.White;
            this.txtCrank.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtCrank.ButtonImage = null;
            this.txtCrank.Location = new System.Drawing.Point(92, 75);
            this.txtCrank.MaxLength = 32767;
            this.txtCrank.Multiline = false;
            this.txtCrank.Name = "txtCrank";
            this.txtCrank.ReadOnly = false;
            this.txtCrank.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtCrank.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtCrank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCrank.Size = new System.Drawing.Size(79, 19);
            this.txtCrank.TabIndex = 3;
            this.txtCrank.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCrank.Leave += new System.EventHandler(this.txtCrank_Leave);
            // 
            // txtCadence
            // 
            this.txtCadence.AcceptsReturn = false;
            this.txtCadence.AcceptsTab = false;
            this.txtCadence.BackColor = System.Drawing.Color.White;
            this.txtCadence.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtCadence.ButtonImage = null;
            this.txtCadence.Location = new System.Drawing.Point(92, 50);
            this.txtCadence.MaxLength = 32767;
            this.txtCadence.Multiline = false;
            this.txtCadence.Name = "txtCadence";
            this.txtCadence.ReadOnly = false;
            this.txtCadence.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtCadence.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtCadence.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCadence.Size = new System.Drawing.Size(79, 19);
            this.txtCadence.TabIndex = 2;
            this.txtCadence.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCadence.Leave += new System.EventHandler(this.txtCadence_Leave);
            // 
            // txtPwrBands
            // 
            this.txtPwrBands.AcceptsReturn = false;
            this.txtPwrBands.AcceptsTab = false;
            this.txtPwrBands.BackColor = System.Drawing.Color.White;
            this.txtPwrBands.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtPwrBands.ButtonImage = null;
            this.txtPwrBands.Location = new System.Drawing.Point(92, 25);
            this.txtPwrBands.MaxLength = 32767;
            this.txtPwrBands.Multiline = false;
            this.txtPwrBands.Name = "txtPwrBands";
            this.txtPwrBands.ReadOnly = false;
            this.txtPwrBands.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtPwrBands.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtPwrBands.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPwrBands.Size = new System.Drawing.Size(79, 19);
            this.txtPwrBands.TabIndex = 1;
            this.txtPwrBands.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPwrBands.Leave += new System.EventHandler(this.txtPwrBands_Leave);
            // 
            // txtPower
            // 
            this.txtPower.AcceptsReturn = false;
            this.txtPower.AcceptsTab = false;
            this.txtPower.BackColor = System.Drawing.Color.White;
            this.txtPower.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtPower.ButtonImage = null;
            this.txtPower.Location = new System.Drawing.Point(92, 0);
            this.txtPower.MaxLength = 32767;
            this.txtPower.Multiline = false;
            this.txtPower.Name = "txtPower";
            this.txtPower.ReadOnly = false;
            this.txtPower.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtPower.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtPower.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPower.Size = new System.Drawing.Size(79, 19);
            this.txtPower.TabIndex = 0;
            this.txtPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPower.Leave += new System.EventHandler(this.txtPower_Leave);
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.Location = new System.Drawing.Point(3, 101);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(145, 13);
            this.lblCredit.TabIndex = 3;
            this.lblCredit.Text = "Concept by Dr. Andy Coggan";
            // 
            // lblCrankLength
            // 
            this.lblCrankLength.AutoSize = true;
            this.lblCrankLength.Location = new System.Drawing.Point(0, 78);
            this.lblCrankLength.Name = "lblCrankLength";
            this.lblCrankLength.Size = new System.Drawing.Size(74, 13);
            this.lblCrankLength.TabIndex = 1;
            this.lblCrankLength.Text = "Crank Length:";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(0, 29);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(59, 13);
            this.lblRange.TabIndex = 1;
            this.lblRange.Text = "Range (%):";
            // 
            // lblCadence
            // 
            this.lblCadence.AutoSize = true;
            this.lblCadence.Location = new System.Drawing.Point(0, 53);
            this.lblCadence.Name = "lblCadence";
            this.lblCadence.Size = new System.Drawing.Size(53, 13);
            this.lblCadence.TabIndex = 1;
            this.lblCadence.Text = "Cadence:";
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Location = new System.Drawing.Point(0, 4);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(40, 13);
            this.lblPower.TabIndex = 1;
            this.lblPower.Text = "Power:";
            // 
            // treeActivities
            // 
            this.treeActivities.BackColor = System.Drawing.Color.Transparent;
            this.treeActivities.Border = ZoneFiveSoftware.Common.Visuals.ControlBorder.Style.SmallRoundShadow;
            this.treeActivities.CheckBoxes = false;
            this.treeActivities.ContextMenuStrip = this.menuTree;
            this.treeActivities.DefaultIndent = 15;
            this.treeActivities.DefaultRowHeight = -1;
            this.treeActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeActivities.HeaderRowHeight = 21;
            this.treeActivities.Location = new System.Drawing.Point(0, 0);
            this.treeActivities.MultiSelect = false;
            this.treeActivities.Name = "treeActivities";
            this.treeActivities.NumHeaderRows = ZoneFiveSoftware.Common.Visuals.TreeList.HeaderRows.Auto;
            this.treeActivities.NumLockedColumns = 0;
            this.treeActivities.RowAlternatingColors = true;
            this.treeActivities.RowHotlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(10)))), ((int)(((byte)(36)))), ((int)(((byte)(106)))));
            this.treeActivities.RowHotlightColorText = System.Drawing.SystemColors.HighlightText;
            this.treeActivities.RowHotlightMouse = true;
            this.treeActivities.RowSelectedColor = System.Drawing.SystemColors.Highlight;
            this.treeActivities.RowSelectedColorText = System.Drawing.SystemColors.HighlightText;
            this.treeActivities.RowSeparatorLines = true;
            this.treeActivities.ShowLines = false;
            this.treeActivities.ShowPlusMinus = false;
            this.treeActivities.Size = new System.Drawing.Size(216, 117);
            this.treeActivities.TabIndex = 2;
            this.treeActivities.TabStop = false;
            // 
            // menuTree
            // 
            this.menuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listSettingsMenuItem});
            this.menuTree.Name = "menuTree";
            this.menuTree.Size = new System.Drawing.Size(147, 26);
            // 
            // listSettingsMenuItem
            // 
            this.listSettingsMenuItem.Name = "listSettingsMenuItem";
            this.listSettingsMenuItem.Size = new System.Drawing.Size(146, 22);
            this.listSettingsMenuItem.Text = "List Settings...";
            this.listSettingsMenuItem.Click += new System.EventHandler(this.menuTreeItem_Click);
            // 
            // panelActivity
            // 
            this.panelActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActivity.BackColor = System.Drawing.Color.Transparent;
            this.panelActivity.Border = ZoneFiveSoftware.Common.Visuals.ControlBorder.Style.None;
            this.panelActivity.BorderColor = System.Drawing.Color.Gray;
            this.panelActivity.Controls.Add(this.treeActivities);
            this.panelActivity.HeadingBackColor = System.Drawing.Color.LightBlue;
            this.panelActivity.HeadingFont = null;
            this.panelActivity.HeadingLeftMargin = 0;
            this.panelActivity.HeadingText = null;
            this.panelActivity.HeadingTextColor = System.Drawing.Color.Black;
            this.panelActivity.HeadingTopMargin = 3;
            this.panelActivity.Location = new System.Drawing.Point(184, 0);
            this.panelActivity.Name = "panelActivity";
            this.panelActivity.Size = new System.Drawing.Size(216, 117);
            this.panelActivity.TabIndex = 18;
            // 
            // chartMenu
            // 
            this.chartMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadenceToolStripMenuItem,
            this.pedalVelocityToolStripMenuItem});
            this.chartMenu.Name = "chartMenu";
            this.chartMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // cadenceToolStripMenuItem
            // 
            this.cadenceToolStripMenuItem.Name = "cadenceToolStripMenuItem";
            this.cadenceToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.cadenceToolStripMenuItem.Tag = global::QuadrantAnalysis.Resources.Strings.Label_CrankLength;
            this.cadenceToolStripMenuItem.Text = "Cadence";
            this.cadenceToolStripMenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // pedalVelocityToolStripMenuItem
            // 
            this.pedalVelocityToolStripMenuItem.Name = "pedalVelocityToolStripMenuItem";
            this.pedalVelocityToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.pedalVelocityToolStripMenuItem.Tag = global::QuadrantAnalysis.Resources.Strings.Label_CrankLength;
            this.pedalVelocityToolStripMenuItem.Text = "Pedal Velocity";
            this.pedalVelocityToolStripMenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // chartToolTip
            // 
            this.chartToolTip.AutoPopDelay = 5000;
            this.chartToolTip.InitialDelay = 100;
            this.chartToolTip.ReshowDelay = 100;
            // 
            // picQ2
            // 
            this.picQ2.BackgroundImage = global::QuadrantAnalysis.Properties.Resources.bgQ24;
            this.picQ2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picQ2.Controls.Add(this.lblQ2);
            this.picQ2.Location = new System.Drawing.Point(75, 6);
            this.picQ2.Name = "picQ2";
            this.picQ2.Padding = new System.Windows.Forms.Padding(20);
            this.picQ2.Size = new System.Drawing.Size(120, 105);
            this.picQ2.TabIndex = 19;
            this.picQ2.TabStop = false;
            // 
            // lblQ2
            // 
            this.lblQ2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQ2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQ2.Location = new System.Drawing.Point(0, 0);
            this.lblQ2.Margin = new System.Windows.Forms.Padding(0);
            this.lblQ2.Name = "lblQ2";
            this.lblQ2.Padding = new System.Windows.Forms.Padding(5);
            this.lblQ2.Size = new System.Drawing.Size(120, 105);
            this.lblQ2.TabIndex = 18;
            this.lblQ2.Text = "Q2";
            // 
            // picQ3
            // 
            this.picQ3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picQ3.BackgroundImage = global::QuadrantAnalysis.Properties.Resources.bgQ13;
            this.picQ3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picQ3.Controls.Add(this.lblQ3);
            this.picQ3.Location = new System.Drawing.Point(75, 120);
            this.picQ3.Name = "picQ3";
            this.picQ3.Size = new System.Drawing.Size(120, 50);
            this.picQ3.TabIndex = 20;
            this.picQ3.TabStop = false;
            // 
            // lblQ3
            // 
            this.lblQ3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQ3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQ3.Location = new System.Drawing.Point(0, 0);
            this.lblQ3.Margin = new System.Windows.Forms.Padding(0);
            this.lblQ3.Name = "lblQ3";
            this.lblQ3.Padding = new System.Windows.Forms.Padding(5);
            this.lblQ3.Size = new System.Drawing.Size(120, 50);
            this.lblQ3.TabIndex = 18;
            this.lblQ3.Text = "Q3";
            this.lblQ3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // picQ4
            // 
            this.picQ4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picQ4.BackgroundImage = global::QuadrantAnalysis.Properties.Resources.bgQ24;
            this.picQ4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picQ4.Controls.Add(this.lblQ4);
            this.picQ4.Location = new System.Drawing.Point(253, 65);
            this.picQ4.Name = "picQ4";
            this.picQ4.Size = new System.Drawing.Size(120, 105);
            this.picQ4.TabIndex = 21;
            this.picQ4.TabStop = false;
            // 
            // lblQ4
            // 
            this.lblQ4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQ4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQ4.Location = new System.Drawing.Point(0, 0);
            this.lblQ4.Margin = new System.Windows.Forms.Padding(0);
            this.lblQ4.Name = "lblQ4";
            this.lblQ4.Padding = new System.Windows.Forms.Padding(5);
            this.lblQ4.Size = new System.Drawing.Size(120, 105);
            this.lblQ4.TabIndex = 18;
            this.lblQ4.Text = "Q4";
            this.lblQ4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // picQ1
            // 
            this.picQ1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picQ1.BackgroundImage = global::QuadrantAnalysis.Properties.Resources.bgQ13;
            this.picQ1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picQ1.Controls.Add(this.lblQ1);
            this.picQ1.Location = new System.Drawing.Point(253, 6);
            this.picQ1.Margin = new System.Windows.Forms.Padding(0);
            this.picQ1.Name = "picQ1";
            this.picQ1.Padding = new System.Windows.Forms.Padding(10);
            this.picQ1.Size = new System.Drawing.Size(120, 50);
            this.picQ1.TabIndex = 18;
            this.picQ1.TabStop = false;
            // 
            // lblQ1
            // 
            this.lblQ1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQ1.Location = new System.Drawing.Point(0, 0);
            this.lblQ1.Margin = new System.Windows.Forms.Padding(0);
            this.lblQ1.Name = "lblQ1";
            this.lblQ1.Padding = new System.Windows.Forms.Padding(5);
            this.lblQ1.Size = new System.Drawing.Size(120, 50);
            this.lblQ1.TabIndex = 18;
            this.lblQ1.Text = "Q1";
            this.lblQ1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // zedChart
            // 
            this.zedChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedChart.Controls.Add(this.picQ1);
            this.zedChart.Controls.Add(this.picQ4);
            this.zedChart.Controls.Add(this.picQ3);
            this.zedChart.Controls.Add(this.picQ2);
            this.zedChart.FitToSelection = true;
            this.zedChart.IsShowPointValues = true;
            this.zedChart.Location = new System.Drawing.Point(1, 47);
            this.zedChart.Name = "zedChart";
            this.zedChart.ScrollGrace = 0D;
            this.zedChart.ScrollMaxX = 0D;
            this.zedChart.ScrollMaxY = 0D;
            this.zedChart.ScrollMaxY2 = 0D;
            this.zedChart.ScrollMinX = 0D;
            this.zedChart.ScrollMinY = 0D;
            this.zedChart.ScrollMinY2 = 0D;
            this.zedChart.Size = new System.Drawing.Size(398, 233);
            this.zedChart.TabIndex = 2;
            this.zedChart.DoubleClick += new System.EventHandler(this.zedChart_DoubleClick);
            // 
            // QuadrantAnalysisDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelActivity);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.panelMain);
            this.Name = "QuadrantAnalysisDetail";
            this.Size = new System.Drawing.Size(400, 400);
            this.ChartBanner.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.menuTree.ResumeLayout(false);
            this.panelActivity.ResumeLayout(false);
            this.chartMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQ2)).EndInit();
            this.picQ2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQ3)).EndInit();
            this.picQ3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQ4)).EndInit();
            this.picQ4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQ1)).EndInit();
            this.picQ1.ResumeLayout(false);
            this.zedChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ZoneFiveSoftware.Common.Visuals.Button ZoomInButton;
        private ZoneFiveSoftware.Common.Visuals.ActionBanner ChartBanner;
        private ZoneFiveSoftware.Common.Visuals.Button ZoomOutButton;
        private ZoneFiveSoftware.Common.Visuals.Button ZoomChartButton;
        private ZoneFiveSoftware.Common.Visuals.Button SaveImageButton;
        private ZoneFiveSoftware.Common.Visuals.Panel ButtonPanel;
        private ZoneFiveSoftware.Common.Visuals.Panel panelMain;
        private ZoneFiveSoftware.Common.Visuals.Panel panelConfig;
        private System.Windows.Forms.Label lblPower;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtPower;
        private System.Windows.Forms.Label lblCadence;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtCadence;
        private ZoneFiveSoftware.Common.Visuals.TreeList treeActivities;
        private System.Windows.Forms.Label lblCrankLength;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtCrank;
        private System.Windows.Forms.Label lblCredit;
        private ZoneFiveSoftware.Common.Visuals.Button MaximizeButton;
        private ZoneFiveSoftware.Common.Visuals.Panel panelActivity;
        private System.Windows.Forms.ContextMenuStrip chartMenu;
        private System.Windows.Forms.ToolStripMenuItem cadenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedalVelocityToolStripMenuItem;
        private ZoneFiveSoftware.Common.Visuals.Button btnHelp;
        private ZoneFiveSoftware.Common.Visuals.Button btnPower;
        private System.Windows.Forms.ContextMenuStrip menuTree;
        private System.Windows.Forms.ToolStripMenuItem listSettingsMenuItem;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtPwrBands;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.ToolTip chartToolTip;
        private ZoneFiveSoftware.Common.Visuals.Chart.ZedGraphControl zedChart;
        private System.Windows.Forms.PictureBox picQ1;
        private System.Windows.Forms.Label lblQ1;
        private System.Windows.Forms.PictureBox picQ4;
        private System.Windows.Forms.Label lblQ4;
        private System.Windows.Forms.PictureBox picQ3;
        private System.Windows.Forms.Label lblQ3;
        private System.Windows.Forms.PictureBox picQ2;
        private System.Windows.Forms.Label lblQ2;
    }
}
