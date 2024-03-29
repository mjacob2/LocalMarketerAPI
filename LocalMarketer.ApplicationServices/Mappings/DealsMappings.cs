﻿using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using Microsoft.VisualBasic;
namespace LocalMarketer.ApplicationServices.Mappings
{
    public class DealsMappings
    {
        internal static List<DealListModel> GetAllDeals(List<Deal> data)
        {
            return data.Select(x => new DealListModel()
            {
                Id = x.Id,
                CreationDate = x.CreationDate,
                Name = x.Name,
                EndDate = x.EndDate,
                Stage = x.Stage,
                CreatorId = x.CreatorId,


            }).ToList();
        }

        internal static DealDetailsModel GetDealById(Deal data)
        {
            return new DealDetailsModel()
            {
                CreationDate = data.CreationDate,
                DealId = data.Id,
                CreatorId = data.CreatorId,
                ProfileId = data.ProfileId,
                ClientEmail = data.Profile.Client.Email,
                Name = data.Name,
                PackageId = data.PackageId,
                Price = data.Price,
                Description = data.Description,
                Stage = data.Stage,
                EndDate = data.EndDate,
                ToDos = data.ToDos.Select(x => new ToDoModel()
                {
                    ToDoId = x.Id,
                    Title = x.Title,
                    DueDate = x.DueDate,
                    IsFinished = x.IsFinished,
                }).ToList(),
            };
        }
    }
}
