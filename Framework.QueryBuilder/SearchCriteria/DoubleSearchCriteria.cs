namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;

    public class DoubleSearchCriteria : SearchCriteriaBase<double, DoubleSearchType>
    {
        public DoubleSearchCriteria()
        {
        }

        public DoubleSearchCriteria(double value, DoubleSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
