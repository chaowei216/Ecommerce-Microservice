using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class ApiController : ControllerBase
{
    
}