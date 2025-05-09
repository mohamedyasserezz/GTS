using GTS.TaskManagement.Domain.Contract;
using GTS.TaskManagement.Domain.Contract.Persistance;
using GTS.TaskManagement.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace GTS.Persistance.Data.GenericRepository
{
    internal class GenericRepository<TEntity>(ApplicationDbContext _dbContext) : IGenricRepository<TEntity>
        where TEntity : class
    {

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false, CancellationToken cancellationToken = default)
        {
            return withTracking ?
                await _dbContext.Set<TEntity>().ToListAsync(cancellationToken) :
                await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public async Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

            return await _dbContext.SaveChangesAsync(cancellationToken) > 0;    
        }

        public bool Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);

            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(TEntity entity)
        {
            _dbContext.Remove(entity);

            return _dbContext.SaveChanges() > 0;
        }

        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> specifications, bool withTracking = false, CancellationToken cancellationToken = default)
        => await ApplySpecification(specifications).ToListAsync();

        public async Task<int> GetCountWithSpecAsync(ISpecification<TEntity> specifications, bool withTracking = false, CancellationToken cancellationToken = default)
        => await ApplySpecification(specifications).CountAsync();

        public async Task<TEntity?> GetWithSpecAsync(ISpecification<TEntity> specifications)
        => await ApplySpecification(specifications).FirstOrDefaultAsync();

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specifications)
          => SpecificationEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>(), specifications);
    }
}
