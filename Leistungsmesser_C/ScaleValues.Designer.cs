namespace Leistungsmesser_C
{
    partial class Stromscale
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
            this.label2 = new System.Windows.Forms.Label();
            this.scale_v = new System.Windows.Forms.TextBox();
            this.buttonWriteV = new System.Windows.Forms.Button();
            this.HallradioButton = new System.Windows.Forms.RadioButton();
            this.ShuntradioButton = new System.Windows.Forms.RadioButton();
            this.BothradioButton = new System.Windows.Forms.RadioButton();
            this.textBoxNickname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Check_Values = new System.Windows.Forms.Timer(this.components);
            this.ShuntOptions = new System.Windows.Forms.GroupBox();
            this.buttonWriteCC = new System.Windows.Forms.Button();
            this.scale_cc = new System.Windows.Forms.TextBox();
            this.Stromlabel = new System.Windows.Forms.Label();
            this.DINShuntradioButton = new System.Windows.Forms.RadioButton();
            this.ResistanceradioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxResistance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDINVoltage = new System.Windows.Forms.TextBox();
            this.textBoxDINCurrent = new System.Windows.Forms.TextBox();
            this.HallOptions = new System.Windows.Forms.GroupBox();
            this.hallsensorlistbox = new System.Windows.Forms.ListBox();
            this.scale_ch = new System.Windows.Forms.TextBox();
            this.buttonWriteCH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoadDefault = new System.Windows.Forms.Button();
            this.ShuntOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.HallOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Scale Voltage:";
            // 
            // scale_v
            // 
            this.scale_v.Location = new System.Drawing.Point(12, 282);
            this.scale_v.Name = "scale_v";
            this.scale_v.Size = new System.Drawing.Size(122, 20);
            this.scale_v.TabIndex = 25;
            this.scale_v.TextChanged += new System.EventHandler(this.scale_v_TextChanged);
            // 
            // buttonWriteV
            // 
            this.buttonWriteV.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonWriteV.Location = new System.Drawing.Point(12, 316);
            this.buttonWriteV.Name = "buttonWriteV";
            this.buttonWriteV.Size = new System.Drawing.Size(122, 22);
            this.buttonWriteV.TabIndex = 26;
            this.buttonWriteV.Text = "Write Value";
            this.buttonWriteV.UseVisualStyleBackColor = true;
            this.buttonWriteV.Click += new System.EventHandler(this.buttonWriteV_Click);
            // 
            // HallradioButton
            // 
            this.HallradioButton.AutoSize = true;
            this.HallradioButton.Location = new System.Drawing.Point(630, 9);
            this.HallradioButton.Name = "HallradioButton";
            this.HallradioButton.Size = new System.Drawing.Size(75, 17);
            this.HallradioButton.TabIndex = 27;
            this.HallradioButton.TabStop = true;
            this.HallradioButton.Text = "Hall active";
            this.HallradioButton.UseVisualStyleBackColor = true;
            this.HallradioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ShuntradioButton
            // 
            this.ShuntradioButton.AutoSize = true;
            this.ShuntradioButton.Location = new System.Drawing.Point(165, 9);
            this.ShuntradioButton.Name = "ShuntradioButton";
            this.ShuntradioButton.Size = new System.Drawing.Size(85, 17);
            this.ShuntradioButton.TabIndex = 28;
            this.ShuntradioButton.TabStop = true;
            this.ShuntradioButton.Text = "Shunt active";
            this.ShuntradioButton.UseVisualStyleBackColor = true;
            this.ShuntradioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // BothradioButton
            // 
            this.BothradioButton.AutoSize = true;
            this.BothradioButton.Location = new System.Drawing.Point(426, 9);
            this.BothradioButton.Name = "BothradioButton";
            this.BothradioButton.Size = new System.Drawing.Size(161, 17);
            this.BothradioButton.TabIndex = 29;
            this.BothradioButton.TabStop = true;
            this.BothradioButton.Text = "auto detected (Hall or Shunt)";
            this.BothradioButton.UseVisualStyleBackColor = true;
            this.BothradioButton.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // textBoxNickname
            // 
            this.textBoxNickname.Location = new System.Drawing.Point(12, 26);
            this.textBoxNickname.MaxLength = 20;
            this.textBoxNickname.Name = "textBoxNickname";
            this.textBoxNickname.Size = new System.Drawing.Size(122, 20);
            this.textBoxNickname.TabIndex = 31;
            this.textBoxNickname.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Nickname:";
            // 
            // Check_Values
            // 
            this.Check_Values.Enabled = true;
            this.Check_Values.Tick += new System.EventHandler(this.Check_Values_Tick);
            // 
            // ShuntOptions
            // 
            this.ShuntOptions.Controls.Add(this.buttonWriteCC);
            this.ShuntOptions.Controls.Add(this.scale_cc);
            this.ShuntOptions.Controls.Add(this.Stromlabel);
            this.ShuntOptions.Controls.Add(this.DINShuntradioButton);
            this.ShuntOptions.Controls.Add(this.ResistanceradioButton);
            this.ShuntOptions.Controls.Add(this.groupBox2);
            this.ShuntOptions.Controls.Add(this.groupBox1);
            this.ShuntOptions.Location = new System.Drawing.Point(165, 26);
            this.ShuntOptions.Name = "ShuntOptions";
            this.ShuntOptions.Size = new System.Drawing.Size(336, 318);
            this.ShuntOptions.TabIndex = 39;
            this.ShuntOptions.TabStop = false;
            // 
            // buttonWriteCC
            // 
            this.buttonWriteCC.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonWriteCC.Location = new System.Drawing.Point(110, 290);
            this.buttonWriteCC.Name = "buttonWriteCC";
            this.buttonWriteCC.Size = new System.Drawing.Size(122, 22);
            this.buttonWriteCC.TabIndex = 45;
            this.buttonWriteCC.Text = "Write Value";
            this.buttonWriteCC.UseVisualStyleBackColor = true;
            this.buttonWriteCC.Click += new System.EventHandler(this.buttonWriteCC_Click);
            // 
            // scale_cc
            // 
            this.scale_cc.Location = new System.Drawing.Point(110, 256);
            this.scale_cc.Name = "scale_cc";
            this.scale_cc.Size = new System.Drawing.Size(122, 20);
            this.scale_cc.TabIndex = 44;
            // 
            // Stromlabel
            // 
            this.Stromlabel.AutoSize = true;
            this.Stromlabel.Location = new System.Drawing.Point(105, 240);
            this.Stromlabel.Name = "Stromlabel";
            this.Stromlabel.Size = new System.Drawing.Size(105, 13);
            this.Stromlabel.TabIndex = 43;
            this.Stromlabel.Text = "Scale Current Shunt:";
            // 
            // DINShuntradioButton
            // 
            this.DINShuntradioButton.AutoSize = true;
            this.DINShuntradioButton.Checked = true;
            this.DINShuntradioButton.Location = new System.Drawing.Point(10, 21);
            this.DINShuntradioButton.Name = "DINShuntradioButton";
            this.DINShuntradioButton.Size = new System.Drawing.Size(75, 17);
            this.DINShuntradioButton.TabIndex = 41;
            this.DINShuntradioButton.TabStop = true;
            this.DINShuntradioButton.Text = "DIN Shunt";
            this.DINShuntradioButton.UseVisualStyleBackColor = true;
            this.DINShuntradioButton.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // ResistanceradioButton
            // 
            this.ResistanceradioButton.AutoSize = true;
            this.ResistanceradioButton.Location = new System.Drawing.Point(11, 132);
            this.ResistanceradioButton.Name = "ResistanceradioButton";
            this.ResistanceradioButton.Size = new System.Drawing.Size(78, 17);
            this.ResistanceradioButton.TabIndex = 42;
            this.ResistanceradioButton.Text = "Resistance";
            this.ResistanceradioButton.UseVisualStyleBackColor = true;
            this.ResistanceradioButton.CheckedChanged += new System.EventHandler(this.ResistanceradioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxResistance);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(9, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 86);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // textBoxResistance
            // 
            this.textBoxResistance.Enabled = false;
            this.textBoxResistance.Location = new System.Drawing.Point(99, 41);
            this.textBoxResistance.MaxLength = 10;
            this.textBoxResistance.Name = "textBoxResistance";
            this.textBoxResistance.Size = new System.Drawing.Size(122, 20);
            this.textBoxResistance.TabIndex = 8;
            this.textBoxResistance.Text = " mΩ";
            this.textBoxResistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxResistance.TextChanged += new System.EventHandler(this.resist_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Resistance";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxDINVoltage);
            this.groupBox1.Controls.Add(this.textBoxDINCurrent);
            this.groupBox1.Location = new System.Drawing.Point(9, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 85);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(184, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Standardized Voltage";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Standardized Current";
            // 
            // textBoxDINVoltage
            // 
            this.textBoxDINVoltage.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDINVoltage.Location = new System.Drawing.Point(173, 41);
            this.textBoxDINVoltage.MaxLength = 10;
            this.textBoxDINVoltage.Name = "textBoxDINVoltage";
            this.textBoxDINVoltage.Size = new System.Drawing.Size(122, 20);
            this.textBoxDINVoltage.TabIndex = 3;
            this.textBoxDINVoltage.Text = " mV";
            this.textBoxDINVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDINVoltage.TextChanged += new System.EventHandler(this.spannung_TextChanged);
            // 
            // textBoxDINCurrent
            // 
            this.textBoxDINCurrent.Location = new System.Drawing.Point(25, 41);
            this.textBoxDINCurrent.MaxLength = 10;
            this.textBoxDINCurrent.Name = "textBoxDINCurrent";
            this.textBoxDINCurrent.Size = new System.Drawing.Size(122, 20);
            this.textBoxDINCurrent.TabIndex = 2;
            this.textBoxDINCurrent.Text = " A";
            this.textBoxDINCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDINCurrent.TextChanged += new System.EventHandler(this.strom_TextChanged);
            // 
            // HallOptions
            // 
            this.HallOptions.Controls.Add(this.hallsensorlistbox);
            this.HallOptions.Controls.Add(this.scale_ch);
            this.HallOptions.Controls.Add(this.buttonWriteCH);
            this.HallOptions.Controls.Add(this.label1);
            this.HallOptions.Location = new System.Drawing.Point(507, 26);
            this.HallOptions.Name = "HallOptions";
            this.HallOptions.Size = new System.Drawing.Size(198, 318);
            this.HallOptions.TabIndex = 40;
            this.HallOptions.TabStop = false;
            // 
            // hallsensorlistbox
            // 
            this.hallsensorlistbox.FormattingEnabled = true;
            this.hallsensorlistbox.Location = new System.Drawing.Point(18, 43);
            this.hallsensorlistbox.Name = "hallsensorlistbox";
            this.hallsensorlistbox.Size = new System.Drawing.Size(163, 95);
            this.hallsensorlistbox.TabIndex = 28;
            this.hallsensorlistbox.SelectedIndexChanged += new System.EventHandler(this.hallsensorlistbox_SelectedIndexChanged);
            // 
            // scale_ch
            // 
            this.scale_ch.Location = new System.Drawing.Point(40, 256);
            this.scale_ch.Name = "scale_ch";
            this.scale_ch.Size = new System.Drawing.Size(122, 20);
            this.scale_ch.TabIndex = 27;
            // 
            // buttonWriteCH
            // 
            this.buttonWriteCH.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonWriteCH.Location = new System.Drawing.Point(40, 288);
            this.buttonWriteCH.Name = "buttonWriteCH";
            this.buttonWriteCH.Size = new System.Drawing.Size(122, 22);
            this.buttonWriteCH.TabIndex = 26;
            this.buttonWriteCH.Text = "Write Value";
            this.buttonWriteCH.UseVisualStyleBackColor = true;
            this.buttonWriteCH.Click += new System.EventHandler(this.buttonWriteCH_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Scale Current Hall:";
            // 
            // buttonLoadDefault
            // 
            this.buttonLoadDefault.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonLoadDefault.Location = new System.Drawing.Point(12, 235);
            this.buttonLoadDefault.Name = "buttonLoadDefault";
            this.buttonLoadDefault.Size = new System.Drawing.Size(122, 22);
            this.buttonLoadDefault.TabIndex = 41;
            this.buttonLoadDefault.Text = "Load Default Voltage";
            this.buttonLoadDefault.UseVisualStyleBackColor = true;
            this.buttonLoadDefault.Click += new System.EventHandler(this.buttonLoadDefault_Click);
            // 
            // Stromscale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 354);
            this.Controls.Add(this.buttonLoadDefault);
            this.Controls.Add(this.HallOptions);
            this.Controls.Add(this.ShuntOptions);
            this.Controls.Add(this.textBoxNickname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BothradioButton);
            this.Controls.Add(this.buttonWriteV);
            this.Controls.Add(this.ShuntradioButton);
            this.Controls.Add(this.HallradioButton);
            this.Controls.Add(this.scale_v);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stromscale";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scale Values";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Stromscale_Load);
            this.Resize += new System.EventHandler(this.Stromscale_Resize);
            this.ShuntOptions.ResumeLayout(false);
            this.ShuntOptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.HallOptions.ResumeLayout(false);
            this.HallOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox scale_v;
        internal System.Windows.Forms.Button buttonWriteV;
        private System.Windows.Forms.RadioButton HallradioButton;
        private System.Windows.Forms.RadioButton ShuntradioButton;
        private System.Windows.Forms.RadioButton BothradioButton;
        public System.Windows.Forms.TextBox textBoxNickname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer Check_Values;
        private System.Windows.Forms.GroupBox ShuntOptions;
        internal System.Windows.Forms.Button buttonWriteCC;
        public System.Windows.Forms.TextBox scale_cc;
        private System.Windows.Forms.Label Stromlabel;
        private System.Windows.Forms.RadioButton DINShuntradioButton;
        private System.Windows.Forms.RadioButton ResistanceradioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxResistance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxDINVoltage;
        private System.Windows.Forms.TextBox textBoxDINCurrent;
        private System.Windows.Forms.GroupBox HallOptions;
        private System.Windows.Forms.ListBox hallsensorlistbox;
        public System.Windows.Forms.TextBox scale_ch;
        internal System.Windows.Forms.Button buttonWriteCH;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button buttonLoadDefault;
    }
}