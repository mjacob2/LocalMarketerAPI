﻿using LocalMarketer.ApplicationServices.API.Domain.Responses.ProfilesResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.ProfilesRequests
{
        public class DeleteProfileByIdRequest : RequestBase, IRequest<DeleteProfileByIdResponse>
        {
                public int ProfileId { get; set; }
        }
}