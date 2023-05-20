using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LocalMarketer.ApplicationServices.Mappings
{
        public class ToDosMapping
        {
                internal static List<ToDoListModel> GetAllToDos(List<ToDo> data)
                {
                        // Wszystkie ToDos
                        var allToDos = data.Select(x => new ToDoListModel()
                        {
                                ToDoId = x.ToDoId,
                                CreationDate = x.CreationDate,
                                Title = x.Title,
                                ProfileName = x.Deal.Profile.Name,
                                ProfileId = x.Deal.ProfileId,
                                DueDate = x.DueDate,
                                IsFinished = x.IsFinished,
                                ForRole = x.ForRole,
                                UserFullName = x.Deal.Profile.Client.Users
        .FirstOrDefault(user => user.Role == x.ForRole)?
        .FirstName + " " + x.Deal.Profile.Client.Users
        .FirstOrDefault(user => user.Role == x.ForRole)?
        .LastName,
                        }).ToList();

                        return allToDos;
                }

                internal static ToDoModel GetToDoById(ToDo data)
                {
                        return new ToDoModel()
                        {
                                ToDoId = data.ToDoId,
                                DealId = data.DealId,
                                CreationDate = data.CreationDate,
                                Title = data.Title,
                                ProfileName = data.Deal.Profile.Name,
                                ProfileId = data.Deal.ProfileId,
                                Description = data.Description,
                                DueDate = data.DueDate,
                                IsFinished = data.IsFinished,
                                UserFullName = data.Deal.Profile.Client.Users
        .FirstOrDefault(user => user.Role == data.ForRole)?
        .FirstName + " " + data.Deal.Profile.Client.Users
        .FirstOrDefault(user => user.Role == data.ForRole)?
        .LastName,
                                DealEndDate = data.Deal.EndDate,
                                Link1 = data.Link1,
                                Link2 = data.Link2,
                                Link3 = data.Link3,
                                Link4 = data.Link4,
                                Link5 = data.Link5,
                                ForRole = data.ForRole

                        };
                }
        }
}
