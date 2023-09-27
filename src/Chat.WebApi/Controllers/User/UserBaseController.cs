using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Chat.WebApi.Controllers.User;


[ApiController]
[AllowAnonymous]
public abstract class UserBaseController : ControllerBase
{
}