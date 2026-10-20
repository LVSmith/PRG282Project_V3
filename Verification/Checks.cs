using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using PRG282Project_V3;
using PRG282Project_V3.BusinessLayer;
using PRG282Project_V3.DataLayer;

class Checks {
    static int count;
    static string path = Path.Combine(AppContext.BaseDirectory, "animals.txt");

    static void Check(bool ok, string name) 
    { 
        if (!ok) 
            throw new Exception(name); 
        Console.WriteLine("PASS " + name); 
        count++; 
    }
    static void Fails(Action action, string name) 
    { 
        bool failed=false; 
        try 
        { 
            action(); 
        } 
        catch(IOException) 
        {
            failed=true;
        } 
        catch(UnauthorizedAccessException) 
        {
            failed=true;
        } 
        Check(failed,name); 
    }
 static object Field(object form, string name) => typeof(Main).GetField(name, BindingFlags.NonPublic|BindingFlags.Instance).GetValue(form);

 static void Call(object form, string name, params object[] args) => typeof(Main).GetMethod(name, BindingFlags.NonPublic|BindingFlags.Instance).Invoke(form,args);

 [STAThread] 

    static void Main() 
    {
        var manager = new AnimalManager();
        string first="WR-0001|Thabo|Penguin|4|85|Release-Ready|Pre-Release Camp";
        string middle="WR-0002|Naledi|Serval|3|62|Recovering|Outdoor Enclosure";
        string last="WR-0003|Zoë|Owl|2|19|Critical|Intensive Care Unit";

        File.WriteAllText(path,first+"\r\n"+middle+"\n"+last,new UTF8Encoding(true));

        var selected=manager.GetAllAnimals()[1];
        manager.DeleteAnimal(selected);

        var expected=new UTF8Encoding(true).GetPreamble().Concat(Encoding.UTF8.GetBytes(first+"\r\n"+last)).ToArray();
        Check(File.ReadAllBytes(path).SequenceEqual(expected),"Middle deletion preserves UTF-8 BOM, mixed endings, unicode and no final newline");
        
        var unchanged=File.ReadAllBytes(path);
        Fails(()=>manager.DeleteAnimal(selected),"Missing selected record rejected");
        Check(File.ReadAllBytes(path).SequenceEqual(unchanged),"Failed deletion leaves file unchanged");
        selected=manager.GetAllAnimals()[0];
        File.WriteAllText(path,first.Replace("Thabo","Changed")+"\n"+last);
        Fails(()=>manager.DeleteAnimal(selected),"Stale selected record rejected");
        File.WriteAllText(path,first+"\n"+first);
        Fails(()=>manager.DeleteAnimal(selected),"Duplicate IDs cannot delete multiple records");
        File.WriteAllText(path,first+"\n"+last);
        File.SetAttributes(path,FileAttributes.ReadOnly);

        try 
        { 
            Fails(()=>manager.DeleteAnimal(selected),"Read-only animals file handled"); 
            Check(File.ReadAllText(path)==first+"\n"+last,"Read-only failure preserves data"); 
        }
        finally 
        { 
            File.SetAttributes(path,FileAttributes.Normal); 
        }

        using(var locked=new FileStream(path,FileMode.Open,FileAccess.ReadWrite,FileShare.None)) 
        {
            Fails(()=>manager.DeleteAnimal(selected),"Locked animals file handled");
            Fails(()=>manager.GenerateSummary(),"Locked summary source handled");
        }

        manager.DeleteAnimal(manager.GetAllAnimals()[0]);
        Check(File.ReadAllText(path)==last,"First deletion preserves last record");
        manager.DeleteAnimal(manager.GetAllAnimals()[0]);
        Check(new FileInfo(path).Length==0,"Last deletion produces empty file");

        var empty=manager.GenerateSummary();
        Check(empty.Contains("Total animals:            0") && empty.Split(new[]{"N/A"},StringSplitOptions.None).Length==3,"Empty averages are N/A and total zero");
        Check(empty.Split('\n').Count(l=>l.StartsWith("  ") && l.TrimEnd().EndsWith("0"))==5,"Empty report includes five zero statuses");
        File.Delete(path); Check(manager.GetAllAnimals().Count==0 && File.Exists(path),"Missing animals file recreated");
        File.WriteAllText(path,first+"\n"+middle+"\n"+last+"\ninvalid|line\nXX-0000|x|x|1|1|Critical|ICU\n");
        Check(manager.GetAllAnimals().Count==3 && manager.SkippedLineCount==2,"Malformed lines and invalid IDs skipped and counted");
        CultureInfo.CurrentCulture=CultureInfo.GetCultureInfo("fr-FR");

        var animals=manager.GetAllAnimals();
        var report=AnimalManager.FormatSummary(animals,new DateTime(2026,10,14,9,32,0));
        string exact="BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE\nANIMAL SUMMARY REPORT\nGenerated: 2026-10-14 09:32\n----------------------------------------\nTotal animals:            3\nAverage age (years):      3.00\nAverage recovery score:   55.33\n----------------------------------------\nAnimals per status:\n  Critical:               1\n  Serious:                0\n  Stable:                 0\n  Recovering:             1\n  Release-Ready:          1\n";
        Check(report.Replace("\r\n","\n")==exact,"Exact report layout and invariant decimals under fr-FR");

        var five = new System.Collections.Generic.List<Animal>();
        foreach(int score in new[]{0,20,40,60,80})
        {
            var c=manager.Classify(score);
            five.Add(new Animal("WR-0000","a","b",10,score,c.Status,c.HousingUnit));
        }
        Check(AnimalManager.FormatSummary(five,DateTime.Now).Split('\n').Count(l=>l.StartsWith("  ")&&l.TrimEnd().EndsWith("1"))==5,"All five nonzero status counts");
  
        string summary=Path.Combine(AppContext.BaseDirectory,"summary.txt");
        manager.SaveSummary(report); manager.SaveSummary(empty);
        Check(File.ReadAllText(summary)==empty,"Report overwrites rather than appends");
        File.SetAttributes(summary,FileAttributes.ReadOnly);
        try 
        { 
            Fails(()=>manager.SaveSummary(report),"Read-only summary handled"); 
        } 
        finally 
        {
            File.SetAttributes(summary,FileAttributes.Normal);
        }
  
        using(var locked=new FileStream(summary,FileMode.Open,FileAccess.ReadWrite,FileShare.None)) 
            Fails(()=>manager.SaveSummary(report),"Locked summary handled");
  
        File.Delete(summary); Directory.CreateDirectory(summary);
        try 
        {
            Fails(()=>manager.SaveSummary(report),"Summary path blocked by directory handled");
        } 
        finally 
        {
            Directory.Delete(summary);
        }
  
        using(var form = new Main()) 
        {
            var grid=(DataGridView)Field(form,"dgvAnimals");
            Check(grid.ReadOnly && !grid.MultiSelect && !grid.AllowUserToAddRows && !grid.AllowUserToDeleteRows,"Grid prevents direct edits and multiple selection");
            Check(grid.Columns.Count==7 && grid.Columns[0].HeaderText=="Animal ID" && grid.Columns[6].HeaderText=="Housing Unit","Grid column order");
            grid.DataSource=animals; form.CreateControl(); grid.BindingContext=new BindingContext();
            Call(form,"LoadSelectedAnimal",grid,new DataGridViewCellEventArgs(0,0));
            Check(((TextBox)Field(form,"txtAnimalId")).ReadOnly && !((Button)Field(form,"btnAdd")).Enabled,"Row load protects ID and disables Add");
            Call(form,"ClearLoadedAnimal");
            Check(((TextBox)Field(form,"txtAnimalId")).Text=="" && ((Button)Field(form,"btnAdd")).Enabled && !((Button)Field(form,"btnSaveChanges")).Enabled,"Clear returns loaded form to Add mode");
            Check(((TextBox)Field(form,"txtSummary")).ReadOnly && ((TextBox)Field(form,"txtSummary")).Multiline,"Summary displayed in read-only on-form textbox");
        }
  
        Console.WriteLine(count+" checks passed.");
    }
}
