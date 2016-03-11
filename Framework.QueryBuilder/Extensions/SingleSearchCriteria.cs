namespace Framework.QueryBuilder.Extensions
{
    using System;
    using System.Linq.Expressions;
    using SearchCriteria;
    using SearchTypes;
    using SingleValueSearchCriteria;

    public static class SingleSearchCriteria
    {
        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleValueSearchCriteriaBase<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> valueSearchCriteriaBase, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            return valueSearchCriteriaBase.Where(CompoundSearchType.And, searchablePropteryName, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleValueSearchCriteriaBase<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> valueSearchCriteriaBase, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            return valueSearchCriteriaBase.Where(CompoundSearchType.And, searchablePropterySpecifier, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> And<TSearchableObject, TSearchableLeftProperty, TSearchLeftType>(this SingleValueSearchCriteriaBase<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> valueSearchCriteriaBase, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class, IFilterable
        {
            var compoundSearchCriteria = CreateCompoundSearchCriteria(valueSearchCriteriaBase);

            compoundSearchCriteria.SearchCriterium.Add(valueSearchCriteriaBase);
            compoundSearchCriteria.SearchCriterium.Add(searchablePropterySpecifier(valueSearchCriteriaBase));
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

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleValueSearchCriteriaBase<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> valueSearchCriteriaBase, string searchablePropteryName, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            return valueSearchCriteriaBase.Where(CompoundSearchType.Or, searchablePropteryName, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject, TSearchableLeftProperty, TSearchLeftType, TSearchableRightProperty, TSearchRightType>(this SingleValueSearchCriteriaBase<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> valueSearchCriteriaBase, Expression<Func<TSearchableObject, TSearchableRightProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableRightProperty, TSearchRightType> sc) where TSearchableObject : class, IFilterable
        {
            return valueSearchCriteriaBase.Where(CompoundSearchType.Or, searchablePropterySpecifier, sc);
        }

        public static CompoundSearchCriteria<TSearchableObject> Or<TSearchableObject, TSearchableLeftProperty, TSearchLeftType>(this SingleValueSearchCriteriaBase<TSearchableObject, TSearchableLeftProperty, TSearchLeftType> valueSearchCriteriaBase, Func<SearchCriteriaBuilder<TSearchableObject>, CompoundSearchCriteria<TSearchableObject>> searchablePropterySpecifier) where TSearchableObject : class, IFilterable
        {
            var compoundSearchCriteria = CreateCompoundSearchCriteria(valueSearchCriteriaBase);

            compoundSearchCriteria.SearchCriterium.Add(valueSearchCriteriaBase);
            compoundSearchCriteria.SearchCriterium.Add(searchablePropterySpecifier(valueSearchCriteriaBase));
            compoundSearchCriteria.SearchCombinationTypes.Add(CompoundSearchType.Or);

            return compoundSearchCriteria;
        }

        internal static SingleValueSearchCriteriaBase<TSearchableObject, TSearchableProperty, TSearchType> CreateSingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>(string searchablePropteryName, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class, IFilterable
        {
            return sc.CreateSingleValueSearchCriteria<TSearchableObject>(searchablePropteryName, sc.SearchValue, sc.SearchType);
            //    new SingleValueSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>
            //{
            //    SearchCriteria = sc.CreateSearchCriteriaBase(searchablePropteryName, sc.SearchValue, sc.SearchType)
            //};
        }

        internal static SingleValueSearchCriteriaBase<TSearchableObject, TSearchableProperty, TSearchType> CreateSingleSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>(Type searchableObjectType, Expression<Func<TSearchableObject, TSearchableProperty>> searchablePropterySpecifier, SearchCriteriaBase<TSearchableProperty, TSearchType> sc) where TSearchableObject : class, IFilterable
        {
            return sc.CreateSingleValueSearchCriteria<TSearchableObject>(Utilities.GetPropertyName(searchableObjectType, searchablePropterySpecifier), sc.SearchValue, sc.SearchType);
            //return new SingleValueSearchCriteria<TSearchableObject, TSearchableProperty, TSearchType>
            //{
            //    SearchCriteria = sc.CreateSearchCriteriaBase(Utilities.GetPropertyName(searchableObjectType, searchablePropterySpecifier), sc.SearchValue, sc.SearchType)
            //};
        }
    }
}
