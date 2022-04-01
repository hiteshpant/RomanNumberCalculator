using System.Text.RegularExpressions;

namespace RomanNumberParser.WebMVC
{
    public class InputModeValidator : IInputModeValidator
    {
        /// <summary>
        /// This is somthing repetative in clien, but better to validate here also the input
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool IsRomanInputValid(string input1, string input2, out string result)
        {
            string pattern = @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            result = String.Empty;
            // Create a Regex  
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            var isMatch = rg.IsMatch(input1.ToUpper()) && rg.IsMatch(input2.ToUpper());
            if (isMatch == false)
            {
                result = @" I,X or C you cannot have more than three occurance and V,L or D cannot have more than one occurence
                            Please try with correct format";
            }
            return isMatch;
        }

        public bool IsNumericInputValid(string input1, string input2, out string result)
        {
            var isMatched = int.TryParse(input1, out int d) && int.TryParse(input2, out int d1);
            result = String.Empty;
            if (isMatched == false)
            {
                result = @"Only Numeric data is allowed in this mode";
            }

            return isMatched;
        }
    }
}
