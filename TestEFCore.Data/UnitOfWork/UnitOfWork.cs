using ERS.Data.Repositories;
using ERS.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Data.Entity;
using TestEFCore.Data.Infrastructure;

namespace TestEFCore.Data.UnitOfWork
{
    public class UnitOfWork<TContext> : Disposable, IUnitOfWork<TContext>
       where TContext : DbContext, new()
    {
        public virtual int Commit()
        {
            return _dataContext.SaveChanges();
        }

        public virtual Task<int> CommitAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        private readonly DbContext _dataContext;

        public UnitOfWork()
        {
            _dataContext = new TContext();
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }

     
        private ICategoryRepository _categoryRepository;

        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository(_dataContext)); }
        }

        private IRepository<Department> _departmentRepository;

        public IRepository<Department> DepartmentRepository
        {
            get
            {
                return _departmentRepository ?? (_departmentRepository = new RepositoryBase<Department>(_dataContext));
            }
        }
    }
}
