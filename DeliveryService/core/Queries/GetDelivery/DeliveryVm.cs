using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class DeliveryVm : IMapWith<Delivery>
    {
        public int Delivery_id { get; set; }
        public string OrderInf { get; set; }
        public int Status_id { get; set; }
        public int Courier_id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Delivery, DeliveryVm>()
                .ForMember(delVm => delVm.Delivery_id,
                    opt => opt.MapFrom(delVm => delVm.Delivery_id))
                .ForMember(delVm => delVm.OrderInf,
                    opt => opt.MapFrom(delVm => delVm.OrderInf))
                .ForMember(delVm => delVm.Status_id,
                    opt => opt.MapFrom(delVm => delVm.Status_id))
                .ForMember(delVm => delVm.Courier_id,
                    opt => opt.MapFrom(delVm => delVm.Courier_id));
        }
    }
}
