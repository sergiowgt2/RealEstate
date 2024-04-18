namespace RealEstate.Domain.Exceptions;

public class DomainException : Exception
{
    DomainException(string message) : base(message) {     }

    public static void When(bool condition, string message) =>
        condition ? throw new DomainValidationError(message) : null;
}