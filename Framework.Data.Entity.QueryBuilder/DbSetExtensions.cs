namespace Framework.QueryBuilder.Data.Entity
{
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Framework.QueryBuilder;

    public static class DbSetExtensions
    {
        public static SearchResult<TSearchable> Search<TSearchable>(this DbSet<TSearchable> dbSet, DbContext dbContext, CompoundSearchCriteria<TSearchable> searchCriteria) where TSearchable : class
        {
            var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(dbContext, searchCriteria);

            return new SearchResult<TSearchable>
            {
                TotalNumberOfResults = queryBuilder.GetTotalNumberOfResults(searchCriteria, dbContext),
                Results = dbSet.SqlQuery(queryBuilder.StringBuilder.ToString(), queryBuilder.QueryParameters).ToList()
            };
        }

        public static async Task<SearchResult<TSearchable>> SearchAsync<TSearchable>(this DbSet<TSearchable> dbSet, DbContext dbContext, CompoundSearchCriteria<TSearchable> searchCriteria) where TSearchable : class
        {
            var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(dbContext, searchCriteria);

            return new SearchResult<TSearchable>
            {
                TotalNumberOfResults = await queryBuilder.GetTotalNumberOfResultsAsync(searchCriteria, dbContext),
                Results = await dbSet.SqlQuery(queryBuilder.StringBuilder.ToString(), queryBuilder.QueryParameters).ToListAsync()
            };
        }
    }
}
