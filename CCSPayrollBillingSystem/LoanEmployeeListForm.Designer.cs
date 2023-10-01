
namespace CCSPayrollBillingSystem
{
    partial class LoanEmployeeListForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtloanlastname = new System.Windows.Forms.TextBox();
            this.txtloanfirstname = new System.Windows.Forms.TextBox();
            this.dgLoanEmployeeList = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::CCSPayrollBillingSystem.Properties.Resources.loupe;
            this.btnSearch.Location = new System.Drawing.Point(424, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 21);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtloanlastname
            // 
            this.txtloanlastname.Location = new System.Drawing.Point(303, 37);
            this.txtloanlastname.Name = "txtloanlastname";
            this.txtloanlastname.Size = new System.Drawing.Size(100, 20);
            this.txtloanlastname.TabIndex = 3;
            // 
            // txtloanfirstname
            // 
            this.txtloanfirstname.Location = new System.Drawing.Point(129, 37);
            this.txtloanfirstname.Name = "txtloanfirstname";
            this.txtloanfirstname.Size = new System.Drawing.Size(100, 20);
            this.txtloanfirstname.TabIndex = 4;
            // 
            // dgLoanEmployeeList
            // 
            this.dgLoanEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLoanEmployeeList.Location = new System.Drawing.Point(63, 81);
            this.dgLoanEmployeeList.Name = "dgLoanEmployeeList";
            this.dgLoanEmployeeList.Size = new System.Drawing.Size(546, 235);
            this.dgLoanEmployeeList.TabIndex = 5;
            this.dgLoanEmployeeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLoanEmployeeList_CellClick);
            this.dgLoanEmployeeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLoanEmployeeList_CellContentClick);
            this.dgLoanEmployeeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLoanEmployeeList_CellDoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(654, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(654, 156);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 37);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // LoanEmployeeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 450);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgLoanEmployeeList);
            this.Controls.Add(this.txtloanfirstname);
            this.Controls.Add(this.txtloanlastname);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoanEmployeeListForm";
            this.Text = "LoanEmployeeListForm";
            this.Load += new System.EventHandler(this.LoanEmployeeListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLoanEmployeeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtloanlastname;
        private System.Windows.Forms.TextBox txtloanfirstname;
        private System.Windows.Forms.DataGridView dgLoanEmployeeList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoad;
    }
}