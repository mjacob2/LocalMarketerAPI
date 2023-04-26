namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ToDoModel
        {
                public int Id { get; set; }
                public DateTime CreationDate { get; set; }
                public string Title { get; set; }
                public string ProfileName { get; set; }
                public int ProfileId { get; set; }
                public string Description { get; set; }
                public DateTime DueDate { get; set; }
                public bool IsFinished { get; set; }
                public string UserFullName { get; set; }
                public DateTime DealEndDate { get; set; }
        }
}
