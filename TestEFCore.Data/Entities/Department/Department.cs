using ERS.Data.Entities;
using System.Collections.Generic;

namespace TestEFCore.Data.Entity
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}