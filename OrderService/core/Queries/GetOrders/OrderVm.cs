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
    public class OrderVm : IMapWith<Order>
    {
        public int Order_id { get; set; }
        public string Customer_name { get; set; }
        public string Full_name { get; set; }
        public string Adres { get; set; }
        public int Sum { get; set; }
        public int Status_id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderVm>()
                .ForMember(orderVm => orderVm.Order_id,
                    opt => opt.MapFrom(orderVm => orderVm.Order_id))
                .ForMember(orderVm => orderVm.Customer_name,
                    opt => opt.MapFrom(orderVm => orderVm.Customer_name))
                .ForMember(orderVm => orderVm.Full_name,
                    opt => opt.MapFrom(orderVm => orderVm.Full_name))
                .ForMember(orderVm => orderVm.Adres,
                    opt => opt.MapFrom(orderVm => orderVm.Adres))
                .ForMember(orderVm => orderVm.Sum,
                    opt => opt.MapFrom(orderVm => orderVm.Sum))
                .ForMember(orderVm => orderVm.Status_id,
                    opt => opt.MapFrom(orderVm => orderVm.Status_id));
        }
    }
}
