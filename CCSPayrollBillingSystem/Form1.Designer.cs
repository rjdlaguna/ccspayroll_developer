
namespace CCSPayrollBillingSystem
{
    partial class FormMain
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
            this.payrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeePayrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnProfileMenu = new System.Windows.Forms.Button();
            this.btnPrintMenu = new System.Windows.Forms.Button();
            this.btnBillingMenu = new System.Windows.Forms.Button();
            this.btnPayrollMenu = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payrollToolStripMenuItem,
            this.billingToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // payrollToolStripMenuItem
            // 
            this.payrollToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeePayrollToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.payrollToolStripMenuItem.Name = "payrollToolStripMenuItem";
            this.payrollToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.payrollToolStripMenuItem.Text = "Payroll";
            // 
            // employeePayrollToolStripMenuItem
            // 
            this.employeePayrollToolStripMenuItem.Name = "employeePayrollToolStripMenuItem";
            this.employeePayrollToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.employeePayrollToolStripMenuItem.Text = "Employee Payroll";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.projectToolStripMenuItem.Text = "Project-based Payroll";
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.billingToolStripMenuItem.Text = "Billing";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeToolStripMenuItem,
            this.projectToolStripMenuItem1});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // projectToolStripMenuItem1
            // 
            this.projectToolStripMenuItem1.Name = "projectToolStripMenuItem1";
            this.projectToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.projectToolStripMenuItem1.Text = "Project";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.Controls.Add(this.btnProfileMenu);
            this.groupBoxMenu.Controls.Add(this.btnPrintMenu);
            this.groupBoxMenu.Controls.Add(this.btnBillingMenu);
            this.groupBoxMenu.Controls.Add(this.btnPayrollMenu);
            this.groupBoxMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBoxMenu.Location = new System.Drawing.Point(14, 27);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(229, 373);
            this.groupBoxMenu.TabIndex = 2;
            this.groupBoxMenu.TabStop = false;
            this.groupBoxMenu.Text = "MenuBox";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnProfileMenu
            // 
            this.btnProfileMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProfileMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfileMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfileMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfileMenu.Image = global::CCSPayrollBillingSystem.Properties.Resources.programmer1;
            this.btnProfileMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfileMenu.Location = new System.Drawing.Point(3, 271);
            this.btnProfileMenu.Name = "btnProfileMenu";
            this.btnProfileMenu.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnProfileMenu.Size = new System.Drawing.Size(223, 86);
            this.btnProfileMenu.TabIndex = 5;
            this.btnProfileMenu.Text = "PROFILE";
            this.btnProfileMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfileMenu.UseVisualStyleBackColor = true;
            this.btnProfileMenu.Click += new System.EventHandler(this.btnProfileMenu_Click);
            // 
            // btnPrintMenu
            // 
            this.btnPrintMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrintMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrintMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintMenu.Image = global::CCSPayrollBillingSystem.Properties.Resources.printer;
            this.btnPrintMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintMenu.Location = new System.Drawing.Point(3, 185);
            this.btnPrintMenu.Name = "btnPrintMenu";
            this.btnPrintMenu.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnPrintMenu.Size = new System.Drawing.Size(223, 86);
            this.btnPrintMenu.TabIndex = 4;
            this.btnPrintMenu.Text = "PRINT";
            this.btnPrintMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintMenu.UseVisualStyleBackColor = true;
            this.btnPrintMenu.Click += new System.EventHandler(this.btnPrintMenu_Click);
            // 
            // btnBillingMenu
            // 
            this.btnBillingMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBillingMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBillingMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBillingMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillingMenu.Image = global::CCSPayrollBillingSystem.Properties.Resources.bill1;
            this.btnBillingMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBillingMenu.Location = new System.Drawing.Point(3, 99);
            this.btnBillingMenu.Name = "btnBillingMenu";
            this.btnBillingMenu.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnBillingMenu.Size = new System.Drawing.Size(223, 86);
            this.btnBillingMenu.TabIndex = 3;
            this.btnBillingMenu.Text = "BILLING";
            this.btnBillingMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBillingMenu.UseVisualStyleBackColor = true;
            this.btnBillingMenu.Click += new System.EventHandler(this.btnBillingMenu_Click);
            // 
            // btnPayrollMenu
            // 
            this.btnPayrollMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPayrollMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPayrollMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPayrollMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayrollMenu.Image = global::CCSPayrollBillingSystem.Properties.Resources.invoice3;
            this.btnPayrollMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayrollMenu.Location = new System.Drawing.Point(3, 13);
            this.btnPayrollMenu.Name = "btnPayrollMenu";
            this.btnPayrollMenu.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnPayrollMenu.Size = new System.Drawing.Size(223, 86);
            this.btnPayrollMenu.TabIndex = 0;
            this.btnPayrollMenu.Text = "PAYROLL";
            this.btnPayrollMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayrollMenu.UseVisualStyleBackColor = true;
            this.btnPayrollMenu.Click += new System.EventHandler(this.btnPayrollMenu_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(934, 441);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxMenu);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CCSPayrollBillingSystem";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPayrollMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem payrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeePayrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.Button btnProfileMenu;
        private System.Windows.Forms.Button btnPrintMenu;
        private System.Windows.Forms.Button btnBillingMenu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

