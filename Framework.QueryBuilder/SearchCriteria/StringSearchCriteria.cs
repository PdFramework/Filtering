namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SingleValueSearchCriteria;
    using System;

    public class StringSearchCriteria : SearchCriteriaBase<string, StringSearchType>
    {
        public StringSearchCriteria()
        {
        }

        public StringSearchCriteria(string value, StringSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<string, StringSearchType> CreateSearchCriteriaBase(string searchPropertyName, string value, StringSearchType type)
        {
            return new StringSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, string, StringSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, string value, StringSearchType type)
        {
            return new StringSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];

            switch (SearchType)
            {
                case StringSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case StringSearchType.DoesNotEqual:
                    return $"[{columnName}] != @p{parameterIndex}";
                case StringSearchType.StartsWith:
                    return $"[{columnName}] LIKE @p{parameterIndex} + '%'";
                case StringSearchType.EndsWith:
                    return $"[{columnName}] LIKE '%' + @p{parameterIndex}";
                case StringSearchType.Contains:
                    return $"[{columnName}] LIKE '%' + @p{parameterIndex} + '%'";
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
