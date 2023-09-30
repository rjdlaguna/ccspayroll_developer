
namespace CCSPayrollBillingSystem
{
    partial class ProfilePrompt
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
            this.groupBoxProfile = new System.Windows.Forms.GroupBox();
            this.btnProfilePromptProject = new System.Windows.Forms.Button();
            this.btnProfilePromptEmployee = new System.Windows.Forms.Button();
            this.groupBoxProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProfile
            // 
            this.groupBoxProfile.Controls.Add(this.btnProfilePromptProject);
            this.groupBoxProfile.Controls.Add(this.btnProfilePromptEmployee);
            this.groupBoxProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBoxProfile.Location = new System.Drawing.Point(64, 12);
            this.groupBoxProfile.Name = "groupBoxProfile";
            this.groupBoxProfile.Size = new System.Drawing.Size(277, 193);
            this.groupBoxProfile.TabIndex = 4;
            this.groupBoxProfile.TabStop = false;
            this.groupBoxProfile.Text = "Profile Type";
            // 
            // btnProfilePromptProject
            // 
            this.btnProfilePromptProject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProfilePromptProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfilePromptProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfilePromptProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfilePromptProject.Image = global::CCSPayrollBillingSystem.Properties.Resources.profit_growth;
            this.btnProfilePromptProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfilePromptProject.Location = new System.Drawing.Point(3, 106);
            this.btnProfilePromptProject.Name = "btnProfilePromptProject";
            this.btnProfilePromptProject.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnProfilePromptProject.Size = new System.Drawing.Size(271, 86);
            this.btnProfilePromptProject.TabIndex = 3;
            this.btnProfilePromptProject.Text = "Add Project";
            this.btnProfilePromptProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfilePromptProject.UseVisualStyleBackColor = true;
            this.btnProfilePromptProject.Click += new System.EventHandler(this.btnProfilePromptProject_Click);
            // 
            // btnProfilePromptEmployee
            // 
            this.btnProfilePromptEmployee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProfilePromptEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfilePromptEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfilePromptEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfilePromptEmployee.Image = global::CCSPayrollBillingSystem.Properties.Resources.employee;
            this.btnProfilePromptEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfilePromptEmployee.Location = new System.Drawing.Point(3, 20);
            this.btnProfilePromptEmployee.Name = "btnProfilePromptEmployee";
            this.btnProfilePromptEmployee.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnProfilePromptEmployee.Size = new System.Drawing.Size(271, 86);
            this.btnProfilePromptEmployee.TabIndex = 0;
            this.btnProfilePromptEmployee.Text = "Add Employee";
            this.btnProfilePromptEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfilePromptEmployee.UseVisualStyleBackColor = true;
            this.btnProfilePromptEmployee.Click += new System.EventHandler(this.btnProfilePromptEmployee_Click);
            // 
            // ProfilePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 231);
            this.Controls.Add(this.groupBoxProfile);
            this.Name = "ProfilePrompt";
            this.Text = "ProfilePrompt";
            this.groupBoxProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProfile;
        private System.Windows.Forms.Button btnProfilePromptProject;
        private System.Windows.Forms.Button btnProfilePromptEmployee;
    }
}