using CRIApp.Api.Controllers.Requests;
using CRIApp.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CRIApp.Api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        request.ValidateAndThrow();
        
        await _service.Create(request.ToDto());

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        request.ValidateAndThrow();
        
        await _service.Login(request.ToDto());

        return Ok();
    }

    [HttpGet]
    public IActionResult Consult()
    {
        throw new NotImplementedException();
    }

    [HttpPatch]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public IActionResult Deactivate()
    {
        throw new NotImplementedException();
    }


    [HttpPost("forgot-password")]
    public IActionResult ForgotPassword()
    {
        throw new NotImplementedException();
    }

    [HttpPost("reset-password")]
    public IActionResult ResetPassword()
    {
        throw new NotImplementedException();
    }
}