namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;
    using System.Collections.Generic;

    public class IntegersSearchCriteria : SearchCriteriaBase<IEnumerable<int>, IntegersSearchType>
    {
        public IntegersSearchCriteria()
        {
        }

        public IntegersSearchCriteria(IEnumerable<int> values, IntegersSearchType type)
        {
            SearchType = type;
            SearchValue = values;
        }
    }
}
