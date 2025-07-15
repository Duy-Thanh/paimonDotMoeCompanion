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
            AutoUpdater.Start("https://duy-thanh.github.io/paimonDotMoeCompanion/update.xml");
            AutoUpdater.Mandatory = false; // set to true if force update
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ReportErrors = true;

            // Optional: Handle update events
            //AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
            Application.Run(new Form1());
        }

        //private static void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        //{
        //    if (args.IsUpdateAvailable)
        //    {
        //        DialogResult dialogResult = MessageBox.Show(
        //            $"New version {args.CurrentVersion} is available (you have {args.InstalledVersion}).\n\nDo you want to update the application now?",
        //            "Update Available",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Information
        //        );

        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            try
        //            {
        //                AutoUpdater.DownloadUpdate(args);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Update failed: " + ex.Message);
        //            }
        //        }
        //    }
        //}
    }
}
