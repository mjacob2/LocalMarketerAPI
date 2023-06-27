using LocalMarketer.DataAccess.Entities;
using MailKit.Security;
using MimeKit;

namespace LocalMarketer.ApplicationServices
{
        public class EmailService
        {
                public static async Task SendClientOnboardingEmail(Deal newDeal, string profileName, string clientEmail)
                {
                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress("Local Marketing", "no-reply@localmarketing.pl"));
                        message.To.Add(new MailboxAddress("Nowy Klient", clientEmail));
                        message.Subject = $"Zadania do wykonania - Profil firmy w Google: {profileName}";
                        message.Body = new TextPart("html")
                        {
                                Text = "<h3>Witamy w gronie naszych klientów!</h3>"
                                + "<br>" + 
                                $"Abyśmy mogli wykonać wszystkie zadania na profilu Twojej firmy: <b>{profileName}</b>, prosimy o wykonanie poniższych zadań:"
                                + "<br> <br>" +
                                $"<a href=\"https://crm.localmarketer.pl/#/forms/basic?DealId={newDeal.DealId}&ProfileId={newDeal.ProfileId}\">Wypełnij formularz Danych Podstawowych</a>"
                                + "<br> <br>" +
                                $"<a href=\"https://crm.localmarketer.pl/#/forms/faq?DealId={newDeal.DealId}&ProfileId={newDeal.ProfileId}\">Wypełnij formularz FAQ do czatu</a>"
                                + "<br> <br>" +
                                $"<a href=\"https://crm.localmarketer.pl/#/forms/service?DealId={newDeal.DealId}&ProfileId={newDeal.ProfileId}\">Wypełnij formularz Usług</a>"
                                + "<br> <br>" +
                                $"<a href=\"https://crm.localmarketer.pl/#/forms/product?DealId={newDeal.DealId}&ProfileId={newDeal.ProfileId}\">Wypełnij formularz Produktów</a>"
                                + "<br> <br>" +
                                "To jest wiadomość systemowa. Prosimy na nią nie odpowiadać."
                        };

                        var smtpClient = new MailKit.Net.Smtp.SmtpClient();
                        smtpClient.Connect("smtp.mailgun.org", 465, SecureSocketOptions.SslOnConnect);
                        smtpClient.Authenticate("postmaster@sandbox4352f0546e5940a2907705cb3e729e5f.mailgun.org", "a4dc6b5582351f25ad0de5cc1bfc6ef9-6d1c649a-66e41c4c");


                        await smtpClient.SendAsync(message);
                        smtpClient.Disconnect(true);
                }

        }
}
