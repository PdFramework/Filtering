namespace Framework.QueryBuilder.Extensions
{
    using System;
    using System.Linq.Expressions;
    using SearchCriteria;
    using SearchTypes;

    public static class SingleSearchCriteria
    {
        public static CompoundSearchCriteria<TSearchableObject> AndWhere<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.And, searchablePropteryName, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> AndWhere<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.And, searchablePropterySpecifier, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> AndWhere<TSearchableObject, TSearchableLeftProperty, TSearchLeftType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.And, searchablePropterySpecifier);
        }

        public static CompoundSearchCriteria<TSearchableObject> OrWhere<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.Or, searchablePropteryName, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> OrWhere<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.Or, searchablePropterySpecifier, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> OrWhere<TSearchableObject, TSearchableLeftProperty, TSearchLeftType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class
        {
            return searchCriteria.Where(CompoundSearchType.Or, searchablePropterySpecifier);
        }

        internal static SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> CreateSingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>(string searchablePropteryName, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class
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

        internal static SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> CreateSingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>(Type searchableObjectType, Expression<Func<TSearchableObject, TSearchableProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class
        {
            return new SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>
            {
                SearchCriteria = new SearchCriteriaBase<TSearchableProperty, TSearchType>
                {
                    SearchValue = sc.SearchValue,
                    SearchType = sc.SearchType,
                    SearchPropertyName = Utilities.GetPropertyName(searchableObjectType, searchablePropterySpecifier)
                }
            };
        }

        private static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            var compoundSearchCriteria = new CompoundSearchCriteria<TSearchableObject>();

            compoundSearchCriteria.SearchCriterium.Add(searchCriteria);
            compoundSearchCriteria.SearchCriterium.Add(new SingleSearchCriteria<TSearchableObject, TSearchableRightProperty, TSearchRightType> { SearchCriteria = new SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> { SearchValue = sc.SearchValue, SearchType = sc.SearchType, SearchPropertyName = searchablePropteryName } });
            compoundSearchCriteria.SearchCombinationTypes.Add(compoundSearchType);

            return compoundSearchCriteria;
        }

        private static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class
        {
            var compoundSearchCriteria = new CompoundSearchCriteria<TSearchableObject>();

            compoundSearchCriteria.SearchCriterium.Add(searchCriteria);
            compoundSearchCriteria.SearchCriterium.Add(CreateSingleSearchCriteria(searchCriteria.BaseSearchObjectType, searchablePropterySpecifier, sc));
            compoundSearchCriteria.SearchCombinationTypes.Add(compoundSearchType);

            return compoundSearchCriteria;
        }

        private static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class
        {
            var compoundSearchCriteria = new CompoundSearchCriteria<TSearchableObject>();
            compoundSearchCriteria.SearchCriterium.Add(searchCriteria);
            compoundSearchCriteria.SearchCriterium.Add(searchablePropterySpecifier(searchCriteria));
            compoundSearchCriteria.SearchCombinationTypes.Add(compoundSearchType);

            return compoundSearchCriteria;
        }
    }
}
