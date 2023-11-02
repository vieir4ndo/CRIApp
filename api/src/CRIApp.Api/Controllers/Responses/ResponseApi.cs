#nullable enable

namespace CRIApp.Api.Controllers.Responses;

public class ApiResponse<T> where T : class?
{
    public bool Success { get; set; }
    public List<T> Data { get; set; } = new();
    public List<string> Messages { get; set; } = new();

    public ApiResponse(bool success, List<T>? data = null, List<string>? messages = null)
    {
        Success = success;
        Data = data ?? Data;
        Messages = messages ?? Messages;
    }

    public ApiResponse(string? message = null)
    {
        Success = false;
        Messages = !string.IsNullOrEmpty(message) ? new List<string>() { message } : Messages;
    }
}