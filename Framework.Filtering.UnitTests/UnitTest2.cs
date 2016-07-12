using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeinearyDevelopment.Framework.Filtering.FilterBuilders;
using PeinearyDevelopment.Framework.Filtering.FilterBuilders.Extensions;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets;
using PeinearyDevelopment.Framework.Filtering.FilterTypes;

namespace Framework.Filtering.UnitTests
{
  [TestClass]
  public class UnitTest2
  {
    [TestMethod]
    public void TestMethod1()
    {
      var ds = new FilterBuilder<TestObject>()
                                 .Where(to => to.BooleanProperty, BooleanFilterType.Equals, true)
                                 .And(to => to.DateTimeProperty, DateTimeFilterType.After, DateTime.MaxValue)
                                 .And(to => to.DateTimeOffsetProperty, DateTimeFilterType.Before, DateTimeOffset.MinValue)
                                 .Or(to => to.DecimalProperty, NumericFilterType.DoesNotEqual, -1)
                                 .Or(to => to.DoubleProperty, NumericFilterType.LessThan, null)
                                 .And(to => to.FloatProperty, NumericFilterType.GreaterThanOrEquals, 5)
                                 .Or(to => to.IntegerProperty, NumericFilterType.LessThanOrEquals, 03982)
                                 .And(to => to.LongProperty, NumericFilterType.GreaterThanOrEquals, 94879348)
                                 .And(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Contains, "foo")
                                          .And(new DateTimeCriterion<TestObject>(to => to.DateTimeProperty, DateTimeFilterType.After, DateTime.MinValue)
                                                  .Or(new FloatCriterion<TestObject>(to => to.FloatProperty, NumericFilterType.Equals, 390))
                                          )
                                  );

      var dt = new FilterBuilder<TestObject>()
                           .Where(to => to.DateTimeProperty, DateTimeFilterType.After, DateTime.Now.AddMonths(-1))
                           .And(to => to.DateTimeProperty, DateTimeFilterType.BeforeOrEquals, DateTime.Now)
                           .And(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, "50000011-01")
                                    .Or(new StringCriterion<TestObject>(to => to.StringProperty, StringFilterType.Equals, "50000018-01"))
                            );
    }
  }
}
