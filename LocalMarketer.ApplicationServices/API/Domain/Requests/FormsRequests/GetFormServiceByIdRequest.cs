using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests
{
        public class GetFormServiceByIdRequest : RequestBase, IRequest<GetFormServiceByIdResponse>
        {
                public int FormServiceId { get; set; }
        }
}