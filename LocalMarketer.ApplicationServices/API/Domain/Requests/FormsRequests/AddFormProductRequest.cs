using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests
{
        public class AddFormProductRequest : RequestBase, IRequest<AddFormProductResponse>
        {
                public int ProfileId { get; set; }
                public int DealId { get; set; }
                public List<Product>? Products { get; set; }
        }

        public class Product
        {
                public string Category { get; set; }
                public string Name { get; set; }
                public string? Price { get; set; }
                public string? Description { get; set; }
                public string? Link { get; set; }
                public string Image { get; set; }
        }
}
