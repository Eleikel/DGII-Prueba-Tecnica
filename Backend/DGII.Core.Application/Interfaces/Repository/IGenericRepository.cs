using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Core.Application.Interfaces.Repository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<Entity> CreateAsync(Entity entity);
        Task<IEnumerable<Entity>> CreateMultipleAsync(IEnumerable<Entity> entities);
        Task<bool> UpdateAsync(Entity entity, int id);
        Task<bool> DeleteAsync(Entity entity);
        Task<bool> DeleteMultipleAsync(IEnumerable<Entity> entities);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<IEnumerable<Entity>> GetAllWithIncludeAsync(List<string> properties);
        Task<Entity> GetByIdAsync(int id);
        Task<bool> Exist(Expression<Func<Entity, bool>> lambdaCondition);
        IEnumerable<Entity> SearchBy(Expression<Func<Entity, bool>> lambdaCondition);
        Task<bool> Save();
    }
}
