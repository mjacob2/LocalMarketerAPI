﻿using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests
{
        public class AddFormFaqRequest : RequestBase, IRequest<AddFormFaqResponse>
        {
                public int ProfileId { get; set; }
                public int DealId { get; set; }
                public string? Question1 { get; set; }
                public string? Answer1 { get; set; }

                public string? Question2 { get; set; }
                public string? Answer2 { get; set; }

                public string? Question3 { get; set; }
                public string? Answer3 { get; set; }

                public string? Question4 { get; set; }
                public string? Answer4 { get; set; }

                public string? Question5 { get; set; }
                public string? Answer5 { get; set; }

                public string? Question6 { get; set; }
                public string? Answer6 { get; set; }
        }
}
