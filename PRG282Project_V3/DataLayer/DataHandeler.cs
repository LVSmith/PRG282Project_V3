using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PRG282Project_V3.DataLayer {
    public class DataHandler {
        private readonly string filePath = "animals.txt";

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

        public void SaveAnimals(List<Animal> animals) {
            var lines = animals.Select(a => $"{a.AnimalID}|{a.Name}|{a.Species}|{a.Age}|{a.RecoveryScore}|{a.Status}|{a.HousingUnit}");
            File.WriteAllLines(filePath, lines);
        }
    }
}