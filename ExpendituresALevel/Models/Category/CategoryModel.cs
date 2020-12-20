using System;
using System.Collections.Generic;

namespace ExpendituresALevel.Models.Category
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<TransactionModel> Transactions { get; set; }
    }
}