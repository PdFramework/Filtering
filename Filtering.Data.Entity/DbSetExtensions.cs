namespace PeinearyDevelopment.Framework.Filtering.Data.Entity
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Infrastructure;
  using System.Linq;
  using System.Threading.Tasks;

  public static class DbSetExtensions
  {
    public static ResultSet<TFilterable> Search<TFilterable>(this DbSet<TFilterable> dbSet, IObjectContextAdapter dbContext, BaseFilterBuilder<TFilterable> filterCriteria) where TFilterable : class, IFilterable
    {
      if (dbSet == null) throw new ArgumentNullException(nameof(dbSet));

      var filter = new Filter<TFilterable>(dbContext, filterCriteria);

      return new ResultSet<TFilterable>(filter.GetTotalNumberOfResults(filterCriteria, dbContext), dbSet.SqlQuery(filter.SqlQueryStringBuilder.ToString(), filter.Parameters.ToArray()).ToList());
    }

    public static async Task<ResultSet<TFilterable>> SearchAsync<TFilterable>(this DbSet<TFilterable> dbSet, DbContext dbContext, BaseFilterBuilder<TFilterable> filterCriteria) where TFilterable : class, IFilterable
    {
      var filter = new Filter<TFilterable>(dbContext, filterCriteria);

      return new ResultSet<TFilterable>(await filter.GetTotalNumberOfResultsAsync(filterCriteria, dbContext), await dbSet.SqlQuery(filter.SqlQueryStringBuilder.ToString(), filter.Parameters.ToArray()).ToListAsync());
    }
  }
}
