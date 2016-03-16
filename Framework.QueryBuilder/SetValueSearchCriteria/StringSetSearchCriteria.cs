namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System.Collections.Generic;
    using SetSearchCriteria;
    using SetSearchTypes;
    using SingleValueSearchCriteria;

    public class StringSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<string>, StringSetSearchType> where TSearchableObject : class, IFilterable
    {
        public StringSetSearchCriteria(string searchPropertyName, IEnumerable<string> value, StringSetSearchType type)
        {
            SearchCriteria = new StringSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
