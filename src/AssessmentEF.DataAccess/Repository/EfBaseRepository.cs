using AssessmentEF.DataAccess.Interfaces;
using AssessmentEF.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.DataAccess.Repository
{
    public class EfBaseRepository<TEntity, TContext> : IAsyncRepository<TEntity>
        where TEntity : BaseModel
        where TContext : DbContext
    {
        protected TContext Context { get; }

        public EfBaseRepository(TContext context)
        {
            Context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {            
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync()
        {
            return await Context.Set<TEntity>().CountAsync();
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {            
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                    ? await Context.Set<TEntity>().ToListAsync()
                    : await Context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
