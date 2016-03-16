namespace Framework.QueryBuilder.SetSearchCriteria
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using SearchCriteria;
    using SetSearchTypes;
    using SetValueSearchCriteria;
    using SingleValueSearchCriteria;

    public class StringSetSearchCriteria : SearchCriteriaBase<IEnumerable<string>, StringSetSearchType>
    {
        public StringSetSearchCriteria()
        {
        }

        public StringSetSearchCriteria(IEnumerable<string> value, StringSetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<IEnumerable<string>, StringSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<string> value, StringSetSearchType type)
        {
            return new StringSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<string>, StringSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<string> value, StringSetSearchType type)
        {
            return new StringSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if (SearchType == StringSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case StringSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case StringSetSearchType.Between:
                    return $"[{columnName}] BETWEEN ({parametersString})";
                case StringSetSearchType.NotIn:
                    return $"[{columnName}] NOT IN @p{parameterIndex}";
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
