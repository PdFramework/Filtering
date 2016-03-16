namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System.Collections.Generic;
    using SetSearchCriteria;
    using SetSearchTypes;
    using SingleValueSearchCriteria;

    public class LongSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<long>, LongSetSearchType> where TSearchableObject : class, IFilterable
    {
        public LongSetSearchCriteria(string searchPropertyName, IEnumerable<long> value, LongSetSearchType type)
        {
            SearchCriteria = new LongSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
