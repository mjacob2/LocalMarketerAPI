﻿using LocalMarketer.ApplicationServices.API.Domain.Responses.ClientsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ClientsRequests
{
        public class GetClientByIdRequest : RequestBase, IRequest<GetClientByIdResponse>
        {
                public int ClientId { get; set; }
        }
}
