using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET; // Import the namespace

namespace paimonDotMoeCompanion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoUpdater.Start("https://https://duy-thanh.github.io/paimonDotMoeCompanion/update.xml");
            Application.Run(new Form1());
        }
    }
}
