using LocalMarketer.ApplicationServices.API.Domain.Models;
using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.ApplicationServices.Mappings
{
        public class DealsMappings
        {
                internal static List<DealListModel> GetAllDeals(List<Deal> data)
                {
                        return data.Select(x => new DealListModel()
                        {
                                Id = x.Id,
                                CreationDate = x.CreationDate,
                                Name = x.Name,
                                EndDate = x.EndDate,
                                Stage = x.Stage,
                                CreatorId = x.CreatorId,


                        }).ToList();
                }
        }
}
