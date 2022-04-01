

namespace RomanParser.Core
{
    public class MaxSumValidaor : IValueValidator
    {
        public bool IsValid(string input)
        {
            Int32.TryParse(input, out int result);
            return result <= 3999;
        }
    }
}
