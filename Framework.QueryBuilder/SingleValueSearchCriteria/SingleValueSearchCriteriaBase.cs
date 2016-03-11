namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;

    public abstract class SingleValueSearchCriteriaBase<TSearchableObject> : SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class, IFilterable
    {
        internal SearchCriteriaBase SearchCriteria { get; set; }
    }

    public abstract class SingleValueSearchCriteriaBase<TSearchableObject, TSearchValue, TSearchType> : SingleValueSearchCriteriaBase<TSearchableObject> where TSearchableObject : class, IFilterable
    {
    }
}
