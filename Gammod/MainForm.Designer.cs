namespace Gammod
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButtonScanOrigin = new MetroFramework.Controls.MetroButton();
            this.metroTextBoxGamePath = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTextBoxGameSearch = new MetroFramework.Controls.MetroTextBox();
            this.metroUserControl2 = new MetroFramework.Controls.MetroUserControl();
            this.metroButtonOriginApply = new MetroFramework.Controls.MetroButton();
            this.metroPanelDynamicFields = new MetroFramework.Controls.MetroPanel();
            this.metroLabelProfileDetails = new MetroFramework.Controls.MetroLabel();
            this.metroLabel26 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxOriginProfile = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel25 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxOriginGames = new MetroFramework.Controls.MetroComboBox();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroTextBoxRepositories = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroToggleDebug = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTileSwitch = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTabPage7 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox9 = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip = new MetroFramework.Components.MetroToolTip();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.metroLink3 = new MetroFramework.Controls.MetroLink();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage7.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage5);
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage7);
            resources.ApplyResources(this.metroTabControl1, "metroTabControl1");
            this.metroTabControl1.HotTrack = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.SelectedIndexChanged += new System.EventHandler(this.metroTabControl1_SelectedIndexChanged);
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.Controls.Add(this.metroButton3);
            this.metroTabPage5.Controls.Add(this.metroButtonScanOrigin);
            this.metroTabPage5.Controls.Add(this.metroTextBoxGamePath);
            this.metroTabPage5.Controls.Add(this.metroLabel22);
            this.metroTabPage5.Controls.Add(this.pictureBox1);
            this.metroTabPage5.Controls.Add(this.metroTextBoxGameSearch);
            this.metroTabPage5.Controls.Add(this.metroUserControl2);
            this.metroTabPage5.Controls.Add(this.metroButtonOriginApply);
            this.metroTabPage5.Controls.Add(this.metroPanelDynamicFields);
            this.metroTabPage5.Controls.Add(this.metroLabelProfileDetails);
            this.metroTabPage5.Controls.Add(this.metroLabel26);
            this.metroTabPage5.Controls.Add(this.metroComboBoxOriginProfile);
            this.metroTabPage5.Controls.Add(this.metroLabel25);
            this.metroTabPage5.Controls.Add(this.metroComboBoxOriginGames);
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.metroTabPage5, "metroTabPage5");
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 10;
            // 
            // metroButton3
            // 
            resources.ApplyResources(this.metroButton3, "metroButton3");
            this.metroButton3.Highlight = true;
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.UseStyleColors = true;
            // 
            // metroButtonScanOrigin
            // 
            this.metroButtonScanOrigin.Highlight = true;
            resources.ApplyResources(this.metroButtonScanOrigin, "metroButtonScanOrigin");
            this.metroButtonScanOrigin.Name = "metroButtonScanOrigin";
            this.metroButtonScanOrigin.UseSelectable = true;
            this.metroButtonScanOrigin.UseStyleColors = true;
            this.metroButtonScanOrigin.Click += new System.EventHandler(this.metroButtonScanOrigin_Click);
            // 
            // metroTextBoxGamePath
            // 
            this.metroTextBoxGamePath.IconRight = true;
            this.metroTextBoxGamePath.Lines = new string[0];
            resources.ApplyResources(this.metroTextBoxGamePath, "metroTextBoxGamePath");
            this.metroTextBoxGamePath.MaxLength = 32767;
            this.metroTextBoxGamePath.Name = "metroTextBoxGamePath";
            this.metroTextBoxGamePath.PasswordChar = '\0';
            this.metroTextBoxGamePath.ReadOnly = true;
            this.metroTextBoxGamePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxGamePath.SelectedText = "";
            this.metroTextBoxGamePath.UseSelectable = true;
            this.metroTextBoxGamePath.UseStyleColors = true;
            // 
            // metroLabel22
            // 
            resources.ApplyResources(this.metroLabel22, "metroLabel22");
            this.metroLabel22.Name = "metroLabel22";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Gammod.Properties.Resources._1411023253_search;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // metroTextBoxGameSearch
            // 
            this.metroTextBoxGameSearch.IconRight = true;
            this.metroTextBoxGameSearch.Lines = new string[0];
            resources.ApplyResources(this.metroTextBoxGameSearch, "metroTextBoxGameSearch");
            this.metroTextBoxGameSearch.MaxLength = 32767;
            this.metroTextBoxGameSearch.Name = "metroTextBoxGameSearch";
            this.metroTextBoxGameSearch.PasswordChar = '\0';
            this.metroTextBoxGameSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxGameSearch.SelectedText = "";
            this.metroTextBoxGameSearch.UseSelectable = true;
            this.metroTextBoxGameSearch.UseStyleColors = true;
            // 
            // metroUserControl2
            // 
            resources.ApplyResources(this.metroUserControl2, "metroUserControl2");
            this.metroUserControl2.Name = "metroUserControl2";
            this.metroUserControl2.UseCustomBackColor = true;
            this.metroUserControl2.UseSelectable = true;
            // 
            // metroButtonOriginApply
            // 
            resources.ApplyResources(this.metroButtonOriginApply, "metroButtonOriginApply");
            this.metroButtonOriginApply.Highlight = true;
            this.metroButtonOriginApply.Name = "metroButtonOriginApply";
            this.metroButtonOriginApply.UseSelectable = true;
            this.metroButtonOriginApply.UseStyleColors = true;
            this.metroButtonOriginApply.Click += new System.EventHandler(this.metroButtonOriginApply_Click);
            // 
            // metroPanelDynamicFields
            // 
            resources.ApplyResources(this.metroPanelDynamicFields, "metroPanelDynamicFields");
            this.metroPanelDynamicFields.HorizontalScrollbar = true;
            this.metroPanelDynamicFields.HorizontalScrollbarBarColor = true;
            this.metroPanelDynamicFields.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelDynamicFields.HorizontalScrollbarSize = 10;
            this.metroPanelDynamicFields.Name = "metroPanelDynamicFields";
            this.metroPanelDynamicFields.VerticalScrollbar = true;
            this.metroPanelDynamicFields.VerticalScrollbarBarColor = true;
            this.metroPanelDynamicFields.VerticalScrollbarHighlightOnWheel = true;
            this.metroPanelDynamicFields.VerticalScrollbarSize = 20;
            // 
            // metroLabelProfileDetails
            // 
            resources.ApplyResources(this.metroLabelProfileDetails, "metroLabelProfileDetails");
            this.metroLabelProfileDetails.Name = "metroLabelProfileDetails";
            // 
            // metroLabel26
            // 
            resources.ApplyResources(this.metroLabel26, "metroLabel26");
            this.metroLabel26.Name = "metroLabel26";
            // 
            // metroComboBoxOriginProfile
            // 
            this.metroComboBoxOriginProfile.DisplayFocus = true;
            this.metroComboBoxOriginProfile.DropDownHeight = 200;
            this.metroComboBoxOriginProfile.FormattingEnabled = true;
            resources.ApplyResources(this.metroComboBoxOriginProfile, "metroComboBoxOriginProfile");
            this.metroComboBoxOriginProfile.Name = "metroComboBoxOriginProfile";
            this.metroComboBoxOriginProfile.UseSelectable = true;
            this.metroComboBoxOriginProfile.SelectedIndexChanged += new System.EventHandler(this.metroComboBoxOriginProfile_SelectedIndexChanged);
            // 
            // metroLabel25
            // 
            resources.ApplyResources(this.metroLabel25, "metroLabel25");
            this.metroLabel25.Name = "metroLabel25";
            // 
            // metroComboBoxOriginGames
            // 
            this.metroComboBoxOriginGames.DisplayFocus = true;
            this.metroComboBoxOriginGames.DropDownHeight = 200;
            this.metroComboBoxOriginGames.FormattingEnabled = true;
            resources.ApplyResources(this.metroComboBoxOriginGames, "metroComboBoxOriginGames");
            this.metroComboBoxOriginGames.Name = "metroComboBoxOriginGames";
            this.metroComboBoxOriginGames.Sorted = true;
            this.metroComboBoxOriginGames.UseSelectable = true;
            this.metroComboBoxOriginGames.SelectedIndexChanged += new System.EventHandler(this.metroComboBoxOriginGames_SelectedIndexChanged);
            // 
            // metroTabPage1
            // 
            resources.ApplyResources(this.metroTabPage1, "metroTabPage1");
            this.metroTabPage1.Controls.Add(this.metroButton1);
            this.metroTabPage1.Controls.Add(this.metroTextBoxRepositories);
            this.metroTabPage1.Controls.Add(this.metroLabel23);
            this.metroTabPage1.Controls.Add(this.metroLabel16);
            this.metroTabPage1.Controls.Add(this.metroToggleDebug);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.metroTileSwitch);
            this.metroTabPage1.Controls.Add(this.metroTile1);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroButton1
            // 
            resources.ApplyResources(this.metroButton1, "metroButton1");
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTextBoxRepositories
            // 
            this.metroTextBoxRepositories.IconRight = true;
            this.metroTextBoxRepositories.Lines = new string[0];
            resources.ApplyResources(this.metroTextBoxRepositories, "metroTextBoxRepositories");
            this.metroTextBoxRepositories.MaxLength = 32767;
            this.metroTextBoxRepositories.Multiline = true;
            this.metroTextBoxRepositories.Name = "metroTextBoxRepositories";
            this.metroTextBoxRepositories.PasswordChar = '\0';
            this.metroTextBoxRepositories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBoxRepositories.SelectedText = "";
            this.metroToolTip.SetToolTip(this.metroTextBoxRepositories, resources.GetString("metroTextBoxRepositories.ToolTip"));
            this.metroTextBoxRepositories.UseSelectable = true;
            this.metroTextBoxRepositories.UseStyleColors = true;
            this.metroTextBoxRepositories.Leave += new System.EventHandler(this.metroTextBoxRepositories_Leave);
            // 
            // metroLabel23
            // 
            resources.ApplyResources(this.metroLabel23, "metroLabel23");
            this.metroLabel23.Name = "metroLabel23";
            // 
            // metroLabel16
            // 
            resources.ApplyResources(this.metroLabel16, "metroLabel16");
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.UseStyleColors = true;
            // 
            // metroToggleDebug
            // 
            resources.ApplyResources(this.metroToggleDebug, "metroToggleDebug");
            this.metroToggleDebug.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggleDebug.Name = "metroToggleDebug";
            this.metroToolTip.SetToolTip(this.metroToggleDebug, resources.GetString("metroToggleDebug.ToolTip"));
            this.metroToggleDebug.UseSelectable = true;
            this.metroToggleDebug.UseStyleColors = true;
            this.metroToggleDebug.CheckedChanged += new System.EventHandler(this.metroToggleDebug_CheckedChanged);
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // metroTileSwitch
            // 
            this.metroTileSwitch.ActiveControl = null;
            resources.ApplyResources(this.metroTileSwitch, "metroTileSwitch");
            this.metroTileSwitch.Name = "metroTileSwitch";
            this.metroToolTip.SetToolTip(this.metroTileSwitch, resources.GetString("metroTileSwitch.ToolTip"));
            this.metroTileSwitch.UseSelectable = true;
            this.metroTileSwitch.Click += new System.EventHandler(this.metroTileSwitch_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            resources.ApplyResources(this.metroTile1, "metroTile1");
            this.metroTile1.Name = "metroTile1";
            this.metroToolTip.SetToolTip(this.metroTile1, resources.GetString("metroTile1.ToolTip"));
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTabPage7
            // 
            this.metroTabPage7.Controls.Add(this.metroButton4);
            this.metroTabPage7.Controls.Add(this.metroLabel24);
            this.metroTabPage7.Controls.Add(this.metroTextBox9);
            this.metroTabPage7.Controls.Add(this.metroPanel3);
            this.metroTabPage7.HorizontalScrollbarBarColor = true;
            this.metroTabPage7.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage7.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.metroTabPage7, "metroTabPage7");
            this.metroTabPage7.Name = "metroTabPage7";
            this.metroTabPage7.VerticalScrollbarBarColor = true;
            this.metroTabPage7.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage7.VerticalScrollbarSize = 10;
            // 
            // metroButton4
            // 
            this.metroButton4.BackColor = System.Drawing.Color.Transparent;
            this.metroButton4.BackgroundImage = global::Gammod.Properties.Resources._1411024218_folder;
            resources.ApplyResources(this.metroButton4, "metroButton4");
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.UseSelectable = true;
            // 
            // metroLabel24
            // 
            resources.ApplyResources(this.metroLabel24, "metroLabel24");
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.UseStyleColors = true;
            // 
            // metroTextBox9
            // 
            this.metroTextBox9.IconRight = true;
            this.metroTextBox9.Lines = new string[0];
            resources.ApplyResources(this.metroTextBox9, "metroTextBox9");
            this.metroTextBox9.MaxLength = 32767;
            this.metroTextBox9.Name = "metroTextBox9";
            this.metroTextBox9.PasswordChar = '\0';
            this.metroTextBox9.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox9.SelectedText = "";
            this.metroTextBox9.UseSelectable = true;
            this.metroTextBox9.UseStyleColors = true;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.metroGrid1);
            this.metroPanel3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.metroPanel3, "metroPanel3");
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.metroGrid1, "metroGrid1");
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.VirtualMode = true;
            this.metroGrid1.CustomPaint += new System.EventHandler<MetroFramework.Drawing.MetroPaintEventArgs>(this.metroGrid1_CustomPaint);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Orange;
            // 
            // metroToolTip
            // 
            this.metroToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip.StyleManager = null;
            this.metroToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            resources.ApplyResources(this.metroContextMenu1, "metroContextMenu1");
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            resources.ApplyResources(this.maintenanceToolStripMenuItem, "maintenanceToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // metroLink3
            // 
            this.metroLink3.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.metroLink3, "metroLink3");
            this.metroLink3.Name = "metroLink3";
            this.metroLink3.UseSelectable = true;
            this.metroLink3.UseStyleColors = true;
            this.metroLink3.Click += new System.EventHandler(this.metroLink3_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::Gammod.Properties.Resources.MainIcon;
            this.BackImagePadding = new System.Windows.Forms.Padding(179, 23, 0, 0);
            this.BackMaxSize = 32;
            this.Controls.Add(this.metroLink3);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.StyleManager = this.metroStyleManager;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage5.ResumeLayout(false);
            this.metroTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage7.ResumeLayout(false);
            this.metroTabPage7.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTile metroTileSwitch;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Components.MetroToolTip metroToolTip;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private MetroFramework.Controls.MetroTabPage metroTabPage7;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroLabel metroLabel24;
        private MetroFramework.Controls.MetroTextBox metroTextBox9;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Controls.MetroComboBox metroComboBoxOriginGames;
        private MetroFramework.Controls.MetroLabel metroLabel26;
        private MetroFramework.Controls.MetroComboBox metroComboBoxOriginProfile;
        private MetroFramework.Controls.MetroLabel metroLabel25;
        private MetroFramework.Controls.MetroLabel metroLabelProfileDetails;
        private MetroFramework.Controls.MetroPanel metroPanelDynamicFields;
        private MetroFramework.Controls.MetroButton metroButtonOriginApply;
        private MetroFramework.Controls.MetroLink metroLink3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroToggle metroToggleDebug;
        private MetroFramework.Controls.MetroUserControl metroUserControl2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRepositories;
        private MetroFramework.Controls.MetroLabel metroLabel23;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBoxGameSearch;
        private MetroFramework.Controls.MetroTextBox metroTextBoxGamePath;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButtonScanOrigin;

    }
}

