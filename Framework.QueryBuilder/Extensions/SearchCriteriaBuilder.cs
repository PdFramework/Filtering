namespace Framework.QueryBuilder.Extensions
{
    using System;
    using System.Linq.Expressions;
    using Framework.QueryBuilder.SearchCriteria;

    public static class SearchCriteriaBuilder
    {
        public static SearchCriteriaBuilder<TSearchableObject> CreateSearchCriteria<TSearchableObject>() where TSearchableObject : class
        {
            return new SearchCriteriaBuilder<TSearchableObject>();
        }

        public static SearchCriteriaBuilder<TSearchableObject> CreateSearchCriteria<TSearchableObject>(this TSearchableObject searchableObject) where TSearchableObject : class
        {
            return new SearchCriteriaBuilder<TSearchableObject>();
        }

        public static SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> Where<TSearchableObject, TSearchableProperty, TSearchType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class
        {
            return new SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>
            {
                SearchCriteria = new SearchCriteriaBase<TSearchableProperty, TSearchType>
                {
                    SearchValue = sc.SearchValue,
                    SearchType = sc.SearchType,
                    SearchPropertyName = searchablePropteryName
                }
            };
        }

        public static SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> Where<TSearchableObject, TSearchableProperty, TSearchType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, Expression<Func<TSearchableObject, TSearchableProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class
        {
            return new SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>
            {
                SearchCriteria = new SearchCriteriaBase<TSearchableProperty, TSearchType>
                {
                    SearchValue = sc.SearchValue,
                    SearchType = sc.SearchType,
                    SearchPropertyName = Utilities.GetPropertyName(searchCriteria.BaseSearchObjectType, searchablePropterySpecifier)
                }
            };
        }
    }
}
