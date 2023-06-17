
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.payrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeePayrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMainView = new System.Windows.Forms.ToolStripStatusLabel();
            this.jobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deductionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProfileMenu = new System.Windows.Forms.Button();
            this.btnPrintMenu = new System.Windows.Forms.Button();
            this.btnBillingMenu = new System.Windows.Forms.Button();
            this.btnPayrollMenu = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.groupBoxMenu.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.payrollToolStripMenuItem,
            this.billingToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(934, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
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
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empSettingsToolStripMenuItem,
            this.passwordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // empSettingsToolStripMenuItem
            // 
            this.empSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jobToolStripMenuItem,
            this.deductionsToolStripMenuItem});
            this.empSettingsToolStripMenuItem.Name = "empSettingsToolStripMenuItem";
            this.empSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.empSettingsToolStripMenuItem.Text = "Employee Settings";
            // 
            // passwordToolStripMenuItem
            // 
            this.passwordToolStripMenuItem.Name = "passwordToolStripMenuItem";
            this.passwordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.passwordToolStripMenuItem.Text = "Change Password";
            this.passwordToolStripMenuItem.Click += new System.EventHandler(this.passwordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
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
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMainView});
            this.statusStripMain.Location = new System.Drawing.Point(0, 419);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(934, 22);
            this.statusStripMain.TabIndex = 3;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMainView
            // 
            this.toolStripStatusLabelMainView.Name = "toolStripStatusLabelMainView";
            this.toolStripStatusLabelMainView.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelMainView.Text = "toolStripStatusLabel1";
            // 
            // jobToolStripMenuItem
            // 
            this.jobToolStripMenuItem.Name = "jobToolStripMenuItem";
            this.jobToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jobToolStripMenuItem.Text = "Job";
            this.jobToolStripMenuItem.Click += new System.EventHandler(this.jobToolStripMenuItem_Click);
            // 
            // deductionsToolStripMenuItem
            // 
            this.deductionsToolStripMenuItem.Name = "deductionsToolStripMenuItem";
            this.deductionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deductionsToolStripMenuItem.Text = "Deductions";
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
            this.ControlBox = false;
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.groupBoxMenu);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CCSPayrollBillingSystem";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxMenu.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPayrollMenu;
        private System.Windows.Forms.MenuStrip menuStrip;
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
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMainView;
        private System.Windows.Forms.ToolStripMenuItem passwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deductionsToolStripMenuItem;
    }
}

