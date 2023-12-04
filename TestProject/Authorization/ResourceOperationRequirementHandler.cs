using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TestProject.Entities;

namespace TestProject.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, GroceryList>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, GroceryList grocery)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read || requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (grocery.UserId == int.Parse(userId)) 
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
