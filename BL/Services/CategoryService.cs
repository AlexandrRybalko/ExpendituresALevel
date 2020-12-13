using AutoMapper;
using BL.BLModels;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryBLModel>();
                cfg.CreateMap<Category, CategoryBLModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void Create(CategoryBLModel model)
        {
            var category = _mapper.Map<Category>(model);
            _categoryRepository.Create(category);
        }

        public void DeleteById(int id)
        {
            _categoryRepository.DeleteById(id);
        }

        public CategoryBLModel GetById(int id)
        {
            var category = _categoryRepository.GetById(id);

            return _mapper.Map<CategoryBLModel>(category);
        }

        public IEnumerable<CategoryBLModel> GetTransactions()
        {
            var categories = _categoryRepository.GetMyCategories();
            return _mapper.Map<IEnumerable<CategoryBLModel>>(categories);
        }
    }
}
