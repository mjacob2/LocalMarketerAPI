using LocalMarketer.ApplicationServices.API.Domain.Responses.FormsResponses;
using MediatR;

namespace LocalMarketer.ApplicationServices.API.Domain.Requests.FormsRequests
{
        public class AddFormBasicRequest : RequestBase, IRequest<AddFormBasicResponse>
        {
                public int ProfileId { get; set; }
                public int DealId { get; set; }
                public string? OpenedDate { get; set; }
                public string? Description { get; set; }
                public string? CustomerService { get; set; }
                public string? AcceptedPaymentMethods { get; set; }
                public string? Voivodeship { get; set; }
                public string? City { get; set; }
                public string? Street { get; set; }
                public string? PostCode { get; set; }
                public string? Phone { get; set; }
                public string? WebsiteUrl { get; set; }
                public string? VisitsUrl { get; set; }
                public string? MondayFrom { get; set; }
                public string? MondayTo { get; set; }
                public string? TuesdayFrom { get; set; }
                public string? WednesdayFrom { get; set; }
                public string? WednesdayTo { get; set; }
                public string? ThursdayFrom { get; set; }
                public string? ThursdayTo { get; set; }
                public string? FridayFrom { get; set; }
                public string? FridayTo { get; set; }
                public string? SaturdayFrom { get; set; }
                public string? SaturdayTo { get; set; }
                public string? SundayFrom { get; set; }
                public string? SundayTo { get; set; }
                public bool Atr1 { get; set; }
                public bool Atr2 { get; set; }
                public bool Atr3 { get; set; }
                public bool Atr4 { get; set; }
                public bool Atr5 { get; set; }
                public bool Atr6 { get; set; }
                public bool Atr7 { get; set; }
                public bool Atr8 { get; set; }
                public bool Atr9 { get; set; }
                public bool Atr10 { get; set; }
                public bool Atr11 { get; set; }
                public bool Atr12 { get; set; }
                public bool Atr13 { get; set; }
                public bool Atr14 { get; set; }
                public bool Atr15 { get; set; }
                public bool Atr16 { get; set; }
                public bool Atr17 { get; set; }
        }
}
