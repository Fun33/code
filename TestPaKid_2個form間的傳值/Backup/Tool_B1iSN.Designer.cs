namespace AP_C
{
    partial class B1iSN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(B1iSN));
            this.tx01 = new System.Windows.Forms.TextBox();
            this.btn_b1isnItem = new System.Windows.Forms.Button();
            this.BtnB1isnBP = new System.Windows.Forms.Button();
            this.BtnB1iSNDoc = new System.Windows.Forms.Button();
            this.tx_desc = new System.Windows.Forms.TextBox();
            this.txBOM = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnBOM = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnOGLT = new System.Windows.Forms.Button();
            this.txOGLT = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_src_xml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dest_xml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tx01
            // 
            this.tx01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tx01.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tx01.Location = new System.Drawing.Point(20, 53);
            this.tx01.Multiline = true;
            this.tx01.Name = "tx01";
            this.tx01.Size = new System.Drawing.Size(958, 247);
            this.tx01.TabIndex = 0;
            // 
            // btn_b1isnItem
            // 
            this.btn_b1isnItem.Location = new System.Drawing.Point(20, 6);
            this.btn_b1isnItem.Name = "btn_b1isnItem";
            this.btn_b1isnItem.Size = new System.Drawing.Size(105, 41);
            this.btn_b1isnItem.TabIndex = 1;
            this.btn_b1isnItem.Text = "B1iSN_Item(&1)";
            this.btn_b1isnItem.UseVisualStyleBackColor = true;
            this.btn_b1isnItem.Click += new System.EventHandler(this.btnB1isnItem_Click);
            // 
            // BtnB1isnBP
            // 
            this.BtnB1isnBP.Location = new System.Drawing.Point(136, 6);
            this.BtnB1isnBP.Name = "BtnB1isnBP";
            this.BtnB1isnBP.Size = new System.Drawing.Size(105, 41);
            this.BtnB1isnBP.TabIndex = 2;
            this.BtnB1isnBP.Text = "B1iSN_bp(&2)";
            this.BtnB1isnBP.UseVisualStyleBackColor = true;
            this.BtnB1isnBP.Click += new System.EventHandler(this.BtnB1isnBP_Click);
            // 
            // BtnB1iSNDoc
            // 
            this.BtnB1iSNDoc.Location = new System.Drawing.Point(262, 6);
            this.BtnB1iSNDoc.Name = "BtnB1iSNDoc";
            this.BtnB1iSNDoc.Size = new System.Drawing.Size(105, 41);
            this.BtnB1iSNDoc.TabIndex = 3;
            this.BtnB1iSNDoc.Text = "B1iSN_doc(&3)";
            this.BtnB1iSNDoc.UseVisualStyleBackColor = true;
            this.BtnB1iSNDoc.Click += new System.EventHandler(this.BtnB1iSNDoc_Click);
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
            // txBOM
            // 
            this.txBOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txBOM.Location = new System.Drawing.Point(19, 44);
            this.txBOM.Name = "txBOM";
            this.txBOM.Size = new System.Drawing.Size(788, 302);
            this.txBOM.TabIndex = 6;
            this.txBOM.Text = resources.GetString("txBOM.Text");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(22, 137);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(830, 387);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btn_b1isnItem);
            this.tabPage1.Controls.Add(this.BtnB1isnBP);
            this.tabPage1.Controls.Add(this.tx01);
            this.tabPage1.Controls.Add(this.BtnB1iSNDoc);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(822, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Item.BP.Doc";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(510, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "price未稅;PriceAfterVAT含稅";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "GetDateXML(&4)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnGetItemXML_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnBOM);
            this.tabPage2.Controls.Add(this.txBOM);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(822, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BOM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnBOM
            // 
            this.BtnBOM.Location = new System.Drawing.Point(19, 6);
            this.BtnBOM.Name = "BtnBOM";
            this.BtnBOM.Size = new System.Drawing.Size(95, 23);
            this.BtnBOM.TabIndex = 7;
            this.BtnBOM.Text = "COPY";
            this.BtnBOM.UseVisualStyleBackColor = true;
            this.BtnBOM.Click += new System.EventHandler(this.BtnBOM_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnOGLT);
            this.tabPage3.Controls.Add(this.txOGLT);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(822, 358);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "OGLT";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnOGLT
            // 
            this.BtnOGLT.Location = new System.Drawing.Point(13, 6);
            this.BtnOGLT.Name = "BtnOGLT";
            this.BtnOGLT.Size = new System.Drawing.Size(95, 23);
            this.BtnOGLT.TabIndex = 9;
            this.BtnOGLT.Text = "COPY";
            this.BtnOGLT.UseVisualStyleBackColor = true;
            this.BtnOGLT.Click += new System.EventHandler(this.BtnOGLT_Click);
            // 
            // txOGLT
            // 
            this.txOGLT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txOGLT.Location = new System.Drawing.Point(13, 50);
            this.txOGLT.Name = "txOGLT";
            this.txOGLT.Size = new System.Drawing.Size(791, 300);
            this.txOGLT.TabIndex = 8;
            this.txOGLT.Text = resources.GetString("txOGLT.Text");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cb_Type);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(822, 358);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "GetXLS";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cb_Type
            // 
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Items.AddRange(new object[] {
            "Item",
            "BP",
            "DOC"});
            this.cb_Type.Location = new System.Drawing.Point(18, 8);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(121, 23);
            this.cb_Type.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(483, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(169, 8);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "gettype n get xml";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.GetTypeNGetXMLFld_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(375, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "產出";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
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
            this.dataGridView1.Location = new System.Drawing.Point(18, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(652, 359);
            this.dataGridView1.TabIndex = 7;
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
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.richTextBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(822, 358);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Special Fld - valid";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(30, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(645, 268);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBox1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
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
            this.listBox1.Location = new System.Drawing.Point(313, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(539, 118);
            this.listBox1.TabIndex = 9;
            // 
            // B1iSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1043, 497);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tx_desc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "B1iSN";
            this.Text = "Tool_B1iSN";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx01;
        private System.Windows.Forms.Button btn_b1isnItem;
        private System.Windows.Forms.Button BtnB1isnBP;
        private System.Windows.Forms.Button BtnB1iSNDoc;
        private System.Windows.Forms.TextBox tx_desc;
        private System.Windows.Forms.RichTextBox txBOM;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnBOM;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button BtnOGLT;
        private System.Windows.Forms.RichTextBox txOGLT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_src;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dest;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_src_xml;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dest_xml;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_path;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}