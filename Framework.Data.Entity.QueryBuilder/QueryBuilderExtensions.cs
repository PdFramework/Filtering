namespace Framework.QueryBuilder.Data.Entity
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;
    using SearchTypes;
    using SetSearchCriteria;
    using SingleValueSearchCriteria;

    internal static class QueryBuilderExtensions
    {
        internal static int? GetTotalNumberOfResults<TSearchable>(this QueryBuilder queryBuilder, SearchCriteriaBuilder<TSearchable> searchCriteria, IObjectContextAdapter dbContext) where TSearchable : class, IFilterable
        {
            if (searchCriteria.PageIndex == 0) return null;

            var countQueryBuilder = queryBuilder.CreateCountQueryBuilder(dbContext, searchCriteria);

            return dbContext.ObjectContext.ExecuteStoreQuery<int>(countQueryBuilder.StringBuilder.ToString(), countQueryBuilder.QueryParameters).First();
        }

        internal static async Task<int?> GetTotalNumberOfResultsAsync<TSearchable>(this QueryBuilder queryBuilder, SearchCriteriaBuilder<TSearchable> searchCriteria, IObjectContextAdapter dbContext) where TSearchable : class, IFilterable
        {
            if (searchCriteria.PageIndex == 0) return null;

            var countQueryBuilder = queryBuilder.CreateCountQueryBuilder(dbContext, searchCriteria);

            return (await dbContext.ObjectContext.ExecuteStoreQueryAsync<int>(countQueryBuilder.StringBuilder.ToString(), countQueryBuilder.QueryParameters)).First();
        }

        internal static QueryBuilder CreateQueryBuilder<TSearchable>(IObjectContextAdapter dbContext, SearchCriteriaBuilder<TSearchable> searchCriteria) where TSearchable : class, IFilterable
        {
            var queryBuilder = new QueryBuilder
            {
                DbObjectMapper = dbContext.MapDbProperties<TSearchable>()
            };

            queryBuilder.CreateSelect()
                .CreateFrom()
                .CreateWhere(dbContext, searchCriteria)
                .CreateOrderBy(searchCriteria)
                .CreateOffset(searchCriteria);

            return queryBuilder;
        }

        internal static QueryBuilder CreateCountQueryBuilder<TSearchable>(this QueryBuilder queryBuilder, IObjectContextAdapter dbContext, SearchCriteriaBuilder<TSearchable> searchCriteria) where TSearchable : class, IFilterable
        {
            var countQueryBuilder = new QueryBuilder
            {
                DbObjectMapper = queryBuilder.DbObjectMapper
            };

            countQueryBuilder.CreateCountSelect()
                             .CreateFrom()
                             .CreateWhere(dbContext, searchCriteria);

            return countQueryBuilder;
        }

        internal static QueryBuilder CreateSelect(this QueryBuilder queryBuilder)
        {
            var sqlProperties = string.Join(", ", queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper.Select(propertyToColumnNameMap => $"[{propertyToColumnNameMap.Value}] AS [{propertyToColumnNameMap.Key}]"));
            queryBuilder.StringBuilder
                        .SafeSqlAppend("SELECT")
                        .SafeSqlAppend(sqlProperties);
            return queryBuilder;
        }

        internal static QueryBuilder CreateCountSelect(this QueryBuilder queryBuilder)
        {
            queryBuilder.StringBuilder
                        .SafeSqlAppend("SELECT  COUNT(1)");
            return queryBuilder;
        }

        internal static QueryBuilder CreateFrom(this QueryBuilder queryBuilder)
        {
            queryBuilder.StringBuilder
                        .SafeSqlAppend("FROM")
                        .SafeSqlAppend($"[{queryBuilder.DbObjectMapper.DbSchema}].[{queryBuilder.DbObjectMapper.DbTableName}]");
            return queryBuilder;
        }

        internal static QueryBuilder CreateOrderBy<TSearchable>(this QueryBuilder queryBuilder, SearchCriteriaBuilder<TSearchable> searchCriteria) where TSearchable : class, IFilterable
        {
            queryBuilder.StringBuilder
                        .SafeSqlAppend("ORDER BY");

            if (searchCriteria.SortCriterium.Any())
            {
                foreach (var sortCriteria in searchCriteria.SortCriterium)
                {
                    var sortDirectionString = sortCriteria.SortType == SortType.Ascending ? "ASC" : "DESC";

                    queryBuilder.StringBuilder
                                .SafeSqlAppend($"[{queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper[sortCriteria.SortPropertyName]}] {sortDirectionString}");

                    if (searchCriteria.SortCriterium.Count > 1 && searchCriteria.SortCriterium.Last() != sortCriteria)
                    {
                        queryBuilder.StringBuilder.Append(",");
                    }
                }
            }
            else
            {
                queryBuilder.StringBuilder
                            .SafeSqlAppend($"[{queryBuilder.DbObjectMapper.PrimaryKeyPropertyName}]");
            }

            return queryBuilder;
        }

        internal static QueryBuilder CreateOffset<TSearchable>(this QueryBuilder queryBuilder, SearchCriteriaBuilder<TSearchable> searchCriteria) where TSearchable : class, IFilterable
        {
            if (!searchCriteria.ReturnAllResults)
            {
                queryBuilder.StringBuilder
                            .SafeSqlAppend($"OFFSET {searchCriteria.PageIndex * searchCriteria.PageSize} ROWS FETCH NEXT {searchCriteria.PageSize} ROWS ONLY");
            }

            return queryBuilder;
        }

        internal static QueryBuilder CreateWhere<TSearchable>(this QueryBuilder queryBuilder, IObjectContextAdapter dbContext, SearchCriteriaBuilder<TSearchable> searchCriteria) where TSearchable : class, IFilterable
        {
            var tmpQueryBuilder = new QueryBuilder
                                  {
                                      DbObjectMapper = dbContext.MapDbProperties<TSearchable>()
                                  }.BuildWhere(searchCriteria);
            if (tmpQueryBuilder.StringBuilder.Length > 0)
            {
                queryBuilder.StringBuilder
                            .SafeSqlAppend("WHERE")
                            .SafeSqlAppend(tmpQueryBuilder.StringBuilder);
                queryBuilder.QueryParameters = tmpQueryBuilder.QueryParameters;
            }
            return queryBuilder;
        }

        internal static QueryBuilder BuildWhere<TSearchable>(this QueryBuilder queryBuilder, SearchCriteriaBuilder<TSearchable> searchCriteria) where TSearchable : class, IFilterable
        {
            var compoundSearchCriteria = searchCriteria as CompoundSearchCriteria<TSearchable>;
            if (compoundSearchCriteria != null)
            {
                queryBuilder.BuildWhere(compoundSearchCriteria);
            }
            else
            {
                var singleValueSearchCriteria = searchCriteria as SingleValueSearchCriteriaBase<TSearchable>;
                if (singleValueSearchCriteria != null)
                {
                    var searchCriteriaBase = singleValueSearchCriteria.SearchCriteria;
                    var whereClause = searchCriteriaBase.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    var sqlParameters = searchCriteriaBase.CreateParameters(queryBuilder.QueryParameters.Count);

                    if (!string.IsNullOrWhiteSpace(whereClause))
                    {
                        queryBuilder.StringBuilder.SafeSqlAppend(whereClause);
                        queryBuilder.QueryParameters.AddRange(sqlParameters);
                    }
                }

                var setSearchCriteria = searchCriteria as SetSearchCriteriaBase<TSearchable>;
                if (setSearchCriteria != null)
                {
                    var searchCriteriaBase = setSearchCriteria.SearchCriteria;
                    var whereClause = searchCriteriaBase.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    var sqlParameters = searchCriteriaBase.CreateParameters(queryBuilder.QueryParameters.Count);

                    if (!string.IsNullOrWhiteSpace(whereClause))
                    {
                        queryBuilder.StringBuilder.SafeSqlAppend(whereClause);
                        queryBuilder.QueryParameters.AddRange(sqlParameters);
                    }
                }

                //TODO: char, byte
            }

            return queryBuilder;
        }

        internal static QueryBuilder BuildWhere<TSearchable>(this QueryBuilder queryBuilder, CompoundSearchCriteria<TSearchable> searchCriteria) where TSearchable : class, IFilterable
        {
            queryBuilder.StringBuilder.SafeSqlAppend("(");
            queryBuilder.BuildWhere(searchCriteria.SearchCriterium[0]);

            for (var i = 0; i < searchCriteria.SearchCombinationTypes.Count; i++)
            {
                string comboType;
                switch (searchCriteria.SearchCombinationTypes[i])
                {
                    case CompoundSearchType.And:
                        comboType = "AND";
                        break;
                    case CompoundSearchType.Or:
                        comboType = "OR";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                queryBuilder.StringBuilder.SafeSqlAppend(comboType);
                queryBuilder.BuildWhere(searchCriteria.SearchCriterium[i + 1]);
            }

            queryBuilder.StringBuilder.SafeSqlAppend(")");
            return queryBuilder;
        }
    }
}
