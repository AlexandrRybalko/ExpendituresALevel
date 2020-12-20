using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T entity);
        T FindById(int id);
        void DeleteById();
        IEnumerable<T> Get();
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private readonly DbContext _ctx;

        public GenericRepository()
        {
            _ctx = new DbContext("name=ExpendituresContext");
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }
    }
}
