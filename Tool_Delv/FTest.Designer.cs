namespace AP_C
{
    partial class FTest
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
            this.tx02 = new System.Windows.Forms.TextBox();
            this.tx01 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tx02
            // 
            this.tx02.Location = new System.Drawing.Point(383, 51);
            this.tx02.Multiline = true;
            this.tx02.Name = "tx02";
            this.tx02.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tx02.Size = new System.Drawing.Size(272, 358);
            this.tx02.TabIndex = 6;
            // 
            // tx01
            // 
            this.tx01.Location = new System.Drawing.Point(12, 51);
            this.tx01.Multiline = true;
            this.tx01.Name = "tx01";
            this.tx01.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tx01.Size = new System.Drawing.Size(342, 358);
            this.tx01.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnIssueAvgPrice_Click);
            // 
            // FTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 421);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tx01);
            this.Controls.Add(this.tx02);
            this.Name = "FTest";
            this.Text = "FTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx02;
        private System.Windows.Forms.TextBox tx01;
        private System.Windows.Forms.Button button1;
    }
}