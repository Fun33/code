namespace AP_C.v1
{
    partial class FB1iSN3
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FB1iSN3));
            this.tx_desc = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button45 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tx01 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage7.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tx_desc
            // 
            this.tx_desc.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tx_desc.Location = new System.Drawing.Point(9, 8);
            this.tx_desc.Margin = new System.Windows.Forms.Padding(2);
            this.tx_desc.Multiline = true;
            this.tx_desc.Name = "tx_desc";
            this.tx_desc.Size = new System.Drawing.Size(204, 98);
            this.tx_desc.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBox1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "//GetXLS",
            "//0-normal",
            "//1-if 0 no mapping.",
            "//-1-if -1 no mapping",
            "//2-if \'\'  no mapping",
            "//3-default",
            "//9-special",
            "",
            "1.click get type",
            "2.edit type udf be 1,2,3",
            "3.click cell 2 xml",
            "4.產出",
            "",
            "有效值.預設",
            ">來源是null,給空白.>ERROR.因為沒有這個值.",
            "來源如果是數字,然後沒有給值,它的預設是0",
            "來源如果是文字,然後沒有給值,它的預設是null,讀到會是空白.",
            "",
            "",
            "當值來到UDF,會遇到的問題",
            "UDF,無有效值,必要欄位,(請給預設值)",
            ">來源無.不做對應.--給預設值(數字給數字.文字給文字)",
            ">來源有.直接對應",
            "",
            "UDF,有有效值,非必要.",
            ">來源無.不可對應",
            ">來源有.需為有效值",
            "",
            "UDF,有有效值,必要.",
            ">來源無.不可對應",
            ">來源有.需為有效值",
            "",
            "UDF若有固定值+非必填,文字,",
            ">需判斷.若為空白,不做對應",
            "3.UDF若有固定值+非必填,數字,需判斷.若為0,不做對應"});
            this.listBox1.Location = new System.Drawing.Point(235, 9);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(405, 84);
            this.listBox1.TabIndex = 9;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.button28);
            this.tabPage7.Controls.Add(this.button29);
            this.tabPage7.Controls.Add(this.button30);
            this.tabPage7.Controls.Add(this.button31);
            this.tabPage7.Controls.Add(this.button32);
            this.tabPage7.Controls.Add(this.button33);
            this.tabPage7.Controls.Add(this.button34);
            this.tabPage7.Controls.Add(this.button35);
            this.tabPage7.Controls.Add(this.button36);
            this.tabPage7.Controls.Add(this.button37);
            this.tabPage7.Controls.Add(this.button38);
            this.tabPage7.Controls.Add(this.button39);
            this.tabPage7.Controls.Add(this.button40);
            this.tabPage7.Controls.Add(this.button41);
            this.tabPage7.Controls.Add(this.button42);
            this.tabPage7.Controls.Add(this.button43);
            this.tabPage7.Controls.Add(this.button44);
            this.tabPage7.Controls.Add(this.button45);
            this.tabPage7.Controls.Add(this.textBox2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(747, 343);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Item";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox2.Location = new System.Drawing.Point(13, 100);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(707, 232);
            this.textBox2.TabIndex = 44;
            // 
            // button45
            // 
            this.button45.Location = new System.Drawing.Point(13, 11);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(115, 23);
            this.button45.TabIndex = 45;
            this.button45.Text = "OCRD";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.button45_Click);
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(134, 11);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(115, 23);
            this.button44.TabIndex = 46;
            this.button44.Text = "CRD1 - BPAddresses";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.button44_Click);
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(255, 11);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(115, 23);
            this.button43.TabIndex = 47;
            this.button43.Text = "CRD2 - BPPaymentMethods";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.button43_Click);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(376, 11);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(115, 23);
            this.button42.TabIndex = 48;
            this.button42.Text = "CRD3 - BPAccountReceivablePayble";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Click += new System.EventHandler(this.button42_Click);
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(497, 11);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(115, 23);
            this.button41.TabIndex = 49;
            this.button41.Text = "CRD5 - BPPaymentDates";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(618, 11);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(115, 23);
            this.button40.TabIndex = 50;
            this.button40.Text = "OCPR - ContactEmployees";
            this.button40.UseVisualStyleBackColor = true;
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(13, 40);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(115, 23);
            this.button39.TabIndex = 51;
            this.button39.Text = "OCRB - BPBankAccounts";
            this.button39.UseVisualStyleBackColor = true;
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(134, 40);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(115, 23);
            this.button38.TabIndex = 52;
            this.button38.Text = "button38";
            this.button38.UseVisualStyleBackColor = true;
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(255, 40);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(115, 23);
            this.button37.TabIndex = 53;
            this.button37.Text = "button37";
            this.button37.UseVisualStyleBackColor = true;
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(376, 40);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(115, 23);
            this.button36.TabIndex = 54;
            this.button36.Text = "button36";
            this.button36.UseVisualStyleBackColor = true;
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(497, 40);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(115, 23);
            this.button35.TabIndex = 55;
            this.button35.Text = "button35";
            this.button35.UseVisualStyleBackColor = true;
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(618, 40);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(115, 23);
            this.button34.TabIndex = 56;
            this.button34.Text = "button34";
            this.button34.UseVisualStyleBackColor = true;
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(13, 72);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(115, 23);
            this.button33.TabIndex = 57;
            this.button33.Text = "button33";
            this.button33.UseVisualStyleBackColor = true;
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(134, 72);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(115, 23);
            this.button32.TabIndex = 58;
            this.button32.Text = "button32";
            this.button32.UseVisualStyleBackColor = true;
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(255, 72);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(115, 23);
            this.button31.TabIndex = 59;
            this.button31.Text = "button31";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(376, 72);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(115, 23);
            this.button30.TabIndex = 60;
            this.button30.Text = "button30";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(497, 72);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(115, 23);
            this.button29.TabIndex = 61;
            this.button29.Text = "button29";
            this.button29.UseVisualStyleBackColor = true;
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(618, 72);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(115, 23);
            this.button28.TabIndex = 62;
            this.button28.Text = "button28";
            this.button28.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button21);
            this.tabPage6.Controls.Add(this.button15);
            this.tabPage6.Controls.Add(this.button16);
            this.tabPage6.Controls.Add(this.button12);
            this.tabPage6.Controls.Add(this.button13);
            this.tabPage6.Controls.Add(this.button11);
            this.tabPage6.Controls.Add(this.button10);
            this.tabPage6.Controls.Add(this.tx01);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(747, 343);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "BP";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tx01
            // 
            this.tx01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tx01.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tx01.Location = new System.Drawing.Point(19, 64);
            this.tx01.Margin = new System.Windows.Forms.Padding(2);
            this.tx01.Multiline = true;
            this.tx01.Name = "tx01";
            this.tx01.Size = new System.Drawing.Size(707, 264);
            this.tx01.TabIndex = 25;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(19, 7);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(115, 23);
            this.button10.TabIndex = 26;
            this.button10.Text = "OCRD";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.BtnOCRD_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(140, 7);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(115, 23);
            this.button11.TabIndex = 27;
            this.button11.Text = "CRD1 - BPAddresses";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.BtnCRD1_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(261, 7);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(205, 23);
            this.button13.TabIndex = 28;
            this.button13.Text = "CRD2 - BPPaymentMethods";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.BtnCRD2_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(485, 7);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(205, 23);
            this.button12.TabIndex = 29;
            this.button12.Text = "CRD3 - BPAccountReceivablePayble";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.BtnCRD3_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(19, 36);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(160, 23);
            this.button16.TabIndex = 30;
            this.button16.Text = "CRD5 - BPPaymentDates";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.BtnCRD5_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(185, 36);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(160, 23);
            this.button15.TabIndex = 31;
            this.button15.Text = "OCPR - ContactEmployees";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.BtnOCPR_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(351, 36);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(160, 23);
            this.button21.TabIndex = 32;
            this.button21.Text = "OCRB - BPBankAccounts";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.BtnOCRB_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(16, 110);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 369);
            this.tabControl1.TabIndex = 1;
            // 
            // B1iSN3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(782, 490);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tx_desc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "B1iSN3";
            this.Text = "Tool_B1iSN";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx_desc;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button40;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Button button43;
        private System.Windows.Forms.Button button44;
        private System.Windows.Forms.Button button45;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox tx01;
        private System.Windows.Forms.TabControl tabControl1;
    }
}