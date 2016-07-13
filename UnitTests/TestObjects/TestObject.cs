using System;
using PeinearyDevelopment.Framework.Filtering;

namespace Framework.Filtering.UnitTests.TestObjects
{
  public class TestObject : IFilterable
  {
    public int Id { get; set; }
    public bool BooleanProperty { get; set; }
    public bool? NullableBooleanProperty { get; set; }
    public DateTime DateTimeProperty { get; set; }
    public DateTime? NullableDateTimeProperty { get; set; }
    public DateTimeOffset DateTimeOffsetProperty { get; set; }
    public DateTimeOffset? NullableDateTimeOffsetProperty { get; set; }
    public decimal DecimalProperty { get; set; }
    public decimal? NullableDecimalProperty { get; set; }
    public double DoubleProperty { get; set; }
    public double? NullableDoubleProperty { get; set; }
    public float FloatProperty { get; set; }
    public float? NullableFloatProperty { get; set; }
    public int IntegerProperty { get; set; }
    public int? NullableIntegerProperty { get; set; }
    public long LongProperty { get; set; }
    public long? NullableLongProperty { get; set; }
    public short ShortProperty { get; set; }
    public short? NullableShortProperty { get; set; }
    public string StringProperty { get; set; }
  }
}
