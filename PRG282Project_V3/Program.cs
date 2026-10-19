using System;
using System.Windows.Forms;

namespace PRG282Project_V3 {
    internal static class Program {
        /// <summary>
        /// Starts the application and opens the main form
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}