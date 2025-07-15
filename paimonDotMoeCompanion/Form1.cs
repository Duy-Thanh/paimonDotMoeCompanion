using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paimonDotMoeCompanion
{
    public partial class Form1 : LostForm
    {
        private Logger logger;

        public string RegionSelected { get; set; }

        public int RegionSelectedIndex { get; set; }


        unsafe void PrintObjectAddress(object obj)
        {
            TypedReference tr = __makeref(obj);
            IntPtr* ptr = (IntPtr*)*(IntPtr*)&tr;
            IntPtr address = *ptr;

            logger.Log($"Logger address: 0x{address.ToString("X")}", LogLevel.Info);
        }

        public Form1()
        {
            InitializeComponent();

            rtbLog.ReadOnly = true;

            logger = new Logger(rtbLog);

            logger.Log("Log system initialized", LogLevel.Info);

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

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtLink.TextButton);

                MessageBox.Show("Link copied to clipboard.\n\nPlease go to paimon.moe/wish/import and paste the link in step 11!",
                        "Copy to clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to copy link to clipboard.\n\nPlease try again!\n\nException:\n" + ex.Message,
                        "Copy to clipboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenPaimonDotMoe_Click(object sender, EventArgs e)
        {
            PaimonDotMoeForm frm = new PaimonDotMoeForm();
            frm.ShowDialog();
        }

        private void btnClearAllLogs_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
            logger.Log("Log cleared", LogLevel.Info);
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
        }
    }
}
