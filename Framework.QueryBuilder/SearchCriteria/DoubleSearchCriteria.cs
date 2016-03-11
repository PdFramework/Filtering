namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SingleValueSearchCriteria;
    using System;

    public class DoubleSearchCriteria : SearchCriteriaBase<double, DoubleSearchType>
    {
        public DoubleSearchCriteria()
        {
        }

        public DoubleSearchCriteria(double value, DoubleSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<double, DoubleSearchType> CreateSearchCriteriaBase(string searchPropertyName, double value, DoubleSearchType type)
        {
            return new DoubleSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, double, DoubleSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, double value, DoubleSearchType type)
        {
            return new DoubleSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case DoubleSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case DoubleSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case DoubleSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case DoubleSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case DoubleSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case DoubleSearchType.DoesNotEqual:
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
