using PRG282Project_V3.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PRG282Project_V3.BusinessLayer {
    public class AnimalManager {
        private DataHandler dataHandler = new DataHandler();

        public string ClassifyStatus(int score) {
            if (score <= 19) return "Critical";
            if (score <= 39) return "Serious";
            if (score <= 59) return "Stable";
            if (score <= 79) return "Recovering";
            return "Release-Ready";
        }

        public string ClassifyHousing(int score) {
            if (score <= 19) return "Intensive Care Unit";
            if (score <= 39) return "High-Dependency Ward";
            if (score <= 59) return "Recovery Ward";
            if (score <= 79) return "Outdoor Enclosure";
            return "Pre-Release Camp";
        }

        public bool ValidateAnimal(Animal animal, out string error) {
            error = "";
            if (Regex.IsMatch(animal.AnimalID, @"^WR-\d{4}$") == false) {
                error = "Animal ID must be WR- followed by 4 digits.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(animal.Name) || animal.Name.Length > 30 || animal.Name.Contains("|")) {
                error = "Name must be 1-30 characters and not contain '|'.";
                return false;
            }

            if (animal.Age < 0 || animal.Age > 100) {
                error = "Age must be between 0 and 100.";
                return false;
            }

            if (animal.RecoveryScore < 0 || animal.RecoveryScore > 100) {
                error = "Recovery Score must be between 0 and 100.";
                return false;
            }

            return true;
        }

        public void UpdateAnimal(Animal updatedAnimal) {
            var animals = dataHandler.LoadAnimals();
            var existing = animals.Find(a => a.AnimalID.Equals(updatedAnimal.AnimalID, StringComparison.OrdinalIgnoreCase));

            if (existing == null) return;
            existing.Name = updatedAnimal.Name;
            existing.Species = updatedAnimal.Species;
            existing.Age = updatedAnimal.Age;
            existing.RecoveryScore = updatedAnimal.RecoveryScore;
            existing.Status = ClassifyStatus(updatedAnimal.RecoveryScore);
            existing.HousingUnit = ClassifyHousing(updatedAnimal.RecoveryScore);

            dataHandler.SaveAnimals(animals);
        }

        public List<Animal> GetAllAnimals() {
            return dataHandler.LoadAnimals();
        }
    }
}