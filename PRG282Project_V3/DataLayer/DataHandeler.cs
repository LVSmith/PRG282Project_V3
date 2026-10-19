using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PRG282Project_V3.DataLayer {
    public class DataHandler {
        private readonly string filePath = "animals.txt";

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
    }
}