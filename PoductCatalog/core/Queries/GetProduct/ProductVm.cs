using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProductCatalog.core.Common.Mappings;
using ProductCatalog.Interfaces.Models;

namespace ProductCatalog.core.Queries.GetProduct
{
    public class ProductVm :  IMapWith<Product>
    {
        public int Id { get; set; }
        public int Brend_id { get; set; }
        public string Product_name { get; set; }
        public string Description { get; set; }
        public string Characteristic { get; set; }
        public int Category_id { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Product, ProductVm>()
                .ForMember(productVm => productVm.Id,
                    opt => opt.MapFrom(productVm => productVm.Id))
                .ForMember(productVm => productVm.Brend_id,
                    opt => opt.MapFrom(productVm => productVm.Brend_id))
                .ForMember(productVm => productVm.Product_name,
                    opt => opt.MapFrom(productVm => productVm.Product_name))
                .ForMember(productVm => productVm.Description,
                    opt => opt.MapFrom(productVm => productVm.Description))
                .ForMember(productVm => productVm.Characteristic,
                    opt => opt.MapFrom(productVm => productVm.Characteristic))
                .ForMember(productVm => productVm.Category_id,
                    opt => opt.MapFrom(productVm => productVm.Category_id))
                .ForMember(productVm => productVm.Price,
                    opt => opt.MapFrom(productVm => productVm.Price));
        }
    }
}
