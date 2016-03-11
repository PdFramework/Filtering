namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;
    using System;

    public class DateTimeOffsetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, DateTimeOffset, DateTimeOffsetSearchType> where TSearchableObject : class, IFilterable
    {
        public DateTimeOffsetSearchCriteria(string searchPropertyName, DateTimeOffset value, DateTimeOffsetSearchType type)
        {
            SearchCriteria = new DateTimeOffsetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
