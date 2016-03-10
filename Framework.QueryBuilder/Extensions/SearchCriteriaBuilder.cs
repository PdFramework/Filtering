namespace Framework.QueryBuilder.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using SearchCriteria;
    using SearchTypes;

    public static class SearchCriteriaBuilder
    {
        public static SearchCriteriaBuilder<TSearchableObject> CreateSearchCriteria<TSearchableObject>() where TSearchableObject : class, IFilterable
        {
            return new SearchCriteriaBuilder<TSearchableObject>();
        }

        public static SearchCriteriaBuilder<TSearchableObject> CreateSearchCriteria<TSearchableObject>(bool returnAllResults) where TSearchableObject : class, IFilterable
        {
            return new SearchCriteriaBuilder<TSearchableObject>(returnAllResults);
        }

        public static SearchCriteriaBuilder<TSearchableObject> CreateSearchCriteria<TSearchableObject>(int pageIndex, int pageSize, bool includeTotalCountWithResults = false) where TSearchableObject : class, IFilterable
        {
            return new SearchCriteriaBuilder<TSearchableObject>(pageIndex, pageSize, includeTotalCountWithResults);
        }

        public static SearchCriteriaBuilder<TSearchableObject> CreateSearchCriteria<TSearchableObject>(this TSearchableObject searchableObject) where TSearchableObject : class, IFilterable
        {
            return new SearchCriteriaBuilder<TSearchableObject>();
        }

        public static SearchCriteriaBuilder<TSearchableObject> CreateSearchCriteria<TSearchableObject>(this TSearchableObject searchableObject, bool returnAllResults) where TSearchableObject : class, IFilterable
        {
            return new SearchCriteriaBuilder<TSearchableObject>(returnAllResults);
        }

        public static SearchCriteriaBuilder<TSearchableObject> CreateSearchCriteria<TSearchableObject>(this TSearchableObject searchableObject, int pageIndex, int pageSize, bool includeTotalCountWithResults = false) where TSearchableObject : class, IFilterable
        {
            return new SearchCriteriaBuilder<TSearchableObject>(pageIndex, pageSize, includeTotalCountWithResults);
        }

        public static SearchCriteriaBuilder<TSearchableObject> GetResultsPage<TSearchableObject>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, int pageIndex) where TSearchableObject : class, IFilterable
        {
            searchCriteria.PageIndex = pageIndex;
            return searchCriteria;
        }

        public static SearchCriteriaBuilder<TSearchableObject> Take<TSearchableObject>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, int pageSize) where TSearchableObject : class, IFilterable
        {
            searchCriteria.PageSize = pageSize;
            return searchCriteria;
        }

        public static SearchCriteriaBuilder<TSearchableObject> IncludeTotalCount<TSearchableObject>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria) where TSearchableObject : class, IFilterable
        {
            searchCriteria.IncludeTotalCountWithResults = true;
            return searchCriteria;
        }

        public static SearchCriteriaBuilder<TSearchableObject> ReturnAllResults<TSearchableObject>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria) where TSearchableObject : class, IFilterable
        {
            searchCriteria.ReturnAllResults = true;
            return searchCriteria;
        }

        public static SearchCriteriaBuilder<TSearchableObject> OrderBy<TSearchableObject>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, string sortablePropteryName, SortType sortType = SortType.Ascending) where TSearchableObject : class, IFilterable
        {
            searchCriteria.SortCriterium.Add(new SortCriteria
            {
                SortPropertyName = sortablePropteryName,
                SortType = sortType
            });

            return searchCriteria;
        }

        public static SearchCriteriaBuilder<TSearchableObject> OrderBy<TSearchableObject, TSearchableProperty>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, Expression<Func<TSearchableObject, TSearchableProperty>> sortablePropterySpecifier, SortType sortType = SortType.Ascending) where TSearchableObject : class, IFilterable
        {
            searchCriteria.SortCriterium.Add(new SortCriteria
            {
                SortPropertyName = Utilities.GetPropertyName(searchCriteria.BaseSearchObjectType, sortablePropterySpecifier),
                SortType = sortType
            });

            return searchCriteria;
        }

        public static SingleValueSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> Where<TSearchableObject, TSearchableProperty, TSearchType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class, IFilterable
        {
            return CreateSingleSearchCriteria(searchCriteria, searchablePropteryName, sc);
        }

        public static SingleValueSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> Where<TSearchableObject, TSearchableProperty, TSearchType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, Expression<Func<TSearchableObject, TSearchableProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class, IFilterable
        {
            return CreateSingleSearchCriteria(searchCriteria, Utilities.GetPropertyName(searchCriteria.BaseSearchObjectType, searchablePropterySpecifier), sc);
        }

        public static SetSearchCriteria<TSearchableObject, IEnumerable<TSearchableProperty>, TSearchType> Where<TSearchableObject, TSearchableProperty, TSearchType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, Expression<Func<TSearchableObject, TSearchableProperty>> searchablePropterySpecifier, SearchCriteriaBase<IEnumerable<TSearchableProperty>, TSearchType> sc) where TSearchableObject : class, IFilterable
        {
            return new SetSearchCriteria<TSearchableObject, IEnumerable<TSearchableProperty>, TSearchType>
            {
                SearchCriteria = new SearchCriteriaBase<IEnumerable<TSearchableProperty>, TSearchType>
                {
                    SearchValue = sc.SearchValue,
                    SearchType = sc.SearchType,
                    SearchPropertyName = Utilities.GetPropertyName(searchCriteria.BaseSearchObjectType, searchablePropterySpecifier)
                },
                SortCriterium = searchCriteria.SortCriterium,
                ReturnAllResults = searchCriteria.ReturnAllResults,
                PageIndex = searchCriteria.PageIndex,
                IncludeTotalCountWithResults = searchCriteria.IncludeTotalCountWithResults,
                PageSize = searchCriteria.PageSize,
                BaseSearchObjectType = searchCriteria.BaseSearchObjectType
            };
        }

        private static SingleValueSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType> CreateSingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>(SearchCriteriaBuilder<TSearchableObject> searchCriteria, string searchablePropteryName, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class, IFilterable
        {
            return new SingleValueSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>
            {
                SearchCriteria = new SearchCriteriaBase<TSearchableProperty, TSearchType>
                {
                    SearchValue = sc.SearchValue,
                    SearchType = sc.SearchType,
                    SearchPropertyName = searchablePropteryName
                },
                SortCriterium = searchCriteria.SortCriterium,
                ReturnAllResults = searchCriteria.ReturnAllResults,
                PageIndex = searchCriteria.PageIndex,
                IncludeTotalCountWithResults = searchCriteria.IncludeTotalCountWithResults,
                PageSize = searchCriteria.PageSize,
                BaseSearchObjectType = searchCriteria.BaseSearchObjectType
            };
        }

        internal static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            var compoundSearchCriteria = CreateCompoundSearchCriteria(searchCriteria);

            compoundSearchCriteria.SearchCriterium.Add(searchCriteria);
            compoundSearchCriteria.SearchCriterium.Add(new SingleValueSearchCriteria<TSearchableObject, TSearchableRightProperty, TSearchRightType> { SearchCriteria = new SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> { SearchValue = sc.SearchValue, SearchType = sc.SearchType, SearchPropertyName = searchablePropteryName } });
            compoundSearchCriteria.SearchCombinationTypes.Add(compoundSearchType);

            return compoundSearchCriteria;
        }

        internal static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject, TSearchableRightProperty, TSearchRightType>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            var compoundSearchCriteria = CreateCompoundSearchCriteria(searchCriteria);

            compoundSearchCriteria.SearchCriterium.Add(searchCriteria);
            compoundSearchCriteria.SearchCriterium.Add(SingleSearchCriteria.CreateSingleSearchCriteria(searchCriteria.BaseSearchObjectType, searchablePropterySpecifier, sc));
            compoundSearchCriteria.SearchCombinationTypes.Add(compoundSearchType);

            return compoundSearchCriteria;
        }

        internal static CompoundSearchCriteria<TSearchableObject> Where<TSearchableObject>(this SearchCriteriaBuilder<TSearchableObject> searchCriteria, CompoundSearchType compoundSearchType, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class, IFilterable
        {
            var compoundSearchCriteria = CreateCompoundSearchCriteria(searchCriteria);

            compoundSearchCriteria.SearchCriterium.Add(searchCriteria);
            compoundSearchCriteria.SearchCriterium.Add(searchablePropterySpecifier(searchCriteria));
            compoundSearchCriteria.SearchCombinationTypes.Add(compoundSearchType);

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
    }
}
