namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;

    public class ShortSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, short, ShortSearchType> where TSearchableObject : class, IFilterable
    {
        public ShortSearchCriteria(string searchPropertyName, short value, ShortSearchType type)
        {
            SearchCriteria = new ShortSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
