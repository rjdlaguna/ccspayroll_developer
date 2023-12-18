
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBilling));
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
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gbWorkDays = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRegHolRestDay = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRegHolRestDayRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegHolRestDay = new System.Windows.Forms.TextBox();
            this.txtRegDaysRate = new System.Windows.Forms.TextBox();
            this.txtOthersRate = new System.Windows.Forms.TextBox();
            this.txtPDARate = new System.Windows.Forms.TextBox();
            this.txtRegOTRate = new System.Windows.Forms.TextBox();
            this.txtCOLARate = new System.Windows.Forms.TextBox();
            this.txtSplHolidaysRate = new System.Windows.Forms.TextBox();
            this.txtRegHolidaysOTRate = new System.Windows.Forms.TextBox();
            this.txtSplHolidaysOTRate = new System.Windows.Forms.TextBox();
            this.txtRegHolidaysRate = new System.Windows.Forms.TextBox();
            this.txtRegDays = new System.Windows.Forms.TextBox();
            this.txtOthers = new System.Windows.Forms.TextBox();
            this.lblRegDays = new System.Windows.Forms.Label();
            this.lblOthers = new System.Windows.Forms.Label();
            this.lblRegOT = new System.Windows.Forms.Label();
            this.txtPDA = new System.Windows.Forms.TextBox();
            this.txtRegOT = new System.Windows.Forms.TextBox();
            this.lblPDA = new System.Windows.Forms.Label();
            this.lblSplHolidays = new System.Windows.Forms.Label();
            this.txtCOLA = new System.Windows.Forms.TextBox();
            this.txtSplHolidays = new System.Windows.Forms.TextBox();
            this.lblCOLA = new System.Windows.Forms.Label();
            this.lblSplHolidaysOT = new System.Windows.Forms.Label();
            this.txtRegHolidaysOT = new System.Windows.Forms.TextBox();
            this.txtSplHolidaysOT = new System.Windows.Forms.TextBox();
            this.lblRegHolidaysOT = new System.Windows.Forms.Label();
            this.lblRegHolidays = new System.Windows.Forms.Label();
            this.txtRegHolidays = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList4Billing)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbWorkDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployeeList4Billing
            // 
            this.dgvEmployeeList4Billing.AllowUserToAddRows = false;
            this.dgvEmployeeList4Billing.AllowUserToDeleteRows = false;
            this.dgvEmployeeList4Billing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeList4Billing.Location = new System.Drawing.Point(549, 285);
            this.dgvEmployeeList4Billing.Name = "dgvEmployeeList4Billing";
            this.dgvEmployeeList4Billing.ReadOnly = true;
            dataGridViewCellStyle1.NullValue = "0";
            this.dgvEmployeeList4Billing.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployeeList4Billing.Size = new System.Drawing.Size(465, 171);
            this.dgvEmployeeList4Billing.TabIndex = 68;
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(378, 39);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(144, 20);
            this.txtVAT.TabIndex = 67;
            this.txtVAT.Text = "0.00";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 137);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PROJECT DETAILS";
            // 
            // cmbProject
            // 
            this.cmbProject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
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
            this.txtNetTotal.Location = new System.Drawing.Point(378, 65);
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.ReadOnly = true;
            this.txtNetTotal.Size = new System.Drawing.Size(144, 20);
            this.txtNetTotal.TabIndex = 65;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(321, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 64;
            this.label18.Text = "Net Pay :";
            // 
            // txtGrossTotal
            // 
            this.txtGrossTotal.Location = new System.Drawing.Point(378, 12);
            this.txtGrossTotal.Name = "txtGrossTotal";
            this.txtGrossTotal.ReadOnly = true;
            this.txtGrossTotal.Size = new System.Drawing.Size(144, 20);
            this.txtGrossTotal.TabIndex = 63;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(311, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "Gross Pay :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(338, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 66;
            this.label19.Text = "VAT :";
            // 
            // rtbBillingSlip
            // 
            this.rtbBillingSlip.Location = new System.Drawing.Point(549, 12);
            this.rtbBillingSlip.Name = "rtbBillingSlip";
            this.rtbBillingSlip.Size = new System.Drawing.Size(465, 257);
            this.rtbBillingSlip.TabIndex = 69;
            this.rtbBillingSlip.Text = "";
            this.rtbBillingSlip.WordWrap = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Image = global::CCSPayrollBillingSystem.Properties.Resources.refresh;
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(350, 109);
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
            this.btnCalculate.Location = new System.Drawing.Point(350, 169);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(128, 40);
            this.btnCalculate.TabIndex = 71;
            this.btnCalculate.Text = "CALCULATE";
            this.btnCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::CCSPayrollBillingSystem.Properties.Resources.printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(350, 229);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(128, 40);
            this.btnPrint.TabIndex = 72;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gbWorkDays
            // 
            this.gbWorkDays.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gbWorkDays.Controls.Add(this.btnOK);
            this.gbWorkDays.Controls.Add(this.btnNext);
            this.gbWorkDays.Controls.Add(this.btnPrevious);
            this.gbWorkDays.Controls.Add(this.txtFullName);
            this.gbWorkDays.Controls.Add(this.label3);
            this.gbWorkDays.Controls.Add(this.label13);
            this.gbWorkDays.Controls.Add(this.label14);
            this.gbWorkDays.Controls.Add(this.label11);
            this.gbWorkDays.Controls.Add(this.label12);
            this.gbWorkDays.Controls.Add(this.label10);
            this.gbWorkDays.Controls.Add(this.lblRegHolRestDay);
            this.gbWorkDays.Controls.Add(this.label9);
            this.gbWorkDays.Controls.Add(this.txtRegHolRestDayRate);
            this.gbWorkDays.Controls.Add(this.label7);
            this.gbWorkDays.Controls.Add(this.txtRegHolRestDay);
            this.gbWorkDays.Controls.Add(this.txtRegDaysRate);
            this.gbWorkDays.Controls.Add(this.txtOthersRate);
            this.gbWorkDays.Controls.Add(this.txtPDARate);
            this.gbWorkDays.Controls.Add(this.txtRegOTRate);
            this.gbWorkDays.Controls.Add(this.txtCOLARate);
            this.gbWorkDays.Controls.Add(this.txtSplHolidaysRate);
            this.gbWorkDays.Controls.Add(this.txtRegHolidaysOTRate);
            this.gbWorkDays.Controls.Add(this.txtSplHolidaysOTRate);
            this.gbWorkDays.Controls.Add(this.txtRegHolidaysRate);
            this.gbWorkDays.Controls.Add(this.txtRegDays);
            this.gbWorkDays.Controls.Add(this.txtOthers);
            this.gbWorkDays.Controls.Add(this.lblRegDays);
            this.gbWorkDays.Controls.Add(this.lblOthers);
            this.gbWorkDays.Controls.Add(this.lblRegOT);
            this.gbWorkDays.Controls.Add(this.txtPDA);
            this.gbWorkDays.Controls.Add(this.txtRegOT);
            this.gbWorkDays.Controls.Add(this.lblPDA);
            this.gbWorkDays.Controls.Add(this.lblSplHolidays);
            this.gbWorkDays.Controls.Add(this.txtCOLA);
            this.gbWorkDays.Controls.Add(this.txtSplHolidays);
            this.gbWorkDays.Controls.Add(this.lblCOLA);
            this.gbWorkDays.Controls.Add(this.lblSplHolidaysOT);
            this.gbWorkDays.Controls.Add(this.txtRegHolidaysOT);
            this.gbWorkDays.Controls.Add(this.txtSplHolidaysOT);
            this.gbWorkDays.Controls.Add(this.lblRegHolidaysOT);
            this.gbWorkDays.Controls.Add(this.lblRegHolidays);
            this.gbWorkDays.Controls.Add(this.txtRegHolidays);
            this.gbWorkDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWorkDays.Location = new System.Drawing.Point(12, 162);
            this.gbWorkDays.Name = "gbWorkDays";
            this.gbWorkDays.Size = new System.Drawing.Size(305, 362);
            this.gbWorkDays.TabIndex = 73;
            this.gbWorkDays.TabStop = false;
            this.gbWorkDays.Text = "BILLING EMPLOYEE";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(118, 22);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 77;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(36, 22);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 25);
            this.btnPrevious.TabIndex = 76;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(62, 54);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(216, 20);
            this.txtFullName.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Name :";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(174, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "day(s)";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(177, 221);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "hrs.";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(174, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "day(s)";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(177, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "hrs.";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(174, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "day(s)";
            // 
            // lblRegHolRestDay
            // 
            this.lblRegHolRestDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegHolRestDay.AutoSize = true;
            this.lblRegHolRestDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegHolRestDay.Location = new System.Drawing.Point(6, 247);
            this.lblRegHolRestDay.Name = "lblRegHolRestDay";
            this.lblRegHolRestDay.Size = new System.Drawing.Size(107, 13);
            this.lblRegHolRestDay.TabIndex = 39;
            this.lblRegHolRestDay.Text = "Reg. Hol. | Rest Day:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(177, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "hrs.";
            // 
            // txtRegHolRestDayRate
            // 
            this.txtRegHolRestDayRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegHolRestDayRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegHolRestDayRate.Location = new System.Drawing.Point(215, 244);
            this.txtRegHolRestDayRate.Name = "txtRegHolRestDayRate";
            this.txtRegHolRestDayRate.Size = new System.Drawing.Size(82, 20);
            this.txtRegHolRestDayRate.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(172, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "day(s)";
            // 
            // txtRegHolRestDay
            // 
            this.txtRegHolRestDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegHolRestDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegHolRestDay.Location = new System.Drawing.Point(118, 244);
            this.txtRegHolRestDay.Name = "txtRegHolRestDay";
            this.txtRegHolRestDay.ReadOnly = true;
            this.txtRegHolRestDay.Size = new System.Drawing.Size(44, 20);
            this.txtRegHolRestDay.TabIndex = 37;
            this.txtRegHolRestDay.Text = "0";
            // 
            // txtRegDaysRate
            // 
            this.txtRegDaysRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegDaysRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegDaysRate.Location = new System.Drawing.Point(215, 87);
            this.txtRegDaysRate.Name = "txtRegDaysRate";
            this.txtRegDaysRate.ReadOnly = true;
            this.txtRegDaysRate.Size = new System.Drawing.Size(82, 20);
            this.txtRegDaysRate.TabIndex = 27;
            // 
            // txtOthersRate
            // 
            this.txtOthersRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOthersRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOthersRate.Location = new System.Drawing.Point(215, 329);
            this.txtOthersRate.Name = "txtOthersRate";
            this.txtOthersRate.Size = new System.Drawing.Size(82, 20);
            this.txtOthersRate.TabIndex = 35;
            // 
            // txtPDARate
            // 
            this.txtPDARate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPDARate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDARate.Location = new System.Drawing.Point(215, 303);
            this.txtPDARate.Name = "txtPDARate";
            this.txtPDARate.Size = new System.Drawing.Size(82, 20);
            this.txtPDARate.TabIndex = 34;
            // 
            // txtRegOTRate
            // 
            this.txtRegOTRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegOTRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegOTRate.Location = new System.Drawing.Point(215, 113);
            this.txtRegOTRate.Name = "txtRegOTRate";
            this.txtRegOTRate.Size = new System.Drawing.Size(82, 20);
            this.txtRegOTRate.TabIndex = 28;
            // 
            // txtCOLARate
            // 
            this.txtCOLARate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCOLARate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCOLARate.Location = new System.Drawing.Point(215, 277);
            this.txtCOLARate.Name = "txtCOLARate";
            this.txtCOLARate.Size = new System.Drawing.Size(82, 20);
            this.txtCOLARate.TabIndex = 33;
            // 
            // txtSplHolidaysRate
            // 
            this.txtSplHolidaysRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSplHolidaysRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSplHolidaysRate.Location = new System.Drawing.Point(215, 139);
            this.txtSplHolidaysRate.Name = "txtSplHolidaysRate";
            this.txtSplHolidaysRate.Size = new System.Drawing.Size(82, 20);
            this.txtSplHolidaysRate.TabIndex = 29;
            // 
            // txtRegHolidaysOTRate
            // 
            this.txtRegHolidaysOTRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegHolidaysOTRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegHolidaysOTRate.Location = new System.Drawing.Point(215, 217);
            this.txtRegHolidaysOTRate.Name = "txtRegHolidaysOTRate";
            this.txtRegHolidaysOTRate.Size = new System.Drawing.Size(82, 20);
            this.txtRegHolidaysOTRate.TabIndex = 32;
            // 
            // txtSplHolidaysOTRate
            // 
            this.txtSplHolidaysOTRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSplHolidaysOTRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSplHolidaysOTRate.Location = new System.Drawing.Point(215, 165);
            this.txtSplHolidaysOTRate.Name = "txtSplHolidaysOTRate";
            this.txtSplHolidaysOTRate.Size = new System.Drawing.Size(82, 20);
            this.txtSplHolidaysOTRate.TabIndex = 30;
            // 
            // txtRegHolidaysRate
            // 
            this.txtRegHolidaysRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegHolidaysRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegHolidaysRate.Location = new System.Drawing.Point(215, 191);
            this.txtRegHolidaysRate.Name = "txtRegHolidaysRate";
            this.txtRegHolidaysRate.Size = new System.Drawing.Size(82, 20);
            this.txtRegHolidaysRate.TabIndex = 31;
            // 
            // txtRegDays
            // 
            this.txtRegDays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegDays.Location = new System.Drawing.Point(118, 87);
            this.txtRegDays.Name = "txtRegDays";
            this.txtRegDays.ReadOnly = true;
            this.txtRegDays.Size = new System.Drawing.Size(44, 20);
            this.txtRegDays.TabIndex = 1;
            this.txtRegDays.Text = "0";
            // 
            // txtOthers
            // 
            this.txtOthers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOthers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOthers.Location = new System.Drawing.Point(118, 329);
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.ReadOnly = true;
            this.txtOthers.Size = new System.Drawing.Size(44, 20);
            this.txtOthers.TabIndex = 26;
            this.txtOthers.Text = "0";
            // 
            // lblRegDays
            // 
            this.lblRegDays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegDays.AutoSize = true;
            this.lblRegDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegDays.Location = new System.Drawing.Point(38, 90);
            this.lblRegDays.Name = "lblRegDays";
            this.lblRegDays.Size = new System.Drawing.Size(77, 13);
            this.lblRegDays.TabIndex = 9;
            this.lblRegDays.Text = "Regular Days :";
            // 
            // lblOthers
            // 
            this.lblOthers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOthers.AutoSize = true;
            this.lblOthers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOthers.Location = new System.Drawing.Point(71, 332);
            this.lblOthers.Name = "lblOthers";
            this.lblOthers.Size = new System.Drawing.Size(44, 13);
            this.lblOthers.TabIndex = 25;
            this.lblOthers.Text = "Others :";
            // 
            // lblRegOT
            // 
            this.lblRegOT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegOT.AutoSize = true;
            this.lblRegOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegOT.Location = new System.Drawing.Point(47, 116);
            this.lblRegOT.Name = "lblRegOT";
            this.lblRegOT.Size = new System.Drawing.Size(68, 13);
            this.lblRegOT.TabIndex = 11;
            this.lblRegOT.Text = "Regular OT :";
            // 
            // txtPDA
            // 
            this.txtPDA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDA.Location = new System.Drawing.Point(118, 303);
            this.txtPDA.Name = "txtPDA";
            this.txtPDA.ReadOnly = true;
            this.txtPDA.Size = new System.Drawing.Size(44, 20);
            this.txtPDA.TabIndex = 24;
            this.txtPDA.Text = "0";
            // 
            // txtRegOT
            // 
            this.txtRegOT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegOT.Location = new System.Drawing.Point(118, 113);
            this.txtRegOT.Name = "txtRegOT";
            this.txtRegOT.ReadOnly = true;
            this.txtRegOT.Size = new System.Drawing.Size(44, 20);
            this.txtRegOT.TabIndex = 12;
            this.txtRegOT.Text = "0";
            // 
            // lblPDA
            // 
            this.lblPDA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPDA.AutoSize = true;
            this.lblPDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDA.Location = new System.Drawing.Point(80, 306);
            this.lblPDA.Name = "lblPDA";
            this.lblPDA.Size = new System.Drawing.Size(35, 13);
            this.lblPDA.TabIndex = 23;
            this.lblPDA.Text = "PDA :";
            // 
            // lblSplHolidays
            // 
            this.lblSplHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSplHolidays.AutoSize = true;
            this.lblSplHolidays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplHolidays.Location = new System.Drawing.Point(24, 142);
            this.lblSplHolidays.Name = "lblSplHolidays";
            this.lblSplHolidays.Size = new System.Drawing.Size(91, 13);
            this.lblSplHolidays.TabIndex = 13;
            this.lblSplHolidays.Text = "Special Holidays :";
            // 
            // txtCOLA
            // 
            this.txtCOLA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCOLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCOLA.Location = new System.Drawing.Point(118, 277);
            this.txtCOLA.Name = "txtCOLA";
            this.txtCOLA.ReadOnly = true;
            this.txtCOLA.Size = new System.Drawing.Size(44, 20);
            this.txtCOLA.TabIndex = 22;
            this.txtCOLA.Text = "0";
            // 
            // txtSplHolidays
            // 
            this.txtSplHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSplHolidays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSplHolidays.Location = new System.Drawing.Point(118, 139);
            this.txtSplHolidays.Name = "txtSplHolidays";
            this.txtSplHolidays.ReadOnly = true;
            this.txtSplHolidays.Size = new System.Drawing.Size(44, 20);
            this.txtSplHolidays.TabIndex = 14;
            this.txtSplHolidays.Text = "0";
            // 
            // lblCOLA
            // 
            this.lblCOLA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCOLA.AutoSize = true;
            this.lblCOLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCOLA.Location = new System.Drawing.Point(74, 280);
            this.lblCOLA.Name = "lblCOLA";
            this.lblCOLA.Size = new System.Drawing.Size(41, 13);
            this.lblCOLA.TabIndex = 21;
            this.lblCOLA.Text = "COLA :";
            // 
            // lblSplHolidaysOT
            // 
            this.lblSplHolidaysOT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSplHolidaysOT.AutoSize = true;
            this.lblSplHolidaysOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplHolidaysOT.Location = new System.Drawing.Point(6, 168);
            this.lblSplHolidaysOT.Name = "lblSplHolidaysOT";
            this.lblSplHolidaysOT.Size = new System.Drawing.Size(109, 13);
            this.lblSplHolidaysOT.TabIndex = 15;
            this.lblSplHolidaysOT.Text = "Special Holidays OT :";
            // 
            // txtRegHolidaysOT
            // 
            this.txtRegHolidaysOT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegHolidaysOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegHolidaysOT.Location = new System.Drawing.Point(118, 217);
            this.txtRegHolidaysOT.Name = "txtRegHolidaysOT";
            this.txtRegHolidaysOT.ReadOnly = true;
            this.txtRegHolidaysOT.Size = new System.Drawing.Size(44, 20);
            this.txtRegHolidaysOT.TabIndex = 20;
            this.txtRegHolidaysOT.Text = "0";
            // 
            // txtSplHolidaysOT
            // 
            this.txtSplHolidaysOT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSplHolidaysOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSplHolidaysOT.Location = new System.Drawing.Point(118, 165);
            this.txtSplHolidaysOT.Name = "txtSplHolidaysOT";
            this.txtSplHolidaysOT.ReadOnly = true;
            this.txtSplHolidaysOT.Size = new System.Drawing.Size(44, 20);
            this.txtSplHolidaysOT.TabIndex = 16;
            this.txtSplHolidaysOT.Text = "0";
            // 
            // lblRegHolidaysOT
            // 
            this.lblRegHolidaysOT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegHolidaysOT.AutoSize = true;
            this.lblRegHolidaysOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegHolidaysOT.Location = new System.Drawing.Point(9, 220);
            this.lblRegHolidaysOT.Name = "lblRegHolidaysOT";
            this.lblRegHolidaysOT.Size = new System.Drawing.Size(106, 13);
            this.lblRegHolidaysOT.TabIndex = 19;
            this.lblRegHolidaysOT.Text = "Regular Holiday OT :";
            // 
            // lblRegHolidays
            // 
            this.lblRegHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegHolidays.AutoSize = true;
            this.lblRegHolidays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegHolidays.Location = new System.Drawing.Point(22, 194);
            this.lblRegHolidays.Name = "lblRegHolidays";
            this.lblRegHolidays.Size = new System.Drawing.Size(93, 13);
            this.lblRegHolidays.TabIndex = 17;
            this.lblRegHolidays.Text = "Regular Holidays :";
            // 
            // txtRegHolidays
            // 
            this.txtRegHolidays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegHolidays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegHolidays.Location = new System.Drawing.Point(118, 191);
            this.txtRegHolidays.Name = "txtRegHolidays";
            this.txtRegHolidays.ReadOnly = true;
            this.txtRegHolidays.Size = new System.Drawing.Size(44, 20);
            this.txtRegHolidays.TabIndex = 18;
            this.txtRegHolidays.Text = "0";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(234, 23);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 25);
            this.btnOK.TabIndex = 78;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1028, 536);
            this.Controls.Add(this.gbWorkDays);
            this.Controls.Add(this.btnPrint);
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
            this.Text = " Billing";
            this.Load += new System.EventHandler(this.frmBilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList4Billing)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbWorkDays.ResumeLayout(false);
            this.gbWorkDays.PerformLayout();
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
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox gbWorkDays;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRegHolRestDay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRegHolRestDayRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRegHolRestDay;
        private System.Windows.Forms.TextBox txtRegDaysRate;
        private System.Windows.Forms.TextBox txtOthersRate;
        private System.Windows.Forms.TextBox txtPDARate;
        private System.Windows.Forms.TextBox txtRegOTRate;
        private System.Windows.Forms.TextBox txtCOLARate;
        private System.Windows.Forms.TextBox txtSplHolidaysRate;
        private System.Windows.Forms.TextBox txtRegHolidaysOTRate;
        private System.Windows.Forms.TextBox txtSplHolidaysOTRate;
        private System.Windows.Forms.TextBox txtRegHolidaysRate;
        private System.Windows.Forms.TextBox txtRegDays;
        private System.Windows.Forms.TextBox txtOthers;
        private System.Windows.Forms.Label lblRegDays;
        private System.Windows.Forms.Label lblOthers;
        private System.Windows.Forms.Label lblRegOT;
        private System.Windows.Forms.TextBox txtPDA;
        private System.Windows.Forms.TextBox txtRegOT;
        private System.Windows.Forms.Label lblPDA;
        private System.Windows.Forms.Label lblSplHolidays;
        private System.Windows.Forms.TextBox txtCOLA;
        private System.Windows.Forms.TextBox txtSplHolidays;
        private System.Windows.Forms.Label lblCOLA;
        private System.Windows.Forms.Label lblSplHolidaysOT;
        private System.Windows.Forms.TextBox txtRegHolidaysOT;
        private System.Windows.Forms.TextBox txtSplHolidaysOT;
        private System.Windows.Forms.Label lblRegHolidaysOT;
        private System.Windows.Forms.Label lblRegHolidays;
        private System.Windows.Forms.TextBox txtRegHolidays;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnOK;
    }
}