namespace Panbor_ImportWebSO
{
    partial class ChangePwd
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
            this.TextPwd1 = new WinUI_Helper.XenTextBox();
            this.TextPwd2 = new WinUI_Helper.XenTextBox();
            this.xenLabel1 = new WinUI_Helper.XenLabel();
            this.xenLabel2 = new WinUI_Helper.XenLabel();
            this.xenButton1 = new WinUI_Helper.XenButton();
            this.xenButton2 = new WinUI_Helper.XenButton();
            this.xenLabel3 = new WinUI_Helper.XenLabel();
            this.xenLabel4 = new WinUI_Helper.XenLabel();
            this.xenLabel5 = new WinUI_Helper.XenLabel();
            this.xenLabel6 = new WinUI_Helper.XenLabel();
            this.xenTextBox3 = new WinUI_Helper.XenTextBox();
            this.SuspendLayout();
            // 
            // TextPwd1
            // 
            this.TextPwd1.BackColor = System.Drawing.Color.White;
            this.TextPwd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextPwd1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextPwd1.Location = new System.Drawing.Point(160, 143);
            this.TextPwd1.Name = "TextPwd1";
            this.TextPwd1.PasswordChar = '*';
            this.TextPwd1.ReadOnlyBackColor = System.Drawing.Color.White;
            this.TextPwd1.Size = new System.Drawing.Size(100, 26);
            this.TextPwd1.TabIndex = 0;
            // 
            // TextPwd2
            // 
            this.TextPwd2.BackColor = System.Drawing.Color.White;
            this.TextPwd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextPwd2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextPwd2.Location = new System.Drawing.Point(160, 172);
            this.TextPwd2.Name = "TextPwd2";
            this.TextPwd2.PasswordChar = '*';
            this.TextPwd2.ReadOnlyBackColor = System.Drawing.Color.White;
            this.TextPwd2.Size = new System.Drawing.Size(100, 26);
            this.TextPwd2.TabIndex = 1;
            // 
            // xenLabel1
            // 
            this.xenLabel1.AutoSize = true;
            this.xenLabel1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel1.Location = new System.Drawing.Point(16, 143);
            this.xenLabel1.Name = "xenLabel1";
            this.xenLabel1.Size = new System.Drawing.Size(41, 20);
            this.xenLabel1.TabIndex = 2;
            this.xenLabel1.Text = "密碼";
            // 
            // xenLabel2
            // 
            this.xenLabel2.AutoSize = true;
            this.xenLabel2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel2.Location = new System.Drawing.Point(14, 172);
            this.xenLabel2.Name = "xenLabel2";
            this.xenLabel2.Size = new System.Drawing.Size(41, 20);
            this.xenLabel2.TabIndex = 3;
            this.xenLabel2.Text = "確認";
            // 
            // xenButton1
            // 
            this.xenButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.xenButton1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenButton1.Location = new System.Drawing.Point(18, 228);
            this.xenButton1.Name = "xenButton1";
            this.xenButton1.Size = new System.Drawing.Size(85, 30);
            this.xenButton1.TabIndex = 4;
            this.xenButton1.Text = "確定";
            this.xenButton1.UseVisualStyleBackColor = true;
            this.xenButton1.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // xenButton2
            // 
            this.xenButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.xenButton2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenButton2.Location = new System.Drawing.Point(175, 228);
            this.xenButton2.Name = "xenButton2";
            this.xenButton2.Size = new System.Drawing.Size(85, 30);
            this.xenButton2.TabIndex = 5;
            this.xenButton2.Text = "取消";
            this.xenButton2.UseVisualStyleBackColor = true;
            this.xenButton2.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // xenLabel3
            // 
            this.xenLabel3.AutoSize = true;
            this.xenLabel3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel3.Location = new System.Drawing.Point(14, 9);
            this.xenLabel3.Name = "xenLabel3";
            this.xenLabel3.Size = new System.Drawing.Size(249, 20);
            this.xenLabel3.TabIndex = 6;
            this.xenLabel3.Text = "選擇遵守貴公司密碼原則的新密碼";
            // 
            // xenLabel4
            // 
            this.xenLabel4.AutoSize = true;
            this.xenLabel4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel4.Location = new System.Drawing.Point(16, 32);
            this.xenLabel4.Name = "xenLabel4";
            this.xenLabel4.Size = new System.Drawing.Size(109, 20);
            this.xenLabel4.TabIndex = 7;
            this.xenLabel4.Text = "密碼必須包含:";
            // 
            // xenLabel5
            // 
            this.xenLabel5.AutoSize = true;
            this.xenLabel5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel5.Location = new System.Drawing.Point(14, 55);
            this.xenLabel5.Name = "xenLabel5";
            this.xenLabel5.Size = new System.Drawing.Size(132, 20);
            this.xenLabel5.TabIndex = 8;
            this.xenLabel5.Text = "最少長度4個字元.";
            // 
            // xenLabel6
            // 
            this.xenLabel6.AutoSize = true;
            this.xenLabel6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel6.Location = new System.Drawing.Point(14, 98);
            this.xenLabel6.Name = "xenLabel6";
            this.xenLabel6.Size = new System.Drawing.Size(77, 20);
            this.xenLabel6.TabIndex = 10;
            this.xenLabel6.Text = "密碼範例:";
            // 
            // xenTextBox3
            // 
            this.xenTextBox3.BackColor = System.Drawing.Color.White;
            this.xenTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xenTextBox3.Enabled = false;
            this.xenTextBox3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenTextBox3.Location = new System.Drawing.Point(162, 98);
            this.xenTextBox3.Name = "xenTextBox3";
            this.xenTextBox3.ReadOnlyBackColor = System.Drawing.Color.White;
            this.xenTextBox3.Size = new System.Drawing.Size(100, 26);
            this.xenTextBox3.TabIndex = 9;
            this.xenTextBox3.Text = "abcd";
            // 
            // ChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 270);
            this.Controls.Add(this.xenLabel6);
            this.Controls.Add(this.xenTextBox3);
            this.Controls.Add(this.xenLabel5);
            this.Controls.Add(this.xenLabel4);
            this.Controls.Add(this.xenLabel3);
            this.Controls.Add(this.xenButton2);
            this.Controls.Add(this.xenButton1);
            this.Controls.Add(this.xenLabel2);
            this.Controls.Add(this.xenLabel1);
            this.Controls.Add(this.TextPwd2);
            this.Controls.Add(this.TextPwd1);
            this.Name = "ChangePwd";
            this.Text = "ChangePwd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinUI_Helper.XenTextBox TextPwd1;
        private WinUI_Helper.XenTextBox TextPwd2;
        private WinUI_Helper.XenLabel xenLabel1;
        private WinUI_Helper.XenLabel xenLabel2;
        private WinUI_Helper.XenButton xenButton1;
        private WinUI_Helper.XenButton xenButton2;
        private WinUI_Helper.XenLabel xenLabel3;
        private WinUI_Helper.XenLabel xenLabel4;
        private WinUI_Helper.XenLabel xenLabel5;
        private WinUI_Helper.XenLabel xenLabel6;
        private WinUI_Helper.XenTextBox xenTextBox3;
    }
}