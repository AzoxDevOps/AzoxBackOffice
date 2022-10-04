﻿namespace Azox.Infrastructure.Core
{
    using Azox.Business.Core.Data;
    using Azox.Business.Core.Domain;
    using Azox.Business.Core.Service;
    using Azox.Core.Eventing;
    using Azox.Core.Extensions;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public abstract partial class EntityServiceBase<TEntity, TService> :
        IEntityService<TEntity>
        where TEntity : class, IEntity
        where TService : class, IEntityService<TEntity>
    {
        #region Fields

        private readonly object _clearCacheKeysLockObject = new();
        private readonly object _setCacheKeysLockObject = new();

        #endregion Fields

        #region Ctor

        protected EntityServiceBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            EventHandlerService = ServiceProvider.GetRequiredService<IEventHandlerService>();
            MemoryCache = ServiceProvider.GetRequiredService<IMemoryCache>();
            Logger = ServiceProvider.GetRequiredService<ILogger<TService>>();
            Repository = ServiceProvider.GetRequiredService<IRepository<TEntity>>();
        }

        #endregion Ctor

        #region Utils

        protected void ClearCacheKeys()
        {
            lock (_clearCacheKeysLockObject)
            {
                IList<string> cacheKeys = MemoryCache.GetOrCreate("cachekeys", ce => new List<string>());
                IList<string> tempCacheKeys = new List<string>(cacheKeys);

                for (int i = 0; i < cacheKeys.Count; i++)
                {
                    if (cacheKeys[i].StartsWith(typeof(TEntity).Name))
                    {
                        MemoryCache.Remove(cacheKeys[i]);
                        tempCacheKeys.Remove(cacheKeys[i]);
                    }
                }

                MemoryCache.Set("cachekeys", tempCacheKeys);
            }
        }

        protected string GetCacheKey()
        {
            string cacheKey = $"{typeof(TEntity).Name}-all";
            SetCacheKey(cacheKey);

            return cacheKey;
        }

        protected string GetCacheKey(Expression expression)
        {
            string cacheKey = $"{typeof(TEntity).Name}-byexp-{expression.Simplify()}";
            SetCacheKey(cacheKey);

            return cacheKey;
        }

        protected string GetCacheKeyById<T>(T id)
        {
            string cacheKey = $"{typeof(TEntity).Name}-byid-{id}";
            SetCacheKey(cacheKey);

            return cacheKey;
        }

        private void SetCacheKey(string key)
        {
            lock (_setCacheKeysLockObject)
            {
                IList<string> cacheKeys = MemoryCache.GetOrCreate("cachekeys", ce => new List<string>());

                if (!cacheKeys.Contains(key))
                {
                    cacheKeys.Add(key);
                    MemoryCache.Set("cachekeys", cacheKeys);
                }
            }
        }

        #endregion Utils

        #region Methods

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return MemoryCache.GetOrCreate(GetCacheKey(predicate),
                 ce => Repository.Any(predicate));
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return MemoryCache.GetOrCreate(GetCacheKey(predicate),
                 ce => Repository.Count(predicate));
        }

        public virtual IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return MemoryCache.GetOrCreate(GetCacheKey(predicate),
                 ce => Repository.Filter(predicate));
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return MemoryCache.GetOrCreate(GetCacheKey(predicate),
                 ce => Repository.FirstOrDefault(predicate));
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return MemoryCache.GetOrCreate(GetCacheKey(),
                 ce => Repository.GetAll());
        }

        public virtual TEntity GetById(Guid id)
        {
            return MemoryCache.GetOrCreate(GetCacheKeyById(id),
                 ce => Repository.GetById(id));
        }

        public virtual TEntity GetById(int id)
        {
            return MemoryCache.GetOrCreate(GetCacheKeyById(id),
                 ce => Repository.GetById(id));
        }

        public virtual TEntity GetById(long id)
        {
            return MemoryCache.GetOrCreate(GetCacheKeyById(id),
                 ce => Repository.GetById(id));
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                Repository.Insert(entity);
                Repository.SaveChanges();

                ClearCacheKeys();
            }
            catch (Exception ex)
            {

            }
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Repository.InsertRange(entities);
                Repository.SaveChanges();

                ClearCacheKeys();
            }
            catch (Exception ex)
            {

            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                Repository.Update(entity);
                Repository.SaveChanges();

                ClearCacheKeys();
            }
            catch (Exception ex)
            {

            }
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Repository.UpdateRange(entities);
                Repository.SaveChanges();

                ClearCacheKeys();
            }
            catch (Exception ex)
            {

            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                Repository.Delete(entity);
                Repository.SaveChanges();

                ClearCacheKeys();
            }
            catch (Exception ex)
            {

            }
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Repository.DeleteRange(entities);
                Repository.SaveChanges();

                ClearCacheKeys();
            }
            catch (Exception ex)
            {

            }
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return MemoryCache.GetOrCreate(GetCacheKey(predicate),
                 ce => Repository.SingleOrDefault(predicate));
        }

        #endregion Methods

        #region Properties
        
        protected IEventHandlerService EventHandlerService { get; }

        protected ILogger Logger { get; }

        protected IMemoryCache MemoryCache { get; }

        protected IRepository<TEntity> Repository { get; }

        protected IServiceProvider ServiceProvider { get; }


        #endregion Properties
    }
}