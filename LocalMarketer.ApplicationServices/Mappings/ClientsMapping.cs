using LocalMarketer.ApplicationServices.API.Domain.Models;
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
                                Id = data.Id,
                                CreationDate = data.CreationDate,
                                Description = data.Description,
                                Email = data.Email,
                                FirstName = data.FirstName,
                                LastName = data.LastName,
                                Phone = data.Phone,
                                SellerId = data.CreatorId,
                                Source = data.Source,
                                Profiles = data.Profiles.Select(x => new ProfileGeneralModel()
                                {
                                        Id = x.Id,
                                        Name = x.Name,
                                }).ToList(),
                        };
                }

                internal static List<ClientListModel> GetAllClients(List<Client> data)
                {
                        return data.Select(x => new ClientListModel()
                        {
                                Id = x.Id,
                                CreationDate = x.CreationDate,
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
