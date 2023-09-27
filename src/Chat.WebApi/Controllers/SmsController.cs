using Chat.Persistence.Dtos.Notifications;
using Chat.Services.Interfaces.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebApi.Controllers;

[Route("api/sms")]
[ApiController]
public class SmsController : ControllerBase
{
    private readonly ISmsSender _smsSender;
    public SmsController(ISmsSender smsSender)
    {
        this._smsSender = smsSender;
    }

    [HttpPost]
    public async Task<IActionResult> SendAsync([FromBody] SmsMessage smsMessage)
    {
        return Ok(await _smsSender.SendAsync(smsMessage));
    }
}
