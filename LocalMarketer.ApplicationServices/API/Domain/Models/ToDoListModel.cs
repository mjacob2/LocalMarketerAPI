namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ToDoListModel
        {
                public int ToDoId { get; set; }
                public DateTime CreationDate { get; set; }
                public string Title { get; set; }
                public string ProfileName { get; set; }
                public int ProfileId { get; set; }
                public DateTime DueDate { get; set; }
                public bool IsFinished { get; set; }
                public string? UserFullName { get; set; }

                public string ForRole {get; set; }
        }
}
