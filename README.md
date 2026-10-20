# PRG282Project_V3
Baobab Ridge Wildlife Rehabilitation Records System

## Project Overview
This is a C# Windows Forms application developed for **Programming 2782 (PRG282)**.  
The system manages wildlife rehabilitation records for Baobab Ridge, allowing vets and staff to add, view, update, delete, and summarize animal records.  
Data is stored in plain text files (`animals.txt`, `summary.txt`) and version-controlled with GitHub.

---

## Team Members
- Sebastian Tomlinson-Nel 604465  – Add Feature  
- Boipelo Mahlatsi 605051 – View Feature  
- Luan Vernon Smith 603262 – Update Feature  
- Jonathan Scheffer 603789 – Delete & Summary Feature  

*(Replace with actual names and student numbers before submission.)*

---

## Technologies Used
- **C# Windows Forms** (.NET 8.0 or newer)  
- **Git & GitHub** for version control  
- **Plain text files** for data storage (no databases allowed)

---

## Features
1. **Add Animal** – Input validation, classification, and saving to `animals.txt`.  
2. **View Animals** – Load and display records in a DataGridView.  
3. **Update Animal** – Search by ID or row-click, edit details, revalidate, and rewrite only the edited record.  
4. **Delete Animal** – Remove a record with confirmation.  
5. **Summary Report** – Generate totals, averages, and per-status counts, saved to `summary.txt`.

---

## File Formats
### animals.txt
- One animal per line, fields separated by `|`:
    ID | Name | Species | Age | Score | Status | Housing Unit
- Example:
  WR-0001|Thabo|African Penguin|4|85|Release-Ready|Pre-Release Camp

### summary.txt
Generated report with totals and averages:
BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE
ANIMAL SUMMARY REPORT
Generated: yyyy-MM-dd HH:mm

Total animals: 12
Average age (years): 7.75
Average recovery score: 54.00
Animals per status:
Critical: 2
Serious: 2
Stable: 2
Recovering: 3
Release-Ready: 3

---

## How to Build and Run
1. Clone the repository:
   ```bash
   git clone https://github.com/<YourUsername>/PRG282Project_V3.git
2. Open the solution in Visual Studio 2022 or newer.

3. Build the project (Ctrl+Shift+B).

4. Run the application (F5).

5. Ensure animals.txt is included in the output directory with starter data.

---

## Known Limitations
- Data storage is limited to plain text files.
- No database or external NuGet packages are used.
- File errors (locked, missing, malformed lines) are handled gracefully but skipped records are not preserved.

## Academic Integrity
All code and documentation are original work by the group.
External snippets (if any) are credited in comments.
Submitting AI-generated code or copying from other groups is prohibited under Belgium Campus’ integrity policy.
