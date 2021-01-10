using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExpendituresContext : DbContext
    {
        public ExpendituresContext() : base("name=ExpendituresContext")
        {
            Database.SetInitializer<ExpendituresContext>(null);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ExpendituresContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Transactions);
        }
    }
}
