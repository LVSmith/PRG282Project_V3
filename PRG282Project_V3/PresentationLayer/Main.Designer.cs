namespace PRG282Project_V3
{
    partial class Main
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
            lblAnimalId = new System.Windows.Forms.Label();
            txtAnimalId = new System.Windows.Forms.TextBox();
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblSpecies = new System.Windows.Forms.Label();
            txtSpecies = new System.Windows.Forms.TextBox();
            lblAge = new System.Windows.Forms.Label();
            txtAge = new System.Windows.Forms.TextBox();
            lblScore = new System.Windows.Forms.Label();
            txtScore = new System.Windows.Forms.TextBox();
            btnAdd = new System.Windows.Forms.Button();
            btnUpdatePage = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            dgvAnimals = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            SuspendLayout();
            // 
            // lblAnimalId
            // 
            lblAnimalId.AutoSize = true;
            lblAnimalId.Location = new System.Drawing.Point(35, 40);
            lblAnimalId.Name = "lblAnimalId";
            lblAnimalId.Size = new System.Drawing.Size(59, 15);
            lblAnimalId.TabIndex = 0;
            lblAnimalId.Text = "Animal ID";
            // 
            // txtAnimalId
            // 
            txtAnimalId.Location = new System.Drawing.Point(140, 38);
            txtAnimalId.Name = "txtAnimalId";
            txtAnimalId.Size = new System.Drawing.Size(140, 23);
            txtAnimalId.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(35, 78);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(39, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(140, 75);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(140, 23);
            txtName.TabIndex = 1;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(35, 115);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new System.Drawing.Size(46, 15);
            lblSpecies.TabIndex = 2;
            lblSpecies.Text = "Species";
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new System.Drawing.Point(140, 112);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new System.Drawing.Size(140, 23);
            txtSpecies.TabIndex = 2;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new System.Drawing.Point(35, 153);
            lblAge.Name = "lblAge";
            lblAge.Size = new System.Drawing.Size(28, 15);
            lblAge.TabIndex = 3;
            lblAge.Text = "Age";
            // 
            // txtAge
            // 
            txtAge.Location = new System.Drawing.Point(140, 150);
            txtAge.Name = "txtAge";
            txtAge.Size = new System.Drawing.Size(140, 23);
            txtAge.TabIndex = 3;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new System.Drawing.Point(35, 190);
            lblScore.Name = "lblScore";
            lblScore.Size = new System.Drawing.Size(87, 15);
            lblScore.TabIndex = 4;
            lblScore.Text = "Recovery Score";
            // 
            // txtScore
            // 
            txtScore.Location = new System.Drawing.Point(140, 188);
            txtScore.Name = "txtScore";
            txtScore.Size = new System.Drawing.Size(140, 23);
            txtScore.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(103, 230);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(88, 26);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add Animal";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdatePage
            // 
            btnUpdatePage.Location = new System.Drawing.Point(12, 330);
            btnUpdatePage.Name = "btnUpdatePage";
            btnUpdatePage.Size = new System.Drawing.Size(75, 23);
            btnUpdatePage.TabIndex = 6;
            btnUpdatePage.Text = "Update page";
            btnUpdatePage.UseVisualStyleBackColor = true;
            btnUpdatePage.Click += btnUpdatePage_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(569, 330);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 23);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(276, 330);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvAnimals
            // 
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimals.Location = new System.Drawing.Point(332, 38);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.ReadOnly = true;
            dgvAnimals.Size = new System.Drawing.Size(303, 281);
            dgvAnimals.TabIndex = 9;
            // 
            // Main
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(656, 365);
            Controls.Add(dgvAnimals);
            Controls.Add(btnDelete);
            Controls.Add(btnClose);
            Controls.Add(btnUpdatePage);
            Controls.Add(lblAnimalId);
            Controls.Add(txtAnimalId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblSpecies);
            Controls.Add(txtSpecies);
            Controls.Add(lblAge);
            Controls.Add(txtAge);
            Controls.Add(lblScore);
            Controls.Add(txtScore);
            Controls.Add(btnAdd);
            Name = "Main";
            Text = "Wildlife Rescue - Animal Records";
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAnimalId;
        private System.Windows.Forms.TextBox txtAnimalId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.TextBox txtSpecies;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdatePage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvAnimals;
    }
}
