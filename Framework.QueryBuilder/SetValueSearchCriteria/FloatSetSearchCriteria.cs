namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System.Collections.Generic;
    using SetSearchTypes;
    using SingleValueSearchCriteria;
    using SetSearchCriteria;

    public class FloatSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<float>, FloatSetSearchType> where TSearchableObject : class, IFilterable
    {
        public FloatSetSearchCriteria(string searchPropertyName, IEnumerable<float> value, FloatSetSearchType type)
        {
            SearchCriteria = new FloatSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
