using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using LocalMarketer.ApplicationServices.API.Domain.Responses.ToDosResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests
{
        public class GetFormFaqByIdRequest : RequestBase, IRequest<GetFormFaqByIdResponse>
        {
                public int FormFaqId { get; set; }
        }
}
