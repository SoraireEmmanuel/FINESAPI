using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Fines.BL.Data;
using System.Data.Entity.Migrations;

namespace Fines.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly FinesContext finesContext;

        public GenericRepository(FinesContext finesContext)
        {
            this.finesContext = finesContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            finesContext.Set<TEntity>().Remove(entity);
            await finesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await finesContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await finesContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            finesContext.Set<TEntity>().Add(entity);
            await finesContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //finesContext.Entry(entity).State = EntityState.Modified;
            finesContext.Set<TEntity>().AddOrUpdate(entity);
            await finesContext.SaveChangesAsync();
            return entity;
        }
    }
}
