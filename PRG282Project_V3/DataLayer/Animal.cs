namespace PRG282Project_V3.DataLayer {
    public class Animal {
        public Animal() { }

        public Animal(string animalID, string name, string species, int age, int recoveryScore, string status, string housingUnit) {
            AnimalID = animalID;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = recoveryScore;
            Status = status;
            HousingUnit = housingUnit;
        }

        public string AnimalID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; set; }
        public string HousingUnit { get; set; }
    }
}