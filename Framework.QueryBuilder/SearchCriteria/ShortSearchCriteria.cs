namespace Framework.QueryBuilder.SearchCriteria
{
    using Framework.QueryBuilder.SearchTypes;

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
