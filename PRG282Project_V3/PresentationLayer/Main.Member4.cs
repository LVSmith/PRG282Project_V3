using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PRG282Project_V3.DataLayer;

namespace PRG282Project_V3 {
    public partial class Main {
        private DataGridView dgvAnimals;
        private TextBox txtSummary;
        private Button btnSaveChanges;
        private string loadedAnimalId;

        // Add Member 4 controls without rewriting the teammates' designer layout.
        private void InitializeMember4() {
            ClientSize = new Size(1100, 750);
            MinimumSize = new Size(1120, 790);
            dgvAnimals = new DataGridView {
                Name = "dgvAnimals", Location = new Point(350, 40), Size = new Size(720, 270),
                ReadOnly = true, AllowUserToAddRows = false, AllowUserToDeleteRows = false,
                MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };
            string[] properties = { "AnimalID", "Name", "Species", "Age", "RecoveryScore", "Status", "HousingUnit" };
            string[] headers = { "Animal ID", "Name", "Species", "Age", "Recovery Score", "Status", "Housing Unit" };
            for (int i = 0; i < properties.Length; i++)
                dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn {
                    DataPropertyName = properties[i], HeaderText = headers[i], SortMode = DataGridViewColumnSortMode.NotSortable
                });
            dgvAnimals.CellClick += LoadSelectedAnimal;
            Controls.Add(dgvAnimals);
            AddMember4Button("btnDelete", "Delete", 350, 325, DeleteSelectedAnimal);
            AddMember4Button("btnRefresh", "Refresh", 500, 325, (s, e) => RefreshAnimals());
            AddMember4Button("btnGenerateSummary", "Generate Summary", 650, 325, GenerateSummary);
            btnSaveChanges = AddMember4Button("btnSaveChanges", "Save Changes", 40, 290, SaveLoadedAnimal);
            btnSaveChanges.Enabled = false;
            AddMember4Button("btnClear", "Clear", 190, 290, (s, e) => ClearLoadedAnimal());
            Controls.Add(new Label { Text = "Summary report", AutoSize = true, Location = new Point(40, 375) });
            txtSummary = new TextBox {
                Name = "txtSummary", Location = new Point(40, 400), Size = new Size(1030, 320),
                Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Both, WordWrap = false,
                Font = new Font(FontFamily.GenericMonospace, 10)
            };
            Controls.Add(txtSummary);
            Shown += (s, e) => RefreshAnimals();
        }

        // Wire each clearly labelled button to its action.
        private Button AddMember4Button(string name, string text, int x, int y, EventHandler handler) {
            var button = new Button { Name = name, Text = text, Location = new Point(x, y), Size = new Size(140, 32) };
            button.Click += handler;
            Controls.Add(button);
            return button;
        }

        // Rebind instead of appending rows; deliberately leave no row selected.
        private void RefreshAnimals() {
            try {
                dgvAnimals.DataSource = manager.GetAllAnimals();
                dgvAnimals.ClearSelection();
                dgvAnimals.CurrentCell = null;
                ShowSkippedLines();
            } catch (IOException ex) { ShowFileError(ex); }
            catch (UnauthorizedAccessException ex) { ShowFileError(ex); }
        }

        // Give one warning per load, rather than one message for every malformed line.
        private void ShowSkippedLines() {
            if (manager.SkippedLineCount > 0)
                MessageBox.Show(this, manager.SkippedLineCount + " malformed line(s) were skipped.", "Data warning");
        }

        // Row loading makes the selected record visible and protects its immutable ID.
        private void LoadSelectedAnimal(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            var animal = dgvAnimals.Rows[e.RowIndex].DataBoundItem as Animal;
            if (animal == null) return;
            loadedAnimalId = animal.AnimalID;
            txtAnimalId.Text = animal.AnimalID;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtAge.Text = animal.Age.ToString();
            txtScore.Text = animal.RecoveryScore.ToString();
            txtAnimalId.ReadOnly = true;
            btnAdd.Enabled = false;
            btnSaveChanges.Enabled = true;
        }

        // Restore Add mode after deleting the loaded animal or pressing Clear.
        private void ClearLoadedAnimal() {
            loadedAnimalId = null;
            foreach (var box in new[] { txtAnimalId, txtName, txtSpecies, txtAge, txtScore }) box.Clear();
            txtAnimalId.ReadOnly = false;
            btnAdd.Enabled = true;
            btnSaveChanges.Enabled = false;
            dgvAnimals.ClearSelection();
            txtAnimalId.Focus();
        }

        // Reuse the team's validation and update methods for the grid-loaded record.
        private void SaveLoadedAnimal(object sender, EventArgs e) {
            if (loadedAnimalId == null) return;
            try {
                if (!manager.ValidateAnimal(loadedAnimalId, txtName.Text, txtSpecies.Text, txtAge.Text, txtScore.Text,
                    false, out Animal animal, out string error, out string field)) {
                    MessageBox.Show(this, error, "Invalid input");
                    FocusField(field);
                    return;
                }
                manager.UpdateAnimal(animal);
                ClearLoadedAnimal();
                RefreshAnimals();
            } catch (IOException ex) { ShowFileError(ex); }
            catch (UnauthorizedAccessException ex) { ShowFileError(ex); }
        }

        // Only a selected bound row can be deleted; No returns before any file operation.
        private void DeleteSelectedAnimal(object sender, EventArgs e) {
            if (dgvAnimals.SelectedRows.Count != 1 || !(dgvAnimals.SelectedRows[0].DataBoundItem is Animal animal)) {
                MessageBox.Show(this, "Please select one animal row to delete.", "Select an animal");
                return;
            }
            if (MessageBox.Show(this, $"Delete {animal.AnimalID} ({animal.Name})? This cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            try {
                manager.DeleteAnimal(animal);
                if (string.Equals(loadedAnimalId, animal.AnimalID, StringComparison.OrdinalIgnoreCase)) ClearLoadedAnimal();
                txtSummary.Clear(); // The old report is no longer current.
                RefreshAnimals();
            } catch (IOException ex) { ShowFileError(ex); }
            catch (UnauthorizedAccessException ex) { ShowFileError(ex); }
        }

        // Reload current disk data and show results even if summary.txt cannot be saved.
        private void GenerateSummary(object sender, EventArgs e) {
            txtSummary.Clear();
            try {
                txtSummary.Text = manager.GenerateSummary();
                ShowSkippedLines();
            } catch (IOException ex) { ShowFileError(ex); return; }
            catch (UnauthorizedAccessException ex) { ShowFileError(ex); return; }
            try {
                manager.SaveSummary(txtSummary.Text);
            } catch (IOException ex) { ShowFileError(ex); }
            catch (UnauthorizedAccessException ex) { ShowFileError(ex); }
        }

        // Keep the form open and explain common file failures without a stack trace.
        private void ShowFileError(Exception error) {
            MessageBox.Show(this, "The file operation could not be completed. Check that the application folder exists, " +
                "the files are writable, and another program is not locking them.\n\n" + error.Message,
                "File operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
