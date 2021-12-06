using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ItSkillHouse.Models.Repositories
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        Task AddAsync(TModel model);
        void Delete(TModel model);
        void Update(TModel model);
        Task<TModel> GetByIdAsync(Guid id);
        Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter);
        Task<List<TModel>> GetAsync();
        Task<int> CountAsync();
    }
}