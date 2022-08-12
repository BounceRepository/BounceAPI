using Bounce_Application.Persistence.Interfaces.Context;
using Bounce_DbOps.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Repositorires
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{

        public DbSet<TEntity> DbEntities { set; get; }
        public IQueryable<TEntity> Table => Entities;

        public readonly BounceDbContext _context;
        public Repository(BounceDbContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            await Entities.AddAsync(entity);
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");
            Entities.AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");
            await Entities.AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (_context.Entry(entity).State.Equals(EntityState.Detached))
                _context.Set<TEntity>().Attach(entity);

            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            var enumerable = entities as TEntity[] ?? entities.ToArray();
            if (_context.Entry(entities).State.Equals(EntityState.Detached))
                _context.Set<IEnumerable<TEntity>>().Attach(enumerable);

            _context.Set<TEntity>().RemoveRange(enumerable);
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entity");

            if (_context.Entry(entities).State.Equals(EntityState.Detached))
                _context.Set<TEntity>().AttachRange(entities);

            _context.Entry(entities).State = EntityState.Modified;
            return entities;
        }



        private DbSet<TEntity> Entities
        {
            get
            {
                if (DbEntities == null)
                {
                    DbEntities = _context.Set<TEntity>();
                }
                return DbEntities;
            }
        }
    }
}
