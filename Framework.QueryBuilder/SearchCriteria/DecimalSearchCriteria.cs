namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;

    public class DecimalSearchCriteria : SearchCriteriaBase<decimal, DecimalSearchType>
    {
        public DecimalSearchCriteria()
        {
        }

        public DecimalSearchCriteria(decimal value, DecimalSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
