using LocalMarketer.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses
{
    public class GetAllClientsResponse : ResponseBase<List<ClientListModel>>
    {
        public GetAllClientsResponse(List<ClientListModel> data)
                : base(data)
        {
        }
    }
}
