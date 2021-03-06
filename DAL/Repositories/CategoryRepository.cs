﻿using DAL.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ICategoryRepository
    {
        void Create(Category model);

        void DeleteById(int id);

        Category GetById(int id);
        void Edit(Category editedCategory);

        IEnumerable<Category> GetMyCategories();
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpendituresContext _ctx;

        public CategoryRepository()
        {
            _ctx = new ExpendituresContext();
        }

        public void Create(Category model)
        {
            _ctx.Categories.Add(model);

            _ctx.SaveChanges();
        }

        public void DeleteById(int id)
        {
            try
            {
                var entity = _ctx.Categories.FirstOrDefault(x => x.Id == id);
                _ctx.Categories.Remove(entity);

                _ctx.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Category GetById(int id)
        {
            return _ctx.Categories.Include(x => x.Transactions).FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Category editedCategory)
        {
            _ctx.Entry(editedCategory).State = System.Data.Entity.EntityState.Modified;

            _ctx.SaveChanges();
        }

        public IEnumerable<Category> GetMyCategories()
        {
            return _ctx.Categories.Include(x => x.Transactions).ToList();
        }
    }
}
