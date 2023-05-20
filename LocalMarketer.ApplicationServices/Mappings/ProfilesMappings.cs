using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocalMarketer.ApplicationServices.API.Domain.Models.GetProfileByIdResponceModel;

namespace LocalMarketer.ApplicationServices.Mappings
{
        internal static class ProfilesMappings
        {
                internal static List<ProfileListModel> GetAllProfiles(List<Profile> data)
                {
                        return data.Select(x => new ProfileListModel()
                        {
                                Id = x.ProfileId,
                                GoogleProfileId = x.GoogleProfileId,
                                CreationDate = x.CreationDate,
                                Name = x.Name,
                                CreatorId = x.CreatorId,
                                //UserId = x.Client.UserId,
                                ClientId = x.ClientId,
                                Source = x.Source,
                                City = x.City,
                                Phone = x.Phone,
                                Email = x.Email,

                        }).ToList();
                }


                internal static GetProfileByIdResponceModel GetProfileById(Profile data)
                {
                        return new GetProfileByIdResponceModel()
                        {
                                City = data.City,
                                ClientEmail = data.Client.Email,
                                CustomerService = data.CustomerService,
                                CreatorId = data.CreatorId,
                                CreationDate = data.CreationDate,
                                Name = data.Name,
                                ClientId = data.ClientId,
                                Description = data.Description,
                                Email = data.Email,
                                ProfileId = data.ProfileId,
                                GoogleProfileId = data.GoogleProfileId,
                                Nip = data.NIP,
                                Phone = data.Phone,
                                PostCode = data.PostCode,
                                ProfileUrl = data.ProfileUrl,
                                Street = data.Street,
                                Regon = data.REGON,
                                Source = data.Source,
                                MediaLink = data.MediaLink,
                                WebsiteUrl = data.WebsiteUrl,
                                Voivodeship = data.Voivodeship,
                                Deals = data.Deals.Select(x => new DealGeneral()
                                {
                                        Id = x.DealId,
                                        Name = x.Name,
                                        Description = x.Description,
                                        ToDos = x.ToDos.Select(y => new ToDoGeneral()
                                        {
                                                Id = y.ToDoId,
                                                isFinished = y.IsFinished,
                                                Title = y.Title,

                                        }).ToList(),
                                }).ToList(),


                        };

                }
        }
}
