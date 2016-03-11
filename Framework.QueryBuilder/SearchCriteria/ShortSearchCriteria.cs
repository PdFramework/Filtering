namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SingleValueSearchCriteria;
    using System;

    public class ShortSearchCriteria : SearchCriteriaBase<short, ShortSearchType>
    {
        public ShortSearchCriteria()
        {
        }

        public ShortSearchCriteria(short value, ShortSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<short, ShortSearchType> CreateSearchCriteriaBase(string searchPropertyName, short value, ShortSearchType type)
        {
            return new ShortSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, short, ShortSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, short value, ShortSearchType type)
        {
            return new ShortSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case ShortSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case ShortSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case ShortSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case ShortSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case ShortSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case ShortSearchType.DoesNotEqual:
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
