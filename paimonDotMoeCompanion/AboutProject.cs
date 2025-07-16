using AutoUpdaterDotNET;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paimonDotMoeCompanion
{
    public partial class AboutProject : LostForm
    {
        public AboutProject()
        {
            InitializeComponent();

            lblTitle.Text =
                "This is an unofficial tool developed by the community. " +
                "It helps you simplify the process\nof syncing your wish " +
                "counter to the paimon.moe website and replaces the need " +
                "to\nopen a PowerShell window, which can be challenging " +
                "for beginners or those not\nfamiliar with technology.\n\nCredits: @nekkochan0x0007 (Duy Thanh)";
        }

        private void btnOpenGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Duy-Thanh/paimonDotMoeCompanion");
        }

        private void btnCheckForUpdate_Click(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://duy-thanh.github.io/paimonDotMoeCompanion/update.xml");
            AutoUpdater.Mandatory = false; // set to true if force update
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ReportErrors = true;

            Thread.Sleep(100);
        }
    }
}
