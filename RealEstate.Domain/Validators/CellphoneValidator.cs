namespace RealEstate.Domain.Validators;
using System.Text.RegularExpressions;

public static class CellphoneValidator
{
    public static bool Validate(string cellphone)
    {
        var regex = new Regex(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3,4}-?[0-9]{4}$");
        return regex.IsMatch(cellphone);
    }
}
