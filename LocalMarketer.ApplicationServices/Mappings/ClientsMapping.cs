﻿using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.Mappings
{
        internal static class ClientsMapping
        {
                internal static ClientDetailsModel ClientDetailsProfile(Client data)
                {
                        return new ClientDetailsModel()
                        {
                                Id = data.ClientId,
                                CreationDate = data.CreationDate,
                                Name = data.Name,
                                GoogleGroupId = data.GoogleGroupId,
                                Description = data.Description,
                                Email = data.Email,
                                FirstName = data.FirstName,
                                LastName = data.LastName,
                                Phone = data.Phone,
                                Source = data.Source,
                                Profiles = data.Profiles.Select(x => new ProfileGeneralModel()
                                {
                                        Id = x.ProfileId,
                                        Name = x.Name,
                                }).ToList(),
                                Users = data.ClientUsers.Select(x => new UserListModel()
                                {
                                        Id = x.UserId,
                                        FirstName = x.User.FirstName,
                                        LastName = x.User.LastName,
                                        Role = x.User.Role,
                                }).ToList(),
                        };
                }

                internal static List<ClientListModel> GetAllClients(List<Client> data)
                {
                        return data.Select(x => new ClientListModel()
                        {
                                Id = x.ClientId,
                                CreationDate = x.CreationDate,
                                Name = x.Name,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                Phone = x.Phone,
                                Email = x.Email,
                                Source = x.Source,
                                CreatorId = x.CreatorId,

                        }).ToList();
                }
        }
}
