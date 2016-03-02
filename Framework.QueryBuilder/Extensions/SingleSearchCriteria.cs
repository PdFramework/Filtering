namespace Framework.QueryBuilder.Extensions
{
    using System;
    using System.Linq.Expressions;
    using SearchCriteria;
    using SearchTypes;

    public static class SingleSearchCriteria
    {
        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            return searchCriteria.Where(CompoundSearchType.And, searchablePropteryName, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            return searchCriteria.Where(CompoundSearchType.And, searchablePropterySpecifier, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject, TSearchableLeftProperty, TSearchLeftType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class, IFilterable
        {
            var compoundSearchCriteria = CreateCompoundSearchCriteria(searchCriteria);

            compoundSearchCriteria.SearchCriterium.Add(searchCriteria);
            compoundSearchCriteria.SearchCriterium.Add(searchablePropterySpecifier(searchCriteria));
            compoundSearchCriteria.SearchCombinationTypes.Add(CompoundSearchType.And);

            return compoundSearchCriteria;
        }

        private static CompoundSearchCriteria<TSearchableObject> CreateCompoundSearchCriteria<TSearchableObject>(SearchCriteriaBuilder<TSearchableObject> searchCriteria) where TSearchableObject : class, IFilterable
        {
            return new CompoundSearchCriteria<TSearchableObject>
            {
                ReturnAllResults = searchCriteria.ReturnAllResults,
                SortCriterium = searchCriteria.SortCriterium,
                PageIndex = searchCriteria.PageIndex,
                IncludeTotalCountWithResults = searchCriteria.IncludeTotalCountWithResults,
                PageSize = searchCriteria.PageSize,
                BaseSearchObjectType = searchCriteria.BaseSearchObjectType
            };
        }

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            return searchCriteria.Where(CompoundSearchType.Or, searchablePropteryName, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            return searchCriteria.Where(CompoundSearchType.Or, searchablePropterySpecifier, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject, TSearchableLeftProperty, TSearchLeftType>(this SingleSearchCriteria<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> searchCriteria, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class, IFilterable
        {
            var compoundSearchCriteria = CreateCompoundSearchCriteria(searchCriteria);

            compoundSearchCriteria.SearchCriterium.Add(searchCriteria);
            compoundSearchCriteria.SearchCriterium.Add(searchablePropterySpecifier(searchCriteria));
            compoundSearchCriteria.SearchCombinationTypes.Add(CompoundSearchType.Or);

            return compoundSearchCriteria;
        }

        internal static SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> CreateSingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>(string searchablePropteryName, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class, IFilterable
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

        internal static SingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> CreateSingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>(Type searchableObjectType, Expression<Func<TSearchableObject, TSearchableProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class, IFilterable
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
    }
}
