using Microsoft.AspNetCore.Authorization;

namespace DavidGroup.Core.Auth.PermissionAuthorization;

public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}
