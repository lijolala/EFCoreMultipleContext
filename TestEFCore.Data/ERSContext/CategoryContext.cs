using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ERS.Data.Entity;

namespace ERS.Data.ERSContext
{
   public class CategoryContext:DbContext
    {
        //add config builder

        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Shadow Properties
            modelBuilder.Entity<Category>(builder =>
            {
                builder.Property(b => b.Name).IsRequired();
            });
            modelBuilder.Entity<Expense>(builder =>
            {
                builder.Property(b => b.Amount).IsRequired();
            });

        }
        public CategoryContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get from config fie
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
        }
    }

   
}
