using AutoMapper;
using BL.BLModels;
using BL.Services;
using ExpendituresALevel.App_Start;
using ExpendituresALevel.Models;
using ExpendituresALevel.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LightInjectConfig.Congigurate();
            PL pl = new PL(new CategoryService(), new TransactionService());

            
            pl.CreateCategory(new CategoryModel { Title = "ffff", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            var c = pl.GetCategories();
        }
    }

    class PL
    {
        private readonly ICategoryService _categoryService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper mapper;

        public PL(ICategoryService categoryService, ITransactionService transactionService)
        {
            _categoryService = categoryService;
            _transactionService = transactionService;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryModel, CategoryBLModel>();
                cfg.CreateMap<CategoryModel, CategoryBLModel>().ReverseMap();

                cfg.CreateMap<TransactionModel, TransactionBLModel>();
                cfg.CreateMap<TransactionModel, TransactionBLModel>().ReverseMap();
            });

            mapper = new Mapper(mapperConfig);
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var c = _categoryService.GetCategories();

            return mapper.Map<IEnumerable<CategoryModel>>(c);
        }

        public void CreateCategory(CategoryModel model)
        {
            var c = mapper.Map<CategoryBLModel>(model);
            _categoryService.Create(c);
        }

        public CategoryModel GetCategoryById(int id)
        {
            var c = _categoryService.GetById(id);
            return mapper.Map<CategoryModel>(c);
        }

        public void DeleteCategory(int id)
        {
            _categoryService.DeleteById(id);
        }

        public IEnumerable<TransactionModel> GetTransactions()
        {
            var c = _transactionService.GetTransactions();

            return mapper.Map<IEnumerable<TransactionModel>>(c);
        }

        public void CreateTransaction(TransactionModel model)
        {
            var c = mapper.Map<TransactionBLModel>(model);
            _transactionService.Create(c);
        }

        public TransactionModel GetTransactionById(int id)
        {
            var c = _transactionService.GetById(id);
            return mapper.Map<TransactionModel>(c);
        }

        public void DeleteTransaction(int id)
        {
            _transactionService.DeleteById(id);
        }
    }
}
