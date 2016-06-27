﻿using System;
using System.Collections.Generic;

namespace Framework.QueryBuilder
{
    public class SearchCriteriaBuilder<TSearchableObject> where TSearchableObject : class, IFilterable
    {
        internal Type BaseSearchObjectType { get; set; }
        internal IList<SortCriteria> SortCriterium { get; set; }

        /// <summary>
        /// A zero-based page index of the results to be returned.
        /// Default value: 0
        /// NOTE: this value is ignored if ReturnAllResults is set to true.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// The maximum number of results to be returned with the search results.
        /// Default value: 10
        /// NOTE: this value is ignored if ReturnAllResults is set to true.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// If set to true, PageIndex and PageSize values are ignored.
        /// </summary>
        public bool ReturnAllResults { get; set; }

        /// <summary>
        /// If set to true, the SearchResult set will include a count of all the records matching the search criteria in the data store.
        /// </summary>
        public bool IncludeTotalCountWithResults { get; set; }

        public SearchCriteriaBuilder(bool returnAllResults) : this(0, 10, returnAllResults, returnAllResults)
        {
        }

        public SearchCriteriaBuilder(int pageIndex = 0, int pageSize = 10, bool returnAllResults = false, bool includeTotalCountWithResults = false)
        {
            BaseSearchObjectType = typeof(TSearchableObject);
            SortCriterium = new List<SortCriteria>();
            PageIndex = pageIndex;
            PageSize = pageSize;
            IncludeTotalCountWithResults = includeTotalCountWithResults;
            ReturnAllResults = returnAllResults;
        }
    }
}
