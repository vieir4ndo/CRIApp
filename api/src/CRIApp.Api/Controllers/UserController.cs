using Microsoft.AspNetCore.Mvc;

namespace CRIApp.Api.Controllers;

[ApiController]
public class UserController
{
    [HttpPost]
    public IActionResult Create()
    {
        throw new NotImplementedException();
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