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
            this.Button2 = new System.Windows.Forms.Button();
            this.Stromlabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.calc = new System.Windows.Forms.Button();
            this.scale_cc = new System.Windows.Forms.TextBox();
            this.scale_ch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scale_v = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Check_Values = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Button2
            // 
            this.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button2.Location = new System.Drawing.Point(151, 82);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(23, 36);
            this.Button2.TabIndex = 12;
            this.Button2.Text = "»";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Stromlabel
            // 
            this.Stromlabel.AutoSize = true;
            this.Stromlabel.Location = new System.Drawing.Point(9, 75);
            this.Stromlabel.Name = "Stromlabel";
            this.Stromlabel.Size = new System.Drawing.Size(135, 13);
            this.Stromlabel.TabIndex = 11;
            this.Stromlabel.Text = "Scale Value Current Shunt:";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(151, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 36);
            this.button1.TabIndex = 15;
            this.button1.Text = "»";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Scale Value Current HAL:";
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(199, 86);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(119, 32);
            this.calc.TabIndex = 22;
            this.calc.Text = "Calculate Scale Value";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // scale_cc
            // 
            this.scale_cc.Location = new System.Drawing.Point(12, 91);
            this.scale_cc.Name = "scale_cc";
            this.scale_cc.Size = new System.Drawing.Size(122, 20);
            this.scale_cc.TabIndex = 23;
            this.scale_cc.TextChanged += new System.EventHandler(this.scale_cc_TextChanged);
            // 
            // scale_ch
            // 
            this.scale_ch.Location = new System.Drawing.Point(12, 159);
            this.scale_ch.Name = "scale_ch";
            this.scale_ch.Size = new System.Drawing.Size(122, 20);
            this.scale_ch.TabIndex = 24;
            this.scale_ch.TextChanged += new System.EventHandler(this.scale_ch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Scale Value Voltage:";
            // 
            // scale_v
            // 
            this.scale_v.Location = new System.Drawing.Point(12, 231);
            this.scale_v.Name = "scale_v";
            this.scale_v.Size = new System.Drawing.Size(122, 20);
            this.scale_v.TabIndex = 25;
            this.scale_v.TextChanged += new System.EventHandler(this.scale_v_TextChanged);
            // 
            // button3
            // 
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(151, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 36);
            this.button3.TabIndex = 26;
            this.button3.Text = "»";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(211, 146);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 27;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Hall active";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(211, 178);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 28;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Shunt active";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(211, 210);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(91, 17);
            this.radioButton3.TabIndex = 29;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "auto detected";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 20);
            this.textBox1.TabIndex = 31;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
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
            // Stromscale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 266);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.scale_v);
            this.Controls.Add(this.scale_ch);
            this.Controls.Add(this.scale_cc);
            this.Controls.Add(this.calc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Stromlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stromscale";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scale Values";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Stromscale_FormClosing);
            this.Load += new System.EventHandler(this.Stromscale_Load);
            this.Resize += new System.EventHandler(this.Stromscale_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Label Stromlabel;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calc;
        public System.Windows.Forms.TextBox scale_cc;
        public System.Windows.Forms.TextBox scale_ch;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox scale_v;
        internal System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer Check_Values;
    }
}