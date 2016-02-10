namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;

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
