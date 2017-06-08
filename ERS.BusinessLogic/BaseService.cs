using System;
using ERS.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using ERS.Data.Infrastructure;
using ERS.Data.UnitOfWork;
using System.Threading.Tasks;

namespace ERS.BusinessLogic
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        #region Properties

        private DatabaseFactory _factory;
        protected DatabaseFactory Factory
        {
            get
            {
                return this._factory ?? (this._factory = new DatabaseFactory());
            }
        }



        //private UnitOfWork _unitOfWork;
        //protected UnitOfWork UnitOfWork
        //{
        //    get
        //    {
        //        return this._unitOfWork ?? (this._unitOfWork = new UnitOfWork(this.data);
        //    }
        //}

        protected IRepository<TEntity> Repository;
        // ReSharper disable once StaticMemberInGenericType
        protected static int DefaultMaxResults = 20;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        #endregion
        public IEnumerable<TEntity> GetAll()
        {
            return this.Repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return this.Repository.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            this.Repository.Insert(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            this.Repository.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            this.Repository.Delete(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        public void Delete(Expression<Func<TEntity, bool>> @where)
        {
            this.Repository.Delete(where);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, bool>> @where)
        {
            return this.Repository.Get(where);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return this.Repository.GetMany(where);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> @where)
        {
            return await this.Repository.GetAsync(where);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> @where)
        {
            return await this.Repository.GetManyAsync(where);
        }

     
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            this._factory.Dispose();
        }

        #region User

        #endregion

    }
}
