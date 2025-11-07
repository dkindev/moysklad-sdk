using System;
using System.Collections.Generic;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.UnitTests.Client
{
    public class OrderParameterBuilderTests
    {
        [Test]
        public void By_should_add_Order()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            subject.ThenBy(p => p.StringProperty);

            orders.Should().HaveCount(1);
            orders["stringproperty"].Should().Be(OrderBy.Asc);
        }

        [Test]
        public void By_with_nested_parameters_should_throw_api_exception()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            Action action = () => subject.ThenBy(p => p.NestedEntity.StringProperty);

            action.Should().Throw<MoySkladException>();
        }

        [Test]
        public void Double_By_should_add_Order_by_two_properties()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            subject.ThenBy(p => p.StringProperty).ThenBy(p => p.IntProperty, OrderBy.Desc);

            orders.Should().HaveCount(2);
            orders["stringproperty"].Should().Be(OrderBy.Asc);
            orders["intproperty"].Should().Be(OrderBy.Desc);
        }

        [Test]
        public void If_order_is_not_allowed_then_By_should_throw_api_exception()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            Action action = () => subject.ThenBy(p => p.NotAllowedOrderMember);

            action.Should().Throw<MoySkladException>();
        }
    }

    internal class NestedTestMetaEntity
    {
        [AllowOrder]
        [Parameter("stringproperty")]
        public string StringProperty { get; set; }
    }

    internal class TestMetaEntity
    {
        [AllowOrder]
        [Parameter("intproperty")]
        public string IntProperty { get; set; }

        public NestedTestMetaEntity NestedEntity { get; set; }

        [Parameter("notAllowedOrderMember")]
        public string NotAllowedOrderMember { get; set; }

        [AllowOrder]
        [Parameter("stringproperty")]
        public string StringProperty { get; set; }
    }
}