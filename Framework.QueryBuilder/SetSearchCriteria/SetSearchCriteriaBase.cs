namespace Framework.QueryBuilder.SetSearchCriteria
{
    using System.Collections;
    using SearchCriteria;

    public class SetSearchCriteriaBase<TSearchableObject> : SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class, IFilterable
    {
        internal SearchCriteriaBase SearchCriteria { get; set; }
    }

    public class SetSearchCriteriaBase<TSearchableObject, TSearchValue, TSearchType> : SetSearchCriteriaBase<TSearchableObject> where TSearchableObject : class, IFilterable
                                                                                                                                 where TSearchValue : IEnumerable
    {
    }
}
