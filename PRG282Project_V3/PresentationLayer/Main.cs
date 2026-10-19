using System;
using System.Windows.Forms;
using PRG282Project_V3.BusinessLayer;
using PRG282Project_V3.DataLayer;

namespace PRG282Project_V3 {
    public partial class Main : Form {
        private AnimalManager manager = new AnimalManager();

        public Main() {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (!manager.ValidateAnimal(txtAnimalId.Text, txtName.Text, txtSpecies.Text, txtAge.Text, txtScore.Text,
                    true, out Animal animal, out string error, out string field)) {
                MessageBox.Show(error, @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FocusField(field);
                return;
            }

            if (!manager.AddAnimal(animal, out error)) {
                MessageBox.Show(error, @"Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"{animal.AnimalID} added.\nStatus: {animal.Status}\nHousing: {animal.HousingUnit}", @"Animal added");
            foreach (var box in new[] { txtAnimalId, txtName, txtSpecies, txtAge, txtScore }) box.Clear();
            txtAnimalId.Focus();
        }

        private void FocusField(string field) {
            TextBox box = field switch {
                "AnimalID" => txtAnimalId,
                "Name" => txtName,
                "Species" => txtSpecies,
                "Age" => txtAge,
                "RecoveryScore" => txtScore,
                _ => null
            };
            if (box == null) return;
            box.Focus();
            box.SelectAll();
        }
    }
}