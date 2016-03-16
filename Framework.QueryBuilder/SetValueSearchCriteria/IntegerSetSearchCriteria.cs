namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System.Collections.Generic;
    using SetSearchCriteria;
    using SetSearchTypes;
    using SingleValueSearchCriteria;

    public class IntegerSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<int>, IntegerSetSearchType> where TSearchableObject : class, IFilterable
    {
        public IntegerSetSearchCriteria(string searchPropertyName, IEnumerable<int> value, IntegerSetSearchType type)
        {
            SearchCriteria = new IntegerSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
