using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Movies.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class IdentityController: ControllerBase
{
    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(from userClaim in User.Claims select new { userClaim.Type, userClaim.Value });
    }
}