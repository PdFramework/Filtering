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

    public class DoubleSetSearchCriteria : SearchCriteriaBase<IEnumerable<double>, DoubleSetSearchType>
    {
        public DoubleSetSearchCriteria()
        {
        }

        public DoubleSetSearchCriteria(IEnumerable<double> value, DoubleSetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<IEnumerable<double>, DoubleSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<double> value, DoubleSetSearchType type)
        {
            return new DoubleSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<double>, DoubleSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<double> value, DoubleSetSearchType type)
        {
            return new DoubleSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if (SearchType == DoubleSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case DoubleSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case DoubleSetSearchType.Between:
                    return $"[{columnName}] BETWEEN ({parametersString})";
                case DoubleSetSearchType.NotIn:
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
