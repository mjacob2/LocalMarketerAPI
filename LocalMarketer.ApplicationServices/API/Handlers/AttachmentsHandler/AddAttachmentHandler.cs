using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.AttachmentsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.AttachmentsResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.DataAccess.CQRS.Commands.AttachmentsCommands;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Handlers.AttachmentsHandler
{
        public class AddAttachmentHandler : IRequestHandler<AddAttachmentRequest, AddAttachmentResponse>
        {
                private readonly ICommandExecutor executor;
                private Attachment dataFromDb;

                public AddAttachmentHandler(ICommandExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<AddAttachmentResponse> Handle(AddAttachmentRequest request, CancellationToken cancellationToken)
                {
                        var itemtoAdd = new Attachment()
                        {
                                Name = request.Name,
                                Data = request.Data.ToArray(),
                                ProfileId = request.ProfileId,
                                CreationDate = DateTime.Today,

                        };

                        var command = new AddAttachmentCommand() { Parameter = itemtoAdd };

                        try
                        {
                                this.dataFromDb = await this.executor.Execute(command);
                        }
                        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                        {
                                return new AddAttachmentResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }


                        var response = new AddAttachmentResponse()
                        {
                                ResponseData = dataFromDb,
                        };

                        return response;
                }
        }
}
