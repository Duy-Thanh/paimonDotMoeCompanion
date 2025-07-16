using Microsoft.Web.WebView2.Core;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paimonDotMoeCompanion
{
    public partial class PaimonDotMoeForm : LostForm
    {
        public PaimonDotMoeForm()
        {
            this.ShowInTaskbar = false;

            this.FormClosing += PaimonDotMoeForm_FormClosing;

            this.FormClosed += PaimonDotMoeForm_FormClosed;

            InitializeComponent();

            InitializeAsync();

            btnBack.Cursor = btnForward.Cursor = btnReload.Cursor = btnClose.Cursor = Cursors.Hand;

            txtLink.KeyDown += TxtLink_KeyDown;
        }

        private void PaimonDotMoeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            webView21.Dispose();
            this.Dispose();
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

        private void PaimonDotMoeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            webView21.Dispose();
        }

        private async void InitializeAsync()
        {
            var env = await CoreWebView2Environment.CreateAsync(null,
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PaimonDotMoeCompanion", "WebView2"));

            await webView21.EnsureCoreWebView2Async(env);

            webView21.CoreWebView2.NavigationStarting += (s, e) =>
            {
                txtLink.Text = e.Uri;
                this.Text = webView21.CoreWebView2.DocumentTitle;
                this.Invalidate();
            };

            webView21.CoreWebView2.SourceChanged += (s, e) =>
            {
                this.Text = webView21.CoreWebView2.DocumentTitle;
                this.Invalidate();
                txtLink.Text = webView21.CoreWebView2.Source;
            };

            webView21.CoreWebView2.DocumentTitleChanged += (s, e) =>
            {
                this.Text = webView21.CoreWebView2.DocumentTitle;
                this.Invalidate();
            };

            webView21.CoreWebView2.NavigationCompleted += (s, e) =>
            {
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

                Task.Run(() => webView21.ExecuteScriptAsync(adBlockScript));
            };

            webView21.CoreWebView2.AddWebResourceRequestedFilter("*",
                Microsoft.Web.WebView2.Core.CoreWebView2WebResourceContext.All);

            webView21.CoreWebView2.WebResourceRequested += (s, e) =>
            {
                Uri uri = new Uri(e.Request.Uri);

                if (blockedHosts.Any(blocked => uri.Host.Contains(blocked)))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(
                        Stream.Null, 403, "Blocked", "Content-Type: text/plain");
                }
            };

            webView21.CoreWebView2.Navigate("https://paimon.moe");
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
