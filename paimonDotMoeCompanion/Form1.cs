using AutoUpdaterDotNET;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paimonDotMoeCompanion
{
    public partial class Form1 : LostForm
    {
        private Logger logger;

        public string RegionSelected { get; set; }

        public int RegionSelectedIndex { get; set; }

        public bool IsWindows11 { get; set; }

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

        unsafe void PrintObjectAddress(object obj)
        {
            TypedReference tr = __makeref(obj);
            IntPtr* ptr = (IntPtr*)*(IntPtr*)&tr;
            IntPtr address = *ptr;

            //logger.Log($"Object address: 0x{address.ToString("X")}", LogLevel.Info);
        }

        public Form1(bool IsWindows11Detected)
        {
            InitializeComponent();

            IsWindows11 = IsWindows11Detected;

            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;

            rtbLog.ReadOnly = true;

            logger = new Logger(rtbLog);

            logger.Log("Log system initialized", LogLevel.Info);

            if (IsWindows11Detected)
            {
                logger.Log("You are using Windows 11", LogLevel.Success);
                var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
                var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
                DwmSetWindowAttribute(this.Handle,
                    attribute, ref preference, sizeof(uint));
            }
            else
            {
                logger.Log("You are not using Windows 11", LogLevel.Success);
            }

            PrintObjectAddress(logger);

            lblTitle.Text =
                "This is an unofficial tool developed by the community. " +
                "It helps you simplify the process\nof syncing your wish " + 
                "counter to the paimon.moe website and replaces the need " +
                "to\nopen a PowerShell window, which can be challenging " +
                "for beginners or those not\nfamiliar with technology. Credits: @nekkochan0x0007 (Duy Thanh)";

            logger.Log("Application started", LogLevel.Info);

            RegionSelected = (cbbRegion.SelectedIndex == 0) ? "global" : "china";
            logger.Log("Region Selected: " + ((cbbRegion.SelectedIndex == 0) ? "Global" : "China"), LogLevel.Info);
            RegionSelectedIndex = cbbRegion.SelectedIndex;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.Log("Checking for updates...", LogLevel.Info);
            AutoUpdater.Start("https://duy-thanh.github.io/paimonDotMoeCompanion/update.xml");
            AutoUpdater.Mandatory = false; // set to true if force update
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ReportErrors = true;

            Thread.Sleep(100);

            logger.Log("Update check done!", LogLevel.Success);
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtLink.TextButton);

                //MessageBox.Show("Link copied to clipboard.\n\nPlease go to paimon.moe/wish/import and paste the link in step 11!",
                //        "Copy to clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);

                logger.Log("Link copied to clipboard.\n\nPlease go to paimon.moe/wish/import and paste the link in step 11!", LogLevel.Success);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Failed to copy link to clipboard.\n\nPlease try again!\n\nException:\n" + ex.Message,
                //        "Copy to clipboard", MessageBoxButtons.OK, MessageBoxIcon.Error);

                logger.Log("Failed to copy link to clipboard.\n\nPlease try again!\n\nException:\n" + ex.Message + "\n\nStacktrace:\n" + ex.StackTrace,
                    LogLevel.Error);
            }
        }

        private void btnOpenPaimonDotMoe_Click(object sender, EventArgs e)
        {
            logger.Log("Starting in-app web browser window...", LogLevel.Info);
            PaimonDotMoeForm frm = new PaimonDotMoeForm(IsWindows11);
            frm.ShowDialog();
            logger.Log("In-app web browser window closed", LogLevel.Info);
        }

        private void btnClearAllLogs_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
            logger.Log("Log window cleared", LogLevel.Info);
        }

        private void cbbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Log("Region changed: " + (cbbRegion.SelectedIndex != RegionSelectedIndex).ToString(), LogLevel.Info);
            logger.Log("Region Selected: " + ((cbbRegion.SelectedIndex == 0) ? "Global" : "China"), LogLevel.Info);

            RegionSelected = (cbbRegion.SelectedIndex == 0) ? "global" : "china";
            RegionSelectedIndex = cbbRegion.SelectedIndex;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            // Start now!
            logger.Log("Begin to fetch wishes data...", LogLevel.Info);

            // Disable the button to prevent multiple clicks
            btnStart.Enabled = false;

            try
            {
                await Task.Run(() => GetLink.getLink(logger, RegionSelected));
                txtLink.TextButton = GetLink.FoundLink;
            }
            finally
            {
                // Re-enable the button
                btnStart.Enabled = true;
            }

            logger.Log("Fetch wishes data done. Please check the log for any errors!", LogLevel.Info);
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            logger.Log("Starting about project window...", LogLevel.Info);
            AboutProject about = new AboutProject(IsWindows11);
            about.ShowDialog();
            logger.Log("About project window closed", LogLevel.Info);
        }
    }
}
