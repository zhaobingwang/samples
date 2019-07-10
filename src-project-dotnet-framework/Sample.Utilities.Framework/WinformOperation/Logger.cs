using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Utilities.Framework.WinformOperation
{
    public class Logger
    {
        RichTextBox _rtxLogs;
        public Logger(RichTextBox rtxLogs)
        {
            _rtxLogs = rtxLogs;
        }

        public void LogInfo(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            _rtxLogs.Invoke(la, Color.Black, GetNowTimeForLogs() + text);
        }
        public void LogImportant(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            _rtxLogs.Invoke(la, Color.Green, GetNowTimeForLogs() + text);
        }
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            _rtxLogs.Invoke(la, Color.Red, GetNowTimeForLogs() + text);
        }


        private delegate void LogAppendDelegate(Color color, string text);
        private void LogAppend(Color color, string text)
        {
            _rtxLogs.SelectionColor = color;
            _rtxLogs.AppendText(text + "\n");
            _rtxLogs.ScrollToCaret();
        }
        private string GetNowTimeForLogs()
        {
            return DateTime.Now.ToString("HH:mm:ss fff ");
        }
    }
}
