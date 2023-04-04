using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.Mappings
{
        public class ToDosMapping
        {
                internal static List<ToDoListModel> GetAllToDos(List<ToDo> data)
                {
                        return data.Select(x => new ToDoListModel()
                        {
                                Id = x.Id,
                                CreationDate = x.CreationDate,
                                Title = x.Title,
                                StartDate = x.StartDate,
                                DueDate = x.DueDate,
                                IsFinished = x.IsFinished,
                        }).ToList();
                }
        }
}
