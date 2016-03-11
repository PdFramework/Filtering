namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SingleValueSearchCriteria;

    public class LongSearchCriteria : SearchCriteriaBase<long, LongSearchType>
    {
        public LongSearchCriteria()
        {
        }

        public LongSearchCriteria(long value, LongSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<long, LongSearchType> CreateSearchCriteriaBase(string searchPropertyName, long value, LongSearchType type)
        {
            return new LongSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, long, LongSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, long value, LongSearchType type)
        {
            return new LongSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case LongSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case LongSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case LongSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case LongSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case LongSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case LongSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
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
