namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using SingleValueSearchCriteria;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class IntegerSearchCriteria : SearchCriteriaBase<int, IntegerSearchType>
    {
        public IntegerSearchCriteria()
        {
        }

        public IntegerSearchCriteria(int value, IntegerSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<int, IntegerSearchType> CreateSearchCriteriaBase(string searchPropertyName, int value, IntegerSearchType type)
        {
            return new IntegerSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, int, IntegerSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, int value, IntegerSearchType type)
        {
            return new IntegerSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case IntegerSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case IntegerSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case IntegerSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case IntegerSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case IntegerSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case IntegerSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(SearchType), SearchType, null);
            }
        }

        internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
        {
            return new [] { new SqlParameter($"p{startingParameterIndex}", SearchValue) };
        }
    }
}
