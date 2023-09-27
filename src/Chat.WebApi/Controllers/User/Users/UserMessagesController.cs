using Chat.Domain.Entities.Messages;
using Chat.Persistence.Dtos.Messages;
using Chat.Services.Interfaces.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebApi.Controllers.User.Users;

[Route("api/user/messages")]
[ApiController]
public class UserMessagesController : UserBaseController
{
    private readonly IMessageService _service;

    public UserMessagesController(IMessageService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] MessageCreateDto dto)
    {
        //var validator = new ProductCreateValidator();
        //var result = validator.Validate(dto);
        //if (result.IsValid)
        return Ok(await _service.CreateAsync(dto));
        //else return BadRequest(result.Errors);
    }

    [HttpPut("{messageId}")]
    public async Task<IActionResult> UpdateAsync(long messageId, [FromForm] MessageUpdateDto dto)
    {
        //var updateValidator = new ProductUpdateValidator();
        //var validationResult = updateValidator.Validate(dto);
        //if (validationResult.IsValid)
        return Ok(await _service.UpdateAsync(messageId, dto));
        //else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{messageId}")]
    public async Task<IActionResult> DeleteAsync(long messageId)
        => Ok(await _service.DeleteAsync(messageId));
}
