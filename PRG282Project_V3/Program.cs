using System;
using System.Windows.Forms;

namespace PRG282Project_V3 {
    internal static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}