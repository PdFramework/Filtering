namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;

    public class DecimalSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, decimal, DecimalSearchType> where TSearchableObject : class, IFilterable
    {
        public DecimalSearchCriteria(string searchPropertyName, decimal value, DecimalSearchType type)
        {
            SearchCriteria = new DecimalSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
