using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Util
{
    public class EmailOperator
    {
        private string _sendServerHost;
        private int _sendServerPort;
        private ILogger _logger;
        public EmailOperator(ILogger logger, string sendServerHost, int sendServerPort)
        {
            _logger = logger;
            _sendServerHost = sendServerHost;
            _sendServerPort = sendServerPort;
        }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderEmailAdrees { get; set; }
        public string SenderEmailPassword { get; set; }
        public MailKit.Security.SecureSocketOptions SecureSocketOptions { get; set; }
        public void SendEmail(string from, string to)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(from));
            message.To.Add(new MailboxAddress(to));
            message.Subject = Subject;
            message.Body = new TextPart(TextFormat.Plain) { Text = Body };

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.MessageSent += Smtp_MessageSent;
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect(_sendServerHost, _sendServerPort, SecureSocketOptions);
                smtp.Authenticate(SenderEmailAdrees, SenderEmailPassword);
                smtp.Send(message);
                smtp.Disconnect(true);
            }
        }

        private void Smtp_MessageSent(object sender, MailKit.MessageSentEventArgs e)
        {
            // log record
            string message = $"{nameof(MailKit.MessageSentEventArgs.Message)}:{e.Message};{nameof(MailKit.MessageSentEventArgs.Response)}:{e.Response}";
            _logger.LogInformation(message);
        }
    }
}
