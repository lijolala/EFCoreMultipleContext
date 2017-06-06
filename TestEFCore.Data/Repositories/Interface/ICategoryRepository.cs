using ERS.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using ERS.Data.Entity;
using ERS.Data.Infrastructure;

namespace ERS.Data.Repositories.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<CategoryWithExpense> GetCategoryWithExpenses();
    }
}
