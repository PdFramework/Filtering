namespace Framework.QueryBuilder
{
    using System.Collections.Generic;
    using Framework.QueryBuilder.SearchTypes;

    public class CompoundSearchCriteria<TSearchableObject> : SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class
    {
        internal IList<SearchCriteriaBuilder<TSearchableObject>> SearchCriterium { get; set; }
        internal IList<CompoundSearchType> SearchCombinationTypes { get; set; }

        public CompoundSearchCriteria()
        {
            SearchCriterium = new List<SearchCriteriaBuilder<TSearchableObject>>();
            SearchCombinationTypes = new List<CompoundSearchType>();
        }
    }
}
