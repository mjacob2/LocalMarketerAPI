using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess.Entities;
using MediatR;
using LocalMarketer.DataAccess.CQRS.Queries.DealsQueries;
using System.Globalization;
using LocalMarketer.ApplicationServices.API.ErrorHandling;

namespace LocalMarketer.ApplicationServices.API.Handlers.DealsHandler
{
        public class ResendOnboardingHandler : IRequestHandler<ResendOnboardingRequest, ResendOnboardingResponse>
        {
                private readonly IQueryExecutor executor;

                public ResendOnboardingHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }

                public async Task<ResendOnboardingResponse> Handle(ResendOnboardingRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetDealByIdQuery()
                        {
                                DealId = request.DealId,
                                LoggedUserRole = request.LoggedUserRole,
                                LoggedUserId = int.Parse(request.LoggedUserId, CultureInfo.InvariantCulture),
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        try
                        {
                                await EmailService.SendClientOnboardingEmail(dataFromDb, dataFromDb.Profile.Name, request.ClientEmail);
                        }
                        catch (Exception ex)
                        {
                                return new ResendOnboardingResponse()
                                {
                                        Error = new ErrorModel(ErrorType.InternalServerError),
                                };
                        }
                       

                        var response = new ResendOnboardingResponse()
                        {
                                ResponseData = "Onboarding e-mail resend succesfully!",
                        };

                        return response;
                }
        }
}
