﻿using LocalMarketer.ApplicationServices.API.Domain.Responses.UsersResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.UsersRequests
{
        public class GetAllUsersRequest : RequestBase, IRequest<GetAllUsersResponse>
        {
                public bool? ShowOnlySellers { get; set; }
                public int PageIndex { get; set; }
                public int PageSize { get; set; }
        }
}