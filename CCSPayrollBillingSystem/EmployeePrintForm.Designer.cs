
namespace CCSPayrollBillingSystem
{
    partial class EmployeePrintForm
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
            this.rtbPayrollSlip = new System.Windows.Forms.RichTextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbPayrollSlip
            // 
            this.rtbPayrollSlip.Location = new System.Drawing.Point(411, 12);
            this.rtbPayrollSlip.Name = "rtbPayrollSlip";
            this.rtbPayrollSlip.Size = new System.Drawing.Size(377, 426);
            this.rtbPayrollSlip.TabIndex = 4;
            this.rtbPayrollSlip.Text = "";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Image = global::CCSPayrollBillingSystem.Properties.Resources.refresh;
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(131, 382);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(128, 40);
            this.btnGenerate.TabIndex = 40;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::CCSPayrollBillingSystem.Properties.Resources.loupe;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(367, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(38, 40);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // EmployeePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.rtbPayrollSlip);
            this.Controls.Add(this.btnSearch);
            this.Name = "EmployeePrintForm";
            this.Text = "EmployeePrintForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbPayrollSlip;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGenerate;
    }
}