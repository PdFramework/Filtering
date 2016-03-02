namespace Framework.QueryBuilder.Data.Entity
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using SearchTypes;

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
                string whereClause = null;
                SqlParameter sqlParameter = null;
                
                var integerSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, int, IntegerSearchType>;
                if (integerSearchCriteria != null)
                {
                    whereClause = integerSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", integerSearchCriteria.SearchCriteria.SearchValue);
                }

                var shortSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, short, ShortSearchType>;
                if (shortSearchCriteria != null)
                {
                    whereClause = shortSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", shortSearchCriteria.SearchCriteria.SearchValue);
                }

                var longSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, long, LongSearchType>;
                if (longSearchCriteria != null)
                {
                    whereClause = longSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", longSearchCriteria.SearchCriteria.SearchValue);
                }

                var stringSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, string, StringSearchType>;
                if (stringSearchCriteria != null)
                {
                    whereClause = stringSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", stringSearchCriteria.SearchCriteria.SearchValue);
                }

                var booleanSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, bool, BooleanSearchType>;
                if (booleanSearchCriteria != null)
                {
                    whereClause = booleanSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", booleanSearchCriteria.SearchCriteria.SearchValue);
                }

                var dateTimeSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, DateTime, DateTimeSearchType>;
                if (dateTimeSearchCriteria != null)
                {
                    whereClause = dateTimeSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", dateTimeSearchCriteria.SearchCriteria.SearchValue);
                }

                var dateTimeOffsetSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, DateTimeOffset, DateTimeOffsetSearchType>;
                if (dateTimeOffsetSearchCriteria != null)
                {
                    whereClause = dateTimeOffsetSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", dateTimeOffsetSearchCriteria.SearchCriteria.SearchValue);
                }

                var decimalSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, decimal, DecimalSearchType>;
                if (decimalSearchCriteria != null)
                {
                    whereClause = decimalSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", decimalSearchCriteria.SearchCriteria.SearchValue);
                }

                var doubleSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, double, DoubleSearchType>;
                if (doubleSearchCriteria != null)
                {
                    whereClause = doubleSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", doubleSearchCriteria.SearchCriteria.SearchValue);
                }

                var floatSearchCriteria = searchCriteria as SingleSearchCriteria<TSearchable, float, FloatSearchType>;
                if (floatSearchCriteria != null)
                {
                    whereClause = floatSearchCriteria.CreateWhere(queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper, queryBuilder.QueryParameters.Count);
                    sqlParameter = new SqlParameter($"p{queryBuilder.QueryParameters.Count}", floatSearchCriteria.SearchCriteria.SearchValue);
                }

                //TODO: char, byte

                if (!string.IsNullOrWhiteSpace(whereClause))
                {
                    queryBuilder.QueryParameters.Add(sqlParameter);
                    queryBuilder.StringBuilder.SafeSqlAppend(whereClause);
                }
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
