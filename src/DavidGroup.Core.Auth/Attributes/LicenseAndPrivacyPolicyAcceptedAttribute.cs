using DavidGroup.Core.Auth.Data;
using DavidGroup.Core.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DavidGroup.Core.Auth.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class LicenseAndPrivacyPolicyAcceptedAttribute(string licenceVersion, string privacyPolicyVersion) : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var licenseClaim = context.HttpContext.User.FindFirst(DavidGroupClaimTypes.LicenceVersion);
        var privacyPolicyClaim = context.HttpContext.User.FindFirst(DavidGroupClaimTypes.PrivacyPolicyVersion);

        if (licenseClaim is null || privacyPolicyClaim is null ||
            licenseClaim.Value != licenceVersion ||
            privacyPolicyClaim.Value != privacyPolicyVersion)
        {
            var result = OperationResult.Failure(
                new OperationResultMessage(ErrorMessages.LicenseAndPrivacyPolicyAcceptanceRequired, OperationResultSeverity.Error));

            context.Result = new ObjectResult(result)
            {
                ContentTypes = ["application/json"],
                StatusCode = StatusCodes.Status423Locked
            };
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context) { }
}