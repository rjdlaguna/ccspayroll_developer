
namespace CCSPayrollBillingSystem
{
    partial class frmLoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoanEmpName = new System.Windows.Forms.TextBox();
            this.btnSelectEmployee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboLoanType = new System.Windows.Forms.ComboBox();
            this.txtLoanDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoanAmount = new System.Windows.Forms.TextBox();
            this.dgEmployeeLoanList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteLoan = new System.Windows.Forms.Button();
            this.btnUpdateLoan = new System.Windows.Forms.Button();
            this.btnEditLoan = new System.Windows.Forms.Button();
            this.btnSaveLoan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLoanAmountToPay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtLoanPayrollStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtLoanPayrollCutoffDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLoanRemainingAmount = new System.Windows.Forms.TextBox();
            this.dgLoanEmployeePaymentList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteLoanPayment = new System.Windows.Forms.Button();
            this.btnUpdateLoanPayment = new System.Windows.Forms.Button();
            this.btnEditLoanPayment = new System.Windows.Forms.Button();
            this.btnSaveLoanPayment = new System.Windows.Forms.Button();
            this.txtLoanAmountPaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoanDataPrompt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployeeLoanList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanEmployeePaymentList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Name:";
            // 
            // txtLoanEmpName
            // 
            this.txtLoanEmpName.Location = new System.Drawing.Point(108, 45);
            this.txtLoanEmpName.Name = "txtLoanEmpName";
            this.txtLoanEmpName.Size = new System.Drawing.Size(136, 20);
            this.txtLoanEmpName.TabIndex = 2;
            // 
            // btnSelectEmployee
            // 
            this.btnSelectEmployee.Location = new System.Drawing.Point(250, 43);
            this.btnSelectEmployee.Name = "btnSelectEmployee";
            this.btnSelectEmployee.Size = new System.Drawing.Size(29, 23);
            this.btnSelectEmployee.TabIndex = 3;
            this.btnSelectEmployee.Text = "...";
            this.btnSelectEmployee.UseVisualStyleBackColor = true;
            this.btnSelectEmployee.Click += new System.EventHandler(this.btnSelectEmployee_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Loan Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // comboLoanType
            // 
            this.comboLoanType.FormattingEnabled = true;
            this.comboLoanType.Items.AddRange(new object[] {
            "SSS",
            "PAGIBIG",
            "PhilHealth",
            "Others"});
            this.comboLoanType.Location = new System.Drawing.Point(108, 75);
            this.comboLoanType.Name = "comboLoanType";
            this.comboLoanType.Size = new System.Drawing.Size(136, 21);
            this.comboLoanType.TabIndex = 6;
            // 
            // txtLoanDescription
            // 
            this.txtLoanDescription.Location = new System.Drawing.Point(108, 102);
            this.txtLoanDescription.Multiline = true;
            this.txtLoanDescription.Name = "txtLoanDescription";
            this.txtLoanDescription.Size = new System.Drawing.Size(192, 45);
            this.txtLoanDescription.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Loan Amount:";
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.Location = new System.Drawing.Point(108, 162);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Size = new System.Drawing.Size(121, 20);
            this.txtLoanAmount.TabIndex = 9;
            this.txtLoanAmount.Text = "0.00";
            this.txtLoanAmount.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // dgEmployeeLoanList
            // 
            this.dgEmployeeLoanList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployeeLoanList.Location = new System.Drawing.Point(18, 220);
            this.dgEmployeeLoanList.Name = "dgEmployeeLoanList";
            this.dgEmployeeLoanList.Size = new System.Drawing.Size(392, 150);
            this.dgEmployeeLoanList.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoanDataPrompt);
            this.groupBox1.Controls.Add(this.btnDeleteLoan);
            this.groupBox1.Controls.Add(this.btnUpdateLoan);
            this.groupBox1.Controls.Add(this.btnEditLoan);
            this.groupBox1.Controls.Add(this.btnSaveLoan);
            this.groupBox1.Controls.Add(this.txtLoanEmpName);
            this.groupBox1.Controls.Add(this.dgEmployeeLoanList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLoanAmount);
            this.groupBox1.Controls.Add(this.btnSelectEmployee);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLoanDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboLoanType);
            this.groupBox1.Location = new System.Drawing.Point(30, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 416);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // btnDeleteLoan
            // 
            this.btnDeleteLoan.Location = new System.Drawing.Point(294, 382);
            this.btnDeleteLoan.Name = "btnDeleteLoan";
            this.btnDeleteLoan.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLoan.TabIndex = 14;
            this.btnDeleteLoan.Text = "Delete";
            this.btnDeleteLoan.UseVisualStyleBackColor = true;
            // 
            // btnUpdateLoan
            // 
            this.btnUpdateLoan.Location = new System.Drawing.Point(204, 382);
            this.btnUpdateLoan.Name = "btnUpdateLoan";
            this.btnUpdateLoan.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateLoan.TabIndex = 13;
            this.btnUpdateLoan.Text = "Update";
            this.btnUpdateLoan.UseVisualStyleBackColor = true;
            // 
            // btnEditLoan
            // 
            this.btnEditLoan.Location = new System.Drawing.Point(131, 381);
            this.btnEditLoan.Name = "btnEditLoan";
            this.btnEditLoan.Size = new System.Drawing.Size(67, 25);
            this.btnEditLoan.TabIndex = 12;
            this.btnEditLoan.Text = "Edit";
            this.btnEditLoan.UseVisualStyleBackColor = true;
            // 
            // btnSaveLoan
            // 
            this.btnSaveLoan.Location = new System.Drawing.Point(55, 381);
            this.btnSaveLoan.Name = "btnSaveLoan";
            this.btnSaveLoan.Size = new System.Drawing.Size(65, 24);
            this.btnSaveLoan.TabIndex = 11;
            this.btnSaveLoan.Text = "Save";
            this.btnSaveLoan.UseVisualStyleBackColor = true;
            this.btnSaveLoan.Click += new System.EventHandler(this.btnAddLoan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Amount to Pay:";
            // 
            // txtLoanAmountToPay
            // 
            this.txtLoanAmountToPay.Location = new System.Drawing.Point(132, 18);
            this.txtLoanAmountToPay.Name = "txtLoanAmountToPay";
            this.txtLoanAmountToPay.Size = new System.Drawing.Size(120, 20);
            this.txtLoanAmountToPay.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Payroll Start Date:";
            // 
            // dtLoanPayrollStartDate
            // 
            this.dtLoanPayrollStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtLoanPayrollStartDate.Location = new System.Drawing.Point(132, 48);
            this.dtLoanPayrollStartDate.Name = "dtLoanPayrollStartDate";
            this.dtLoanPayrollStartDate.Size = new System.Drawing.Size(120, 20);
            this.dtLoanPayrollStartDate.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Payroll Cutoff Date:";
            // 
            // dtLoanPayrollCutoffDate
            // 
            this.dtLoanPayrollCutoffDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtLoanPayrollCutoffDate.Location = new System.Drawing.Point(132, 74);
            this.dtLoanPayrollCutoffDate.Name = "dtLoanPayrollCutoffDate";
            this.dtLoanPayrollCutoffDate.Size = new System.Drawing.Size(120, 20);
            this.dtLoanPayrollCutoffDate.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Remaining Amount:";
            // 
            // txtLoanRemainingAmount
            // 
            this.txtLoanRemainingAmount.Location = new System.Drawing.Point(132, 132);
            this.txtLoanRemainingAmount.Name = "txtLoanRemainingAmount";
            this.txtLoanRemainingAmount.Size = new System.Drawing.Size(120, 20);
            this.txtLoanRemainingAmount.TabIndex = 19;
            // 
            // dgLoanEmployeePaymentList
            // 
            this.dgLoanEmployeePaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLoanEmployeePaymentList.Location = new System.Drawing.Point(37, 185);
            this.dgLoanEmployeePaymentList.Name = "dgLoanEmployeePaymentList";
            this.dgLoanEmployeePaymentList.Size = new System.Drawing.Size(375, 157);
            this.dgLoanEmployeePaymentList.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteLoanPayment);
            this.groupBox2.Controls.Add(this.btnUpdateLoanPayment);
            this.groupBox2.Controls.Add(this.btnEditLoanPayment);
            this.groupBox2.Controls.Add(this.btnSaveLoanPayment);
            this.groupBox2.Controls.Add(this.txtLoanAmountPaid);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dgLoanEmployeePaymentList);
            this.groupBox2.Controls.Add(this.txtLoanAmountToPay);
            this.groupBox2.Controls.Add(this.txtLoanRemainingAmount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtLoanPayrollCutoffDate);
            this.groupBox2.Controls.Add(this.dtLoanPayrollStartDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(526, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 388);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // btnDeleteLoanPayment
            // 
            this.btnDeleteLoanPayment.Location = new System.Drawing.Point(294, 353);
            this.btnDeleteLoanPayment.Name = "btnDeleteLoanPayment";
            this.btnDeleteLoanPayment.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLoanPayment.TabIndex = 26;
            this.btnDeleteLoanPayment.Text = "Delete";
            this.btnDeleteLoanPayment.UseVisualStyleBackColor = true;
            // 
            // btnUpdateLoanPayment
            // 
            this.btnUpdateLoanPayment.Location = new System.Drawing.Point(204, 353);
            this.btnUpdateLoanPayment.Name = "btnUpdateLoanPayment";
            this.btnUpdateLoanPayment.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateLoanPayment.TabIndex = 25;
            this.btnUpdateLoanPayment.Text = "Update";
            this.btnUpdateLoanPayment.UseVisualStyleBackColor = true;
            // 
            // btnEditLoanPayment
            // 
            this.btnEditLoanPayment.Location = new System.Drawing.Point(131, 352);
            this.btnEditLoanPayment.Name = "btnEditLoanPayment";
            this.btnEditLoanPayment.Size = new System.Drawing.Size(67, 25);
            this.btnEditLoanPayment.TabIndex = 24;
            this.btnEditLoanPayment.Text = "Edit";
            this.btnEditLoanPayment.UseVisualStyleBackColor = true;
            // 
            // btnSaveLoanPayment
            // 
            this.btnSaveLoanPayment.Location = new System.Drawing.Point(55, 352);
            this.btnSaveLoanPayment.Name = "btnSaveLoanPayment";
            this.btnSaveLoanPayment.Size = new System.Drawing.Size(65, 24);
            this.btnSaveLoanPayment.TabIndex = 23;
            this.btnSaveLoanPayment.Text = "Save";
            this.btnSaveLoanPayment.UseVisualStyleBackColor = true;
            // 
            // txtLoanAmountPaid
            // 
            this.txtLoanAmountPaid.Location = new System.Drawing.Point(131, 103);
            this.txtLoanAmountPaid.Name = "txtLoanAmountPaid";
            this.txtLoanAmountPaid.Size = new System.Drawing.Size(121, 20);
            this.txtLoanAmountPaid.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Amount Paid:";
            // 
            // txtLoanDataPrompt
            // 
            this.txtLoanDataPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.txtLoanDataPrompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoanDataPrompt.ForeColor = System.Drawing.Color.Red;
            this.txtLoanDataPrompt.Location = new System.Drawing.Point(108, 17);
            this.txtLoanDataPrompt.Name = "txtLoanDataPrompt";
            this.txtLoanDataPrompt.Size = new System.Drawing.Size(319, 13);
            this.txtLoanDataPrompt.TabIndex = 15;
            this.txtLoanDataPrompt.Text = "LoanDataPrompt";
            this.txtLoanDataPrompt.Visible = false;
            // 
            // frmLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLoan";
            this.Text = "LoanForm";
            this.Load += new System.EventHandler(this.LoanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployeeLoanList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanEmployeePaymentList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoanEmpName;
        private System.Windows.Forms.Button btnSelectEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboLoanType;
        private System.Windows.Forms.TextBox txtLoanDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoanAmount;
        private System.Windows.Forms.DataGridView dgEmployeeLoanList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteLoan;
        private System.Windows.Forms.Button btnUpdateLoan;
        private System.Windows.Forms.Button btnEditLoan;
        private System.Windows.Forms.Button btnSaveLoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoanAmountToPay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtLoanPayrollStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtLoanPayrollCutoffDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLoanRemainingAmount;
        private System.Windows.Forms.DataGridView dgLoanEmployeePaymentList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteLoanPayment;
        private System.Windows.Forms.Button btnUpdateLoanPayment;
        private System.Windows.Forms.Button btnEditLoanPayment;
        private System.Windows.Forms.Button btnSaveLoanPayment;
        private System.Windows.Forms.TextBox txtLoanAmountPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoanDataPrompt;
    }
}