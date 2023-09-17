using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ServiceFilter(typeof(LogUserActivity))]
[ApiController]
[Route("[Controller]")]
public class BaseController : ControllerBase
{

}
