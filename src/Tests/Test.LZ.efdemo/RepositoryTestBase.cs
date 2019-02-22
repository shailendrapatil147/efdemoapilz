using LZ.Common.Logging;
using LZ.Common.Logging.Serilog;
using LZ.DataLayer.efdemo.Context;
using LZ.DataLayer.efdemo.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test.LZ.efdemo
{
    public class RepositoryTestBase : TestBase
    {
        const string ConnectionstringKey = "Data:DefaultConnection:ConnectionString";
        private Dictionary<string, List<object>> CreatedEntities { get; }

        protected IMemoryCache _memoryCache;
        protected IDistributedCache _distributedCache;
        protected IefdemoRepository _memRepository;
        protected IefdemoRepository _sqlRepository;
        protected IefdemoContext _efdemoContextSql;
        protected efdemoContext _efdemoContextMem;

        public RepositoryTestBase()
        {
            CreatedEntities = new Dictionary<string, List<object>>();

            _distributedCache =
                new MemoryDistributedCache(
                    new OptionsWrapper<MemoryDistributedCacheOptions>(
                        new MemoryDistributedCacheOptions()));

            _efdemoContextMem = InMemorySearchContext();

            //_sqlRepository = new efdemoRepository(
            //    _efdemoContextSql,
            //    _configuration,
            //    _loggingService,
            //    mapper
            //);

            //_memRepository = new efdemoRepository(
            //    _efdemoContextMem,
            //    _configuration,
            //    _loggingService,
            //    mapper
            //);
        }

        /// <summary>
        /// TestSearchContext
        /// </summary>
        /// <returns></returns>
        protected static efdemoContext InMemorySearchContext()
        {

            var options = new DbContextOptionsBuilder<efdemoContext>()
               .UseInMemoryDatabase(nameof(efdemoContext))
               .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
               .Options;

            return new efdemoContext(null);
        }

        /// <summary>
        /// TestSearchContext
        /// </summary>
        /// <returns></returns>
        protected efdemoContext SqlSearchContext()
        {

            var options = new DbContextOptionsBuilder<efdemoContext>()
               .UseSqlServer(_configuration[ConnectionstringKey])
               .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
               .Options;

            return new efdemoContext(null);
        }

        protected efdemoRepository GetNewRepository(efdemoContext context)
        {

            return new efdemoRepository(context, _configuration);
        }

        /// <summary>
        /// Gets the created entity based on  the index.
        /// </summary>
        /// <typeparam name="T">The key.</typeparam>
        /// <param name="index">The index defaulted to  zero.</param>
        /// <returns></returns>
        protected T GetCreated<T>(int index = 0)
        {
            if (CreatedEntities.ContainsKey(typeof(T).Name))
            {
                var obj = CreatedEntities[typeof(T).Name];
                return (T)obj.ToArray()[index];
            }

            throw new Exception("Requested key is not found.");
        }

        /// <summary>
        /// Gets the created entity based on  the index.
        /// </summary>
        /// <typeparam name="T">The key.</typeparam>
        /// <returns></returns>
        protected IList<T> GetAllCreated<T>()
        {
            if (CreatedEntities.ContainsKey(typeof(T).Name))
            {
                var obj = CreatedEntities[typeof(T).Name];
                return (IList<T>)obj;
            }

            throw new Exception("Requested key is not found.");
        }

        protected T Create<T>(Action<T> predicate = null) where T : class, new()
        {
            var obj = new T();

            predicate?.Invoke(obj);
            using (var context = InMemorySearchContext())
            {
                context.Add<T>(obj);
                context.SaveChanges();
            }

            if (CreatedEntities.ContainsKey(typeof(T).Name))
            {
                var value = CreatedEntities[typeof(T).Name];
                value.Add(obj);
            }
            else
            {
                CreatedEntities.Add(typeof(T).Name, new List<object> { obj });
            }

            return obj;
        }

    }
}