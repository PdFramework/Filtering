namespace Framework.QueryBuilder.SearchCriteria
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SearchTypes;
    using SingleValueSearchCriteria;

    public class DateTimeOffsetSearchCriteria : SearchCriteriaBase<DateTimeOffset, DateTimeOffsetSearchType>
    {
        public DateTimeOffsetSearchCriteria()
        {
        }

        public DateTimeOffsetSearchCriteria(DateTimeOffset value, DateTimeOffsetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<DateTimeOffset, DateTimeOffsetSearchType> CreateSearchCriteriaBase(string searchPropertyName, DateTimeOffset value, DateTimeOffsetSearchType type)
        {
            return new DateTimeOffsetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, DateTimeOffset, DateTimeOffsetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, DateTimeOffset value, DateTimeOffsetSearchType type)
        {
            return new DateTimeOffsetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case DateTimeOffsetSearchType.Before:
                    return $"[{columnName}] < @p{parameterIndex}";
                case DateTimeOffsetSearchType.BeforeOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case DateTimeOffsetSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case DateTimeOffsetSearchType.AfterOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case DateTimeOffsetSearchType.After:
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
