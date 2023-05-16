using LocalMarketer.ApplicationServices.API.Domain.Responses.DealsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.DealsRequests
{
        public class AddDealRequest : RequestBase, IRequest<AddDealResponse>
        {
                public int SellerId { get; set; }
                public string SellerFullName { get; set; }
                public int ProfileId { get; set; }
                public int selectedPackageMinPrice { get; set; }
                public int PackageId { get; set; }
                public string Name { get; set; }
                public double Price { get; set; }
                public string Description { get; set; }
                public DateTime EndDate { get; set; }
                public string Stage { get; set; }

                public string ProfileName { get; set; }

                public string ClientEmail { get; set; }

        }
}