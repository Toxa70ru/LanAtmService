using AutoMapper;
using stall.Application.stalls.Commands.Create.seller;
using stall.Application.Common.Mappings;
using stall.Domain.seller;

namespace stall.WebApi.Models
{
    public class CreateCategoryDto : IMapWith<CreateCategory>
    {
        public int Category_id { get; set; } 
        public string Category_name { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCategory>()
                .ForMember(creatPr => creatPr.Category_name,
                    opt => opt.MapFrom(creatPr => creatPr.Category_name))
                .ForMember(creatPr => creatPr.Category_id,
                    opt => opt.MapFrom(creatPr => creatPr.Category_id));

        }
    }
}
