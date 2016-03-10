namespace Framework.QueryBuilder
{
    using SearchCriteria;
    using System.Collections;

    public class SetSearchCriteria<TSearchableObject, TSearchValue, TSearchType> : SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class, IFilterable
                                                                                                                            where TSearchValue : IEnumerable
    {
        //TODO: investigate how to handle null values for bool, int, etc.
        internal SearchCriteriaBase<TSearchValue, TSearchType> SearchCriteria { get; set; }
    }
}
