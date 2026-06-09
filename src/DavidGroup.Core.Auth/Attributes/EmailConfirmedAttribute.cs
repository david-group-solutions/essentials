using DavidGroup.Core.Auth.Data;
using DavidGroup.Core.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DavidGroup.Core.Auth.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class EmailConfirmedAttribute : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var claim = context.HttpContext.User.FindFirst(DavidGroupClaimTypes.EmailConfirmed);

        if (claim is null || !bool.TryParse(claim.Value, out var confirmed) || !confirmed)
        {
            var result = OperationResult.Failure(
                new OperationResultMessage(ErrorMessages.EmailMustBeConfirmed, OperationResultSeverity.Error));
            
            context.Result = new ObjectResult(result)
            {
                ContentTypes = ["application/json"],
                StatusCode = StatusCodes.Status423Locked
            };
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context) { }
}