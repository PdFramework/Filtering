namespace PeinearyDevelopment.Framework.Filtering
{
  using System.Collections.Generic;

  public class ResultSet<TFilterable> where TFilterable : class, IFilterable
  {
    public int? TotalNumberOfResults { get; }
    public IList<TFilterable> Results { get; }

    public ResultSet(int? totalNumberOfResults, IList<TFilterable> results)
    {
      TotalNumberOfResults = totalNumberOfResults;
      Results = results;
    }
  }
}
