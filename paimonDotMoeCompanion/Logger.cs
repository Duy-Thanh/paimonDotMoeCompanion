using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paimonDotMoeCompanion
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Success,
        Debug
    }
    public class Logger
    {
        private readonly RichTextBox _logBox;

        public Logger(RichTextBox logBox)
        {
            _logBox = logBox;
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (_logBox.InvokeRequired)
            {
                _logBox.Invoke(new Action(() => Log(message, level)));
                return;
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string levelText = level.ToString().ToUpper();
            string logEntry = $"[{timestamp}] [{levelText}] {message}\n";

            Color textColor = level switch
            {
                LogLevel.Info => Color.LightBlue,
                LogLevel.Warning => Color.Yellow,
                LogLevel.Error => Color.Red,
                LogLevel.Success => Color.LightGreen,
                LogLevel.Debug => Color.LightGray,
                _ => Color.White
            };

            _logBox.SelectionStart = _logBox.TextLength;
            _logBox.SelectionLength = 0;
            _logBox.SelectionColor = textColor;
            _logBox.AppendText(logEntry);
            _logBox.SelectionColor = _logBox.ForeColor;
            _logBox.ScrollToCaret();
        }

        public void Clear()
        {
            if (_logBox.InvokeRequired)
            {
                _logBox.Invoke(new Action(() => _logBox.Clear()));
                return;
            }
            _logBox.Clear();
        }
    }
}
