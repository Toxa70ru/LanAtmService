using AutoMapper;
using ProductCatalog.core.Common.Mappings;
using ProductCatalog.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetCategorys
{
    public class CategoryVm : IMapWith<Category>
    {
        public int Category_id { get; set; }
        public string Category_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryVm>()
                .ForMember(categVm => categVm.Category_id,
                    opt => opt.MapFrom(categVm => categVm.Category_id))
                .ForMember(categVm => categVm.Category_name,
                    opt => opt.MapFrom(categVm => categVm.Category_name));
        }
    }
}
