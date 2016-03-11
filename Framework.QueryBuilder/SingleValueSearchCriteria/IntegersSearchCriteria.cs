namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchTypes;
    using System.Collections.Generic;
    using SetSearchCriteria;

    public class IntegersSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<int>, IntegersSearchType> where TSearchableObject : class, IFilterable
    {
        public IntegersSearchCriteria(string searchPropertyName, IEnumerable<int> value, IntegersSearchType type)
        {
            SearchCriteria = new IntegerSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
