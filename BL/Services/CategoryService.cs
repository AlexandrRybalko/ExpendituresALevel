using AutoMapper;
using BL.BLModels;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;

namespace BL.Services
{
    public interface ICategoryService
    {
        void Create(CategoryBLModel model);
        void DeleteById(int id);
        CategoryBLModel GetById(int id);
        void Edit(CategoryBLModel editedCategory);
        IEnumerable<CategoryBLModel> GetCategories();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<BLAutoMapperProfile>());

            _mapper = new Mapper(mapperConfig);
        }

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<BLAutoMapperProfile>());

            _mapper = new Mapper(mapperConfig);
        }

        public void Create(CategoryBLModel model)
        {
            var category = _mapper.Map<Category>(model);
            _categoryRepository.Create(category);
        }

        public void DeleteById(int id)
        {
            try
            {
                _categoryRepository.DeleteById(id);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CategoryBLModel GetById(int id)
        {
            var category = _categoryRepository.GetById(id);

            return _mapper.Map<CategoryBLModel>(category);
        }

        public void Edit(CategoryBLModel editedCategory)
        {
            var category = _mapper.Map<Category>(editedCategory);
            _categoryRepository.Edit(category);
        }

        public IEnumerable<CategoryBLModel> GetCategories()
        {
            var categories = _categoryRepository.GetMyCategories();
            return _mapper.Map<IEnumerable<CategoryBLModel>>(categories);
        }
    }
}
