using System;
using Framework.Filtering.UnitTests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeinearyDevelopment.Framework.Filtering;
using PeinearyDevelopment.Framework.Filtering.Extensions;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets;
using PeinearyDevelopment.Framework.Filtering.FilterTypes;

namespace Framework.Filtering.UnitTests
{
  [TestClass]
  public class ReadableCompilableRunnableUnitTests
  {
    [TestMethod]
    public void BooleanTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new BooleanCriterion<TestObject>(to => to.BooleanProperty, BooleanFilterType.Equals, true))
                           .And(new BooleanCriterion<TestObject>(to => to.BooleanProperty, BooleanFilterType.Equals, true))
                           .Or(new BooleanCriterion<TestObject>(to => to.BooleanProperty, BooleanFilterType.Equals, true));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.BooleanProperty, BooleanFilterType.Equals, true)
                           .And(to => to.BooleanProperty, BooleanFilterType.Equals, true)
                           .Or(to => to.BooleanProperty, BooleanFilterType.Equals, true);
      var c = new FilterBuilder<TestObject>()
                           .Where("BooleanProperty", BooleanFilterType.Equals, true)
                           .And("BooleanProperty", BooleanFilterType.Equals, true)
                           .Or("BooleanProperty", BooleanFilterType.Equals, true);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableBooleanCriterion<TestObject>(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null))
                           .And(new NullableBooleanCriterion<TestObject>(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null))
                           .Or(new NullableBooleanCriterion<TestObject>(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null)
                           .And(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null)
                           .Or(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableBooleanProperty", BooleanFilterType.Equals, null)
                           .And("NullableBooleanProperty", BooleanFilterType.Equals, null)
                           .Or("NullableBooleanProperty", BooleanFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new BooleanCriterion<TestObject>(to => to.BooleanProperty, BooleanFilterType.Equals, true))
                           .Or(new BooleanCriterion<TestObject>(to => to.BooleanProperty, BooleanFilterType.Equals, true))
                           .And(new BooleanCriterion<TestObject>(to => to.BooleanProperty, BooleanFilterType.Equals, true));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.BooleanProperty, BooleanFilterType.Equals, true)
                           .Or(to => to.BooleanProperty, BooleanFilterType.Equals, true)
                           .And(to => to.BooleanProperty, BooleanFilterType.Equals, true);
      var i = new FilterBuilder<TestObject>()
                           .Where("BooleanProperty", BooleanFilterType.Equals, true)
                           .Or("BooleanProperty", BooleanFilterType.Equals, true)
                           .And("BooleanProperty", BooleanFilterType.Equals, true);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableBooleanCriterion<TestObject>(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null))
                           .Or(new NullableBooleanCriterion<TestObject>(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null))
                           .And(new NullableBooleanCriterion<TestObject>(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null)
                           .Or(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null)
                           .And(to => to.NullableBooleanProperty, BooleanFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableBooleanProperty", BooleanFilterType.Equals, null)
                           .Or("NullableBooleanProperty", BooleanFilterType.Equals, null)
                           .And("NullableBooleanProperty", BooleanFilterType.Equals, null);
    }

    [TestMethod]
    public void DateTimeTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new DateTimeCriterion<TestObject>(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now))
                           .And(new DateTimeCriterion<TestObject>(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now))
                           .Or(new DateTimeCriterion<TestObject>(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now)
                           .And(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now)
                           .Or(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now);
      var c = new FilterBuilder<TestObject>()
                           .Where("DateTimeProperty", DateTimeFilterType.Equals, DateTime.Now)
                           .And("DateTimeProperty", DateTimeFilterType.Equals, DateTime.Now)
                           .Or("DateTimeProperty", DateTimeFilterType.Equals, DateTime.Now);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableDateTimeCriterion<TestObject>(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null))
                           .And(new NullableDateTimeCriterion<TestObject>(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null))
                           .Or(new NullableDateTimeCriterion<TestObject>(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null)
                           .And(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null)
                           .Or(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableDateTimeProperty", DateTimeFilterType.Equals, null)
                           .And("NullableDateTimeProperty", DateTimeFilterType.Equals, null)
                           .Or("NullableDateTimeProperty", DateTimeFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new DateTimeCriterion<TestObject>(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now))
                           .Or(new DateTimeCriterion<TestObject>(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now))
                           .And(new DateTimeCriterion<TestObject>(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now)
                           .Or(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now)
                           .And(to => to.DateTimeProperty, DateTimeFilterType.Equals, DateTime.Now);
      var i = new FilterBuilder<TestObject>()
                           .Where("DateTimeProperty", DateTimeFilterType.Equals, DateTime.Now)
                           .Or("DateTimeProperty", DateTimeFilterType.Equals, DateTime.Now)
                           .And("DateTimeProperty", DateTimeFilterType.Equals, DateTime.Now);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableDateTimeCriterion<TestObject>(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null))
                           .Or(new NullableDateTimeCriterion<TestObject>(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null))
                           .And(new NullableDateTimeCriterion<TestObject>(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null)
                           .Or(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null)
                           .And(to => to.NullableDateTimeProperty, DateTimeFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableDateTimeProperty", DateTimeFilterType.Equals, null)
                           .Or("NullableDateTimeProperty", DateTimeFilterType.Equals, null)
                           .And("NullableDateTimeProperty", DateTimeFilterType.Equals, null);
      
      var m = new FilterBuilder<TestObject>()
                           .Where(new DateTimeSetCriterion<TestObject>(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now }))
                           .And(new DateTimeSetCriterion<TestObject>(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now }))
                           .Or(new DateTimeSetCriterion<TestObject>(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now })
                           .And(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now })
                           .Or(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now });
      var o = new FilterBuilder<TestObject>()
                           .Where("DateTimeProperty", SetFilterType.In, new[] { DateTime.Now })
                           .And("DateTimeProperty", SetFilterType.In, new[] { DateTime.Now })
                           .Or("DateTimeProperty", SetFilterType.In, new[] { DateTime.Now });

      var p = new FilterBuilder<TestObject>()
                           .Where(new NullableDateTimeSetCriterion<TestObject>(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null }))
                           .And(new NullableDateTimeSetCriterion<TestObject>(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null }))
                           .Or(new NullableDateTimeSetCriterion<TestObject>(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null })
                           .And(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null })
                           .Or(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("NullableDateTimeProperty", SetFilterType.In, new[] { (DateTime?)null })
                           .And("NullableDateTimeProperty", SetFilterType.In, new[] { (DateTime?)null })
                           .Or("NullableDateTimeProperty", SetFilterType.In, new[] { (DateTime?)null });

      var s = new FilterBuilder<TestObject>()
                           .Where(new DateTimeSetCriterion<TestObject>(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now }))
                           .Or(new DateTimeSetCriterion<TestObject>(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now }))
                           .And(new DateTimeSetCriterion<TestObject>(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now })
                           .Or(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now })
                           .And(to => to.DateTimeProperty, SetFilterType.In, new[] { DateTime.Now });
      var u = new FilterBuilder<TestObject>()
                           .Where("DateTimeProperty", SetFilterType.In, new[] { DateTime.Now })
                           .Or("DateTimeProperty", SetFilterType.In, new[] { DateTime.Now })
                           .And("DateTimeProperty", SetFilterType.In, new[] { DateTime.Now });

      var v = new FilterBuilder<TestObject>()
                           .Where(new NullableDateTimeSetCriterion<TestObject>(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null }))
                           .Or(new NullableDateTimeSetCriterion<TestObject>(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null }))
                           .And(new NullableDateTimeSetCriterion<TestObject>(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null })
                           .Or(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null })
                           .And(to => to.NullableDateTimeProperty, SetFilterType.In, new[] { (DateTime?)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("NullableDateTimeProperty", SetFilterType.In, new[] { (DateTime?)null })
                           .Or("NullableDateTimeProperty", SetFilterType.In, new[] { (DateTime?)null })
                           .And("NullableDateTimeProperty", SetFilterType.In, new[] { (DateTime?)null });
    }

    [TestMethod]
    public void DateTimeOffsetTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new DateTimeOffsetCriterion<TestObject>(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now))
                           .And(new DateTimeOffsetCriterion<TestObject>(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now))
                           .Or(new DateTimeOffsetCriterion<TestObject>(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now)
                           .And(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now)
                           .Or(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now);
      var c = new FilterBuilder<TestObject>()
                           .Where("DateTimeOffsetProperty", DateTimeFilterType.Equals, DateTimeOffset.Now)
                           .And("DateTimeOffsetProperty", DateTimeFilterType.Equals, DateTimeOffset.Now)
                           .Or("DateTimeOffsetProperty", DateTimeFilterType.Equals, DateTimeOffset.Now);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableDateTimeOffsetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null))
                           .And(new NullableDateTimeOffsetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null))
                           .Or(new NullableDateTimeOffsetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null)
                           .And(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null)
                           .Or(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableDateTimeOffsetProperty", DateTimeFilterType.Equals, null)
                           .And("NullableDateTimeOffsetProperty", DateTimeFilterType.Equals, null)
                           .Or("NullableDateTimeOffsetProperty", DateTimeFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new DateTimeOffsetCriterion<TestObject>(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now))
                           .Or(new DateTimeOffsetCriterion<TestObject>(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now))
                           .And(new DateTimeOffsetCriterion<TestObject>(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now)
                           .Or(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now)
                           .And(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now);
      var i = new FilterBuilder<TestObject>()
                           .Where("DateTimeOffsetProperty", DateTimeFilterType.Equals, DateTimeOffset.Now)
                           .Or("DateTimeOffsetProperty", DateTimeFilterType.Equals, DateTimeOffset.Now)
                           .And("DateTimeOffsetProperty", DateTimeFilterType.Equals, DateTimeOffset.Now);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableDateTimeOffsetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null))
                           .Or(new NullableDateTimeOffsetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null))
                           .And(new NullableDateTimeOffsetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null)
                           .Or(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null)
                           .And(to => to.NullableDateTimeOffsetProperty, DateTimeFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableDateTimeOffsetProperty", DateTimeFilterType.Equals, null)
                           .Or("NullableDateTimeOffsetProperty", DateTimeFilterType.Equals, null)
                           .And("NullableDateTimeOffsetProperty", DateTimeFilterType.Equals, null);

      var m = new FilterBuilder<TestObject>()
                           .Where(new DateTimeOffsetSetCriterion<TestObject>(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now }))
                           .And(new DateTimeOffsetSetCriterion<TestObject>(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now }))
                           .Or(new DateTimeOffsetSetCriterion<TestObject>(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now })
                           .And(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now })
                           .Or(to => to.DateTimeOffsetProperty, DateTimeFilterType.Equals, DateTimeOffset.Now);
      var o = new FilterBuilder<TestObject>()
                           .Where("DateTimeOffsetProperty", SetFilterType.In, new[] { DateTimeOffset.Now })
                           .And("DateTimeOffsetProperty", SetFilterType.In, new[] { DateTimeOffset.Now })
                           .Or("DateTimeOffsetProperty", SetFilterType.In, new[] { DateTimeOffset.Now });

      var p = new FilterBuilder<TestObject>()
                           .Where(new NullableDateTimeOffsetSetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null }))
                           .And(new NullableDateTimeOffsetSetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null }))
                           .Or(new NullableDateTimeOffsetSetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null })
                           .And(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null })
                           .Or(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("NullableDateTimeOffsetProperty", SetFilterType.In, new[] { (DateTimeOffset?)null })
                           .And("NullableDateTimeOffsetProperty", SetFilterType.In, new[] { (DateTimeOffset?)null })
                           .Or("NullableDateTimeOffsetProperty", SetFilterType.In, new[] { (DateTimeOffset?)null });

      var s = new FilterBuilder<TestObject>()
                           .Where(new DateTimeOffsetSetCriterion<TestObject>(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now }))
                           .Or(new DateTimeOffsetSetCriterion<TestObject>(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now }))
                           .And(new DateTimeOffsetSetCriterion<TestObject>(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now })
                           .Or(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now })
                           .And(to => to.DateTimeOffsetProperty, SetFilterType.In, new[] { DateTimeOffset.Now });
      var u = new FilterBuilder<TestObject>()
                           .Where("DateTimeOffsetProperty", SetFilterType.In, new[] { DateTimeOffset.Now })
                           .Or("DateTimeOffsetProperty", SetFilterType.In, new[] { DateTimeOffset.Now })
                           .And("DateTimeOffsetProperty", SetFilterType.In, new[] { DateTimeOffset.Now });

      var v = new FilterBuilder<TestObject>()
                           .Where(new NullableDateTimeOffsetSetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null }))
                           .Or(new NullableDateTimeOffsetSetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null }))
                           .And(new NullableDateTimeOffsetSetCriterion<TestObject>(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null })
                           .Or(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null })
                           .And(to => to.NullableDateTimeOffsetProperty, SetFilterType.In, new[] { (DateTimeOffset?)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("NullableDateTimeOffsetProperty", SetFilterType.In, new[] { (DateTimeOffset?)null })
                           .Or("NullableDateTimeOffsetProperty", SetFilterType.In, new[] { (DateTimeOffset?)null })
                           .And("NullableDateTimeOffsetProperty", SetFilterType.In, new[] { (DateTimeOffset?)null });
    }

    [TestMethod]
    public void DecimalTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new DecimalCriterion<TestObject>(to => to.DecimalProperty, NumericFilterType.Equals, 1))
                           .And(new DecimalCriterion<TestObject>(to => to.DecimalProperty, NumericFilterType.Equals, 1))
                           .Or(new DecimalCriterion<TestObject>(to => to.DecimalProperty, NumericFilterType.Equals, 1));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.DecimalProperty, NumericFilterType.Equals, 1)
                           .And(to => to.DecimalProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.DecimalProperty, NumericFilterType.Equals, 1);
      var c = new FilterBuilder<TestObject>()
                           .Where("DecimalProperty", NumericFilterType.Equals, 1)
                           .And("DecimalProperty", NumericFilterType.Equals, 1)
                           .Or("DecimalProperty", NumericFilterType.Equals, 1);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableDecimalCriterion<TestObject>(to => to.NullableDecimalProperty, NumericFilterType.Equals, null))
                           .And(new NullableDecimalCriterion<TestObject>(to => to.NullableDecimalProperty, NumericFilterType.Equals, null))
                           .Or(new NullableDecimalCriterion<TestObject>(to => to.NullableDecimalProperty, NumericFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDecimalProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableDecimalProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableDecimalProperty, NumericFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableDecimalProperty", NumericFilterType.Equals, null)
                           .And("NullableDecimalProperty", NumericFilterType.Equals, null)
                           .Or("NullableDecimalProperty", NumericFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new DecimalCriterion<TestObject>(to => to.DecimalProperty, NumericFilterType.Equals, 1))
                           .Or(new DecimalCriterion<TestObject>(to => to.DecimalProperty, NumericFilterType.Equals, 1))
                           .And(new DecimalCriterion<TestObject>(to => to.DecimalProperty, NumericFilterType.Equals, 1));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.DecimalProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.DecimalProperty, NumericFilterType.Equals, 1)
                           .And(to => to.DecimalProperty, NumericFilterType.Equals, 1);
      var i = new FilterBuilder<TestObject>()
                           .Where("DecimalProperty", NumericFilterType.Equals, 1)
                           .Or("DecimalProperty", NumericFilterType.Equals, 1)
                           .And("DecimalProperty", NumericFilterType.Equals, 1);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableDecimalCriterion<TestObject>(to => to.NullableDecimalProperty, NumericFilterType.Equals, null))
                           .Or(new NullableDecimalCriterion<TestObject>(to => to.NullableDecimalProperty, NumericFilterType.Equals, null))
                           .And(new NullableDecimalCriterion<TestObject>(to => to.NullableDecimalProperty, NumericFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDecimalProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableDecimalProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableDecimalProperty, NumericFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableDecimalProperty", NumericFilterType.Equals, null)
                           .Or("NullableDecimalProperty", NumericFilterType.Equals, null)
                           .And("NullableDecimalProperty", NumericFilterType.Equals, null);

      var m = new FilterBuilder<TestObject>()
                           .Where(new DecimalSetCriterion<TestObject>(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 }))
                           .And(new DecimalSetCriterion<TestObject>(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 }))
                           .Or(new DecimalSetCriterion<TestObject>(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 })
                           .And(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 })
                           .Or(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 });
      var o = new FilterBuilder<TestObject>()
                           .Where("DecimalProperty", SetFilterType.In, new[] { (decimal)1 })
                           .And("DecimalProperty", SetFilterType.In, new[] { (decimal)1 })
                           .Or("DecimalProperty", SetFilterType.In, new[] { (decimal)1 });

      var p = new FilterBuilder<TestObject>()
                           .Where(new NullableDecimalSetCriterion<TestObject>(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null }))
                           .And(new NullableDecimalSetCriterion<TestObject>(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null }))
                           .Or(new NullableDecimalSetCriterion<TestObject>(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null })
                           .And(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null })
                           .Or(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("NullableDecimalProperty", SetFilterType.In, new[] { (decimal?)null })
                           .And("NullableDecimalProperty", SetFilterType.In, new[] { (decimal?)null })
                           .Or("NullableDecimalProperty", SetFilterType.In, new[] { (decimal?)null });

      var s = new FilterBuilder<TestObject>()
                           .Where(new DecimalSetCriterion<TestObject>(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 }))
                           .Or(new DecimalSetCriterion<TestObject>(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 }))
                           .And(new DecimalSetCriterion<TestObject>(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 })
                           .Or(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 })
                           .And(to => to.DecimalProperty, SetFilterType.In, new[] { (decimal)1 });
      var u = new FilterBuilder<TestObject>()
                           .Where("DecimalProperty", SetFilterType.In, new[] { (decimal)1 })
                           .Or("DecimalProperty", SetFilterType.In, new[] { (decimal)1 })
                           .And("DecimalProperty", SetFilterType.In, new[] { (decimal)1 });

      var v = new FilterBuilder<TestObject>()
                           .Where(new NullableDecimalSetCriterion<TestObject>(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null }))
                           .Or(new NullableDecimalSetCriterion<TestObject>(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null }))
                           .And(new NullableDecimalSetCriterion<TestObject>(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null })
                           .Or(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null })
                           .And(to => to.NullableDecimalProperty, SetFilterType.In, new[] { (decimal?)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("NullableDecimalProperty", SetFilterType.In, new[] { (decimal?)null })
                           .Or("NullableDecimalProperty", SetFilterType.In, new[] { (decimal?)null })
                           .And("NullableDecimalProperty", SetFilterType.In, new[] { (decimal?)null });
    }

    [TestMethod]
    public void DoubleTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new DoubleCriterion<TestObject>(to => to.DoubleProperty, NumericFilterType.Equals, 1))
                           .And(new DoubleCriterion<TestObject>(to => to.DoubleProperty, NumericFilterType.Equals, 1))
                           .Or(new DoubleCriterion<TestObject>(to => to.DoubleProperty, NumericFilterType.Equals, 1));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.DoubleProperty, NumericFilterType.Equals, 1)
                           .And(to => to.DoubleProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.DoubleProperty, NumericFilterType.Equals, 1);
      var c = new FilterBuilder<TestObject>()
                           .Where("DoubleProperty", NumericFilterType.Equals, 1)
                           .And("DoubleProperty", NumericFilterType.Equals, 1)
                           .Or("DoubleProperty", NumericFilterType.Equals, 1);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableDoubleCriterion<TestObject>(to => to.NullableDoubleProperty, NumericFilterType.Equals, null))
                           .And(new NullableDoubleCriterion<TestObject>(to => to.NullableDoubleProperty, NumericFilterType.Equals, null))
                           .Or(new NullableDoubleCriterion<TestObject>(to => to.NullableDoubleProperty, NumericFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDoubleProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableDoubleProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableDoubleProperty, NumericFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableDoubleProperty", NumericFilterType.Equals, null)
                           .And("NullableDoubleProperty", NumericFilterType.Equals, null)
                           .Or("NullableDoubleProperty", NumericFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new DoubleCriterion<TestObject>(to => to.DoubleProperty, NumericFilterType.Equals, 1))
                           .Or(new DoubleCriterion<TestObject>(to => to.DoubleProperty, NumericFilterType.Equals, 1))
                           .And(new DoubleCriterion<TestObject>(to => to.DoubleProperty, NumericFilterType.Equals, 1));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.DoubleProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.DoubleProperty, NumericFilterType.Equals, 1)
                           .And(to => to.DoubleProperty, NumericFilterType.Equals, 1);
      var i = new FilterBuilder<TestObject>()
                           .Where("DoubleProperty", NumericFilterType.Equals, 1)
                           .Or("DoubleProperty", NumericFilterType.Equals, 1)
                           .And("DoubleProperty", NumericFilterType.Equals, 1);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableDoubleCriterion<TestObject>(to => to.NullableDoubleProperty, NumericFilterType.Equals, null))
                           .Or(new NullableDoubleCriterion<TestObject>(to => to.NullableDoubleProperty, NumericFilterType.Equals, null))
                           .And(new NullableDoubleCriterion<TestObject>(to => to.NullableDoubleProperty, NumericFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDoubleProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableDoubleProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableDoubleProperty, NumericFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableDoubleProperty", NumericFilterType.Equals, null)
                           .Or("NullableDoubleProperty", NumericFilterType.Equals, null)
                           .And("NullableDoubleProperty", NumericFilterType.Equals, null);

      var m = new FilterBuilder<TestObject>()
                     .Where(new DoubleSetCriterion<TestObject>(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 }))
                     .And(new DoubleSetCriterion<TestObject>(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 }))
                     .Or(new DoubleSetCriterion<TestObject>(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 })
                           .And(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 })
                           .Or(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 });
      var o = new FilterBuilder<TestObject>()
                           .Where("DoubleProperty", SetFilterType.In, new[] { 1.0 })
                           .And("DoubleProperty", SetFilterType.In, new[] { 1.0 })
                           .Or("DoubleProperty", SetFilterType.In, new[] { 1.0 });

      var p = new FilterBuilder<TestObject>()
                           .Where(new NullableDoubleSetCriterion<TestObject>(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null }))
                           .And(new NullableDoubleSetCriterion<TestObject>(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null }))
                           .Or(new NullableDoubleSetCriterion<TestObject>(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null })
                           .And(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null })
                           .Or(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("NullableDoubleProperty", SetFilterType.In, new[] { (double?)null })
                           .And("NullableDoubleProperty", SetFilterType.In, new[] { (double?)null })
                           .Or("NullableDoubleProperty", SetFilterType.In, new[] { (double?)null });

      var s = new FilterBuilder<TestObject>()
                           .Where(new DoubleSetCriterion<TestObject>(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 }))
                           .Or(new DoubleSetCriterion<TestObject>(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 }))
                           .And(new DoubleSetCriterion<TestObject>(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 })
                           .Or(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 })
                           .And(to => to.DoubleProperty, SetFilterType.In, new[] { 1.0 });
      var u = new FilterBuilder<TestObject>()
                           .Where("DoubleProperty", SetFilterType.In, new[] { 1.0 })
                           .Or("DoubleProperty", SetFilterType.In, new[] { 1.0 })
                           .And("DoubleProperty", SetFilterType.In, new[] { 1.0 });

      var v = new FilterBuilder<TestObject>()
                           .Where(new NullableDoubleSetCriterion<TestObject>(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null }))
                           .Or(new NullableDoubleSetCriterion<TestObject>(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null }))
                           .And(new NullableDoubleSetCriterion<TestObject>(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null })
                           .Or(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null })
                           .And(to => to.NullableDoubleProperty, SetFilterType.In, new[] { (double?)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("NullableDoubleProperty", SetFilterType.In, new[] { (double?)null })
                           .Or("NullableDoubleProperty", SetFilterType.In, new[] { (double?)null })
                           .And("NullableDoubleProperty", SetFilterType.In, new[] { (double?)null });
    }

    [TestMethod]
    public void FloatTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new FloatCriterion<TestObject>(to => to.FloatProperty, NumericFilterType.Equals, 1))
                           .And(new FloatCriterion<TestObject>(to => to.FloatProperty, NumericFilterType.Equals, 1))
                           .Or(new FloatCriterion<TestObject>(to => to.FloatProperty, NumericFilterType.Equals, 1));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.FloatProperty, NumericFilterType.Equals, 1)
                           .And(to => to.FloatProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.FloatProperty, NumericFilterType.Equals, 1);
      var c = new FilterBuilder<TestObject>()
                           .Where("FloatProperty", NumericFilterType.Equals, 1)
                           .And("FloatProperty", NumericFilterType.Equals, 1)
                           .Or("FloatProperty", NumericFilterType.Equals, 1);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableFloatCriterion<TestObject>(to => to.NullableFloatProperty, NumericFilterType.Equals, null))
                           .And(new NullableFloatCriterion<TestObject>(to => to.NullableFloatProperty, NumericFilterType.Equals, null))
                           .Or(new NullableFloatCriterion<TestObject>(to => to.NullableFloatProperty, NumericFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableFloatProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableFloatProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableFloatProperty, NumericFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableFloatProperty", NumericFilterType.Equals, null)
                           .And("NullableFloatProperty", NumericFilterType.Equals, null)
                           .Or("NullableFloatProperty", NumericFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new FloatCriterion<TestObject>(to => to.FloatProperty, NumericFilterType.Equals, 1))
                           .Or(new FloatCriterion<TestObject>(to => to.FloatProperty, NumericFilterType.Equals, 1))
                           .And(new FloatCriterion<TestObject>(to => to.FloatProperty, NumericFilterType.Equals, 1));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.FloatProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.FloatProperty, NumericFilterType.Equals, 1)
                           .And(to => to.FloatProperty, NumericFilterType.Equals, 1);
      var i = new FilterBuilder<TestObject>()
                           .Where("FloatProperty", NumericFilterType.Equals, 1)
                           .Or("FloatProperty", NumericFilterType.Equals, 1)
                           .And("FloatProperty", NumericFilterType.Equals, 1);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableFloatCriterion<TestObject>(to => to.NullableFloatProperty, NumericFilterType.Equals, null))
                           .Or(new NullableFloatCriterion<TestObject>(to => to.NullableFloatProperty, NumericFilterType.Equals, null))
                           .And(new NullableFloatCriterion<TestObject>(to => to.NullableFloatProperty, NumericFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableFloatProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableFloatProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableFloatProperty, NumericFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableFloatProperty", NumericFilterType.Equals, null)
                           .Or("NullableFloatProperty", NumericFilterType.Equals, null)
                           .And("NullableFloatProperty", NumericFilterType.Equals, null);

      var m = new FilterBuilder<TestObject>()
                           .Where(new FloatSetCriterion<TestObject>(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 }))
                           .And(new FloatSetCriterion<TestObject>(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 }))
                           .Or(new FloatSetCriterion<TestObject>(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 })
                           .And(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 })
                           .Or(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 });
      var o = new FilterBuilder<TestObject>()
                           .Where("FloatProperty", SetFilterType.In, new[] { (float)1 })
                           .And("FloatProperty", SetFilterType.In, new[] { (float)1 })
                           .Or("FloatProperty", SetFilterType.In, new[] { (float)1 });

      var p = new FilterBuilder<TestObject>()
                           .Where(new NullableFloatSetCriterion<TestObject>(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null }))
                           .And(new NullableFloatSetCriterion<TestObject>(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null }))
                           .Or(new NullableFloatSetCriterion<TestObject>(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null })
                           .And(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null })
                           .Or(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("NullableFloatProperty", SetFilterType.In, new[] { (float?)null })
                           .And("NullableFloatProperty", SetFilterType.In, new[] { (float?)null })
                           .Or("NullableFloatProperty", SetFilterType.In, new[] { (float?)null });

      var s = new FilterBuilder<TestObject>()
                           .Where(new FloatSetCriterion<TestObject>(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 }))
                           .Or(new FloatSetCriterion<TestObject>(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 }))
                           .And(new FloatSetCriterion<TestObject>(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 })
                           .Or(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 })
                           .And(to => to.FloatProperty, SetFilterType.In, new[] { (float)1 });
      var u = new FilterBuilder<TestObject>()
                           .Where("FloatProperty", SetFilterType.In, new[] { (float)1 })
                           .Or("FloatProperty", SetFilterType.In, new[] { (float)1 })
                           .And("FloatProperty", SetFilterType.In, new[] { (float)1 });

      var v = new FilterBuilder<TestObject>()
                           .Where(new NullableFloatSetCriterion<TestObject>(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null }))
                           .Or(new NullableFloatSetCriterion<TestObject>(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null }))
                           .And(new NullableFloatSetCriterion<TestObject>(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null })
                           .Or(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null })
                           .And(to => to.NullableFloatProperty, SetFilterType.In, new[] { (float?)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("NullableFloatProperty", SetFilterType.In, new[] { (float?)null })
                           .Or("NullableFloatProperty", SetFilterType.In, new[] { (float?)null })
                           .And("NullableFloatProperty", SetFilterType.In, new[] { (float?)null });
    }

    [TestMethod]
    public void IntegerTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new IntegerCriterion<TestObject>(to => to.IntegerProperty, NumericFilterType.Equals, 1))
                           .And(new IntegerCriterion<TestObject>(to => to.IntegerProperty, NumericFilterType.Equals, 1))
                           .Or(new IntegerCriterion<TestObject>(to => to.IntegerProperty, NumericFilterType.Equals, 1));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.IntegerProperty, NumericFilterType.Equals, 1)
                           .And(to => to.IntegerProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.IntegerProperty, NumericFilterType.Equals, 1);
      var c = new FilterBuilder<TestObject>()
                           .Where("IntegerProperty", NumericFilterType.Equals, 1)
                           .And("IntegerProperty", NumericFilterType.Equals, 1)
                           .Or("IntegerProperty", NumericFilterType.Equals, 1);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableIntegerCriterion<TestObject>(to => to.NullableIntegerProperty, NumericFilterType.Equals, null))
                           .And(new NullableIntegerCriterion<TestObject>(to => to.NullableIntegerProperty, NumericFilterType.Equals, null))
                           .Or(new NullableIntegerCriterion<TestObject>(to => to.NullableIntegerProperty, NumericFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableIntegerProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableIntegerProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableIntegerProperty, NumericFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableIntegerProperty", NumericFilterType.Equals, null)
                           .And("NullableIntegerProperty", NumericFilterType.Equals, null)
                           .Or("NullableIntegerProperty", NumericFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new IntegerCriterion<TestObject>(to => to.IntegerProperty, NumericFilterType.Equals, 1))
                           .Or(new IntegerCriterion<TestObject>(to => to.IntegerProperty, NumericFilterType.Equals, 1))
                           .And(new IntegerCriterion<TestObject>(to => to.IntegerProperty, NumericFilterType.Equals, 1));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.IntegerProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.IntegerProperty, NumericFilterType.Equals, 1)
                           .And(to => to.IntegerProperty, NumericFilterType.Equals, 1);
      var i = new FilterBuilder<TestObject>()
                           .Where("IntegerProperty", NumericFilterType.Equals, 1)
                           .Or("IntegerProperty", NumericFilterType.Equals, 1)
                           .And("IntegerProperty", NumericFilterType.Equals, 1);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableIntegerCriterion<TestObject>(to => to.NullableIntegerProperty, NumericFilterType.Equals, null))
                           .Or(new NullableIntegerCriterion<TestObject>(to => to.NullableIntegerProperty, NumericFilterType.Equals, null))
                           .And(new NullableIntegerCriterion<TestObject>(to => to.NullableIntegerProperty, NumericFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableIntegerProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableIntegerProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableIntegerProperty, NumericFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableIntegerProperty", NumericFilterType.Equals, null)
                           .Or("NullableIntegerProperty", NumericFilterType.Equals, null)
                           .And("NullableIntegerProperty", NumericFilterType.Equals, null);

      var m = new FilterBuilder<TestObject>()
                           .Where(new IntegerSetCriterion<TestObject>(to => to.IntegerProperty, SetFilterType.In, new[] { 1 }))
                           .And(new IntegerSetCriterion<TestObject>(to => to.IntegerProperty, SetFilterType.In, new[] { 1 }))
                           .Or(new IntegerSetCriterion<TestObject>(to => to.IntegerProperty, SetFilterType.In, new[] { 1 }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.IntegerProperty, SetFilterType.In, new[] { 1 })
                           .And(to => to.IntegerProperty, SetFilterType.In, new[] { 1 })
                           .Or(to => to.IntegerProperty, SetFilterType.In, new[] { 1 });
      var o = new FilterBuilder<TestObject>()
                           .Where("IntegerProperty", SetFilterType.In, new[] { 1 })
                           .And("IntegerProperty", SetFilterType.In, new[] { 1 })
                           .Or("IntegerProperty", SetFilterType.In, new[] { 1 });

      var p = new FilterBuilder<TestObject>()
                           .Where(new NullableIntegerSetCriterion<TestObject>(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null }))
                           .And(new NullableIntegerSetCriterion<TestObject>(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null }))
                           .Or(new NullableIntegerSetCriterion<TestObject>(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null })
                           .And(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null })
                           .Or(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("NullableIntegerProperty", SetFilterType.In, new[] { (int?)null })
                           .And("NullableIntegerProperty", SetFilterType.In, new[] { (int?)null })
                           .Or("NullableIntegerProperty", SetFilterType.In, new[] { (int?)null });

      var s = new FilterBuilder<TestObject>()
                           .Where(new IntegerSetCriterion<TestObject>(to => to.IntegerProperty, SetFilterType.In, new[] { 1 }))
                           .Or(new IntegerSetCriterion<TestObject>(to => to.IntegerProperty, SetFilterType.In, new[] { 1 }))
                           .And(new IntegerSetCriterion<TestObject>(to => to.IntegerProperty, SetFilterType.In, new[] { 1 }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.IntegerProperty, SetFilterType.In, new[] { 1 })
                           .Or(to => to.IntegerProperty, SetFilterType.In, new[] { 1 })
                           .And(to => to.IntegerProperty, SetFilterType.In, new[] { 1 });
      var u = new FilterBuilder<TestObject>()
                           .Where("IntegerProperty", SetFilterType.In, new[] { 1 })
                           .Or("IntegerProperty", SetFilterType.In, new[] { 1 })
                           .And("IntegerProperty", SetFilterType.In, new[] { 1 });

      var v = new FilterBuilder<TestObject>()
                           .Where(new NullableIntegerSetCriterion<TestObject>(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null }))
                           .Or(new NullableIntegerSetCriterion<TestObject>(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null }))
                           .And(new NullableIntegerSetCriterion<TestObject>(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null })
                           .Or(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null })
                           .And(to => to.NullableIntegerProperty, SetFilterType.In, new[] { (int?)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("NullableIntegerProperty", SetFilterType.In, new[] { (int?)null })
                           .Or("NullableIntegerProperty", SetFilterType.In, new[] { (int?)null })
                           .And("NullableIntegerProperty", SetFilterType.In, new[] { (int?)null });
    }

    [TestMethod]
    public void LongTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new LongCriterion<TestObject>(to => to.LongProperty, NumericFilterType.Equals, 1))
                           .And(new LongCriterion<TestObject>(to => to.LongProperty, NumericFilterType.Equals, 1))
                           .Or(new LongCriterion<TestObject>(to => to.LongProperty, NumericFilterType.Equals, 1));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.LongProperty, NumericFilterType.Equals, 1)
                           .And(to => to.LongProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.LongProperty, NumericFilterType.Equals, 1);
      var c = new FilterBuilder<TestObject>()
                           .Where("LongProperty", NumericFilterType.Equals, 1)
                           .And("LongProperty", NumericFilterType.Equals, 1)
                           .Or("LongProperty", NumericFilterType.Equals, 1);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableLongCriterion<TestObject>(to => to.NullableLongProperty, NumericFilterType.Equals, null))
                           .And(new NullableLongCriterion<TestObject>(to => to.NullableLongProperty, NumericFilterType.Equals, null))
                           .Or(new NullableLongCriterion<TestObject>(to => to.NullableLongProperty, NumericFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableLongProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableLongProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableLongProperty, NumericFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableLongProperty", NumericFilterType.Equals, null)
                           .And("NullableLongProperty", NumericFilterType.Equals, null)
                           .Or("NullableLongProperty", NumericFilterType.Equals, null);
      var g = new FilterBuilder<TestObject>()
                           .Where(new LongCriterion<TestObject>(to => to.LongProperty, NumericFilterType.Equals, 1))
                           .Or(new LongCriterion<TestObject>(to => to.LongProperty, NumericFilterType.Equals, 1))
                           .And(new LongCriterion<TestObject>(to => to.LongProperty, NumericFilterType.Equals, 1));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.LongProperty, NumericFilterType.Equals, 1)
                           .Or(to => to.LongProperty, NumericFilterType.Equals, 1)
                           .And(to => to.LongProperty, NumericFilterType.Equals, 1);
      var i = new FilterBuilder<TestObject>()
                           .Where("LongProperty", NumericFilterType.Equals, 1)
                           .Or("LongProperty", NumericFilterType.Equals, 1)
                           .And("LongProperty", NumericFilterType.Equals, 1);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableLongCriterion<TestObject>(to => to.NullableLongProperty, NumericFilterType.Equals, null))
                           .Or(new NullableLongCriterion<TestObject>(to => to.NullableLongProperty, NumericFilterType.Equals, null))
                           .And(new NullableLongCriterion<TestObject>(to => to.NullableLongProperty, NumericFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableLongProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableLongProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableLongProperty, NumericFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableLongProperty", NumericFilterType.Equals, null)
                           .Or("NullableLongProperty", NumericFilterType.Equals, null)
                           .And("NullableLongProperty", NumericFilterType.Equals, null);

      var m = new FilterBuilder<TestObject>()
                     .Where(new LongSetCriterion<TestObject>(to => to.LongProperty, SetFilterType.In, new[] { (long)1 }))
                     .And(new LongSetCriterion<TestObject>(to => to.LongProperty, SetFilterType.In, new[] { (long)1 }))
                     .Or(new LongSetCriterion<TestObject>(to => to.LongProperty, SetFilterType.In, new[] { (long)1 }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.LongProperty, SetFilterType.In, new[] { (long)1 })
                           .And(to => to.LongProperty, SetFilterType.In, new[] { (long)1 })
                           .Or(to => to.LongProperty, SetFilterType.In, new[] { (long)1 });
      var o = new FilterBuilder<TestObject>()
                           .Where("LongProperty", SetFilterType.In, new[] { (long)1 })
                           .And("LongProperty", SetFilterType.In, new[] { (long)1 })
                           .Or("LongProperty", SetFilterType.In, new[] { (long)1 });

      var p = new FilterBuilder<TestObject>()
                           .Where(new NullableLongSetCriterion<TestObject>(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null }))
                           .And(new NullableLongSetCriterion<TestObject>(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null }))
                           .Or(new NullableLongSetCriterion<TestObject>(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null })
                           .And(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null })
                           .Or(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("NullableLongProperty", SetFilterType.In, new[] { (long?)null })
                           .And("NullableLongProperty", SetFilterType.In, new[] { (long?)null })
                           .Or("NullableLongProperty", SetFilterType.In, new[] { (long?)null });
      var s = new FilterBuilder<TestObject>()
                           .Where(new LongSetCriterion<TestObject>(to => to.LongProperty, SetFilterType.In, new[] { (long)1 }))
                           .Or(new LongSetCriterion<TestObject>(to => to.LongProperty, SetFilterType.In, new[] { (long)1 }))
                           .And(new LongSetCriterion<TestObject>(to => to.LongProperty, SetFilterType.In, new[] { (long)1 }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.LongProperty, SetFilterType.In, new[] { (long)1 })
                           .Or(to => to.LongProperty, SetFilterType.In, new[] { (long)1 })
                           .And(to => to.LongProperty, SetFilterType.In, new[] { (long)1 });
      var u = new FilterBuilder<TestObject>()
                           .Where("LongProperty", SetFilterType.In, new[] { (long)1 })
                           .Or("LongProperty", SetFilterType.In, new[] { (long)1 })
                           .And("LongProperty", SetFilterType.In, new[] { (long)1 });

      var v = new FilterBuilder<TestObject>()
                           .Where(new NullableLongSetCriterion<TestObject>(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null }))
                           .Or(new NullableLongSetCriterion<TestObject>(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null }))
                           .And(new NullableLongSetCriterion<TestObject>(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null })
                           .Or(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null })
                           .And(to => to.NullableLongProperty, SetFilterType.In, new[] { (long?)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("NullableLongProperty", SetFilterType.In, new[] { (long?)null })
                           .Or("NullableLongProperty", SetFilterType.In, new[] { (long?)null })
                           .And("NullableLongProperty", SetFilterType.In, new[] { (long?)null });
    }

    [TestMethod]
    public void ShortTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new ShortCriterion<TestObject>(to => to.ShortProperty, NumericFilterType.Equals, 1))
                           .And(new ShortCriterion<TestObject>(to => to.ShortProperty, NumericFilterType.Equals, 1))
                           .Or(new ShortCriterion<TestObject>(to => to.ShortProperty, NumericFilterType.Equals, 1));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.ShortProperty, NumericFilterType.Equals, (short)1)
                           .And(to => to.ShortProperty, NumericFilterType.Equals, (short)1)
                           .Or(to => to.ShortProperty, NumericFilterType.Equals, (short)1);
      var c = new FilterBuilder<TestObject>()
                           .Where("ShortProperty", NumericFilterType.Equals, 1)
                           .And("ShortProperty", NumericFilterType.Equals, 1)
                           .Or("ShortProperty", NumericFilterType.Equals, 1);

      var d = new FilterBuilder<TestObject>()
                           .Where(new NullableShortCriterion<TestObject>(to => to.NullableShortProperty, NumericFilterType.Equals, null))
                           .And(new NullableShortCriterion<TestObject>(to => to.NullableShortProperty, NumericFilterType.Equals, null))
                           .Or(new NullableShortCriterion<TestObject>(to => to.NullableShortProperty, NumericFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableShortProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableShortProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableShortProperty, NumericFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("NullableShortProperty", NumericFilterType.Equals, null)
                           .And("NullableShortProperty", NumericFilterType.Equals, null)
                           .Or("NullableShortProperty", NumericFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new ShortCriterion<TestObject>(to => to.ShortProperty, NumericFilterType.Equals, 1))
                           .Or(new ShortCriterion<TestObject>(to => to.ShortProperty, NumericFilterType.Equals, 1))
                           .And(new ShortCriterion<TestObject>(to => to.ShortProperty, NumericFilterType.Equals, 1));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.ShortProperty, NumericFilterType.Equals, (short)1)
                           .Or(to => to.ShortProperty, NumericFilterType.Equals, (short)1)
                           .And(to => to.ShortProperty, NumericFilterType.Equals, (short)1);
      var i = new FilterBuilder<TestObject>()
                           .Where("ShortProperty", NumericFilterType.Equals, 1)
                           .Or("ShortProperty", NumericFilterType.Equals, 1)
                           .And("ShortProperty", NumericFilterType.Equals, 1);

      var j = new FilterBuilder<TestObject>()
                           .Where(new NullableShortCriterion<TestObject>(to => to.NullableShortProperty, NumericFilterType.Equals, null))
                           .Or(new NullableShortCriterion<TestObject>(to => to.NullableShortProperty, NumericFilterType.Equals, null))
                           .And(new NullableShortCriterion<TestObject>(to => to.NullableShortProperty, NumericFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableShortProperty, NumericFilterType.Equals, null)
                           .Or(to => to.NullableShortProperty, NumericFilterType.Equals, null)
                           .And(to => to.NullableShortProperty, NumericFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("NullableShortProperty", NumericFilterType.Equals, null)
                           .Or("NullableShortProperty", NumericFilterType.Equals, null)
                           .And("NullableShortProperty", NumericFilterType.Equals, null);

      var m = new FilterBuilder<TestObject>()
                           .Where(new ShortSetCriterion<TestObject>(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 }))
                           .And(new ShortSetCriterion<TestObject>(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 }))
                           .Or(new ShortSetCriterion<TestObject>(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 })
                           .And(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 })
                           .Or(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 });
      var o = new FilterBuilder<TestObject>()
                           .Where("ShortProperty", SetFilterType.In, new[] { (short)1 })
                           .And("ShortProperty", SetFilterType.In, new[] { (short)1 })
                           .Or("ShortProperty", SetFilterType.In, new[] { (short)1 });

      var p = new FilterBuilder<TestObject>()
                           .Where(new NullableShortSetCriterion<TestObject>(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null }))
                           .And(new NullableShortSetCriterion<TestObject>(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null }))
                           .Or(new NullableShortSetCriterion<TestObject>(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null })
                           .And(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null })
                           .Or(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("NullableShortProperty", SetFilterType.In, new[] { (short?)null })
                           .And("NullableShortProperty", SetFilterType.In, new[] { (short?)null })
                           .Or("NullableShortProperty", SetFilterType.In, new[] { (short?)null });

      var s = new FilterBuilder<TestObject>()
                           .Where(new ShortSetCriterion<TestObject>(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 }))
                           .Or(new ShortSetCriterion<TestObject>(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 }))
                           .And(new ShortSetCriterion<TestObject>(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 })
                           .Or(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 })
                           .And(to => to.ShortProperty, SetFilterType.In, new[] { (short)1 });
      var u = new FilterBuilder<TestObject>()
                           .Where("ShortProperty", SetFilterType.In, new[] { (short)1 })
                           .Or("ShortProperty", SetFilterType.In, new[] { (short)1 })
                           .And("ShortProperty", SetFilterType.In, new[] { (short)1 });

      var v = new FilterBuilder<TestObject>()
                           .Where(new NullableShortSetCriterion<TestObject>(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null }))
                           .Or(new NullableShortSetCriterion<TestObject>(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null }))
                           .And(new NullableShortSetCriterion<TestObject>(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null })
                           .Or(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null })
                           .And(to => to.NullableShortProperty, SetFilterType.In, new[] { (short?)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("NullableShortProperty", SetFilterType.In, new[] { (short?)null })
                           .Or("NullableShortProperty", SetFilterType.In, new[] { (short?)null })
                           .And("NullableShortProperty", SetFilterType.In, new[] { (short?)null });
    }

    [TestMethod]
    public void StringTests()
    {
      var a = new FilterBuilder<TestObject>()
                           .Where(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, string.Empty))
                           .And(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, string.Empty))
                           .Or(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, string.Empty));
      var b = new FilterBuilder<TestObject>()
                           .Where(to => to.StringProperty, StringFilterType.Equals, string.Empty)
                           .And(to => to.StringProperty, StringFilterType.Equals, string.Empty)
                           .Or(to => to.StringProperty, StringFilterType.Equals, string.Empty);
      var c = new FilterBuilder<TestObject>()
                           .Where("StringProperty", StringFilterType.Equals, string.Empty)
                           .And("StringProperty", StringFilterType.Equals, string.Empty)
                           .Or("StringProperty", StringFilterType.Equals, string.Empty);

      var d = new FilterBuilder<TestObject>()
                           .Where(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, null))
                           .And(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, null))
                           .Or(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, null));
      var e = new FilterBuilder<TestObject>()
                           .Where(to => to.StringProperty, StringFilterType.Equals, null)
                           .And(to => to.StringProperty, StringFilterType.Equals, null)
                           .Or(to => to.StringProperty, StringFilterType.Equals, null);
      var f = new FilterBuilder<TestObject>()
                           .Where("StringProperty", StringFilterType.Equals, null)
                           .And("StringProperty", StringFilterType.Equals, null)
                           .Or("StringProperty", StringFilterType.Equals, null);

      var g = new FilterBuilder<TestObject>()
                           .Where(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, string.Empty))
                           .Or(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, string.Empty))
                           .And(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, string.Empty));
      var h = new FilterBuilder<TestObject>()
                           .Where(to => to.StringProperty, StringFilterType.Equals, string.Empty)
                           .Or(to => to.StringProperty, StringFilterType.Equals, string.Empty)
                           .And(to => to.StringProperty, StringFilterType.Equals, string.Empty);
      var i = new FilterBuilder<TestObject>()
                           .Where("StringProperty", StringFilterType.Equals, string.Empty)
                           .Or("StringProperty", StringFilterType.Equals, string.Empty)
                           .And("StringProperty", StringFilterType.Equals, string.Empty);

      var j = new FilterBuilder<TestObject>()
                           .Where(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, null))
                           .Or(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, null))
                           .And(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, null));
      var k = new FilterBuilder<TestObject>()
                           .Where(to => to.StringProperty, StringFilterType.Equals, null)
                           .Or(to => to.StringProperty, StringFilterType.Equals, null)
                           .And(to => to.StringProperty, StringFilterType.Equals, null);
      var l = new FilterBuilder<TestObject>()
                           .Where("StringProperty", StringFilterType.Equals, null)
                           .Or("StringProperty", StringFilterType.Equals, null)
                           .And("StringProperty", StringFilterType.Equals, null);

      var m = new FilterBuilder<TestObject>()
                           .Where(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { string.Empty }))
                           .And(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { string.Empty }))
                           .Or(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { string.Empty }));
      var n = new FilterBuilder<TestObject>()
                           .Where(to => to.StringProperty, SetFilterType.In, new[] { string.Empty })
                           .And(to => to.StringProperty, SetFilterType.In, new[] { string.Empty })
                           .Or(to => to.StringProperty, SetFilterType.In, new[] { string.Empty });
      var o = new FilterBuilder<TestObject>()
                           .Where("StringProperty", SetFilterType.In, new[] { string.Empty })
                           .And("StringProperty", SetFilterType.In, new[] { string.Empty })
                           .Or("StringProperty", SetFilterType.In, new[] { string.Empty });

      var p = new FilterBuilder<TestObject>()
                           .Where(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { (string)null }))
                           .And(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { (string)null }))
                           .Or(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { (string)null }));
      var q = new FilterBuilder<TestObject>()
                           .Where(to => to.StringProperty, SetFilterType.In, new[] { (string)null })
                           .And(to => to.StringProperty, SetFilterType.In, new[] { (string)null })
                           .Or(to => to.StringProperty, SetFilterType.In, new[] { (string)null });
      var r = new FilterBuilder<TestObject>()
                           .Where("StringProperty", SetFilterType.In, new[] { (string)null })
                           .And("StringProperty", SetFilterType.In, new[] { (string)null })
                           .Or("StringProperty", SetFilterType.In, new[] { (string)null });

      var s = new FilterBuilder<TestObject>()
                           .Where(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { string.Empty }))
                           .Or(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { string.Empty }))
                           .And(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { string.Empty }));
      var t = new FilterBuilder<TestObject>()
                           .Where(to => to.StringProperty, SetFilterType.In, new[] { string.Empty })
                           .Or(to => to.StringProperty, SetFilterType.In, new[] { string.Empty })
                           .And(to => to.StringProperty, SetFilterType.In, new[] { string.Empty });
      var u = new FilterBuilder<TestObject>()
                           .Where("StringProperty", SetFilterType.In, new[] { string.Empty })
                           .Or("StringProperty", SetFilterType.In, new[] { string.Empty })
                           .And("StringProperty", SetFilterType.In, new[] { string.Empty });

      var v = new FilterBuilder<TestObject>()
                           .Where(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { (string)null }))
                           .Or(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { (string)null }))
                           .And(new StringSetCriterion<TestObject>(to => to.StringProperty, SetFilterType.In, new[] { (string)null }));
      var w = new FilterBuilder<TestObject>()
                           .Where(to => to.StringProperty, SetFilterType.In, new[] { (string)null })
                           .Or(to => to.StringProperty, SetFilterType.In, new[] { (string)null })
                           .And(to => to.StringProperty, SetFilterType.In, new[] { (string)null });
      var x = new FilterBuilder<TestObject>()
                           .Where("StringProperty", SetFilterType.In, new[] { (string)null })
                           .Or("StringProperty", SetFilterType.In, new[] { (string)null })
                           .And("StringProperty", SetFilterType.In, new[] { (string)null });
    }
  }
}
