namespace Framework.QueryBuilder.SearchCriteria
{
    using System;
    using SearchTypes;

    public class DateTimeSearchCriteria : SearchCriteriaBase<DateTime, DateTimeSearchType>
    {
        public DateTimeSearchCriteria()
        {
        }

        public DateTimeSearchCriteria(DateTime value, DateTimeSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
