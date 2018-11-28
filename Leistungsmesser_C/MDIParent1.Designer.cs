namespace Leistungsmesser_C
{
    partial class MDIParent1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScaleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.scalepowermeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softwareUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMSCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveasimagetoolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PlayStripButton = new System.Windows.Forms.ToolStripButton();
            this.StopStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RecordStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStriptrigger_threshold = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonSetTriggerS = new System.Windows.Forms.ToolStripButton();
            this.TextTriggerSource = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripRecordTime = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.calctoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.powertoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomBackToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutAlltoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hid_search = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu,
            this.startToolStripMenuItem,
            this.ScaleMenu,
            this.toolsToolStripMenuItem,
            this.viewMenu,
            this.windowsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(788, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // MainMenu
            // 
            this.MainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.saveAsImageToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.MainMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(41, 20);
            this.MainMenu.Text = "&Main";
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save &as csv";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // saveAsImageToolStripMenuItem
            // 
            this.saveAsImageToolStripMenuItem.Enabled = false;
            this.saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            this.saveAsImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsImageToolStripMenuItem.Text = "Save as Image";
            this.saveAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watchingToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.recodingToolStripMenuItem});
            this.startToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // watchingToolStripMenuItem
            // 
            this.watchingToolStripMenuItem.Name = "watchingToolStripMenuItem";
            this.watchingToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.watchingToolStripMenuItem.Text = "Play";
            this.watchingToolStripMenuItem.Click += new System.EventHandler(this.watchingToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.stopToolStripMenuItem.Text = "Pause";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // recodingToolStripMenuItem
            // 
            this.recodingToolStripMenuItem.Name = "recodingToolStripMenuItem";
            this.recodingToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.recodingToolStripMenuItem.Text = "Record";
            this.recodingToolStripMenuItem.Click += new System.EventHandler(this.recodingToolStripMenuItem_Click);
            // 
            // ScaleMenu
            // 
            this.ScaleMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scalepowermeterToolStripMenuItem});
            this.ScaleMenu.Enabled = false;
            this.ScaleMenu.Name = "ScaleMenu";
            this.ScaleMenu.Size = new System.Drawing.Size(78, 20);
            this.ScaleMenu.Text = "Scale Values";
            // 
            // scalepowermeterToolStripMenuItem
            // 
            this.scalepowermeterToolStripMenuItem.Name = "scalepowermeterToolStripMenuItem";
            this.scalepowermeterToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.scalepowermeterToolStripMenuItem.Text = "Scale PowerMeter...";
            this.scalepowermeterToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareUpdateToolStripMenuItem,
            this.rMSCalculatorToolStripMenuItem,
            this.powerChartToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // softwareUpdateToolStripMenuItem
            // 
            this.softwareUpdateToolStripMenuItem.Enabled = false;
            this.softwareUpdateToolStripMenuItem.Name = "softwareUpdateToolStripMenuItem";
            this.softwareUpdateToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.softwareUpdateToolStripMenuItem.Text = "Start Bootloader";
            this.softwareUpdateToolStripMenuItem.Click += new System.EventHandler(this.softwareUpdateToolStripMenuItem_Click);
            // 
            // rMSCalculatorToolStripMenuItem
            // 
            this.rMSCalculatorToolStripMenuItem.Enabled = false;
            this.rMSCalculatorToolStripMenuItem.Name = "rMSCalculatorToolStripMenuItem";
            this.rMSCalculatorToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.rMSCalculatorToolStripMenuItem.Text = "RMS/Average Calculator";
            this.rMSCalculatorToolStripMenuItem.Click += new System.EventHandler(this.rMSCalculatorToolStripMenuItem_Click);
            // 
            // powerChartToolStripMenuItem
            // 
            this.powerChartToolStripMenuItem.Enabled = false;
            this.powerChartToolStripMenuItem.Name = "powerChartToolStripMenuItem";
            this.powerChartToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.powerChartToolStripMenuItem.Text = "Power Chart";
            this.powerChartToolStripMenuItem.Click += new System.EventHandler(this.powerChartToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(41, 20);
            this.viewMenu.Text = "&View";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.toolBarToolStripMenuItem.Text = "Toolbar";
            this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.statusBarToolStripMenuItem.Text = "Status Bar";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(57, 20);
            this.windowsMenu.Text = "&Window";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile Vertically";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile Horizontally";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.arrangeIconsToolStripMenuItem.Text = "Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(40, 20);
            this.helpMenu.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.aboutToolStripMenuItem.Text = "&Info...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.saveasimagetoolStripButton6,
            this.toolStripSeparator1,
            this.PlayStripButton,
            this.StopStripButton,
            this.toolStripSeparator2,
            this.RecordStripButton,
            this.toolStripLabel1,
            this.toolStriptrigger_threshold,
            this.toolStripLabel2,
            this.toolStripButtonSetTriggerS,
            this.TextTriggerSource,
            this.toolStripLabel3,
            this.toolStripRecordTime,
            this.toolStripLabel4,
            this.toolStripSeparator4,
            this.calctoolStripButton,
            this.powertoolStripButton,
            this.toolStripSeparator6,
            this.ZoomBackToolstripButton,
            this.ZoomOutAlltoolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(788, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save As";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // saveasimagetoolStripButton6
            // 
            this.saveasimagetoolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveasimagetoolStripButton6.Enabled = false;
            this.saveasimagetoolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("saveasimagetoolStripButton6.Image")));
            this.saveasimagetoolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveasimagetoolStripButton6.Name = "saveasimagetoolStripButton6";
            this.saveasimagetoolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.saveasimagetoolStripButton6.Text = "Save as Image";
            this.saveasimagetoolStripButton6.Click += new System.EventHandler(this.saveasimagetoolStripButton6_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // PlayStripButton
            // 
            this.PlayStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PlayStripButton.Enabled = false;
            this.PlayStripButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayStripButton.Image")));
            this.PlayStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayStripButton.Name = "PlayStripButton";
            this.PlayStripButton.Size = new System.Drawing.Size(23, 22);
            this.PlayStripButton.Text = "Play";
            this.PlayStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // StopStripButton
            // 
            this.StopStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StopStripButton.Enabled = false;
            this.StopStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StopStripButton.Image")));
            this.StopStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopStripButton.Name = "StopStripButton";
            this.StopStripButton.Size = new System.Drawing.Size(23, 22);
            this.StopStripButton.Text = "Pause";
            this.StopStripButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // RecordStripButton
            // 
            this.RecordStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RecordStripButton.Enabled = false;
            this.RecordStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RecordStripButton.Image")));
            this.RecordStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RecordStripButton.Name = "RecordStripButton";
            this.RecordStripButton.Size = new System.Drawing.Size(23, 22);
            this.RecordStripButton.Text = "Record";
            this.RecordStripButton.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel1.Text = "Trigger Threshold:";
            // 
            // toolStriptrigger_threshold
            // 
            this.toolStriptrigger_threshold.MaxLength = 5;
            this.toolStriptrigger_threshold.Name = "toolStriptrigger_threshold";
            this.toolStriptrigger_threshold.Size = new System.Drawing.Size(50, 25);
            this.toolStriptrigger_threshold.Text = "0";
            this.toolStriptrigger_threshold.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(14, 22);
            this.toolStripLabel2.Text = "A";
            // 
            // toolStripButtonSetTriggerS
            // 
            this.toolStripButtonSetTriggerS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSetTriggerS.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSetTriggerS.Image")));
            this.toolStripButtonSetTriggerS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetTriggerS.Name = "toolStripButtonSetTriggerS";
            this.toolStripButtonSetTriggerS.Size = new System.Drawing.Size(104, 22);
            this.toolStripButtonSetTriggerS.Text = "Set Trigger Source:";
            this.toolStripButtonSetTriggerS.Click += new System.EventHandler(this.toolStripButtonSetTriggerS_Click);
            // 
            // TextTriggerSource
            // 
            this.TextTriggerSource.Name = "TextTriggerSource";
            this.TextTriggerSource.ReadOnly = true;
            this.TextTriggerSource.Size = new System.Drawing.Size(75, 25);
            this.TextTriggerSource.Click += new System.EventHandler(this.probetoolStripComboBox_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(76, 22);
            this.toolStripLabel3.Text = "  Record Time:";
            // 
            // toolStripRecordTime
            // 
            this.toolStripRecordTime.MaxLength = 5;
            this.toolStripRecordTime.Name = "toolStripRecordTime";
            this.toolStripRecordTime.Size = new System.Drawing.Size(50, 25);
            this.toolStripRecordTime.Text = "20";
            this.toolStripRecordTime.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel4.Text = "s";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // calctoolStripButton
            // 
            this.calctoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.calctoolStripButton.Enabled = false;
            this.calctoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("calctoolStripButton.Image")));
            this.calctoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.calctoolStripButton.Name = "calctoolStripButton";
            this.calctoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.calctoolStripButton.Text = "RMS/Average Calculator";
            this.calctoolStripButton.Click += new System.EventHandler(this.calctoolStripButton_Click);
            // 
            // powertoolStripButton
            // 
            this.powertoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.powertoolStripButton.Enabled = false;
            this.powertoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("powertoolStripButton.Image")));
            this.powertoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.powertoolStripButton.Name = "powertoolStripButton";
            this.powertoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.powertoolStripButton.Text = "Power Chart";
            this.powertoolStripButton.Click += new System.EventHandler(this.powertoolStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // ZoomBackToolstripButton
            // 
            this.ZoomBackToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomBackToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomBackToolstripButton.Image")));
            this.ZoomBackToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomBackToolstripButton.Name = "ZoomBackToolstripButton";
            this.ZoomBackToolstripButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomBackToolstripButton.Text = "Undo Zoom";
            this.ZoomBackToolstripButton.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // ZoomOutAlltoolStripButton
            // 
            this.ZoomOutAlltoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutAlltoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOutAlltoolStripButton.Image")));
            this.ZoomOutAlltoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutAlltoolStripButton.Name = "ZoomOutAlltoolStripButton";
            this.ZoomOutAlltoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomOutAlltoolStripButton.Text = "Zoom Out All";
            this.ZoomOutAlltoolStripButton.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(788, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel.Text = "disconnected";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hid_search
            // 
            this.hid_search.Enabled = true;
            this.hid_search.Interval = 2000;
            this.hid_search.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 562);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIParent1_FormClosing);
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.MdiChildActivate += new System.EventHandler(this.MDIParent1_MdiChildActivate);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScaleMenu;
        private System.Windows.Forms.ToolStripMenuItem scalepowermeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        //public System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softwareUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rMSCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStriptrigger_threshold;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox toolStripRecordTime;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton PlayStripButton;
        private System.Windows.Forms.ToolStripButton StopStripButton;
        private System.Windows.Forms.ToolStripButton RecordStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton calctoolStripButton;
        private System.Windows.Forms.ToolStripButton powertoolStripButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem powerChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton ZoomBackToolstripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton ZoomOutAlltoolStripButton;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton saveasimagetoolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem saveAsImageToolStripMenuItem;
        private System.Windows.Forms.Timer hid_search;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetTriggerS;
        public System.Windows.Forms.ToolStripTextBox TextTriggerSource;
    }
}



