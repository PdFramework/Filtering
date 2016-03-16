namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System.Collections.Generic;
    using SetSearchTypes;
    using SingleValueSearchCriteria;
    using SetSearchCriteria;

    public class DoubleSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<double>, DoubleSetSearchType> where TSearchableObject : class, IFilterable
    {
        public DoubleSetSearchCriteria(string searchPropertyName, IEnumerable<double> value, DoubleSetSearchType type)
        {
            SearchCriteria = new DoubleSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
