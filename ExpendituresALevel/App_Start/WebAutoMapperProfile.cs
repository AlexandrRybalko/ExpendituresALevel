using AutoMapper;
using BL.BLModels;
using ExpendituresALevel.Models;
using ExpendituresALevel.Models.Category;

namespace ExpendituresALevel
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<CategoryBLModel, CategoryModel>();
            CreateMap<CategoryBLModel, CategoryModel>().ReverseMap();

            CreateMap<TransactionBLModel, TransactionModel>();
            CreateMap<TransactionBLModel, TransactionModel>().ReverseMap();

            CreateMap<CategoryBLModel, AutoCompleteModel>()
                .ForMember(x => x.data, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.value, opt => opt.MapFrom(src => src.Title));
        }
    }
}