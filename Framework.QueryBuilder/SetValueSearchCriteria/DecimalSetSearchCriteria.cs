namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System.Collections.Generic;
    using SetSearchTypes;
    using SingleValueSearchCriteria;
    using SetSearchCriteria;

    public class DecimalSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<decimal>, DecimalSetSearchType> where TSearchableObject : class, IFilterable
    {
        public DecimalSetSearchCriteria(string searchPropertyName, IEnumerable<decimal> value, DecimalSetSearchType type)
        {
            SearchCriteria = new DecimalSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
