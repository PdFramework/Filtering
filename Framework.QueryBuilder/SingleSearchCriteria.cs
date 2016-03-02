namespace Framework.QueryBuilder
{
    using SearchCriteria;

    public class SingleSearchCriteria<TSearchableObject, TSearchValue, TSearchType> : SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class, IFilterable
    {
        //TODO: investigate how to handle null values for bool, int, etc.
        internal SearchCriteriaBase<TSearchValue, TSearchType> SearchCriteria { get; set; }
    }
}
