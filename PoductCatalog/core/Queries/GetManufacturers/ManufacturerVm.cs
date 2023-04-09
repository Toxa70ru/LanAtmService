using AutoMapper;
using ProductCatalog.core.Common.Mappings;
using ProductCatalog.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetManufacturers
{
    public class ManufacturerVm : IMapWith<Manufacturer>
    {
        public int Brend_id { get; set; }
        public string Brend { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Manufacturer, ManufacturerVm>()
                .ForMember(brendVm => brendVm.Brend_id,
                    opt => opt.MapFrom(brendVm => brendVm.Brend_id))
                .ForMember(brendVm => brendVm.Brend,
                    opt => opt.MapFrom(brendVm => brendVm.Brend));
        }
    }

}
