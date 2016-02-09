namespace Framework.QueryBuilder.SearchCriteria
{
    using Framework.QueryBuilder.SearchTypes;

    public class LongSearchCriteria : SearchCriteriaBase<long, LongSearchType>
    {
        public LongSearchCriteria()
        {
        }

        public LongSearchCriteria(long value, LongSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
