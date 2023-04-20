using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ToDosRequests
{
        public class AddToDoRequest : RequestBase, IRequest<AddToDoResponse>
        {
                public int CreatorId { get; set; }
                public string Title { get; set; }
                public int DealId { get; set; }
                public DateTime StartDate { get; set; }
                public DateTime DueDate { get; set; }
                public string Description { get; set; }
                public bool IsFinished { get; set; }
                public List<Note> Notes { get; set; }
        }
}
