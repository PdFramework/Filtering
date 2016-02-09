namespace Framework.QueryBuilder.SearchCriteria
{
    using Framework.QueryBuilder.SearchTypes;

    public class IntegerSearchCriteria : SearchCriteriaBase<int, IntegerSearchType>
    {
        public IntegerSearchCriteria()
        {
        }

        public IntegerSearchCriteria(int value, IntegerSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
