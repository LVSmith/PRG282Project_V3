using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PRG282Project_V3.DataLayer {
    public partial class DataHandler {
        public int SkippedLineCount { get; private set; }

        // Remove exactly one unchanged record; retain all other UTF-8 bytes and line endings.
        public void DeleteAnimal(Animal selected) {
            byte[] original = File.ReadAllBytes(filePath);
            bool bom = original.Length >= 3 && original[0] == 239 && original[1] == 187 && original[2] == 191;
            var utf8 = new UTF8Encoding(false, true);
            string text = utf8.GetString(original, bom ? 3 : 0, original.Length - (bom ? 3 : 0));
            var lines = Regex.Matches(text, @"[^\r\n]*(?:\r\n|\n|\r|$)").Cast<Match>()
                .Where(m => m.Length > 0).ToList();
            var matches = lines.Where(m => m.Value.TrimEnd('\r', '\n').Split('|')[0].Trim()
                .Equals(selected.AnimalID, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matches.Count != 1)
                throw new IOException("The selected ID is missing or duplicated. Refresh and select a unique record.");
            Match line = matches[0];
            string[] fields = line.Value.TrimEnd('\r', '\n').Split('|').Select(x => x.Trim()).ToArray();
            if (fields.Length != 7 || fields[1] != selected.Name || fields[2] != selected.Species ||
                !int.TryParse(fields[3], out int age) || age != selected.Age ||
                !int.TryParse(fields[4], out int score) || score != selected.RecoveryScore ||
                fields[5] != selected.Status || fields[6] != selected.HousingUnit)
                throw new IOException("This animal changed since it was loaded. Refresh before deleting.");
            int start = (bom ? 3 : 0) + utf8.GetByteCount(text.Substring(0, line.Index));
            int length = utf8.GetByteCount(line.Value);
            byte[] remaining = new byte[original.Length - length];
            Buffer.BlockCopy(original, 0, remaining, 0, start);
            Buffer.BlockCopy(original, start + length, remaining, start, original.Length - start - length);
            string temporary = filePath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try {
                File.WriteAllBytes(temporary, remaining);
                // Do not commit a stale snapshot if another program changed the data.
                if (!File.ReadAllBytes(filePath).SequenceEqual(original))
                    throw new IOException("The data file changed. Refresh before deleting.");
                File.Replace(temporary, filePath, null);
            } finally {
                if (File.Exists(temporary)) File.Delete(temporary);
            }
        }

        // Overwrite the report beside the executable; never append previous reports.
        public void SaveSummary(string report) {
            File.WriteAllText(Path.Combine(AppContext.BaseDirectory, "summary.txt"), report, new UTF8Encoding(false));
        }
    }
}
