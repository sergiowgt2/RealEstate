using System.Text.RegularExpressions;

namespace RealEstate.Domain.Validators;

public static class CpfCnpjValidador
{
    public static bool Validate(string toValidate)
    {
        toValidate = Regex.Replace(toValidate, "[^0-9]", "");
        var regex = new Regex(@"^\d{11}$|^\d{14}$");
        return regex.IsMatch(toValidate);
    }
}