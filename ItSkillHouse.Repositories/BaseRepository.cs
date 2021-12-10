using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ItSkillHouse.Contracts;
using ItSkillHouse.Models;
using ItSkillHouse.Models.Repositories;
using ItSkillHouse.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ItSkillHouse.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        protected readonly SqlContext Context;
        
        protected BaseRepository(SqlContext context)
        {
            Context = context;
        }
        
        public async Task AddAsync(TModel model)
        {
            model.Created = DateTime.Now;
            await Context.Set<TModel>().AddAsync(model);
        }

        public void Delete(TModel model)
        {
            model.IsDeleted = true;
            Context.Set<TModel>().Update(model);
        }

        public void Update(TModel model)
        {
            model.Updated = DateTime.Now;
            Context.Set<TModel>().Update(model);
        }
        
        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter)
        {
            IQueryable<TModel> models = Context.Set<TModel>();
            models = FormatQuery(models);
            models = models.Where(model => model.IsDeleted == false);
            return await models.FirstOrDefaultAsync(filter);
        }
        
        public async Task<TModel> GetByIdAsync(int id)
        {
            IQueryable<TModel> models = Context.Set<TModel>();
            models = FormatQuery(models);
            models = models.Where(model => model.IsDeleted == false);
            return await models.FirstOrDefaultAsync(model => model.Id == id);
        }
        
        public async Task<List<TModel>> GetAsync()
        {
            IQueryable<TModel> models = Context.Set<TModel>();
            models = FormatQuery(models);
            models = models.Where(model => model.IsDeleted == false);
            return await models.ToListAsync();
        }
        
        public async Task<int> CountAsync()
        {
            IQueryable<TModel> models = Context.Set<TModel>();
            models = models.Where(model => model.IsDeleted == false);
            models = FormatQuery(models);
            return await models.CountAsync();
        }
        
        protected virtual IQueryable<TModel> FormatQuery(IQueryable<TModel> query)
        {
            return query;
        }
        
        protected IQueryable<TModel> ApplyPaging(IQueryable<TModel> query, Paging paging)
        {
            return paging.Take == 0 ? query : query.Skip(paging.Skip).Take(paging.Take);
        }
    }
}