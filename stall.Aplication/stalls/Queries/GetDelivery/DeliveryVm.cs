using AutoMapper;
using stall.Application.Common.Mappings;
using stall.Application.stalls.Queries.GetProducts;
using stall.Domain.courier;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetDelivery
{
    public class DeliveryVm : IMapWith<Delivery>
    {
        public int Delivery_id { get; set; }
        public int Order_id { get; set; }
        public int Status_id { get; set; }
        public int Courier_id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Delivery, DeliveryVm>()
                .ForMember(delVm => delVm.Delivery_id,
                    opt => opt.MapFrom(delVm => delVm.Delivery_id))
                .ForMember(delVm => delVm.Order_id,
                    opt => opt.MapFrom(delVm => delVm.Order_id))
                .ForMember(delVm => delVm.Status_id,
                    opt => opt.MapFrom(delVm => delVm.Status_id))
                .ForMember(delVm => delVm.Courier_id,
                    opt => opt.MapFrom(delVm => delVm.Courier_id));
        }
    }
}
