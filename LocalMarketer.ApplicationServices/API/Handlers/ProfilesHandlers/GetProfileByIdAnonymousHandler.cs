using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using LocalMarketer.ApplicationServices.API.ErrorHandling;
using LocalMarketer.ApplicationServices.Mappings;
using LocalMarketer.DataAccess.CQRS.Queries.ProfilesQueries;
using LocalMarketer.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Handlers.ProfilesHandlers
{
        public class GetProfileByIdAnonymousHandler : IRequestHandler<GetProfileByIdAnonymousRequest, GetProfileByIdAnonymousResponse>
        {
                private readonly IQueryExecutor executor;

                public GetProfileByIdAnonymousHandler(IQueryExecutor executor)
                {
                        this.executor = executor;
                }
                public async Task<GetProfileByIdAnonymousResponse> Handle(GetProfileByIdAnonymousRequest request, CancellationToken cancellationToken)
                {
                        var query = new GetProfileByIdAnonymousQuery()
                        {
                                ProfileId = request.ProfileId,
                        };
                        var dataFromDb = await this.executor.Execute(query);

                        if (dataFromDb == null)
                        {
                                return new GetProfileByIdAnonymousResponse()
                                {
                                        Error = new ErrorModel(ErrorType.NotFound),
                                };
                        }

                        var dataFromDbMappedToModel = ProfilesMappings.GetProfileByIdAnonymous(dataFromDb);

                        var response = new GetProfileByIdAnonymousResponse()
                        {
                                ResponseData = dataFromDbMappedToModel,
                        };

                        return response;
                }
        }
}