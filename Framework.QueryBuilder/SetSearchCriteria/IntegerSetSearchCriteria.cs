using Framework.QueryBuilder.SetSearchTypes;
using Framework.QueryBuilder.SetValueSearchCriteria;

namespace Framework.QueryBuilder.SetSearchCriteria
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using SearchCriteria;
    using SearchTypes;
    using SingleValueSearchCriteria;

    public class IntegerSetSearchCriteria : SearchCriteriaBase<IEnumerable<int>, IntegerSetSearchType>
    {
        public IntegerSetSearchCriteria()
        {
        }

        public IntegerSetSearchCriteria(IEnumerable<int> values, IntegerSetSearchType type)
        {
            SearchType = type;
            SearchValue = values;
        }

        public override SearchCriteriaBase<IEnumerable<int>, IntegerSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<int> value, IntegerSetSearchType type)
        {
            return new IntegerSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<int>, IntegerSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<int> value, IntegerSetSearchType type)
        {
            return new IntegerSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if(SearchType == IntegerSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case IntegerSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case IntegerSetSearchType.Between:
                    return $"[{columnName}] BETWEEN ({parametersString})";
                case IntegerSetSearchType.NotIn:
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
