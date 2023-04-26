using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests
{
        public class GetToDoByIdRequest : RequestBase, IRequest<GetToDoByIdResponse>
        {
                public int ToDoId { get; set; }
        }
}