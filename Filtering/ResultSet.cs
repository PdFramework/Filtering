namespace PeinearyDevelopment.Framework.Filtering
{
    using System.Collections.Generic;

    public class ResultSet<TFilterable> where TFilterable : class, IFilterable
    {
        public int? TotalNumberOfResults { get; }
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
