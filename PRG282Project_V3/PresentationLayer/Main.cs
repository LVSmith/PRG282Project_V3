using System;
using System.Windows.Forms;
using PRG282Project_V3.BusinessLayer;
using PRG282Project_V3.DataLayer;
using PRG282Project_V3.PresentationLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PRG282Project_V3 
{
    public partial class Main : Form 
    {
        private AnimalManager manager = new AnimalManager();

        // Grid view for displaying animal records.
        private DataGridView dgvAnimals;

        /// <summary>
        /// Creates the main form and displays animal records.
        /// </summary>
        public Main()
        {
            InitializeComponent();

            // Create and configure the grid view.
            dgvAnimals = new DataGridView();
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.Dock = DockStyle.None;
            dgvAnimals.Left = 10;
            dgvAnimals.Top = btnAdd.Bottom + 15;
            dgvAnimals.Width = ClientSize.Width - 20;
            dgvAnimals.Height = ClientSize.Height - dgvAnimals.Top - 10;
            dgvAnimals.Anchor = AnchorStyles.Top |
                                AnchorStyles.Bottom |
                                AnchorStyles.Left |
                                AnchorStyles.Right;
            dgvAnimals.ReadOnly = true;
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimals.AutoGenerateColumns = true;
            dgvAnimals.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.MultiSelect = false;

            // Add the grid to the form.
            Controls.Add(dgvAnimals);

            // Load existing animal records.
            RefreshAnimals();
        }

        /// <summary>
        /// Validates the input boxes, saves the new animal, and clears the form.
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

            MessageBox.Show(
                $"{animal.AnimalID} added.\nStatus: {animal.Status}\nHousing: {animal.HousingUnit}",
                "Animal added");

            foreach (var box in new[]
            {
                txtAnimalId, txtName, txtSpecies, txtAge, txtScore
            })
            {
                box.Clear();
            }

            txtAnimalId.Focus();

            // Refresh the grid after adding an animal.
            RefreshAnimals();
        }

        /// <summary>
        /// Loads the latest animal records into the grid.
        /// </summary>
        private void RefreshAnimals()
        {
            dgvAnimals.DataSource = null;
            dgvAnimals.DataSource = manager.GetAllAnimals();
        }

        /// <summary>
        /// Puts the cursor in the box for the given field and selects its text.
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

        private void btnUpdatePage_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            // Get selected row values
            string id = dgvAnimals.SelectedRows[0].Cells["AnimalID"].Value.ToString();
            string name = dgvAnimals.SelectedRows[0].Cells["Name"].Value.ToString();
            string species = dgvAnimals.SelectedRows[0].Cells["Species"].Value.ToString();
            string age = dgvAnimals.SelectedRows[0].Cells["Age"].Value.ToString();
            string score = dgvAnimals.SelectedRows[0].Cells["RecoveryScore"].Value.ToString();
            string status = dgvAnimals.SelectedRows[0].Cells["Status"].Value.ToString();
            string housing = dgvAnimals.SelectedRows[0].Cells["HousingUnit"].Value.ToString();

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
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            string id = dgvAnimals.SelectedRows[0].Cells["AnimalID"].Value.ToString();
            string name = dgvAnimals.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show($"Delete {id} ({name})? This cannot be undone.",
                                          "Confirm Delete", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                var animals = manager.GetAllAnimals();
                var toRemove = animals.FirstOrDefault(a => a.AnimalID.Equals(id, StringComparison.OrdinalIgnoreCase));

                if (toRemove != null)
                {
                    animals.Remove(toRemove);
                    manager.SaveAnimals(animals);
                    MessageBox.Show("Record deleted successfully!");
                    RefreshAnimals(); 
                }
            }
        }

    }
}
