using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FamilyPlanner_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]  // TODO: Uncomment this once Authorization has been set up
    public class ApiBaseController : ControllerBase
    {
        protected string GetCurrentUserID()
        {
            if (User.Identity is ClaimsIdentity identity)
            {
                // Extract the user ID from the claims (assuming it's stored in the "sub" claim)
                var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub");
                if (userIdClaim != null)
                {
                    return userIdClaim.Value;
                }
            }

             return null;
        }
    }
}
