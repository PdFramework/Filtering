namespace PeinearyDevelopment.Framework.Filtering
{
  public class SortCriterion
  {
    public string SortPropertyName { get; set; }
    public SortType SortType { get; set; }

    public SortCriterion()
    {
    }

    public SortCriterion(string propertyName, SortType sortType)
    {
      SortPropertyName = propertyName;
      SortType = sortType;
    }
  }
}
