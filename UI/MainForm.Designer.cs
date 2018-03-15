namespace UI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMember = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(100, 100);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManager,
            this.menuMember,
            this.menuDish,
            this.menuTable,
            this.menuOrder,
            this.menuQuit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(852, 108);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuManager
            // 
            this.menuManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuManager.Image = global::UI.Properties.Resources._2017_09_22_180438;
            this.menuManager.Name = "menuManager";
            this.menuManager.Size = new System.Drawing.Size(112, 104);
            this.menuManager.Text = "manager";
            this.menuManager.Click += new System.EventHandler(this.menuManager_Click);
            // 
            // menuMember
            // 
            this.menuMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMember.Image = global::UI.Properties.Resources._2017_10_21_145825;
            this.menuMember.Name = "menuMember";
            this.menuMember.Size = new System.Drawing.Size(112, 104);
            this.menuMember.Text = "member";
            // 
            // menuDish
            // 
            this.menuDish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDish.Image = global::UI.Properties.Resources._1;
            this.menuDish.Name = "menuDish";
            this.menuDish.Size = new System.Drawing.Size(112, 104);
            this.menuDish.Text = "dish";
            // 
            // menuTable
            // 
            this.menuTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuTable.Image = global::UI.Properties.Resources._7;
            this.menuTable.Name = "menuTable";
            this.menuTable.Size = new System.Drawing.Size(112, 104);
            this.menuTable.Text = "table";
            // 
            // menuOrder
            // 
            this.menuOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOrder.Image = global::UI.Properties.Resources._21;
            this.menuOrder.Name = "menuOrder";
            this.menuOrder.Size = new System.Drawing.Size(112, 104);
            this.menuOrder.Text = "order";
            // 
            // menuQuit
            // 
            this.menuQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuQuit.Image = global::UI.Properties.Resources._31;
            this.menuQuit.Name = "menuQuit";
            this.menuQuit.Size = new System.Drawing.Size(112, 104);
            this.menuQuit.Text = "quit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(852, 566);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "餐饮管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuManager;
        private System.Windows.Forms.ToolStripMenuItem menuMember;
        private System.Windows.Forms.ToolStripMenuItem menuDish;
        private System.Windows.Forms.ToolStripMenuItem menuTable;
        private System.Windows.Forms.ToolStripMenuItem menuOrder;
        private System.Windows.Forms.ToolStripMenuItem menuQuit;
    }
}