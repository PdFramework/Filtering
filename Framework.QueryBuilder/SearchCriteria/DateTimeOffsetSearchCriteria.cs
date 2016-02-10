namespace Framework.QueryBuilder.SearchCriteria
{
    using System;
    using SearchTypes;

    public class DateTimeOffsetSearchCriteria : SearchCriteriaBase<DateTimeOffset, DateTimeOffsetSearchType>
    {
        public DateTimeOffsetSearchCriteria()
        {
        }

        public DateTimeOffsetSearchCriteria(DateTimeOffset value, DateTimeOffsetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }
    }
}
