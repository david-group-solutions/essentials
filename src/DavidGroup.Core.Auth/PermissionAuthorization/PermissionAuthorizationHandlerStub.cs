using Microsoft.AspNetCore.Authorization;

namespace DavidGroup.Core.Auth.PermissionAuthorization;

public class PermissionAuthorizationHandlerStub : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
