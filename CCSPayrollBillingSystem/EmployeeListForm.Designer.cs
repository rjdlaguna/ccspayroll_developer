
namespace CCSPayrollBillingSystem
{
    partial class EmployeeListForm
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
            this.dgEmployeesList = new System.Windows.Forms.DataGridView();
            this.dteditbirthdate = new System.Windows.Forms.DateTimePicker();
            this.dteditdatehired = new System.Windows.Forms.DateTimePicker();
            this.dteditcontractend = new System.Windows.Forms.DateTimePicker();
            this.txteditcontactno = new System.Windows.Forms.TextBox();
            this.txtedithomeaddress = new System.Windows.Forms.TextBox();
            this.txteditlastname = new System.Windows.Forms.TextBox();
            this.txteditmiddlename = new System.Windows.Forms.TextBox();
            this.txteditfirstname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearchlastname = new System.Windows.Forms.TextBox();
            this.txtsearchfirstname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbEditJob = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployeesList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEmployeesList
            // 
            this.dgEmployeesList.AllowUserToAddRows = false;
            this.dgEmployeesList.AllowUserToDeleteRows = false;
            this.dgEmployeesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployeesList.Location = new System.Drawing.Point(370, 121);
            this.dgEmployeesList.Name = "dgEmployeesList";
            this.dgEmployeesList.ReadOnly = true;
            this.dgEmployeesList.Size = new System.Drawing.Size(514, 300);
            this.dgEmployeesList.TabIndex = 52;
            this.dgEmployeesList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmployeesList_CellClick);
            this.dgEmployeesList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmployeesList_CellContentClick);
            this.dgEmployeesList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmployeesList_CellDoubleClick);
            // 
            // dteditbirthdate
            // 
            this.dteditbirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteditbirthdate.Location = new System.Drawing.Point(96, 235);
            this.dteditbirthdate.Name = "dteditbirthdate";
            this.dteditbirthdate.Size = new System.Drawing.Size(110, 20);
            this.dteditbirthdate.TabIndex = 51;
            // 
            // dteditdatehired
            // 
            this.dteditdatehired.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteditdatehired.Location = new System.Drawing.Point(96, 58);
            this.dteditdatehired.Name = "dteditdatehired";
            this.dteditdatehired.Size = new System.Drawing.Size(120, 20);
            this.dteditdatehired.TabIndex = 50;
            // 
            // dteditcontractend
            // 
            this.dteditcontractend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteditcontractend.Location = new System.Drawing.Point(96, 94);
            this.dteditcontractend.Name = "dteditcontractend";
            this.dteditcontractend.Size = new System.Drawing.Size(120, 20);
            this.dteditcontractend.TabIndex = 49;
            // 
            // txteditcontactno
            // 
            this.txteditcontactno.Location = new System.Drawing.Point(95, 199);
            this.txteditcontactno.Name = "txteditcontactno";
            this.txteditcontactno.Size = new System.Drawing.Size(162, 20);
            this.txteditcontactno.TabIndex = 48;
            // 
            // txtedithomeaddress
            // 
            this.txtedithomeaddress.Location = new System.Drawing.Point(96, 140);
            this.txtedithomeaddress.Multiline = true;
            this.txtedithomeaddress.Name = "txtedithomeaddress";
            this.txtedithomeaddress.Size = new System.Drawing.Size(210, 38);
            this.txtedithomeaddress.TabIndex = 47;
            // 
            // txteditlastname
            // 
            this.txteditlastname.Location = new System.Drawing.Point(96, 107);
            this.txteditlastname.Name = "txteditlastname";
            this.txteditlastname.Size = new System.Drawing.Size(161, 20);
            this.txteditlastname.TabIndex = 46;
            // 
            // txteditmiddlename
            // 
            this.txteditmiddlename.Location = new System.Drawing.Point(96, 74);
            this.txteditmiddlename.Name = "txteditmiddlename";
            this.txteditmiddlename.Size = new System.Drawing.Size(161, 20);
            this.txteditmiddlename.TabIndex = 45;
            // 
            // txteditfirstname
            // 
            this.txteditfirstname.Location = new System.Drawing.Point(96, 36);
            this.txteditfirstname.Name = "txteditfirstname";
            this.txteditfirstname.Size = new System.Drawing.Size(161, 20);
            this.txteditfirstname.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "End of Contract:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Date Hired:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Date of Birth:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Contact No.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Home Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Middle Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "First Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtsearchlastname);
            this.groupBox1.Controls.Add(this.txtsearchfirstname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(373, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 65);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter employee name to search:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "First Name:";
            // 
            // txtsearchlastname
            // 
            this.txtsearchlastname.Location = new System.Drawing.Point(290, 27);
            this.txtsearchlastname.Name = "txtsearchlastname";
            this.txtsearchlastname.Size = new System.Drawing.Size(120, 20);
            this.txtsearchlastname.TabIndex = 13;
            // 
            // txtsearchfirstname
            // 
            this.txtsearchfirstname.Location = new System.Drawing.Point(77, 27);
            this.txtsearchfirstname.Name = "txtsearchfirstname";
            this.txtsearchfirstname.Size = new System.Drawing.Size(125, 20);
            this.txtsearchfirstname.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Last Name:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::CCSPayrollBillingSystem.Properties.Resources.loupe2;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(425, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::CCSPayrollBillingSystem.Properties.Resources.refresh;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(900, 185);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::CCSPayrollBillingSystem.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(900, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::CCSPayrollBillingSystem.Properties.Resources.edit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(900, 121);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 32;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dteditbirthdate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txteditcontactno);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtedithomeaddress);
            this.groupBox2.Controls.Add(this.txteditfirstname);
            this.groupBox2.Controls.Add(this.txteditlastname);
            this.groupBox2.Controls.Add(this.txteditmiddlename);
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 276);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbEditJob);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.dteditdatehired);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dteditcontractend);
            this.groupBox3.Location = new System.Drawing.Point(12, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 122);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            // 
            // cmbEditJob
            // 
            this.cmbEditJob.FormattingEnabled = true;
            this.cmbEditJob.Location = new System.Drawing.Point(95, 19);
            this.cmbEditJob.Name = "cmbEditJob";
            this.cmbEditJob.Size = new System.Drawing.Size(121, 21);
            this.cmbEditJob.TabIndex = 52;
            this.cmbEditJob.Text = "Select";
            this.cmbEditJob.SelectedIndexChanged += new System.EventHandler(this.cmbEditJob_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Job:";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::CCSPayrollBillingSystem.Properties.Resources.bin;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(900, 236);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // EmployeeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgEmployeesList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Name = "EmployeeListForm";
            this.Text = "EmployeeListForm";
            this.Load += new System.EventHandler(this.EmployeeListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployeesList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEmployeesList;
        private System.Windows.Forms.DateTimePicker dteditbirthdate;
        private System.Windows.Forms.DateTimePicker dteditdatehired;
        private System.Windows.Forms.DateTimePicker dteditcontractend;
        private System.Windows.Forms.TextBox txteditcontactno;
        private System.Windows.Forms.TextBox txtedithomeaddress;
        private System.Windows.Forms.TextBox txteditlastname;
        private System.Windows.Forms.TextBox txteditmiddlename;
        private System.Windows.Forms.TextBox txteditfirstname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsearchlastname;
        private System.Windows.Forms.TextBox txtsearchfirstname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbEditJob;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDelete;
    }
}