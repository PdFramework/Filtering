namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SingleValueSearchCriteria;

    public class FloatSearchCriteria : SearchCriteriaBase<float, FloatSearchType>
    {
        public FloatSearchCriteria()
        {
        }

        public FloatSearchCriteria(float value, FloatSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<float, FloatSearchType> CreateSearchCriteriaBase(string searchPropertyName, float value, FloatSearchType type)
        {
            return new FloatSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, float, FloatSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, float value, FloatSearchType type)
        {
            return new FloatSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case FloatSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case FloatSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case FloatSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case FloatSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case FloatSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case FloatSearchType.DoesNotEqual:
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
