namespace Panbor_ImportWebSO
{
    partial class excel_2003
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(excel_2003));
            this.xenLabel2 = new System.Windows.Forms.Label();
            this.GV = new System.Windows.Forms.DataGridView();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.TextFilePath = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GV)).BeginInit();
            this.SuspendLayout();
            // 
            // xenLabel2
            // 
            this.xenLabel2.AutoSize = true;
            this.xenLabel2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xenLabel2.Location = new System.Drawing.Point(310, 24);
            this.xenLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xenLabel2.Name = "xenLabel2";
            this.xenLabel2.Size = new System.Drawing.Size(73, 20);
            this.xenLabel2.TabIndex = 1;
            this.xenLabel2.Text = "檔案位置";
            // 
            // GV
            // 
            this.GV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GV.ColumnHeadersHeight = 35;
            this.GV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.colDesc});
            this.GV.Location = new System.Drawing.Point(13, 76);
            this.GV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GV.Name = "GV";
            this.GV.RowHeadersWidth = 75;
            this.GV.RowTemplate.Height = 24;
            this.GV.Size = new System.Drawing.Size(859, 376);
            this.GV.TabIndex = 2;
            // 
            // colChk
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.colChk.DefaultCellStyle = dataGridViewCellStyle1;
            this.colChk.HeaderText = "選取";
            this.colChk.Name = "colChk";
            this.colChk.Visible = false;
            this.colChk.Width = 47;
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "備註";
            this.colDesc.Name = "colDesc";
            this.colDesc.Width = 66;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(755, 16);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(100, 38);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "選取";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnOK.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Location = new System.Drawing.Point(13, 462);
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
            this.TextFilePath.Location = new System.Drawing.Point(398, 23);
            this.TextFilePath.Name = "TextFilePath";
            this.TextFilePath.Size = new System.Drawing.Size(316, 26);
            this.TextFilePath.TabIndex = 5;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(145, 462);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 38);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // excel_2003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(893, 514);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TextFilePath);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.GV);
            this.Controls.Add(this.xenLabel2);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "excel_2003";
            this.Load += new System.EventHandler(this.ImportWebSO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xenLabel2;
        private System.Windows.Forms.DataGridView GV;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.TextBox TextFilePath;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
    }
}