namespace Framework.QueryBuilder.Extensions
{
    using System;
    using System.Linq.Expressions;
    using SearchCriteria;
    using SearchTypes;

    public static class CompoundSearchCriteria
    {
        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.And, searchablePropteryName, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.And, searchablePropterySpecifier, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.And, searchablePropterySpecifier);
        }

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.Or, searchablePropteryName, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.Or, searchablePropterySpecifier, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.Or, searchablePropterySpecifier);
        }

        private static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            searchCriteria.SearchCriterium.Add(SingleSearchCriteria.CreateSingleSearchCriteria(searchCriteria.BaseSearchObjectType, searchablePropterySpecifier, sc));
            searchCriteria.SearchCombinationTypes.Add(compoundSearchType);

            return searchCriteria;
        }

        private static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            searchCriteria.SearchCriterium.Add(SingleSearchCriteria.CreateSingleSearchCriteria<TSearchableObject, TSearchableRightProperty, TSearchRightType>(searchablePropteryName, sc));
            searchCriteria.SearchCombinationTypes.Add(compoundSearchType);

            return searchCriteria;
        }

        private static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject>(this CompoundSearchCriteria<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class
        {
            searchCriteria.SearchCriterium.Add(searchablePropterySpecifier(searchCriteria));
            searchCriteria.SearchCombinationTypes.Add(compoundSearchType);
            return searchCriteria;
        }
    }
}
