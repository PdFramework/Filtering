namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;

    public class BooleanSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, bool, BooleanSearchType> where TSearchableObject : class, IFilterable
    {
        public BooleanSearchCriteria(string searchPropertyName, bool value, BooleanSearchType type)
        {
            SearchCriteria = new BooleanSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
