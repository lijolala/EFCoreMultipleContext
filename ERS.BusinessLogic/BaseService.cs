using System;
using ERS.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using ERS.Data.Infrastructure;
using ERS.Data.UnitOfWork;

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

        private UnitOfWork _unitOfWork;
        protected UnitOfWork UnitOfWork
        {
            get
            {
                return this._unitOfWork ?? (this._unitOfWork = new UnitOfWork(this.Factory,
                                                        this.CurrentLoggedInUserID,
                                                        this.CurrentLoggedInUserName));
            }
        }

        protected IRepository<TEntity> Repository;
        // ReSharper disable once StaticMemberInGenericType
        protected static int DefaultMaxResults = 20;

        #endregion

        public IEnumerable<TEntity> GetAll()
        {
            return this.Repository.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <returns></returns>
        public TEntity FirstOrDefault()
        {
            return this.Repository.FirstOrDefault();
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity Find(int id)
        {
            return this.Repository.Get(id);
        }

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return this.Repository.Count();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(T entity)
        {
            this.Repository.Insert(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(T entity)
        {
            this.Repository.Update(entity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Delete(object id)
        {
            this.Repository.Delete(id);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(T entity)
        {
            this.Repository.Delete(entity);
        }

        /// <summary>
        /// Attach entity to the current data context.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Attach(T entity)
        {
            this.Repository.Attach(entity);
        }
              

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            this._factory.Dispose();
        }

        #region User

        public int? CurrentLoggedInUserID { get; set; }

        public string CurrentLoggedInUserName { get; set; }

        #endregion

    }
}
