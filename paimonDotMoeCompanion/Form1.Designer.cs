namespace paimonDotMoeCompanion
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lostLabel1 = new ReaLTaiizor.Controls.LostLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLink = new ReaLTaiizor.Controls.CyberTextBox();
            this.btnCopyToClipboard = new ReaLTaiizor.Controls.CyberButton();
            this.btnOpenPaimonDotMoe = new ReaLTaiizor.Controls.CyberButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbRegion = new ReaLTaiizor.Controls.DungeonComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearAllLogs = new ReaLTaiizor.Controls.CyberButton();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnStart = new ReaLTaiizor.Controls.CyberButton();
            this.lnkAbout = new ReaLTaiizor.Controls.NightLinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::paimonDotMoeCompanion.Properties.Resources.image1;
            this.pictureBox1.Location = new System.Drawing.Point(20, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lostLabel1
            // 
            this.lostLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lostLabel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lostLabel1.ForeColor = System.Drawing.Color.White;
            this.lostLabel1.Location = new System.Drawing.Point(261, 55);
            this.lostLabel1.Name = "lostLabel1";
            this.lostLabel1.Size = new System.Drawing.Size(383, 32);
            this.lostLabel1.TabIndex = 1;
            this.lostLabel1.Text = "Welcome to paimon.moe Companion!";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(146, 97);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 21);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(16, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(708, 231);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(16, 553);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Link: ";
            // 
            // txtLink
            // 
            this.txtLink.Alpha = 20;
            this.txtLink.BackColor = System.Drawing.Color.Transparent;
            this.txtLink.Background_WidthPen = 3F;
            this.txtLink.BackgroundPen = true;
            this.txtLink.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtLink.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtLink.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtLink.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.txtLink.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.txtLink.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.txtLink.Font = new System.Drawing.Font("Arial", 10F);
            this.txtLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtLink.Lighting = false;
            this.txtLink.LinearGradientPen = false;
            this.txtLink.Location = new System.Drawing.Point(88, 543);
            this.txtLink.Name = "txtLink";
            this.txtLink.PenWidth = 15;
            this.txtLink.RGB = false;
            this.txtLink.Rounding = true;
            this.txtLink.RoundingInt = 60;
            this.txtLink.Size = new System.Drawing.Size(554, 40);
            this.txtLink.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.txtLink.TabIndex = 6;
            this.txtLink.Tag = "Cyber";
            this.txtLink.TextButton = "";
            this.txtLink.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.txtLink.Timer_RGB = 300;
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Alpha = 20;
            this.btnCopyToClipboard.BackColor = System.Drawing.Color.Transparent;
            this.btnCopyToClipboard.Background = true;
            this.btnCopyToClipboard.Background_WidthPen = 4F;
            this.btnCopyToClipboard.BackgroundPen = true;
            this.btnCopyToClipboard.ColorBackground = System.Drawing.Color.Teal;
            this.btnCopyToClipboard.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnCopyToClipboard.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnCopyToClipboard.ColorBackground_Pen = System.Drawing.Color.Green;
            this.btnCopyToClipboard.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnCopyToClipboard.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnCopyToClipboard.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnCopyToClipboard.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnCopyToClipboard.Effect_1 = true;
            this.btnCopyToClipboard.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnCopyToClipboard.Effect_1_Transparency = 25;
            this.btnCopyToClipboard.Effect_2 = true;
            this.btnCopyToClipboard.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnCopyToClipboard.Effect_2_Transparency = 20;
            this.btnCopyToClipboard.Font = new System.Drawing.Font("Arial", 11F);
            this.btnCopyToClipboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnCopyToClipboard.Lighting = false;
            this.btnCopyToClipboard.LinearGradient_Background = false;
            this.btnCopyToClipboard.LinearGradientPen = false;
            this.btnCopyToClipboard.Location = new System.Drawing.Point(648, 543);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.PenWidth = 15;
            this.btnCopyToClipboard.Rounding = true;
            this.btnCopyToClipboard.RoundingInt = 70;
            this.btnCopyToClipboard.Size = new System.Drawing.Size(130, 40);
            this.btnCopyToClipboard.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnCopyToClipboard.TabIndex = 7;
            this.btnCopyToClipboard.Tag = "Cyber";
            this.btnCopyToClipboard.TextButton = "Copy";
            this.btnCopyToClipboard.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnCopyToClipboard.Timer_Effect_1 = 5;
            this.btnCopyToClipboard.Timer_RGB = 300;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnOpenPaimonDotMoe
            // 
            this.btnOpenPaimonDotMoe.Alpha = 20;
            this.btnOpenPaimonDotMoe.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenPaimonDotMoe.Background = true;
            this.btnOpenPaimonDotMoe.Background_WidthPen = 4F;
            this.btnOpenPaimonDotMoe.BackgroundPen = true;
            this.btnOpenPaimonDotMoe.ColorBackground = System.Drawing.Color.Green;
            this.btnOpenPaimonDotMoe.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnOpenPaimonDotMoe.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnOpenPaimonDotMoe.ColorBackground_Pen = System.Drawing.Color.Green;
            this.btnOpenPaimonDotMoe.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnOpenPaimonDotMoe.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnOpenPaimonDotMoe.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnOpenPaimonDotMoe.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnOpenPaimonDotMoe.Effect_1 = true;
            this.btnOpenPaimonDotMoe.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnOpenPaimonDotMoe.Effect_1_Transparency = 25;
            this.btnOpenPaimonDotMoe.Effect_2 = true;
            this.btnOpenPaimonDotMoe.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnOpenPaimonDotMoe.Effect_2_Transparency = 20;
            this.btnOpenPaimonDotMoe.Font = new System.Drawing.Font("Arial", 11F);
            this.btnOpenPaimonDotMoe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnOpenPaimonDotMoe.Lighting = false;
            this.btnOpenPaimonDotMoe.LinearGradient_Background = false;
            this.btnOpenPaimonDotMoe.LinearGradientPen = false;
            this.btnOpenPaimonDotMoe.Location = new System.Drawing.Point(417, 607);
            this.btnOpenPaimonDotMoe.Name = "btnOpenPaimonDotMoe";
            this.btnOpenPaimonDotMoe.PenWidth = 15;
            this.btnOpenPaimonDotMoe.Rounding = true;
            this.btnOpenPaimonDotMoe.RoundingInt = 70;
            this.btnOpenPaimonDotMoe.Size = new System.Drawing.Size(361, 50);
            this.btnOpenPaimonDotMoe.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnOpenPaimonDotMoe.TabIndex = 8;
            this.btnOpenPaimonDotMoe.Tag = "Cyber";
            this.btnOpenPaimonDotMoe.TextButton = "Open paimon.moe";
            this.btnOpenPaimonDotMoe.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnOpenPaimonDotMoe.Timer_Effect_1 = 5;
            this.btnOpenPaimonDotMoe.Timer_RGB = 300;
            this.btnOpenPaimonDotMoe.Click += new System.EventHandler(this.btnOpenPaimonDotMoe_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(16, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Region: ";
            // 
            // cbbRegion
            // 
            this.cbbRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cbbRegion.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.cbbRegion.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.cbbRegion.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.cbbRegion.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.cbbRegion.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.cbbRegion.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cbbRegion.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(118)))));
            this.cbbRegion.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.cbbRegion.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cbbRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbRegion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbRegion.DropDownHeight = 100;
            this.cbbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRegion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbRegion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(97)))));
            this.cbbRegion.FormattingEnabled = true;
            this.cbbRegion.HoverSelectionColor = System.Drawing.Color.Empty;
            this.cbbRegion.IntegralHeight = false;
            this.cbbRegion.ItemHeight = 20;
            this.cbbRegion.Items.AddRange(new object[] {
            "Global",
            "China"});
            this.cbbRegion.Location = new System.Drawing.Point(88, 500);
            this.cbbRegion.Name = "cbbRegion";
            this.cbbRegion.Size = new System.Drawing.Size(690, 26);
            this.cbbRegion.StartIndex = 0;
            this.cbbRegion.TabIndex = 11;
            this.cbbRegion.SelectedIndexChanged += new System.EventHandler(this.cbbRegion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(16, 687);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Log:";
            // 
            // btnClearAllLogs
            // 
            this.btnClearAllLogs.Alpha = 20;
            this.btnClearAllLogs.BackColor = System.Drawing.Color.Transparent;
            this.btnClearAllLogs.Background = true;
            this.btnClearAllLogs.Background_WidthPen = 4F;
            this.btnClearAllLogs.BackgroundPen = true;
            this.btnClearAllLogs.ColorBackground = System.Drawing.Color.Teal;
            this.btnClearAllLogs.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnClearAllLogs.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnClearAllLogs.ColorBackground_Pen = System.Drawing.Color.Green;
            this.btnClearAllLogs.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnClearAllLogs.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnClearAllLogs.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnClearAllLogs.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnClearAllLogs.Effect_1 = true;
            this.btnClearAllLogs.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnClearAllLogs.Effect_1_Transparency = 25;
            this.btnClearAllLogs.Effect_2 = true;
            this.btnClearAllLogs.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnClearAllLogs.Effect_2_Transparency = 20;
            this.btnClearAllLogs.Font = new System.Drawing.Font("Arial", 11F);
            this.btnClearAllLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnClearAllLogs.Lighting = false;
            this.btnClearAllLogs.LinearGradient_Background = false;
            this.btnClearAllLogs.LinearGradientPen = false;
            this.btnClearAllLogs.Location = new System.Drawing.Point(594, 677);
            this.btnClearAllLogs.Name = "btnClearAllLogs";
            this.btnClearAllLogs.PenWidth = 15;
            this.btnClearAllLogs.Rounding = true;
            this.btnClearAllLogs.RoundingInt = 70;
            this.btnClearAllLogs.Size = new System.Drawing.Size(184, 40);
            this.btnClearAllLogs.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnClearAllLogs.TabIndex = 14;
            this.btnClearAllLogs.Tag = "Cyber";
            this.btnClearAllLogs.TextButton = "Clear logs";
            this.btnClearAllLogs.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnClearAllLogs.Timer_Effect_1 = 5;
            this.btnClearAllLogs.Timer_RGB = 300;
            this.btnClearAllLogs.Click += new System.EventHandler(this.btnClearAllLogs_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.ForeColor = System.Drawing.Color.White;
            this.rtbLog.Location = new System.Drawing.Point(20, 723);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(758, 160);
            this.rtbLog.TabIndex = 15;
            this.rtbLog.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Alpha = 20;
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Background = true;
            this.btnStart.Background_WidthPen = 4F;
            this.btnStart.BackgroundPen = true;
            this.btnStart.ColorBackground = System.Drawing.Color.Teal;
            this.btnStart.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnStart.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnStart.ColorBackground_Pen = System.Drawing.Color.Green;
            this.btnStart.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnStart.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnStart.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnStart.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnStart.Effect_1 = true;
            this.btnStart.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnStart.Effect_1_Transparency = 25;
            this.btnStart.Effect_2 = true;
            this.btnStart.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnStart.Effect_2_Transparency = 20;
            this.btnStart.Font = new System.Drawing.Font("Arial", 11F);
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnStart.Lighting = false;
            this.btnStart.LinearGradient_Background = false;
            this.btnStart.LinearGradientPen = false;
            this.btnStart.Location = new System.Drawing.Point(20, 607);
            this.btnStart.Name = "btnStart";
            this.btnStart.PenWidth = 15;
            this.btnStart.Rounding = true;
            this.btnStart.RoundingInt = 70;
            this.btnStart.Size = new System.Drawing.Size(391, 50);
            this.btnStart.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnStart.TabIndex = 16;
            this.btnStart.Tag = "Cyber";
            this.btnStart.TextButton = "START";
            this.btnStart.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnStart.Timer_Effect_1 = 5;
            this.btnStart.Timer_RGB = 300;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lnkAbout
            // 
            this.lnkAbout.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(89)))), ((int)(((byte)(84)))));
            this.lnkAbout.AutoSize = true;
            this.lnkAbout.BackColor = System.Drawing.Color.Transparent;
            this.lnkAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAbout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAbout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAbout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(93)))), ((int)(((byte)(89)))));
            this.lnkAbout.Location = new System.Drawing.Point(323, 203);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(142, 21);
            this.lnkAbout.TabIndex = 18;
            this.lnkAbout.TabStop = true;
            this.lnkAbout.Text = "About this project...";
            this.lnkAbout.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(89)))), ((int)(((byte)(84)))));
            this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 906);
            this.Controls.Add(this.lnkAbout);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnClearAllLogs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbRegion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenPaimonDotMoe);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lostLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image = global::paimonDotMoeCompanion.Properties.Resources.image;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "paimon.moe Companion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ReaLTaiizor.Controls.LostLabel lostLabel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.CyberButton btnCopyToClipboard;
        private ReaLTaiizor.Controls.CyberTextBox txtLink;
        private ReaLTaiizor.Controls.CyberButton btnOpenPaimonDotMoe;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.DungeonComboBox cbbRegion;
        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.CyberButton btnClearAllLogs;
        private System.Windows.Forms.RichTextBox rtbLog;
        private ReaLTaiizor.Controls.CyberButton btnStart;
        private ReaLTaiizor.Controls.NightLinkLabel lnkAbout;
    }
}

