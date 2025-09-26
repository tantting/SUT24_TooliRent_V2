using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SUT24_TooliRent_V2.Swagger;

public class SwaggerDefaultValues : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var hasAuthorize = context.MethodInfo.DeclaringType!.GetCustomAttributes(true)
                               .OfType<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>().Any() ||
                           context.MethodInfo.GetCustomAttributes(true)
                               .OfType<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>().Any();

        if (hasAuthorize)
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();

            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                }] = new string[] { }
            });
        }
    }
}