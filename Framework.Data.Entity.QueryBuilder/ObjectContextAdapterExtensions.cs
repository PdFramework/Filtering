namespace Framework.QueryBuilder.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    internal static class ObjectContextAdapterExtensions
    {
        internal static DbObjectMapper MapDbProperties<TSearchable>(this IObjectContextAdapter dbContext) where TSearchable : class
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
