namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;

    public class FloatSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, float, FloatSearchType> where TSearchableObject : class, IFilterable
    {
        public FloatSearchCriteria(string searchPropertyName, float value, FloatSearchType type)
        {
            SearchCriteria = new FloatSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
