using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.CQRS.Queries;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses
{
        public class GetAllToDosResponse : ResponseBase<List<ToDoListModel>>
        {
                public int Count { get; set; }
        }
}
