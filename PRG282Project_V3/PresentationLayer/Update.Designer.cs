namespace PRG282Project_V3.PresentationLayer
{
    partial class Update
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
            btnSaveChanges = new System.Windows.Forms.Button();
            btnReturn = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            pnlOld = new System.Windows.Forms.Panel();
            lblOUStatus = new System.Windows.Forms.Label();
            lblUOID = new System.Windows.Forms.Label();
            txbOUStatus = new System.Windows.Forms.TextBox();
            txbOUID = new System.Windows.Forms.TextBox();
            lblOUHousingUnit = new System.Windows.Forms.Label();
            lblOUName = new System.Windows.Forms.Label();
            txbOUHousingUnit = new System.Windows.Forms.TextBox();
            txbOUName = new System.Windows.Forms.TextBox();
            lblOURecoveryScore = new System.Windows.Forms.Label();
            txbOUSpecies = new System.Windows.Forms.TextBox();
            txbOURecoveryScore = new System.Windows.Forms.TextBox();
            lblSpecies = new System.Windows.Forms.Label();
            lblOUAge = new System.Windows.Forms.Label();
            txbOUAge = new System.Windows.Forms.TextBox();
            pnlNew = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            txbUStatus = new System.Windows.Forms.TextBox();
            tbxUID = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            txbUHousingUnit = new System.Windows.Forms.TextBox();
            txbUName = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            txbUSpecies = new System.Windows.Forms.TextBox();
            txbURecoveryScore = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            txbUAge = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            btnUSearch = new System.Windows.Forms.Button();
            btnUClear = new System.Windows.Forms.Button();
            pnlOld.SuspendLayout();
            pnlNew.SuspendLayout();
            SuspendLayout();
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new System.Drawing.Point(10, 389);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new System.Drawing.Size(66, 22);
            btnSaveChanges.TabIndex = 0;
            btnSaveChanges.Text = "Save";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new System.Drawing.Point(624, 389);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new System.Drawing.Size(66, 22);
            btnReturn.TabIndex = 1;
            btnReturn.Text = "Main";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(273, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(142, 25);
            label1.TabIndex = 2;
            label1.Text = "UPDATE page";
            // 
            // pnlOld
            // 
            pnlOld.BackColor = System.Drawing.SystemColors.ControlDark;
            pnlOld.Controls.Add(lblOUStatus);
            pnlOld.Controls.Add(lblUOID);
            pnlOld.Controls.Add(txbOUStatus);
            pnlOld.Controls.Add(txbOUID);
            pnlOld.Controls.Add(lblOUHousingUnit);
            pnlOld.Controls.Add(lblOUName);
            pnlOld.Controls.Add(txbOUHousingUnit);
            pnlOld.Controls.Add(txbOUName);
            pnlOld.Controls.Add(lblOURecoveryScore);
            pnlOld.Controls.Add(txbOUSpecies);
            pnlOld.Controls.Add(txbOURecoveryScore);
            pnlOld.Controls.Add(lblSpecies);
            pnlOld.Controls.Add(lblOUAge);
            pnlOld.Controls.Add(txbOUAge);
            pnlOld.Location = new System.Drawing.Point(38, 98);
            pnlOld.Name = "pnlOld";
            pnlOld.Size = new System.Drawing.Size(283, 246);
            pnlOld.TabIndex = 5;
            // 
            // lblOUStatus
            // 
            lblOUStatus.AutoSize = true;
            lblOUStatus.Location = new System.Drawing.Point(49, 179);
            lblOUStatus.Name = "lblOUStatus";
            lblOUStatus.Size = new System.Drawing.Size(39, 15);
            lblOUStatus.TabIndex = 27;
            lblOUStatus.Text = "Status";
            // 
            // lblUOID
            // 
            lblUOID.AutoSize = true;
            lblUOID.Location = new System.Drawing.Point(49, 22);
            lblUOID.Name = "lblUOID";
            lblUOID.Size = new System.Drawing.Size(18, 15);
            lblUOID.TabIndex = 5;
            lblUOID.Text = "ID";
            // 
            // txbOUStatus
            // 
            txbOUStatus.Location = new System.Drawing.Point(147, 179);
            txbOUStatus.Name = "txbOUStatus";
            txbOUStatus.Size = new System.Drawing.Size(88, 23);
            txbOUStatus.TabIndex = 28;
            // 
            // txbOUID
            // 
            txbOUID.Location = new System.Drawing.Point(147, 22);
            txbOUID.Name = "txbOUID";
            txbOUID.Size = new System.Drawing.Size(88, 23);
            txbOUID.TabIndex = 6;
            txbOUID.TextChanged += textBox1_TextChanged;
            // 
            // lblOUHousingUnit
            // 
            lblOUHousingUnit.AutoSize = true;
            lblOUHousingUnit.Location = new System.Drawing.Point(49, 209);
            lblOUHousingUnit.Name = "lblOUHousingUnit";
            lblOUHousingUnit.Size = new System.Drawing.Size(77, 15);
            lblOUHousingUnit.TabIndex = 25;
            lblOUHousingUnit.Text = "Housing Unit";
            // 
            // lblOUName
            // 
            lblOUName.AutoSize = true;
            lblOUName.Location = new System.Drawing.Point(49, 54);
            lblOUName.Name = "lblOUName";
            lblOUName.Size = new System.Drawing.Size(39, 15);
            lblOUName.TabIndex = 17;
            lblOUName.Text = "Name";
            // 
            // txbOUHousingUnit
            // 
            txbOUHousingUnit.Location = new System.Drawing.Point(147, 209);
            txbOUHousingUnit.Name = "txbOUHousingUnit";
            txbOUHousingUnit.Size = new System.Drawing.Size(88, 23);
            txbOUHousingUnit.TabIndex = 26;
            // 
            // txbOUName
            // 
            txbOUName.Location = new System.Drawing.Point(147, 54);
            txbOUName.Name = "txbOUName";
            txbOUName.Size = new System.Drawing.Size(88, 23);
            txbOUName.TabIndex = 18;
            // 
            // lblOURecoveryScore
            // 
            lblOURecoveryScore.AutoSize = true;
            lblOURecoveryScore.Location = new System.Drawing.Point(49, 152);
            lblOURecoveryScore.Name = "lblOURecoveryScore";
            lblOURecoveryScore.Size = new System.Drawing.Size(87, 15);
            lblOURecoveryScore.TabIndex = 23;
            lblOURecoveryScore.Text = "Recovery Score";
            // 
            // txbOUSpecies
            // 
            txbOUSpecies.Location = new System.Drawing.Point(147, 89);
            txbOUSpecies.Name = "txbOUSpecies";
            txbOUSpecies.Size = new System.Drawing.Size(88, 23);
            txbOUSpecies.TabIndex = 20;
            // 
            // txbOURecoveryScore
            // 
            txbOURecoveryScore.Location = new System.Drawing.Point(147, 152);
            txbOURecoveryScore.Name = "txbOURecoveryScore";
            txbOURecoveryScore.Size = new System.Drawing.Size(88, 23);
            txbOURecoveryScore.TabIndex = 24;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(49, 89);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new System.Drawing.Size(46, 15);
            lblSpecies.TabIndex = 19;
            lblSpecies.Text = "Species";
            // 
            // lblOUAge
            // 
            lblOUAge.AutoSize = true;
            lblOUAge.Location = new System.Drawing.Point(49, 121);
            lblOUAge.Name = "lblOUAge";
            lblOUAge.Size = new System.Drawing.Size(28, 15);
            lblOUAge.TabIndex = 21;
            lblOUAge.Text = "Age";
            // 
            // txbOUAge
            // 
            txbOUAge.Location = new System.Drawing.Point(147, 121);
            txbOUAge.Name = "txbOUAge";
            txbOUAge.Size = new System.Drawing.Size(88, 23);
            txbOUAge.TabIndex = 22;
            // 
            // pnlNew
            // 
            pnlNew.BackColor = System.Drawing.SystemColors.ControlDark;
            pnlNew.Controls.Add(label5);
            pnlNew.Controls.Add(label6);
            pnlNew.Controls.Add(txbUStatus);
            pnlNew.Controls.Add(tbxUID);
            pnlNew.Controls.Add(label7);
            pnlNew.Controls.Add(label8);
            pnlNew.Controls.Add(txbUHousingUnit);
            pnlNew.Controls.Add(txbUName);
            pnlNew.Controls.Add(label9);
            pnlNew.Controls.Add(txbUSpecies);
            pnlNew.Controls.Add(txbURecoveryScore);
            pnlNew.Controls.Add(label10);
            pnlNew.Controls.Add(label11);
            pnlNew.Controls.Add(txbUAge);
            pnlNew.Location = new System.Drawing.Point(377, 98);
            pnlNew.Name = "pnlNew";
            pnlNew.Size = new System.Drawing.Size(288, 246);
            pnlNew.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(51, 176);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(39, 15);
            label5.TabIndex = 41;
            label5.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(51, 19);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(18, 15);
            label6.TabIndex = 29;
            label6.Text = "ID";
            // 
            // txbUStatus
            // 
            txbUStatus.Location = new System.Drawing.Point(149, 176);
            txbUStatus.Name = "txbUStatus";
            txbUStatus.Size = new System.Drawing.Size(88, 23);
            txbUStatus.TabIndex = 42;
            // 
            // tbxUID
            // 
            tbxUID.Location = new System.Drawing.Point(149, 19);
            tbxUID.Name = "tbxUID";
            tbxUID.Size = new System.Drawing.Size(88, 23);
            tbxUID.TabIndex = 30;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(51, 206);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(77, 15);
            label7.TabIndex = 39;
            label7.Text = "Housing Unit";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(51, 52);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(39, 15);
            label8.TabIndex = 31;
            label8.Text = "Name";
            // 
            // txbUHousingUnit
            // 
            txbUHousingUnit.Location = new System.Drawing.Point(149, 206);
            txbUHousingUnit.Name = "txbUHousingUnit";
            txbUHousingUnit.Size = new System.Drawing.Size(88, 23);
            txbUHousingUnit.TabIndex = 40;
            // 
            // txbUName
            // 
            txbUName.Location = new System.Drawing.Point(149, 52);
            txbUName.Name = "txbUName";
            txbUName.Size = new System.Drawing.Size(88, 23);
            txbUName.TabIndex = 32;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(51, 149);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(87, 15);
            label9.TabIndex = 37;
            label9.Text = "Recovery Score";
            // 
            // txbUSpecies
            // 
            txbUSpecies.Location = new System.Drawing.Point(149, 86);
            txbUSpecies.Name = "txbUSpecies";
            txbUSpecies.Size = new System.Drawing.Size(88, 23);
            txbUSpecies.TabIndex = 34;
            // 
            // txbURecoveryScore
            // 
            txbURecoveryScore.Location = new System.Drawing.Point(149, 149);
            txbURecoveryScore.Name = "txbURecoveryScore";
            txbURecoveryScore.Size = new System.Drawing.Size(88, 23);
            txbURecoveryScore.TabIndex = 38;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(51, 86);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(46, 15);
            label10.TabIndex = 33;
            label10.Text = "Species";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(51, 118);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(28, 15);
            label11.TabIndex = 35;
            label11.Text = "Age";
            // 
            // txbUAge
            // 
            txbUAge.Location = new System.Drawing.Point(149, 118);
            txbUAge.Name = "txbUAge";
            txbUAge.Size = new System.Drawing.Size(88, 23);
            txbUAge.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(150, 81);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 15);
            label2.TabIndex = 6;
            label2.Text = "OLD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(508, 81);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(33, 15);
            label3.TabIndex = 7;
            label3.Text = "NEW";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(340, 81);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(18, 15);
            label4.TabIndex = 8;
            label4.Text = "to";
            // 
            // btnUSearch
            // 
            btnUSearch.Location = new System.Drawing.Point(254, 360);
            btnUSearch.Name = "btnUSearch";
            btnUSearch.Size = new System.Drawing.Size(66, 22);
            btnUSearch.TabIndex = 9;
            btnUSearch.Text = "Search";
            btnUSearch.UseVisualStyleBackColor = true;
            btnUSearch.Click += btnSearch_Click;
            // 
            // btnUClear
            // 
            btnUClear.Location = new System.Drawing.Point(385, 360);
            btnUClear.Name = "btnUClear";
            btnUClear.Size = new System.Drawing.Size(66, 22);
            btnUClear.TabIndex = 10;
            btnUClear.Text = "Clear";
            btnUClear.UseVisualStyleBackColor = true;
            btnUClear.Click += btnUClear_Click;
            // 
            // Update
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 422);
            Controls.Add(btnUClear);
            Controls.Add(btnUSearch);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pnlNew);
            Controls.Add(pnlOld);
            Controls.Add(label1);
            Controls.Add(btnReturn);
            Controls.Add(btnSaveChanges);
            Name = "Update";
            Text = "Update";
            Load += Update_Load;
            pnlOld.ResumeLayout(false);
            pnlOld.PerformLayout();
            pnlNew.ResumeLayout(false);
            pnlNew.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlOld;
        private System.Windows.Forms.Panel pnlNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUOID;
        private System.Windows.Forms.TextBox txbOUID;
        private System.Windows.Forms.Label lblOUStatus;
        private System.Windows.Forms.TextBox txbOUStatus;
        private System.Windows.Forms.Label lblOUHousingUnit;
        private System.Windows.Forms.Label lblOUName;
        private System.Windows.Forms.TextBox txbOUHousingUnit;
        private System.Windows.Forms.TextBox txbOUName;
        private System.Windows.Forms.Label lblOURecoveryScore;
        private System.Windows.Forms.TextBox txbOUSpecies;
        private System.Windows.Forms.TextBox txbOURecoveryScore;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.Label lblOUAge;
        private System.Windows.Forms.TextBox txbOUAge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbUStatus;
        private System.Windows.Forms.TextBox tbxUID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbUHousingUnit;
        private System.Windows.Forms.TextBox txbUName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbUSpecies;
        private System.Windows.Forms.TextBox txbURecoveryScore;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbUAge;
        private System.Windows.Forms.Button btnUSearch;
        private System.Windows.Forms.Button btnUClear;
    }
}