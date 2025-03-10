﻿// Ignore Spelling: Jrica

using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JricaStudioWebAPI.Attributes
{

    /// <summary>
    /// Placing this attribute above a rest controller end point uses the AdminKey in the header of the request to authorize the request. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AdministratorKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                if (context.HttpContext.Request.Headers.TryGetValue("AdminKey", out var result))
                {
                    Guid adminKey = Guid.Parse(result);

                    var adminRepo = context.HttpContext.RequestServices.GetRequiredService<IAdministratorRepository>();

                    if (await adminRepo.ValidateAdministratorKey(adminKey))
                    {
                        await next();
                    }
                    else
                    {
                        context.Result = new ContentResult { StatusCode = StatusCodes.Status401Unauthorized, Content = "Unauthorized key provided" };
                        return;
                    }

                }
                else
                {
                    context.Result = new ContentResult { StatusCode = StatusCodes.Status401Unauthorized, Content = "Key not provided" };
                    return;
                }

            }
            catch (Exception e)
            {
                context.Result = new ContentResult { StatusCode = StatusCodes.Status500InternalServerError, Content = e.Message };
                return;
            }
        }
    }
}
