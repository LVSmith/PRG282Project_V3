using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PRG282Project_V3.DataLayer {
    public class DataHandler {
        private readonly string filePath = "animals.txt";
        internal readonly int SkippedLineCount;

        /// <summary>
        /// Reads all animals from the .txt file, it creates the file if it does not already exist and skips any errored linse
        /// </summary>
        /// <returns>A list of all animals in the file</returns>
        public List<Animal> LoadAnimals() {
            var animals = new List<Animal>();
            if (!File.Exists(filePath)) File.Create(filePath).Close();

            foreach (var line in File.ReadAllLines(filePath)) {
                var parts = line.Split('|');
                if (parts.Length == 7 && int.TryParse(parts[3], out int age) && int.TryParse(parts[4], out int score)) {
                    animals.Add(new Animal {
                        AnimalID = parts[0].Trim(),
                        Name = parts[1].Trim(),
                        Species = parts[2].Trim(),
                        Age = age,
                        RecoveryScore = score,
                        Status = parts[5].Trim(),
                        HousingUnit = parts[6].Trim()
                    });
                }
            }

            return animals;
        }

        /// <summary>
        /// Overwrites the file with the list of animals
        /// </summary>
        /// <param name="animals">Every animal to keep in the file</param>
        public void SaveAnimals(List<Animal> animals) {
            var lines = animals.Select(a => $"{a.AnimalID}|{a.Name}|{a.Species}|{a.Age}|{a.RecoveryScore}|{a.Status}|{a.HousingUnit}");
            File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        /// Appends one animal as a new line at the end of the file
        /// </summary>
        /// <param name="a">The animal to append</param>
        /// <param name="error">A message describing why writing failed</param>
        /// <returns>True if the line was written</returns>
        public bool AddAnimal(Animal a, out string error) {
            error = "";
            try {
                File.AppendAllText(filePath, $"{a.AnimalID}|{a.Name}|{a.Species}|{a.Age}|{a.RecoveryScore}|{a.Status}|{a.HousingUnit}{Environment.NewLine}");
                return true;
            }
            catch (IOException ex) {
                error = $"Could not write to {filePath}: {ex.Message}";
                return false;
            }
            catch (UnauthorizedAccessException) {
                error = $"Access to {filePath} was denied.";
                return false;
            }
        }

        public void DeleteAnimal(Animal selected)
        {
            byte[] original = File.ReadAllBytes(filePath);
            bool bom = original.Length >= 3 && original[0] == 239 && original[1] == 187 && original[2] == 191;
            var utf8 = new UTF8Encoding(false, true);
            string text = utf8.GetString(original, bom ? 3 : 0, original.Length - (bom ? 3 : 0));
            var lines = Regex.Matches(text, @"[^\r\n]*(?:\r\n|\n|\r|$)").Cast<Match>()
                .Where(m => m.Length > 0).ToList();
            var matches = lines.Where(m => m.Value.TrimEnd('\r', '\n').Split('|')[0].Trim()
                .Equals(selected.AnimalID, StringComparison.OrdinalIgnoreCase)).ToList();

            if (matches.Count != 1)
            { 
                throw new IOException("The selected ID is missing or duplicated. Refresh and select a unique record.");
            }

            Match line = matches[0];

            string[] fields = line.Value.TrimEnd('\r', '\n').Split('|').Select(x => x.Trim()).ToArray();
            if (fields.Length != 7 || fields[1] != selected.Name || fields[2] != selected.Species ||
                !int.TryParse(fields[3], out int age) || age != selected.Age ||
                !int.TryParse(fields[4], out int score) || score != selected.RecoveryScore ||
                fields[5] != selected.Status || fields[6] != selected.HousingUnit)
            {
                throw new IOException("This animal changed since it was loaded. Refresh before deleting.");
            }

            int start = (bom ? 3 : 0) + utf8.GetByteCount(text.Substring(0, line.Index));
            int length = utf8.GetByteCount(line.Value);
            byte[] remaining = new byte[original.Length - length];

            Buffer.BlockCopy(original, 0, remaining, 0, start);
            Buffer.BlockCopy(original, start + length, remaining, start, original.Length - start - length);

            string temporary = filePath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                File.WriteAllBytes(temporary, remaining);
                // Do not commit a stale snapshot if another program changed the data.
                if (!File.ReadAllBytes(filePath).SequenceEqual(original))
                    throw new IOException("The data file changed. Refresh before deleting.");
                File.Replace(temporary, filePath, null);
            }
            finally
            {
                if (File.Exists(temporary)) File.Delete(temporary);
            }
        }

        // Overwrite the report beside the executable; never append previous reports.
        public void SaveSummary(string report)
        {
            File.WriteAllText(Path.Combine(AppContext.BaseDirectory, "summary.txt"), report, new UTF8Encoding(false));
        }
    }
}