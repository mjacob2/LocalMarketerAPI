using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.Mappings
{
        internal static class ProfilesMappings
        {
                internal static List<ProfileListModel> GetAllProfiles(List<Profile> data)
                {
                        return data.Select(x => new ProfileListModel()
                        {
                                Id = x.Id,
                                GoogleProfileId = x.GoogleProfileId,
                                CreationDate = x.CreationDate,
                                Name = x.Name,
                                CreatorId = x.CreatorId,
                                UserId = x.UserId,
                                ClientId = x.ClientId,
                                Source = x.Source,
                                City = x.City,
                                Phone = x.Phone,
                                Email = x.Email,

                        }).ToList();
                }
        }
}
