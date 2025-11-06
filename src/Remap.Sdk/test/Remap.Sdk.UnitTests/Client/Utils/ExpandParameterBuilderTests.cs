using System;
using System.Collections.Generic;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.UnitTests.Client
{
    public class ExpandParameterBuilderTests
    {
        [Test]
        public void Double_With_should_add_Expander_with_two_properties()
        {
            var expanders = new List<string>();
            var subject = new ExpandParameterBuilder<TestExpandMetaEntity>(expanders);

            subject.ThenBy(p => p.L1Entity).ThenBy(p => p.L1Entity.L2Entity);

            expanders.Should().HaveCount(2);
            expanders[0].Should().Be("entity_one_level");
            expanders[1].Should().Be("entity_one_level.entity_two_level");
        }

        [Test]
        public void If_expand_is_not_allowed_then_By_should_throw_api_exception()
        {
            var expanders = new List<string>();
            var subject = new ExpandParameterBuilder<TestExpandMetaEntity>(expanders);

            Action action = () => subject.ThenBy(p => p.NotAllowedExpandMember);

            action.Should().Throw<ApiException>();
        }

        [Test]
        public void With_should_add_Expander()
        {
            var expanders = new List<string>();
            var subject = new ExpandParameterBuilder<TestExpandMetaEntity>(expanders);

            subject.ThenBy(p => p.L1Entity.L2Entity);

            expanders.Should().HaveCount(1);
            expanders[0].Should().Be("entity_one_level.entity_two_level");
        }
    }

    internal class L1TestExpandMetaEntity
    {
        [AllowExpand]
        [Parameter("entity_two_level")]
        public L2TestExpandMetaEntity L2Entity { get; set; }
    }

    internal class L2TestExpandMetaEntity
    {
    }

    internal class TestExpandMetaEntity
    {
        [AllowExpand]
        [Parameter("entity_one_level")]
        public L1TestExpandMetaEntity L1Entity { get; set; }

        [Parameter("entity_one_level")]
        public L1TestExpandMetaEntity NotAllowedExpandMember { get; set; }
    }
}