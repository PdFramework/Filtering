namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using SingleValueSearchCriteria;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class BooleanSearchCriteria : SearchCriteriaBase<bool, BooleanSearchType>
    {
        public BooleanSearchCriteria()
        {
        }

        public BooleanSearchCriteria(bool value, BooleanSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<bool, BooleanSearchType> CreateSearchCriteriaBase(string searchPropertyName, bool value, BooleanSearchType type)
        {
            return new BooleanSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, bool, BooleanSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, bool value, BooleanSearchType type)
        {
            return new BooleanSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case BooleanSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case BooleanSearchType.DoesNotEqual:
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
