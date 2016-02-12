namespace Framework.QueryBuilder.SearchCriteria
{
    //TODO: add MultiValue Search Criteria Base for IN, NOT IN and BETWEEN
    public class SearchCriteriaBase<TSearchValue, TSearchType>
    {
        internal string SearchPropertyName { get; set; }
        public TSearchType SearchType { get; set; }
        public TSearchValue SearchValue { get; set; }

        public SearchCriteriaBase()
        {
        }

        public SearchCriteriaBase(TSearchValue value, TSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
