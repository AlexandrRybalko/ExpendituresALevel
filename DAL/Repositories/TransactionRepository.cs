using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TransactionRepository
    {
        private readonly ExpendituresContext _ctx;

        public TransactionRepository()
        {
            _ctx = new ExpendituresContext();
        }

        public void Create(Transaction model)
        {
            _ctx.Transactions.Add(model);

            _ctx.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = _ctx.Transactions.FirstOrDefault(x => x.Id == id);
            _ctx.Transactions.Remove(entity);

            _ctx.SaveChanges();
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _ctx.Transactions.ToList();
        }
    }
}
