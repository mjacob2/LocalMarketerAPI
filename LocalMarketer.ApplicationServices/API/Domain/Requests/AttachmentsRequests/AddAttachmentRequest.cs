using LocalMarketer.ApplicationServices.API.Domain.Responses.AttachmentsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.AttachmentsRequests
{
        public class AddAttachmentRequest : RequestBase, IRequest<AddAttachmentResponse>
        {
                public string Name { get; set; }
                public IList<byte> Data { get; set; }
                public int ProfileId { get; set; }
        }
}
