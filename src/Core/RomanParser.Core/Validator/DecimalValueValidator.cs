

namespace RomanParser.Core
{
    public class DecimalValueValidator : IValueValidator
    {
        public bool IsValid(string input)
        {
            return Int32.TryParse(input, out int result) == true ? true :throw new InvalidDataException
                                                            ("Invalid Numeric Data, Please enter Valid numeric data");           
        }
    }
}
