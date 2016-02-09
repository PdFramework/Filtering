namespace Framework.Data.Entity.QueryBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using Framework.QueryBuilder;
    using Framework.QueryBuilder.SearchTypes;

    public static class EntityFrameworkExtensions
    {
        public static IEnumerable<TSearchable> Search<TSearchable>(this DbSet<TSearchable> dbSet, DbContext dbContext, CompoundSearchCriteria<TSearchable> searchCriteria) where TSearchable : class
        {
            var queryBuilder = new QueryBuilder
            {
                DbObjectMapper = dbContext.MapDbProperties<TSearchable>(),
                StringBuilder = new StringBuilder()
            };

            queryBuilder = queryBuilder.CreateSelect()
                                       .CreateFrom();

            throw new NotImplementedException();
        }

        private static QueryBuilder CreateSelect(this QueryBuilder queryBuilder)
        {
            var sqlProperties = string.Join(", ", queryBuilder.DbObjectMapper.ObjectPropertyColumnNameMapper.Select(propertyToColumnNameMap => $"[{propertyToColumnNameMap.Value}] AS [{propertyToColumnNameMap.Key}]"));
            queryBuilder.StringBuilder = queryBuilder.StringBuilder.SafeSqlAppend($"SELECT {sqlProperties}");
            return queryBuilder;
        }

        private static QueryBuilder CreateFrom(this QueryBuilder queryBuilder)
        {
            queryBuilder.StringBuilder.SafeSqlAppend($"FROM [{queryBuilder.DbObjectMapper.DbSchema}].[{queryBuilder.DbObjectMapper.DbTableName}]");
            return queryBuilder;
        }

        private static DynamicQuery CreateWhere<TSearchable>(this QueryBuilder queryBuilder, CompoundSearchCriteria<TSearchable> searchCriteria) where TSearchable : class
        {
            for (var i = 0; i < searchCriteria.SearchCombinationTypes.Count; i++)
            {
                var compoundSearchCriteria = searchCriteria.SearchCriterium[i] as CompoundSearchCriteria<TSearchable>;
                if (compoundSearchCriteria != null)
                {

                }
                else
                {
                    var integerSearchCriteria = searchCriteria.SearchCriterium[i] as SingleSearchCriteria<TSearchable, int, IntegerSearchType>;
                    if (integerSearchCriteria != null)
                    {
                        //var whereClause = CreateWhereClause(propertyToColumnNameMap.Value, parameterIndex, stringSearchCriteria.SearchType);
                        //if (!string.IsNullOrWhiteSpace(whereClause))
                        //{
                        //    var param = new SqlParameter($"p{parameterIndex}", integerSearchCriteria.SearchCriteria.SearchValue);
                        //}
                    }
                }
            }

            throw new NotImplementedException();
            //var tEntitySearchCriteriaProperties = typeof(TEntitySearchCriteria).GetProperties();

            //var parameters = new List<object>();
            //var parameterIndex = -1;
            //var tmpStringBuilder = new StringBuilder();
            //var sortCriteria = new List<SortCriteria>();

            //foreach (var propertyToColumnNameMap in _objectPropertyToColumnNameMapper)
            //{
            //    var prop = tEntitySearchCriteriaProperties.FirstOrDefault(p => p.Name.Equals(propertyToColumnNameMap.Key, StringComparison.OrdinalIgnoreCase));

            //    var propertySearchCriteria = prop?.GetValue(entitySearchCriteria);

            //    if (propertySearchCriteria is SortCriteriaBase)
            //    {
            //        sortCriteria.Add(new SortCriteria { SortColumnName = propertyToColumnNameMap.Value, SortCriteriaBase = propertySearchCriteria as SortCriteriaBase });
            //        parameterIndex++;

            //        if (propertySearchCriteria is StringSearchCriteria)
            //        {
            //            var stringSearchCriteria = propertySearchCriteria as StringSearchCriteria;
            //            var whereClause = CreateWhereClause(propertyToColumnNameMap.Value, parameterIndex, stringSearchCriteria.SearchType);
            //            if (!string.IsNullOrWhiteSpace(whereClause))
            //            {
            //                if (tmpStringBuilder.Length > 0)
            //                {
            //                    tmpStringBuilder.Append(" AND ");
            //                }
            //                tmpStringBuilder.Append(whereClause);
            //                parameters.Add(new SqlParameter($"p{parameterIndex}", stringSearchCriteria.Value));
            //            }
            //        }

            //        if (propertySearchCriteria is IntegerSearchCriteria)
            //        {
            //            var integerSearchCriteria = propertySearchCriteria as IntegerSearchCriteria;
            //            var whereClause = CreateWhereClause(propertyToColumnNameMap.Value, parameterIndex, integerSearchCriteria.SearchType);
            //            if (!string.IsNullOrWhiteSpace(whereClause))
            //            {
            //                if (tmpStringBuilder.Length > 0)
            //                {
            //                    tmpStringBuilder.Append(" AND ");
            //                }
            //                tmpStringBuilder.Append(whereClause);
            //                parameters.Add(new SqlParameter($"p{parameterIndex}", integerSearchCriteria.Value));
            //            }
            //        }

            //        if (propertySearchCriteria is DecimalSearchCriteria)
            //        {
            //            var decimalSearchCriteria = propertySearchCriteria as DecimalSearchCriteria;
            //            var whereClause = CreateWhereClause(propertyToColumnNameMap.Value, parameterIndex, decimalSearchCriteria.SearchType);
            //            if (!string.IsNullOrWhiteSpace(whereClause))
            //            {
            //                if (tmpStringBuilder.Length > 0)
            //                {
            //                    tmpStringBuilder.Append(" AND ");
            //                }
            //                tmpStringBuilder.Append(whereClause);
            //                parameters.Add(new SqlParameter($"p{parameterIndex}", decimalSearchCriteria.Value));
            //            }
            //        }

            //        if (propertySearchCriteria is DateTimeSearchCriteria)
            //        {
            //            var dateTimeSearchCriteria = propertySearchCriteria as DateTimeSearchCriteria;
            //            var whereClause = CreateWhereClause(propertyToColumnNameMap.Value, parameterIndex, dateTimeSearchCriteria.SearchType);
            //            if (!string.IsNullOrWhiteSpace(whereClause))
            //            {
            //                if (tmpStringBuilder.Length > 0)
            //                {
            //                    tmpStringBuilder.Append(" AND ");
            //                }
            //                tmpStringBuilder.Append(whereClause);
            //                parameters.Add(new SqlParameter($"p{parameterIndex}", dateTimeSearchCriteria.Value));
            //            }
            //        }

            //        if (propertySearchCriteria is DateTimeOffsetSearchCriteria)
            //        {
            //            var dateTimeOffsetSearchCriteria = propertySearchCriteria as DateTimeOffsetSearchCriteria;
            //            var whereClause = CreateWhereClause(propertyToColumnNameMap.Value, parameterIndex, dateTimeOffsetSearchCriteria.SearchType);
            //            if (!string.IsNullOrWhiteSpace(whereClause))
            //            {
            //                if (tmpStringBuilder.Length > 0)
            //                {
            //                    tmpStringBuilder.Append(" AND ");
            //                }
            //                tmpStringBuilder.Append(whereClause);
            //                parameters.Add(new SqlParameter($"p{parameterIndex}", dateTimeOffsetSearchCriteria.Value));
            //            }
            //        }

            //        if (propertySearchCriteria is BooleanSearchCriteria)
            //        {
            //            var booleanSearchCriteria = propertySearchCriteria as BooleanSearchCriteria;
            //            var whereClause = CreateWhereClause(propertyToColumnNameMap.Value, parameterIndex, booleanSearchCriteria.SearchType);
            //            if (!string.IsNullOrWhiteSpace(whereClause))
            //            {
            //                if (tmpStringBuilder.Length > 0)
            //                {
            //                    tmpStringBuilder.Append(" AND ");
            //                }
            //                tmpStringBuilder.Append(whereClause);
            //                parameters.Add(new SqlParameter($"p{parameterIndex}", booleanSearchCriteria.Value));
            //            }
            //        }
            //    }
            //}

            //if (tmpStringBuilder.Length > 0)
            //{
            //    stringBuilder.Append(" WHERE ").Append(tmpStringBuilder);
            //}

            //var filteredSortCriteria = sortCriteria.Where(criteria => criteria.SortCriteriaBase.SortType != SortType.None);
            //if (filteredSortCriteria.Any())
            //{
            //    var orderedSortCriteria = filteredSortCriteria.OrderBy(criteria => criteria.SortCriteriaBase.SortOrder);
            //    stringBuilder.Append(" ORDER BY ");
            //    foreach (var sortCriterium in orderedSortCriteria)
            //    {
            //        var sortDirectionString = sortCriterium.SortCriteriaBase.SortType == SortType.Ascending ? "ASC" : "DESC";

            //        stringBuilder.Append($"{sortCriterium.SortColumnName} {sortDirectionString} ");

            //        if (orderedSortCriteria.Count() > 1 && orderedSortCriteria.Last() != sortCriterium)
            //        {
            //            stringBuilder.Append(",");
            //        }
            //    }
            //}

            //return new DynamicQuery
            //{
            //    ParameterizedQuery = stringBuilder,
            //    Parameters = parameters.ToArray()
            //};
        }

        private static StringBuilder SafeSqlAppend(this StringBuilder stringBuilder, string stringToAppend)
        {
            if (stringBuilder.Length > 0)
            {
                stringBuilder.Append(" ");
            }

            stringBuilder.Append(stringToAppend);

            return stringBuilder;
        }

        private static DbObjectMapper MapDbProperties<TSearchable>(this IObjectContextAdapter dbContext) where TSearchable : class
        {
            var dbObjectMapper = new DbObjectMapper();
            var objectContext = dbContext.ObjectContext;
            var objectSet = objectContext.CreateObjectSet<TSearchable>();
            dbObjectMapper.PrimaryKeyPropertyName = objectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).First();
            var traceString = objectSet.ToTraceString();
            dbObjectMapper.ObjectPropertyColumnNameMapper = traceString.MapObjectPropertiesToColumnNames();
            dbObjectMapper.DbSchema = "dbo";
            dbObjectMapper.DbTableName = traceString.MapObjectToTableName();
            return dbObjectMapper;
        }

        private static IDictionary<string, string> MapObjectPropertiesToColumnNames(this string sqlClause)
        {
            var fromClauseStartIndex = sqlClause.IndexOf("FROM", StringComparison.OrdinalIgnoreCase);
            var selectClause = sqlClause.Substring(0, fromClauseStartIndex).Trim();
            var selectClauseSegments = selectClause.Split(',');
            var tmpObjectPropertyToColumnNameMapper = new Dictionary<string, string>();
            foreach (var selectClauseSegment in selectClauseSegments)
            {
                var columnNameStartIndex = selectClauseSegment.IndexOf(".[") + ".[".Length;
                var columnNameEndIndex = selectClauseSegment.IndexOf(']', columnNameStartIndex);
                var columnName = selectClauseSegment.Substring(columnNameStartIndex, columnNameEndIndex - columnNameStartIndex);
                var objectProperyNameStartIndex = selectClauseSegment.IndexOf('[', columnNameEndIndex) + "[".Length;
                var objectProperyNameEndIndex = selectClauseSegment.IndexOf(']', objectProperyNameStartIndex);
                var objectPropertyName = selectClauseSegment.Substring(objectProperyNameStartIndex, objectProperyNameEndIndex - objectProperyNameStartIndex);
                tmpObjectPropertyToColumnNameMapper.Add(objectPropertyName, columnName);
            }

            return tmpObjectPropertyToColumnNameMapper;
        }

        private static string MapObjectToTableName(this string sqlClause)
        {
            var fromClauseStartIndex = sqlClause.IndexOf("FROM", StringComparison.OrdinalIgnoreCase);
            var fromClause = sqlClause.Substring(fromClauseStartIndex).Trim();
            var tableNameStartIndex = fromClause.IndexOf(".[") + ".[".Length;
            var tableNameEndIndex = fromClause.IndexOf(']', tableNameStartIndex);
            return fromClause.Substring(tableNameStartIndex, tableNameEndIndex - tableNameStartIndex);
        }
    }
}
