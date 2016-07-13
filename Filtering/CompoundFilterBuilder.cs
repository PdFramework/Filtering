namespace PeinearyDevelopment.Framework.Filtering
{
  public class CompoundFilterBuilder<TFilterable> : SimpleFilterBuilder<TFilterable> where TFilterable : class, IFilterable
  {
    public CompoundFilterBuilder(BaseFilterBuilder<TFilterable> baseFilterBuilder) : base(baseFilterBuilder) { }
  }
}