namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;

    public class StringSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, string, StringSearchType> where TSearchableObject : class, IFilterable
    {
        public StringSearchCriteria(string searchPropertyName, string value, StringSearchType type)
        {
            SearchCriteria = new StringSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
