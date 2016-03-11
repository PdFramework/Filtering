namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;

    public class IntegerSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, int, IntegerSearchType> where TSearchableObject : class, IFilterable
    {
        public IntegerSearchCriteria(string searchPropertyName, int value, IntegerSearchType type)
        {
            SearchCriteria = new IntegerSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
