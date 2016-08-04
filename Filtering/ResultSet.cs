using Newtonsoft.Json;

namespace PeinearyDevelopment.Framework.Filtering
{
    using System.Collections.Generic;

    public class ResultSet<TFilterable> where TFilterable : class, IFilterable
    {
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public int? TotalNumberOfResults { get; }
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public IEnumerable<TFilterable> Results { get; }

        public ResultSet()
        {
        }

        public ResultSet(int? totalNumberOfResults, IEnumerable<TFilterable> results)
        {
            TotalNumberOfResults = totalNumberOfResults;
            Results = results;
        }
    }
}
