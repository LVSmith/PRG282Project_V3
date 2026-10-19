using PRG282Project_V3.DataLayer;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PRG282Project_V3.BusinessLayer {
    public class AnimalManager {
        private DataHandler dataHandler = new DataHandler();

        /// <summary>
        /// Works out an animal's status and housing unit from its recovery score.
        /// </summary>
        /// <param name="score">Recovery score from 0 to 100.</param>
        /// <returns>The status and housing unit for that score.</returns>
        public (string Status, string HousingUnit) Classify(int score) {
            if (score <= 19) return ("Critical", "Intensive Care Unit");
            if (score <= 39) return ("Serious", "High-Dependency Ward");
            if (score <= 59) return ("Stable", "Recovery Ward");
            if (score <= 79) return ("Recovering", "Outdoor Enclosure");
            return ("Release-Ready", "Pre-Release Camp");
        }

        /// <summary>
        /// Trims and checks the form input, and builds a classified animal if everything is valid.
        /// </summary>
        /// <param name="isNew">True when adding, so the ID must not already exist.</param>
        /// <param name="animal">The finished animal, or null if validation failed.</param>
        /// <param name="error">A message describing what is wrong.</param>
        /// <param name="field">The name of the field that failed, so the form can focus it.</param>
        /// <returns>True if all input is valid.</returns>
        public bool ValidateAnimal(string id, string name, string species, string ageText, string scoreText, bool isNew,
            out Animal animal, out string error, out string field) {
            animal = null;
            error = "";
            field = "";

            id = (id ?? "").Trim().ToUpperInvariant();
            name = (name ?? "").Trim();
            species = (species ?? "").Trim();
            ageText = (ageText ?? "").Trim();
            scoreText = (scoreText ?? "").Trim();

            if (!Regex.IsMatch(id, @"^WR-\d{4}$")) {
                error = "Animal ID must be WR- followed by 4 digits.";
                field = "AnimalID";
                return false;
            }

            if (isNew && GetAllAnimals().Exists(a => a.AnimalID.Equals(id, StringComparison.OrdinalIgnoreCase))) {
                error = $"Animal ID {id} already exists.";
                field = "AnimalID";
                return false;
            }

            if (name.Length == 0 || name.Length > 30 || name.Contains("|")) {
                error = "Name must be 1-30 characters and not contain '|'.";
                field = "Name";
                return false;
            }

            if (species.Length == 0 || species.Length > 30 || species.Contains("|")) {
                error = "Species must be 1-30 characters and not contain '|'.";
                field = "Species";
                return false;
            }

            if (!int.TryParse(ageText, out int age) || age < 0 || age > 100) {
                error = "Age must be a whole number between 0 and 100.";
                field = "Age";
                return false;
            }

            if (!int.TryParse(scoreText, out int score) || score < 0 || score > 100) {
                error = "Recovery Score must be a whole number between 0 and 100.";
                field = "RecoveryScore";
                return false;
            }

            var (status, housingUnit) = Classify(score);
            animal = new Animal(id, name, species, age, score, status, housingUnit);
            return true;
        }

        /// <summary>
        /// Saves a new animal to the end of the file.
        /// </summary>
        /// <param name="animal">A validated animal.</param>
        /// <param name="error">A message describing why saving failed.</param>
        /// <returns>True if the animal was saved.</returns>
        public bool AddAnimal(Animal animal, out string error) {
            return dataHandler.AddAnimal(animal, out error);
        }

        /// <summary>
        /// Replaces an existing animal's details, re-classifies it, and saves the file.
        /// </summary>
        /// <param name="updatedAnimal">The animal with its new details. The ID is used to find the record.</param>
        public void UpdateAnimal(Animal updatedAnimal) {
            var animals = dataHandler.LoadAnimals();
            var existing = animals.Find(a => a.AnimalID.Equals(updatedAnimal.AnimalID, StringComparison.OrdinalIgnoreCase));

            if (existing == null) return;
            var (status, housingUnit) = Classify(updatedAnimal.RecoveryScore);
            existing.Name = updatedAnimal.Name;
            existing.Species = updatedAnimal.Species;
            existing.Age = updatedAnimal.Age;
            existing.RecoveryScore = updatedAnimal.RecoveryScore;
            existing.Status = status;
            existing.HousingUnit = housingUnit;

            dataHandler.SaveAnimals(animals);
        }

        /// <summary>
        /// Gets every animal from the file.
        /// </summary>
        /// <returns>A list of all animals.</returns>
        public List<Animal> GetAllAnimals() {
            return dataHandler.LoadAnimals();
        }
    }
}