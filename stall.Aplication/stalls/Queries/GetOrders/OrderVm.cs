using AutoMapper;
using stall.Application.Common.Mappings;
using stall.Application.stalls.Queries.GetProducts;
using stall.Domain.customer;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetOrders
{
    public class OrderVm : IMapWith<Order>
    {
        public int Order_id { get; set; }
        public int Customer_id { get; set; }
        public string Full_name { get; set; }
        public string Adres { get; set; }
        public int Sum { get; set; }
        public int Status_id { get; set; }
        public int Chek_id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderVm>()
                .ForMember(orderVm => orderVm.Order_id,
                    opt => opt.MapFrom(orderVm => orderVm.Order_id))
                .ForMember(orderVm => orderVm.Customer_id,
                    opt => opt.MapFrom(orderVm => orderVm.Customer_id))
                .ForMember(orderVm => orderVm.Full_name,
                    opt => opt.MapFrom(orderVm => orderVm.Full_name))
                .ForMember(orderVm => orderVm.Adres,
                    opt => opt.MapFrom(orderVm => orderVm.Adres))
                .ForMember(orderVm => orderVm.Sum,
                    opt => opt.MapFrom(orderVm => orderVm.Sum))
                .ForMember(orderVm => orderVm.Status_id,
                    opt => opt.MapFrom(orderVm => orderVm.Status_id))
                .ForMember(orderVm => orderVm.Chek_id,
                    opt => opt.MapFrom(orderVm => orderVm.Chek_id));
        }
    }
}
