namespace Leistungsmesser_C
{
    partial class INA1_Power
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INA1_Power));
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(12, 12);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(858, 577);
            this.zg1.TabIndex = 0;
            this.zg1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zg1_PointValueEvent);
            this.zg1.Load += new System.EventHandler(this.zg1_Load);
            // 
            // INA1_Power
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 637);
            this.Controls.Add(this.zg1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "INA1_Power";
            this.Text = "Probe 1 Power";
            this.Load += new System.EventHandler(this.INA1_Power_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.INA1_Power_Paint);
            this.Resize += new System.EventHandler(this.INA1_Power_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public ZedGraph.ZedGraphControl zg1;

    }
}