using DGII.Core.Application.Interfaces.Repository;
using DGII.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        public ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Entity> CreateAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await Save();

            return entity;
        }

        public async Task<IEnumerable<Entity>> CreateMultipleAsync(IEnumerable<Entity> entities)
        {
            _dbContext.Set<Entity>().AddRange(entities);
            await Save();

            return entities;

        }

        public virtual async Task<bool> DeleteAsync(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            return await Save();
        }

        public async Task<bool> DeleteMultipleAsync(IEnumerable<Entity> entities)
        {
            _dbContext.Set<Entity>().RemoveRange(entities);
            return await Save();

        }

        public virtual async Task<bool> UpdateAsync(Entity entity, int id)
        {
            if (entity != null)
            {
                Entity EntityDB = await _dbContext.Set<Entity>().FindAsync(id);
                if (EntityDB == null)
                {
                    throw new Exception("The entity couldn't be found");
                }
                _dbContext.Entry(EntityDB).CurrentValues.SetValues(entity);
            }

            return await Save();
        }


        public Task<bool> Exist(Expression<Func<Entity, bool>> lambdaCondition)
        {
            return Task.FromResult(_dbContext.Set<Entity>().Any(lambdaCondition));
        }

        public virtual async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbContext.Set<Entity>().AsQueryable();

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();

        }
        public async virtual Task<Entity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }


        public IEnumerable<Entity> SearchBy(Expression<Func<Entity, bool>> lambdaCondition)
        {
            return _dbContext.Set<Entity>().Where(lambdaCondition);
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() >= 0 ? true : false;
        }

    }
}
