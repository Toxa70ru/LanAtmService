using AutoMapper;
using OrderService.Interfaces.models;
using OrderService.core.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
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
