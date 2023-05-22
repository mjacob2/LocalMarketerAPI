using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using LocalMarketer.DataAccess.Entities;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class AddDealRequest : RequestBase, IRequest<AddDealResponse>
        {
                public int ProfileId { get; set; }
                public string SellerFullName { get; set; }
                public int SellerId { get; set; }
                public Package? SelectedPackage { get; set; }
                public string Name { get; set; }
                public double Price { get; set; }
                public string Description { get; set; }
                public string ProfileName { get; set; }
                public string ClientEmail { get; set; }

        }
}
