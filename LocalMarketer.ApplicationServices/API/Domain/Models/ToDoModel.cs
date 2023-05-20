namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ToDoModel
        {
                public int ToDoId { get; set; }
                public int DealId { get; set; }
                public DateTime CreationDate { get; set; }
                public string Title { get; set; }
                public string ProfileName { get; set; }
                public int ProfileId { get; set; }
                public string Description { get; set; }
                public DateTime DueDate { get; set; }
                public bool IsFinished { get; set; }
                public string UserFullName { get; set; }
                public DateTime DealEndDate { get; set; }
                public string? Link1 { get; set; }
                public string? Link2 { get; set; }
                public string? Link3 { get; set; }
                public string? Link4 { get; set; }
                public string? Link5 { get; set; }
                public string ForRole { get; set; }
        }
}
