using PRG282Project_V3.BusinessLayer;
using PRG282Project_V3.DataLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PRG282Project_V3 {
    public partial class Update : Form {
        private AnimalManager manager = new AnimalManager();

        public Update() {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void btnSearch_Click(object sender, EventArgs e) {
            string id = txbOUID.Text.Trim();
            string name = txbOUName.Text.Trim();
            string species = txbOUSpecies.Text.Trim();

            var animals = manager.GetAllAnimals(); // calls DataHandler.LoadAnimals()

            Animal found = null;
            if (!string.IsNullOrEmpty(id))
                found = animals.FirstOrDefault(a => a.AnimalID.Equals(id, StringComparison.OrdinalIgnoreCase));
            else if (!string.IsNullOrEmpty(name))
                found = animals.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            else if (!string.IsNullOrEmpty(species))
                found = animals.FirstOrDefault(a => a.Species.Equals(species, StringComparison.OrdinalIgnoreCase));

            if (found != null) {
                txbOUID.Text = found.AnimalID;
                txbOUName.Text = found.Name;
                txbOUSpecies.Text = found.Species;
                txbOUAge.Text = found.Age.ToString();
                txbOURecoveryScore.Text = found.RecoveryScore.ToString();
                txbOUStatus.Text = found.Status;
                txbOUHousingUnit.Text = found.HousingUnit;

                pnlNew.Enabled = true; // enable NEW panel
            }
            else {
                MessageBox.Show(@"No matching record found.");
            }
        }

        private void btnUClear_Click(object sender, EventArgs e) {
            foreach (Control c in this.Controls) {
                if (c is TextBox tbx) tbx.Clear();
            }

            pnlNew.Enabled = false; // disable NEW panel again
        }

        private void btnReturn_Click(object sender, EventArgs e) {
            Main mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e) {
            var updatedAnimal = new Animal {
                AnimalID = txbOUID.Text, // ID stays locked
                Name = txbOUName.Text,
                Species = txbOUSpecies.Text,
                Age = int.TryParse(txbOUAge.Text, out int age) ? age : -1,
                RecoveryScore = int.TryParse(txbOURecoveryScore.Text, out int score) ? score : -1
            };

            if (manager.ValidateAnimal(updatedAnimal, out string error)) {
                manager.UpdateAnimal(updatedAnimal);
                MessageBox.Show(@"Animal updated successfully!");
                btnUClear.PerformClick(); // clear after save
            }
            else {
                MessageBox.Show(error);
            }
        }

        private void Update_Load(object sender, EventArgs e) {
            pnlNew.Enabled = false; // disable NEW panel on load
        }
    }
}