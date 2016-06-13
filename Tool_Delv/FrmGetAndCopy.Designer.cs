namespace AP_C
{
    partial class FrmGetAndCopy
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
            this.txdest = new System.Windows.Forms.TextBox();
            this.txsrc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txdest
            // 
            this.txdest.Location = new System.Drawing.Point(97, 46);
            this.txdest.Margin = new System.Windows.Forms.Padding(4);
            this.txdest.Name = "txdest";
            this.txdest.Size = new System.Drawing.Size(528, 25);
            this.txdest.TabIndex = 31;
            this.txdest.Text = "D:\\9-other\\Desktop\\wechat";
            // 
            // txsrc
            // 
            this.txsrc.Location = new System.Drawing.Point(97, 13);
            this.txsrc.Margin = new System.Windows.Forms.Padding(4);
            this.txsrc.Name = "txsrc";
            this.txsrc.Size = new System.Drawing.Size(528, 25);
            this.txsrc.TabIndex = 30;
            this.txsrc.Text = "D:\\9-other\\Desktop\\f8494bd2a57b5f51062a1357466f8f0c";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 29;
            this.label6.Text = "輸入src path";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(515, 113);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 29);
            this.button4.TabIndex = 28;
            this.button4.Text = "找出mp4和arm";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "輸入dest path";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 171);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(528, 25);
            this.textBox1.TabIndex = 34;
            this.textBox1.Text = "D:\\Dropbox\\Una_Code\\YFY\\YFY_POS\\YFY_POS_Main\\bin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "輸入src path";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 204);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(877, 341);
            this.textBox2.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 171);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 36;
            this.button1.Text = "step1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnStep1ForYFYCN_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(648, 171);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 37;
            this.button2.Text = "step2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnStep2ForYFYCN_Click);
            // 
            // FrmGetAndCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 558);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txdest);
            this.Controls.Add(this.txsrc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Name = "FrmGetAndCopy";
            this.Text = "FrmGetAndCopy";
            this.Load += new System.EventHandler(this.FrmGetAndCopy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txdest;
        private System.Windows.Forms.TextBox txsrc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}