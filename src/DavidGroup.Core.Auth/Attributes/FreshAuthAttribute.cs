using DavidGroup.Core.Auth.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DavidGroup.Core.Auth.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class FreshAuthAttribute : TypeFilterAttribute
{
    public FreshAuthAttribute(long maxAgeInSeconds) : base(typeof(FreshAuthFilter))
    {
        Arguments = [maxAgeInSeconds];
    }
}