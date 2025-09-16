using AutoUpdaterDotNET;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paimonDotMoeCompanion
{
    public partial class AboutProject : LostForm
    {
        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
        // Copied from dwmapi.h
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.
        // Copied from dwmapi.h
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);

        public AboutProject(bool IsWindows11Detected)
        {
            if (IsWindows11Detected)
            {
                var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
                var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
                DwmSetWindowAttribute(this.Handle,
                    attribute, ref preference, sizeof(uint));
            }

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
