
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
            this.btnUserPromptUser2 = new System.Windows.Forms.Button();
            this.btnUserPromptUser1 = new System.Windows.Forms.Button();
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.groupBoxUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUserPromptUser2
            // 
            this.btnUserPromptUser2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUserPromptUser2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserPromptUser2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserPromptUser2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserPromptUser2.Image = global::CCSPayrollBillingSystem.Properties.Resources.user2;
            this.btnUserPromptUser2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserPromptUser2.Location = new System.Drawing.Point(3, 106);
            this.btnUserPromptUser2.Name = "btnUserPromptUser2";
            this.btnUserPromptUser2.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUserPromptUser2.Size = new System.Drawing.Size(336, 86);
            this.btnUserPromptUser2.TabIndex = 3;
            this.btnUserPromptUser2.Text = "Update Employee Payroll";
            this.btnUserPromptUser2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserPromptUser2.UseVisualStyleBackColor = true;
            this.btnUserPromptUser2.Click += new System.EventHandler(this.btnUserPromptUser2_Click);
            // 
            // btnUserPromptUser1
            // 
            this.btnUserPromptUser1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUserPromptUser1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserPromptUser1.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserPromptUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserPromptUser1.Image = global::CCSPayrollBillingSystem.Properties.Resources.user1;
            this.btnUserPromptUser1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserPromptUser1.Location = new System.Drawing.Point(3, 20);
            this.btnUserPromptUser1.Name = "btnUserPromptUser1";
            this.btnUserPromptUser1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUserPromptUser1.Size = new System.Drawing.Size(336, 86);
            this.btnUserPromptUser1.TabIndex = 0;
            this.btnUserPromptUser1.Text = "Add Employee Payroll";
            this.btnUserPromptUser1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserPromptUser1.UseVisualStyleBackColor = true;
            this.btnUserPromptUser1.Click += new System.EventHandler(this.btnUserPromptUser1_Click);
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.btnUserPromptUser2);
            this.groupBoxUser.Controls.Add(this.btnUserPromptUser1);
            this.groupBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBoxUser.Location = new System.Drawing.Point(33, 26);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(342, 193);
            this.groupBoxUser.TabIndex = 5;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "Payroll Actions";
            // 
            // PayrollPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 231);
            this.Controls.Add(this.groupBoxUser);
            this.Name = "PayrollPrompt";
            this.Text = "PayrollPrompt";
            this.groupBoxUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUserPromptUser2;
        private System.Windows.Forms.Button btnUserPromptUser1;
        private System.Windows.Forms.GroupBox groupBoxUser;
    }
}