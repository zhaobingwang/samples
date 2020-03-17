using System;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;

namespace MailKitDemo
{
    class Program
    {
        static readonly string FromName = "";
        static readonly string FromAddress = "";
        static readonly string FromPassword = "";
        static readonly string ToUserName = "";
        static readonly string ToUserAddress = "";
        static void Main(string[] args)
        {
            SendingMessages();
            RetrievingMessagesWithIMAP();
        }

        private static void SendingMessages()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(FromName, FromAddress));
            message.To.Add(new MailboxAddress(ToUserName, ToUserAddress));
            message.Subject = "Hello,MailKit!";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = $"MailKit Demo"
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.163.com", 465, true);
                client.Authenticate(FromAddress, FromPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }

        private static void RetrievingMessagesWithIMAP()
        {
            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("imap.163.com", 993, true);
                client.Authenticate(FromAddress, FromPassword);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                Console.WriteLine("Total messages: {0}", inbox.Count);
                Console.WriteLine("Recent messages: {0}", inbox.Recent);

                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    Console.WriteLine("Subject: {0}", message.Subject);
                }

                client.Disconnect(true);
            }
        }
    }
}
