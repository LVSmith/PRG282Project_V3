using PRG282Project_V3.BusinessLayer;
using PRG282Project_V3.DataLayer;
using PRG282Project_V3.PresentationLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PRG282Project_V3 {
    public partial class Main : Form
    {
        private AnimalManager manager = new AnimalManager();

        /// <summary>
        /// Creates the main form
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validates the input boxes, saves the new animal, and clears the form
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!manager.ValidateAnimal(txtAnimalId.Text, txtName.Text, txtSpecies.Text, txtAge.Text, txtScore.Text,
                    true, out Animal animal, out string error, out string field))
            {
                MessageBox.Show(error, @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FocusField(field);
                return;
            }

            if (!manager.AddAnimal(animal, out error))
            {
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
        private void FocusField(string field)
        {
            TextBox box = field switch
            {
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

        private void btnUpdatePage_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            // Get selected row values
            string id = dataGridView1.SelectedRows[0].Cells["AnimalID"].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            string species = dataGridView1.SelectedRows[0].Cells["Species"].Value.ToString();
            string age = dataGridView1.SelectedRows[0].Cells["Age"].Value.ToString();
            string score = dataGridView1.SelectedRows[0].Cells["RecoveryScore"].Value.ToString();
            string status = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();
            string housing = dataGridView1.SelectedRows[0].Cells["HousingUnit"].Value.ToString();

            // Pass values into Update form
            Update updateForm = new Update(id, name, species, age, score, status, housing);
            updateForm.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            // Get selected animal
            string id = dataGridView1.SelectedRows[0].Cells["AnimalID"].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

            // Confirm deletion
            var confirm = MessageBox.Show($"Delete {id} ({name})? This cannot be undone.",
                                          "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var animals = manager.GetAllAnimals();
                var toRemove = animals.FirstOrDefault(a => a.AnimalID.Equals(id, StringComparison.OrdinalIgnoreCase));

                if (toRemove != null)
                {
                    animals.Remove(toRemove);
                    manager.SaveAnimals(animals); // rewrite file
                    MessageBox.Show("Record deleted successfully!");
                    RefreshGrid(); // reload DataGridView
                    btnUClear.PerformClick(); // clear form if deleted record was loaded
                }
            }
        }
    }
}