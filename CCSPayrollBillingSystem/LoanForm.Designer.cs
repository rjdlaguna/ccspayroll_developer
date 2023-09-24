
namespace CCSPayrollBillingSystem
{
    partial class LoanForm
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
            this.grpLoanList = new System.Windows.Forms.GroupBox();
            this.btnPayLoan = new System.Windows.Forms.Button();
            this.txtLoanDataPrompt = new System.Windows.Forms.TextBox();
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
            this.grpLoanPayment = new System.Windows.Forms.GroupBox();
            this.btnSaveLoanPayment = new System.Windows.Forms.Button();
            this.txtLoanAmountPaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployeeLoanList)).BeginInit();
            this.grpLoanList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanEmployeePaymentList)).BeginInit();
            this.grpLoanPayment.SuspendLayout();
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
            this.comboLoanType.Text = "Select";
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
            this.dgEmployeeLoanList.Location = new System.Drawing.Point(18, 231);
            this.dgEmployeeLoanList.Name = "dgEmployeeLoanList";
            this.dgEmployeeLoanList.Size = new System.Drawing.Size(409, 150);
            this.dgEmployeeLoanList.TabIndex = 10;
            this.dgEmployeeLoanList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmployeeLoanList_CellClick);
            this.dgEmployeeLoanList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmployeeLoanList_CellContentClick);
            // 
            // grpLoanList
            // 
            this.grpLoanList.Controls.Add(this.btnPayLoan);
            this.grpLoanList.Controls.Add(this.txtLoanDataPrompt);
            this.grpLoanList.Controls.Add(this.btnSaveLoan);
            this.grpLoanList.Controls.Add(this.txtLoanEmpName);
            this.grpLoanList.Controls.Add(this.dgEmployeeLoanList);
            this.grpLoanList.Controls.Add(this.label1);
            this.grpLoanList.Controls.Add(this.txtLoanAmount);
            this.grpLoanList.Controls.Add(this.btnSelectEmployee);
            this.grpLoanList.Controls.Add(this.label4);
            this.grpLoanList.Controls.Add(this.label2);
            this.grpLoanList.Controls.Add(this.txtLoanDescription);
            this.grpLoanList.Controls.Add(this.label3);
            this.grpLoanList.Controls.Add(this.comboLoanType);
            this.grpLoanList.Location = new System.Drawing.Point(30, 22);
            this.grpLoanList.Name = "grpLoanList";
            this.grpLoanList.Size = new System.Drawing.Size(463, 416);
            this.grpLoanList.TabIndex = 11;
            this.grpLoanList.TabStop = false;
            // 
            // btnPayLoan
            // 
            this.btnPayLoan.Location = new System.Drawing.Point(169, 387);
            this.btnPayLoan.Name = "btnPayLoan";
            this.btnPayLoan.Size = new System.Drawing.Size(75, 23);
            this.btnPayLoan.TabIndex = 16;
            this.btnPayLoan.Text = "Pay Loan";
            this.btnPayLoan.UseVisualStyleBackColor = true;
            this.btnPayLoan.Click += new System.EventHandler(this.btnPayLoan_Click);
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
            // btnSaveLoan
            // 
            this.btnSaveLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveLoan.Image = global::CCSPayrollBillingSystem.Properties.Resources.floppy_disk;
            this.btnSaveLoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveLoan.Location = new System.Drawing.Point(325, 181);
            this.btnSaveLoan.Name = "btnSaveLoan";
            this.btnSaveLoan.Size = new System.Drawing.Size(102, 42);
            this.btnSaveLoan.TabIndex = 11;
            this.btnSaveLoan.Text = "SAVE";
            this.btnSaveLoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dtLoanPayrollCutoffDate.ValueChanged += new System.EventHandler(this.dtLoanPayrollCutoffDate_ValueChanged);
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
            this.dgLoanEmployeePaymentList.Location = new System.Drawing.Point(25, 228);
            this.dgLoanEmployeePaymentList.Name = "dgLoanEmployeePaymentList";
            this.dgLoanEmployeePaymentList.Size = new System.Drawing.Size(375, 157);
            this.dgLoanEmployeePaymentList.TabIndex = 20;
            // 
            // grpLoanPayment
            // 
            this.grpLoanPayment.Controls.Add(this.btnSaveLoanPayment);
            this.grpLoanPayment.Controls.Add(this.txtLoanAmountPaid);
            this.grpLoanPayment.Controls.Add(this.label9);
            this.grpLoanPayment.Controls.Add(this.dgLoanEmployeePaymentList);
            this.grpLoanPayment.Controls.Add(this.txtLoanAmountToPay);
            this.grpLoanPayment.Controls.Add(this.txtLoanRemainingAmount);
            this.grpLoanPayment.Controls.Add(this.label5);
            this.grpLoanPayment.Controls.Add(this.label8);
            this.grpLoanPayment.Controls.Add(this.label6);
            this.grpLoanPayment.Controls.Add(this.dtLoanPayrollCutoffDate);
            this.grpLoanPayment.Controls.Add(this.dtLoanPayrollStartDate);
            this.grpLoanPayment.Controls.Add(this.label7);
            this.grpLoanPayment.Location = new System.Drawing.Point(526, 25);
            this.grpLoanPayment.Name = "grpLoanPayment";
            this.grpLoanPayment.Size = new System.Drawing.Size(418, 413);
            this.grpLoanPayment.TabIndex = 15;
            this.grpLoanPayment.TabStop = false;
            // 
            // btnSaveLoanPayment
            // 
            this.btnSaveLoanPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveLoanPayment.Image = global::CCSPayrollBillingSystem.Properties.Resources.floppy_disk;
            this.btnSaveLoanPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveLoanPayment.Location = new System.Drawing.Point(316, 184);
            this.btnSaveLoanPayment.Name = "btnSaveLoanPayment";
            this.btnSaveLoanPayment.Size = new System.Drawing.Size(84, 38);
            this.btnSaveLoanPayment.TabIndex = 23;
            this.btnSaveLoanPayment.Text = "SAVE";
            this.btnSaveLoanPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveLoanPayment.UseVisualStyleBackColor = true;
            this.btnSaveLoanPayment.Click += new System.EventHandler(this.btnSaveLoanPayment_Click);
            // 
            // txtLoanAmountPaid
            // 
            this.txtLoanAmountPaid.Location = new System.Drawing.Point(131, 103);
            this.txtLoanAmountPaid.Name = "txtLoanAmountPaid";
            this.txtLoanAmountPaid.Size = new System.Drawing.Size(121, 20);
            this.txtLoanAmountPaid.TabIndex = 22;
            this.txtLoanAmountPaid.TextChanged += new System.EventHandler(this.txtLoanAmountPaid_TextChanged);
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
            // LoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 450);
            this.Controls.Add(this.grpLoanPayment);
            this.Controls.Add(this.grpLoanList);
            this.Name = "LoanForm";
            this.Text = "LoanForm";
            this.Load += new System.EventHandler(this.LoanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployeeLoanList)).EndInit();
            this.grpLoanList.ResumeLayout(false);
            this.grpLoanList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanEmployeePaymentList)).EndInit();
            this.grpLoanPayment.ResumeLayout(false);
            this.grpLoanPayment.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpLoanList;
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
        private System.Windows.Forms.GroupBox grpLoanPayment;
        private System.Windows.Forms.Button btnSaveLoanPayment;
        private System.Windows.Forms.TextBox txtLoanAmountPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoanDataPrompt;
        private System.Windows.Forms.Button btnPayLoan;
    }
}