using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class StorehouseVm : IMapWith<Storehouse>
    {
        public int Storehouse_id { get; set; }
        public string Product_name { get; set; }
        public int Count { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Storehouse, StorehouseVm>()
                .ForMember(storeVm => storeVm.Storehouse_id,
                    opt => opt.MapFrom(storeVm => storeVm.Storehouse_id))
                .ForMember(storeVm => storeVm.Product_name,
                    opt => opt.MapFrom(storeVm => storeVm.Product_name))
                .ForMember(storeVm => storeVm.Count,
                    opt => opt.MapFrom(storeVm => storeVm.Count));
        }
    }
}
