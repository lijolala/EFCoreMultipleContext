using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Data.Entity;

namespace TestEFCore.Data.ERSContext
{
    public class DepartmentContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DepartmentContext() : base()
        {
        }

        //public StudentContext(DbContextOptions options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestEFCore;Integrated Security=True");
        }
    }
}
