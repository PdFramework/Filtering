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

    public class FloatSetSearchCriteria : SearchCriteriaBase<IEnumerable<float>, FloatSetSearchType>
    {
        public FloatSetSearchCriteria()
        {
        }

        public FloatSetSearchCriteria(IEnumerable<float> value, FloatSetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<IEnumerable<float>, FloatSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<float> value, FloatSetSearchType type)
        {
            return new FloatSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<float>, FloatSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<float> value, FloatSetSearchType type)
        {
            return new FloatSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if (SearchType == FloatSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = SearchType == FloatSetSearchType.Between ? $"@p{parameterIndex++} AND @p{parameterIndex++}" : string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case FloatSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case FloatSetSearchType.Between:
                    return $"[{columnName}] BETWEEN {parametersString}";
                case FloatSetSearchType.NotIn:
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
