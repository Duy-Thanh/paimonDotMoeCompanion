using Microsoft.Web.WebView2.Core;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paimonDotMoeCompanion
{
    public partial class PaimonDotMoeForm : LostForm
    {
        private CoreWebView2Environment _webViewEnvironment;
        private bool _disposed = false;

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

        public PaimonDotMoeForm(bool IsWindows11Detected)
        {
            this.ShowInTaskbar = false;

            this.FormClosing += PaimonDotMoeForm_FormClosing;
            this.FormClosed += PaimonDotMoeForm_FormClosed;

            if (IsWindows11Detected)
            {
                var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
                var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
                DwmSetWindowAttribute(this.Handle,
                    attribute, ref preference, sizeof(uint));
            }

            InitializeComponent();

            InitializeAsync();

            btnBack.Cursor = btnForward.Cursor = btnReload.Cursor = btnClose.Cursor = Cursors.Hand;

            txtLink.KeyDown += TxtLink_KeyDown;
        }

        private void PaimonDotMoeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CleanupWebView();
        }

        private void PaimonDotMoeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cleanup will happen in FormClosed
        }

        private void CleanupWebView()
        {
            if (_disposed) return;
            _disposed = true;

            try
            {
                if (webView21?.CoreWebView2 != null)
                {
                    // Unsubscribe from all events
                    webView21.CoreWebView2.NavigationStarting -= OnNavigationStarting;
                    webView21.CoreWebView2.SourceChanged -= OnSourceChanged;
                    webView21.CoreWebView2.DocumentTitleChanged -= OnDocumentTitleChanged;
                    webView21.CoreWebView2.NavigationCompleted -= OnNavigationCompleted;
                    webView21.CoreWebView2.WebResourceRequested -= OnWebResourceRequested;

                    // Navigate to about:blank to stop any ongoing processes
                    try
                    {
                        webView21.CoreWebView2.Navigate("about:blank");
                    }
                    catch { /* Ignore navigation errors during cleanup */ }
                }

                // Dispose WebView2 control
                webView21?.Dispose();

                // Set environment reference to null (it's managed by WebView2 runtime)
                _webViewEnvironment = null;

                // Force garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            catch (Exception ex)
            {
                // Log the exception but don't throw
                System.Diagnostics.Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        private readonly string[] blockedHosts = new[]
        {
            // Google Ads
            "doubleclick.net",
            "googleads.g.doubleclick.net",
            "adservice.google.com",
            "pagead2.googlesyndication.com",
            "tpc.googlesyndication.com",
            "googlesyndication.com",
            "google-analytics.com",

            // Facebook/Meta
            "facebook.com/tr",
            "connect.facebook.net",
            "facebook.net",
            "fbcdn.net",

            // Microsoft/Bing
            "bat.bing.com",
            "c.bing.com",

            // Yahoo/Verizon
            "ads.yahoo.com",
            "gemini.yahoo.com",

            // Amazon
            "aax.amazon-adsystem.com",

            // Other ad providers
            "ads.pubmatic.com",
            "adnxs.com",
            "adform.net",
            "adroll.com",
            "taboola.com",
            "outbrain.com",
            "criteo.com",
            "scorecardresearch.com",
            "mathtag.com",
            "openx.net",
            "yieldmo.com",
            "zdbb.net",
            "moatads.com",
            "casalemedia.com",
            "revcontent.com",
            "tradedoubler.com",
            "bluekai.com",
            "tracking",
            "tracker",
            "clicksor.com"
        };

        private void TxtLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // prevent ding sound

                string url = txtLink.Text.Trim();

                if (!url.StartsWith("http"))
                {
                    url = "https://" + url;
                }

                try
                {
                    webView21.CoreWebView2.Navigate(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Navigation failed: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void InitializeAsync()
        {
            try
            {
                _webViewEnvironment = await CoreWebView2Environment.CreateAsync(null,
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PaimonDotMoeCompanion", "WebView2"));

                await webView21.EnsureCoreWebView2Async(_webViewEnvironment);

                // Subscribe to events using separate methods for easier cleanup
                webView21.CoreWebView2.NavigationStarting += OnNavigationStarting;
                webView21.CoreWebView2.SourceChanged += OnSourceChanged;
                webView21.CoreWebView2.DocumentTitleChanged += OnDocumentTitleChanged;
                webView21.CoreWebView2.NavigationCompleted += OnNavigationCompleted;

                webView21.CoreWebView2.AddWebResourceRequestedFilter("*",
                    Microsoft.Web.WebView2.Core.CoreWebView2WebResourceContext.All);

                webView21.CoreWebView2.WebResourceRequested += OnWebResourceRequested;

                webView21.CoreWebView2.Navigate("https://paimon.moe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize WebView2: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnNavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            if (_disposed) return;

            txtLink.Text = e.Uri;
            this.Text = webView21.CoreWebView2.DocumentTitle;
            this.Invalidate();
        }

        private void OnSourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            if (_disposed) return;

            this.Text = webView21.CoreWebView2.DocumentTitle;
            this.Invalidate();
            txtLink.Text = webView21.CoreWebView2.Source;
        }

        private void OnDocumentTitleChanged(object sender, object e)
        {
            if (_disposed) return;

            this.Text = webView21.CoreWebView2.DocumentTitle;
            this.Invalidate();
        }

        private async void OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (_disposed) return;

            // Fallback in case others fail
            this.Text = webView21.CoreWebView2.DocumentTitle;
            this.Invalidate();
            txtLink.Text = webView21.CoreWebView2.Source;

            string adBlockScript = @"
                const styles = document.createElement('style');
                styles.innerHTML = `
                    iframe[src*='ads'],
                    div[class*='ad'],
                    [id*='ad'], .adsbygoogle, .sponsored {
                        display: none !important;
                    }
                `;
                document.head.appendChild(styles);
            ";

            try
            {
                await webView21.ExecuteScriptAsync(adBlockScript);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error executing ad block script: {ex.Message}");
            }
        }

        private void OnWebResourceRequested(object sender, CoreWebView2WebResourceRequestedEventArgs e)
        {
            if (_disposed) return;

            try
            {
                Uri uri = new Uri(e.Request.Uri);

                if (blockedHosts.Any(blocked => uri.Host.Contains(blocked)))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(
                        Stream.Null, 403, "Blocked", "Content-Type: text/plain");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in WebResourceRequested: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webView21.CanGoBack)
            {
                webView21.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webView21.CanGoForward)
            {
                webView21.GoForward();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webView21.Reload();
        }
    }
}