using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.DealsCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands;
using System.Net.Mail;
using System.Net;
using FluentEmail.Core;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace LocalMarketer.ApplicationServices.API.Handlers.DealsHandler
{
        public class AddDealHandler : IRequestHandler<AddDealRequest, AddDealResponse>
        {
                private readonly ICommandExecutor executor;
                private Deal dataFromDb;

                public AddDealHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddDealResponse> Handle(AddDealRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new Deal()
                        {
                                CreationDate = DateTime.Today,
                                Name = request.Name,
                                Price = request.Price,
                                CreatorId = int.Parse(request.LoggedUserId),
                                ProfileId = request.ProfileId,
                                PackageId = request.PackageId,
                                Description = request.Description,
                                EndDate = request.EndDate,
                                Stage = request.Stage,

                        };

                        var command = new AddDealCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);

                                await CreateAutomaticToDos(this.dataFromDb);

                                // Build the email message
                                var message = new MimeMessage();
                                message.From.Add(new MailboxAddress("Sender Name", "sender@example.com"));
                                message.To.Add(new MailboxAddress("Recipient Name", "jakubicki.m@gmail.com"));
                                message.Subject = "New deal created";
                                message.Body = new TextPart("plain")
                                {
                                        Text = "A new deal has been created."
                                };

                                // Configure the SMTP client
                                var smtpClient = new MailKit.Net.Smtp.SmtpClient();
                                smtpClient.Connect("smtp.mailgun.org", 465, SecureSocketOptions.SslOnConnect);
                                smtpClient.Authenticate("postmaster@sandbox4352f0546e5940a2907705cb3e729e5f.mailgun.org", "d7cb774375a804aadd088dcf65ca4e49-49a2671e-e1170936");

                                // Send the email message
                                smtpClient.Send(message);
                                smtpClient.Disconnect(true);

                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddDealResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }



                        var response = new AddDealResponse()
                        {
                                ResponseData = this.dataFromDb,
                        };

                        //var smtpClient = new SmtpClient("s6.cyber-folks.pl")
                        //{
                        //        Port = 465,
                        //        Credentials = new NetworkCredential("mjakubicki@localmarketer.pl", "J2Uq-TJa5.]1-^)o"),
                        //        EnableSsl = true,
                        //};

                        //smtpClient.Send("mjakubicki@localmarketer.pl", "biuro@middlers.pl", "subject", "body");


                        return response;
                }


                private async Task CreateAutomaticToDos(Deal newDeal)
                {
                        var threeDaysFromNow = DateTime.Today.AddDays(3);
                        var sevenDaysFromNow = DateTime.Today.AddDays(7);
                        var forteenDaysFromNow = DateTime.Today.AddDays(14);

                        var oneMontFromNow = DateTime.Today.AddMonths(1);
                        var twoMonthsFromNow = DateTime.Today.AddMonths(2);
                        var threeMonthsFromNow = DateTime.Today.AddMonths(3);
                        var fourMonthsFromNow = DateTime.Today.AddMonths(4);
                        var fiveMonthsFromNow = DateTime.Today.AddMonths(5);

                        var threeDaysBeforeDealEndDate = newDeal.EndDate.AddDays(-3);

                        var packageExclusiveTasks = new List<ToDo>
                        {
                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Aktywuj czat",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Potwierdź pinezkę i widok z mapy",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = oneMontFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = threeDaysBeforeDealEndDate,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = oneMontFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = forteenDaysFromNow,
                                        Description = "http://bitly.pl/7FtAx \n http://bitly.pl/HOlGU \n http://bitly.pl/V2CNu",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = oneMontFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.Id,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                },
                        };

                        List<ToDo> todostoAdd;

                        if (newDeal.Name.Contains("Exclusive", StringComparison.InvariantCultureIgnoreCase))
                        {
                                todostoAdd = packageExclusiveTasks;
                        }
                        else
                        {
                                todostoAdd = new List<ToDo>();
                        }


                        foreach (var todo in todostoAdd)
                        {
                                var command = new AddToDoCommand() { Parameter = todo };
                                try
                                {
                                        await this.executor.Execute(command);
                                }
                                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                                {
                                        throw new InvalidOperationException(ex.Message);
                                }
                        }

                }

        }


}
