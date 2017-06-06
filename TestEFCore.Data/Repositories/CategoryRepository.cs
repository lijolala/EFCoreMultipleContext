using ERS.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using TestEFCore.Data.Entity;
using TestEFCore.Data.Infrastructure;
using TestEFCore.Data.ERSContext;
using ERS.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace ERS.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly CategoryContext _dbContext;

        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {
            _dbContext = (_dbContext ?? (CategoryContext)dbContext);
        }

        public IEnumerable<CategoryWithExpense> GetCategoryWithExpenses()
        {
            var category = GetAll().Join(_dbContext.Expenses, c => c.Id, e => e.CategoryId, (c, e) => new { c, e })
                .GroupBy(z => new { z.c.Id, z.c.Name, z.c.Description }, z => z.e)
                .Select(
                    g =>
                        new CategoryWithExpense
                        {
                            CategoryId = g.Key.Id,
                            CategoryName = g.Key.Name,
                            Description = g.Key.Description,
                            TotalExpenses = g.Sum(s => s.Amount)
                        });
            return category;
        }
    }
}
