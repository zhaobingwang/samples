using System;
using MailKit;
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
    }
}
