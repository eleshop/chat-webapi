using Chat.Services.Interfaces.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebApi.Controllers.Common.CommonMessageController;

[Route("api/common/messages")]
[ApiController]
public class CommonMessageController : ControllerBase
{
    private readonly IMessageService _service;

    public CommonMessageController(IMessageService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
      => Ok(await _service.GetAllAsync());

    [HttpGet("{messageId}")]
    public async Task<IActionResult> GetByIdAsync(long messageId)
    => Ok(await _service.GetByIdAsync(messageId));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());
}
