using CRIApp.Domain.Exceptions;

namespace CRIApp.Domain;

public static class Validations
{
    public static void IsNullOrEmpty(this string text, string message)
    {
        if (string.IsNullOrEmpty(text))
            throw new DomainException(message);
    }
    
    
    public static void HasElements<T>(this IList<T> list, string message)
    {
        if (list.Any())
            throw new DomainException(message);
    }

    public static void IsEmpty(this Guid guid, string message)
    {
        if (guid == Guid.Empty)
            throw new DomainException(message);
    }

    public static void IsActive(this bool active, string message)
    {
        if (active is false)
            throw new DomainException(message);
    }

    public static void IsValueInRange(this int value, int min, int max, string message)
    {
        if (value < min || value > max)
            throw new DomainException(message);
    }
    
}