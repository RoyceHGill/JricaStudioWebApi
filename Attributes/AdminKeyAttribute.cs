﻿using JricaStudioWebApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JricaStudioWebApi.Attributes
{

    /// <summary>
    /// The Purposed of this class is to: Authorize the Admin Key provided through the header of requests made to the Server. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AdminKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                if (context.HttpContext.Request.Headers.TryGetValue("AdminKey", out var result))
                {
                    Guid adminKey = Guid.Parse(result);

                    var adminRepo = context.HttpContext.RequestServices.GetRequiredService<IAdminRepository>();

                    if (await adminRepo.ValidateAdminKey(adminKey))
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
