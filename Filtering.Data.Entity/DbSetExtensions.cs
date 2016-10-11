namespace PeinearyDevelopment.Framework.Filtering.Data.Entity
{
  using System;
  using System.Data.Entity;
  using System.Linq;
  using System.Threading.Tasks;

  public static class DbSetExtensions
  {
    public static ResultSet<TFilterable> Search<TFilterable>(this DbSet<TFilterable> dbSet, DbContext dbContext, BaseFilterBuilder<TFilterable> filterCriteria) where TFilterable : class, IFilterable
    {
      if (dbSet == null) throw new ArgumentNullException(nameof(dbSet));
      if (filterCriteria == null) throw new ArgumentNullException(nameof(filterCriteria));

      var filter = new Filter<TFilterable>(dbContext, filterCriteria);
      var results = dbSet.SqlQuery(filter.SqlQueryStringBuilder.ToString(), filter.Parameters.ToArray()).ToList();
      if (!filterCriteria.ReturnAllResults && filterCriteria.Take < results.Count)
      {
          return new ResultSet<TFilterable>(results.Take(filterCriteria.Take), filter.GetTotalNumberOfResults(filterCriteria, dbContext), true);
      }

      return new ResultSet<TFilterable>(results, filter.GetTotalNumberOfResults(filterCriteria, dbContext));
    }

    public static async Task<ResultSet<TFilterable>> SearchAsync<TFilterable>(this DbSet<TFilterable> dbSet, DbContext dbContext, BaseFilterBuilder<TFilterable> filterCriteria) where TFilterable : class, IFilterable
    {
      if (dbSet == null) throw new ArgumentNullException(nameof(dbSet));
      if (filterCriteria == null) throw new ArgumentNullException(nameof(filterCriteria));

      var filter = new Filter<TFilterable>(dbContext, filterCriteria);
      var results = await dbSet.SqlQuery(filter.SqlQueryStringBuilder.ToString(), filter.Parameters.ToArray()).ToListAsync();
      if (!filterCriteria.ReturnAllResults && filterCriteria.Take < results.Count)
      {
          return new ResultSet<TFilterable>(results.Take(filterCriteria.Take), filter.GetTotalNumberOfResults(filterCriteria, dbContext), true);
      }

      return new ResultSet<TFilterable>(results, await filter.GetTotalNumberOfResultsAsync(filterCriteria, dbContext));
    }
  }
}
