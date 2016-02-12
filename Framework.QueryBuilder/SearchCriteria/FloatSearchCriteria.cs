namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;

    public class FloatSearchCriteria : SearchCriteriaBase<float, FloatSearchType>
    {
        public FloatSearchCriteria()
        {
        }

        public FloatSearchCriteria(float value, FloatSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
