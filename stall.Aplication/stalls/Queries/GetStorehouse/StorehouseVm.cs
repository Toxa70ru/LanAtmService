using AutoMapper;
using stall.Application.Common.Mappings;
using stall.Application.stalls.Queries.GetProducts;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStorehouse
{
    public class StorehouseVm : IMapWith<Storehouse>
    {
        public int Storehouse_id { get; set; }
        public int Product_id { get; set; }
        public int Count { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Storehouse, StorehouseVm>()
                .ForMember(storeVm => storeVm.Storehouse_id,
                    opt => opt.MapFrom(storeVm => storeVm.Storehouse_id))
                .ForMember(storeVm => storeVm.Product_id,
                    opt => opt.MapFrom(storeVm => storeVm.Product_id))
                .ForMember(storeVm => storeVm.Count,
                    opt => opt.MapFrom(storeVm => storeVm.Count));
        }
    }
}
