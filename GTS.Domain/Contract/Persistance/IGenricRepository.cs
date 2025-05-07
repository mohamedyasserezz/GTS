using GTS.Domain.Contract;

namespace GTS.TaskManagement.Domain.Contract.Persistance
{
    public interface IGenricRepository<TEntity>
    where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false, CancellationToken cancellationToken = default);
        public Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> specifications, bool withTracking = false, CancellationToken cancellationToken = default);
        public Task<int> GetCountWithSpecAsync(ISpecification<TEntity> specifications, bool withTracking = false, CancellationToken cancellationToken = default);

        public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<TEntity?> GetWithSpecAsync(ISpecification<TEntity> specifications);
        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);

    }
}
