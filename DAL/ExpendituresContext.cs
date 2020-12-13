﻿using DAL.Entities;
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
        public ExpendituresContext() : base("Data Source = DESKTOP-CVLKMS0\\MSSQLSERVER01; Initial Catalog = ExpendituresDB; Integrated Security = true")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
