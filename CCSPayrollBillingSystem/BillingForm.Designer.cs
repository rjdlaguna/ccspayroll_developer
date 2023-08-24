
namespace CCSPayrollBillingSystem
{
    partial class frmBilling
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEmployeeList4Billing = new System.Windows.Forms.DataGridView();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.txtProjectAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtGrossTotal = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.rtbBillingSlip = new System.Windows.Forms.RichTextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList4Billing)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployeeList4Billing
            // 
            this.dgvEmployeeList4Billing.AllowUserToAddRows = false;
            this.dgvEmployeeList4Billing.AllowUserToOrderColumns = true;
            this.dgvEmployeeList4Billing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeList4Billing.Location = new System.Drawing.Point(12, 222);
            this.dgvEmployeeList4Billing.Name = "dgvEmployeeList4Billing";
            dataGridViewCellStyle5.NullValue = "0";
            this.dgvEmployeeList4Billing.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEmployeeList4Billing.Size = new System.Drawing.Size(594, 161);
            this.dgvEmployeeList4Billing.TabIndex = 68;
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(428, 62);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(144, 20);
            this.txtVAT.TabIndex = 67;
            // 
            // txtProjectAddress
            // 
            this.txtProjectAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectAddress.Location = new System.Drawing.Point(92, 42);
            this.txtProjectAddress.Multiline = true;
            this.txtProjectAddress.Name = "txtProjectAddress";
            this.txtProjectAddress.ReadOnly = true;
            this.txtProjectAddress.Size = new System.Drawing.Size(179, 78);
            this.txtProjectAddress.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbProject);
            this.groupBox1.Controls.Add(this.txtProjectAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 137);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PROJECT DETAILS";
            // 
            // cmbProject
            // 
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(92, 15);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(179, 21);
            this.cmbProject.TabIndex = 56;
            this.cmbProject.Text = "Select";
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Project Name :";
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.Location = new System.Drawing.Point(428, 88);
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.ReadOnly = true;
            this.txtNetTotal.Size = new System.Drawing.Size(144, 20);
            this.txtNetTotal.TabIndex = 65;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(371, 88);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 64;
            this.label18.Text = "Net Pay :";
            // 
            // txtGrossTotal
            // 
            this.txtGrossTotal.Location = new System.Drawing.Point(428, 35);
            this.txtGrossTotal.Name = "txtGrossTotal";
            this.txtGrossTotal.ReadOnly = true;
            this.txtGrossTotal.Size = new System.Drawing.Size(178, 20);
            this.txtGrossTotal.TabIndex = 63;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(361, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "Gross Pay :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(388, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 66;
            this.label19.Text = "VAT :";
            // 
            // rtbBillingSlip
            // 
            this.rtbBillingSlip.Location = new System.Drawing.Point(625, 20);
            this.rtbBillingSlip.Name = "rtbBillingSlip";
            this.rtbBillingSlip.Size = new System.Drawing.Size(437, 426);
            this.rtbBillingSlip.TabIndex = 69;
            this.rtbBillingSlip.Text = "";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Image = global::CCSPayrollBillingSystem.Properties.Resources.refresh;
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(183, 163);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(128, 40);
            this.btnGenerate.TabIndex = 70;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Image = global::CCSPayrollBillingSystem.Properties.Resources.calculator;
            this.btnCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculate.Location = new System.Drawing.Point(478, 132);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(128, 40);
            this.btnCalculate.TabIndex = 71;
            this.btnCalculate.Text = "CALCULATE";
            this.btnCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // frmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 475);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.rtbBillingSlip);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dgvEmployeeList4Billing);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNetTotal);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtGrossTotal);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label19);
            this.Name = "frmBilling";
            this.Text = "Billing Form";
            this.Load += new System.EventHandler(this.frmBilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList4Billing)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEmployeeList4Billing;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.TextBox txtProjectAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtGrossTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox rtbBillingSlip;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.Button btnCalculate;
    }
}