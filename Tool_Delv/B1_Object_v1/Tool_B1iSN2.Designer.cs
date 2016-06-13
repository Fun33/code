namespace AP_C
{
    partial class B1iSN2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(B1iSN2));
            this.tx_desc = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_src_xml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dest_xml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tx_desc
            // 
            this.tx_desc.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tx_desc.Location = new System.Drawing.Point(12, 10);
            this.tx_desc.Multiline = true;
            this.tx_desc.Name = "tx_desc";
            this.tx_desc.Size = new System.Drawing.Size(270, 121);
            this.tx_desc.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBox1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Items.AddRange(new object[] {
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
            this.listBox1.Location = new System.Drawing.Point(313, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(539, 118);
            this.listBox1.TabIndex = 9;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cb_Type);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(858, 361);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "item";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cb_Type
            // 
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Items.AddRange(new object[] {
            "Item",
            "BP",
            "DOC"});
            this.cb_Type.Location = new System.Drawing.Point(34, 6);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(121, 23);
            this.cb_Type.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(185, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "gettype n get xml";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(391, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "產出";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_src,
            this.col_dest,
            this.COL_TYPE,
            this.col_src_xml,
            this.col_dest_xml,
            this.col_path});
            this.dataGridView1.Location = new System.Drawing.Point(34, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(652, 320);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // col_src
            // 
            this.col_src.HeaderText = "col_src";
            this.col_src.Name = "col_src";
            // 
            // col_dest
            // 
            this.col_dest.HeaderText = "col_dest";
            this.col_dest.Name = "col_dest";
            // 
            // COL_TYPE
            // 
            this.COL_TYPE.HeaderText = "COL_TYPE";
            this.COL_TYPE.Name = "COL_TYPE";
            // 
            // col_src_xml
            // 
            this.col_src_xml.HeaderText = "col_src_xml";
            this.col_src_xml.Name = "col_src_xml";
            // 
            // col_dest_xml
            // 
            this.col_dest_xml.HeaderText = "col_dest_xml";
            this.col_dest_xml.Name = "col_dest_xml";
            // 
            // col_path
            // 
            this.col_path.HeaderText = "col_path";
            this.col_path.Name = "col_path";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(22, 137);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(866, 390);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(858, 361);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(858, 361);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // B1iSN2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(900, 539);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tx_desc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "B1iSN2";
            this.Text = "Tool_B1iSN";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx_desc;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_src;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dest;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_src_xml;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dest_xml;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.TabPage tabPage2;
    }
}