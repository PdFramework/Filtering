namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SingleValueSearchCriteria;

    public class DecimalSearchCriteria : SearchCriteriaBase<decimal, DecimalSearchType>
    {
        public DecimalSearchCriteria()
        {
        }

        public DecimalSearchCriteria(decimal value, DecimalSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<decimal, DecimalSearchType> CreateSearchCriteriaBase(string searchPropertyName, decimal value, DecimalSearchType type)
        {
            return new DecimalSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, decimal, DecimalSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, decimal value, DecimalSearchType type)
        {
            return new DecimalSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case DecimalSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case DecimalSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case DecimalSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case DecimalSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case DecimalSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case DecimalSearchType.DoesNotEqual:
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
