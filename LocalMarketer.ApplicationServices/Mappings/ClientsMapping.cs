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
                                SellerEmail = x.SellerEmail,

                        }).ToList();
                }
        }
}
