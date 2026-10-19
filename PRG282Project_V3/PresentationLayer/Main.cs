using System;
using System.Windows.Forms;
using PRG282Project_V3.BusinessLayer;
using PRG282Project_V3.DataLayer;

namespace PRG282Project_V3 {
    public partial class Main : Form {
        private AnimalManager manager = new AnimalManager();

        /// <summary>
        /// Creates the main form
        /// </summary>
        public Main() {
            InitializeComponent();
        }

        /// <summary>
        /// Validates the input boxes, saves the new animal, and clears the form
        /// </summary>
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

        /// <summary>
        /// Puts the cursor in the box for the given field and selects its text
        /// </summary>
        /// <param name="field">The field name returned by ValidateAnimal</param>
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