namespace Framework.QueryBuilder
{
    using SearchCriteria;

    public class SingleSearchCriteria<TSearchableObject, TSearchValue, TSearchType> : SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class
    {
        internal SearchCriteriaBase<TSearchValue, TSearchType> SearchCriteria { get; set; }
    }
}
