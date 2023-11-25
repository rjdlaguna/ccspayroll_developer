
namespace CCSPayrollBillingSystem
{
    partial class ProjectProfileList
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
            this.dgProjectProfileList = new System.Windows.Forms.DataGridView();
            this.txtsearchprojectname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txteditProjectName = new System.Windows.Forms.TextBox();
            this.txteditProjectDesc = new System.Windows.Forms.TextBox();
            this.txteditProjectAdd = new System.Windows.Forms.TextBox();
            this.txteditProjectInCharge = new System.Windows.Forms.TextBox();
            this.txteditProjectContact = new System.Windows.Forms.TextBox();
            this.txteditProjectEmail = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddEmpToProject = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectProfileList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgProjectProfileList
            // 
            this.dgProjectProfileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProjectProfileList.Location = new System.Drawing.Point(345, 68);
            this.dgProjectProfileList.Name = "dgProjectProfileList";
            this.dgProjectProfileList.ReadOnly = true;
            this.dgProjectProfileList.Size = new System.Drawing.Size(581, 366);
            this.dgProjectProfileList.TabIndex = 0;
            this.dgProjectProfileList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProjectProfileList_CellClick);
            this.dgProjectProfileList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProjectProfileList_CellContentClick);
            this.dgProjectProfileList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProjectProfileList_CellDoubleClick);
            // 
            // txtsearchprojectname
            // 
            this.txtsearchprojectname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchprojectname.Location = new System.Drawing.Point(140, 15);
            this.txtsearchprojectname.Name = "txtsearchprojectname";
            this.txtsearchprojectname.Size = new System.Drawing.Size(170, 24);
            this.txtsearchprojectname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtsearchprojectname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(345, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 45);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEARCH PROJECT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Project Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Person In Charge:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Contact No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Email Address:";
            // 
            // txteditProjectName
            // 
            this.txteditProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txteditProjectName.Location = new System.Drawing.Point(114, 25);
            this.txteditProjectName.Name = "txteditProjectName";
            this.txteditProjectName.Size = new System.Drawing.Size(156, 20);
            this.txteditProjectName.TabIndex = 33;
            // 
            // txteditProjectDesc
            // 
            this.txteditProjectDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txteditProjectDesc.Location = new System.Drawing.Point(114, 69);
            this.txteditProjectDesc.Multiline = true;
            this.txteditProjectDesc.Name = "txteditProjectDesc";
            this.txteditProjectDesc.Size = new System.Drawing.Size(188, 48);
            this.txteditProjectDesc.TabIndex = 34;
            // 
            // txteditProjectAdd
            // 
            this.txteditProjectAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txteditProjectAdd.Location = new System.Drawing.Point(114, 130);
            this.txteditProjectAdd.Multiline = true;
            this.txteditProjectAdd.Name = "txteditProjectAdd";
            this.txteditProjectAdd.Size = new System.Drawing.Size(188, 48);
            this.txteditProjectAdd.TabIndex = 35;
            // 
            // txteditProjectInCharge
            // 
            this.txteditProjectInCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txteditProjectInCharge.Location = new System.Drawing.Point(114, 187);
            this.txteditProjectInCharge.Name = "txteditProjectInCharge";
            this.txteditProjectInCharge.Size = new System.Drawing.Size(156, 20);
            this.txteditProjectInCharge.TabIndex = 36;
            // 
            // txteditProjectContact
            // 
            this.txteditProjectContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txteditProjectContact.Location = new System.Drawing.Point(114, 224);
            this.txteditProjectContact.Name = "txteditProjectContact";
            this.txteditProjectContact.Size = new System.Drawing.Size(156, 20);
            this.txteditProjectContact.TabIndex = 37;
            // 
            // txteditProjectEmail
            // 
            this.txteditProjectEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txteditProjectEmail.Location = new System.Drawing.Point(114, 261);
            this.txteditProjectEmail.Name = "txteditProjectEmail";
            this.txteditProjectEmail.Size = new System.Drawing.Size(156, 20);
            this.txteditProjectEmail.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddEmpToProject);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txteditProjectEmail);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txteditProjectContact);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txteditProjectInCharge);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txteditProjectAdd);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txteditProjectDesc);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txteditProjectName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 356);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PROJECT DETAILS";
            // 
            // btnAddEmpToProject
            // 
            this.btnAddEmpToProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmpToProject.Location = new System.Drawing.Point(114, 305);
            this.btnAddEmpToProject.Name = "btnAddEmpToProject";
            this.btnAddEmpToProject.Size = new System.Drawing.Size(167, 32);
            this.btnAddEmpToProject.TabIndex = 39;
            this.btnAddEmpToProject.Text = "Add Employee To Project";
            this.btnAddEmpToProject.UseVisualStyleBackColor = true;
            this.btnAddEmpToProject.Click += new System.EventHandler(this.btnAddEmpToProject_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::CCSPayrollBillingSystem.Properties.Resources.bin;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(950, 268);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 40);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::CCSPayrollBillingSystem.Properties.Resources.refresh;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(950, 211);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::CCSPayrollBillingSystem.Properties.Resources.edit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(950, 155);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 41;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::CCSPayrollBillingSystem.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(950, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 40);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::CCSPayrollBillingSystem.Properties.Resources.loupe2;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(323, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 30);
            this.btnSearch.TabIndex = 40;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ProjectProfileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 459);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgProjectProfileList);
            this.Name = "ProjectProfileList";
            this.Text = "List of Projects";
            this.Load += new System.EventHandler(this.ProjectProfileList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectProfileList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProjectProfileList;
        private System.Windows.Forms.TextBox txtsearchprojectname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txteditProjectName;
        private System.Windows.Forms.TextBox txteditProjectDesc;
        private System.Windows.Forms.TextBox txteditProjectAdd;
        private System.Windows.Forms.TextBox txteditProjectInCharge;
        private System.Windows.Forms.TextBox txteditProjectContact;
        private System.Windows.Forms.TextBox txteditProjectEmail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddEmpToProject;
        private System.Windows.Forms.Button btnDelete;
    }
}