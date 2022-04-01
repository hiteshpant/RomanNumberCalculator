namespace RomanNumberParser.WebMVC
{
    /// <summary>
    /// Validates if Input data is valid for Roman Input Mode or Numeric Mode
    /// </summary>
    public interface IInputModeValidator
    {
        bool IsRomanInputValid(string input1, string input2, out string result);

        bool IsNumericInputValid(string input1, string input2, out string result);
    }
}
