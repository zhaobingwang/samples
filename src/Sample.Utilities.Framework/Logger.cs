using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Utilities.Framework
{
    /// <summary>
    /// 使用RichTextBox记录log
    /// </summary>
    public class Logger
    {
        RichTextBox _txtLogs;
        public Logger(RichTextBox richTextBox)
        {
            _txtLogs = richTextBox;
        }

        private delegate void LogAppendDelegate(Color color, string text);
        /// <summary> 
        /// 追加显示文本 
        /// </summary> 
        /// <param name="color">文本颜色</param> 
        /// <param name="text">显示文本</param> 
        private void LogAppend(Color color, string text)
        {
            _txtLogs.SelectionColor = color;
            _txtLogs.AppendText($"{text}\n");
            _txtLogs.ScrollToCaret();
        }

        private string GetNowDateTimeForLogs()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff ");
        }

        /// <summary> 
        /// 显示常规信息日志
        /// </summary> 
        /// <param name="text"></param> 
        public void Info(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            _txtLogs.Invoke(la, Color.Black, GetNowDateTimeForLogs() + text);
        }

        /// <summary>
        /// 显示重要信息日志
        /// </summary>
        /// <param name="text"></param>
        public void LogImportantInfo(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            _txtLogs.Invoke(la, Color.Green, GetNowDateTimeForLogs() + text);
        }

        /// <summary> 
        /// 显示错误日志 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            _txtLogs.Invoke(la, Color.Red, GetNowDateTimeForLogs() + text);
        }
    }
}
