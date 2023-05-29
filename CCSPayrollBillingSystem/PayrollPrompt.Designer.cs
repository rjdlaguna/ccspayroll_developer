
namespace CCSPayrollBillingSystem
{
    partial class PayrollPrompt
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
            this.groupBoxPayroll = new System.Windows.Forms.GroupBox();
            this.btnPayPromptProject = new System.Windows.Forms.Button();
            this.btnPayPromptEmployee = new System.Windows.Forms.Button();
            this.groupBoxPayroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPayroll
            // 
            this.groupBoxPayroll.Controls.Add(this.btnPayPromptProject);
            this.groupBoxPayroll.Controls.Add(this.btnPayPromptEmployee);
            this.groupBoxPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBoxPayroll.Location = new System.Drawing.Point(86, 12);
            this.groupBoxPayroll.Name = "groupBoxPayroll";
            this.groupBoxPayroll.Size = new System.Drawing.Size(232, 193);
            this.groupBoxPayroll.TabIndex = 3;
            this.groupBoxPayroll.TabStop = false;
            this.groupBoxPayroll.Text = "Payroll Type";
            // 
            // btnPayPromptProject
            // 
            this.btnPayPromptProject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPayPromptProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPayPromptProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPayPromptProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayPromptProject.Image = global::CCSPayrollBillingSystem.Properties.Resources.salaries;
            this.btnPayPromptProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayPromptProject.Location = new System.Drawing.Point(3, 106);
            this.btnPayPromptProject.Name = "btnPayPromptProject";
            this.btnPayPromptProject.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnPayPromptProject.Size = new System.Drawing.Size(226, 86);
            this.btnPayPromptProject.TabIndex = 3;
            this.btnPayPromptProject.Text = "Project";
            this.btnPayPromptProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayPromptProject.UseVisualStyleBackColor = true;
            // 
            // btnPayPromptEmployee
            // 
            this.btnPayPromptEmployee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPayPromptEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPayPromptEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPayPromptEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayPromptEmployee.Image = global::CCSPayrollBillingSystem.Properties.Resources.salary;
            this.btnPayPromptEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayPromptEmployee.Location = new System.Drawing.Point(3, 20);
            this.btnPayPromptEmployee.Name = "btnPayPromptEmployee";
            this.btnPayPromptEmployee.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnPayPromptEmployee.Size = new System.Drawing.Size(226, 86);
            this.btnPayPromptEmployee.TabIndex = 0;
            this.btnPayPromptEmployee.Text = "Employee";
            this.btnPayPromptEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayPromptEmployee.UseVisualStyleBackColor = true;
            // 
            // PayrollPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 231);
            this.Controls.Add(this.groupBoxPayroll);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PayrollPrompt";
            this.Text = "PayrollPrompt";
            this.groupBoxPayroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayroll;
        private System.Windows.Forms.Button btnPayPromptProject;
        private System.Windows.Forms.Button btnPayPromptEmployee;
    }
}