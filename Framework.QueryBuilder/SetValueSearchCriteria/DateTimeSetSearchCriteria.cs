namespace Framework.QueryBuilder.SetValueSearchCriteria
{
    using System;
    using System.Collections.Generic;
    using SetSearchTypes;
    using SingleValueSearchCriteria;
    using SetSearchCriteria;

    public class DateTimeSetSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, IEnumerable<DateTime>, DateTimeSetSearchType> where TSearchableObject : class, IFilterable
    {
        public DateTimeSetSearchCriteria(string searchPropertyName, IEnumerable<DateTime> value, DateTimeSetSearchType type)
        {
            SearchCriteria = new DateTimeSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
