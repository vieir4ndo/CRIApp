using CRIApp.Api.Controllers.Requests;
using CRIApp.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CRIApp.Api.Controllers;

[ApiController]
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

    [HttpPost]
    public IActionResult Login()
    {
        throw new NotImplementedException();
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


    [HttpPost]
    public IActionResult ForgotPassword()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult ResetPassword()
    {
        throw new NotImplementedException();
    }
}