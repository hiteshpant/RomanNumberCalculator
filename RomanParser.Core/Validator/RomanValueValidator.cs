using System.Text.RegularExpressions;

namespace RomanParser.Core
{
    public class RomanValueValidator : IValueValidator
    {
        // M{0,3}
        //specifies the thousands section and basically restrains it to between 0 and 4000 
        //(CM|CD|D? C {0,3}) is for the hundreds section.
        //(XC|XL|L? X {0,3}) is for the tens place.
        //Finally, (IX|IV|V? I {0,3}) is the units section.
        public bool IsValid(string input)
        {
            if(string.IsNullOrEmpty(input))
                throw new ArgumentNullException("Input cannot be null or empty");

            string pattern = @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

            // Create a Regex  
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            return rg.IsMatch(input.ToUpper()) ? true : throw new InValidRomanValueException("Invalid Roman Sequence");
        }
    }
}
