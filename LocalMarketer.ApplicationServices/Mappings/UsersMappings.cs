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
                                Id = x.Id,
                                CreationDate = x.CreationDate,
                                Firstname = x.Firstname,
                                Lastname = x.Lastname,
                                Phone = x.Phone,
                                Email = x.Email,
                                Role = x.Role,
                                AccesDenied = x.AccesDenied,
                                ProfilesCount = x.Profiles.Count,
                                ToDosCount = x.Profiles
                                .SelectMany(u => u.Deals)
                                .SelectMany(d => d.ToDos)
                                .Distinct()
                                .Count(),

                        }).ToList();
                }
        }
}
