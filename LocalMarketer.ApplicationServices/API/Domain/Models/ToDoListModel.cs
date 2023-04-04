using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class ToDoListModel
        {
                public int Id { get; set; }
                public DateTime CreationDate { get; set; }
                public string Title { get; set; }
                public DateTime StartDate { get; set; }
                public DateTime DueDate { get; set; }
                public bool IsFinished { get; set; }
        }
}
