namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System;
    using System.Collections.Generic;
    using SetSearchCriteria;
    using SetSearchTypes;
    using SingleValueSearchCriteria;

    public class DateTimeOffsetSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<DateTimeOffset>, DateTimeOffsetSetSearchType> where TSearchableObject : class, IFilterable
    {
        public DateTimeOffsetSetSearchCriteria(string searchPropertyName, IEnumerable<DateTimeOffset> value, DateTimeOffsetSetSearchType type)
        {
            SearchCriteria = new DateTimeOffsetSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
