using LocalMarketer.DataAccess.Entities;
using MailKit.Security;
using MimeKit;

namespace LocalMarketer.ApplicationServices
{
        public class EmailService
        {
                public static async Task SendClientOnboardingEmail(Deal newDeal, string profileName, string cientEmail)
                {

                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress("Local Marketer", "no-reply@localmarketer.pl"));
                        message.To.Add(new MailboxAddress("Nowy Klient", "jakubicki.m@gmail.com"));
                        message.Subject = $"Zadania do wykonania - Profil firmy w Google: {profileName}";
                        message.Body = new TextPart("html")
                        {
                                Text = "<h3>Witamy w gronie naszych klientów!</h3>"
                                + "<br>" + 
                                $"Abyśmy mogli wykonać wszystkie zadania na profilu Twojej firmy: <b>{profileName}</b>, prosimy o wypełnienie poniższych formularzy."
                                + "<br> <br>" +
                                $"<a href=\"http://localhost:4200/forms/basic?DealId={newDeal.DealId}&ProfileId={newDeal.ProfileId}\">Wypełnij formularz Danych Podstawowych</a>"
                                + "<br> <br>" +
                                $"<a href=\"http://localhost:4200/forms/faq?DealId={newDeal.DealId}&ProfileId={newDeal.ProfileId}\">Wypełnij formularz FAQ do czatu</a>"
                                + "<br> <br>" +
                                $"<a href=\"http://localhost:4200/forms/service?DealId={newDeal.DealId}&ProfileId={newDeal.ProfileId}\">Wypełnij formularz Usług</a>"
                                + "<br> <br>" +
                                $"<a href=\"http://localhost:4200/forms/product?DealId={newDeal.DealId}&ProfileId={newDeal.ProfileId}\">Wypełnij formularz Produktów</a>"
                                
                        };

                        var smtpClient = new MailKit.Net.Smtp.SmtpClient();
                        smtpClient.Connect("smtp.mailgun.org", 465, SecureSocketOptions.SslOnConnect);
                        smtpClient.Authenticate("postmaster@sandbox4352f0546e5940a2907705cb3e729e5f.mailgun.org", "d7cb774375a804aadd088dcf65ca4e49-49a2671e-e1170936");


                        await smtpClient.SendAsync(message);
                        smtpClient.Disconnect(true);
                }

        }
}
