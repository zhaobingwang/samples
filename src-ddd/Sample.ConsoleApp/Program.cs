using System;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Sample.Infrastructure.Util;

namespace Sample.ConsoleApp
{
    class Program
    {
        private const string EMAIL_ADREES = "";
        private const string EMAIL_PASSWORD = "";
        static void Main(string[] args)
        {
            Console.WriteLine("start.");
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("cstree_sys@outlook.com"));
            message.To.Add(new MailboxAddress("zhaobingwang@foxmail.com"));
            message.Subject = "Hi,the mail from MimeKit";
            message.Body = new TextPart(TextFormat.Plain) { Text = "Hi,the mail from MimeKit." };
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.MessageSent += Smtp_MessageSent;
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtp.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(EMAIL_ADREES, EMAIL_PASSWORD);
                smtp.Send(message);
                smtp.Disconnect(true);
            }
            Console.WriteLine("end");
        }

        private static void Smtp_MessageSent(object sender, MailKit.MessageSentEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Response);
        }
    }
}
