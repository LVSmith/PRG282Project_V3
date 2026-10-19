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
            this.lblAnimalId = new System.Windows.Forms.Label();
            this.txtAnimalId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSpecies = new System.Windows.Forms.Label();
            this.txtSpecies = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblAnimalId.AutoSize = true;
            this.lblAnimalId.Location = new System.Drawing.Point(40, 43);
            this.lblAnimalId.Name = "lblAnimalId";
            this.lblAnimalId.Text = "Animal ID";
            this.txtAnimalId.Location = new System.Drawing.Point(160, 40);
            this.txtAnimalId.Name = "txtAnimalId";
            this.txtAnimalId.Size = new System.Drawing.Size(160, 22);
            this.txtAnimalId.TabIndex = 0;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(40, 83);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Name";
            this.txtName.Location = new System.Drawing.Point(160, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 22);
            this.txtName.TabIndex = 1;
            this.lblSpecies.AutoSize = true;
            this.lblSpecies.Location = new System.Drawing.Point(40, 123);
            this.lblSpecies.Name = "lblSpecies";
            this.lblSpecies.Text = "Species";
            this.txtSpecies.Location = new System.Drawing.Point(160, 120);
            this.txtSpecies.Name = "txtSpecies";
            this.txtSpecies.Size = new System.Drawing.Size(160, 22);
            this.txtSpecies.TabIndex = 2;
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(40, 163);
            this.lblAge.Name = "lblAge";
            this.lblAge.Text = "Age";
            this.txtAge.Location = new System.Drawing.Point(160, 160);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(160, 22);
            this.txtAge.TabIndex = 3;
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(40, 203);
            this.lblScore.Name = "lblScore";
            this.lblScore.Text = "Recovery Score";
            this.txtScore.Location = new System.Drawing.Point(160, 200);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(160, 22);
            this.txtScore.TabIndex = 4;
            this.btnAdd.Location = new System.Drawing.Point(160, 245);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Animal";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAnimalId);
            this.Controls.Add(this.txtAnimalId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSpecies);
            this.Controls.Add(this.txtSpecies);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.btnAdd);
            this.Name = "Main";
            this.Text = "Wildlife Rescue - Animal Records";
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
}
