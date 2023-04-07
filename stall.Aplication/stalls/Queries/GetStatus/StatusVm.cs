using AutoMapper;
using stall.Application.Common.Mappings;
using stall.Application.stalls.Queries.GetDelivery;
using stall.Domain.courier;
using stall.Domain.customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStatus
{
    public class StatusVm : IMapWith<Status>
    {
        public int Status_id { get; set; }
        public string Status_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Status, StatusVm>()
                .ForMember(delVm => delVm.Status_id,
                    opt => opt.MapFrom(delVm => delVm.Status_id))
                .ForMember(delVm => delVm.Status_name,
                    opt => opt.MapFrom(delVm => delVm.Status_name));
        }
    }
}
