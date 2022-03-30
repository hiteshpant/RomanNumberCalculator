

namespace RomanParser.Core
{
    public class StringEmptyValidator : IValueValidator
    {
        public bool IsValid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
