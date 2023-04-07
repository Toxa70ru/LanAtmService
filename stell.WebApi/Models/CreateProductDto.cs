using AutoMapper;
using stall.Application.Common.Mappings;
using stall.Application.stalls.Commands.Create.seller;
using stall.Application.stalls.Commands.Update.seller;

namespace stall.WebApi.Models
{
    public class CreateProductDto : IMapWith<CreateProduct>
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public string Description { get; set; }
        public string Characteristic { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<CreateProductDto, CreateProduct>()
                .ForMember(creatPr => creatPr.Product_id,
                    opt => opt.MapFrom(creatPr => creatPr.Product_id))
                .ForMember(creatPr => creatPr.Product_name,
                    opt => opt.MapFrom(creatPr => creatPr.Product_name))
                .ForMember(creatPr => creatPr.Description,
                    opt => opt.MapFrom(creatPr => creatPr.Description))
                .ForMember(creatPr => creatPr.Characteristic,
                    opt => opt.MapFrom(creatPr => creatPr.Characteristic))
                .ForMember(creatPr => creatPr.Price,
                    opt => opt.MapFrom(creatPr => creatPr.Price));

        }
    }
}
