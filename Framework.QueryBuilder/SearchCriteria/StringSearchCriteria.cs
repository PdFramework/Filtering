namespace Framework.QueryBuilder.SearchCriteria
{
    using SearchTypes;

    public class StringSearchCriteria : SearchCriteriaBase<string, StringSearchType>
    {
        public StringSearchCriteria()
        {
        }

        public StringSearchCriteria(string value, StringSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
