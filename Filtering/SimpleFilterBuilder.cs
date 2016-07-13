namespace PeinearyDevelopment.Framework.Filtering
{
  public class SimpleFilterBuilder<TFilterable> : BaseFilterBuilder<TFilterable> where TFilterable : class, IFilterable
  {
    public SimpleFilterBuilder(BaseFilterBuilder<TFilterable> baseFilterBuilder) : base(baseFilterBuilder) { }
  }
}
