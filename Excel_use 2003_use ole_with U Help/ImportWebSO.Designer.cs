namespace Panbor_ImportWebSO
{
    partial class ImportWebSO
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
            this.xenLabel1 = new WinUI_Helper.XenLabel();
            this.xenLabel2 = new WinUI_Helper.XenLabel();
            this.GV = new WinUI_Helper.XenDataGridView();
            this.BtnSearch = new WinUI_Helper.XenButton();
            this.BtnOK = new WinUI_Helper.XenButton();
            this.TextFilePath = new WinUI_Helper.XenTextBox();
            this.xenComboBox1 = new WinUI_Helper.XenComboBox();
            this.BtnCancel = new WinUI_Helper.XenButton();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GV)).BeginInit();
            this.SuspendLayout();
            // 
            // xenLabel1
            // 
            this.xenLabel1.AutoSize = true;
            this.xenLabel1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel1.Location = new System.Drawing.Point(36, 24);
            this.xenLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xenLabel1.Name = "xenLabel1";
            this.xenLabel1.Size = new System.Drawing.Size(73, 20);
            this.xenLabel1.TabIndex = 0;
            this.xenLabel1.Text = "營業夥伴";
            // 
            // xenLabel2
            // 
            this.xenLabel2.AutoSize = true;
            this.xenLabel2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel2.Location = new System.Drawing.Point(36, 78);
            this.xenLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xenLabel2.Name = "xenLabel2";
            this.xenLabel2.Size = new System.Drawing.Size(73, 20);
            this.xenLabel2.TabIndex = 1;
            this.xenLabel2.Text = "檔案位置";
            // 
            // GV
            // 
            this.GV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.colDesc});
            this.GV.Location = new System.Drawing.Point(13, 125);
            this.GV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GV.Name = "GV";
            this.GV.RowHeadersWidth = 75;
            this.GV.RowTemplate.Height = 24;
            this.GV.Size = new System.Drawing.Size(1009, 328);
            this.GV.TabIndex = 2;
            this.GV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GV_ColumnHeaderMouseClick);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(481, 70);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(100, 38);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Location = new System.Drawing.Point(13, 463);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(100, 38);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "匯入";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // TextFilePath
            // 
            this.TextFilePath.BackColor = System.Drawing.Color.White;
            this.TextFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextFilePath.Location = new System.Drawing.Point(124, 77);
            this.TextFilePath.Name = "TextFilePath";
            this.TextFilePath.ReadOnlyBackColor = System.Drawing.Color.White;
            this.TextFilePath.Size = new System.Drawing.Size(316, 26);
            this.TextFilePath.TabIndex = 5;
            // 
            // xenComboBox1
            // 
            this.xenComboBox1.BackColor = System.Drawing.Color.White;
            this.xenComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xenComboBox1.EnabledBackColor = System.Drawing.Color.White;
            this.xenComboBox1.FormattingEnabled = true;
            this.xenComboBox1.Items.AddRange(new object[] {
            "大買家",
            "興奇",
            "大晋"});
            this.xenComboBox1.Location = new System.Drawing.Point(124, 24);
            this.xenComboBox1.Name = "xenComboBox1";
            this.xenComboBox1.Size = new System.Drawing.Size(121, 28);
            this.xenComboBox1.TabIndex = 6;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(145, 463);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 38);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // colChk
            // 
            this.colChk.HeaderText = "選取";
            this.colChk.Name = "colChk";
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "備註";
            this.colDesc.Name = "colDesc";
            // 
            // ImportWebSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 515);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.xenComboBox1);
            this.Controls.Add(this.TextFilePath);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.GV);
            this.Controls.Add(this.xenLabel2);
            this.Controls.Add(this.xenLabel1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ImportWebSO";
            this.Text = "ImportWebSO";
            ((System.ComponentModel.ISupportInitialize)(this.GV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinUI_Helper.XenLabel xenLabel1;
        private WinUI_Helper.XenLabel xenLabel2;
        private WinUI_Helper.XenDataGridView GV;
        private WinUI_Helper.XenButton BtnSearch;
        private WinUI_Helper.XenButton BtnOK;
        private WinUI_Helper.XenTextBox TextFilePath;
        private WinUI_Helper.XenComboBox xenComboBox1;
        private WinUI_Helper.XenButton BtnCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
    }
}