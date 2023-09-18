using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using static LocalMarketer.ApplicationServices.API.Domain.Models.GetProfileByIdResponceModel;

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
                //UserId = x.Client.UserId,
                ClientId = x.ClientId,
                ClientName = x.Client.Name,
                Voivodeship = x.Voivodeship,
                City = x.City,
                Phone = x.Phone,
                SellerFullName = x.Client.Users.Where(c => c.Role == User.Roles.Seller.ToString()).Select(v => $"{v.FirstName} {v.LastName}").FirstOrDefault(),
                LocalMarketerFullName = x.Client.Users.Where(c => c.Role == User.Roles.LocalMarketer.ToString()).Select(v => $"{v.FirstName} {v.LastName}").FirstOrDefault(),

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
                ProfileId = data.Id,
                GoogleProfileId = data.GoogleProfileId,
                Phone = data.Phone,
                PostCode = data.PostCode,
                ProfileUrl = data.ProfileUrl,
                Street = data.Street,
                MediaLink = data.MediaLink,
                WebsiteUrl = data.WebsiteUrl,
                Voivodeship = data.Voivodeship,
                Deals = data.Deals.Select(x => new DealGeneral()
                {
                    DealId = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ToDos = x.ToDos.Select(y => new ToDoGeneral()
                    {
                        ToDoId = y.Id,
                        isFinished = y.IsFinished,
                        Title = y.Title,

                    }).ToList(),
                }).ToList(),


            };

        }
        internal static GetProfileByIdAnonymousResponceModel GetProfileByIdAnonymous(Profile data)
        {
            return new GetProfileByIdAnonymousResponceModel()
            {
                ProfileId = data.Id,
                City = data.City,
                CustomerService = data.CustomerService,
                Name = data.Name,
                Description = data.Description,
                GoogleProfileId = data.GoogleProfileId,
                Phone = data.Phone,
                PostCode = data.PostCode,
                ProfileUrl = data.ProfileUrl,
                Street = data.Street,
                WebsiteUrl = data.WebsiteUrl,
                Voivodeship = data.Voivodeship,
                ClientId = data.ClientId,
                MediaLink = data.MediaLink,
            };
        }

    }
}
