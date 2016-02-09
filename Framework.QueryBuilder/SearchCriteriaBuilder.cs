namespace Framework.QueryBuilder
{
    using System;

    public class SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class
    {
        internal Type BaseSearchObjectType { get; set; }

        public SearchCriteriaBuilder()
        {
            BaseSearchObjectType = typeof(TSearchableObject);
        }
    }
}
