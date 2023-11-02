namespace CRIApp.Domain.Exceptions;

public class ValidationException : Exception
{
    public List<string> Errors { get; set; }
    
    public ValidationException(List<string> errors)
    {
        Errors = errors;
    }
}