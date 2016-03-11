namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;

    public class LongSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, long, LongSearchType> where TSearchableObject : class, IFilterable
    {
        public LongSearchCriteria(string searchPropertyName, long value, LongSearchType type)
        {
            SearchCriteria = new LongSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
