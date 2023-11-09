using CRIApp.Api.Controllers.Responses;
using CRIApp.Application.Abstractions;
using CRIApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRIApp.Api.Controllers;

[ApiController]
[Route("question")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _service;

    public QuestionController(IQuestionService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<ApiResponse<Question>> GetAll()
    {
        var data = await _service.GetAll();

        return new ApiResponse<Question>(true, data);
    }

}