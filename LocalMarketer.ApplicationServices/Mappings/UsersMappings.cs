using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.Mappings
{
    public class UsersMappings
    {
        internal static List<UserListModel> GetUserListModel(List<User> data)
        {
            return data.Select(x => new UserListModel()
            {
                UserId = x.Id,
                CreationDate = x.CreationDate,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                Email = x.Email,
                Role = x.Role,
                HasAccess = x.HasAccess,
                ProfilesCount = x.Clients.SelectMany(x => x.Profiles).Count(),
                ClientsCount = x.Clients.Count(),
                ToDosCount = x.Clients.SelectMany(c => c.Profiles.SelectMany(v => v.Deals)
                        .SelectMany(b => b.ToDos.Where(n => n.ForRole == x.Role).Where(n => !n.IsFinished)))
                    .Count()
                    ,

            }).ToList();
        }

        internal static UserModel GetUserModel(User data)
        {
            return new UserModel()
            {
                UserId = data.Id,
                CreationDate = data.CreationDate,
                HasAccess = data.HasAccess,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Phone = data.Phone,
                Role = data.Role,
            };
        }
    }
}
