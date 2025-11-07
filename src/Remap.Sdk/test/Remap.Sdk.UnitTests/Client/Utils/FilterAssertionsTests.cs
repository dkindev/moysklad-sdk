using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.UnitTests.Client
{
    public class FilterAssertionsTests
    {
        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Assertion_should_add_filter(string @operator)
        {
            var guid = Guid.NewGuid();
            var filters = new List<FilterItem>();
            Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.GuidMember;
            var subject = new GuidFilterAssertions(expression, filters);

            if (@operator == "=")
                subject.Be(guid);
            else if (@operator == "!=")
                subject.NotBe(guid);

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("guidMember");
            filters[0].Operator.Should().Be(@operator);
            filters[0].Value.Should().Be(guid.ToString());
        }

        [Test]
        public void Assertion_with_not_allowed_filter_member_should_throw_api_exception()
        {
            Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.NotFilteredMember;
            Action assertion = () => new GuidFilterAssertions(expression, new List<FilterItem>());

            assertion.Should().Throw<MoySkladException>();
        }

        [Test]
        public void Assertion_with_not_allowed_nesting_filter_member_should_throw_api_exception()
        {
            Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.AllowedNestingFilterMember.NestingNotFilteredMember;
            Action assertion = () => new GuidFilterAssertions(expression, new List<FilterItem>());

            assertion.Should().Throw<MoySkladException>();
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Assertion_with_null_value_should_add_filter(string @operator)
        {
            var guid = Guid.NewGuid();
            var filters = new List<FilterItem>();
            Expression<Func<GuidAssertionsTestEntity, Guid?>> expression = p => p.NullableMember;
            var subject = new NullableGuidFilterAssertions(expression, filters);

            if (@operator == "=")
                subject.BeNull();
            else if (@operator == "!=")
                subject.NotBeNull();

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("nullableMember");
            filters[0].Operator.Should().Be(@operator);
            filters[0].Value.Should().BeNull();
        }

        [Test]
        [TestCase("=", new string[] { "=" })]
        [TestCase("!=", new string[] { "!=" })]
        public void If_AllowContinueConstraint_not_allowed_then_Assertion_with_other_Assertions_on_same_member_should_throw_api_exception(string @operator, string[] allowedOperators)
        {
            foreach (var allowedOperator in allowedOperators)
            {
                var guid = Guid.NewGuid();
                var filters = new List<FilterItem>(new[] { new FilterItem("notAllowedContinueConstraintMember", @operator, "foo") });
                Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.NotAllowedContinueConstraintMember;
                var subject = new GuidFilterAssertions(expression, filters);

                Action assertion = null;

                if (allowedOperator == "=")
                    assertion = () => subject.Be(guid);
                if (allowedOperator == "!=")
                    assertion = () => subject.NotBe(guid);

                assertion.Should().Throw<MoySkladException>();
            }
        }

        [Test]
        public void If_filter_by_root_nesting_member_is_not_allowed_then_assertion_should_throw_api_exception()
        {
            Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.NotAllowedRootNestingFilterMember;
            Action assertion = () => new GuidFilterAssertions(expression, new List<FilterItem>());

            assertion.Should().Throw<MoySkladException>();
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void If_nesting_is_allowed_then_assertion_should_add_filter(string @operator)
        {
            var guid = Guid.NewGuid();
            var filters = new List<FilterItem>();
            Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.AllowedNestingFilterMember.NestedGuidMember;
            var subject = new GuidFilterAssertions(expression, filters);

            if (@operator == "=")
                subject.Be(guid);
            else if (@operator == "!=")
                subject.NotBe(guid);

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("allowedNestingFilterMember.nestedGuidMember1");
            filters[0].Operator.Should().Be(@operator);
            filters[0].Value.Should().Be(guid.ToString());
        }

        [Test]
        public void If_nesting_is_not_allowed_then_assertion_should_throw_api_exception()
        {
            Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.NotAllowedNestingFilterMember.NestedGuidMember;
            Action assertion = () => new GuidFilterAssertions(expression, new List<FilterItem>());

            assertion.Should().Throw<MoySkladException>();
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void If_nullable_value_is_not_allowed_then_assertion_should_throw_api_exception(string @operator)
        {
            var guid = Guid.NewGuid();
            var filters = new List<FilterItem>();
            Expression<Func<GuidAssertionsTestEntity, Guid?>> expression = p => p.NullableNotAllowedMember;
            var subject = new NullableGuidFilterAssertions(expression, filters);

            Action assertion = null;

            if (@operator != "=")
                assertion = () => subject.BeNull();
            if (@operator != "!=")
                assertion = () => subject.NotBeNull();

            assertion.Should().Throw<MoySkladException>();
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void If_operator_is_not_supported_then_assertion_should_throw_api_exception(string @operator)
        {
            var guid = Guid.NewGuid();
            var filters = new List<FilterItem>();
            Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.OverriddenOperatorsMember;
            var subject = new GuidFilterAssertions(expression, filters);

            Action assertion = null;

            if (@operator != "=")
                assertion = () => subject.Be(guid);
            if (@operator != "!=")
                assertion = () => subject.NotBe(guid);

            assertion.Should().Throw<MoySkladException>();
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Using_Assertion_with_other_Assertions_on_other_member_should_not_be_throw_api_exception(string @operator)
        {
            GuidFilterAssertions subject = null;

            var assertions = new Action[]
            {
                () => subject.Be(Guid.NewGuid()),
                () => subject.NotBe(Guid.NewGuid())
            };

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new[] { new FilterItem("guidMember1", @operator, "foo") });
                Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.GuidMember;
                subject = new GuidFilterAssertions(expression, filters);

                assertion.Should().NotThrow<MoySkladException>();
            }
        }

        [Test]
        [TestCase("=", new string[] { "=" })]
        [TestCase("!=", new string[] { "!=" })]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_add_filter_items(string @operator, string[] allowedOperators)
        {
            foreach (var allowedOperator in allowedOperators)
            {
                var guid = Guid.NewGuid();
                var filters = new List<FilterItem>(new[] { new FilterItem("guidMember", @operator, "foo") });
                Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.GuidMember;
                var subject = new GuidFilterAssertions(expression, filters);

                if (allowedOperator == "=")
                    subject.Be(guid);
                if (allowedOperator == "!=")
                    subject.NotBe(guid);

                filters.Should().HaveCount(2);
                filters[0].Name.Should().Be("guidMember");
                filters[0].Operator.Should().Be(@operator);
                filters[0].Value.Should().Be("foo");
                filters[1].Name.Should().Be("guidMember");
                filters[1].Operator.Should().Be(allowedOperator);
                filters[1].Value.Should().Be(guid.ToString());
            }
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_throw_api_exception(string @operator)
        {
            var guid = Guid.NewGuid();
            var filters = new List<FilterItem>(new[] { new FilterItem("guidMember", @operator, "foo") });
            Expression<Func<GuidAssertionsTestEntity, Guid>> expression = p => p.GuidMember;
            var subject = new GuidFilterAssertions(expression, filters);

            Action assertion = null;

            // operators '=' and '!=' can be used with other operators on the same field.
            if (@operator != "=")
                assertion = () => subject.Be(guid);
            if (@operator != "!=")
                assertion = () => subject.NotBe(guid);

            assertion.Should().Throw<MoySkladException>();
        }
    }

    public class GuidAssertionsTestEntity : MetaEntity
    {
        [Filter(allowNesting: true)]
        [Parameter("allowedNestingFilterMember")]
        public GuidAssertionsTestEntity1 AllowedNestingFilterMember { get; set; }

        [Filter]
        [Parameter("guidMember")]
        public Guid GuidMember { get; set; }

        [Filter(allowContinueConstraint: false)]
        [Parameter("notAllowedContinueConstraintMember")]
        public Guid NotAllowedContinueConstraintMember { get; set; }

        [Filter]
        [Parameter("notAllowedNestingFilterMember")]
        public GuidAssertionsTestEntity1 NotAllowedNestingFilterMember { get; set; }

        [Filter(allowNesting: true, allowFilterByRootNestingMember: false)]
        [Parameter("notAllowedRootNestingFilterMember")]
        public Guid NotAllowedRootNestingFilterMember { get; set; }

        public Guid NotFilteredMember { get; set; }

        [Filter]
        [Parameter("nullableMember")]
        public Guid? NullableMember { get; set; }

        [Filter(allowNull: false)]
        [Parameter("nullableNotAllowedMember")]
        public Guid? NullableNotAllowedMember { get; set; }

        [Filter(overriddenOperators: new[] { "<" })]
        [Parameter("overriddenOperatorsMember")]
        public Guid OverriddenOperatorsMember { get; set; }
    }

    public class GuidAssertionsTestEntity1 : MetaEntity
    {
        [Filter]
        [Parameter("nestedGuidMember1")]
        public Guid NestedGuidMember { get; set; }

        public Guid NestingNotFilteredMember { get; set; }
    }
}