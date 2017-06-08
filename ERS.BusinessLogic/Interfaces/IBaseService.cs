﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERS.BusinessLogic.Interfaces
{
     interface IBaseService<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
      
        void Insert(TEntity entity);
               
         void Update(TEntity entity);

        void Delete(int id);

    
        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> @where);

        TEntity Get(Expression<Func<TEntity, bool>> @where);

   
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
 
         Task<List<TEntity>> GetAllAsync();
       
         Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> @where);
             
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> @where);

    }
}
