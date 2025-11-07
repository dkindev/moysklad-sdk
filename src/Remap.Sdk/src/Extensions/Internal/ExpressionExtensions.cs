using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Expression"/>.
    /// </summary>
    internal static class ExpressionExtensions
    {
        #region Methods

        public static string GetExpandName(this LambdaExpression parameter)
        {
            var members = parameter.GetMembers();

            var expanderBuilder = new StringBuilder(members.Count * 4);
            for (var i = 0; i < members.Count; i++)
            {
                var member = members[i];

                if (!member.IsAllowExpand())
                    throw new MoySkladException(400, $"Expand by member '{member.Name}' isn't available.'");

                if (expanderBuilder.Length > 1)
                    expanderBuilder.Append(".");

                expanderBuilder.Append(member.GetParameterName());
            }

            return expanderBuilder.ToString();
        }

        public static FilterAttribute GetFilter(this LambdaExpression parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            if (!(memberExpression.Member is MemberInfo memberInfo))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            return memberInfo.GetFilter();
        }

        public static string GetFilterName(this LambdaExpression parameter)
        {
            var members = parameter.GetMembers();

            var expanderBuilder = new StringBuilder(members.Count * 4);
            for (var i = 0; i < members.Count; i++)
            {
                var member = members[i];
                var filter = member.GetFilter();
                if (filter == null)
                    throw new MoySkladException(400, $"Filter by member '{member.Name}' isn't available.");

                if (!filter.AllowNesting && members.Count - 1 > i)
                    throw new MoySkladException(400, $"Filter by member '{member.Name}' is invalid. Filter nesting level should be {i + 1}.");

                if (filter.AllowNesting && !filter.AllowFilterByRootNestingMember && members.Count - 1 == i)
                    throw new MoySkladException(400, $"Filter by member '{member.Name}' isn't available. Filter is available only for nesting member(s).");

                if (expanderBuilder.Length > 1)
                    expanderBuilder.Append(".");

                expanderBuilder.Append(member.GetParameterName());
            }

            return expanderBuilder.ToString();
        }

        public static string GetFullParameterName(this LambdaExpression parameter)
        {
            var members = parameter.GetMembers();

            var expanderBuilder = new StringBuilder(members.Count * 4);
            for (var i = 0; i < members.Count; i++)
            {
                if (expanderBuilder.Length > 1)
                    expanderBuilder.Append(".");

                expanderBuilder.Append(members[i].GetParameterName());
            }

            return expanderBuilder.ToString();
        }

        public static int GetNestingLevel<T, TProperty>(this Expression<Func<T, TProperty>> parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            var nestingLevel = 0;
            while (memberExpression != null)
            {
                if (memberExpression.NodeType != ExpressionType.MemberAccess)
                    throw new InvalidOperationException($"Expression '{parameter}' should refers to the field or property.");

                memberExpression = memberExpression.Expression as MemberExpression;
                nestingLevel++;
            }

            return nestingLevel;
        }

        public static string GetOrderName<T, TProperty>(this Expression<Func<T, TProperty>> parameter)
        {
            var parameterName = parameter.GetParameterName();

            if (!parameter.IsAllowOrder())
                throw new MoySkladException(400, $"The order isn't allowed for the '{parameterName}' property.");

            if (parameter.GetNestingLevel() > 1)
                throw new MoySkladException(400, $"The nesting level of the '{parameterName}' property should be 1.");

            return parameterName;
        }

        public static string GetParameterName(this LambdaExpression parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            if (!(memberExpression.Member is MemberInfo memberInfo))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            return memberInfo.GetParameterName();
        }

        public static bool IsAllowExpand(this LambdaExpression parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            if (!(memberExpression.Member is MemberInfo memberInfo))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            return memberInfo.IsAllowExpand();
        }

        public static bool IsAllowOrder(this LambdaExpression parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            if (!(memberExpression.Member is MemberInfo memberInfo))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            return memberInfo.IsAllowOrder();
        }

        #endregion Methods

        #region Utilities

        private static List<MemberInfo> GetMembers(this LambdaExpression parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            var members = new List<MemberInfo>();
            while (memberExpression != null)
            {
                if (memberExpression.NodeType != ExpressionType.MemberAccess)
                    throw new InvalidOperationException($"Expression '{parameter}' should refers to the field or property.");

                members.Add(memberExpression.Member);
                memberExpression = memberExpression.Expression as MemberExpression;
            }

            members.Reverse();

            return members;
        }

        #endregion Utilities
    }
}