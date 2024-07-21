using System;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the attribute to allow 'order' parameter on the entity member.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class AllowOrderAttribute : Attribute
    {
    }
}