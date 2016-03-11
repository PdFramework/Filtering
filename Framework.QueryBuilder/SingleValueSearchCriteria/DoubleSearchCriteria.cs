namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;

    public class DoubleSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, double, DoubleSearchType> where TSearchableObject : class, IFilterable
    {
        public DoubleSearchCriteria(string searchPropertyName, double value, DoubleSearchType type)
        {
            SearchCriteria = new DoubleSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
