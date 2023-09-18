using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.CQRS.Queries;
using LocalMarketer.DataAccess.Entities;
namespace LocalMarketer.ApplicationServices.Mappings
{
    internal static class ClientsMappings
    {
        internal static ClientDetailsModel GetClientDetailsModel(Client data)
        {
            return new ClientDetailsModel()
            {
                ClientId = data.Id,
                CreationDate = data.CreationDate,
                Name = data.Name,
                GoogleGroupId = data.GoogleGroupId,
                Description = data.Description,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Phone = data.Phone,
                CreatorId = data.CreatorId,
                CreatorFullName = data.CreatorFullName,
                Profiles = data.Profiles.Select(x => new ProfileGeneralModel()
                {
                    ProfileId = x.Id,
                    Name = x.Name,
                }).ToList(),
                Users = data.ClientUsers.Select(x => new UserListModel()
                {
                    UserId = x.UserId,
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
                ClientId = x.Id,
                CreationDate = x.CreationDate,
                Name = x.Name,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                Email = x.Email,
                CreatorId = x.CreatorId,
                SellerFullName = x.Users.Where(c => c.Role == User.Roles.Seller.ToString()).Select(v => $"{v.FirstName} {v.LastName}").FirstOrDefault(),
                LocalMarketerFullName = x.Users.Where(c => c.Role == User.Roles.LocalMarketer.ToString()).Select(v => $"{v.FirstName} {v.LastName}").FirstOrDefault(),
            }).ToList();
        }

        internal static ClientModel GetClientModel(Client data)
        {
            return new ClientModel()
            {
                ClientId = data.Id,
                CreationDate = data.CreationDate,
                Name = data.Name,
                GoogleGroupId = data.GoogleGroupId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Phone = data.Phone,
                Email = data.Email,
                Description = data.Description,
                CreatorId = data.CreatorId,
            };
        }
    }
}
