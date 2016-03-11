namespace Framework.QueryBuilder.SingleValueSearchCriteria
{
    using SearchCriteria;
    using SearchTypes;
    using System;

    public class DateTimeSearchCriteria<TSearchableObject> : SingleValueSearchCriteriaBase<TSearchableObject, DateTime, DateTimeSearchType> where TSearchableObject : class, IFilterable
    {
        public DateTimeSearchCriteria(string searchPropertyName, DateTime value, DateTimeSearchType type)
        {
            SearchCriteria = new DateTimeSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }
    }
}
