namespace Framework.QueryBuilder
{
    using Framework.QueryBuilder.SearchCriteria;

    public class SingleSearchCriteria<TSearchableObject, TSearchValue, TSearchType> : SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class
    {
        internal SearchCriteriaBase<TSearchValue, TSearchType> SearchCriteria { get; set; }
    }
}
