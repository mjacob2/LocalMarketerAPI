﻿using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class AddDealRequest : RequestBase, IRequest<AddDealResponse>
        {
                public int ProfileId { get; set; }

                public int PackageId { get; set; }
                public string Name { get; set; }
                public double Price { get; set; }
                public string Description { get; set; }
                public DateTime EndDate { get; set; }
                public string Stage { get; set; }

        }
}