namespace Framework.QueryBuilder.SetSearchCriteria
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using SearchCriteria;
    using SearchTypes;
    using SingleValueSearchCriteria;

    public class IntegerSetSearchCriteria : SearchCriteriaBase<IEnumerable<int>, IntegersSearchType>
    {
        public IntegerSetSearchCriteria()
        {
        }

        public IntegerSetSearchCriteria(IEnumerable<int> values, IntegersSearchType type)
        {
            SearchType = type;
            SearchValue = values;
        }

        public override SearchCriteriaBase<IEnumerable<int>, IntegersSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<int> value, IntegersSearchType type)
        {
            return new IntegerSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<int>, IntegersSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<int> value, IntegersSearchType type)
        {
            return new IntegersSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if(SearchType == IntegersSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case IntegersSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case IntegersSearchType.Between:
                    return $"[{columnName}] BETWEEN ({parametersString})";
                case IntegersSearchType.NotIn:
                    return $"[{columnName}] NOT IN @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(SearchType), SearchType, null);
            }
        }

        internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
        {
            return SearchValue.Select(value => new SqlParameter($"p{startingParameterIndex++}", value));
        }
    }
}
