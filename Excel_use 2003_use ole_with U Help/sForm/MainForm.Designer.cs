namespace Panbor_ImportWebSO
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tipDataBase = new System.Windows.Forms.ToolStripStatusLabel();
            this.tipUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tipStation = new System.Windows.Forms.ToolStripStatusLabel();
            this.Menu_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_1_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_1_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_1_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.Menu_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_5_One = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_2_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_2_Seting = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_3_Cascade = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_3_TileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_3_TileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_3_ArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_3_CloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StText,
            this.tipDataBase,
            this.tipUserName,
            this.tipStation});
            this.StatusBar.Location = new System.Drawing.Point(0, 396);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(853, 25);
            this.StatusBar.TabIndex = 1;
            // 
            // StText
            // 
            this.StText.Name = "StText";
            this.StText.Size = new System.Drawing.Size(13, 20);
            this.StText.Text = " ";
            // 
            // tipDataBase
            // 
            this.tipDataBase.Name = "tipDataBase";
            this.tipDataBase.Size = new System.Drawing.Size(57, 20);
            this.tipDataBase.Text = "資料庫";
            // 
            // tipUserName
            // 
            this.tipUserName.Name = "tipUserName";
            this.tipUserName.Size = new System.Drawing.Size(89, 20);
            this.tipUserName.Text = "使用者名稱";
            // 
            // tipStation
            // 
            this.tipStation.Name = "tipStation";
            this.tipStation.Size = new System.Drawing.Size(41, 20);
            this.tipStation.Text = "站別";
            // 
            // Menu_1
            // 
            this.Menu_1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_1_Login,
            this.Menu_1_Logout,
            this.Menu_1_Exit});
            this.Menu_1.Name = "Menu_1";
            this.Menu_1.Size = new System.Drawing.Size(53, 24);
            this.Menu_1.Text = "檔案";
            // 
            // Menu_1_Login
            // 
            this.Menu_1_Login.Name = "Menu_1_Login";
            this.Menu_1_Login.Size = new System.Drawing.Size(110, 24);
            this.Menu_1_Login.Text = "登入";
            this.Menu_1_Login.Click += new System.EventHandler(this.Menu_1_Login_Click);
            // 
            // Menu_1_Logout
            // 
            this.Menu_1_Logout.Name = "Menu_1_Logout";
            this.Menu_1_Logout.Size = new System.Drawing.Size(110, 24);
            this.Menu_1_Logout.Text = "登出";
            this.Menu_1_Logout.Visible = false;
            this.Menu_1_Logout.Click += new System.EventHandler(this.Menu_1_Logout_Click);
            // 
            // Menu_1_Exit
            // 
            this.Menu_1_Exit.Name = "Menu_1_Exit";
            this.Menu_1_Exit.Size = new System.Drawing.Size(110, 24);
            this.Menu_1_Exit.Text = "離開";
            this.Menu_1_Exit.Click += new System.EventHandler(this.Menu_1_Exit_Click);
            // 
            // Menu
            // 
            this.Menu.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_1,
            this.Menu_5,
            this.Menu_2,
            this.Menu_3,
            this.Menu_4});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.MdiWindowListItem = this.Menu_3;
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(853, 28);
            this.Menu.TabIndex = 3;
            this.Menu.Text = "Menu";
            // 
            // Menu_5
            // 
            this.Menu_5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_5_One});
            this.Menu_5.Enabled = false;
            this.Menu_5.Name = "Menu_5";
            this.Menu_5.Size = new System.Drawing.Size(53, 24);
            this.Menu_5.Text = "作業";
            // 
            // Menu_5_One
            // 
            this.Menu_5_One.Name = "Menu_5_One";
            this.Menu_5_One.Size = new System.Drawing.Size(152, 24);
            this.Menu_5_One.Text = "訂單匯入";
            this.Menu_5_One.Click += new System.EventHandler(this.Menu_5_One_Click);
            // 
            // Menu_2
            // 
            this.Menu_2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_2_Config,
            this.Menu_2_Seting});
            this.Menu_2.Name = "Menu_2";
            this.Menu_2.Size = new System.Drawing.Size(53, 24);
            this.Menu_2.Text = "設定";
            // 
            // Menu_2_Config
            // 
            this.Menu_2_Config.Name = "Menu_2_Config";
            this.Menu_2_Config.Size = new System.Drawing.Size(142, 24);
            this.Menu_2_Config.Text = "一般設定";
            this.Menu_2_Config.Click += new System.EventHandler(this.Menu_2_Config_Click);
            // 
            // Menu_2_Seting
            // 
            this.Menu_2_Seting.Name = "Menu_2_Seting";
            this.Menu_2_Seting.Size = new System.Drawing.Size(142, 24);
            this.Menu_2_Seting.Text = "連線設定";
            this.Menu_2_Seting.Click += new System.EventHandler(this.Menu_2_Seting_Click);
            // 
            // Menu_3
            // 
            this.Menu_3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_3_Cascade,
            this.Menu_3_TileVertical,
            this.Menu_3_TileHorizontal,
            this.Menu_3_ArrangeIcons,
            this.Menu_3_CloseAll});
            this.Menu_3.Name = "Menu_3";
            this.Menu_3.Size = new System.Drawing.Size(53, 24);
            this.Menu_3.Text = "視窗";
            // 
            // Menu_3_Cascade
            // 
            this.Menu_3_Cascade.Name = "Menu_3_Cascade";
            this.Menu_3_Cascade.Size = new System.Drawing.Size(142, 24);
            this.Menu_3_Cascade.Text = "重疊顯示";
            this.Menu_3_Cascade.Click += new System.EventHandler(this.Menu_3_Cascade_Click);
            // 
            // Menu_3_TileVertical
            // 
            this.Menu_3_TileVertical.Name = "Menu_3_TileVertical";
            this.Menu_3_TileVertical.Size = new System.Drawing.Size(142, 24);
            this.Menu_3_TileVertical.Text = "垂直並排";
            this.Menu_3_TileVertical.Click += new System.EventHandler(this.Menu_3_TileVertical_Click);
            // 
            // Menu_3_TileHorizontal
            // 
            this.Menu_3_TileHorizontal.Name = "Menu_3_TileHorizontal";
            this.Menu_3_TileHorizontal.Size = new System.Drawing.Size(142, 24);
            this.Menu_3_TileHorizontal.Text = "水平並排";
            this.Menu_3_TileHorizontal.Click += new System.EventHandler(this.Menu_3_TileHorizontal_Click);
            // 
            // Menu_3_ArrangeIcons
            // 
            this.Menu_3_ArrangeIcons.Name = "Menu_3_ArrangeIcons";
            this.Menu_3_ArrangeIcons.Size = new System.Drawing.Size(142, 24);
            this.Menu_3_ArrangeIcons.Text = "排列圖示";
            this.Menu_3_ArrangeIcons.Click += new System.EventHandler(this.Menu_3_ArrangeIcons_Click);
            // 
            // Menu_3_CloseAll
            // 
            this.Menu_3_CloseAll.Name = "Menu_3_CloseAll";
            this.Menu_3_CloseAll.Size = new System.Drawing.Size(142, 24);
            this.Menu_3_CloseAll.Text = "全部關閉";
            this.Menu_3_CloseAll.Click += new System.EventHandler(this.Menu_3_CloseAll_Click);
            // 
            // Menu_4
            // 
            this.Menu_4.Name = "Menu_4";
            this.Menu_4.Size = new System.Drawing.Size(53, 24);
            this.Menu_4.Text = "關於";
            this.Menu_4.Click += new System.EventHandler(this.Menu_4_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 421);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Menu;
            this.Name = "MainForm";
            this.Text = "網路訂單匯入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip StatusBar;
        public System.Windows.Forms.ToolStripStatusLabel StText;
        private System.Windows.Forms.ToolStripMenuItem Menu_1;
        private System.Windows.Forms.ToolStripMenuItem Menu_1_Exit;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem Menu_2;
        private System.Windows.Forms.ToolStripMenuItem Menu_2_Seting;
        private System.Windows.Forms.ToolStripMenuItem Menu_3;
        private System.Windows.Forms.ToolStripMenuItem Menu_1_Login;
        private System.Windows.Forms.ToolStripMenuItem Menu_3_Cascade;
        private System.Windows.Forms.ToolStripMenuItem Menu_3_TileVertical;
        private System.Windows.Forms.ToolStripMenuItem Menu_3_TileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem Menu_3_ArrangeIcons;
        private System.Windows.Forms.ToolStripMenuItem Menu_3_CloseAll;
        private System.Windows.Forms.ToolStripMenuItem Menu_4;
        private System.Windows.Forms.ToolStripMenuItem Menu_5;
        private System.Windows.Forms.ToolStripMenuItem Menu_5_One;
        private System.Windows.Forms.ToolStripMenuItem Menu_2_Config;
        private System.Windows.Forms.ToolStripMenuItem Menu_1_Logout;
        private System.Windows.Forms.ToolStripStatusLabel tipDataBase;
        private System.Windows.Forms.ToolStripStatusLabel tipUserName;
        private System.Windows.Forms.ToolStripStatusLabel tipStation;

    }
}

