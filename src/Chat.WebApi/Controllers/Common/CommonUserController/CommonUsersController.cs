using Chat.Services.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebApi.Controllers.Common.CommonUserController;

[Route("api/common/users")]
[ApiController]
public class CommonUsersController : ControllerBase
{
    private readonly IUserService _service;

    public CommonUsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
      => Ok(await _service.GetAllAsync());

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByIdAsync(long userId)
    => Ok(await _service.GetByIdAsync(userId));
}
