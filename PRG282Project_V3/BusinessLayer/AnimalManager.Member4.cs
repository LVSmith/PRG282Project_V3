using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PRG282Project_V3.DataLayer;

namespace PRG282Project_V3.BusinessLayer {
    public partial class AnimalManager {
        public int SkippedLineCount => dataHandler.SkippedLineCount;

        // The selected bound object is passed through unchanged for stale-record checking.
        public void DeleteAnimal(Animal selected) {
            if (selected == null) throw new ArgumentNullException(nameof(selected));
            dataHandler.DeleteAnimal(selected);
        }

        // Format is shared by the read-only on-form display and summary.txt.
        public string GenerateSummary() {
            var animals = GetAllAnimals();
            string report = FormatSummary(animals, DateTime.Now);
            return report;
        }

        // Keep display independent of file saving so calculated results survive a write error.
        public void SaveSummary(string report) { dataHandler.SaveSummary(report); }

        // InvariantCulture guarantees decimal points even on comma-decimal computers.
        public static string FormatSummary(List<Animal> animals, DateTime generated) {
            var culture = CultureInfo.InvariantCulture;
            var lines = new List<string> {
                "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE",
                "ANIMAL SUMMARY REPORT",
                "Generated: " + generated.ToString("yyyy-MM-dd HH:mm", culture),
                "----------------------------------------",
                "Total animals:            " + animals.Count.ToString(culture),
                "Average age (years):      " + (animals.Count == 0 ? "N/A" : animals.Average(a => a.Age).ToString("F2", culture)),
                "Average recovery score:   " + (animals.Count == 0 ? "N/A" : animals.Average(a => a.RecoveryScore).ToString("F2", culture)),
                "----------------------------------------",
                "Animals per status:"
            };
            foreach (string status in new[] { "Critical", "Serious", "Stable", "Recovering", "Release-Ready" })
                lines.Add(("  " + status + ":").PadRight(26) + animals.Count(a => a.Status == status).ToString(culture));
            return string.Join(Environment.NewLine, lines) + Environment.NewLine;
        }
    }
}
