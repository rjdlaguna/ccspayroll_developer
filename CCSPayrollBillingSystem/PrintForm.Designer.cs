
namespace CCSPayrollBillingSystem
{
    partial class PrintForm
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
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.btnUserPromptUser2 = new System.Windows.Forms.Button();
            this.btnEmployeePrint = new System.Windows.Forms.Button();
            this.groupBoxUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.btnUserPromptUser2);
            this.groupBoxUser.Controls.Add(this.btnEmployeePrint);
            this.groupBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.groupBoxUser.Location = new System.Drawing.Point(99, 12);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(232, 193);
            this.groupBoxUser.TabIndex = 5;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "Print Type";
            // 
            // btnUserPromptUser2
            // 
            this.btnUserPromptUser2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUserPromptUser2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserPromptUser2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserPromptUser2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserPromptUser2.Image = global::CCSPayrollBillingSystem.Properties.Resources.salaries;
            this.btnUserPromptUser2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserPromptUser2.Location = new System.Drawing.Point(3, 106);
            this.btnUserPromptUser2.Name = "btnUserPromptUser2";
            this.btnUserPromptUser2.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUserPromptUser2.Size = new System.Drawing.Size(226, 86);
            this.btnUserPromptUser2.TabIndex = 3;
            this.btnUserPromptUser2.Text = "Billing";
            this.btnUserPromptUser2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserPromptUser2.UseVisualStyleBackColor = true;
            this.btnUserPromptUser2.Click += new System.EventHandler(this.btnUserPromptUser2_Click);
            // 
            // btnEmployeePrint
            // 
            this.btnEmployeePrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEmployeePrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmployeePrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployeePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeePrint.Image = global::CCSPayrollBillingSystem.Properties.Resources.salary;
            this.btnEmployeePrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeePrint.Location = new System.Drawing.Point(3, 20);
            this.btnEmployeePrint.Name = "btnEmployeePrint";
            this.btnEmployeePrint.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnEmployeePrint.Size = new System.Drawing.Size(226, 86);
            this.btnEmployeePrint.TabIndex = 0;
            this.btnEmployeePrint.Text = "Employee";
            this.btnEmployeePrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmployeePrint.UseVisualStyleBackColor = true;
            this.btnEmployeePrint.Click += new System.EventHandler(this.btnEmployeePrint_Click);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 231);
            this.Controls.Add(this.groupBoxUser);
            this.Name = "PrintForm";
            this.Text = "Print Form";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            this.groupBoxUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.Button btnUserPromptUser2;
        private System.Windows.Forms.Button btnEmployeePrint;
    }
}