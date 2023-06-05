using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LocalMarketer.DataAccess.Entities
{
        public class FormBasic
        {
                public int FormBasicId { get; set; }
                public DateTime CreationDate { get; set; }
                public int ProfileId { get; set; }

                [JsonIgnore]
                public Profile Profile { get; set; }
                public int DealId { get; set; }

                [MaxLength(50)]
                public string? OpenedDate { get; set; }

                [MaxLength(500)]
                public string? Description { get; set; }

                [MaxLength(50)]
                public string? CustomerService { get; set; }

                [MaxLength(200)]
                public string? AcceptedPaymentMethods { get; set; }

                [MaxLength(50)]
                public string? Voivodeship { get; set; }

                [MaxLength(50)]
                public string? City { get; set; }

                [MaxLength(50)]
                public string? Street { get; set; }

                [MaxLength(10)]
                public string? PostCode { get; set; }

                [MaxLength(10)]
                public string? Phone { get; set; }

                [MaxLength(1000)]
                public string? WebsiteUrl { get; set; }

                [MaxLength(1000)]
                public string? VisitsUrl { get; set; }

                [MaxLength(5)]
                public string? MondayFrom { get; set; }

                [MaxLength(5)]
                public string? MondayTo { get; set; }

                [MaxLength(5)]
                public string? TuesdayFrom { get; set; }

                [MaxLength(5)]
                public string? TuesdayTo { get; set; }

                [MaxLength(5)]
                public string? WednesdayFrom { get; set; }

                [MaxLength(5)]
                public string? WednesdayTo { get; set; }

                [MaxLength(5)]
                public string? ThursdayFrom { get; set; }

                [MaxLength(5)]
                public string? ThursdayTo { get; set; }

                [MaxLength(5)]
                public string? FridayFrom { get; set; }

                [MaxLength(5)]
                public string? FridayTo { get; set; }

                [MaxLength(5)]
                public string? SaturdayFrom { get; set; }

                [MaxLength(5)]
                public string? SaturdayTo { get; set; }

                [MaxLength(5)]
                public string? SundayFrom { get; set; }

                [MaxLength(5)]
                public string? SundayTo { get; set; }
                public bool? Atr1 { get; set; }
                public bool? Atr2 { get; set; }
                public bool? Atr3 { get; set; }
                public bool? Atr4 { get; set; }
                public bool? Atr5 { get; set; }
                public bool? Atr6 { get; set; }
                public bool? Atr7 { get; set; }
                public bool? Atr8 { get; set; }
                public bool? Atr9 { get; set; }
                public bool? Atr10 { get; set; }
                public bool? Atr11 { get; set; }
                public bool? Atr12 { get; set; }
                public bool? Atr13 { get; set; }
                public bool? Atr14 { get; set; }
                public bool? Atr15 { get; set; }
                public bool? Atr16 { get; set; }
                public bool? Atr17 { get; set; }
        }
}
