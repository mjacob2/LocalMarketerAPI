using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;

namespace LocalMarketer.ApplicationServices.Mappings
{
        public class UsersMappings
        {
                internal static List<UserListModel> GetAllUsers(List<User> data)
                {
                        return data.Select(x => new UserListModel()
                        {
                                Id = x.UserId,
                                CreationDate = x.CreationDate,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                Phone = x.Phone,
                                Email = x.Email,
                                Role = x.Role,
                                AccesDenied = x.AccesDenied,
                                ProfilesCount = x.Clients.Select(x => x.Profiles).Count(),
                                ToDosCount = x.Clients.Select(x => x.Profiles.SelectMany(u => u.Deals)
                                .SelectMany(d => d.ToDos)
                                .Distinct()
                                ).Count()
                                ,

                        }).ToList();
                }
        }
}
