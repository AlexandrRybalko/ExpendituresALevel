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
        }
    }
}