using System;
using System.Linq;
using System.Windows.Forms;
using PRG282Project_V3.BusinessLayer;
using PRG282Project_V3.DataLayer;

// ReSharper disable SuggestVarOrType_BuiltInTypes

namespace PRG282Project_V3.PresentationLayer {
    public partial class Update : Form {
        private AnimalManager manager = new AnimalManager();

        public Update() {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        /// <summary>
        /// Finds an animal by ID, name or species and fills the boxes with its details
        /// </summary>
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

        /// <summary>
        /// Clears all boxes and disables the NEW panel
        /// </summary>
        private void btnUClear_Click(object sender, EventArgs e) {
            foreach (Control c in this.Controls) {
                if (c is TextBox tbx) tbx.Clear();
            }

            pnlNew.Enabled = false; // disable NEW panel again
        }

        /// <summary>
        /// Goes back to the main form.
        /// </summary>
        private void btnReturn_Click(object sender, EventArgs e) {
            Main mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Validates the edited details and saves them over the existing record
        /// </summary>
        private void btnSaveChanges_Click(object sender, EventArgs e) {
            if (manager.ValidateAnimal(txbOUID.Text, txbOUName.Text, txbOUSpecies.Text, txbOUAge.Text, txbOURecoveryScore.Text,
                    false, out Animal updatedAnimal, out string error, out string field)) {
                manager.UpdateAnimal(updatedAnimal);
                MessageBox.Show(@"Animal updated successfully!");
                btnUClear.PerformClick(); // clear after save
            }
            else {
                MessageBox.Show(error);
                FocusField(field);
            }
        }

        /// <summary>
        /// Puts the cursor in the box for the given field and selects its text
        /// </summary>
        /// <param name="field">The field name returned by ValidateAnimal</param>
        private void FocusField(string field) {
            TextBox box = field switch {
                "AnimalID" => txbOUID,
                "Name" => txbOUName,
                "Species" => txbOUSpecies,
                "Age" => txbOUAge,
                "RecoveryScore" => txbOURecoveryScore,
                _ => null
            };
            if (box == null) return;
            box.Focus();
            box.SelectAll();
        }

        /// <summary>
        /// Disables the NEW panel until an animal has been found
        /// </summary>
        private void Update_Load(object sender, EventArgs e) {
            pnlNew.Enabled = false; // disable NEW panel on load
        }
    }
}