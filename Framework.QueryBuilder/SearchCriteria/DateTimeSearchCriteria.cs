namespace Framework.QueryBuilder.SearchCriteria
{
    using System;
    using SearchTypes;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SingleValueSearchCriteria;

    public class DateTimeSearchCriteria : SearchCriteriaBase<DateTime, DateTimeSearchType>
    {
        public DateTimeSearchCriteria()
        {
        }

        public DateTimeSearchCriteria(DateTime value, DateTimeSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<DateTime, DateTimeSearchType> CreateSearchCriteriaBase(string searchPropertyName, DateTime value, DateTimeSearchType type)
        {
            return new DateTimeSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, DateTime, DateTimeSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, DateTime value, DateTimeSearchType type)
        {
            return new DateTimeSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case DateTimeSearchType.Before:
                    return $"[{columnName}] < @p{parameterIndex}";
                case DateTimeSearchType.BeforeOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case DateTimeSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case DateTimeSearchType.AfterOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case DateTimeSearchType.After:
                    return $"[{columnName}] > @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(SearchType), SearchType, null);
            }
        }

        internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
        {
            return new[] { new SqlParameter($"p{startingParameterIndex}", SearchValue) };
        }
    }
}
