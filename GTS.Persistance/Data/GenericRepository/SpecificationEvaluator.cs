using GTS.Domain.Contract;
using Microsoft.EntityFrameworkCore;

namespace GTS.Persistance.Data.GenericRepository
{
    internal static class SpecificationEvaluator<TEntity>
        where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecification<TEntity> specifications)
        {
            if (specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);

            if (specifications.OrderByDesc is not null)
                query = query.OrderByDescending(specifications.OrderByDesc);
            else if (specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);

            if (specifications.IsPaginationEnabled is true)
                query = query.Skip(specifications.Skip).Take(specifications.Take);

            if (specifications.Includes is not null)
            {
                query = specifications.Includes.Aggregate(query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            }

            return query;
        }
    }
}
