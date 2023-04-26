using LocalMarketer.ApplicationServices.API.Domain.Responses.PackagesResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.PackagesRequests
{
        public class GetAllPackagesRequest : RequestBase, IRequest<GetAllPackagesResponse>
        {
        }
}