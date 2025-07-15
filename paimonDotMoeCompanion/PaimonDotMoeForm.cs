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
using ReaLTaiizor.Forms;

namespace paimonDotMoeCompanion
{
    public partial class PaimonDotMoeForm : LostForm
    {
        public PaimonDotMoeForm()
        {
            this.ShowInTaskbar = false;

            this.FormClosing += PaimonDotMoeForm_FormClosing;

            InitializeComponent();

            InitializeAsync();

            btnBack.Cursor = btnForward.Cursor = btnReload.Cursor = btnClose.Cursor = Cursors.Hand;

            txtLink.KeyDown += TxtLink_KeyDown;
        }

        private readonly string[] blockedHosts = new[]
        {
            "doubleclick.net",
            "googleads.g.doubleclick.net",
            "ads.pubmatic.com",
            "adservice.google.com",
            "pagead2.googlesyndication.com",
            "googlesyndication.com",
            "ads.yahoo.com",
            "adnxs.com",
            "facebook.com/tr",
            "tpc.googlesyndication.com"
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
            this.Dispose();
        }

        private async void InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);

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
