namespace Framework.QueryBuilder.SearchCriteria
{
    using Framework.QueryBuilder.SearchTypes;

    public class BooleanSearchCriteria : SearchCriteriaBase<bool, BooleanSearchType>
    {
        public BooleanSearchCriteria()
        {
        }

        public BooleanSearchCriteria(bool value, BooleanSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
