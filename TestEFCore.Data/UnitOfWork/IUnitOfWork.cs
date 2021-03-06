﻿using ERS.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ERS.Data.Entity;
using ERS.Data.Infrastructure;

namespace ERS.Data.UnitOfWork
{
    public interface IUnitOfWork<U> where U : DbContext, IDisposable
    {
        int Commit();
        Task<int> CommitAsync();


      //  IRepository<Category> CategoryRepository { get; }

        ICategoryRepository CategoryRepository { get; }
        

        IRepository<Department> DepartmentRepository { get; }
    }
}
