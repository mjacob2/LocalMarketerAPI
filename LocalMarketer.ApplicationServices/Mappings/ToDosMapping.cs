﻿using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
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
                        return data.Select(x => new ToDoListModel()
                        {
                                Id = x.Id,
                                CreationDate = x.CreationDate,
                                Title = x.Title,
                                ProfileName = x.Deal.Profile.Name,
                                ProfileId = x.Deal.ProfileId,
                                DueDate = x.DueDate,
                                IsFinished = x.IsFinished,
                                UserFullName = $"{x.Deal.Profile.User.Firstname} {x.Deal.Profile.User.Lastname}",
                        }).ToList();
                }

                internal static ToDoModel GetToDoById(ToDo data)
                {
                        return  new ToDoModel()
                        {
                                Id = data.Id,
                                CreationDate = data.CreationDate,
                                Title = data.Title,
                                ProfileName = data.Deal.Profile.Name,
                                ProfileId = data.Deal.ProfileId,
                                Description = data.Description,
                                DueDate = data.DueDate,
                                IsFinished = data.IsFinished,
                                UserFullName = $"{data.Deal.Profile.User.Firstname} {data.Deal.Profile.User.Lastname}",
                                DealEndDate = data.Deal.EndDate,
                                Link1 = data.Link1, 
                                Link2 = data.Link2,
                                Link3 = data.Link3,
                                Link4 = data.Link4,
                                Link5 = data.Link5,
                                
                        };
                }
        }
}
