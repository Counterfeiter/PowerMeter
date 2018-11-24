namespace Leistungsmesser_C
{
    partial class Debug_Form
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
            this.Recived = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Recived
            // 
            this.Recived.Location = new System.Drawing.Point(12, 12);
            this.Recived.Multiline = true;
            this.Recived.Name = "Recived";
            this.Recived.ReadOnly = true;
            this.Recived.Size = new System.Drawing.Size(813, 536);
            this.Recived.TabIndex = 10;
            // 
            // Debug_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 560);
            this.Controls.Add(this.Recived);
            this.Name = "Debug_Form";
            this.Text = "Debug";
            this.Load += new System.EventHandler(this.Debug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox Recived;
    }
}