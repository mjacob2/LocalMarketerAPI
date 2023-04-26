using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests
{
        public class DeleteToDoByIdRequest : RequestBase, IRequest<DeleteToDoByIdResponse>
        {
                public int ToDoId { get; set; }
        }
}