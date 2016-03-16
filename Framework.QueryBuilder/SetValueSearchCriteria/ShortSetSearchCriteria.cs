namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System.Collections.Generic;
    using SetSearchCriteria;
    using SetSearchTypes;
    using SingleValueSearchCriteria;

    public class ShortSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<short>, ShortSetSearchType> where TSearchableObject : class, IFilterable
    {
        public ShortSetSearchCriteria(string searchPropertyName, IEnumerable<short> value, ShortSetSearchType type)
        {
            SearchCriteria = new ShortSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
