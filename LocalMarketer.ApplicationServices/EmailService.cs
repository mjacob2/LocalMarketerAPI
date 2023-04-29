using LocalMarketer.DataAccess.Entities;
using MailKit.Security;
using MimeKit;

namespace LocalMarketer.ApplicationServices
{
        public class EmailService
        {
                public static async Task SendClientOnboardingEmail()
                {

                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress("Local Marketer", "no-reply@localmarketer.pl"));
                        message.To.Add(new MailboxAddress("Nowy Klient", "jakubicki.m@gmail.com"));
                        message.Subject = "Zadania do wykonania - Profil firmy w Google";
                        message.Body = new TextPart("plain")
                        {
                                Text = "Witamy w gronie naszych klientów!"
                        };

                        var smtpClient = new MailKit.Net.Smtp.SmtpClient();
                        smtpClient.Connect("smtp.mailgun.org", 465, SecureSocketOptions.SslOnConnect);
                        smtpClient.Authenticate("postmaster@sandbox4352f0546e5940a2907705cb3e729e5f.mailgun.org", "d7cb774375a804aadd088dcf65ca4e49-49a2671e-e1170936");


                        await smtpClient.SendAsync(message);
                        smtpClient.Disconnect(true);
                }

        }
}
