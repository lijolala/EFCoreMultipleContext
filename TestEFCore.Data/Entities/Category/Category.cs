using ERS.Data.Entities;
using System.Collections.Generic;

namespace ERS.Data.Entity
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}