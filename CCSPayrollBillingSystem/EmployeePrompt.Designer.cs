
namespace CCSPayrollBillingSystem
{
    partial class EmployeePrompt
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
            this.btnUpdateEmployeePrompt = new System.Windows.Forms.Button();
            this.btnAddEmployeePrompt = new System.Windows.Forms.Button();
            this.groupBoxPayroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPayroll
            // 
            this.groupBoxPayroll.Controls.Add(this.btnUpdateEmployeePrompt);
            this.groupBoxPayroll.Controls.Add(this.btnAddEmployeePrompt);
            this.groupBoxPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBoxPayroll.Location = new System.Drawing.Point(42, 19);
            this.groupBoxPayroll.Name = "groupBoxPayroll";
            this.groupBoxPayroll.Size = new System.Drawing.Size(322, 193);
            this.groupBoxPayroll.TabIndex = 4;
            this.groupBoxPayroll.TabStop = false;
            this.groupBoxPayroll.Text = "Employee Action";
            // 
            // btnUpdateEmployeePrompt
            // 
            this.btnUpdateEmployeePrompt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateEmployeePrompt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdateEmployeePrompt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdateEmployeePrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEmployeePrompt.Image = global::CCSPayrollBillingSystem.Properties.Resources.programmer1;
            this.btnUpdateEmployeePrompt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateEmployeePrompt.Location = new System.Drawing.Point(3, 106);
            this.btnUpdateEmployeePrompt.Name = "btnUpdateEmployeePrompt";
            this.btnUpdateEmployeePrompt.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUpdateEmployeePrompt.Size = new System.Drawing.Size(316, 86);
            this.btnUpdateEmployeePrompt.TabIndex = 3;
            this.btnUpdateEmployeePrompt.Text = "Update Employee";
            this.btnUpdateEmployeePrompt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateEmployeePrompt.UseVisualStyleBackColor = true;
            this.btnUpdateEmployeePrompt.Click += new System.EventHandler(this.btnUpdateEmployeePrompt_Click);
            // 
            // btnAddEmployeePrompt
            // 
            this.btnAddEmployeePrompt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddEmployeePrompt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddEmployeePrompt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddEmployeePrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployeePrompt.Image = global::CCSPayrollBillingSystem.Properties.Resources.update_emp;
            this.btnAddEmployeePrompt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEmployeePrompt.Location = new System.Drawing.Point(3, 20);
            this.btnAddEmployeePrompt.Name = "btnAddEmployeePrompt";
            this.btnAddEmployeePrompt.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnAddEmployeePrompt.Size = new System.Drawing.Size(316, 86);
            this.btnAddEmployeePrompt.TabIndex = 0;
            this.btnAddEmployeePrompt.Text = "Add Employee";
            this.btnAddEmployeePrompt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddEmployeePrompt.UseVisualStyleBackColor = true;
            this.btnAddEmployeePrompt.Click += new System.EventHandler(this.btnAddEmployeePrompt_Click);
            // 
            // EmployeePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 231);
            this.Controls.Add(this.groupBoxPayroll);
            this.Name = "EmployeePrompt";
            this.Text = "EmployeePrompt";
            this.groupBoxPayroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayroll;
        private System.Windows.Forms.Button btnUpdateEmployeePrompt;
        private System.Windows.Forms.Button btnAddEmployeePrompt;
    }
}