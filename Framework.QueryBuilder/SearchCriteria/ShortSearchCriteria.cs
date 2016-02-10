namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;

    public class ShortSearchCriteria : SearchCriteriaBase<short, ShortSearchType>
    {
        public ShortSearchCriteria()
        {
        }

        public ShortSearchCriteria(short value, ShortSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
