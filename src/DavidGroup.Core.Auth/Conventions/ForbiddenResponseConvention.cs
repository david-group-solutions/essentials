using DavidGroup.Core.Auth.PermissionAuthorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DavidGroup.Core.Auth.Conventions;

public class ForbiddenResponseConvention : IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            foreach (var action in controller.Actions)
            {
                var hasPermission = action.Attributes.Any(a => a is AuthorizeAttribute) ||
                                    controller.Attributes.Any(a => a is AuthorizeAttribute)
                                    ||
                                    action.Attributes.Any(a => a is HasPermissionAttribute) ||
                                    controller.Attributes.Any(a => a is HasPermissionAttribute);

                if (hasPermission)
                {
                    action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status403Forbidden));
                }
            }
        }
    }
}